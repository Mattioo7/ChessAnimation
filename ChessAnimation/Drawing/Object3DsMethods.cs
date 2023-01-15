using ChessAnimation.Enums;
using ChessAnimation.Models;
using ChessAnimation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnimation.Drawing
{
	internal static class Object3DsMethods
	{
		public static void calculateObject3D(ProjectData projectData, Object3D obj, float scale, float angle, Vector3 position)
		{
			Matrix4x4 S = Matrix4x4.CreateScale(scale);
			Matrix4x4 R = Matrix4x4.CreateRotationY(angle);
			Matrix4x4 T = Matrix4x4.CreateTranslation(position);
			Matrix4x4 V = projectData.V;

			obj.position = Vector4.Transform(Vector3.Zero, S * R * T);
			
			Matrix4x4 P = projectData.P;

			/*Matrix4x4 matrix = S * R * V * P;*/
			Matrix4x4 matrix = S * R * T * V * P;

			for (int ii = 0; ii < obj.polygons.Count; ++ii)
			{
				List<Vertex> vertices = obj.polygons[ii].vertices;
				List<Vertex> verticesCopy = obj.polygons[ii].verticesCopy;

				for (int i = 0; i < vertices.Count; i++)
				{
					verticesCopy[i] = Vertex.Transform(vertices[i], matrix);
					verticesCopy[i] = verticesCopy[i] / verticesCopy[i].w;
				}
			}
		}






		

		public static void torus(ProjectData projectData)
		{
			float angle = projectData.angle;
			Matrix4x4 S = Matrix4x4.CreateScale(5);
			Matrix4x4 R = Matrix4x4.CreateRotationY(angle);
			Matrix4x4 T = Matrix4x4.CreateTranslation(0, 0, 0);

			Matrix4x4 V = Matrix4x4.CreateLookAt(new Vector3(0, 0, 10), new Vector3(0, 0, 0), Vector3.UnitY);

			float fieldOfView = 90 * MathF.PI / 180;
			float aspectRatio = (float)projectData.workingArea.Width / (float)projectData.workingArea.Height;
			float nearPlaneDistance = 1f;
			float farPlaneDistance = 2f;
			Matrix4x4 P = Matrix4x4.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance);

			/*Matrix4x4 matrix = S * R * V * P;*/
			Matrix4x4 matrix = S * R * T * V * P;

			for (int ii = 0; ii < projectData.objects[0].polygons.Count; ++ii)
			{
				List<Vertex> vertices = projectData.objects[0].polygons[ii].vertices;
				List<Vertex> verticesCopy = projectData.objects[0].polygons[ii].verticesCopy;

				for (int i = 0; i < vertices.Count; i++)
				{
					verticesCopy[i] = Vertex.Transform(vertices[i], matrix);
					verticesCopy[i] = verticesCopy[i] / verticesCopy[i].w;
				}
			}
		}









		
		// lab4

		/*public static void lab4(ProjectData projectData)
		{
			int a = projectData.a;
			float angle = projectData.angle;
			//table of vector4 for a cube of side a
			Vector4[] vertices = new Vector4[8];
			vertices[0] = new Vector4(-a, -a, -a, 1);
			vertices[1] = new Vector4(-a, -a, a, 1);
			vertices[2] = new Vector4(-a, a, -a, 1);
			vertices[3] = new Vector4(-a, a, a, 1);
			vertices[4] = new Vector4(a, -a, -a, 1);
			vertices[5] = new Vector4(a, -a, a, 1);
			vertices[6] = new Vector4(a, a, -a, 1);
			vertices[7] = new Vector4(a, a, a, 1);

			projectData.vertices = vertices;

			Matrix4x4 R = Matrix4x4.CreateRotationY(angle);
			Matrix4x4 T = Matrix4x4.CreateTranslation(0, 0, 0);

			Matrix4x4 V = Matrix4x4.CreateLookAt(new Vector3(0, 0, 10), new Vector3(0, 0, 0), Vector3.UnitY);

			float fieldOfView = 90 * MathF.PI / 180;
			float aspectRatio = (float)projectData.workingArea.Width / (float)projectData.workingArea.Height;
			float nearPlaneDistance = 1;
			float farPlaneDistance = 2;
			Matrix4x4 P = Matrix4x4.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance);

			Matrix4x4 matrix = R * T * V * P;
			//Matrix4x4 matrix = P * V * T * R;

			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] = Vector4.Transform(vertices[i], matrix);
				vertices[i] = vertices[i] / vertices[i].W;
			}
			
			//draw cube
			drawCube(projectData);
		}


		public static void drawCube(ProjectData projectData)
		{
			int width = projectData.workingArea.Width / 2;
			int height = projectData.workingArea.Height / 2;
			using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
			{
				g.Clear(Color.AliceBlue);
				// draw lines
				g.DrawLine(new Pen(Color.Black, 1), (1 + projectData.vertices[0].X) * width, (1 + projectData.vertices[0].Y) * height, (1 + projectData.vertices[1].X) * width, (1 + projectData.vertices[1].Y) * height);
				g.DrawLine(new Pen(Color.Black, 1), (1 + projectData.vertices[0].X) * width, (1 + projectData.vertices[0].Y) * height, (1 + projectData.vertices[2].X) * width, (1 + projectData.vertices[2].Y) * height);
				g.DrawLine(new Pen(Color.Black, 1), (1 + projectData.vertices[0].X) * width, (1 + projectData.vertices[0].Y) * height, (1 + projectData.vertices[4].X) * width, (1 + projectData.vertices[4].Y) * height);
				g.DrawLine(new Pen(Color.Black, 1), (1 + projectData.vertices[1].X) * width, (1 + projectData.vertices[1].Y) * height, (1 + projectData.vertices[3].X) * width, (1 + projectData.vertices[3].Y) * height);
				g.DrawLine(new Pen(Color.Black, 1), (1 + projectData.vertices[1].X) * width, (1 + projectData.vertices[1].Y) * height, (1 + projectData.vertices[5].X) * width, (1 + projectData.vertices[5].Y) * height);
				g.DrawLine(new Pen(Color.Black, 1), (1 + projectData.vertices[2].X) * width, (1 + projectData.vertices[2].Y) * height, (1 + projectData.vertices[3].X) * width, (1 + projectData.vertices[3].Y) * height);
				g.DrawLine(new Pen(Color.Black, 1), (1 + projectData.vertices[2].X) * width, (1 + projectData.vertices[2].Y) * height, (1 + projectData.vertices[6].X) * width, (1 + projectData.vertices[6].Y) * height);
				g.DrawLine(new Pen(Color.Black, 1), (1 + projectData.vertices[3].X) * width, (1 + projectData.vertices[3].Y) * height, (1 + projectData.vertices[7].X) * width, (1 + projectData.vertices[7].Y) * height);
				g.DrawLine(new Pen(Color.Black, 1), (1 + projectData.vertices[4].X) * width, (1 + projectData.vertices[4].Y) * height, (1 + projectData.vertices[5].X) * width, (1 + projectData.vertices[5].Y) * height);
			}
			projectData.workingArea.Refresh();
		}*/
	}
}
