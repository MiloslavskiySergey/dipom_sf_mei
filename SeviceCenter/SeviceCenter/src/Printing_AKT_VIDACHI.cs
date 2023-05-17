// Printing_AKT_VIDACHI
using BarcodeLib;
using Microsoft.Win32;

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class Printing_AKT_VIDACHI : Form
{
	private Form1 mainForm;

	private string id_bd;

	private string valutaMain = "";

	private IContainer components = null;

	private Button PrintButton;

	private WebBrowser webBrowser1;

	private Button ReAktor;

	private Button button1;

	private Button button2;

	public Printing_AKT_VIDACHI(DataTable dtabe, Form1 mf, string valuta)
	{
		valutaMain = valuta;
		InitializeComponent();
		mainForm = mf;
		if (dtabe.Rows.Count > 0)
		{
			DataTable dataTable = mainForm.basa.ClientsMapGiver(dtabe.Rows[0].ItemArray[29].ToString());
			int index = 0;
			string text = File.ReadAllText("Shablon_Act_vidachi.htm");
			text = text.Replace("NUMZAKAZPRINT", dtabe.Rows[index].ItemArray[0].ToString());
			id_bd = dtabe.Rows[index].ItemArray[0].ToString();
			if (dtabe.Rows[index].ItemArray[30].ToString().Length == 12)
			{
				BarcodeMacker(dtabe.Rows[index].ItemArray[30].ToString());
			}
			text = text.Replace("DATAPRIEMAPRINT", dtabe.Rows[index].ItemArray[1].ToString());
			text = text.Replace("FIOPRINT", FirstLetterToUpper(dataTable.Rows[0].ItemArray[1].ToString()));
			string text2 = dataTable.Rows[0].ItemArray[2].ToString();
			if (text2.Length == 5)
			{
				text2 = text2.Insert(2, " ");
			}
			else if (text2.Length == 6)
			{
				text2 = text2.Insert(3, " ");
			}
			else if (text2.Length == 7)
			{
				text2 = text2.Insert(3, " ");
				text2 = text2.Insert(6, " ");
			}
			else if (text2.Length > 9)
			{
				text2 = text2.Insert(1, " ");
				text2 = text2.Insert(5, " ");
				text2 = text2.Insert(9, " ");
			}
			text = text.Replace("PHONEPRINT", text2);
			string str = dtabe.Rows[index].ItemArray[7].ToString() + " ";
			str = str + dtabe.Rows[index].ItemArray[8].ToString() + " ";
			text = text.Replace("TYPEUSTRPRINT", FirstLetterToUpper(str) + " " + dtabe.Rows[index].ItemArray[9].ToString());
			text = text.Replace("SERIALNPIRNT", dtabe.Rows[index].ItemArray[10].ToString());
			text = text.Replace("KOMPLEKTNOSTPRINT", dtabe.Rows[index].ItemArray[12].ToString());
			text = text.Replace("VNESHVIPRINT", dtabe.Rows[index].ItemArray[11].ToString());
			text = text.Replace("NEISPRAVNOSTPRINT", dtabe.Rows[index].ItemArray[13].ToString());
			text = text.Replace("DATAVIDACHIPRINT", dtabe.Rows[index].ItemArray[2].ToString());
			text = text.Replace("GARANTYPRINT", dtabe.Rows[index].ItemArray[23].ToString());
			text = text.Replace("VIPRABOTPRINT", dtabe.Rows[index].ItemArray[22].ToString());
			try
			{
				text = ((int.Parse(dtabe.Rows[index].ItemArray[19].ToString()) != 0) ? text.Replace("SKIDKAPRINT", " Скидка: " + dtabe.Rows[index].ItemArray[19].ToString() + " " + valutaMain) : text.Replace("SKIDKAPRINT", ""));
				text = text.Replace("PRICEFULLPRINT", string.Format(arg0: (int.Parse(dtabe.Rows[index].ItemArray[18].ToString()) - int.Parse(dtabe.Rows[index].ItemArray[16].ToString())).ToString(), format: " Сумма предлоплаты: {1}<br>К оплате: {0} " + valutaMain, arg1: int.Parse(dtabe.Rows[index].ItemArray[16].ToString())));
			}
			catch
			{
			}
			text = text.Replace("FIRMNAMEPRINT", File.ReadAllText("Settings/Akts/FirmName.txt"));
			text = text.Replace("FIRMTELPRINT", File.ReadAllText("Settings/Akts/Phone.txt"));
			text = text.Replace("DANNIEOFIRMEPRINT", File.ReadAllText("Settings/Akts/DannieOFirme.txt"));
			text = text.Replace("URDANNIEPRINT", File.ReadAllText("Settings/Akts/URDannie.txt"));
			text = text.Replace("DOGOVORVIDACHAPRINT", File.ReadAllText("Settings/Akts/DogovorTextVidacha.txt"));
			File.WriteAllText("Act_vidachi", text);
			webBrowser1.Navigate(Application.StartupPath + "\\Act_vidachi");
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

	private void PrintButton_Click(object sender, EventArgs e)
	{
		Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Internet Explorer\\PageSetup", "header", "");
		Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup", "footer", "");
		webBrowser1.ShowPrintDialog();
		mainForm.StatusStripLabel.Text = "Печать акта выдачи " + id_bd;
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

	private void ReAktor_Click(object sender, EventArgs e)
	{
		RedaktorAktov redaktorAktov = new RedaktorAktov(mainForm);
		redaktorAktov.Show();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		webBrowser1.ShowPageSetupDialog();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Internet Explorer\\PageSetup", "header", "");
		Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Internet Explorer\\PageSetup", "footer", "");
		webBrowser1.ShowPrintPreviewDialog();
		mainForm.StatusStripLabel.Text = "Печать акта выдачи " + id_bd;
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
            this.PrintButton = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.ReAktor = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintButton.Location = new System.Drawing.Point(1237, 0);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(100, 54);
            this.PrintButton.TabIndex = 3;
            this.PrintButton.Text = "Печать";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1211, 697);
            this.webBrowser1.TabIndex = 2;
            // 
            // ReAktor
            // 
            this.ReAktor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReAktor.Location = new System.Drawing.Point(1237, 642);
            this.ReAktor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReAktor.Name = "ReAktor";
            this.ReAktor.Size = new System.Drawing.Size(100, 54);
            this.ReAktor.TabIndex = 8;
            this.ReAktor.Text = "Редактор Актов";
            this.ReAktor.UseVisualStyleBackColor = true;
            this.ReAktor.Click += new System.EventHandler(this.ReAktor_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1237, 123);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Настройка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1237, 62);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 54);
            this.button2.TabIndex = 10;
            this.button2.Text = "Предпросмотр";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Printing_AKT_VIDACHI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 697);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ReAktor);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.webBrowser1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Printing_AKT_VIDACHI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Печатать акт выдачи";
            this.ResumeLayout(false);

	}
}
