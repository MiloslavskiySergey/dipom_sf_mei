// Stock

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

public class Stock : Form
{
	private Form1 mainForm;

	private itemComparerStock itcStock;

	private List<ZIP> ZIP1 = new List<ZIP>();

	private IniFile INIF = new IniFile("Config.ini");

	private string idInMainBd = "-1";

	private Editor editorForm = null;

	private Color backOfColour = Color.Green;

	private DataTable dtMap1 = null;

	private string client_id_base = "";

	private IContainer components = null;

	public TextBox StockSearchTextBox;

	public ComboBox KategoryComboBox;

	public ComboBox PodKategoryComboBox;

	public ListView StockListView;

	public ColumnHeader PosName;

	public ColumnHeader Colour;

	public ColumnHeader Count;

	public ColumnHeader Price;

	public ColumnHeader Brand;

	public ColumnHeader Model;

	public Button AddZip;

	public ComboBox BrandComboBox;

	public ComboBox ColourComboBox;

	public TextBox ModelTextBox;

	private ColumnHeader Art;

	private CheckBox BuyCheckBox;

	private CheckBox ClientUsedCheckBox;

	public Stock(Form1 mf, string idInMainBd = "-1", Editor ed1 = null, string Client_id_inBase = "")
	{
		InitializeComponent();
		mainForm = mf;
		itcStock = new itemComparerStock(this);
		StockListView.ListViewItemSorter = itcStock;
		StockListView.ColumnClick += OnColumnClick;
		this.idInMainBd = idInMainBd;
		editorForm = ed1;
		dtMap1 = mainForm.basa.BdStockMapZIPUsedCheckOptimised();
		client_id_base = Client_id_inBase;
		if (INIF.KeyExists("PROGRAMM_SETTINGS", "colorDiagnostik"))
		{
			backOfColour = Color.FromArgb(int.Parse(INIF.ReadINI("PROGRAMM_SETTINGS", "colorDiagnostik")));
		}
	}

	private void OnColumnClick(object sender, ColumnClickEventArgs e)
	{
		try
		{
			itcStock.ColumnIndex = e.Column;
			StockListView.VirtualListSize = ZIP1.Count;
			StockListView.VirtualListSize -= 1;
			StockListView.VirtualListSize += 1;
		}
		catch
		{
			MessageBox.Show("Нечего сортировать");
		}
	}

	private void Stock_Load(object sender, EventArgs e)
	{
		AddZip.Enabled = ((TemporaryBase.stockAdd == "1") ? true : false);
		if (INIF.KeyExists(TemporaryBase.UserKey, "StockPosition"))
		{
			try
			{
				base.Width = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "STfWidth"));
				base.Height = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "STfHeight"));
				base.Left = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "STfLeft"));
				base.Top = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "STfTop"));
				if (base.Left < -10000)
				{
					base.Left = 0;
					base.Top = 0;
					base.Width = 600;
					base.Height = 600;
				}
			}
			catch
			{
			}
		}
		mainForm.basa.CreateStock();
		mainForm.basa.CreateStockMap();
		ComboboxMaker("settings/Stock/ustrojstvo.txt", KategoryComboBox);
		ComboboxMaker("settings/Stock/TypeOvZIP.txt", PodKategoryComboBox);
		ComboboxMaker("settings/Stock/brands.txt", BrandComboBox);
		ComboboxMaker("settings/Stock/DeviceColour.txt", ColourComboBox);
		StockFullSearch();
		ToolTip toolTip = new ToolTip();
		toolTip.SetToolTip(KategoryComboBox, "Тип устройства");
		toolTip.SetToolTip(PodKategoryComboBox, "Тип запчасти");
		toolTip.SetToolTip(BrandComboBox, "Фирма производитель");
		toolTip.SetToolTip(ModelTextBox, "Модель");
		toolTip.SetToolTip(ColourComboBox, "Цвет");
		toolTip.SetToolTip(StockSearchTextBox, "Поиск по наименованию");
		toolTip.SetToolTip(BuyCheckBox, "Показать записи, количество которых меньше нормы " + Environment.NewLine + "Данная галочка не учитывает остальные поля поиска");
		toolTip.SetToolTip(ClientUsedCheckBox, "Показать записи, которые используются данным клиентом " + Environment.NewLine + "Данная галочка не учитывает остальные поля поиска");
		if (editorForm != null)
		{
			editorForm.Enabled = false;
		}
		if (int.Parse(idInMainBd) > -1)
		{
			Text = "Склад. Клиент: " + mainForm.basa.BdReadOne("surname", idInMainBd);
		}
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

	private void listView1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void AddZip_Click(object sender, EventArgs e)
	{
		StockAddPosition stockAddPosition = new StockAddPosition(mainForm, this);
		stockAddPosition.Show(mainForm);
	}

	private void StockListView_ColumnClick(object sender, ColumnClickEventArgs e)
	{
		StockListView.Sorting = SortOrder.Descending;
	}

	private void StockListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		try
		{
			e.Item = new ListViewItem(ZIP1[e.ItemIndex].idOf);
			e.Item.SubItems.Add(ZIP1[e.ItemIndex].naimenovanie);
			e.Item.SubItems.Add(ZIP1[e.ItemIndex].colour);
			e.Item.SubItems.Add(ZIP1[e.ItemIndex].brand);
			e.Item.SubItems.Add(ZIP1[e.ItemIndex].model);
			e.Item.SubItems.Add(ZIP1[e.ItemIndex].countOf);
			e.Item.SubItems.Add(ZIP1[e.ItemIndex].price);
			if (e.ItemIndex >= 0 && e.ItemIndex < ZIP1.Count)
			{
				if (dtableSearchConcidence(idInMainBd, ZIP1[e.ItemIndex].idOf))
				{
					e.Item.BackColor = backOfColour;
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

	private bool dtableSearchConcidence(string idInMainBd, string idOfZIP)
	{
		if (dtMap1 != null)
		{
			for (int i = 0; i < dtMap1.Rows.Count; i++)
			{
				if (dtMap1.Rows[i].ItemArray[1].ToString() == idInMainBd && dtMap1.Rows[i].ItemArray[2].ToString() == idOfZIP)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	private void SearchInStock_Click(object sender, EventArgs e)
	{
		StockFullSearch();
	}

	public void StockFullSearch()
	{
		try
		{
			dtMap1 = mainForm.basa.BdStockMapZIPUsedCheckOptimised();
			StockListView.Items.Clear();
			ZIP1.Clear();
			DataTable dataTable = mainForm.basa.BdStockFullSearch(StockSearchTextBox.Text, KategoryComboBox.Text, PodKategoryComboBox.Text, ColourComboBox.Text, BrandComboBox.Text, ModelTextBox.Text, "", "");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				ZIP item = new ZIP(dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[4].ToString(), dataTable.Rows[i].ItemArray[5].ToString(), dataTable.Rows[i].ItemArray[6].ToString(), dataTable.Rows[i].ItemArray[7].ToString(), dataTable.Rows[i].ItemArray[8].ToString(), dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[10].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[9].ToString(), dataTable.Rows[i].ItemArray[11].ToString(), dataTable.Rows[i].ItemArray[12].ToString(), dataTable.Rows[i].ItemArray[13].ToString());
				ZIP1.Add(item);
			}
			StockListView.VirtualListSize = ZIP1.Count;
			if (StockListView.VirtualListSize > 0)
			{
				StockListView.VirtualListSize -= 1;
				StockListView.VirtualListSize += 1;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void StockFullSearch(string buy)
	{
		try
		{
			dtMap1 = mainForm.basa.BdStockMapZIPUsedCheckOptimised();
			StockListView.Items.Clear();
			ZIP1.Clear();
			DataTable dataTable = mainForm.basa.BdStockFullSearch("", "", "", "", "", "", "", "");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				ZIP zIP = new ZIP(dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[4].ToString(), dataTable.Rows[i].ItemArray[5].ToString(), dataTable.Rows[i].ItemArray[6].ToString(), dataTable.Rows[i].ItemArray[7].ToString(), dataTable.Rows[i].ItemArray[8].ToString(), dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[10].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[9].ToString(), dataTable.Rows[i].ItemArray[11].ToString(), dataTable.Rows[i].ItemArray[12].ToString(), dataTable.Rows[i].ItemArray[13].ToString());
				if (zIP.napominanie != "0" && int.Parse(zIP.countOf) < int.Parse(zIP.napominanie))
				{
					ZIP1.Add(zIP);
				}
			}
			StockListView.VirtualListSize = ZIP1.Count;
			if (StockListView.VirtualListSize > 0)
			{
				StockListView.VirtualListSize -= 1;
				StockListView.VirtualListSize += 1;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void StockFullSearchClientUsed()
	{
		try
		{
			dtMap1 = mainForm.basa.BdStockMapZIPUsedCheckOptimised();
			StockListView.Items.Clear();
			ZIP1.Clear();
			DataTable dataTable = mainForm.basa.BdStockFullSearch("", "", "", "", "", "", "", "");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				ZIP zIP = new ZIP(dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[4].ToString(), dataTable.Rows[i].ItemArray[5].ToString(), dataTable.Rows[i].ItemArray[6].ToString(), dataTable.Rows[i].ItemArray[7].ToString(), dataTable.Rows[i].ItemArray[8].ToString(), dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[10].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[9].ToString(), dataTable.Rows[i].ItemArray[11].ToString(), dataTable.Rows[i].ItemArray[12].ToString(), dataTable.Rows[i].ItemArray[13].ToString());
				if (dtableSearchConcidence(idInMainBd, zIP.idOf))
				{
					ZIP1.Add(zIP);
				}
			}
			StockListView.VirtualListSize = ZIP1.Count;
			if (StockListView.VirtualListSize > 0)
			{
				StockListView.VirtualListSize -= 1;
				StockListView.VirtualListSize += 1;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void StockSearchTextBox_TextChanged(object sender, EventArgs e)
	{
		StockFullSearch();
	}

	private void StockListView_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		if (ZIP1.Count > 0)
		{
			string text = StockListView.Items[StockListView.SelectedIndices[0]].SubItems[0].Text;
			StockEditor stockEditor = new StockEditor(mainForm, text, this, idInMainBd, editorForm, client_id_base);
			stockEditor.Show(mainForm);
		}
	}

	private void BuyButton_Click(object sender, EventArgs e)
	{
	}

	private void BuyCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		ClientUsedCheckBox.Checked = false;
		if (BuyCheckBox.Checked)
		{
			StockFullSearch("buy");
		}
		else
		{
			StockFullSearch();
		}
	}

	private void Stock_FormClosed(object sender, FormClosedEventArgs e)
	{
		if (base.Left > -10000 && base.Top > -10000)
		{
			INIF.WriteINI(TemporaryBase.UserKey, "StockPosition", "1");
			INIF.WriteINI(TemporaryBase.UserKey, "STfLeft", base.Left.ToString());
			INIF.WriteINI(TemporaryBase.UserKey, "STfTop", base.Top.ToString());
			INIF.WriteINI(TemporaryBase.UserKey, "STfWidth", base.Width.ToString());
			INIF.WriteINI(TemporaryBase.UserKey, "STfHeight", base.Height.ToString());
		}
		if (editorForm != null)
		{
			editorForm.Enabled = true;
			editorForm.WindowState = FormWindowState.Normal;
		}
	}

	private void KategoryComboBox_TextChanged(object sender, EventArgs e)
	{
		StockFullSearch();
	}

	private void ModelTextBox_TextChanged(object sender, EventArgs e)
	{
		StockFullSearch();
	}

	private void PodKategoryComboBox_TextChanged(object sender, EventArgs e)
	{
		StockFullSearch();
	}

	private void ColourComboBox_TextChanged(object sender, EventArgs e)
	{
		StockFullSearch();
	}

	private void BrandComboBox_TextChanged(object sender, EventArgs e)
	{
		StockFullSearch();
	}

	private void ClientUsedCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		BuyCheckBox.Checked = false;
		if (ClientUsedCheckBox.Checked)
		{
			StockFullSearchClientUsed();
		}
		else
		{
			StockFullSearch();
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
            this.StockSearchTextBox = new System.Windows.Forms.TextBox();
            this.KategoryComboBox = new System.Windows.Forms.ComboBox();
            this.PodKategoryComboBox = new System.Windows.Forms.ComboBox();
            this.StockListView = new System.Windows.Forms.ListView();
            this.Art = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PosName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Colour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Brand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddZip = new System.Windows.Forms.Button();
            this.BrandComboBox = new System.Windows.Forms.ComboBox();
            this.ColourComboBox = new System.Windows.Forms.ComboBox();
            this.ModelTextBox = new System.Windows.Forms.TextBox();
            this.BuyCheckBox = new System.Windows.Forms.CheckBox();
            this.ClientUsedCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // StockSearchTextBox
            // 
            this.StockSearchTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.StockSearchTextBox.Location = new System.Drawing.Point(16, 15);
            this.StockSearchTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StockSearchTextBox.Name = "StockSearchTextBox";
            this.StockSearchTextBox.Size = new System.Drawing.Size(433, 22);
            this.StockSearchTextBox.TabIndex = 0;
            this.StockSearchTextBox.TextChanged += new System.EventHandler(this.StockSearchTextBox_TextChanged);
            // 
            // KategoryComboBox
            // 
            this.KategoryComboBox.FormattingEnabled = true;
            this.KategoryComboBox.Location = new System.Drawing.Point(477, 15);
            this.KategoryComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KategoryComboBox.Name = "KategoryComboBox";
            this.KategoryComboBox.Size = new System.Drawing.Size(237, 24);
            this.KategoryComboBox.TabIndex = 1;
            this.KategoryComboBox.TextChanged += new System.EventHandler(this.KategoryComboBox_TextChanged);
            // 
            // PodKategoryComboBox
            // 
            this.PodKategoryComboBox.FormattingEnabled = true;
            this.PodKategoryComboBox.Location = new System.Drawing.Point(744, 15);
            this.PodKategoryComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PodKategoryComboBox.Name = "PodKategoryComboBox";
            this.PodKategoryComboBox.Size = new System.Drawing.Size(237, 24);
            this.PodKategoryComboBox.TabIndex = 2;
            this.PodKategoryComboBox.TextChanged += new System.EventHandler(this.PodKategoryComboBox_TextChanged);
            // 
            // StockListView
            // 
            this.StockListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StockListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Art,
            this.PosName,
            this.Colour,
            this.Brand,
            this.Model,
            this.Count,
            this.Price});
            this.StockListView.FullRowSelect = true;
            this.StockListView.GridLines = true;
            this.StockListView.HideSelection = false;
            this.StockListView.Location = new System.Drawing.Point(16, 84);
            this.StockListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StockListView.MultiSelect = false;
            this.StockListView.Name = "StockListView";
            this.StockListView.Size = new System.Drawing.Size(1228, 594);
            this.StockListView.TabIndex = 3;
            this.StockListView.UseCompatibleStateImageBehavior = false;
            this.StockListView.View = System.Windows.Forms.View.Details;
            this.StockListView.VirtualMode = true;
            this.StockListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.StockListView_ColumnClick);
            this.StockListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.StockListView_RetrieveVirtualItem);
            this.StockListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.StockListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StockListView_MouseDoubleClick);
            // 
            // Art
            // 
            this.Art.Text = "Арт.";
            this.Art.Width = 40;
            // 
            // PosName
            // 
            this.PosName.Text = "Наименование";
            this.PosName.Width = 540;
            // 
            // Colour
            // 
            this.Colour.Text = "Цвет";
            // 
            // Brand
            // 
            this.Brand.Text = "Бренд";
            this.Brand.Width = 80;
            // 
            // Model
            // 
            this.Model.Text = "Модель";
            this.Model.Width = 80;
            // 
            // Count
            // 
            this.Count.Text = "Количество";
            this.Count.Width = 70;
            // 
            // Price
            // 
            this.Price.Text = "Цена";
            // 
            // AddZip
            // 
            this.AddZip.Location = new System.Drawing.Point(16, 47);
            this.AddZip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddZip.Name = "AddZip";
            this.AddZip.Size = new System.Drawing.Size(435, 28);
            this.AddZip.TabIndex = 4;
            this.AddZip.Text = "Добавить ЗИП";
            this.AddZip.UseVisualStyleBackColor = true;
            this.AddZip.Click += new System.EventHandler(this.AddZip_Click);
            // 
            // BrandComboBox
            // 
            this.BrandComboBox.FormattingEnabled = true;
            this.BrandComboBox.Location = new System.Drawing.Point(1007, 15);
            this.BrandComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrandComboBox.Name = "BrandComboBox";
            this.BrandComboBox.Size = new System.Drawing.Size(237, 24);
            this.BrandComboBox.TabIndex = 5;
            this.BrandComboBox.TextChanged += new System.EventHandler(this.BrandComboBox_TextChanged);
            // 
            // ColourComboBox
            // 
            this.ColourComboBox.FormattingEnabled = true;
            this.ColourComboBox.Location = new System.Drawing.Point(744, 47);
            this.ColourComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ColourComboBox.Name = "ColourComboBox";
            this.ColourComboBox.Size = new System.Drawing.Size(237, 24);
            this.ColourComboBox.TabIndex = 7;
            this.ColourComboBox.TextChanged += new System.EventHandler(this.ColourComboBox_TextChanged);
            // 
            // ModelTextBox
            // 
            this.ModelTextBox.Location = new System.Drawing.Point(477, 48);
            this.ModelTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ModelTextBox.Name = "ModelTextBox";
            this.ModelTextBox.Size = new System.Drawing.Size(237, 22);
            this.ModelTextBox.TabIndex = 9;
            this.ModelTextBox.TextChanged += new System.EventHandler(this.ModelTextBox_TextChanged);
            // 
            // BuyCheckBox
            // 
            this.BuyCheckBox.AutoSize = true;
            this.BuyCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.BuyCheckBox.Location = new System.Drawing.Point(1145, 50);
            this.BuyCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BuyCheckBox.Name = "BuyCheckBox";
            this.BuyCheckBox.Size = new System.Drawing.Size(91, 20);
            this.BuyCheckBox.TabIndex = 10;
            this.BuyCheckBox.Text = "Докупить";
            this.BuyCheckBox.UseVisualStyleBackColor = false;
            this.BuyCheckBox.CheckedChanged += new System.EventHandler(this.BuyCheckBox_CheckedChanged);
            // 
            // ClientUsedCheckBox
            // 
            this.ClientUsedCheckBox.AutoSize = true;
            this.ClientUsedCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.ClientUsedCheckBox.Location = new System.Drawing.Point(1007, 50);
            this.ClientUsedCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClientUsedCheckBox.Name = "ClientUsedCheckBox";
            this.ClientUsedCheckBox.Size = new System.Drawing.Size(123, 20);
            this.ClientUsedCheckBox.TabIndex = 11;
            this.ClientUsedCheckBox.Text = "Исп. клиентом";
            this.ClientUsedCheckBox.UseVisualStyleBackColor = false;
            this.ClientUsedCheckBox.CheckedChanged += new System.EventHandler(this.ClientUsedCheckBox_CheckedChanged);
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 693);
            this.Controls.Add(this.ClientUsedCheckBox);
            this.Controls.Add(this.BuyCheckBox);
            this.Controls.Add(this.ModelTextBox);
            this.Controls.Add(this.ColourComboBox);
            this.Controls.Add(this.BrandComboBox);
            this.Controls.Add(this.AddZip);
            this.Controls.Add(this.StockListView);
            this.Controls.Add(this.PodKategoryComboBox);
            this.Controls.Add(this.KategoryComboBox);
            this.Controls.Add(this.StockSearchTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Склад";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Stock_FormClosed);
            this.Load += new System.EventHandler(this.Stock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

	}
}
