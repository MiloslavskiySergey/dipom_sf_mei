// StockPictureShowForm
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class StockPictureShowForm : Form
{
	private IContainer components = null;

	private PictureBox pictureBox1;

	public StockPictureShowForm()
	{
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		pictureBox1.Location = new System.Drawing.Point(0, 0);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(100, 50);
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(640, 468);
		base.Controls.Add(pictureBox1);
		base.Name = "StockPictureShowForm";
		Text = "StockPictureShowForm";
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
