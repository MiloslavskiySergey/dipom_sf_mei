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
		label1 = new System.Windows.Forms.Label();
		IncrementValueUpDown = new System.Windows.Forms.NumericUpDown();
		NextButton = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)IncrementValueUpDown).BeginInit();
		SuspendLayout();
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label1.Location = new System.Drawing.Point(12, 9);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(433, 131);
		label1.TabIndex = 0;
		label1.Text = "Сейчас будет создан файл базы данных, в котором будут храниться все записи о ваших клиентах, возможно вы захотите, чтобы нумерация начиналась не с 1, а с другого числа ( у вас уже была другая база, и чтобы не путать номера квитанций  и т.п.) Для этого введите нужное число ниже, или оставьте все как есть. Для продолжения нажмите кнопку \"Далее\"";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		IncrementValueUpDown.Location = new System.Drawing.Point(15, 163);
		IncrementValueUpDown.Maximum = new decimal(new int[4]
		{
			999999,
			0,
			0,
			0
		});
		IncrementValueUpDown.Minimum = new decimal(new int[4]
		{
			1,
			0,
			0,
			0
		});
		IncrementValueUpDown.Name = "IncrementValueUpDown";
		IncrementValueUpDown.Size = new System.Drawing.Size(214, 20);
		IncrementValueUpDown.TabIndex = 1;
		IncrementValueUpDown.Value = new decimal(new int[4]
		{
			1,
			0,
			0,
			0
		});
		NextButton.Location = new System.Drawing.Point(235, 161);
		NextButton.Name = "NextButton";
		NextButton.Size = new System.Drawing.Size(210, 23);
		NextButton.TabIndex = 2;
		NextButton.Text = "Далее";
		NextButton.UseVisualStyleBackColor = true;
		NextButton.Click += new System.EventHandler(NextButton_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(457, 204);
		base.Controls.Add(NextButton);
		base.Controls.Add(IncrementValueUpDown);
		base.Controls.Add(label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "BaseLineNumber";
		Text = "BaseLineNumber";
		base.TopMost = true;
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(BaseLineNumber_FormClosed);
		((System.ComponentModel.ISupportInitialize)IncrementValueUpDown).EndInit();
		ResumeLayout(false);
	}
}
