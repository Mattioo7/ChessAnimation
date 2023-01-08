/*using ChessAnimation.Models;
using ChessAnimation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnimation.Drawing
{
	internal static class ColorGenerator
	{
		public static void setVerticesColors(Polygon polygon, ProjectData projectData, BmpPixelSnoop texture)
		{
			float kd = projectData.kd;
			float ks = projectData.ks;
			int m = projectData.m;
			Color sun = projectData.sunColor;
			Vector3 sunPosition = new Vector3(projectData.sunPosition.X, projectData.sunPosition.Y, projectData.sunPosition.Z * projectData.sunHeightModifier);
			Color objColor = projectData.objColor; // zawsze będzie ustawiony, bo domyślny

			foreach (Vertex vertex in polygon.vertices)
			{
				if (projectData.useTexture)
				{
					int x = (int)vertex.x;
					int y = (int)vertex.y;

					if (vertex.x > texture.Width)
					{
						//x = texture.Width - 1;
						// z domyślnego
					}
					else if (vertex.y > texture.Height)
					{
						//y = texture.Height - 1;
						// z domyślnego
					}
					else
					{
						objColor = texture.GetPixel(x, y);
					}
				}

				Vector3 sunVector = sunPosition - vertex;
				Vector3 L = Vector3.Normalize(sunVector);

				Vector3 N = Vector3.Normalize(vertex.normal);
				Vector3 rVec = 2 * dot(N, L) * N - L;
				Vector3 R = Vector3.Normalize(rVec);

				Vector3 V = new Vector3(0, 0, 1);

				float RR = toUnity(sun.R) * toUnity(objColor.R) * (kd * cosine(N, L) + ks * (float)Math.Pow(cosine(V, R), m));
				float GG = toUnity(sun.G) * toUnity(objColor.G) * (kd * cosine(N, L) + ks * (float)Math.Pow(cosine(V, R), m));
				float BB = toUnity(sun.B) * toUnity(objColor.B) * (kd * cosine(N, L) + ks * (float)Math.Pow(cosine(V, R), m));

				vertex.R = fromUnity(RR); if (vertex.R > 255) vertex.R = 255; if (vertex.R < 0) vertex.R = 0;
				vertex.G = fromUnity(GG); if (vertex.G > 255) vertex.G = 255; if (vertex.G < 0) vertex.G = 0;
				vertex.B = fromUnity(BB); if (vertex.B > 255) vertex.B = 255; if (vertex.B < 0) vertex.B = 0;
				vertex.A = 255;
			}
		}

		public static void setVerticesColorsTest(Polygon polygon)
		{
			for (int i = 0; i < 3; ++i)
			{
				polygon.vertices[i].A = 250;

				if (i == 0)
				{
					polygon.vertices[i].R = 250;
					polygon.vertices[i].G = 1;
					polygon.vertices[i].B = 1;
				}
				if (i == 1)
				{
					polygon.vertices[i].R = 1;
					polygon.vertices[i].G = 250;
					polygon.vertices[i].B = 1;
				}
				if (i == 2)
				{
					polygon.vertices[i].R = 1;
					polygon.vertices[i].G = 1;
					polygon.vertices[i].B = 250;
				}
			}
		}

		public static Color generatePixelColor(Polygon polygon, int x, int y)
		{
			Vertex v1 = polygon.vertices[0];
			Vertex v2 = polygon.vertices[1];
			Vertex v3 = polygon.vertices[2];

			float denominator = polygon.denominator;
			float W_v1 = ((v2.y - v3.y) * (x - v3.x) + (v3.x - v2.x) * (y - v3.y)) / denominator;
			float W_v2 = ((v3.y - v1.y) * (x - v3.x) + (v1.x - v3.x) * (y - v3.y)) / denominator;
			float W_v3 = 1 - W_v1 - W_v2;

			int colorA = (int)(v1.A * W_v1 + v2.A * W_v2 + v3.A * W_v3);
			int colorR = (int)(v1.R * W_v1 + v2.R * W_v2 + v3.R * W_v3);
			int colorG = (int)(v1.G * W_v1 + v2.G * W_v2 + v3.G * W_v3);
			int colorB = (int)(v1.B * W_v1 + v2.B * W_v2 + v3.B * W_v3);

			if (colorA > 255) colorA = 255; if (colorA < 0) colorA = 0;
			if (colorR > 255) colorR = 255; if (colorR < 0) colorR = 0;
			if (colorG > 255) colorG = 255; if (colorG < 0) colorG = 0;
			if (colorB > 255) colorB = 255; if (colorB < 0) colorB = 0;

			Color color = Color.FromArgb(colorA, colorR, colorG, colorB);

			return color;
		}

		public static Color generatePixelColorFromNormalVector(Polygon polygon, ProjectData projectData, int x, int y, Vector3 normal, BmpPixelSnoop? texture)
		{
			//Stopwatch timing = new Stopwatch();
			//timing.Start();

			float kd = projectData.kd;
			float ks = projectData.ks;
			int m = projectData.m;
			Color sun = projectData.sunColor;
			Vector3 sunPosition = new Vector3(projectData.sunPosition.X, projectData.sunPosition.Y, projectData.sunPosition.Z * projectData.sunHeightModifier);
			Color objColor = projectData.objColor; // zawsze będzie ustawiony, bo domyślny

			if (projectData.useTexture)
			{
				if (x > texture.Width)
				{
					//x = texture.Width - 1;
					// z domyślnego
				}
				else if (y > texture.Height)
				{
					//y = texture.Height - 1;
					// z domyślnego
				}
				else
				{
					objColor = texture.GetPixel(x, y);
				}
			}

			Vector3 vertex = new Vector3(x, y, interpolateZ(polygon, x, y));

			Vector3 sunVector = sunPosition - vertex;
			Vector3 L = Vector3.Normalize(sunVector);

			Vector3 N = Vector3.Normalize(normal);
			Vector3 rVec = 2 * dot(N, L) * N - L;
			Vector3 R = Vector3.Normalize(rVec);

			Vector3 V = new Vector3(0, 0, 1);

			float RR = toUnity(sun.R) * toUnity(objColor.R) * (kd * cosine(N, L) + ks * (float)Math.Pow(cosine(V, R), m));
			float GG = toUnity(sun.G) * toUnity(objColor.G) * (kd * cosine(N, L) + ks * (float)Math.Pow(cosine(V, R), m));
			float BB = toUnity(sun.B) * toUnity(objColor.B) * (kd * cosine(N, L) + ks * (float)Math.Pow(cosine(V, R), m));

			int colorR = fromUnity(RR); if (colorR > 255) colorR = 255; if (colorR < 0) colorR = 0;
			int colorG = fromUnity(GG); if (colorG > 255) colorG = 255; if (colorG < 0) colorG = 0;
			int colorB = fromUnity(BB); if (colorB > 255) colorB = 255; if (colorB < 0) colorB = 0;
			int colorA = 255;

			//timing.Stop();
			//Debug.WriteLine("Elapsed time generatePixelColorFromNormalVector: {0} ms", timing.ElapsedMilliseconds);

			return Color.FromArgb(colorA, colorR, colorG, colorB);
		}

		public static Vector3 interpolateNormal(Polygon polygon, int x, int y)
		{
			//Stopwatch timing = new Stopwatch();
			//timing.Start();

			Vertex v1 = polygon.vertices[0];
			Vertex v2 = polygon.vertices[1];
			Vertex v3 = polygon.vertices[2];

			float denominator = polygon.denominator;
			float W_v1 = ((v2.y - v3.y) * (x - v3.x) + (v3.x - v2.x) * (y - v3.y)) / denominator;
			float W_v2 = ((v3.y - v1.y) * (x - v3.x) + (v1.x - v3.x) * (y - v3.y)) / denominator;
			float W_v3 = 1 - W_v1 - W_v2;

			float normalX = (float)(v1.normal.X * W_v1 + v2.normal.X * W_v2 + v3.normal.X * W_v3);
			float normalY = (float)(v1.normal.Y * W_v1 + v2.normal.Y * W_v2 + v3.normal.Y * W_v3);
			float normalZ = (float)(v1.normal.Z * W_v1 + v2.normal.Z * W_v2 + v3.normal.Z * W_v3);

			Vector3 normal = new Vector3(normalX * 255, normalY * 255, normalZ * 255);

			//timing.Stop();
			//Debug.WriteLine("Elapsed time interpolateNormal: {0} ms", timing.ElapsedMilliseconds);

			return normal;
		}

		public static int interpolateZ(Polygon polygon, int x, int y)
		{
			Vertex v1 = polygon.vertices[0];
			Vertex v2 = polygon.vertices[1];
			Vertex v3 = polygon.vertices[2];

			float denominator = polygon.denominator;
			float W_v1 = ((v2.y - v3.y) * (x - v3.x) + (v3.x - v2.x) * (y - v3.y)) / denominator;
			float W_v2 = ((v3.y - v1.y) * (x - v3.x) + (v1.x - v3.x) * (y - v3.y)) / denominator;
			float W_v3 = 1 - W_v1 - W_v2;

			int z = (int)(v1.z * W_v1 + v2.z * W_v2 + v3.z * W_v3);

			return z;
		}

		public static float cosine(Vector3 v1, Vector3 v2)
		{
			return Math.Max(v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z, 0);
		}

		public static float dot(Vector3 v1, Vector3 v2)
		{
			return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
		}

		public static float toUnity(int a)
		{
			return a / 255.0f;
		}

		public static byte fromUnity(float a)
		{
			float result = a * 255.0f;
			if (result > 255) result = 255; if (result < 0) result = 0;
			return (byte)(result);
		}
	}
}
*/