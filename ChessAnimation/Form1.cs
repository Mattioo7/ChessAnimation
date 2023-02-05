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

			// queen
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[1], 1f, 0.1f + 2 * projectData.angle, new Vector3(10, 0, 0));

			// pawn
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[2], 1f, 0.3f + 7 * projectData.angle, new Vector3(10, 0, -10));

			// rook
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[3], 1f, 0.5f /*1f + 5 * projectData.angle*/, new Vector3(10, 0, -20));

			// bishop
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[4], 1f, 0.7f + 2 * projectData.angle, new Vector3(10, 0, -30));

			// knight
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[5], 1f, 1.5f /*+ 5 * projectData.angle*/, new Vector3(10, 0, 10));


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

			if (projectData.drawOutline)
			{
				Filler.fillObjects(projectData);
			}
			
			if (projectData.fillColor)
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
			this.label_position.Text = "Position: " + projectData.position.ToString();

			fpsCounter.Stop();
			this.label_fps.Text = "FPS: " + (int)(1 / fpsCounter.Elapsed.TotalSeconds);
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
			
			obj = "queen.obj";
			Loaders.loadObject(projectData, obj);

			obj = "pawn.obj";
			Loaders.loadObject(projectData, obj);

			obj = "rook.obj";
			Loaders.loadObject(projectData, obj);

			obj = "bishop.obj";
			Loaders.loadObject(projectData, obj);

			obj = "knight.obj";
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
					this.label2.Text = "Static";
					game();
					break;
				case Keys.F2:
					this.projectData.cameraMode = CameraMode.Tacking;
					this.projectData.trackedObject = 0;
					this.projectData.cameraPosition = new Vector3(0, -10, 20);
					this.projectData.cameraTarget = new Vector3(0, 0, 0);
					this.label2.Text = "Tacking";
					game();
					break;
				case Keys.F3:
					this.projectData.cameraMode = CameraMode.Moving;
					this.projectData.trackedObject = 0;
					this.projectData.cameraPosition = new Vector3(0, -10, 20);
					this.projectData.cameraTarget = new Vector3(0, 0, 0);
					this.label2.Text = "Moving";
					game();
					break;
				case Keys.Space:
					if (timer.Enabled)
					{
						timer.Stop();
					}
					else
					{
						timer.Start();
					}
					break;
				case Keys.Q:
					this.projectData.colorMode = ColorMode.Static;
					game();
					break;
				case Keys.W:
					this.projectData.colorMode = ColorMode.Gouraud;
					game();
					break;
				case Keys.E:
					this.projectData.colorMode = ColorMode.Phong;
					game();
					break;
				case Keys.Z:
					this.projectData.fillColor = !this.projectData.fillColor;
					game();
					break;
				case Keys.X:
					this.projectData.drawOutline = !this.projectData.drawOutline;
					game();
					break;
				case Keys.C:
					this.projectData.fog = !this.projectData.fog;
					//Debug.WriteLine("Fog: " + projectData.fog);
					game();
					break;
				/*case Keys.D:
					this.projectData.debug = !this.projectData.debug;
					break;*/
			}

		}

		private void trackBar_kd_Scroll(object sender, EventArgs e)
		{
			projectData.kd = (this.trackBar_kd.Value / 100f);

			if (this.trackBar_kd.Value < 1)
			{
				this.label_kdValue.Text = "0,00";
			}
			else if (this.trackBar_kd.Value > 99)
			{
				this.label_kdValue.Text = "1,00";
			}
			else
			{
				this.label_kdValue.Text = projectData.kd.ToString();
			}
			Filler.fillObjects(projectData);
			this.pictureBox_workingArea.Refresh();
			this.Focus();
		}

		private void trackBar_ks_Scroll(object sender, EventArgs e)
		{
			projectData.ks = (this.trackBar_ks.Value / 100f);

			if (this.trackBar_ks.Value < 1)
			{
				this.label_ksValue.Text = "0,00";
			}
			else if (this.trackBar_ks.Value > 99)
			{
				this.label_ksValue.Text = "1,00";
			}
			else
			{
				this.label_ksValue.Text = projectData.ks.ToString();
			}
			Filler.fillObjects(projectData);
			this.pictureBox_workingArea.Refresh();
			this.Focus();
		}

		private void trackBar_m_Scroll(object sender, EventArgs e)
		{
			projectData.m = this.trackBar_m.Value;

			this.label_mValue.Text = projectData.m.ToString();

			Filler.fillObjects(projectData);
			this.pictureBox_workingArea.Refresh();
			this.Focus();
		}

		private void trackBar_x_Scroll(object sender, EventArgs e)
		{
			float newX = this.trackBar_x.Value - 50;
			this.label_x.Text = newX.ToString();
			projectData.cameraPosition = new Vector3(newX, projectData.cameraPosition.Y, projectData.cameraPosition.Z);
			
			Filler.fillObjects(projectData);
			this.pictureBox_workingArea.Refresh();
		}

		private void trackBar_y_Scroll(object sender, EventArgs e)
		{
			float newY = this.trackBar_y.Value - 50;
			this.label_y.Text = newY.ToString();
			projectData.cameraPosition = new Vector3(projectData.cameraPosition.X, newY, projectData.cameraPosition.Z);
			
			Filler.fillObjects(projectData);
			this.pictureBox_workingArea.Refresh();
		}

		private void trackBar_z_Scroll(object sender, EventArgs e)
		{
			float newZ = this.trackBar_z.Value - 50;
			this.label_z.Text = newZ.ToString();
			projectData.cameraPosition = new Vector3(projectData.cameraPosition.X, projectData.cameraPosition.Y, newZ);
			
			Filler.fillObjects(projectData);
			this.pictureBox_workingArea.Refresh();
		}
	}
}