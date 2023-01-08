/*using ChessAnimation.Models;
using ChessAnimation.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnimation.Drawing
{
	internal static class Filler
	{
		public static void fillObject(Object3D object3D, ProjectData projectData)
		{
			foreach (Polygon polygon in object3D.polygons)
			{
				fillPolygon(polygon, projectData);
			}
		}
		
		public static void fillPolygons(ProjectData projectData)
		{

			if (projectData.useTexture && projectData.useNormalMap)
			{
				Parallel.ForEach(projectData.polygons, polygon => fillPolygon(polygon, projectData, projectData.snoop, projectData.textureSnoop, null, projectData.normalMapSnoop));
				//foreach (Polygon polygon in projectData.polygons) fillPolygon(polygon, projectData, snoop, texture, null, normalMap);
			}
			else if (projectData.useTexture)
			{
				Parallel.ForEach(projectData.polygons, polygon => fillPolygon(polygon, projectData, projectData.snoop, projectData.textureSnoop, null, null));
				//foreach (Polygon polygon in projectData.polygons) fillPolygon(polygon, projectData, snoop, texture, null, null);

			}
			else if (projectData.useNormalMap)
			{
				Parallel.ForEach(projectData.polygons, polygon => fillPolygon(polygon, projectData, projectData.snoop, null, null, projectData.normalMapSnoop));
				//foreach (Polygon polygon in projectData.polygons) fillPolygon(polygon, projectData, snoop, null, null, normalMap);
			}
			else
			{
				Parallel.ForEach(projectData.polygons, polygon => fillPolygon(polygon, projectData, projectData.snoop, null, null, null));
			}

			projectData.workingArea.Refresh();

			return;
		}

		public static void fillPolygons2(ProjectData projectData, int i, Color? polyColor = null)
		{
			fillPolygon(projectData.polygons[i], projectData, projectData.snoop, null, polyColor, null);
		}

		public static void fillPolygon(Polygon polygon, ProjectData projectData, BmpPixelSnoop bitmap, BmpPixelSnoop? texture, Color? objectColor = null, BmpPixelSnoop? normalMap = null)
		{
			List<Vertex> vertices = polygon.vertices;

			if (projectData.interpolateColor)
			{
				ColorGenerator.setVerticesColors(polygon, projectData, texture);
			}

			List<Vertex> sortedVertices = vertices.OrderBy(vertex => vertex.y).ToList();

			int[] ind = new int[polygon.vertices.Count];
			for (int i = 0; i < vertices.Count; i++)
			{
				ind[i] = vertices.IndexOf(sortedVertices[i]);
			}

			int ymin = (int)sortedVertices.First().y;
			int ymax = (int)sortedVertices.Last().y;

			List<AETPointer> AET = new List<AETPointer>();


			{ // do debugowania
				int k = 0;  // iterator po tablicy sortedVerticesIndexes
				for (int y = ymin + 1; y <= ymax; ++y)
				{
					while ((int)vertices[ind[k]].y == y - 1)
					{
						int prevVertexIndex = (ind[k] - 1 + vertices.Count) % vertices.Count;
						int nextVertexIndex = (ind[k] + 1 + vertices.Count) % vertices.Count;

						if (vertices[prevVertexIndex].y >= vertices[ind[k]].y)
						{
							Vertex u = vertices[prevVertexIndex];
							Vertex v = vertices[ind[k]];

							float m = (u.y - v.y) / (u.x - v.x);
							float alfa;
							if (Math.Abs(m) < 0.00000001)
								alfa = 0;
							else
								alfa = 1 / m;

							AETPointer pointer = new AETPointer(u.y, v.x, alfa);
							AET.Add(pointer);
						}

						if (vertices[nextVertexIndex].y >= vertices[ind[k]].y)
						{
							Vertex u = vertices[nextVertexIndex];
							Vertex v = vertices[ind[k]];

							float m = (u.y - v.y) / (u.x - v.x);
							float alfa;
							if (Math.Abs(m) < 0.00000001)
								alfa = 0;
							else
								alfa = 1 / m;

							AETPointer pointer = new AETPointer(u.y, v.x, alfa);
							AET.Add(pointer);
						}

						k++;

						AET.RemoveAll(pointer => (int)pointer.y_max <= y - 1);
					}

					AET = AET.OrderBy(pointer => pointer.x).ToList();

					for (int i = 0; i < AET.Count; i += 2)
					{
						for (int x = (int)AET[i].x; x <= (int)AET[i + 1].x; ++x)
						{
							if (x >= projectData.workingArea.Width || x <= 0)
							{
								continue;
							}

							Color color;

							if (projectData.interpolateColor)
							{
								// interpolacja koloru 
								color = ColorGenerator.generatePixelColor(polygon, x, y);
							}
							else
							{
								// interpolacja wektora
								Vector3 normal = projectData.normalsTab[x, y];
								color = ColorGenerator.generatePixelColorFromNormalVector(polygon, projectData, x, y, normal, texture);
							}

							// debugowanie
							if (objectColor != null)
							{
								color = (Color)objectColor;
							}

							bitmap.SetPixel(x, y, color);
						}
					}

					if (AET.Count % 2 != 0)
					{
						Debug.WriteLine("AET.Count % 2 != 0");
					}

					foreach (var a in AET)
					{
						a.x += a.alfa;
					}

				}
			}
		}
	}
}

*/