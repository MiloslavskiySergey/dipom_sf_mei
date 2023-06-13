// Export

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class Export : Form
{
	private IniFile INIF = new IniFile("Config.ini");

	private MainForm MainForm;

	private IContainer components = null;

	private Button ExportToAndroidButton;

	private Label label1;

	private Label label2;

	private NumericUpDown fromNumericUpDown;

	private Label label3;

	private NumericUpDown toNumericUpDown;

	private Button ExportToAppleButton;

	private Button AllExportNumbersButton;

	public Export(MainForm fm1)
	{
		InitializeComponent();
		MainForm = fm1;
	}

	private void Export_Load(object sender, EventArgs e)
	{
		if (INIF.KeyExists("EXPORT", "to"))
		{
			label1.Text = string.Format("В прошлый раз, Вы экспортировали номера с {0} по {1} ", INIF.ReadINI("EXPORT", "from"), INIF.ReadINI("EXPORT", "to"));
			if (int.Parse(INIF.ReadINI("EXPORT", "to")) < MainForm.basa.BdReadAdvertsDataTop())
			{
				fromNumericUpDown.Value = int.Parse(INIF.ReadINI("EXPORT", "to")) + 1;
				toNumericUpDown.Value = MainForm.basa.BdReadAdvertsDataTop();
				Label label = label1;
				label.Text = label.Text + Environment.NewLine + "Дипазон номеров сформирован для нового экспорта";
			}
			else
			{
				toNumericUpDown.Value = MainForm.basa.BdReadAdvertsDataTop();
				fromNumericUpDown.Value = MainForm.basa.BdReadAdvertsDataFirt();
				Label label2 = label1;
				label2.Text = label2.Text + Environment.NewLine + "Новых номеров не появилось";
			}
		}
		else
		{
			toNumericUpDown.Value = MainForm.basa.BdReadAdvertsDataTop();
			fromNumericUpDown.Value = MainForm.basa.BdReadAdvertsDataFirt();
		}
	}

	private void ExportToAndroidButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Будет создан файл Contacts.csv, содержащий все ваши контакты, он находится в папке с программой", "Экспорт контактов", MessageBoxButtons.OKCancel) != DialogResult.OK)
		{
			return;
		}
		int value = MainForm.basa.BdReadAdvertsDataFirt();
		MainForm.basa.BdReadAdvertsDataTop();
		new List<VirtualClient>();
		if ((decimal)value < fromNumericUpDown.Value)
		{
			List<VirtualClient> list = MainForm.basa.ExportPhonesVCList(value.ToString(), (fromNumericUpDown.Value - decimal.One).ToString());
			string text = string.Format("google_{0}.csv", DateTime.Now.ToString("dd_MM_yyyy_hh_mm"));
			new List<VirtualClient>();
			List<PhoneExport> list2 = new List<PhoneExport>();
			List<VirtualClient> list3 = MainForm.basa.ExportPhonesVCList(fromNumericUpDown.Value.ToString(), toNumericUpDown.Value.ToString());
			for (int i = 0; i < list3.Count; i++)
			{
				if (!PhoneValidator(list3[i].Phone))
				{
					continue;
				}
				bool flag = true;
				for (int j = 0; j < list.Count; j++)
				{
					if (list3[i].Phone == list[j].Phone)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list2.Add(new PhoneExport(list3[i].Phone, list3[i].Surname));
				}
			}
			List<PhoneExport> list4 = list2.Distinct().ToList();
			string text2 = "Name,Given Name,Additional Name,Family Name,Yomi Name,Given Name Yomi,Additional Name Yomi,Family Name Yomi,Name Prefix,Name Suffix,Initials,Nickname,Short Name,Maiden Name,Birthday,Gender,Location,Billing Information,Directory Server,Mileage,Occupation,Hobby,Sensitivity,Priority,Subject,Notes,Group Membership,Phone 1 - Type,Phone 1 - Value,Phone 2 - Type,Phone 2 - Value";
			for (int k = 0; k < list4.Count; k++)
			{
				text2 += string.Format("{0},{0},,,,,,,,,,,,,,,,,,,,,,,,,* {1},{2},{3},,", FirstLetterToUpper(list4[k].FIO.Replace(",", "")), "My Contacts", "Mobile", list4[k].Phone);
				text2 += Environment.NewLine;
			}
			File.WriteAllText(text, text2);
			if (list4.Count == 0)
			{
				MessageBox.Show("Новых клиентов не обнаружено");
			}
			else
			{
				MessageBox.Show($"{list4.Count.ToString()} новых клиентов добавлено в файл {text}");
			}
			INIF.WriteINI("EXPORT", "from", fromNumericUpDown.Value.ToString());
			INIF.WriteINI("EXPORT", "to", toNumericUpDown.Value.ToString());
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			string str = text;
			processStartInfo.CreateNoWindow = true;
			processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
			processStartInfo.FileName = "explorer";
			processStartInfo.Arguments = "/n, /select, " + str;
			process.StartInfo = processStartInfo;
			process.Start();
			return;
		}
		string text3 = string.Format("google_{0}.csv", DateTime.Now.ToString("dd_MM_yyyy_hh_mm"));
		new List<VirtualClient>();
		List<PhoneExport> list5 = new List<PhoneExport>();
		List<VirtualClient> list6 = MainForm.basa.ExportPhonesVCList(fromNumericUpDown.Value.ToString(), toNumericUpDown.Value.ToString());
		for (int l = 0; l < list6.Count; l++)
		{
			if (PhoneValidator(list6[l].Phone))
			{
				list5.Add(new PhoneExport(list6[l].Phone, list6[l].Surname));
			}
		}
		List<PhoneExport> list7 = list5.Distinct().ToList();
		string text4 = "Name,Given Name,Additional Name,Family Name,Yomi Name,Given Name Yomi,Additional Name Yomi,Family Name Yomi,Name Prefix,Name Suffix,Initials,Nickname,Short Name,Maiden Name,Birthday,Gender,Location,Billing Information,Directory Server,Mileage,Occupation,Hobby,Sensitivity,Priority,Subject,Notes,Group Membership,Phone 1 - Type,Phone 1 - Value,Phone 2 - Type,Phone 2 - Value";
		for (int m = 0; m < list7.Count; m++)
		{
			text4 += string.Format("{0},{0},,,,,,,,,,,,,,,,,,,,,,,,,* {1},{2},{3},,", FirstLetterToUpper(list7[m].FIO.Replace(",", "")), "My Contacts", "Mobile", list7[m].Phone);
			text4 += Environment.NewLine;
		}
		File.WriteAllText(text3, text4);
		if (list7.Count == 0)
		{
			MessageBox.Show("Новых клиентов не обнаружено");
		}
		else
		{
			MessageBox.Show($"{list7.Count.ToString()} новых клиентов добавлено в файл {text3}");
		}
		INIF.WriteINI("EXPORT", "from", fromNumericUpDown.Value.ToString());
		INIF.WriteINI("EXPORT", "to", toNumericUpDown.Value.ToString());
		Process process2 = new Process();
		ProcessStartInfo processStartInfo2 = new ProcessStartInfo();
		string str2 = text3;
		processStartInfo2.CreateNoWindow = true;
		processStartInfo2.WindowStyle = ProcessWindowStyle.Normal;
		processStartInfo2.FileName = "explorer";
		processStartInfo2.Arguments = "/n, /select, " + str2;
		process2.StartInfo = processStartInfo2;
		process2.Start();
	}

	private string FirstLetterToUpper(string krolik)
	{
		string source = " \r\n\t";
		StringBuilder stringBuilder = new StringBuilder(krolik.ToLower());
		if (stringBuilder.Length > 0 && char.IsLetter(stringBuilder[0]))
		{
			stringBuilder[0] = char.ToUpper(stringBuilder[0]);
		}
		for (int i = 1; i < stringBuilder.Length; i++)
		{
			char c = stringBuilder[i];
			if (source.Contains(stringBuilder[i - 1]) && char.IsLetter(c))
			{
				stringBuilder[i] = char.ToUpper(c);
			}
		}
		return stringBuilder.ToString();
	}

	private void ExportToAppleButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Будет создан файл Vcard.vcf, содержащий все ваши контакты, он находится в папке с программой", "Экспорт контактов", MessageBoxButtons.OKCancel) != DialogResult.OK)
		{
			return;
		}
		int value = MainForm.basa.BdReadAdvertsDataFirt();
		MainForm.basa.BdReadAdvertsDataTop();
		new List<VirtualClient>();
		if ((decimal)value < fromNumericUpDown.Value)
		{
			List<VirtualClient> list = MainForm.basa.ExportPhonesVCList(value.ToString(), (fromNumericUpDown.Value - decimal.One).ToString());
			string text = string.Format("google_{0}.vcf", DateTime.Now.ToString("dd_MM_yyyy_hh_mm"));
			new List<VirtualClient>();
			List<PhoneExport> list2 = new List<PhoneExport>();
			List<VirtualClient> list3 = MainForm.basa.ExportPhonesVCList(fromNumericUpDown.Value.ToString(), toNumericUpDown.Value.ToString());
			for (int i = 0; i < list3.Count; i++)
			{
				if (!PhoneValidator(list3[i].Phone))
				{
					continue;
				}
				bool flag = true;
				for (int j = 0; j < list.Count; j++)
				{
					if (list3[i].Phone == list[j].Phone)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list2.Add(new PhoneExport(list3[i].Phone, list3[i].Surname));
				}
			}
			List<PhoneExport> list4 = list2.Distinct().ToList();
			string text2 = "";
			for (int k = 0; k < list4.Count; k++)
			{
				text2 += string.Format("{1}{4}{2}{4}FN:{0}{4}N:;{0};;;{4}TEL;TYPE=CELL:{3}{4}{5}", FirstLetterToUpper(list4[k].FIO.Replace(",", "")), "BEGIN:VCARD", "VERSION:3.0", list4[k].Phone, Environment.NewLine, "END:VCARD");
				text2 += Environment.NewLine;
			}
			File.WriteAllText(text, text2);
			if (list4.Count == 0)
			{
				MessageBox.Show("Новых клиентов не обнаружено");
			}
			else
			{
				MessageBox.Show($"{list4.Count.ToString()} новых клиентов добавлено в файл {text}");
			}
			INIF.WriteINI("EXPORT", "from", fromNumericUpDown.Value.ToString());
			INIF.WriteINI("EXPORT", "to", toNumericUpDown.Value.ToString());
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			string str = text;
			processStartInfo.CreateNoWindow = true;
			processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
			processStartInfo.FileName = "explorer";
			processStartInfo.Arguments = "/n, /select, " + str;
			process.StartInfo = processStartInfo;
			process.Start();
			return;
		}
		string text3 = string.Format("Vcard_{0}.vcf", DateTime.Now.ToString("dd_MM_yyyy_hh_mm"));
		new List<VirtualClient>();
		List<PhoneExport> list5 = new List<PhoneExport>();
		List<VirtualClient> list6 = MainForm.basa.ExportPhonesVCList(fromNumericUpDown.Value.ToString(), toNumericUpDown.Value.ToString());
		for (int l = 0; l < list6.Count; l++)
		{
			if (PhoneValidator(list6[l].Phone))
			{
				list5.Add(new PhoneExport(list6[l].Phone, list6[l].Surname));
			}
		}
		List<PhoneExport> list7 = list5.Distinct().ToList();
		string text4 = "";
		for (int m = 0; m < list7.Count; m++)
		{
			text4 += string.Format("{1}{4}{2}{4}FN:{0}{4}N:;{0};;;{4}TEL;TYPE=CELL:{3}{4}{5}", FirstLetterToUpper(list7[m].FIO.Replace(",", "")), "BEGIN:VCARD", "VERSION:3.0", list7[m].Phone, Environment.NewLine, "END:VCARD");
			text4 += Environment.NewLine;
		}
		File.WriteAllText(text3, text4);
		if (list7.Count == 0)
		{
			MessageBox.Show("Новых клиентов не обнаружено");
		}
		else
		{
			MessageBox.Show($"{list7.Count.ToString()} новых клиентов добавлено в файл {text3}");
		}
		INIF.WriteINI("EXPORT", "from", fromNumericUpDown.Value.ToString());
		INIF.WriteINI("EXPORT", "to", toNumericUpDown.Value.ToString());
		Process process2 = new Process();
		ProcessStartInfo processStartInfo2 = new ProcessStartInfo();
		string str2 = text3;
		processStartInfo2.CreateNoWindow = true;
		processStartInfo2.WindowStyle = ProcessWindowStyle.Normal;
		processStartInfo2.FileName = "explorer";
		processStartInfo2.Arguments = "/n, /select, " + str2;
		process2.StartInfo = processStartInfo2;
		process2.Start();
	}

	private bool PhoneValidator(string phone)
	{
		if (phone.Length == 11)
		{
			return true;
		}
		return false;
	}

	private void AllExportNumbersButton_Click(object sender, EventArgs e)
	{
		toNumericUpDown.Value = MainForm.basa.BdReadAdvertsDataTop();
		fromNumericUpDown.Value = MainForm.basa.BdReadAdvertsDataFirt();
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
            this.ExportToAndroidButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fromNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.toNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ExportToAppleButton = new System.Windows.Forms.Button();
            this.AllExportNumbersButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fromNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ExportToAndroidButton
            // 
            this.ExportToAndroidButton.Location = new System.Drawing.Point(52, 207);
            this.ExportToAndroidButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExportToAndroidButton.Name = "ExportToAndroidButton";
            this.ExportToAndroidButton.Size = new System.Drawing.Size(556, 28);
            this.ExportToAndroidButton.TabIndex = 0;
            this.ExportToAndroidButton.Text = "Для переноса в csv формат";
            this.ExportToAndroidButton.UseVisualStyleBackColor = true;
            this.ExportToAndroidButton.Click += new System.EventHandler(this.ExportToAndroidButton_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(647, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пока еще вы не экспортировали номера телефонов";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Экспортировать телефонные номера клиентов с \r\n";
            // 
            // fromNumericUpDown
            // 
            this.fromNumericUpDown.Location = new System.Drawing.Point(401, 79);
            this.fromNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fromNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.fromNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fromNumericUpDown.Name = "fromNumericUpDown";
            this.fromNumericUpDown.Size = new System.Drawing.Size(160, 22);
            this.fromNumericUpDown.TabIndex = 3;
            this.fromNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "по";
            // 
            // toNumericUpDown
            // 
            this.toNumericUpDown.Location = new System.Drawing.Point(401, 114);
            this.toNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.toNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.toNumericUpDown.Name = "toNumericUpDown";
            this.toNumericUpDown.Size = new System.Drawing.Size(160, 22);
            this.toNumericUpDown.TabIndex = 5;
            this.toNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ExportToAppleButton
            // 
            this.ExportToAppleButton.Location = new System.Drawing.Point(52, 171);
            this.ExportToAppleButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExportToAppleButton.Name = "ExportToAppleButton";
            this.ExportToAppleButton.Size = new System.Drawing.Size(556, 28);
            this.ExportToAppleButton.TabIndex = 6;
            this.ExportToAppleButton.Text = "Для переноса в Android/Iphone/Vcard";
            this.ExportToAppleButton.UseVisualStyleBackColor = true;
            this.ExportToAppleButton.Click += new System.EventHandler(this.ExportToAppleButton_Click);
            // 
            // AllExportNumbersButton
            // 
            this.AllExportNumbersButton.Location = new System.Drawing.Point(569, 78);
            this.AllExportNumbersButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AllExportNumbersButton.Name = "AllExportNumbersButton";
            this.AllExportNumbersButton.Size = new System.Drawing.Size(48, 63);
            this.AllExportNumbersButton.TabIndex = 7;
            this.AllExportNumbersButton.Text = "Все";
            this.AllExportNumbersButton.UseVisualStyleBackColor = true;
            this.AllExportNumbersButton.Click += new System.EventHandler(this.AllExportNumbersButton_Click);
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 250);
            this.Controls.Add(this.AllExportNumbersButton);
            this.Controls.Add(this.ExportToAppleButton);
            this.Controls.Add(this.toNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fromNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportToAndroidButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Export";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export";
            this.Load += new System.EventHandler(this.Export_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fromNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
}
