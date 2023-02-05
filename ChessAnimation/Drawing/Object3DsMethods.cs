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

			Matrix4x4 modelMatrix = S * R * T;
			obj.position = Vector4.Transform(Vector3.Zero, modelMatrix);
			
			Matrix4x4 V = projectData.V;
			Matrix4x4 P = projectData.P;

			Matrix4x4 totalMatrix = modelMatrix * V * P;

			for (int ii = 0; ii < obj.polygons.Count; ++ii)
			{
				List<Vertex> vertices = obj.polygons[ii].vertices;
				List<Vertex> verticesCopy = obj.polygons[ii].verticesCopy;
				List<Vertex> verticesInWorld = obj.polygons[ii].verticesInWorld;

				for (int i = 0; i < vertices.Count; i++)
				{
					verticesCopy[i] = Vertex.Transform(vertices[i], totalMatrix);
					verticesCopy[i] = verticesCopy[i] / verticesCopy[i].w;

					verticesInWorld[i] = Vertex.Transform(vertices[i], modelMatrix);
					verticesInWorld[i] = verticesInWorld[i] / verticesInWorld[i].w;
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
	}
}
