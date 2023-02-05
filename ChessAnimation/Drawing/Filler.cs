using ChessAnimation.Enums;
using ChessAnimation.Models;
using ChessAnimation.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnimation.Drawing
{
	internal static class Filler
	{
		public static void fillObjects(ProjectData projectData)
		{
			//Parallel.ForEach(projectData.objects, (object3D) => fillPolygons(projectData, object3D));

			foreach (Object3D object3D in projectData.objects)
			{
				fillPolygons(projectData, object3D);
			}
		}

		public static void fillPolygons(ProjectData projectData, Object3D object3D)
		{
			
			//Parallel.ForEach(object3D.polygons, polygon => fillPolygon(polygon, projectData, projectData.snoop, null, null, null));
			foreach (Polygon polygon in object3D.polygons)
			{
				fillPolygon(polygon, projectData, projectData.snoop, null, null, null);


				//projectData.workingArea.Refresh();
				int a = 0;
			}


			return;
		}

		public static void fillPolygon(Polygon polygon, ProjectData projectData, BmpPixelSnoop bitmap, BmpPixelSnoop? texture, Color? objectColor = null, BmpPixelSnoop? normalMap = null)
		{

			if (ColorGenerator.backFaceCulling(polygon, projectData.cameraPosition, projectData.debug))
			{
				return;
			}

			polygon.calculateDenominatorCopy();

			List<Vertex> vertices = polygon.verticesCopy;

			if (projectData.colorMode == ColorMode.Gouraud || projectData.colorMode == ColorMode.Static)
			{
				ColorGenerator.setVerticesColors(polygon, projectData, texture);
			}

			List<Vertex> sortedVertices = vertices.OrderBy(vertex => vertex.y).ToList();

			int[] ind = new int[polygon.verticesCopy.Count];
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
							if (y >= projectData.workingArea.Height || y <= 0)
							{
								continue;
							}
							if (projectData.zBuffer[x, y] > ColorGenerator.interpolateZ(polygon, x, y))
							{
								continue;
							}

							Color color = projectData.objColor;

							if (projectData.colorMode == ColorMode.Gouraud)
							{
								// interpolacja koloru 
								color = ColorGenerator.generatePixelColor(polygon, x, y);
							}
							else if (projectData.colorMode == ColorMode.Phong)
							{
								// interpolacja wektora
								Vector3 normal = ColorGenerator.interpolateNormal(polygon, x, y);
								color = ColorGenerator.generatePixelColorFromNormalVector(polygon, projectData, x, y, normal, texture);
							}
							else if (projectData.colorMode == ColorMode.Static)
							{
								color = ColorGenerator.getAverageColor(polygon);
							}

							// debugowanie
							if (objectColor != null)
							{
								color = (Color)objectColor;
							}

							//color = Color.LightGreen;
							float z = ColorGenerator.interpolateZ(polygon, x, y);

							if (projectData.fog)
							{
								float fogRation = 0;
								if (z < projectData.fogStart)
								{
									fogRation = 0;
								}
								else
								{
									fogRation = (z - projectData.fogStart) / (projectData.fogEnd - projectData.fogStart);
								}
								
								/*if (fogRation >= 0.4f)
								{
									fogRation = 0.4f;
								}*/
								float fog = 255 * fogRation;
								//Debug.WriteLine("FogRation: " + fogRation);
								color = Color.FromArgb(Math.Clamp((int)(color.R + fog), 0, 255), Math.Clamp((int)(color.G + fog), 0, 255), Math.Clamp((int)(color.B + fog), 0, 255));
								//color = Color.FromArgb(Math.Clamp((int)(color.R + 100), 0, 255), Math.Clamp((int)(color.G + 100), 0, 255), Math.Clamp((int)(color.B + 100), 0, 255));
							}
							
							//Debug.WriteLine("z: " + z);

							projectData.zBuffer[x, y] = z;

							/*if (color.R < 10 || color.G < 10 || color.B < 10)
							{
								bitmap.SetPixel(x, y, Color.LightGray);
							}
							else
							{
								bitmap.SetPixel(x, y, color);
							}*/

							bitmap.SetPixel(x, y, color);

							//bitmap.SetPixel(x, y, Color.Green);


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
		} // fillPolygon
	}
}

