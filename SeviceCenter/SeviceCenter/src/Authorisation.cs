// Authorisation

using SeviceCenter.src;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Authorisation : Form
{
	private IniFile INIF = new IniFile("Config.ini");

	private Form1 mainForm;

	private IContainer components = null;

	private ComboBox LoginComboBox;

	public TextBox PasswordBox;

	public PictureBox pictureBox1;

	private Label label1;

	private Label label2;
	private Button btnSetting;
	private Button EnterButton;

	public Authorisation(Form1 fm)
	{
		InitializeComponent();
		mainForm = fm;
	}

	private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
	{
		PasswordBox.UseSystemPasswordChar = false;
	}

	private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
	{
		PasswordBox.UseSystemPasswordChar = true;
	}

	private void Authorisation_Load(object sender, EventArgs e)
	{
		comboboxUsersMaker(LoginComboBox);
		PasswordBox.UseSystemPasswordChar = true;
		if (!INIF.KeyExists(TemporaryBase.UserKey, "LastUser"))
		{
			return;
		}
		for (int i = 0; i < LoginComboBox.Items.Count; i++)
		{
			string a = LoginComboBox.Items[i].ToString();
			if (a == INIF.ReadINI(TemporaryBase.UserKey, "LastUser"))
			{
				LoginComboBox.SelectedIndex = i;
			}
		}
	}

	private void comboboxUsersMaker(ComboBox cmbox)
	{
		cmbox.Items.Clear();
		DataTable dataTable = mainForm.basa.UsersBdRead();
		if (dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				cmbox.Items.Add(dataTable.Rows[i].ItemArray[2].ToString());
			}
		}
	}

	private void EnterButton_Click(object sender, EventArgs e)
	{
		VhodVMy();
	}

	private void VhodVMy()
	{
		if (LoginComboBox.Text != "")
		{
			if (Registration.sha1(PasswordBox.Text) == mainForm.basa.UsersGetPass(LoginComboBox.Text))
			{
				RulesMaker(mainForm.basa.GroupDostupGetgrNameByIdBdRead(mainForm.basa.UsersGetGroupIdByUserName(LoginComboBox.Text)));
				mainForm.RulesMackerMainWindow();
				mainForm.Enabled = true;
				TemporaryBase.USER_SESSION = LoginComboBox.Text + " " + mainForm.basa.GroupDostupGetgrNameByIdBdRead(mainForm.basa.UsersGetGroupIdByUserName(LoginComboBox.Text));
				INIF.WriteINI(TemporaryBase.UserKey, "LastUser", LoginComboBox.Text);
				Close();
			}
			else
			{
				MessageBox.Show("Неверный логин-пароль");
			}
		}
		else
		{
			MessageBox.Show("Выберите пользователя");
		}
	}

	private void Authorisation_FormClosed(object sender, FormClosedEventArgs e)
	{
	}

	private void Authorisation_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!mainForm.Enabled)
		{
			Application.Exit();
		}
	}

	private void RulesMaker(string grName)
	{
		DataTable dataTable = mainForm.basa.GroupDostupBdRead(grName);
		if (dataTable.Rows.Count > 0)
		{
			int index = 0;
			TemporaryBase.delZapis = ((dataTable.Rows[index].ItemArray[2].ToString() == "1") ? "1" : "0");
			TemporaryBase.addZapis = ((dataTable.Rows[index].ItemArray[3].ToString() == "1") ? "1" : "0");
			TemporaryBase.saveZapis = ((dataTable.Rows[index].ItemArray[4].ToString() == "1") ? "1" : "0");
			TemporaryBase.graf = ((dataTable.Rows[index].ItemArray[5].ToString() == "1") ? "1" : "0");
			TemporaryBase.sms = ((dataTable.Rows[index].ItemArray[6].ToString() == "1") ? "1" : "0");
			TemporaryBase.stock = ((dataTable.Rows[index].ItemArray[7].ToString() == "1") ? "1" : "0");
			TemporaryBase.clients = ((dataTable.Rows[index].ItemArray[8].ToString() == "1") ? "1" : "0");
			TemporaryBase.stockAdd = ((dataTable.Rows[index].ItemArray[9].ToString() == "1") ? "1" : "0");
			TemporaryBase.stockDel = ((dataTable.Rows[index].ItemArray[10].ToString() == "1") ? "1" : "0");
			TemporaryBase.stockEdit = ((dataTable.Rows[index].ItemArray[11].ToString() == "1") ? "1" : "0");
			TemporaryBase.clientAdd = ((dataTable.Rows[index].ItemArray[12].ToString() == "1") ? "1" : "0");
			TemporaryBase.clientDel = ((dataTable.Rows[index].ItemArray[13].ToString() == "1") ? "1" : "0");
			TemporaryBase.clientConcat = ((dataTable.Rows[index].ItemArray[14].ToString() == "1") ? "1" : "0");
			TemporaryBase.settings = ((dataTable.Rows[index].ItemArray[15].ToString() == "1") ? "1" : "0");
			TemporaryBase.dates = ((dataTable.Rows[index].ItemArray[16].ToString() == "1") ? "1" : "0");
			TemporaryBase.editDates = ((dataTable.Rows[index].ItemArray[17].ToString() == "1") ? "1" : "0");
		}
	}

	private void LoginComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		Text = "Авторизация " + mainForm.basa.GroupDostupGetgrNameByIdBdRead(mainForm.basa.UsersGetGroupIdByUserName(LoginComboBox.Text));
	}

	private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			VhodVMy();
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
            this.LoginComboBox = new System.Windows.Forms.ComboBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EnterButton = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginComboBox
            // 
            this.LoginComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LoginComboBox.FormattingEnabled = true;
            this.LoginComboBox.Location = new System.Drawing.Point(87, 7);
            this.LoginComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginComboBox.Name = "LoginComboBox";
            this.LoginComboBox.Size = new System.Drawing.Size(363, 24);
            this.LoginComboBox.TabIndex = 0;
            this.LoginComboBox.SelectedIndexChanged += new System.EventHandler(this.LoginComboBox_SelectedIndexChanged);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(87, 41);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(328, 22);
            this.PasswordBox.TabIndex = 13;
            this.PasswordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Пароль:";
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(112, 89);
            this.EnterButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(116, 28);
            this.EnterButton.TabIndex = 17;
            this.EnterButton.Text = "Войти";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.AutoSize = true;
            this.btnSetting.Location = new System.Drawing.Point(260, 89);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(156, 28);
            this.btnSetting.TabIndex = 18;
            this.btnSetting.Text = "Настройка сервера";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(424, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Authorisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 132);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoginComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Authorisation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Authorisation_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Authorisation_FormClosed);
            this.Load += new System.EventHandler(this.Authorisation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}

	private void btnSetting_Click(object sender, EventArgs e)
	{
		new SettingServer().ShowDialog();
	}
}
