namespace ChessAnimation
{
	partial class form_mainWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_mainWindow));
			this.tableLayoutPanel_main = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel_right = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label_z = new System.Windows.Forms.Label();
			this.trackBar_z = new System.Windows.Forms.TrackBar();
			this.label_animation = new System.Windows.Forms.Label();
			this.label_fog = new System.Windows.Forms.Label();
			this.label_coloring = new System.Windows.Forms.Label();
			this.label_outline = new System.Windows.Forms.Label();
			this.label_shading = new System.Windows.Forms.Label();
			this.label_camera = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox_workingArea = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel_main.SuspendLayout();
			this.tableLayoutPanel_right.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_z)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_workingArea)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel_main
			// 
			this.tableLayoutPanel_main.ColumnCount = 2;
			this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
			this.tableLayoutPanel_main.Controls.Add(this.tableLayoutPanel_right, 1, 0);
			this.tableLayoutPanel_main.Controls.Add(this.pictureBox_workingArea, 0, 0);
			this.tableLayoutPanel_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_main.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel_main.Name = "tableLayoutPanel_main";
			this.tableLayoutPanel_main.RowCount = 1;
			this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_main.Size = new System.Drawing.Size(1184, 744);
			this.tableLayoutPanel_main.TabIndex = 0;
			// 
			// tableLayoutPanel_right
			// 
			this.tableLayoutPanel_right.ColumnCount = 1;
			this.tableLayoutPanel_right.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_right.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel_right.Controls.Add(this.groupBox2, 0, 1);
			this.tableLayoutPanel_right.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_right.Location = new System.Drawing.Point(937, 3);
			this.tableLayoutPanel_right.Name = "tableLayoutPanel_right";
			this.tableLayoutPanel_right.RowCount = 2;
			this.tableLayoutPanel_right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_right.Size = new System.Drawing.Size(244, 738);
			this.tableLayoutPanel_right.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label_z);
			this.groupBox1.Controls.Add(this.trackBar_z);
			this.groupBox1.Controls.Add(this.label_animation);
			this.groupBox1.Controls.Add(this.label_fog);
			this.groupBox1.Controls.Add(this.label_coloring);
			this.groupBox1.Controls.Add(this.label_outline);
			this.groupBox1.Controls.Add(this.label_shading);
			this.groupBox1.Controls.Add(this.label_camera);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(238, 363);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Info";
			// 
			// label_z
			// 
			this.label_z.AutoSize = true;
			this.label_z.Location = new System.Drawing.Point(6, 285);
			this.label_z.Name = "label_z";
			this.label_z.Size = new System.Drawing.Size(19, 15);
			this.label_z.TabIndex = 5;
			this.label_z.Text = "20";
			// 
			// trackBar_z
			// 
			this.trackBar_z.LargeChange = 10;
			this.trackBar_z.Location = new System.Drawing.Point(31, 285);
			this.trackBar_z.Maximum = 50;
			this.trackBar_z.Minimum = 10;
			this.trackBar_z.Name = "trackBar_z";
			this.trackBar_z.Size = new System.Drawing.Size(176, 45);
			this.trackBar_z.TabIndex = 8;
			this.trackBar_z.Tag = "";
			this.trackBar_z.TickFrequency = 5;
			this.trackBar_z.Value = 20;
			this.trackBar_z.Scroll += new System.EventHandler(this.trackBar_z_Scroll);
			// 
			// label_animation
			// 
			this.label_animation.AutoSize = true;
			this.label_animation.Location = new System.Drawing.Point(6, 209);
			this.label_animation.Name = "label_animation";
			this.label_animation.Size = new System.Drawing.Size(83, 15);
			this.label_animation.TabIndex = 7;
			this.label_animation.Text = "Animation: on";
			// 
			// label_fog
			// 
			this.label_fog.AutoSize = true;
			this.label_fog.Location = new System.Drawing.Point(6, 173);
			this.label_fog.Name = "label_fog";
			this.label_fog.Size = new System.Drawing.Size(55, 15);
			this.label_fog.TabIndex = 6;
			this.label_fog.Text = "Fog: True";
			// 
			// label_coloring
			// 
			this.label_coloring.AutoSize = true;
			this.label_coloring.Location = new System.Drawing.Point(6, 136);
			this.label_coloring.Name = "label_coloring";
			this.label_coloring.Size = new System.Drawing.Size(81, 15);
			this.label_coloring.TabIndex = 5;
			this.label_coloring.Text = "Coloring: True";
			// 
			// label_outline
			// 
			this.label_outline.AutoSize = true;
			this.label_outline.Location = new System.Drawing.Point(6, 100);
			this.label_outline.Name = "label_outline";
			this.label_outline.Size = new System.Drawing.Size(78, 15);
			this.label_outline.TabIndex = 4;
			this.label_outline.Text = "Outline: False";
			// 
			// label_shading
			// 
			this.label_shading.AutoSize = true;
			this.label_shading.Location = new System.Drawing.Point(6, 64);
			this.label_shading.Name = "label_shading";
			this.label_shading.Size = new System.Drawing.Size(136, 15);
			this.label_shading.TabIndex = 3;
			this.label_shading.Text = "Shading mode: constant";
			// 
			// label_camera
			// 
			this.label_camera.AutoSize = true;
			this.label_camera.Location = new System.Drawing.Point(6, 28);
			this.label_camera.Name = "label_camera";
			this.label_camera.Size = new System.Drawing.Size(82, 15);
			this.label_camera.TabIndex = 0;
			this.label_camera.Text = "Camera: static";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 372);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(238, 363);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Keybinds";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(236, 195);
			this.label1.TabIndex = 0;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// pictureBox_workingArea
			// 
			this.pictureBox_workingArea.BackColor = System.Drawing.Color.White;
			this.pictureBox_workingArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox_workingArea.Location = new System.Drawing.Point(3, 3);
			this.pictureBox_workingArea.Name = "pictureBox_workingArea";
			this.pictureBox_workingArea.Size = new System.Drawing.Size(928, 738);
			this.pictureBox_workingArea.TabIndex = 1;
			this.pictureBox_workingArea.TabStop = false;
			// 
			// form_mainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 744);
			this.Controls.Add(this.tableLayoutPanel_main);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1200, 783);
			this.MinimumSize = new System.Drawing.Size(1200, 783);
			this.Name = "form_mainWindow";
			this.Text = "Chess animation";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_mainWindow_KeyDown);
			this.tableLayoutPanel_main.ResumeLayout(false);
			this.tableLayoutPanel_right.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_z)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_workingArea)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private TableLayoutPanel tableLayoutPanel_main;
		private TableLayoutPanel tableLayoutPanel_right;
		private PictureBox pictureBox_workingArea;
		private GroupBox groupBox1;
		private Label label_camera;
		private GroupBox groupBox2;
		private TrackBar trackBar_z;
		private Label label_z;
		private Label label_fog;
		private Label label_coloring;
		private Label label_outline;
		private Label label_shading;
		private Label label_animation;
		private Label label1;
	}
}