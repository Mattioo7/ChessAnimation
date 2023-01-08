using ObjLoader.Loader.Data.Elements;
using ObjLoader.Loader.Data.VertexData;
using ObjLoader.Loader.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnimation.Models
{
	internal class Polygon
	{
		public List<Vertex> vertices { get; set; }
		public List<Vertex> verticesCopy { get; set; }
		

		public float denominator { get; set; }

		public Polygon()
		{
			vertices = new List<Vertex>();
			verticesCopy = new List<Vertex>();
		}

		public Polygon(List<Vertex> vertices)
		{
			this.vertices = vertices;

			// assign to verticesCopy deep copy of vertices
			verticesCopy = new List<Vertex>();
			foreach (Vertex vertex in vertices)
			{
				verticesCopy.Add(new Vertex(vertex));
			}
		}

		public Polygon(Polygon polygon)
		{
			vertices = new List<Vertex>();
			foreach (Vertex vertex in polygon.vertices)
			{
				vertices.Add(new Vertex(vertex));
			}

			verticesCopy = new List<Vertex>();
			foreach (Vertex vertex in polygon.verticesCopy)
			{
				verticesCopy.Add(new Vertex(vertex));
			}
		}

		public static List<Polygon> makePolygonListFromLoadResult(LoadResult loadResult)
		{
			List<Polygon> polygons = new List<Polygon>();

			// każdego for'a mogę rozbić na metody
			for (int i = 0; i < loadResult.Groups[0].Faces.Count; i++)
			{
				Polygon polygon = new Polygon();
				Face face = loadResult.Groups[0].Faces[i];

				for (int j = 0; j < face.Count; j++)
				{
					FaceVertex faceVertex = face[j];
					ObjLoader.Loader.Data.VertexData.Vertex vertex = loadResult.Vertices[faceVertex.VertexIndex - 1];
					Normal normal = loadResult.Normals[faceVertex.NormalIndex - 1];

					Vertex newVertex = new Vertex(vertex, normal);
					Vertex newVertexCopy = new Vertex(vertex, normal);

					polygon.vertices.Add(newVertex);
					polygon.verticesCopy.Add(newVertexCopy);
				}

				polygons.Add(polygon);
			}

			return polygons;
		}

		public void calculateDenominator()
		{
			Vertex v1 = this.vertices[0];
			Vertex v2 = this.vertices[1];
			Vertex v3 = this.vertices[2];
			this.denominator = ((v2.y - v3.y) * (v1.x - v3.x) + (v3.x - v2.x) * (v1.y - v3.y));
		}
	}
}
