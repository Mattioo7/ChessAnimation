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
		public static void drawOutlines(ProjectData projectData)
		{
			foreach (Object3D object3D in projectData.objects)
			{
				drawOutline(projectData, object3D);
			}
		}
		
		public static void drawOutline(ProjectData projectData, Object3D object3D)
		{
			for (int i = 0; i < object3D.polygons.Count; ++i)
			{
				for (int j = 0; j < object3D.polygons[i].verticesCopy.Count; ++j)
				{
					Vertex vertex1 = object3D.polygons[i].verticesCopy[j];
					Vertex vertex2 = object3D.polygons[i].verticesCopy[(object3D.polygons[i].verticesCopy.Count + j - 1) % object3D.polygons[i].verticesCopy.Count];
					drawLineBresenham(projectData, vertex1, vertex2);
				}
			}
		}

		private static void drawLineBresenham(ProjectData projectData, Vertex vertex1, Vertex vertex2, Color? color = null)
		{
			drawLineBresenham(projectData, (int)vertex1.x, (int)vertex1.y, (int)vertex2.x, (int)vertex2.y, color);
		}


		private static void drawLineBresenham(ProjectData projectData, int x, int y, int x2, int y2, Color? color = null)
		{
			if (color == null)
			{
				color = Color.Black;
			}

			//http://tech-algorithm.com/articles/drawing-line-using-bresenham-algorithm/
			int w = x2 - x;
			int h = y2 - y;
			int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
			if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
			if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
			if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;

			int longest = Math.Abs(w);
			int shortest = Math.Abs(h);
			if (!(longest > shortest))
			{
				longest = Math.Abs(h);
				shortest = Math.Abs(w);
				if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
				dx2 = 0;
			}
			int numerator = longest >> 1;
			for (int i = 0; i <= longest; i++)
			{
				projectData.snoop.SetPixel(x, y, (Color)color);
				numerator += shortest;
				if (!(numerator < longest))
				{
					numerator -= longest;
					x += dx1;
					y += dy1;
				}
				else
				{
					x += dx2;
					y += dy2;
				}
			}
		}
	}
}
