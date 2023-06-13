// SURPRISE

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

public class SURPRISE : Form
{
	private MainForm mainForm;

	private IContainer components = null;

	private Button button1;

	private Button Adress_NoNull;

	private Button button2;

	private Button button3;

	private Button button4;

	private Button button5;

	private ComboBox ServiceAdressComboBox;

	private ComboBox WhatToRenameServiceAdressComboBox;

	private Label label1;

	private Button button6;

	private Button button7;

	public SURPRISE(MainForm fm)
	{
		mainForm = fm;
		InitializeComponent();
		ComboboxMaker("settings/AdresSC.txt", ServiceAdressComboBox);
		ComboboxMaker("settings/AdresSC.txt", WhatToRenameServiceAdressComboBox);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		mainForm.basa.BdNoNull("Image_key");
	}

	private void Adress_NoNull_Click(object sender, EventArgs e)
	{
		mainForm.basa.BdNoNull("Adress");
	}

	private void button2_Click(object sender, EventArgs e)
	{
		mainForm.basa.BdNoNull("wait_zakaz");
	}

	private void button3_Click(object sender, EventArgs e)
	{
		mainForm.basa.BdNoNull("AdressSC");
	}

	private void button4_Click(object sender, EventArgs e)
	{
		mainForm.basa.BdNoNull("DeviceColour");
	}

	private void button5_Click(object sender, EventArgs e)
	{
		mainForm.basa.BdNoNullRename("AdressSC", ServiceAdressComboBox.Text, WhatToRenameServiceAdressComboBox.Text);
	}

	public void ComboboxMaker(string location, ComboBox cmb)
	{
		StreamReader streamReader = new StreamReader(location, Encoding.Default);
		for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
		{
			cmb.Items.Add(text);
		}
		streamReader.Close();
	}

	private void SURPRISE_Load(object sender, EventArgs e)
	{
	}

	private void button6_Click(object sender, EventArgs e)
	{
		mainForm.basa.BdNoNullRename("Status_remonta", "Ждёт запчасть", "Ждет ЗИП");
	}

	private void button7_Click(object sender, EventArgs e)
	{
		mainForm.basa.bdBarcodeAllGenerator();
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
		button1 = new System.Windows.Forms.Button();
		Adress_NoNull = new System.Windows.Forms.Button();
		button2 = new System.Windows.Forms.Button();
		button3 = new System.Windows.Forms.Button();
		button4 = new System.Windows.Forms.Button();
		button5 = new System.Windows.Forms.Button();
		ServiceAdressComboBox = new System.Windows.Forms.ComboBox();
		WhatToRenameServiceAdressComboBox = new System.Windows.Forms.ComboBox();
		label1 = new System.Windows.Forms.Label();
		button6 = new System.Windows.Forms.Button();
		button7 = new System.Windows.Forms.Button();
		SuspendLayout();
		button1.Location = new System.Drawing.Point(12, 12);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(501, 23);
		button1.TabIndex = 0;
		button1.Text = "Заменить NULL На пустые строки в Image_KEY";
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		Adress_NoNull.Location = new System.Drawing.Point(12, 41);
		Adress_NoNull.Name = "Adress_NoNull";
		Adress_NoNull.Size = new System.Drawing.Size(501, 23);
		Adress_NoNull.TabIndex = 1;
		Adress_NoNull.Text = "Заменить NULL на пустые строки в Adress";
		Adress_NoNull.UseVisualStyleBackColor = true;
		Adress_NoNull.Click += new System.EventHandler(Adress_NoNull_Click);
		button2.Location = new System.Drawing.Point(12, 70);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(501, 24);
		button2.TabIndex = 2;
		button2.Text = "Заменить NULL на пустые строки в Wait_zakz";
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(button2_Click);
		button3.Location = new System.Drawing.Point(12, 100);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(501, 24);
		button3.TabIndex = 3;
		button3.Text = "Заменить NULL на пустые строки в ADRESSSC";
		button3.UseVisualStyleBackColor = true;
		button3.Click += new System.EventHandler(button3_Click);
		button4.Location = new System.Drawing.Point(12, 130);
		button4.Name = "button4";
		button4.Size = new System.Drawing.Size(501, 24);
		button4.TabIndex = 4;
		button4.Text = "Заменить NULL на пустые строки в DeviceColour";
		button4.UseVisualStyleBackColor = true;
		button4.Click += new System.EventHandler(button4_Click);
		button5.Location = new System.Drawing.Point(12, 160);
		button5.Name = "button5";
		button5.Size = new System.Drawing.Size(135, 24);
		button5.TabIndex = 5;
		button5.Text = "Заменить Адреса сц";
		button5.UseVisualStyleBackColor = true;
		button5.Click += new System.EventHandler(button5_Click);
		ServiceAdressComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.62f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ServiceAdressComboBox.FormattingEnabled = true;
		ServiceAdressComboBox.Location = new System.Drawing.Point(353, 161);
		ServiceAdressComboBox.Name = "ServiceAdressComboBox";
		ServiceAdressComboBox.Size = new System.Drawing.Size(160, 21);
		ServiceAdressComboBox.TabIndex = 16;
		WhatToRenameServiceAdressComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.62f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		WhatToRenameServiceAdressComboBox.FormattingEnabled = true;
		WhatToRenameServiceAdressComboBox.Location = new System.Drawing.Point(153, 161);
		WhatToRenameServiceAdressComboBox.Name = "WhatToRenameServiceAdressComboBox";
		WhatToRenameServiceAdressComboBox.Size = new System.Drawing.Size(153, 21);
		WhatToRenameServiceAdressComboBox.TabIndex = 17;
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(321, 166);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(19, 13);
		label1.TabIndex = 18;
		label1.Text = "на";
		button6.Location = new System.Drawing.Point(12, 190);
		button6.Name = "button6";
		button6.Size = new System.Drawing.Size(501, 24);
		button6.TabIndex = 19;
		button6.Text = "Заменить Ждёт зип, на Ждёт запчасть";
		button6.UseVisualStyleBackColor = true;
		button6.Click += new System.EventHandler(button6_Click);
		button7.Location = new System.Drawing.Point(12, 220);
		button7.Name = "button7";
		button7.Size = new System.Drawing.Size(501, 24);
		button7.TabIndex = 20;
		button7.Text = "Сгенерировать баркоды";
		button7.UseVisualStyleBackColor = true;
		button7.Click += new System.EventHandler(button7_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(525, 251);
		base.Controls.Add(button7);
		base.Controls.Add(button6);
		base.Controls.Add(label1);
		base.Controls.Add(WhatToRenameServiceAdressComboBox);
		base.Controls.Add(ServiceAdressComboBox);
		base.Controls.Add(button5);
		base.Controls.Add(button4);
		base.Controls.Add(button3);
		base.Controls.Add(button2);
		base.Controls.Add(Adress_NoNull);
		base.Controls.Add(button1);
		base.Name = "SURPRISE";
		Text = "SURPRISE";
		base.Load += new System.EventHandler(SURPRISE_Load);
		ResumeLayout(false);
		PerformLayout();
	}
}
