// ClientsEditor

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class ClientsEditor : Form
{
	private Form1 mainForm;

	private ItemComparerClients itemComparerClients;

	public List<KlientBase> ClientsList = new List<KlientBase>();

	private int firstClient = -1;

	private int secondClient = -1;

	private IContainer components = null;

	public Button AddZip;

	public ListView ClientsListView;

	private ColumnHeader Art;

	public ColumnHeader PosName;

	public ColumnHeader Colour;

	public ColumnHeader Brand;

	public ColumnHeader Model;

	public ColumnHeader Count;

	public ColumnHeader Price;

	public TextBox ClientFIOSearchTextBox;

	public TextBox ClientPhoneSearchTextBox;

	private ColumnHeader date;

	public Button DeleteClientButton;

	private PictureBox pictureBox1;

	private PictureBox pictureBox2;

	public Button ClitenToClientButton;

	private Label RepairHistoryLabel;

	public Panel panel1;

	public ClientsEditor(Form1 mf)
	{
		InitializeComponent();
		mainForm = mf;
		try
		{
			itemComparerClients = new ItemComparerClients(this);
			ClientsListView.ListViewItemSorter = itemComparerClients;
			ClientsListView.ColumnClick += OnColumnClick;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void ServiceAdressComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void OnColumnClick(object sender, ColumnClickEventArgs e)
	{
		try
		{
			itemComparerClients.ColumnIndex = e.Column;
			ClientsListView.VirtualListSize = ClientsList.Count;
			ClientsListView.VirtualListSize -= 1;
			ClientsListView.VirtualListSize += 1;
		}
		catch
		{
			MessageBox.Show("Нечего сортировать");
		}
	}

	private void ClientsEditor_Load(object sender, EventArgs e)
	{
		AddZip.Enabled = ((TemporaryBase.clientAdd == "1") ? true : false);
		DeleteClientButton.Enabled = ((TemporaryBase.clientDel == "1") ? true : false);
		ClitenToClientButton.Enabled = ((TemporaryBase.clientConcat == "1") ? true : false);
		ClientEditorStartLoad();
	}

	private void ClientEditorStartLoad()
	{
		ClientsListView.Items.Clear();
		ClientsList.Clear();
		DataTable dataTable = mainForm.basa.ClientsAllMapGiver();
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			ClientsList.Add(new KlientBase(dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString(), KlientBlistDecoder(dataTable.Rows[i].ItemArray[5].ToString()), dataTable.Rows[i].ItemArray[6].ToString(), dataTable.Rows[i].ItemArray[7].ToString()));
		}
		ClientsListView.VirtualListSize = ClientsList.Count;
		if (ClientsListView.VirtualListSize > 0)
		{
			ClientsListView.VirtualListSize -= 1;
			ClientsListView.VirtualListSize += 1;
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

	private void ClientsListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		try
		{
			e.Item = new ListViewItem(ClientsList[e.ItemIndex].id);
			e.Item.SubItems.Add(ClientsList[e.ItemIndex].FIO);
			e.Item.SubItems.Add(ClientsList[e.ItemIndex].Phone);
			e.Item.SubItems.Add(ClientsList[e.ItemIndex].Adress);
			e.Item.SubItems.Add(ClientsList[e.ItemIndex].AboutUs);
			e.Item.SubItems.Add(ClientsList[e.ItemIndex].Blist);
			e.Item.SubItems.Add(ClientsList[e.ItemIndex].Primechanie);
			e.Item.SubItems.Add(ClientsList[e.ItemIndex].Date);
			if (e.ItemIndex >= 0 && e.ItemIndex < ClientsList.Count)
			{
				if (ClientsList[e.ItemIndex].Blist == "Проблемный")
				{
					if (TemporaryBase.BlistColor != "")
					{
						e.Item.BackColor = Color.FromArgb(int.Parse(TemporaryBase.BlistColor));
					}
					else
					{
						e.Item.BackColor = Color.Yellow;
					}
				}
				else if (TemporaryBase.Poloski && e.ItemIndex % 2 == 0)
				{
					e.Item.BackColor = Color.FromArgb(240, 240, 240);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void AddZip_Click(object sender, EventArgs e)
	{
		ClientAddForm clientAddForm = new ClientAddForm(mainForm, this);
		clientAddForm.Show(mainForm);
	}

	private void DeleteClientButton_Click(object sender, EventArgs e)
	{
		if (ClientsListView.SelectedIndices.Count > 0 && MessageBox.Show("Вы действительно хотите удалить клиента" + Environment.NewLine + ClientsListView.Items[ClientsListView.SelectedIndices[0]].SubItems[1].Text + Environment.NewLine + "Вместе с клиентом будут удалены все записи, о ремонтированной им технике", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.ClientsMapDelete(ClientsListView.Items[ClientsListView.SelectedIndices[0]].SubItems[0].Text);
			mainForm.basa.ClientsMapZapisiDelete(ClientsListView.Items[ClientsListView.SelectedIndices[0]].SubItems[0].Text);
			ClientEditorStartLoad();
			TemporaryBase.SearchFULLBegin();
		}
	}

	private void ClientFIOSearchTextBox_TextChanged(object sender, EventArgs e)
	{
		SearchClient();
	}

	public void SearchClient()
	{
		ClientsListView.Items.Clear();
		ClientsList.Clear();
		DataTable dataTable = mainForm.basa.ClientsFIOPhoneSearch(ClientFIOSearchTextBox.Text, ClientPhoneSearchTextBox.Text);
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			ClientsList.Add(new KlientBase(dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString(), KlientBlistDecoder(dataTable.Rows[i].ItemArray[5].ToString()), dataTable.Rows[i].ItemArray[6].ToString(), dataTable.Rows[i].ItemArray[7].ToString()));
		}
		ClientsListView.VirtualListSize = ClientsList.Count;
		if (ClientsListView.VirtualListSize > 0)
		{
			ClientsListView.VirtualListSize -= 1;
			ClientsListView.VirtualListSize += 1;
		}
	}

	private void ClientPhoneSearchTextBox_TextChanged(object sender, EventArgs e)
	{
		SearchClient();
	}

	private void ClitenToClientButton_Click(object sender, EventArgs e)
	{
		if (ClientsListView.SelectedIndices.Count > 0)
		{
			if (firstClient == -1)
			{
				if (MessageBox.Show("Теперь выберите второго клиента, записи певрого клиента, станут записями второго клиента" + Environment.NewLine + "После выбора клиента, еще раз нажмите эту кнопку, для объединения", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					firstClient = int.Parse(ClientsListView.Items[ClientsListView.SelectedIndices[0]].SubItems[0].Text);
				}
				return;
			}
			secondClient = int.Parse(ClientsListView.Items[ClientsListView.SelectedIndices[0]].SubItems[0].Text);
			if (MessageBox.Show("Вы действительно хотите объединить клиентов? " + Environment.NewLine + "Первый клиент " + firstClient.ToString() + Environment.NewLine + "Второй клиент " + secondClient.ToString(), "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				mainForm.basa.ClientsMapDelete(firstClient.ToString());
				mainForm.basa.ClientsToClitens(firstClient.ToString(), secondClient.ToString());
				SearchClient();
				TemporaryBase.SearchFULLBegin();
				firstClient = -1;
				secondClient = -1;
			}
		}
		else
		{
			MessageBox.Show("Для начала выберите клиента, которого хотите объединить, все записи этого клиента перейдут ко второму клиенту");
		}
	}

	private void ClientsListView_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ClientsListView.SelectedIndices.Count > 0)
		{
			Text = "В данный момент выбран клиент " + ClientsListView.Items[ClientsListView.SelectedIndices[0]].SubItems[1].Text;
		}
		ClientsHistoryMaker();
	}

	public void MyMethod(object sender, EventArgs e)
	{
		Label label = (Label)sender;
		Editor editor = new Editor(mainForm, label.Tag.ToString());
		editor.Show(mainForm);
	}

	public void ClientsHistoryMaker()
	{
		if (ClientsListView.SelectedIndices.Count > 0)
		{
			DataTable dataTable = mainForm.basa.ClientsShowHistory(ClientsListView.Items[ClientsListView.SelectedIndices[0]].SubItems[0].Text);
			int num = 3;
			int num2 = 3;
			int num3 = panel1.Width - num * 2 - 2;
			List<Label> list = new List<Label>();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				Label label = new Label();
				string text = (!(dataTable.Rows[i].ItemArray[20].ToString() == "Выдан")) ? dataTable.Rows[i].ItemArray[20].ToString() : ("Выдан " + dataTable.Rows[i].ItemArray[2].ToString());
				label.Text = dataTable.Rows[i].ItemArray[1].ToString() + Environment.NewLine + dataTable.Rows[i].ItemArray[7].ToString() + Environment.NewLine + dataTable.Rows[i].ItemArray[8].ToString() + Environment.NewLine + dataTable.Rows[i].ItemArray[9].ToString() + Environment.NewLine + "Цена ремонта: " + dataTable.Rows[i].ItemArray[18].ToString() + Environment.NewLine + "Скидка: " + dataTable.Rows[i].ItemArray[19].ToString() + Environment.NewLine + text;
				label.BorderStyle = BorderStyle.FixedSingle;
				label.Location = new Point(num, num2);
				label.BackColor = Color.White;
				label.AutoSize = true;
				label.MinimumSize = new Size(num3, 107);
				num2 += 110;
				label.Font = new Font("Arial", 9f, FontStyle.Bold);
				label.Tag = dataTable.Rows[i].ItemArray[0].ToString();
				list.Add(label);
			}
			foreach (Label item in list)
			{
				if (num2 > panel1.Height)
				{
					item.MinimumSize = new Size(num3 - 18, 107);
				}
			}
			panel1.Controls.Clear();
			ToolTip toolTip = new ToolTip();
			toolTip.AutoPopDelay = 30000;
			int num4 = 0;
			foreach (Label item2 in list)
			{
				item2.MouseClick += MyMethod;
				panel1.Controls.Add(item2);
				toolTip.SetToolTip(item2, "Адрес СЦ: " + dataTable.Rows[num4].ItemArray[27].ToString() + Environment.NewLine + "Выполненные работы: " + dataTable.Rows[num4].ItemArray[22].ToString() + Environment.NewLine + "Мастер: " + dataTable.Rows[num4].ItemArray[21].ToString() + Environment.NewLine + "Поломка: " + dataTable.Rows[num4].ItemArray[13].ToString() + Environment.NewLine + "Комментарий: " + dataTable.Rows[num4].ItemArray[14].ToString() + Environment.NewLine);
				num4++;
			}
		}
	}

	private void ClientsListView_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		if (ClientsListView.SelectedIndices.Count > 0)
		{
			ClientEditorTrue clientEditorTrue = new ClientEditorTrue(mainForm, ClientsListView.Items[ClientsListView.SelectedIndices[0]].SubItems[0].Text, this);
			clientEditorTrue.Show(mainForm);
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
			this.AddZip = new System.Windows.Forms.Button();
			this.ClientsListView = new System.Windows.Forms.ListView();
			this.Art = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PosName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Colour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Brand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ClientFIOSearchTextBox = new System.Windows.Forms.TextBox();
			this.ClientPhoneSearchTextBox = new System.Windows.Forms.TextBox();
			this.DeleteClientButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.ClitenToClientButton = new System.Windows.Forms.Button();
			this.RepairHistoryLabel = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// AddZip
			// 
			this.AddZip.BackColor = System.Drawing.SystemColors.Window;
			this.AddZip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddZip.Location = new System.Drawing.Point(335, 5);
			this.AddZip.Name = "AddZip";
			this.AddZip.Size = new System.Drawing.Size(76, 47);
			this.AddZip.TabIndex = 3;
			this.AddZip.Text = "Добавить клиента";
			this.AddZip.UseVisualStyleBackColor = false;
			this.AddZip.Click += new System.EventHandler(this.AddZip_Click);
			// 
			// ClientsListView
			// 
			this.ClientsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ClientsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Art,
            this.PosName,
            this.Colour,
            this.Brand,
            this.Model,
            this.Count,
            this.Price,
            this.date});
			this.ClientsListView.FullRowSelect = true;
			this.ClientsListView.GridLines = true;
			this.ClientsListView.Location = new System.Drawing.Point(3, 57);
			this.ClientsListView.MultiSelect = false;
			this.ClientsListView.Name = "ClientsListView";
			this.ClientsListView.Size = new System.Drawing.Size(965, 612);
			this.ClientsListView.TabIndex = 15;
			this.ClientsListView.UseCompatibleStateImageBehavior = false;
			this.ClientsListView.View = System.Windows.Forms.View.Details;
			this.ClientsListView.VirtualMode = true;
			this.ClientsListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ClientsListView_RetrieveVirtualItem);
			this.ClientsListView.SelectedIndexChanged += new System.EventHandler(this.ClientsListView_SelectedIndexChanged);
			this.ClientsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ClientsListView_MouseDoubleClick);
			// 
			// Art
			// 
			this.Art.Text = "id";
			this.Art.Width = 40;
			// 
			// PosName
			// 
			this.PosName.Text = "ФИО";
			this.PosName.Width = 200;
			// 
			// Colour
			// 
			this.Colour.Text = "Телефон";
			this.Colour.Width = 113;
			// 
			// Brand
			// 
			this.Brand.Text = "Адрес";
			this.Brand.Width = 80;
			// 
			// Model
			// 
			this.Model.Text = "Откуда узнал";
			this.Model.Width = 80;
			// 
			// Count
			// 
			this.Count.Text = "Чёрный список";
			this.Count.Width = 100;
			// 
			// Price
			// 
			this.Price.Text = "Примечание";
			this.Price.Width = 226;
			// 
			// date
			// 
			this.date.Text = "Дата прихода";
			this.date.Width = 103;
			// 
			// ClientFIOSearchTextBox
			// 
			this.ClientFIOSearchTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.ClientFIOSearchTextBox.Location = new System.Drawing.Point(26, 5);
			this.ClientFIOSearchTextBox.Name = "ClientFIOSearchTextBox";
			this.ClientFIOSearchTextBox.Size = new System.Drawing.Size(301, 20);
			this.ClientFIOSearchTextBox.TabIndex = 1;
			this.ClientFIOSearchTextBox.TextChanged += new System.EventHandler(this.ClientFIOSearchTextBox_TextChanged);
			// 
			// ClientPhoneSearchTextBox
			// 
			this.ClientPhoneSearchTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.ClientPhoneSearchTextBox.Location = new System.Drawing.Point(26, 31);
			this.ClientPhoneSearchTextBox.Name = "ClientPhoneSearchTextBox";
			this.ClientPhoneSearchTextBox.Size = new System.Drawing.Size(301, 20);
			this.ClientPhoneSearchTextBox.TabIndex = 2;
			this.ClientPhoneSearchTextBox.TextChanged += new System.EventHandler(this.ClientPhoneSearchTextBox_TextChanged);
			// 
			// DeleteClientButton
			// 
			this.DeleteClientButton.BackColor = System.Drawing.SystemColors.Window;
			this.DeleteClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DeleteClientButton.Location = new System.Drawing.Point(417, 5);
			this.DeleteClientButton.Name = "DeleteClientButton";
			this.DeleteClientButton.Size = new System.Drawing.Size(76, 47);
			this.DeleteClientButton.TabIndex = 4;
			this.DeleteClientButton.Text = "Удалить клиента";
			this.DeleteClientButton.UseVisualStyleBackColor = false;
			this.DeleteClientButton.Click += new System.EventHandler(this.DeleteClientButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(5, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(19, 20);
			this.pictureBox1.TabIndex = 24;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(3, 33);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(19, 20);
			this.pictureBox2.TabIndex = 25;
			this.pictureBox2.TabStop = false;
			// 
			// ClitenToClientButton
			// 
			this.ClitenToClientButton.BackColor = System.Drawing.SystemColors.Window;
			this.ClitenToClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ClitenToClientButton.Location = new System.Drawing.Point(499, 5);
			this.ClitenToClientButton.Name = "ClitenToClientButton";
			this.ClitenToClientButton.Size = new System.Drawing.Size(81, 47);
			this.ClitenToClientButton.TabIndex = 5;
			this.ClitenToClientButton.Text = "Объединить клиентов";
			this.ClitenToClientButton.UseVisualStyleBackColor = false;
			this.ClitenToClientButton.Click += new System.EventHandler(this.ClitenToClientButton_Click);
			// 
			// RepairHistoryLabel
			// 
			this.RepairHistoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RepairHistoryLabel.Location = new System.Drawing.Point(1008, 7);
			this.RepairHistoryLabel.Name = "RepairHistoryLabel";
			this.RepairHistoryLabel.Size = new System.Drawing.Size(166, 19);
			this.RepairHistoryLabel.TabIndex = 204;
			this.RepairHistoryLabel.Text = "История клиента";
			this.RepairHistoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.SystemColors.Menu;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(972, 29);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(232, 640);
			this.panel1.TabIndex = 205;
			// 
			// ClientsEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1207, 672);
			this.Controls.Add(this.RepairHistoryLabel);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ClitenToClientButton);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.DeleteClientButton);
			this.Controls.Add(this.ClientPhoneSearchTextBox);
			this.Controls.Add(this.AddZip);
			this.Controls.Add(this.ClientsListView);
			this.Controls.Add(this.ClientFIOSearchTextBox);
			this.Name = "ClientsEditor";
			this.Text = "Клиенты";
			this.Load += new System.EventHandler(this.ClientsEditor_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

	}
}
