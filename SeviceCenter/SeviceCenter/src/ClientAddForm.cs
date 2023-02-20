// ClientAddForm

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class ClientAddForm : Form
{
	private Form1 mainForm;

	private ClientsEditor clientsForm;

	private IContainer components = null;

	public Button AddClientButton;

	private Label label30;

	private Label label28;

	public ComboBox BlackListComboBox;

	private Label label29;

	public TextBox PrimechanieTextBox;

	public Label label17;

	public TextBox ClientFioTextBox;

	public TextBox ClientAdressTextBox;

	public ComboBox ClientAboutUsComboBox;

	public Label label25;

	public Label label26;

	public MaskedTextBox ClientPhoneTextBox;

	public Label label27;

	public ClientAddForm(Form1 mf, ClientsEditor ce)
	{
		InitializeComponent();
		mainForm = mf;
		clientsForm = ce;
	}

	private void AddClientButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Добавить клиента " + ClientFioTextBox.Text + " ?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.ClientsMapWrite(ClientFioTextBox.Text, ClientPhoneTextBox.Text.Replace(" ", ""), ClientAdressTextBox.Text, PrimechanieTextBox.Text, BlistOfClients(), DateTime.Now.ToString("dd-MM-yyyy HH:mm"), ClientAboutUsComboBox.Text);
			AllItemsClear();
			clientsForm.SearchClient();
		}
	}

	private string BlistOfClients()
	{
		if (BlackListComboBox.Text == "Не проблемный")
		{
			return "0";
		}
		if (BlackListComboBox.Text == "Проблемный")
		{
			return "1";
		}
		return "-1";
	}

	private void AllItemsClear()
	{
		ClientFioTextBox.Text = "";
		ClientPhoneTextBox.Text = "";
		ClientAdressTextBox.Text = "";
		PrimechanieTextBox.Text = "";
		BlackListComboBox.Text = "Не проблемный";
		ClientAboutUsComboBox.Text = "";
	}

	private void label30_MouseLeave(object sender, EventArgs e)
	{
		label30.BorderStyle = BorderStyle.Fixed3D;
	}

	private void label30_Click(object sender, EventArgs e)
	{
		AllItemsClear();
	}

	private void label30_MouseEnter(object sender, EventArgs e)
	{
		label30.BorderStyle = BorderStyle.FixedSingle;
	}

	private void BlackListComboBox_TextChanged(object sender, EventArgs e)
	{
		if (BlackListComboBox.Text == "Проблемный")
		{
			if (TemporaryBase.BlistColor != "")
			{
				BlackListComboBox.BackColor = Color.FromArgb(int.Parse(TemporaryBase.BlistColor));
			}
			else
			{
				BlackListComboBox.BackColor = Color.White;
			}
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
		label30 = new System.Windows.Forms.Label();
		label28 = new System.Windows.Forms.Label();
		BlackListComboBox = new System.Windows.Forms.ComboBox();
		label29 = new System.Windows.Forms.Label();
		PrimechanieTextBox = new System.Windows.Forms.TextBox();
		label17 = new System.Windows.Forms.Label();
		ClientFioTextBox = new System.Windows.Forms.TextBox();
		ClientAdressTextBox = new System.Windows.Forms.TextBox();
		ClientAboutUsComboBox = new System.Windows.Forms.ComboBox();
		label25 = new System.Windows.Forms.Label();
		label26 = new System.Windows.Forms.Label();
		ClientPhoneTextBox = new System.Windows.Forms.MaskedTextBox();
		label27 = new System.Windows.Forms.Label();
		AddClientButton = new System.Windows.Forms.Button();
		SuspendLayout();
		label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		label30.Cursor = System.Windows.Forms.Cursors.Hand;
		label30.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label30.Location = new System.Drawing.Point(12, 9);
		label30.Name = "label30";
		label30.Size = new System.Drawing.Size(340, 46);
		label30.TabIndex = 220;
		label30.Text = "Очистить содержимое полей";
		label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label30.Click += new System.EventHandler(label30_Click);
		label30.MouseEnter += new System.EventHandler(label30_MouseEnter);
		label30.MouseLeave += new System.EventHandler(label30_MouseLeave);
		label28.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label28.Location = new System.Drawing.Point(12, 233);
		label28.Name = "label28";
		label28.Size = new System.Drawing.Size(340, 12);
		label28.TabIndex = 219;
		label28.Text = "Тип клиента";
		label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		BlackListComboBox.FormattingEnabled = true;
		BlackListComboBox.Items.AddRange(new object[2]
		{
			"Не проблемный",
			"Проблемный"
		});
		BlackListComboBox.Location = new System.Drawing.Point(12, 248);
		BlackListComboBox.Name = "BlackListComboBox";
		BlackListComboBox.Size = new System.Drawing.Size(340, 21);
		BlackListComboBox.TabIndex = 218;
		BlackListComboBox.Text = "Не проблемный";
		BlackListComboBox.TextChanged += new System.EventHandler(BlackListComboBox_TextChanged);
		label29.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label29.Location = new System.Drawing.Point(363, 9);
		label29.Name = "label29";
		label29.Size = new System.Drawing.Size(340, 14);
		label29.TabIndex = 217;
		label29.Text = "Заметка о клиенте (клиенту не видна)";
		label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		PrimechanieTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		PrimechanieTextBox.Location = new System.Drawing.Point(363, 25);
		PrimechanieTextBox.Multiline = true;
		PrimechanieTextBox.Name = "PrimechanieTextBox";
		PrimechanieTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		PrimechanieTextBox.Size = new System.Drawing.Size(340, 283);
		PrimechanieTextBox.TabIndex = 216;
		label17.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label17.ForeColor = System.Drawing.Color.Black;
		label17.Location = new System.Drawing.Point(12, 57);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(340, 13);
		label17.TabIndex = 212;
		label17.Text = "ФИО";
		label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		ClientFioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ClientFioTextBox.Location = new System.Drawing.Point(12, 72);
		ClientFioTextBox.Name = "ClientFioTextBox";
		ClientFioTextBox.Size = new System.Drawing.Size(340, 22);
		ClientFioTextBox.TabIndex = 208;
		ClientAdressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ClientAdressTextBox.Location = new System.Drawing.Point(12, 189);
		ClientAdressTextBox.Multiline = true;
		ClientAdressTextBox.Name = "ClientAdressTextBox";
		ClientAdressTextBox.Size = new System.Drawing.Size(340, 41);
		ClientAdressTextBox.TabIndex = 211;
		ClientAboutUsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ClientAboutUsComboBox.FormattingEnabled = true;
		ClientAboutUsComboBox.Location = new System.Drawing.Point(12, 147);
		ClientAboutUsComboBox.Name = "ClientAboutUsComboBox";
		ClientAboutUsComboBox.Size = new System.Drawing.Size(340, 24);
		ClientAboutUsComboBox.TabIndex = 210;
		label25.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label25.ForeColor = System.Drawing.Color.Black;
		label25.Location = new System.Drawing.Point(15, 173);
		label25.Name = "label25";
		label25.Size = new System.Drawing.Size(337, 13);
		label25.TabIndex = 215;
		label25.Text = "Адрес клиента";
		label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label26.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label26.ForeColor = System.Drawing.Color.Black;
		label26.Location = new System.Drawing.Point(12, 131);
		label26.Name = "label26";
		label26.Size = new System.Drawing.Size(340, 13);
		label26.TabIndex = 214;
		label26.Text = "Откуда о нас узнали";
		label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		ClientPhoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ClientPhoneTextBox.Location = new System.Drawing.Point(12, 109);
		ClientPhoneTextBox.Name = "ClientPhoneTextBox";
		ClientPhoneTextBox.Size = new System.Drawing.Size(340, 22);
		ClientPhoneTextBox.TabIndex = 209;
		label27.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label27.ForeColor = System.Drawing.Color.Black;
		label27.Location = new System.Drawing.Point(12, 93);
		label27.Name = "label27";
		label27.Size = new System.Drawing.Size(340, 13);
		label27.TabIndex = 213;
		label27.Text = "Телефон";
		label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		AddClientButton.BackgroundImage = SeviceCenter.Properties.Resources.add;
		AddClientButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		AddClientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		AddClientButton.Location = new System.Drawing.Point(13, 280);
		AddClientButton.Name = "AddClientButton";
		AddClientButton.Size = new System.Drawing.Size(340, 28);
		AddClientButton.TabIndex = 221;
		AddClientButton.Text = "Добавить";
		AddClientButton.UseVisualStyleBackColor = true;
		AddClientButton.Click += new System.EventHandler(AddClientButton_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(715, 322);
		base.Controls.Add(AddClientButton);
		base.Controls.Add(label30);
		base.Controls.Add(label28);
		base.Controls.Add(BlackListComboBox);
		base.Controls.Add(label29);
		base.Controls.Add(PrimechanieTextBox);
		base.Controls.Add(label17);
		base.Controls.Add(ClientFioTextBox);
		base.Controls.Add(ClientAdressTextBox);
		base.Controls.Add(ClientAboutUsComboBox);
		base.Controls.Add(label25);
		base.Controls.Add(label26);
		base.Controls.Add(ClientPhoneTextBox);
		base.Controls.Add(label27);
		base.Name = "ClientAddForm";
		Text = "Добавление нового клиента";
		ResumeLayout(false);
		PerformLayout();
	}
}
