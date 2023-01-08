using ChessAnimation.Models;
using ObjLoader.Loader.Data.VertexData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertex = ChessAnimation.Models.Vertex;

namespace ChessAnimation.ObjHelpers
{
	internal class Converters
	{
		public static void convertVerticesFromNormalizedObj(List<Polygon> polygons, int width, int height)
		{
			foreach (Polygon polygon in polygons)
			{
				convertVerticesFromNormalizedObj(polygon, width, height);
			}
		}

		public static void convertVerticesFromNormalizedObj(Polygon polygon, int width, int height)
		{
			// Konwersja x z [c,d] do [a,b]
			// a + (b - a) * (x - c) / (d - c)

			// [-1, 1] do [0, len]
			// 0 + (len - 0) * (x - -1) / (1 - -1)

			int len = width < height ? width : height;

			foreach (Vertex vertex in polygon.vertices)
			{
				vertex.y = len * (vertex.y + 1) / 2 + 20;
				vertex.x = len * (vertex.x + 1) / 2 + 20;
				vertex.z = len * (vertex.z + 1) / 2;

				/*float nX = len * (vertex.normal.X + 1) / 2;
				float nY = len * (vertex.normal.Y + 1) / 2;
				float nZ = len * (vertex.normal.Z + 1) / 2;*/

				/*float nX = len * vertex.normal.X;
				float nY = len * vertex.normal.Y;
				float nZ = len * vertex.normal.Z;

				vertex.normal = new System.Numerics.Vector3(nX, nY, nZ);*/
			}
		}
	}
}
