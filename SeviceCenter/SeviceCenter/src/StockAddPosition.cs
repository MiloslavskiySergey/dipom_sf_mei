// StockAddPosition

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

public class StockAddPosition : Form
{
	private Form1 mainForm;

	private Stock stockForm;

	private string photoPath = "";

	private string photoPath2 = "";

	private string photoPath3 = "";

	private IContainer components = null;

	private TextBox ModelTextBox;

	private ComboBox ColourComboBox;

	private ComboBox BrandComboBox;

	private ComboBox PodKategoryComboBox;

	private ComboBox KategoryComboBox;

	private TextBox PrimechanieTextBox;

	private TextBox CountOfTextBox;

	private Label label1;

	private TextBox NapominanieTextBox;

	private Label label2;

	private Label label3;

	private Label label4;

	private Label label5;

	private Label label6;

	private Label label7;

	private Button button1;

	private Label label8;

	private Label label9;

	private TextBox PriceTextBox;

	private Button button2;

	private OpenFileDialog openFileDialog1;

	private Button ResetFields;

	private Button button3;

	private Button button4;

	public StockAddPosition(Form1 mf, Stock st1)
	{
		InitializeComponent();
		mainForm = mf;
		stockForm = st1;
	}

	private void StockAddPosition_Load(object sender, EventArgs e)
	{
		ComboboxMaker("settings/Stock/ustrojstvo.txt", KategoryComboBox);
		ComboboxMaker("settings/Stock/TypeOvZIP.txt", PodKategoryComboBox);
		ComboboxMaker("settings/Stock/brands.txt", BrandComboBox);
		ComboboxMaker("settings/Stock/DeviceColour.txt", ColourComboBox);
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

	private void button1_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Добавить " + NaimenovanieMaker() + " в склад?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.BdStockWrite(NaimenovanieMaker(), KategoryComboBox.Text, PodKategoryComboBox.Text, ColourComboBox.Text, BrandComboBox.Text, ModelTextBox.Text, CountOfTextBox.Text, NapominanieTextBox.Text, PriceTextBox.Text, PrimechanieTextBox.Text, photoPath, photoPath2, photoPath3);
			photoPath = "";
			button2.Text = "Загрузить фото";
			button4.Text = "Загрузите фото 2";
			button3.Text = "Загрузите фото 3";
			stockForm.StockFullSearch();
		}
	}

	private string NaimenovanieMaker()
	{
		if (PrimechanieTextBox.Text != "")
		{
			return KategoryComboBox.Text + " " + PodKategoryComboBox.Text + " " + BrandComboBox.Text + " " + ModelTextBox.Text + " " + ColourComboBox.Text + " (" + PrimechanieTextBox.Text + ")";
		}
		return KategoryComboBox.Text + " " + PodKategoryComboBox.Text + " " + BrandComboBox.Text + " " + ModelTextBox.Text + " " + ColourComboBox.Text + " " + PrimechanieTextBox.Text;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		openFileDialog1.Filter = "Файлы изображений|*.bmp;*.jpg;*.jpeg;*.png";
		openFileDialog1.ShowDialog();
		button2.Text = openFileDialog1.FileName;
		string str = openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4);
		if (File.Exists(openFileDialog1.FileName))
		{
			string destFileName = "settings\\Stock\\Photos\\" + Path.GetRandomFileName() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + str;
			File.Copy(openFileDialog1.FileName, destFileName);
			photoPath = destFileName;
		}
		if (button2.Text == "openFileDialog1")
		{
			button2.Text = "Не загружено";
		}
		openFileDialog1.FileName = "openFileDialog1";
	}

	private void ResetFields_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Данное действие очистить все поля, в которых введены данные", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			PrimechanieTextBox.Text = "";
			KategoryComboBox.Text = "";
			PodKategoryComboBox.Text = "";
			BrandComboBox.Text = "";
			ModelTextBox.Text = "";
			ColourComboBox.Text = "";
			PriceTextBox.Text = "";
			CountOfTextBox.Text = "";
			NapominanieTextBox.Text = "";
			button2.Text = "Загрузить фото";
			photoPath = "";
		}
	}

	private void button4_Click(object sender, EventArgs e)
	{
		openFileDialog1.Filter = "Файлы изображений|*.bmp;*.jpg;*.jpeg;*.png";
		openFileDialog1.ShowDialog();
		button4.Text = openFileDialog1.FileName;
		string str = openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4);
		if (File.Exists(openFileDialog1.FileName))
		{
			string destFileName = "settings\\Stock\\Photos\\" + Path.GetRandomFileName() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + str;
			File.Copy(openFileDialog1.FileName, destFileName);
			photoPath2 = destFileName;
		}
		if (button4.Text == "openFileDialog1")
		{
			button4.Text = "Не загружено";
		}
		openFileDialog1.FileName = "openFileDialog1";
	}

	private void button3_Click(object sender, EventArgs e)
	{
		openFileDialog1.Filter = "Файлы изображений|*.bmp;*.jpg;*.jpeg;*.png";
		openFileDialog1.ShowDialog();
		button3.Text = openFileDialog1.FileName;
		string str = openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4);
		if (File.Exists(openFileDialog1.FileName))
		{
			string destFileName = "settings\\Stock\\Photos\\" + Path.GetRandomFileName() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + str;
			File.Copy(openFileDialog1.FileName, destFileName);
			photoPath3 = destFileName;
		}
		if (button3.Text == "openFileDialog1")
		{
			button3.Text = "Не загружено";
		}
		openFileDialog1.FileName = "openFileDialog1";
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
            this.ModelTextBox = new System.Windows.Forms.TextBox();
            this.ColourComboBox = new System.Windows.Forms.ComboBox();
            this.BrandComboBox = new System.Windows.Forms.ComboBox();
            this.PodKategoryComboBox = new System.Windows.Forms.ComboBox();
            this.KategoryComboBox = new System.Windows.Forms.ComboBox();
            this.PrimechanieTextBox = new System.Windows.Forms.TextBox();
            this.CountOfTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NapominanieTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ResetFields = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ModelTextBox
            // 
            this.ModelTextBox.Location = new System.Drawing.Point(353, 158);
            this.ModelTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ModelTextBox.Name = "ModelTextBox";
            this.ModelTextBox.Size = new System.Drawing.Size(237, 22);
            this.ModelTextBox.TabIndex = 5;
            // 
            // ColourComboBox
            // 
            this.ColourComboBox.FormattingEnabled = true;
            this.ColourComboBox.Location = new System.Drawing.Point(353, 190);
            this.ColourComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ColourComboBox.Name = "ColourComboBox";
            this.ColourComboBox.Size = new System.Drawing.Size(237, 24);
            this.ColourComboBox.TabIndex = 6;
            // 
            // BrandComboBox
            // 
            this.BrandComboBox.FormattingEnabled = true;
            this.BrandComboBox.Location = new System.Drawing.Point(353, 124);
            this.BrandComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrandComboBox.Name = "BrandComboBox";
            this.BrandComboBox.Size = new System.Drawing.Size(237, 24);
            this.BrandComboBox.TabIndex = 4;
            // 
            // PodKategoryComboBox
            // 
            this.PodKategoryComboBox.FormattingEnabled = true;
            this.PodKategoryComboBox.Location = new System.Drawing.Point(353, 91);
            this.PodKategoryComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PodKategoryComboBox.Name = "PodKategoryComboBox";
            this.PodKategoryComboBox.Size = new System.Drawing.Size(237, 24);
            this.PodKategoryComboBox.TabIndex = 3;
            // 
            // KategoryComboBox
            // 
            this.KategoryComboBox.FormattingEnabled = true;
            this.KategoryComboBox.Location = new System.Drawing.Point(353, 58);
            this.KategoryComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KategoryComboBox.Name = "KategoryComboBox";
            this.KategoryComboBox.Size = new System.Drawing.Size(237, 24);
            this.KategoryComboBox.TabIndex = 2;
            // 
            // PrimechanieTextBox
            // 
            this.PrimechanieTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.PrimechanieTextBox.Location = new System.Drawing.Point(157, 15);
            this.PrimechanieTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PrimechanieTextBox.Name = "PrimechanieTextBox";
            this.PrimechanieTextBox.Size = new System.Drawing.Size(433, 22);
            this.PrimechanieTextBox.TabIndex = 1;
            // 
            // CountOfTextBox
            // 
            this.CountOfTextBox.Location = new System.Drawing.Point(353, 255);
            this.CountOfTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CountOfTextBox.Name = "CountOfTextBox";
            this.CountOfTextBox.Size = new System.Drawing.Size(237, 22);
            this.CountOfTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Тип устройства: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NapominanieTextBox
            // 
            this.NapominanieTextBox.Location = new System.Drawing.Point(353, 287);
            this.NapominanieTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NapominanieTextBox.Name = "NapominanieTextBox";
            this.NapominanieTextBox.Size = new System.Drawing.Size(237, 22);
            this.NapominanieTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Тип запчасти (ЗИП): ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(329, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Бренд: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(24, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(321, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Модель: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(24, 194);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(321, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Цвет: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(24, 258);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(321, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Количество: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(24, 290);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(321, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Напомнить, если количество менее: ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 321);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(576, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "Добавить в склад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Примечание: ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(24, 226);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(321, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Цена: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(353, 223);
            this.PriceTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(237, 22);
            this.PriceTextBox.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 139);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 30);
            this.button2.TabIndex = 10;
            this.button2.Text = "Загрузить фото";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ResetFields
            // 
            this.ResetFields.Location = new System.Drawing.Point(16, 357);
            this.ResetFields.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResetFields.Name = "ResetFields";
            this.ResetFields.Size = new System.Drawing.Size(576, 28);
            this.ResetFields.TabIndex = 29;
            this.ResetFields.Text = "Очистить поля";
            this.ResetFields.UseVisualStyleBackColor = true;
            this.ResetFields.Click += new System.EventHandler(this.ResetFields_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 210);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 27);
            this.button3.TabIndex = 55;
            this.button3.Text = "Загрузить фото 3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(17, 176);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(192, 27);
            this.button4.TabIndex = 54;
            this.button4.Text = "Загрузить фото 2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // StockAddPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 395);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ResetFields);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NapominanieTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CountOfTextBox);
            this.Controls.Add(this.ModelTextBox);
            this.Controls.Add(this.ColourComboBox);
            this.Controls.Add(this.BrandComboBox);
            this.Controls.Add(this.PodKategoryComboBox);
            this.Controls.Add(this.KategoryComboBox);
            this.Controls.Add(this.PrimechanieTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StockAddPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить запчасть";
            this.Load += new System.EventHandler(this.StockAddPosition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

	}
}
