using ObjLoader.Loader.Data.VertexData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnimation.Models
{
	internal class Vertex
	{
		// variables 
		public Vector4 vector4 { get; set; }
		public Vector3 normal { get; set; }
		public byte A { get; set; }
		public byte R { get; set; }
		public byte G { get; set; }
		public byte B { get; set; }

		// properties
		public float x
		{
			get
			{
				return vector4.X;
			}
			set
			{
				vector4 = new Vector4(value, vector4.Y, vector4.Z, vector4.W);
			}
		}
		public float y
		{
			get
			{
				return vector4.Y;
			}
			set
			{
				vector4 = new Vector4(vector4.X, value, vector4.Z, vector4.W);
			}
		}
		public float z
		{
			get
			{
				return vector4.Z;
			}
			set
			{
				vector4 = new Vector4(vector4.X, vector4.Y, value, vector4.W);
			}
		}
		public float w
		{
			get
			{
				return vector4.W;
			}
			set
			{
				vector4 = new Vector4(vector4.X, vector4.Y, vector4.Z, value);
			}
		}
		public Vector3 position { get { return new Vector3(x, y, z); } }

		public Color Color => this.color();

		public Vertex() { }

		public Vertex(Vertex vertex)
		{
			this.vector4 = vertex.vector4;
			this.normal = vertex.normal;
			this.A = vertex.A;
			this.R = vertex.R;
			this.G = vertex.G;
			this.B = vertex.B;
		}
		
		public Vertex(float x, float y, float z, Normal normal = default)
		{
			vector4 = new Vector4(x, y, z, 1);
			this.normal = new Vector3(normal.X, normal.Y, normal.Z);
		}

		public Vertex(ObjLoader.Loader.Data.VertexData.Vertex vertex, Normal normal = default)
		{
			vector4 = new Vector4(vertex.X, vertex.Y, vertex.Z, 1);
			this.normal = new Vector3(normal.X, normal.Y, normal.Z);
		}

		public static implicit operator Point(Vertex vertex) => new Point((int)vertex.x, (int)vertex.y);

		public static implicit operator Vector3(Vertex vertex) => new Vector3(vertex.x, vertex.y, vertex.z);

		public Color color() => Color.FromArgb(A, R, G, B);

		public static Vertex Transform(Vertex vertex, Matrix4x4 matrix)
		{
			Vertex result = new Vertex(vertex);
			result.vector4 = Vector4.Transform(vertex.vector4, matrix);
			result.normal = Vector3.TransformNormal(vertex.normal, matrix);
			return result;
		}

		public static Vertex operator /(Vertex vertex, float rhs)
		{
			Vertex result = new Vertex(vertex);
			result.vector4 /= rhs;

			return result;
		}
	}
}
