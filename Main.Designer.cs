namespace Graphito
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.strItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itmNew = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.strItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.strItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.picCanvas = new Graphito.Canvas();
            this.toolBar1 = new Graphito.ToolBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strItemFile,
            this.strItemUndo,
            this.strItemRedo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1424, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Menu";
            // 
            // strItemFile
            // 
            this.strItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmNew,
            this.itmSave,
            this.itmLoad});
            this.strItemFile.Name = "strItemFile";
            this.strItemFile.Size = new System.Drawing.Size(63, 21);
            this.strItemFile.Text = "Archivo";
            // 
            // itmNew
            // 
            this.itmNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.itmNew.ForeColor = System.Drawing.Color.White;
            this.itmNew.Name = "itmNew";
            this.itmNew.Size = new System.Drawing.Size(130, 24);
            this.itmNew.Text = "Nuevo";
            this.itmNew.Click += new System.EventHandler(this.itmNew_Click);
            // 
            // itmSave
            // 
            this.itmSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.itmSave.ForeColor = System.Drawing.Color.White;
            this.itmSave.Name = "itmSave";
            this.itmSave.Size = new System.Drawing.Size(130, 24);
            this.itmSave.Text = "Guardar";
            this.itmSave.Click += new System.EventHandler(this.itmSave_Click);
            // 
            // itmLoad
            // 
            this.itmLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.itmLoad.ForeColor = System.Drawing.Color.White;
            this.itmLoad.Name = "itmLoad";
            this.itmLoad.Size = new System.Drawing.Size(130, 24);
            this.itmLoad.Text = "Cargar";
            this.itmLoad.Click += new System.EventHandler(this.itmLoad_Click);
            // 
            // strItemUndo
            // 
            this.strItemUndo.Name = "strItemUndo";
            this.strItemUndo.Size = new System.Drawing.Size(34, 21);
            this.strItemUndo.Text = "<-";
            this.strItemUndo.Click += new System.EventHandler(this.strItemUndo_Click);
            // 
            // strItemRedo
            // 
            this.strItemRedo.Name = "strItemRedo";
            this.strItemRedo.Size = new System.Drawing.Size(34, 21);
            this.strItemRedo.Text = "->";
            this.strItemRedo.Click += new System.EventHandler(this.strItemRedo_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.bmp = ((System.Drawing.Bitmap)(resources.GetObject("picCanvas.bmp")));
            this.picCanvas.Image = ((System.Drawing.Image)(resources.GetObject("picCanvas.Image")));
            this.picCanvas.Location = new System.Drawing.Point(36, 168);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(1280, 720);
            this.picCanvas.TabIndex = 4;
            this.picCanvas.TabStop = false;
            // 
            // toolBar1
            // 
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar1.Location = new System.Drawing.Point(0, 25);
            this.toolBar1.Margin = new System.Windows.Forms.Padding(2);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(1424, 137);
            this.toolBar1.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1424, 983);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem strItemFile;
        private System.Windows.Forms.ToolStripMenuItem itmSave;
        private System.Windows.Forms.ToolStripMenuItem itmLoad;
        private ToolBar toolBar1;
        private Canvas picCanvas;
        private System.Windows.Forms.ToolStripMenuItem itmNew;
        private System.Windows.Forms.ToolStripMenuItem strItemUndo;
        private System.Windows.Forms.ToolStripMenuItem strItemRedo;
    }
}