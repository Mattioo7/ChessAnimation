using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnimation.Models
{
	internal class Object3D
	{
		public string name { get; set; }
		public List<Polygon> polygons { get; set; }
		public Vector4 position { get; set; } = new Vector4(0, 0, 0, 1);

		public Object3D() { }

		public Object3D(List<Polygon> polygons)
		{
			this.polygons = polygons;
		}

		public Object3D(List<Polygon> polygons, string name)
		{
			this.polygons = polygons;
			this.name = name;
		}


	}
}
