﻿using ChessAnimation.Models;
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
			foreach (Object3D object3D in projectData.objects)
			{
				fillPolygons(projectData, object3D);
			}
		}

		public static void fillPolygons(ProjectData projectData, Object3D object3D)
		{

			/*if (projectData.useTexture && projectData.useNormalMap)
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
			}*/


			//projectData.workingArea.Refresh();
			//Parallel.ForEach(object3D.polygons, polygon => fillPolygon(polygon, projectData, projectData.snoop, null, null, null));
			foreach (Polygon polygon in object3D.polygons)
			{
				fillPolygon(polygon, projectData, projectData.snoop, null, null, null);

				//projectData.workingArea.Refresh();
				int a = 0;
			}

			//projectData.workingArea.Refresh();
			return;
		}

		/*public static void fillPolygons2(ProjectData projectData, int i, Color? polyColor = null)
		{
			fillPolygon(projectData.polygons[i], projectData, projectData.snoop, null, polyColor, null);
		}*/

		public static void fillPolygon(Polygon polygon, ProjectData projectData, BmpPixelSnoop bitmap, BmpPixelSnoop? texture, Color? objectColor = null, BmpPixelSnoop? normalMap = null)
		{
			// back face culling
			/*Vector3 vectorToUs = projectData.cameraPosition - polygon.verticesCopy[0].position;
			vectorToUs = Vector3.Normalize(vectorToUs);
			Vector3 faceNormal = new Vector3(polygon.verticesCopy[0].normal.X, polygon.verticesCopy[0].normal.Y, polygon.verticesCopy[0].normal.Z);
			faceNormal = Vector3.Normalize(faceNormal);
			float dot = Vector3.Dot(vectorToUs, faceNormal);
			if (dot <= 0)
			{
				int bb = 0;
				return;
			}*/

			if (ColorGenerator.backFaceCulling(polygon, projectData.cameraPosition, projectData.debug))
			{
				return;
			}

			polygon.calculateDenominatorCopy();

			List<Vertex> vertices = polygon.verticesCopy;

			if (projectData.interpolateColor)
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
							if (projectData.zBuffer[x, y] < ColorGenerator.interpolateZ(polygon, x, y))
							{
								continue;
							}

							Color color = projectData.objColor;

							if (projectData.interpolateColor)
							{
								// interpolacja koloru 
								color = ColorGenerator.generatePixelColor(polygon, x, y);
							}
							else
							{
								// interpolacja wektora
								Vector3 normal = ColorGenerator.interpolateNormal(polygon, x, y);
								color = ColorGenerator.generatePixelColorFromNormalVector(polygon, projectData, x, y, normal, texture);
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
								if (fogRation >= 0.3f)
								{
									fogRation = 0.3f;
								}
								//Debug.WriteLine("FogRation: " + fogRation);
								color = Color.FromArgb(Math.Clamp((int)(color.R + 255 * fogRation), 0, 255), Math.Clamp((int)(color.G + 255 * fogRation), 0, 255), Math.Clamp((int)(color.B + 255 * fogRation), 0, 255));
								//color = Color.FromArgb(Math.Clamp((int)(color.R + 100), 0, 255), Math.Clamp((int)(color.G + 100), 0, 255), Math.Clamp((int)(color.B + 100), 0, 255));
							}
							
							//Debug.WriteLine("z: " + z);
							
							projectData.zBuffer[x, y] = z;
							bitmap.SetPixel(x, y, color);

							/*if (projectData.zBuffer[x, y] >= ColorGenerator.interpolateZ(polygon, x, y))
							{
								projectData.zBuffer[x, y] = ColorGenerator.interpolateZ(polygon, x, y);
								bitmap.SetPixel(x, y, color);
							}*/
							//bitmap.SetPixel(x, y, color);
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

