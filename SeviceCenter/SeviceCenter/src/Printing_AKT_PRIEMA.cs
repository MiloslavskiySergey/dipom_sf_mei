// Printing_AKT_PRIEMA
using BarcodeLib;
using Microsoft.Win32;

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class Printing_AKT_PRIEMA : Form
{
	private Form1 mainForm;

	private string id_bd;

	private string valutaMain = "";

	private IContainer components = null;

	private WebBrowser webBrowser1;

	private PrintDocument printDocument1;

	private Button PrintButton;

	private PrintPreviewDialog printPreviewDialog1;

	private PrintDocument printDocument2;

	private Button ReAktor;

	private Button SetPrintButton;

	private Button button1;

	private string MonthInText(string month)
	{
		if (int.Parse(month) == 1)
		{
			return " Января ";
		}
		if (int.Parse(month) == 2)
		{
			return " Февраля ";
		}
		if (int.Parse(month) == 3)
		{
			return " Марта ";
		}
		if (int.Parse(month) == 4)
		{
			return " Апреля ";
		}
		if (int.Parse(month) == 5)
		{
			return " Мая ";
		}
		if (int.Parse(month) == 6)
		{
			return " Июня ";
		}
		if (int.Parse(month) == 7)
		{
			return " Июля ";
		}
		if (int.Parse(month) == 8)
		{
			return " Августа ";
		}
		if (int.Parse(month) == 9)
		{
			return " Сентября ";
		}
		if (int.Parse(month) == 10)
		{
			return " Октября ";
		}
		if (int.Parse(month) == 11)
		{
			return " Ноября ";
		}
		if (int.Parse(month) == 12)
		{
			return " Декабря ";
		}
		return "Месяц не указан";
	}

	public Printing_AKT_PRIEMA(DataTable dtabe, Form1 mf, string valuta)
	{
		valutaMain = valuta;
		InitializeComponent();
		mainForm = mf;
		if (dtabe.Rows.Count > 0)
		{
			DataTable dataTable = mainForm.basa.ClientsMapGiver(dtabe.Rows[0].ItemArray[29].ToString());
			int index = 0;
			string text = File.ReadAllText("Shablon_Act_Priema.htm");
			string text2 = DateTime.Parse(dtabe.Rows[index].ItemArray[1].ToString()).ToString("dd");
			string month = DateTime.Parse(dtabe.Rows[index].ItemArray[1].ToString()).ToString("MM");
			string text3 = DateTime.Parse(dtabe.Rows[index].ItemArray[1].ToString()).ToString("yyyy");
			text = text.Replace("NUMZAKAZPRINT", dtabe.Rows[index].ItemArray[0].ToString() + "   | Дата выдачи акта: " + text2 + MonthInText(month) + text3);
			id_bd = dtabe.Rows[index].ItemArray[0].ToString();
			if (dtabe.Rows[index].ItemArray[30].ToString().Length == 12)
			{
				BarcodeMacker(dtabe.Rows[index].ItemArray[30].ToString());
			}
			text = text.Replace("DATAPRIEMAPRINT", dtabe.Rows[index].ItemArray[1].ToString());
			text = text.Replace("FIOPRINT", FirstLetterToUpper(dataTable.Rows[0].ItemArray[1].ToString()));
			string text4 = dataTable.Rows[0].ItemArray[2].ToString();
			if (text4.Length == 5)
			{
				text4 = text4.Insert(2, " ");
			}
			else if (text4.Length == 6)
			{
				text4 = text4.Insert(3, " ");
			}
			else if (text4.Length == 7)
			{
				text4 = text4.Insert(3, " ");
				text4 = text4.Insert(6, " ");
			}
			else if (text4.Length > 9)
			{
				text4 = text4.Insert(1, " ");
				text4 = text4.Insert(5, " ");
				text4 = text4.Insert(9, " ");
			}
			text = text.Replace("PHONEPRINT", text4);
			string str = dtabe.Rows[index].ItemArray[7].ToString() + " ";
			str = str + dtabe.Rows[index].ItemArray[8].ToString() + " ";
			text = text.Replace("TYPEUSTRPRINT", FirstLetterToUpper(str) + " " + dtabe.Rows[index].ItemArray[9].ToString());
			text = text.Replace("SERIALNPIRNT", dtabe.Rows[index].ItemArray[10].ToString());
			text = text.Replace("KOMPLEKTNOSTPRINT", dtabe.Rows[index].ItemArray[12].ToString());
			text = text.Replace("VNESHVIPRINT", dtabe.Rows[index].ItemArray[11].ToString());
			text = text.Replace("NEISPRAVNOSTPRINT", dtabe.Rows[index].ItemArray[13].ToString());
			text = text.Replace("PREDOPLATAPRINT", dtabe.Rows[index].ItemArray[16].ToString() + " " + valutaMain);
			text = ((!(dtabe.Rows[index].ItemArray[15].ToString() != " ") || !(dtabe.Rows[index].ItemArray[15].ToString() != "0")) ? text.Replace("PREDSTOIMOSTPRINT", "Не оговорена") : text.Replace("PREDSTOIMOSTPRINT", dtabe.Rows[index].ItemArray[15].ToString() + " " + valutaMain)).Replace("FIRMNAMEPRINT", File.ReadAllText("Settings/Akts/FirmName.txt"));
			text = text.Replace("FIRMTELPRINT", File.ReadAllText("Settings/Akts/Phone.txt"));
			text = text.Replace("DANNIEOFIRMEPRINT", File.ReadAllText("Settings/Akts/DannieOFirme.txt"));
			text = text.Replace("URDANNIEPRINT", File.ReadAllText("Settings/Akts/URDannie.txt"));
			text = text.Replace("DOGOVORPRIEMPRINT", File.ReadAllText("Settings/Akts/DogovorTextPriem.txt"));
			File.WriteAllText("Act_priema", (!(dataTable.Rows[0].ItemArray[3].ToString() == "")) ? text.Replace("ADRESSCLIENTAIFNOTNULLPRINT", dataTable.Rows[0].ItemArray[3].ToString()) : text.Replace("ADRESSCLIENTAIFNOTNULLPRINT", "Не указан"));
			webBrowser1.Navigate(Application.StartupPath + "\\Act_priema");
		}
	}

	private void BarcodeMacker(string id_base)
	{
		Barcode barcode = new Barcode();
		barcode.Alignment = AlignmentPositions.CENTER;
		TYPE iType = TYPE.UPCA;
		barcode.Encode(iType, id_base, Color.Black, Color.White, TemporaryBase.barcodeW, TemporaryBase.barcodeH);
		SaveTypes fileType = SaveTypes.GIF;
		barcode.SaveImage("barcode.gif", fileType);
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

	private void PrintButton_Click(object sender, EventArgs e)
	{
		Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Internet Explorer\\PageSetup", "header", "");
		Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup", "footer", "");
		webBrowser1.ShowPrintDialog();
		mainForm.StatusStripLabel.Text = "Печать акта приёма " + id_bd;
	}

	private void ReAktor_Click(object sender, EventArgs e)
	{
		RedaktorAktov redaktorAktov = new RedaktorAktov(mainForm);
		redaktorAktov.Show();
	}

	private void SetPrintButton_Click(object sender, EventArgs e)
	{
		webBrowser1.ShowPageSetupDialog();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Internet Explorer\\PageSetup", "header", "");
		Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup", "footer", "");
		webBrowser1.ShowPrintPreviewDialog();
		mainForm.StatusStripLabel.Text = "Печать акта приёма " + id_bd;
	}

	private void Printing_AKT_PRIEMA_Load(object sender, EventArgs e)
	{
	}

	private void button2_Click(object sender, EventArgs e)
	{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Printing_AKT_PRIEMA));
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.PrintButton = new System.Windows.Forms.Button();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.printDocument2 = new System.Drawing.Printing.PrintDocument();
			this.ReAktor = new System.Windows.Forms.Button();
			this.SetPrintButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// webBrowser1
			// 
			this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.webBrowser1.Location = new System.Drawing.Point(0, 0);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(908, 590);
			this.webBrowser1.TabIndex = 3;
			// 
			// PrintButton
			// 
			this.PrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.PrintButton.Location = new System.Drawing.Point(917, 12);
			this.PrintButton.Name = "PrintButton";
			this.PrintButton.Size = new System.Drawing.Size(75, 44);
			this.PrintButton.TabIndex = 2;
			this.PrintButton.Text = "Печать";
			this.PrintButton.UseVisualStyleBackColor = true;
			this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Visible = false;
			// 
			// ReAktor
			// 
			this.ReAktor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ReAktor.Location = new System.Drawing.Point(917, 546);
			this.ReAktor.Name = "ReAktor";
			this.ReAktor.Size = new System.Drawing.Size(75, 44);
			this.ReAktor.TabIndex = 7;
			this.ReAktor.Text = "Редактор Актов";
			this.ReAktor.UseVisualStyleBackColor = true;
			this.ReAktor.Click += new System.EventHandler(this.ReAktor_Click);
			// 
			// SetPrintButton
			// 
			this.SetPrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SetPrintButton.Location = new System.Drawing.Point(917, 112);
			this.SetPrintButton.Name = "SetPrintButton";
			this.SetPrintButton.Size = new System.Drawing.Size(75, 23);
			this.SetPrintButton.TabIndex = 8;
			this.SetPrintButton.Text = "Настройка";
			this.SetPrintButton.UseVisualStyleBackColor = true;
			this.SetPrintButton.Click += new System.EventHandler(this.SetPrintButton_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(917, 62);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 44);
			this.button1.TabIndex = 9;
			this.button1.Text = "Предпросмотр";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Printing_AKT_PRIEMA
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1004, 590);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.SetPrintButton);
			this.Controls.Add(this.ReAktor);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.PrintButton);
			this.Name = "Printing_AKT_PRIEMA";
			this.Text = "Печатать акт приема";
			this.Load += new System.EventHandler(this.Printing_AKT_PRIEMA_Load);
			this.ResumeLayout(false);

	}
}
