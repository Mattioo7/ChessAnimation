﻿using ChessAnimation.Enums;
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
		public float kd { get; set; } = 1f;
		public float ks { get; set; } = 0.5f;
		public int m { get; set; } = 20;
		public Color objColor { get; set; } = Color.LightGreen;

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

		// sun
		public Vector3 sunPosition { get; set; } = new Vector3(0, 0, -900);
		public List<Vector3> sunPositions { get; set; } 
		public Color sunColor { get; set; } = Color.White;

		// fog
		public bool fog { get; set; } = false;
		public float fogStart { get; set; } = 1.9f;
		public float fogEnd { get; set; } = 1.95f;

		// booleans
		public bool interpolateColor { get; set; } = true;
		public bool drawOutline { get; set; } = true;
		public bool fillColor { get; set; } = false;
	}
}
