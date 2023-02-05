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
			this.tableLayoutPanel_main = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel_right = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.trackBar_m = new System.Windows.Forms.TrackBar();
			this.label_mValue = new System.Windows.Forms.Label();
			this.label_m = new System.Windows.Forms.Label();
			this.trackBar_ks = new System.Windows.Forms.TrackBar();
			this.label_ksValue = new System.Windows.Forms.Label();
			this.label_ks = new System.Windows.Forms.Label();
			this.label_kdValue = new System.Windows.Forms.Label();
			this.label_kd = new System.Windows.Forms.Label();
			this.trackBar_kd = new System.Windows.Forms.TrackBar();
			this.label_position = new System.Windows.Forms.Label();
			this.label_fps = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.trackBar_z = new System.Windows.Forms.TrackBar();
			this.trackBar_y = new System.Windows.Forms.TrackBar();
			this.trackBar_x = new System.Windows.Forms.TrackBar();
			this.label_z = new System.Windows.Forms.Label();
			this.label_y = new System.Windows.Forms.Label();
			this.label_x = new System.Windows.Forms.Label();
			this.pictureBox_workingArea = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel_main.SuspendLayout();
			this.tableLayoutPanel_right.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_m)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_ks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_kd)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_z)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_y)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_x)).BeginInit();
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
			this.groupBox1.Controls.Add(this.trackBar_m);
			this.groupBox1.Controls.Add(this.label_mValue);
			this.groupBox1.Controls.Add(this.label_m);
			this.groupBox1.Controls.Add(this.trackBar_ks);
			this.groupBox1.Controls.Add(this.label_ksValue);
			this.groupBox1.Controls.Add(this.label_ks);
			this.groupBox1.Controls.Add(this.label_kdValue);
			this.groupBox1.Controls.Add(this.label_kd);
			this.groupBox1.Controls.Add(this.trackBar_kd);
			this.groupBox1.Controls.Add(this.label_position);
			this.groupBox1.Controls.Add(this.label_fps);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(238, 363);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// trackBar_m
			// 
			this.trackBar_m.LargeChange = 10;
			this.trackBar_m.Location = new System.Drawing.Point(40, 233);
			this.trackBar_m.Maximum = 100;
			this.trackBar_m.Minimum = 1;
			this.trackBar_m.Name = "trackBar_m";
			this.trackBar_m.Size = new System.Drawing.Size(176, 45);
			this.trackBar_m.TabIndex = 12;
			this.trackBar_m.Tag = "";
			this.trackBar_m.TickFrequency = 20;
			this.trackBar_m.Value = 20;
			this.trackBar_m.Scroll += new System.EventHandler(this.trackBar_m_Scroll);
			// 
			// label_mValue
			// 
			this.label_mValue.AutoSize = true;
			this.label_mValue.Location = new System.Drawing.Point(6, 248);
			this.label_mValue.Name = "label_mValue";
			this.label_mValue.Size = new System.Drawing.Size(19, 15);
			this.label_mValue.TabIndex = 11;
			this.label_mValue.Text = "20";
			// 
			// label_m
			// 
			this.label_m.AutoSize = true;
			this.label_m.Location = new System.Drawing.Point(6, 233);
			this.label_m.Name = "label_m";
			this.label_m.Size = new System.Drawing.Size(18, 15);
			this.label_m.TabIndex = 10;
			this.label_m.Text = "m";
			// 
			// trackBar_ks
			// 
			this.trackBar_ks.LargeChange = 10;
			this.trackBar_ks.Location = new System.Drawing.Point(40, 192);
			this.trackBar_ks.Maximum = 100;
			this.trackBar_ks.Name = "trackBar_ks";
			this.trackBar_ks.Size = new System.Drawing.Size(176, 45);
			this.trackBar_ks.TabIndex = 9;
			this.trackBar_ks.Tag = "";
			this.trackBar_ks.TickFrequency = 20;
			this.trackBar_ks.Value = 50;
			this.trackBar_ks.Scroll += new System.EventHandler(this.trackBar_ks_Scroll);
			// 
			// label_ksValue
			// 
			this.label_ksValue.AutoSize = true;
			this.label_ksValue.Location = new System.Drawing.Point(6, 207);
			this.label_ksValue.Name = "label_ksValue";
			this.label_ksValue.Size = new System.Drawing.Size(28, 15);
			this.label_ksValue.TabIndex = 8;
			this.label_ksValue.Text = "0,50";
			// 
			// label_ks
			// 
			this.label_ks.AutoSize = true;
			this.label_ks.Location = new System.Drawing.Point(6, 192);
			this.label_ks.Name = "label_ks";
			this.label_ks.Size = new System.Drawing.Size(18, 15);
			this.label_ks.TabIndex = 7;
			this.label_ks.Text = "ks";
			// 
			// label_kdValue
			// 
			this.label_kdValue.AutoSize = true;
			this.label_kdValue.Location = new System.Drawing.Point(6, 159);
			this.label_kdValue.Name = "label_kdValue";
			this.label_kdValue.Size = new System.Drawing.Size(28, 15);
			this.label_kdValue.TabIndex = 6;
			this.label_kdValue.Text = "1,00";
			// 
			// label_kd
			// 
			this.label_kd.AutoSize = true;
			this.label_kd.Location = new System.Drawing.Point(6, 141);
			this.label_kd.Name = "label_kd";
			this.label_kd.Size = new System.Drawing.Size(20, 15);
			this.label_kd.TabIndex = 5;
			this.label_kd.Text = "kd";
			// 
			// trackBar_kd
			// 
			this.trackBar_kd.LargeChange = 10;
			this.trackBar_kd.Location = new System.Drawing.Point(40, 141);
			this.trackBar_kd.Maximum = 100;
			this.trackBar_kd.Name = "trackBar_kd";
			this.trackBar_kd.Size = new System.Drawing.Size(176, 45);
			this.trackBar_kd.TabIndex = 4;
			this.trackBar_kd.Tag = "";
			this.trackBar_kd.TickFrequency = 20;
			this.trackBar_kd.Value = 100;
			this.trackBar_kd.Scroll += new System.EventHandler(this.trackBar_kd_Scroll);
			// 
			// label_position
			// 
			this.label_position.AutoSize = true;
			this.label_position.Location = new System.Drawing.Point(6, 81);
			this.label_position.Name = "label_position";
			this.label_position.Size = new System.Drawing.Size(56, 15);
			this.label_position.TabIndex = 3;
			this.label_position.Text = "Position: ";
			// 
			// label_fps
			// 
			this.label_fps.AutoSize = true;
			this.label_fps.Location = new System.Drawing.Point(6, 55);
			this.label_fps.Name = "label_fps";
			this.label_fps.Size = new System.Drawing.Size(32, 15);
			this.label_fps.TabIndex = 2;
			this.label_fps.Text = "FPS: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(63, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Static";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Camera:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.trackBar_z);
			this.groupBox2.Controls.Add(this.trackBar_y);
			this.groupBox2.Controls.Add(this.trackBar_x);
			this.groupBox2.Controls.Add(this.label_z);
			this.groupBox2.Controls.Add(this.label_y);
			this.groupBox2.Controls.Add(this.label_x);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 372);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(238, 363);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
			// 
			// trackBar_z
			// 
			this.trackBar_z.LargeChange = 10;
			this.trackBar_z.Location = new System.Drawing.Point(40, 141);
			this.trackBar_z.Maximum = 100;
			this.trackBar_z.Name = "trackBar_z";
			this.trackBar_z.Size = new System.Drawing.Size(176, 45);
			this.trackBar_z.TabIndex = 8;
			this.trackBar_z.Tag = "";
			this.trackBar_z.TickFrequency = 20;
			this.trackBar_z.Value = 70;
			this.trackBar_z.Scroll += new System.EventHandler(this.trackBar_z_Scroll);
			// 
			// trackBar_y
			// 
			this.trackBar_y.LargeChange = 10;
			this.trackBar_y.Location = new System.Drawing.Point(40, 93);
			this.trackBar_y.Maximum = 100;
			this.trackBar_y.Name = "trackBar_y";
			this.trackBar_y.Size = new System.Drawing.Size(176, 45);
			this.trackBar_y.TabIndex = 7;
			this.trackBar_y.Tag = "";
			this.trackBar_y.TickFrequency = 20;
			this.trackBar_y.Value = 40;
			this.trackBar_y.Scroll += new System.EventHandler(this.trackBar_y_Scroll);
			// 
			// trackBar_x
			// 
			this.trackBar_x.LargeChange = 10;
			this.trackBar_x.Location = new System.Drawing.Point(40, 42);
			this.trackBar_x.Maximum = 100;
			this.trackBar_x.Name = "trackBar_x";
			this.trackBar_x.Size = new System.Drawing.Size(176, 45);
			this.trackBar_x.TabIndex = 6;
			this.trackBar_x.Tag = "";
			this.trackBar_x.TickFrequency = 20;
			this.trackBar_x.Value = 50;
			this.trackBar_x.Scroll += new System.EventHandler(this.trackBar_x_Scroll);
			// 
			// label_z
			// 
			this.label_z.AutoSize = true;
			this.label_z.Location = new System.Drawing.Point(6, 141);
			this.label_z.Name = "label_z";
			this.label_z.Size = new System.Drawing.Size(19, 15);
			this.label_z.TabIndex = 5;
			this.label_z.Text = "20";
			// 
			// label_y
			// 
			this.label_y.AutoSize = true;
			this.label_y.Location = new System.Drawing.Point(6, 93);
			this.label_y.Name = "label_y";
			this.label_y.Size = new System.Drawing.Size(24, 15);
			this.label_y.TabIndex = 4;
			this.label_y.Text = "-10";
			// 
			// label_x
			// 
			this.label_x.AutoSize = true;
			this.label_x.Location = new System.Drawing.Point(6, 42);
			this.label_x.Name = "label_x";
			this.label_x.Size = new System.Drawing.Size(13, 15);
			this.label_x.TabIndex = 3;
			this.label_x.Text = "0";
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
			this.Name = "form_mainWindow";
			this.Text = "Chess animation";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_mainWindow_KeyDown);
			this.tableLayoutPanel_main.ResumeLayout(false);
			this.tableLayoutPanel_right.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_m)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_ks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_kd)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_z)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_y)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_x)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_workingArea)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private TableLayoutPanel tableLayoutPanel_main;
		private TableLayoutPanel tableLayoutPanel_right;
		private PictureBox pictureBox_workingArea;
		private GroupBox groupBox1;
		private Label label2;
		private Label label1;
		private Label label_fps;
		private Label label_position;
		private TrackBar trackBar_m;
		private Label label_mValue;
		private Label label_m;
		private TrackBar trackBar_ks;
		private Label label_ksValue;
		private Label label_ks;
		private Label label_kdValue;
		private Label label_kd;
		private TrackBar trackBar_kd;
		private GroupBox groupBox2;
		private TrackBar trackBar_z;
		private TrackBar trackBar_y;
		private TrackBar trackBar_x;
		private Label label_z;
		private Label label_y;
		private Label label_x;
	}
}