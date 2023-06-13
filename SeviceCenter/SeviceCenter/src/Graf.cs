// Graf
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

public class Graf : Form
{
	private MainForm mainForm;

	private List<string> models = new List<string>();

	private List<string> modelsAndCount = new List<string>();

	private IContainer components = null;

	private Label label11;

	private Label label10;

	private Label label9;

	private Label label8;

	private Label label7;

	private DateTimePicker dateTimePicker2;

	private DateTimePicker dateTimePicker1;

	private Label label6;

	private Label label5;

	private Button button1;

	private Label label4;

	private ComboBox comboBox1;

	private Label label3;

	private Label label2;

	private Label label1;

	private Chart chart1;

	private ComboBox ServiceAdressComboBox;

	private Label label12;

	private Button ReportExcelButton;

	public ComboBox BrandComboBox;

	public ComboBox What_remont_combo_box;

	public Label label14;

	public Label label15;

	private Button AboutUsStatButton;

	public Graf(MainForm mf)
	{
		mainForm = mf;
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			label5.Text = "Выручка: ";
			label6.Text = "Затраты: ";
			label7.Text = "Итого: ";
			label8.Text = "Средняя выручка за 1 заказ: ";
			label9.Text = "Средняя скидка за 1 заказ: ";
			label10.Text = "Всего заказов за выбранный период: ";
			label11.Text = "Из них без ремонта: ";
			new List<VirtualClient>();
			List<VirtualClient> list = mainForm.basa.BdReadGrafList(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), comboBox1.Text, ServiceAdressComboBox.Text, What_remont_combo_box.Text, BrandComboBox.Text);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			if (list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					num += int.Parse(list[i].Okonchatelnaya_stoimost_remonta);
					num2 += int.Parse(list[i].Zatrati);
					num3 += int.Parse(list[i].Skidka);
					if (list[i].Vipolnenie_raboti.ToUpper() == "Без ремонта,".ToUpper())
					{
						num4++;
					}
					if (list[i].Vipolnenie_raboti.ToUpper() == "Без ремонта".ToUpper())
					{
						num4++;
					}
				}
			}
			if (list.Count > 0)
			{
				label5.Text = "Выручка: " + num + " " + TemporaryBase.valuta;
				label6.Text = "Затраты: " + num2 + " " + TemporaryBase.valuta;
				label7.Text = "Итого: " + (num - num2) + " " + TemporaryBase.valuta;
				label8.Text = "Средняя выручка за 1 заказ: " + (num - num2) / list.Count + " " + TemporaryBase.valuta;
				label9.Text = "Средняя скидка за 1 заказ: " + num3 / list.Count + " " + TemporaryBase.valuta;
				label10.Text = "Всего заказов за выбранный период: " + list.Count;
				label11.Text = "Из них без ремонта: " + num4;
				string text = string.Format(comboBox1.Text + " " + ServiceAdressComboBox.Text + " " + What_remont_combo_box.Text + " " + BrandComboBox.Text);
				if (text.Trim() == "")
				{
					text = "Все";
				}
				chart1.Series["Выручка"].Points.AddXY(text, num);
				chart1.Series["Затраты"].Points.AddXY(text, num2);
				chart1.Series["Итого"].Points.AddXY(text, num - num2);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void Graf_Load(object sender, EventArgs e)
	{
		ComboboxMaker("settings/masters.txt", comboBox1);
		ComboboxMaker("settings/AdresSC.txt", ServiceAdressComboBox);
		ComboboxMaker("settings/ustrojstvo.txt", What_remont_combo_box);
		ComboboxMaker("settings/brands.txt", BrandComboBox);
		ToolTip toolTip = new ToolTip();
		toolTip.SetToolTip(comboBox1, "Если хотите искать по всем мастреам, выберите пустную строку");
		toolTip.SetToolTip(ServiceAdressComboBox, "Если хотите искать по всем СЦ, выберите пустую строку");
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

	private void ReportExcelButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Отчёт будет сохранён в папке reports, после чего откроется окно с этой папкой", "Отчёт", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			try
			{
				label5.Text = "Выручка: ";
				label6.Text = "Затраты: ";
				label7.Text = "Итого: ";
				label8.Text = "Средняя выручка за 1 заказ: ";
				label9.Text = "Средняя скидка за 1 заказ: ";
				label10.Text = "Всего заказов за выбранный период: ";
				label11.Text = "Из них без ремонта: ";
				new List<VirtualClient>();
				List<VirtualClient> list = mainForm.basa.BdReadGrafList(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), comboBox1.Text, ServiceAdressComboBox.Text, What_remont_combo_box.Text, BrandComboBox.Text);
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				if (list.Count > 0)
				{
					using (ExcelPackage excelPackage = new ExcelPackage())
					{
						excelPackage.Workbook.Properties.Author = "Scrypto";
						excelPackage.Workbook.Properties.Title = "Отчёт";
						excelPackage.Workbook.Properties.Company = "MyWork2";
						ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Прайс-лист");
						int num5 = 1;
						int num6 = 1;
						excelWorksheet.Cells[num5, num6].Value = "Номер заказа";
						excelWorksheet.Cells[num5, num6 + 1].Value = "ФИО клиента";
						excelWorksheet.Cells[num5, num6 + 2].Value = "Тип устройства";
						excelWorksheet.Cells[num5, num6 + 3].Value = "Фирма устройства";
						excelWorksheet.Cells[num5, num6 + 4].Value = "Модель";
						excelWorksheet.Cells[num5, num6 + 5].Value = "Неисправность";
						excelWorksheet.Cells[num5, num6 + 6].Value = "Выполненные работы";
						excelWorksheet.Cells[num5, num6 + 7].Value = "Стоимость ремонта";
						excelWorksheet.Cells[num5, num6 + 8].Value = "Мастер";
						excelWorksheet.Cells[num5, num6 + 9].Value = "Телефон клиента";
						excelWorksheet.Cells[num5, num6 + 10].Value = "Дата приёма";
						excelWorksheet.Cells[num5, num6 + 11].Value = "Дата выдачи";
						excelWorksheet.Cells[num5, num6 + 12].Value = "Как долго забирали";
						excelWorksheet.Cells[num5, num6 + 13].Value = "Адрес СЦ";
						excelWorksheet.Cells[num5, num6 + 14].Value = "Откуда узнали о нас";
						num5++;
						for (int i = 0; i < list.Count; i++)
						{
							num += int.Parse(list[i].Okonchatelnaya_stoimost_remonta);
							num2 += int.Parse(list[i].Zatrati);
							num3 += int.Parse(list[i].Skidka);
							if (list[i].Vipolnenie_raboti.ToUpper() == "Без ремонта,".ToUpper())
							{
								num4++;
							}
							if (list[i].Vipolnenie_raboti.ToUpper() == "Без ремонта".ToUpper())
							{
								num4++;
							}
							excelWorksheet.Cells[num5, num6].Value = list[i].Id;
							excelWorksheet.Cells[num5, num6 + 1].Value = list[i].Surname;
							excelWorksheet.Cells[num5, num6 + 2].Value = list[i].WhatRemont;
							excelWorksheet.Cells[num5, num6 + 3].Value = list[i].Brand;
							excelWorksheet.Cells[num5, num6 + 4].Value = list[i].Model;
							excelWorksheet.Cells[num5, num6 + 5].Value = list[i].Polomka;
							excelWorksheet.Cells[num5, num6 + 6].Value = list[i].Vipolnenie_raboti;
							excelWorksheet.Cells[num5, num6 + 7].Value = list[i].Okonchatelnaya_stoimost_remonta;
							excelWorksheet.Cells[num5, num6 + 8].Value = list[i].Master;
							excelWorksheet.Cells[num5, num6 + 9].Value = list[i].Phone;
							excelWorksheet.Cells[num5, num6 + 10].Value = list[i].Data_priema;
							excelWorksheet.Cells[num5, num6 + 11].Value = list[i].Data_vidachi;
							excelWorksheet.Cells[num5, num6 + 12].Value = $"{(DateTime.Parse(list[i].Data_vidachi) - DateTime.Parse(list[i].Data_priema)).TotalDays:0}";
							excelWorksheet.Cells[num5, num6 + 13].Value = list[i].AdressSC;
							excelWorksheet.Cells[num5, num6 + 14].Value = list[i].AboutUs;
							num5++;
						}
						using (ExcelRange excelRange = excelWorksheet.Cells[excelWorksheet.Dimension.Address])
						{
							excelRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
							excelRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
							excelRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
							excelRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
							excelRange.AutoFitColumns();
						}
						byte[] asByteArray = excelPackage.GetAsByteArray();
						string text = string.Format("reports/Отчёт от {0} до {1} по мастеру {2}.xlsx", dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), (comboBox1.Text == "") ? "Все" : comboBox1.Text);
						File.WriteAllBytes(text, asByteArray);
						Process process = new Process();
						ProcessStartInfo processStartInfo = new ProcessStartInfo();
						string str = text.Replace("/", "\\");
						processStartInfo.CreateNoWindow = true;
						processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
						processStartInfo.FileName = "explorer";
						processStartInfo.Arguments = "/n, /select, " + str;
						process.StartInfo = processStartInfo;
						process.Start();
					}
					if (list.Count > 0)
					{
						label5.Text = "Выручка: " + num + " " + TemporaryBase.valuta;
						label6.Text = "Затраты: " + num2 + " " + TemporaryBase.valuta;
						label7.Text = "Итого: " + (num - num2) + " " + TemporaryBase.valuta;
						label8.Text = "Средняя выручка за 1 заказ: " + (num - num2) / list.Count + " " + TemporaryBase.valuta;
						label9.Text = "Средняя скидка за 1 заказ: " + num3 / list.Count + " " + TemporaryBase.valuta;
						label10.Text = "Всего заказов за выбранный период: " + list.Count;
						label11.Text = "Из них без ремонта: " + num4;
						string xValue = "Все";
						if (comboBox1.Text != "")
						{
							xValue = comboBox1.Text;
						}
						chart1.Series["Выручка"].Points.AddXY(xValue, num);
						chart1.Series["Затраты"].Points.AddXY(xValue, num2);
						chart1.Series["Итого"].Points.AddXY(xValue, num - num2);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	}

	private void AboutUsStatButton_Click(object sender, EventArgs e)
	{
		try
		{
			new List<VirtualClient>();
			List<VirtualClient> list = mainForm.basa.BdReadGrafList(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), comboBox1.Text, ServiceAdressComboBox.Text, What_remont_combo_box.Text, BrandComboBox.Text);
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			if (list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].AboutUs != "")
					{
						list2.Add(list[i].AboutUs);
					}
				}
				for (int j = 0; j < list2.Count; j++)
				{
					bool flag = true;
					if (list3.Count == 0)
					{
						list3.Add(list2[j]);
					}
					for (int k = 0; k < list3.Count; k++)
					{
						if (list3[k] == list2[j])
						{
							flag = false;
						}
					}
					if (flag)
					{
						list3.Add(list2[j]);
					}
				}
			}
			int[] array = new int[list3.Count];
			for (int l = 0; l < list3.Count; l++)
			{
				for (int m = 0; m < list2.Count; m++)
				{
					if (list3[l] == list2[m])
					{
						array[l]++;
					}
				}
			}
			string text = "";
			for (int n = 0; n < list3.Count; n++)
			{
				text = text + list3[n] + ": " + array[n].ToString() + Environment.NewLine;
			}
			if (text != "")
			{
				MessageBox.Show(text);
			}
			else
			{
				MessageBox.Show("За данные период нечего покаызвать");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ServiceAdressComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ReportExcelButton = new System.Windows.Forms.Button();
            this.BrandComboBox = new System.Windows.Forms.ComboBox();
            this.What_remont_combo_box = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.AboutUsStatButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(548, 254);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 16);
            this.label11.TabIndex = 34;
            this.label11.Text = "Из них без ремонта:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(547, 224);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(256, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "Всего заказов за выбранный период: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(547, 193);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Средняя скидка за 1 заказ: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(547, 160);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 16);
            this.label8.TabIndex = 31;
            this.label8.Text = "Средняя выручка за 1 заказ: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(547, 107);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Итого:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(312, 52);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(217, 22);
            this.dateTimePicker2.TabIndex = 29;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(9, 52);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(217, 22);
            this.dateTimePicker1.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(547, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Затраты: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(547, 41);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Выручка: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 210);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(520, 31);
            this.button1.TabIndex = 25;
            this.button1.Text = "Посчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Мастер";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            ""});
            this.comboBox1.Location = new System.Drawing.Point(9, 107);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(217, 24);
            this.comboBox1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "по";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "с";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Выберите период:";
            // 
            // chart1
            // 
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(9, 367);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Итого";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Выручка";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Затраты";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(899, 369);
            this.chart1.TabIndex = 35;
            this.chart1.Text = "chart1";
            // 
            // ServiceAdressComboBox
            // 
            this.ServiceAdressComboBox.FormattingEnabled = true;
            this.ServiceAdressComboBox.Items.AddRange(new object[] {
            ""});
            this.ServiceAdressComboBox.Location = new System.Drawing.Point(9, 160);
            this.ServiceAdressComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ServiceAdressComboBox.Name = "ServiceAdressComboBox";
            this.ServiceAdressComboBox.Size = new System.Drawing.Size(217, 24);
            this.ServiceAdressComboBox.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(76, 137);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 16);
            this.label12.TabIndex = 37;
            this.label12.Text = "Адресс СЦ";
            // 
            // ReportExcelButton
            // 
            this.ReportExcelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ReportExcelButton.Location = new System.Drawing.Point(9, 254);
            this.ReportExcelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReportExcelButton.Name = "ReportExcelButton";
            this.ReportExcelButton.Size = new System.Drawing.Size(520, 28);
            this.ReportExcelButton.TabIndex = 38;
            this.ReportExcelButton.Text = "Посчитать и сделать отчёт";
            this.ReportExcelButton.UseVisualStyleBackColor = true;
            this.ReportExcelButton.Click += new System.EventHandler(this.ReportExcelButton_Click);
            // 
            // BrandComboBox
            // 
            this.BrandComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "4PARTS",
            "ACER",
            "ADVOCAM",
            "AMD",
            "APACER",
            "APPLE",
            "ASUS",
            "ASX",
            "BBK",
            "BEELINE",
            "BEKO",
            "BENQ",
            "BLACKBERRY",
            "BLACKVIEW",
            "BQ",
            "COMPAQ",
            "COOLER MASTER",
            "CREATIVE",
            "DAEWOO",
            "DELL",
            "DEXP",
            "DIGMA",
            "DNS",
            "ELENBERG",
            "EMACHINES",
            "EPLUTUS",
            "EPSON",
            "EPSON",
            "ETULINE",
            "EXPLAY",
            "FLY",
            "GARMIN",
            "GIGABYTE",
            "HAIER",
            "HEWLETT PACKARD",
            "HIGHSCREEN",
            "HTC",
            "HUAWEI",
            "ICONBIT",
            "IMPRESSION",
            "INTEGO",
            "INVIN",
            "INWIN",
            "IRBIS",
            "IRU",
            "IRULU",
            "JINGA",
            "JVC",
            "LENOVO",
            "LENTEL",
            "LG",
            "MAXVI",
            "MEGAFON",
            "MERSEDES-BENZ",
            "MI",
            "MICROLAB",
            "MICROMAX",
            "MICROSOFT",
            "MSI",
            "MYSTERY",
            "NOKIA",
            "ORIEL",
            "OUSTERS",
            "PACKARD BELL",
            "PANASONIC",
            "PHILIPS",
            "POLAR",
            "PRESTIGIO",
            "QUMO",
            "REKAM",
            "RITMIX",
            "SAMSUNG",
            "SATELLITE",
            "SC",
            "SHARP+Environment.NewLineDELTA",
            "SIEMENS",
            "SILICON POWER",
            "SMARTBUY",
            "SONY",
            "STARK",
            "STRIKE",
            "SUPRA",
            "TESLA",
            "TESLER",
            "TEXET",
            "TEXET",
            "THOMPSON",
            "TOSHIBA",
            "TREELOGIC",
            "TURBOPAD",
            "TWOCHI",
            "UNITED",
            "VALEO",
            "WEXLER",
            "XEROX",
            "XIAOMI",
            "YOTAPHONE",
            "ZIFRO",
            "ZTE",
            "БЕЗ МАРКИ",
            "БИЛАЙН",
            "КЕЙ",
            "МТС",
            "СПЛАЙН"});
            this.BrandComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.BrandComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.BrandComboBox.FormattingEnabled = true;
            this.BrandComboBox.Location = new System.Drawing.Point(311, 160);
            this.BrandComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrandComboBox.Name = "BrandComboBox";
            this.BrandComboBox.Size = new System.Drawing.Size(217, 24);
            this.BrandComboBox.TabIndex = 135;
            // 
            // What_remont_combo_box
            // 
            this.What_remont_combo_box.AutoCompleteCustomSource.AddRange(new string[] {
            "DVD ПРИСТАВКА",
            "FLASH НАКОПИТЕЛЬ",
            "MACBOOK",
            "MP3 ПЛЕЕР",
            "TV",
            "АВТОМАГНИТОЛА",
            "АККУМУЛЯТОРНАЯ БАТАРЕЯ",
            "БЛОК ПИТАНИЯ",
            "ВИДЕОКАРТА",
            "ВИДЕОРЕГИСТРАТОР",
            "ДЖОЙСТИК",
            "ДЫМОВАЯ МАШИНА",
            "ЖЕСТКИЙ ДИСК",
            "ЗАРЯДНОЕ УСТРОЙСТВО",
            "ИГРОВАЯ КОНСОЛЬ",
            "МАГНИТОФОН",
            "МИКРОВОЛНОВАЯ ПЕЧЬ",
            "МОНИТОР",
            "МОНИТОР",
            "МОНОБЛОК",
            "МУЗЫКАЛЬНЫЙ ЦЕНТР",
            "МФУ",
            "НАВИГАТОР",
            "НАУШНИКИ",
            "НЕТБУК",
            "НЕТБУК",
            "НОУТБУК",
            "ПЛАНШЕТ",
            "ПЛАТА",
            "ПОРТАТИВНАЯ КОЛОНКА",
            "ПРИНТЕР",
            "ПРОЕКТОР",
            "РАДИОПРИЕМНИК",
            "РАДИОУПРАВЛЯЕМЫЙ ВЕРТОЛЕТ",
            "РОУТЕР",
            "СИСТЕМНЫЙ БЛОК",
            "ТЕЛЕВИЗЕОННАЯ ПРИСТАВКА",
            "ТЕЛЕФОН",
            "УСИЛИТЕЛЬ",
            "ФОТОРАМКА",
            "ЭЛЕКТРОННАЯ КНИГА"});
            this.What_remont_combo_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.What_remont_combo_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.What_remont_combo_box.FormattingEnabled = true;
            this.What_remont_combo_box.Location = new System.Drawing.Point(311, 107);
            this.What_remont_combo_box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.What_remont_combo_box.Name = "What_remont_combo_box";
            this.What_remont_combo_box.Size = new System.Drawing.Size(217, 24);
            this.What_remont_combo_box.TabIndex = 134;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(368, 85);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 17);
            this.label14.TabIndex = 137;
            this.label14.Text = "Тип устройства";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(355, 137);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 17);
            this.label15.TabIndex = 136;
            this.label15.Text = "Название бренда";
            // 
            // AboutUsStatButton
            // 
            this.AboutUsStatButton.Location = new System.Drawing.Point(11, 294);
            this.AboutUsStatButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AboutUsStatButton.Name = "AboutUsStatButton";
            this.AboutUsStatButton.Size = new System.Drawing.Size(520, 31);
            this.AboutUsStatButton.TabIndex = 138;
            this.AboutUsStatButton.Text = "Показать статистику по полю \"Откуда о нас узнали\"";
            this.AboutUsStatButton.UseVisualStyleBackColor = true;
            this.AboutUsStatButton.Click += new System.EventHandler(this.AboutUsStatButton_Click);
            // 
            // Graf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 751);
            this.Controls.Add(this.AboutUsStatButton);
            this.Controls.Add(this.BrandComboBox);
            this.Controls.Add(this.What_remont_combo_box);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ReportExcelButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ServiceAdressComboBox);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Graf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "График";
            this.Load += new System.EventHandler(this.Graf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
}
