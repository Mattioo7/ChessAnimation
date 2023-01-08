using ChessAnimation.Models;
using ChessAnimation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnimation.Drawing
{
	internal static class BasicDrawing
	{


		public static void drawOutline(Object3D object3D, ProjectData projectData)
		{
			using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
			{
				for (int i = 0; i < object3D.polygons.Count; ++i)
				{
					for (int j = 0; j < object3D.polygons[i].verticesCopy.Count; ++j)
					{
						Vertex vertex1 = object3D.polygons[i].verticesCopy[j];
						Vertex vertex2 = object3D.polygons[i].verticesCopy[(object3D.polygons[i].verticesCopy.Count + j - 1) % object3D.polygons[i].verticesCopy.Count];
						g.DrawLine(new Pen(Color.Black, 1), vertex1, vertex2);
					}
				}
			}
		}
	}
}
