using ChessAnimation.Enums;
using ChessAnimation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnimation.Utility
{
	internal class ProjectData
	{
		// public int a { get; set; } = 1;
		// public Vector4[] vertices { get; set; }
		
		// variables
		public float angle { get; set; } = 0.1f;
		public List<Object3D> objects { get; set; }

		// bitmap
		public PictureBox workingArea { get; set; }
		public BmpPixelSnoop snoop { get; set; }
		public float[,] zBuffer { get; set; }

		// camera
		public CameraMode cameraMode { get; set; } = CameraMode.Static;
		public int trackedObject { get; set; }
		public Vector3 cameraPosition { get; set; } = new Vector3(0, 0, 12);
		public Vector3 cameraTarget { get; set; } = new Vector3(0, 0, 0);
		public Vector3 cameraUpVector { get; set; } = Vector3.UnitY;

		// position
		public Vector3 position { get; set; } = new Vector3(-4, 0, 0);
	}
}
