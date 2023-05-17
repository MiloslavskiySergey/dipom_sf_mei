// BaseLineNumber

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class BaseLineNumber : Form
{
	private Form1 mainForm;

	private IContainer components = null;

	private Label label1;

	private NumericUpDown IncrementValueUpDown;

	private Button NextButton;

	public BaseLineNumber(Form1 mf)
	{
		mainForm = mf;
		InitializeComponent();
	}

	private void NextButton_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void BaseLineNumber_FormClosed(object sender, FormClosedEventArgs e)
	{
		if (IncrementValueUpDown.Value != decimal.One)
		{
			mainForm.basa.BdWrite(DateTime.Now.ToShortDateString(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
			string id_bd = mainForm.basa.BdReadAdvertsDataTop().ToString();
			mainForm.basa.BdDelete(id_bd);
			mainForm.basa.CreateBd((IncrementValueUpDown.Value - decimal.One).ToString());
		}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseLineNumber));
            this.label1 = new System.Windows.Forms.Label();
            this.IncrementValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.NextButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IncrementValueUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 161);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IncrementValueUpDown
            // 
            this.IncrementValueUpDown.Location = new System.Drawing.Point(20, 201);
            this.IncrementValueUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IncrementValueUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.IncrementValueUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IncrementValueUpDown.Name = "IncrementValueUpDown";
            this.IncrementValueUpDown.Size = new System.Drawing.Size(285, 22);
            this.IncrementValueUpDown.TabIndex = 1;
            this.IncrementValueUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(313, 198);
            this.NextButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(280, 28);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = "Далее";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // BaseLineNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 251);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.IncrementValueUpDown);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BaseLineNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseLineNumber";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseLineNumber_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.IncrementValueUpDown)).EndInit();
            this.ResumeLayout(false);

	}
}
