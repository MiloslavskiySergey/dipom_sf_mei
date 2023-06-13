// RedaktorAktov

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class RedaktorAktov : Form
{
	private MainForm mainForm;

	private HtmlWorker htmw1 = new HtmlWorker();

	private HtmlWorker htmw2 = new HtmlWorker();

	private IContainer components = null;

	private TabControl tabControl1;

	private TabPage AktPriema;

	private Label label5;

	private TabPage AktVidachi;

	private Label label6;

	private TextBox DannieURLitsaTextBox;

	private Label label4;

	private TextBox PhoneNumberTextBox;

	private Label label3;

	private TextBox DannieOFirmeTextBox;

	private Label label2;

	private Label label1;

	private TextBox FirmNameTextBox;

	private Button SaveButton;

	private Label label7;

	private RichTextBox RulesAktPriema;

	private RichTextBox RulesAktVidachi;

	private Button AktVidachiButton;

	private Button AktPiemaButton;

	public RedaktorAktov(MainForm fm1)
	{
		mainForm = fm1;
		InitializeComponent();
	}

	private void SaveButton_Click(object sender, EventArgs e)
	{
		try
		{
			if (MessageBox.Show("Сохранить все изменения в актах выдачи и приёма?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				File.WriteAllText("Settings/Akts/FirmName.txt", FirmNameTextBox.Text);
				File.WriteAllText("Settings/Akts/Phone.txt", PhoneNumberTextBox.Text);
				File.WriteAllText("Settings/Akts/DannieOFirme.txt", DannieOFirmeTextBox.Text);
				File.WriteAllText("Settings/Akts/URDannie.txt", DannieURLitsaTextBox.Text);
				File.WriteAllText("Settings/Akts/DogovorTextPriem.txt", RulesAktPriema.Text);
				File.WriteAllText("Settings/Akts/DogovorTextVidacha.txt", RulesAktVidachi.Text);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void RedaktorAktov_Load(object sender, EventArgs e)
	{
		try
		{
			FirmNameTextBox.Text = File.ReadAllText("Settings/Akts/FirmName.txt");
			PhoneNumberTextBox.Text = File.ReadAllText("Settings/Akts/Phone.txt");
			DannieOFirmeTextBox.Text = File.ReadAllText("Settings/Akts/DannieOFirme.txt");
			DannieURLitsaTextBox.Text = File.ReadAllText("Settings/Akts/URDannie.txt");
			RulesAktPriema.Text = File.ReadAllText("Settings/Akts/DogovorTextPriem.txt");
			RulesAktVidachi.Text = File.ReadAllText("Settings/Akts/DogovorTextVidacha.txt");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void RulesAktPriema_TextChanged(object sender, EventArgs e)
	{
	}

	private void AktPiemaButton_Click(object sender, EventArgs e)
	{

			if (mainForm.basa.BdReadAdvertsDataTop() > 0)
			{
				Printing_AKT_PRIEMA printing_AKT_PRIEMA = new Printing_AKT_PRIEMA(mainForm.basa.BdReadOneEditor(mainForm.basa.BdReadAdvertsDataTop().ToString()), mainForm, TemporaryBase.valuta);
				printing_AKT_PRIEMA.Show();
			}
			else
			{
				MessageBox.Show("Нужна хотябы одна запись в базе, чтобы посмотреть акты");
			}

	}

	private void AktVidachiButton_Click(object sender, EventArgs e)
	{

			if (mainForm.basa.BdReadAdvertsDataTop() > 0)
			{
				Printing_AKT_VIDACHI printing_AKT_VIDACHI = new Printing_AKT_VIDACHI(mainForm.basa.BdReadOneEditor(mainForm.basa.BdReadAdvertsDataTop().ToString()), mainForm, TemporaryBase.valuta);
				printing_AKT_VIDACHI.Show();
			}
			else
			{
				MessageBox.Show("Нужна хотябы одна запись в базе, чтобы посмотреть акты");
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AktPriema = new System.Windows.Forms.TabPage();
            this.RulesAktPriema = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AktVidachi = new System.Windows.Forms.TabPage();
            this.RulesAktVidachi = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DannieURLitsaTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DannieOFirmeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FirmNameTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.AktVidachiButton = new System.Windows.Forms.Button();
            this.AktPiemaButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.AktPriema.SuspendLayout();
            this.AktVidachi.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.AktPriema);
            this.tabControl1.Controls.Add(this.AktVidachi);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(620, 714);
            this.tabControl1.TabIndex = 0;
            // 
            // AktPriema
            // 
            this.AktPriema.Controls.Add(this.RulesAktPriema);
            this.AktPriema.Controls.Add(this.label5);
            this.AktPriema.Location = new System.Drawing.Point(4, 25);
            this.AktPriema.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AktPriema.Name = "AktPriema";
            this.AktPriema.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AktPriema.Size = new System.Drawing.Size(612, 685);
            this.AktPriema.TabIndex = 0;
            this.AktPriema.Text = "Акт приёма";
            this.AktPriema.UseVisualStyleBackColor = true;
            // 
            // RulesAktPriema
            // 
            this.RulesAktPriema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RulesAktPriema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RulesAktPriema.Location = new System.Drawing.Point(12, 27);
            this.RulesAktPriema.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RulesAktPriema.Name = "RulesAktPriema";
            this.RulesAktPriema.Size = new System.Drawing.Size(584, 644);
            this.RulesAktPriema.TabIndex = 2;
            this.RulesAktPriema.Text = "";
            this.RulesAktPriema.TextChanged += new System.EventHandler(this.RulesAktPriema_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Условия ремонта";
            // 
            // AktVidachi
            // 
            this.AktVidachi.Controls.Add(this.RulesAktVidachi);
            this.AktVidachi.Controls.Add(this.label6);
            this.AktVidachi.Location = new System.Drawing.Point(4, 25);
            this.AktVidachi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AktVidachi.Name = "AktVidachi";
            this.AktVidachi.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AktVidachi.Size = new System.Drawing.Size(612, 685);
            this.AktVidachi.TabIndex = 1;
            this.AktVidachi.Text = "Акт выдачи";
            this.AktVidachi.UseVisualStyleBackColor = true;
            // 
            // RulesAktVidachi
            // 
            this.RulesAktVidachi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RulesAktVidachi.Location = new System.Drawing.Point(12, 27);
            this.RulesAktVidachi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RulesAktVidachi.Name = "RulesAktVidachi";
            this.RulesAktVidachi.Size = new System.Drawing.Size(584, 644);
            this.RulesAktVidachi.TabIndex = 4;
            this.RulesAktVidachi.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Условия ремонта";
            // 
            // DannieURLitsaTextBox
            // 
            this.DannieURLitsaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DannieURLitsaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DannieURLitsaTextBox.Location = new System.Drawing.Point(657, 287);
            this.DannieURLitsaTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DannieURLitsaTextBox.Multiline = true;
            this.DannieURLitsaTextBox.Name = "DannieURLitsaTextBox";
            this.DannieURLitsaTextBox.Size = new System.Drawing.Size(456, 100);
            this.DannieURLitsaTextBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(655, 267);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Юридические данные ( ИП. ОГРНИП ИНН)";
            // 
            // PhoneNumberTextBox
            // 
            this.PhoneNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PhoneNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneNumberTextBox.Location = new System.Drawing.Point(659, 116);
            this.PhoneNumberTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            this.PhoneNumberTextBox.Size = new System.Drawing.Size(456, 24);
            this.PhoneNumberTextBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(655, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Номер телефона";
            // 
            // DannieOFirmeTextBox
            // 
            this.DannieOFirmeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DannieOFirmeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DannieOFirmeTextBox.Location = new System.Drawing.Point(659, 164);
            this.DannieOFirmeTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DannieOFirmeTextBox.Multiline = true;
            this.DannieOFirmeTextBox.Name = "DannieOFirmeTextBox";
            this.DannieOFirmeTextBox.Size = new System.Drawing.Size(456, 99);
            this.DannieOFirmeTextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(655, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Данные о фирме (режим работы и место)";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(655, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Введите название вашей фирмы";
            // 
            // FirmNameTextBox
            // 
            this.FirmNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FirmNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirmNameTextBox.Location = new System.Drawing.Point(659, 41);
            this.FirmNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FirmNameTextBox.Multiline = true;
            this.FirmNameTextBox.Name = "FirmNameTextBox";
            this.FirmNameTextBox.Size = new System.Drawing.Size(456, 51);
            this.FirmNameTextBox.TabIndex = 8;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(657, 629);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(459, 28);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(657, 401);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(457, 221);
            this.label7.TabIndex = 17;
            this.label7.Text = "Редактор актов";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // AktVidachiButton
            // 
            this.AktVidachiButton.Location = new System.Drawing.Point(657, 699);
            this.AktVidachiButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AktVidachiButton.Name = "AktVidachiButton";
            this.AktVidachiButton.Size = new System.Drawing.Size(459, 28);
            this.AktVidachiButton.TabIndex = 18;
            this.AktVidachiButton.Text = "Просмотр Акта выдачи";
            this.AktVidachiButton.UseVisualStyleBackColor = true;
            this.AktVidachiButton.Click += new System.EventHandler(this.AktVidachiButton_Click);
            // 
            // AktPiemaButton
            // 
            this.AktPiemaButton.Location = new System.Drawing.Point(657, 663);
            this.AktPiemaButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AktPiemaButton.Name = "AktPiemaButton";
            this.AktPiemaButton.Size = new System.Drawing.Size(459, 28);
            this.AktPiemaButton.TabIndex = 19;
            this.AktPiemaButton.Text = "Просмотр Акта приёма";
            this.AktPiemaButton.UseVisualStyleBackColor = true;
            this.AktPiemaButton.Click += new System.EventHandler(this.AktPiemaButton_Click);
            // 
            // RedaktorAktov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 743);
            this.Controls.Add(this.AktPiemaButton);
            this.Controls.Add(this.AktVidachiButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DannieURLitsaTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PhoneNumberTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DannieOFirmeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FirmNameTextBox);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RedaktorAktov";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор актов";
            this.Load += new System.EventHandler(this.RedaktorAktov_Load);
            this.tabControl1.ResumeLayout(false);
            this.AktPriema.ResumeLayout(false);
            this.AktPriema.PerformLayout();
            this.AktVidachi.ResumeLayout(false);
            this.AktVidachi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

	}

	private void label7_Click(object sender, EventArgs e)
	{

	}
}
