/*
 * Created by SharpDevelop.
 * User: IDEAD PAD 330S
 * Date: 08/09/2019
 * Time: 09:54 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Actividad1
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button buttonCargar;
		private System.Windows.Forms.Button buttonAnalizar;
		private System.Windows.Forms.PictureBox pictureBoxImagen;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.PictureBox pictureBoxResultado;
		private System.Windows.Forms.ListBox listBoxCircles;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button buttonParCercano;
		private System.Windows.Forms.Button buttonOrdena;
		private System.Windows.Forms.Label IdCirculo;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonCargar = new System.Windows.Forms.Button();
			this.buttonAnalizar = new System.Windows.Forms.Button();
			this.pictureBoxImagen = new System.Windows.Forms.PictureBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.pictureBoxResultado = new System.Windows.Forms.PictureBox();
			this.listBoxCircles = new System.Windows.Forms.ListBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.buttonParCercano = new System.Windows.Forms.Button();
			this.buttonOrdena = new System.Windows.Forms.Button();
			this.IdCirculo = new System.Windows.Forms.Label();
			this.Circuito = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultado)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCargar
			// 
			this.buttonCargar.Location = new System.Drawing.Point(663, 29);
			this.buttonCargar.Name = "buttonCargar";
			this.buttonCargar.Size = new System.Drawing.Size(81, 41);
			this.buttonCargar.TabIndex = 0;
			this.buttonCargar.Text = "Cargar";
			this.buttonCargar.UseVisualStyleBackColor = true;
			this.buttonCargar.Click += new System.EventHandler(this.ButtonCargarClick);
			// 
			// buttonAnalizar
			// 
			this.buttonAnalizar.Location = new System.Drawing.Point(663, 77);
			this.buttonAnalizar.Name = "buttonAnalizar";
			this.buttonAnalizar.Size = new System.Drawing.Size(81, 35);
			this.buttonAnalizar.TabIndex = 1;
			this.buttonAnalizar.Text = "Analizar";
			this.buttonAnalizar.UseVisualStyleBackColor = true;
			this.buttonAnalizar.Visible = false;
			this.buttonAnalizar.Click += new System.EventHandler(this.ButtonAnalizarClick);
			// 
			// pictureBoxImagen
			// 
			this.pictureBoxImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxImagen.Location = new System.Drawing.Point(12, 29);
			this.pictureBoxImagen.Name = "pictureBoxImagen";
			this.pictureBoxImagen.Size = new System.Drawing.Size(298, 264);
			this.pictureBoxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxImagen.TabIndex = 2;
			this.pictureBoxImagen.TabStop = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// pictureBoxResultado
			// 
			this.pictureBoxResultado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxResultado.Location = new System.Drawing.Point(316, 29);
			this.pictureBoxResultado.Name = "pictureBoxResultado";
			this.pictureBoxResultado.Size = new System.Drawing.Size(324, 264);
			this.pictureBoxResultado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxResultado.TabIndex = 3;
			this.pictureBoxResultado.TabStop = false;
			this.pictureBoxResultado.Click += new System.EventHandler(this.PictureBoxResultadoClick);
			this.pictureBoxResultado.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxResultadoMouseClick);
			this.pictureBoxResultado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxResultado_MouseDoubleClick);
			this.pictureBoxResultado.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxResultadoMouseMove);
			// 
			// listBoxCircles
			// 
			this.listBoxCircles.FormattingEnabled = true;
			this.listBoxCircles.Location = new System.Drawing.Point(646, 119);
			this.listBoxCircles.Name = "listBoxCircles";
			this.listBoxCircles.Size = new System.Drawing.Size(198, 82);
			this.listBoxCircles.TabIndex = 4;
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(654, 227);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(189, 103);
			this.treeView1.TabIndex = 5;
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1NodeMouseClick);
			// 
			// buttonParCercano
			// 
			this.buttonParCercano.Location = new System.Drawing.Point(750, 29);
			this.buttonParCercano.Name = "buttonParCercano";
			this.buttonParCercano.Size = new System.Drawing.Size(92, 41);
			this.buttonParCercano.TabIndex = 6;
			this.buttonParCercano.Text = "Par cercano";
			this.buttonParCercano.UseVisualStyleBackColor = true;
			this.buttonParCercano.Visible = false;
			this.buttonParCercano.Click += new System.EventHandler(this.ButtonParCercanoClick);
			// 
			// buttonOrdena
			// 
			this.buttonOrdena.Location = new System.Drawing.Point(272, 360);
			this.buttonOrdena.Name = "buttonOrdena";
			this.buttonOrdena.Size = new System.Drawing.Size(92, 35);
			this.buttonOrdena.TabIndex = 7;
			this.buttonOrdena.Text = "Ordenar";
			this.buttonOrdena.UseVisualStyleBackColor = true;
			this.buttonOrdena.Visible = false;
			this.buttonOrdena.Click += new System.EventHandler(this.ButtonOrdenaClick);
			// 
			// IdCirculo
			// 
			this.IdCirculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IdCirculo.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.IdCirculo.Location = new System.Drawing.Point(386, 0);
			this.IdCirculo.Name = "IdCirculo";
			this.IdCirculo.Size = new System.Drawing.Size(196, 27);
			this.IdCirculo.TabIndex = 8;
			// 
			// Circuito
			// 
			this.Circuito.Location = new System.Drawing.Point(750, 76);
			this.Circuito.Name = "Circuito";
			this.Circuito.Size = new System.Drawing.Size(92, 37);
			this.Circuito.TabIndex = 9;
			this.Circuito.Text = "Circuito";
			this.Circuito.UseVisualStyleBackColor = true;
			this.Circuito.Visible = false;
			this.Circuito.Click += new System.EventHandler(this.Circuito_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(870, 430);
			this.Controls.Add(this.Circuito);
			this.Controls.Add(this.IdCirculo);
			this.Controls.Add(this.buttonOrdena);
			this.Controls.Add(this.buttonParCercano);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.listBoxCircles);
			this.Controls.Add(this.pictureBoxResultado);
			this.Controls.Add(this.pictureBoxImagen);
			this.Controls.Add(this.buttonAnalizar);
			this.Controls.Add(this.buttonCargar);
			this.Name = "MainForm";
			this.Text = "Actividad1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultado)).EndInit();
			this.ResumeLayout(false);

		}

        private System.Windows.Forms.Button Circuito;
    }
}
