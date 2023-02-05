using ChessAnimation.Drawing;
using ChessAnimation.Enums;
using ChessAnimation.Models;
using ChessAnimation.ObjHelpers;
using ChessAnimation.Utility;
using System.Diagnostics;
using System.Numerics;
using Timer = System.Windows.Forms.Timer;

namespace ChessAnimation
{
	public partial class form_mainWindow : Form
	{
		ProjectData projectData;
		Timer timer;

		public form_mainWindow()
		{
			InitializeComponent();

			initalizeEnviroment();

			//lab4(projectData);

			game();
		}

		private void game()
		{
			if (projectData.cameraMode == CameraMode.Tacking)
			{
				Vector3 target = new Vector3(projectData.objects[0].position.X, projectData.objects[0].position.Y, projectData.objects[0].position.Z);
				projectData.V = Matrix4x4.CreateLookAt(projectData.cameraPosition, target, projectData.cameraUpVector);
			}
			else if (projectData.cameraMode == CameraMode.Moving)
			{
				Vector3 newPosition = new Vector3(projectData.objects[0].position.X, projectData.objects[0].position.Y, projectData.objects[0].position.Z);
				Vector3 newCameraPosition = projectData.cameraPosition + newPosition;
				Vector3 newCameraTarget = projectData.cameraTarget + newPosition;
				projectData.V = Matrix4x4.CreateLookAt(newCameraPosition, newCameraTarget, projectData.cameraUpVector);
			}
			else
			{
				projectData.V = Matrix4x4.CreateLookAt(projectData.cameraPosition, projectData.cameraTarget, projectData.cameraUpVector);
			}

			float fieldOfView = 90 * MathF.PI / 180;
			float aspectRatio = (float)projectData.workingArea.Width / (float)projectData.workingArea.Height;
			float nearPlaneDistance = 1f;
			float farPlaneDistance = 2f;
			projectData.P = Matrix4x4.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance);

			// objects
			
			// torus
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[0], 10f, -1.5f + 2 * projectData.angle, projectData.position);

			// pawns
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[1], 1f, 0.1f + 2 * projectData.angle, new Vector3(10, 0 - (float)Math.Sin(5 * projectData.angle) * 3, 10));
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[2], 1f, 0.1f + 2 * projectData.angle, new Vector3(10, 0, 5));
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[3], 1f, 0.3f + 7 * projectData.angle, new Vector3(10, 0, 0));
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[4], 1f, 0.5f /*1f + 5 * projectData.angle*/, new Vector3(10, 0, -5));
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[5], 1f, 0.7f + 2 * projectData.angle, new Vector3(10, 0, -10));
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[6], 1f, 1.5f /*+ 5 * projectData.angle*/, new Vector3(10, 0, -15));
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[7], 1f, 1.5f /*+ 5 * projectData.angle*/, new Vector3(10, 0, -20));
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[8], 1f, 1.5f /*+ 5 * projectData.angle*/, new Vector3(10, 0, -25));
			
			// rooks
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[9], 1f, 1.5f /*+ 5 * projectData.angle*/, new Vector3(15, 0, 10));
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[10], 1f, 1.5f /*+ 5 * projectData.angle*/, new Vector3(15, 0, -25));

			// knights
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[11], 1f, 1.5f /*+ 5 * projectData.angle*/, new Vector3(15, 0, 5));
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[12], 1f, 1.5f /*+ 5 * projectData.angle*/, new Vector3(15, 0, -20));

			// bishops
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[13], 1f, 1.5f /*+ 5 * projectData.angle*/, new Vector3(15, 0, 0));
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[14], 1f, 1.5f /*+ 5 * projectData.angle*/, new Vector3(15, 0, -15));

			// queens
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[15], 1f, 1.5f + 5 * projectData.angle, new Vector3(15, 0, -5));
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[16], 1f, 1.5f /*+ 5 * projectData.angle*/, new Vector3(15, 0 + (float)Math.Sin(5 * projectData.angle) * 3, -10));


			// drawing scene
			using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
			{
				g.Clear(Color.White);
			}
			for (int i = 0; i < projectData.zBuffer.GetLength(0); i++)
			{
				for (int j = 0; j < projectData.zBuffer.GetLength(1); j++)
				{
					projectData.zBuffer[i, j] = float.MaxValue;
				}
			}
			foreach (Object3D obj in projectData.objects)
			{
				foreach (Polygon polygon in obj.polygons)
				{
					foreach (Vertex vertexCopy in polygon.verticesCopy)
					{
						vertexCopy.x = (vertexCopy.x + 1) * projectData.workingArea.Width / 2;
						vertexCopy.y = (vertexCopy.y + 1) * projectData.workingArea.Height / 2;
					}
				}
			}

			if (projectData.fillColor)
			{
				Filler.fillObjects(projectData);
			}
			
			if (projectData.drawOutline)
			{
				BasicDrawing.drawOutlines(projectData);
			}

			projectData.workingArea.Refresh();
			int aa = 0;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Stopwatch fpsCounter = new Stopwatch();
			fpsCounter.Start();
			game();
			projectData.angle += 0.01f;

			// moving position up and down
			projectData.position = new Vector3(projectData.position.X, (float)Math.Sin(2 * projectData.angle) * 5, projectData.position.Z);
			//projectData.position = new Vector3(projectData.position.X, projectData.position.Y, (float)Math.Sin(5 * projectData.angle) * 12 - 20);

			fpsCounter.Stop();
			//this.label_fps.Text = "FPS: " + (int)(1 / fpsCounter.Elapsed.TotalSeconds);
		}

		public void initalizeEnviroment()
		{
			// project data
			projectData = new ProjectData();
			projectData.objects = new List<Object3D>();

			// bitmap
			Bitmap bitmap = new Bitmap(this.pictureBox_workingArea.Size.Width, this.pictureBox_workingArea.Size.Height);
			this.pictureBox_workingArea.Image = bitmap;
			projectData.workingArea = this.pictureBox_workingArea;
			using (var snoop = new BmpPixelSnoop((Bitmap)projectData.workingArea.Image))
			{
				projectData.snoop = snoop;
			}

			projectData.zBuffer = new float[projectData.workingArea.Width, projectData.workingArea.Height];
			for (int i = 0; i < projectData.zBuffer.GetLength(0); i++)
			{
				for (int j = 0; j < projectData.zBuffer.GetLength(1); j++)
				{
					projectData.zBuffer[i, j] = float.MaxValue;
				}
			}


			// loading objects
			string obj = "FullTorusNormalized.obj";
			Loaders.loadObject(projectData, obj);
			
			obj = "pawn.obj";
			Loaders.loadObject(projectData, obj);
			Loaders.loadObject(projectData, obj);
			Loaders.loadObject(projectData, obj);
			Loaders.loadObject(projectData, obj);
			Loaders.loadObject(projectData, obj);
			Loaders.loadObject(projectData, obj);
			Loaders.loadObject(projectData, obj);
			Loaders.loadObject(projectData, obj);

			obj = "rook.obj";
			Loaders.loadObject(projectData, obj);
			Loaders.loadObject(projectData, obj);

			obj = "knight.obj";
			Loaders.loadObject(projectData, obj);
			Loaders.loadObject(projectData, obj);

			obj = "bishop.obj";
			Loaders.loadObject(projectData, obj);
			Loaders.loadObject(projectData, obj);

			obj = "queen.obj";
			Loaders.loadObject(projectData, obj);
			Loaders.loadObject(projectData, obj);

			// sun
			projectData.sunPositions = new List<Vector3>
			{
				new Vector3(0, 0, -900),
				new Vector3(100, 0, -600)
			};

			// timer
			timer = new Timer();
			timer.Interval = 25;
			timer.Tick += new EventHandler(timer1_Tick);
			timer.Start();
		}

		private void form_mainWindow_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F1:
					this.projectData.cameraMode = CameraMode.Static;
					this.projectData.cameraPosition = new Vector3(0, -10, 20);
					this.projectData.cameraTarget = new Vector3(0, 0, 0);
					this.label_camera.Text = "Camera: static";
					game();
					break;
				case Keys.F2:
					this.projectData.cameraMode = CameraMode.Tacking;
					this.projectData.trackedObject = 0;
					this.projectData.cameraPosition = new Vector3(0, -10, 20);
					this.projectData.cameraTarget = new Vector3(0, 0, 0);
					this.label_camera.Text = "Camera: tacking";
					game();
					break;
				case Keys.F3:
					this.projectData.cameraMode = CameraMode.Moving;
					this.projectData.trackedObject = 0;
					this.projectData.cameraPosition = new Vector3(0, -10, 20);
					this.projectData.cameraTarget = new Vector3(0, 0, 0);
					this.label_camera.Text = "Camera: moving";
					game();
					break;
				case Keys.Space:
					if (timer.Enabled)
					{
						timer.Stop();
						this.label_animation.Text = "Animation: off";
					}
					else
					{
						timer.Start();
						this.label_animation.Text = "Animation: on";
					}
					break;
				case Keys.Q:
					this.projectData.colorMode = ColorMode.Constant;
					this.label_shading.Text = "Shading mode: constant";
					game();
					break;
				case Keys.W:
					this.projectData.colorMode = ColorMode.Gouraud;
					this.label_shading.Text = "Shading mode: gouraud";
					game();
					break;
				case Keys.E:
					this.projectData.colorMode = ColorMode.Phong;
					this.label_shading.Text = "Shading mode: phong";
					game();
					break;
				case Keys.Z:
					this.projectData.fillColor = !this.projectData.fillColor;
					this.label_coloring.Text = "Coloring: " + this.projectData.fillColor;
					game();
					break;
				case Keys.X:
					this.projectData.drawOutline = !this.projectData.drawOutline;
					this.label_outline.Text = "Outline: " + this.projectData.drawOutline;
					game();
					break;
				case Keys.C:
					this.projectData.fog = !this.projectData.fog;
					this.label_fog.Text = "Fog: " + this.projectData.fog;
					game();
					break;
				/*case Keys.D:
					this.projectData.debug = !this.projectData.debug;
					break;*/
			}

		}

		private void trackBar_z_Scroll(object sender, EventArgs e)
		{
			float newZ = this.trackBar_z.Value;
			this.label_z.Text = newZ.ToString();
			projectData.cameraPosition = new Vector3(projectData.cameraPosition.X, projectData.cameraPosition.Y, newZ);
			
			Filler.fillObjects(projectData);
			this.pictureBox_workingArea.Refresh();
		}
	}
}