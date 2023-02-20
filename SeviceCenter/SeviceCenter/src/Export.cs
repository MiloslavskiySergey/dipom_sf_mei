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

	private Form1 MainForm;

	private IContainer components = null;

	private Button ExportToAndroidButton;

	private Label label1;

	private Label label2;

	private NumericUpDown fromNumericUpDown;

	private Label label3;

	private NumericUpDown toNumericUpDown;

	private Button ExportToAppleButton;

	private Button AllExportNumbersButton;

	public Export(Form1 fm1)
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
		ExportToAndroidButton = new System.Windows.Forms.Button();
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		fromNumericUpDown = new System.Windows.Forms.NumericUpDown();
		label3 = new System.Windows.Forms.Label();
		toNumericUpDown = new System.Windows.Forms.NumericUpDown();
		ExportToAppleButton = new System.Windows.Forms.Button();
		AllExportNumbersButton = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)fromNumericUpDown).BeginInit();
		((System.ComponentModel.ISupportInitialize)toNumericUpDown).BeginInit();
		SuspendLayout();
		ExportToAndroidButton.Location = new System.Drawing.Point(39, 168);
		ExportToAndroidButton.Name = "ExportToAndroidButton";
		ExportToAndroidButton.Size = new System.Drawing.Size(417, 23);
		ExportToAndroidButton.TabIndex = 0;
		ExportToAndroidButton.Text = "Для переноса в csv формат";
		ExportToAndroidButton.UseVisualStyleBackColor = true;
		ExportToAndroidButton.Click += new System.EventHandler(ExportToAndroidButton_Click);
		label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label1.Location = new System.Drawing.Point(12, 9);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(486, 38);
		label1.TabIndex = 1;
		label1.Text = "Пока еще вы не экспортировали номера телефонов";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(36, 66);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(259, 13);
		label2.TabIndex = 2;
		label2.Text = "Экспортировать телефонные номера клиентов с \r\n";
		fromNumericUpDown.Location = new System.Drawing.Point(301, 64);
		fromNumericUpDown.Maximum = new decimal(new int[4]
		{
			9999999,
			0,
			0,
			0
		});
		fromNumericUpDown.Minimum = new decimal(new int[4]
		{
			1,
			0,
			0,
			0
		});
		fromNumericUpDown.Name = "fromNumericUpDown";
		fromNumericUpDown.Size = new System.Drawing.Size(120, 20);
		fromNumericUpDown.TabIndex = 3;
		fromNumericUpDown.Value = new decimal(new int[4]
		{
			1,
			0,
			0,
			0
		});
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(273, 95);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(19, 13);
		label3.TabIndex = 4;
		label3.Text = "по";
		toNumericUpDown.Location = new System.Drawing.Point(301, 93);
		toNumericUpDown.Maximum = new decimal(new int[4]
		{
			9999999,
			0,
			0,
			0
		});
		toNumericUpDown.Minimum = new decimal(new int[4]
		{
			1,
			0,
			0,
			0
		});
		toNumericUpDown.Name = "toNumericUpDown";
		toNumericUpDown.Size = new System.Drawing.Size(120, 20);
		toNumericUpDown.TabIndex = 5;
		toNumericUpDown.Value = new decimal(new int[4]
		{
			1,
			0,
			0,
			0
		});
		ExportToAppleButton.Location = new System.Drawing.Point(39, 139);
		ExportToAppleButton.Name = "ExportToAppleButton";
		ExportToAppleButton.Size = new System.Drawing.Size(417, 23);
		ExportToAppleButton.TabIndex = 6;
		ExportToAppleButton.Text = "Для переноса в Android/Iphone/Vcard";
		ExportToAppleButton.UseVisualStyleBackColor = true;
		ExportToAppleButton.Click += new System.EventHandler(ExportToAppleButton_Click);
		AllExportNumbersButton.Location = new System.Drawing.Point(427, 63);
		AllExportNumbersButton.Name = "AllExportNumbersButton";
		AllExportNumbersButton.Size = new System.Drawing.Size(36, 51);
		AllExportNumbersButton.TabIndex = 7;
		AllExportNumbersButton.Text = "Все";
		AllExportNumbersButton.UseVisualStyleBackColor = true;
		AllExportNumbersButton.Click += new System.EventHandler(AllExportNumbersButton_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(510, 203);
		base.Controls.Add(AllExportNumbersButton);
		base.Controls.Add(ExportToAppleButton);
		base.Controls.Add(toNumericUpDown);
		base.Controls.Add(label3);
		base.Controls.Add(fromNumericUpDown);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(ExportToAndroidButton);
		base.Name = "Export";
		Text = "Export";
		base.Load += new System.EventHandler(Export_Load);
		((System.ComponentModel.ISupportInitialize)fromNumericUpDown).EndInit();
		((System.ComponentModel.ISupportInitialize)toNumericUpDown).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
