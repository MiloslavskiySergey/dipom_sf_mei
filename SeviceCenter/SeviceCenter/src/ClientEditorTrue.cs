// ClientEditorTrue

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

public class ClientEditorTrue : Form
{
	private MainForm mainForm;

	private string ClID;

	private ClientsEditor clientForm;

	private IContainer components = null;

	public Button SaveClientButton;

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

	public ClientEditorTrue(MainForm mf, string clientID, ClientsEditor ce)
	{
		InitializeComponent();
		mainForm = mf;
		ClID = clientID;
		clientForm = ce;
	}

	private void SaveClientButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Сохранить данные о клиенте?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.ClientsMapEditWithoutDate(ClientFioTextBox.Text, PhoneToNorm(ClientPhoneTextBox.Text), ClientAdressTextBox.Text, PrimechanieTextBox.Text, BlistOfClients(), ClientAboutUsComboBox.Text, ClID);
			TemporaryBase.SearchFULLBegin();
			clientForm.SearchClient();
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

	private string PhoneToNorm(string phone)
	{
		return phone.Replace(" ", "");
	}

	private void ClientEditorTrue_Load(object sender, EventArgs e)
	{
		ComboboxMaker("settings/aboutUs.txt", ClientAboutUsComboBox);
		DataTable dataTable = mainForm.basa.ClientsMapGiver(ClID);
		try
		{
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					ClientFioTextBox.Text = dataTable.Rows[i].ItemArray[1].ToString();
					ClientPhoneTextBox.Text = dataTable.Rows[i].ItemArray[2].ToString();
					ClientAdressTextBox.Text = dataTable.Rows[i].ItemArray[3].ToString();
					PrimechanieTextBox.Text = dataTable.Rows[i].ItemArray[4].ToString();
					BlackListComboBox.Text = KlientBlistDecoder(dataTable.Rows[i].ItemArray[5].ToString());
					ClientAboutUsComboBox.Text = dataTable.Rows[i].ItemArray[7].ToString();
					label30.Text = "Редактирование клиенат номер: " + dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private string KlientBlistDecoder(string blist)
	{
		if (blist == "0")
		{
			return "Не проблемный";
		}
		if (blist == "1")
		{
			return "Проблемный";
		}
		return "";
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
            this.SaveClientButton = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.BlackListComboBox = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.PrimechanieTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ClientFioTextBox = new System.Windows.Forms.TextBox();
            this.ClientAdressTextBox = new System.Windows.Forms.TextBox();
            this.ClientAboutUsComboBox = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.ClientPhoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveClientButton
            // 
            this.SaveClientButton.BackgroundImage = global::SeviceCenter.Properties.Resources.save;
            this.SaveClientButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SaveClientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveClientButton.Location = new System.Drawing.Point(17, 795);
            this.SaveClientButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveClientButton.Name = "SaveClientButton";
            this.SaveClientButton.Size = new System.Drawing.Size(453, 34);
            this.SaveClientButton.TabIndex = 221;
            this.SaveClientButton.Text = "Сохранить";
            this.SaveClientButton.UseVisualStyleBackColor = true;
            this.SaveClientButton.Click += new System.EventHandler(this.SaveClientButton_Click);
            // 
            // label30
            // 
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label30.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label30.Location = new System.Drawing.Point(16, 11);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(453, 56);
            this.label30.TabIndex = 220;
            this.label30.Text = "Редактирование клиента номер";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label28.Location = new System.Drawing.Point(16, 737);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(453, 15);
            this.label28.TabIndex = 219;
            this.label28.Text = "Тип клиента";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BlackListComboBox
            // 
            this.BlackListComboBox.FormattingEnabled = true;
            this.BlackListComboBox.Items.AddRange(new object[] {
            "Не проблемный",
            "Проблемный"});
            this.BlackListComboBox.Location = new System.Drawing.Point(16, 756);
            this.BlackListComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BlackListComboBox.Name = "BlackListComboBox";
            this.BlackListComboBox.Size = new System.Drawing.Size(452, 24);
            this.BlackListComboBox.TabIndex = 218;
            this.BlackListComboBox.Text = "Не проблемный";
            this.BlackListComboBox.TextChanged += new System.EventHandler(this.BlackListComboBox_TextChanged);
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label29.Location = new System.Drawing.Point(16, 286);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(453, 17);
            this.label29.TabIndex = 217;
            this.label29.Text = "Заметка о клиенте (клиенту не видна)";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrimechanieTextBox
            // 
            this.PrimechanieTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrimechanieTextBox.Location = new System.Drawing.Point(16, 305);
            this.PrimechanieTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PrimechanieTextBox.Multiline = true;
            this.PrimechanieTextBox.Name = "PrimechanieTextBox";
            this.PrimechanieTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrimechanieTextBox.Size = new System.Drawing.Size(452, 422);
            this.PrimechanieTextBox.TabIndex = 216;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(16, 70);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(453, 16);
            this.label17.TabIndex = 212;
            this.label17.Text = "ФИО";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientFioTextBox
            // 
            this.ClientFioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientFioTextBox.Location = new System.Drawing.Point(16, 89);
            this.ClientFioTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClientFioTextBox.Name = "ClientFioTextBox";
            this.ClientFioTextBox.Size = new System.Drawing.Size(452, 26);
            this.ClientFioTextBox.TabIndex = 208;
            // 
            // ClientAdressTextBox
            // 
            this.ClientAdressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientAdressTextBox.Location = new System.Drawing.Point(16, 233);
            this.ClientAdressTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClientAdressTextBox.Multiline = true;
            this.ClientAdressTextBox.Name = "ClientAdressTextBox";
            this.ClientAdressTextBox.Size = new System.Drawing.Size(452, 50);
            this.ClientAdressTextBox.TabIndex = 211;
            // 
            // ClientAboutUsComboBox
            // 
            this.ClientAboutUsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientAboutUsComboBox.FormattingEnabled = true;
            this.ClientAboutUsComboBox.Location = new System.Drawing.Point(16, 181);
            this.ClientAboutUsComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClientAboutUsComboBox.Name = "ClientAboutUsComboBox";
            this.ClientAboutUsComboBox.Size = new System.Drawing.Size(452, 28);
            this.ClientAboutUsComboBox.TabIndex = 210;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(20, 213);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(449, 16);
            this.label25.TabIndex = 215;
            this.label25.Text = "Адрес клиента";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(16, 161);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(453, 16);
            this.label26.TabIndex = 214;
            this.label26.Text = "Откуда о нас узнали";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientPhoneTextBox
            // 
            this.ClientPhoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientPhoneTextBox.Location = new System.Drawing.Point(16, 134);
            this.ClientPhoneTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClientPhoneTextBox.Name = "ClientPhoneTextBox";
            this.ClientPhoneTextBox.Size = new System.Drawing.Size(452, 26);
            this.ClientPhoneTextBox.TabIndex = 209;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(16, 114);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(453, 16);
            this.label27.TabIndex = 213;
            this.label27.Text = "Телефон";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientEditorTrue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 841);
            this.Controls.Add(this.SaveClientButton);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.BlackListComboBox);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.PrimechanieTextBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.ClientFioTextBox);
            this.Controls.Add(this.ClientAdressTextBox);
            this.Controls.Add(this.ClientAboutUsComboBox);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.ClientPhoneTextBox);
            this.Controls.Add(this.label27);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ClientEditorTrue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактировать клиента";
            this.Load += new System.EventHandler(this.ClientEditorTrue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

	}
}
