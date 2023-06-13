// Registration

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

public class Registration : Form
{
	private IniFile INIF = new IniFile("Config.ini");

	private MainForm mform;

	private IContainer components = null;

	private GroupBox groupBox1;

	private Button button2;

	private Button button1;

	private TextBox textBox2;

	private Label label2;

	private Label label1;

	private TextBox textBox1;

	public Registration(MainForm mf)
	{
		InitializeComponent();
		base.TopMost = true;
		mform = mf;
	}

	public static string getHDD()
	{
		string str = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
		ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"" + str + ":\"");
		managementObject.Get();
		string text = managementObject["VolumeSerialNumber"].ToString();
		return Crypt(text.ToString());
	}

	public static string Crypt(string text)
	{
		string text2 = string.Empty;
		foreach (char c in text)
		{
			text2 += ((char)(ushort)(c ^ 1)).ToString();
		}
		return text2;
	}

	public static string GetMd5Hash(MD5 md5Hash, string input)
	{
		byte[] array = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
	{
		string md5Hash2 = GetMd5Hash(md5Hash, input);
		StringComparer ordinalIgnoreCase = StringComparer.OrdinalIgnoreCase;
		if (ordinalIgnoreCase.Compare(md5Hash2, hash) == 0)
		{
			return true;
		}
		return false;
	}

	public static string sha1(string input)
	{
		byte[] array;
		using (SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider())
		{
			array = sHA1CryptoServiceProvider.ComputeHash(Encoding.Unicode.GetBytes(input));
		}
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			stringBuilder.AppendFormat("{0:x2}", b);
		}
		return stringBuilder.ToString();
	}

	public static bool deHash(string pass, string val)
	{
		MD5 md5Hash = MD5.Create();
		string str = "antivzlom89";
		string b = sha1(sha1(GetMd5Hash(md5Hash, val) + str));
		return pass == b;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Process.Start("http://vk.com/scrypto");
	}

	private void groupBox1_Enter(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (deHash(textBox2.Text, textBox1.Text))
		{
			mform.Enabled = true;
			INIF.WriteINI("ACTIVATION", textBox1.Text, textBox2.Text);
			Close();
		}
		else
		{
			MessageBox.Show("Не верный ключ авторизации");
		}
	}

	private void Registration_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!deHash(textBox2.Text, textBox1.Text))
		{
			mform.Close();
		}
	}

	private void button2_Click_1(object sender, EventArgs e)
	{
		Process.Start("http://vk.com/scrypto");
	}

	private void Registration_Load_1(object sender, EventArgs e)
	{
		try
		{
			textBox1.Text = getHDD();
		}
		catch (Exception)
		{
			textBox1.Text = "Error to generate SYS code!";
		}
	}

	private void groupBox1_Enter_1(object sender, EventArgs e)
	{
	}

	private void Registration_FormClosing_1(object sender, FormClosingEventArgs e)
	{
		if (!mform.Enabled)
		{
			Application.Exit();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(16, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(532, 165);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Авторизация";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 123);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Получить ключ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 123);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Зарегистрироваться";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 91);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(493, 22);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ключ авторизации";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ваш уникальный код:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 43);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(493, 22);
            this.textBox1.TabIndex = 0;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 175);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регестрация програмного продукта";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Registration_FormClosing_1);
            this.Load += new System.EventHandler(this.Registration_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

	}
}
