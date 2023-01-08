using ChessAnimation.Drawing;
using ChessAnimation.Enums;
using ChessAnimation.Models;
using ChessAnimation.ObjHelpers;
using ChessAnimation.Utility;
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
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[0], 5f, 1f + 2 * projectData.angle, projectData.position);
			Object3DsMethods.calculateObject3D(projectData, projectData.objects[1], 3f, 1f, new Vector3(7, 0, 0));


			//Object3DsMethods.torus(projectData);

			// drawing scene

			using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
			{
				g.Clear(Color.AliceBlue);
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
				BasicDrawing.drawOutline(obj, projectData);
			}
			
			projectData.workingArea.Refresh();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			game();
			projectData.angle += 0.01f;

			// moving position up and down
			projectData.position = new Vector3(projectData.position.X, (float)Math.Sin(2 * projectData.angle) * 5, projectData.position.Z);
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

			
			// loading objects
			string obj1 = "FullTorusNormalized.obj";
			Loaders.loadObject(projectData, obj1);

			string obj2 = "Cube.obj";
			Loaders.loadObject(projectData, obj2);

			// timer
			timer = new Timer();
			timer.Interval = 25;
			timer.Tick += new EventHandler(timer1_Tick);
			timer.Start();
		}

		private void form_mainWindow_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F1)
			{
				this.projectData.cameraMode = CameraMode.Static;
				this.projectData.cameraPosition = new Vector3(0, 0, 12);
				this.projectData.cameraTarget = new Vector3(0, 0, 0);
				this.label2.Text = "Static";
			}
			else if (e.KeyCode == Keys.F2)
			{
				this.projectData.cameraMode = CameraMode.Tacking;
				this.projectData.trackedObject = 0;
				this.projectData.cameraPosition = new Vector3(0, 0, 12);
				this.projectData.cameraTarget = new Vector3(0, 0, 0);
				this.label2.Text = "Tacking";
			}
			else if (e.KeyCode == Keys.F3)
			{
				this.projectData.cameraMode = CameraMode.Moving;
				this.projectData.trackedObject = 0;
				this.projectData.cameraPosition = new Vector3(0, 0, 12);
				this.projectData.cameraTarget = new Vector3(0, 0, 0);
				this.label2.Text = "Moving";
			}
		}
	}
}