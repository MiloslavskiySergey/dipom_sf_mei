// States

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class States : Form
{
	private Form1 mainForm;

	private string id_client;

	private Editor editorForm;

	private IContainer components = null;

	public ListView StockListView;

	private ColumnHeader Number;

	public ColumnHeader Date;

	public ColumnHeader State;

	private ColumnHeader NumInBase;

	private Button DeleteStateButton1;

	public States(Form1 mf, string id_client, Editor ed1)
	{
		InitializeComponent();
		mainForm = mf;
		this.id_client = id_client;
		editorForm = ed1;
	}

	private void States_Load(object sender, EventArgs e)
	{
		mainForm.basa.StatesMapTable_Create();
		ListViewWriter(id_client);
	}

	public void ListViewWriter(string id_clent)
	{
		try
		{
			StockListView.Items.Clear();
			DataTable dataTable = mainForm.basa.StatesMapGiver(id_client);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				ListViewItem listViewItem = new ListViewItem((i + 1).ToString());
				listViewItem.SubItems.Add(dataTable.Rows[i].ItemArray[2].ToString());
				listViewItem.SubItems.Add(dataTable.Rows[i].ItemArray[3].ToString());
				listViewItem.SubItems.Add(dataTable.Rows[i].ItemArray[0].ToString());
				StockListView.Items.Add(listViewItem);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void DeleteStateButton1_Click(object sender, EventArgs e)
	{
		if (StockListView.SelectedIndices.Count > 0)
		{
			if (MessageBox.Show("Вы действительно хотите удалить статус номер: " + StockListView.Items[StockListView.SelectedIndices[0]].SubItems[0].Text, "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				mainForm.basa.StatesMapDelete(StockListView.Items[StockListView.SelectedIndices[0]].SubItems[3].Text);
				ListViewWriter(id_client);
				editorForm.DynamicLabelMaker();
			}
		}
		else
		{
			MessageBox.Show("Не выделено ни одной строки для удаления");
		}
	}

	private void States_FormClosed(object sender, FormClosedEventArgs e)
	{
		editorForm.Enabled = true;
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
			this.StockListView = new System.Windows.Forms.ListView();
			this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.NumInBase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DeleteStateButton1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// StockListView
			// 
			this.StockListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StockListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.Date,
            this.State,
            this.NumInBase});
			this.StockListView.FullRowSelect = true;
			this.StockListView.GridLines = true;
			this.StockListView.Location = new System.Drawing.Point(12, 12);
			this.StockListView.MultiSelect = false;
			this.StockListView.Name = "StockListView";
			this.StockListView.Size = new System.Drawing.Size(540, 213);
			this.StockListView.TabIndex = 4;
			this.StockListView.UseCompatibleStateImageBehavior = false;
			this.StockListView.View = System.Windows.Forms.View.Details;
			// 
			// Number
			// 
			this.Number.Text = "Номер";
			// 
			// Date
			// 
			this.Date.Text = "Дата";
			this.Date.Width = 160;
			// 
			// State
			// 
			this.State.Text = "Статус";
			this.State.Width = 315;
			// 
			// NumInBase
			// 
			this.NumInBase.Text = "Номер в базе";
			this.NumInBase.Width = 0;
			// 
			// DeleteStateButton1
			// 
			this.DeleteStateButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DeleteStateButton1.Location = new System.Drawing.Point(440, 231);
			this.DeleteStateButton1.Name = "DeleteStateButton1";
			this.DeleteStateButton1.Size = new System.Drawing.Size(112, 23);
			this.DeleteStateButton1.TabIndex = 5;
			this.DeleteStateButton1.Text = "Удалить";
			this.DeleteStateButton1.UseVisualStyleBackColor = true;
			this.DeleteStateButton1.Click += new System.EventHandler(this.DeleteStateButton1_Click);
			// 
			// States
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 261);
			this.Controls.Add(this.DeleteStateButton1);
			this.Controls.Add(this.StockListView);
			this.Name = "States";
			this.Text = "Состояние заказа";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.States_FormClosed);
			this.Load += new System.EventHandler(this.States_Load);
			this.ResumeLayout(false);

	}
}
