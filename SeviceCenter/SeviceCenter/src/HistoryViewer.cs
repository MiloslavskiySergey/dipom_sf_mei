// HistoryViewer

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class HistoryViewer : Form
{
	private ItemComparerHistory itemComparerHistory;

	public List<HistoryViewerListViewLoader> HistoryList = new List<HistoryViewerListViewLoader>();

	private Form1 mainForm;

	private bool dataSearcherRetriview = false;

	private IContainer components = null;

	private MonthCalendar monthCalendar1;

	private ComboBox UserComboBox1;

	private Label label1;

	private Label label2;

	private ComboBox GroupsComboBox1;

	public ListView HistoryListView;

	private ColumnHeader id;

	public ColumnHeader WHO;

	public ColumnHeader WHAT;

	public ColumnHeader FULLWHAT;

	public ColumnHeader Data;

	private Panel panel1;

	private Button SearchButton;

	private Panel panel2;

	private Button SearchDataButton;

	private DateTimePicker dateTimePicker2;

	private Label label3;

	private Label label5;

	private DateTimePicker dateTimePicker1;

	private Label label4;

	private Button ResetSearchButton;

	private TextBox FullWhatTextBox;

	public HistoryViewer(Form1 mf)
	{
		mainForm = mf;
		InitializeComponent();
		itemComparerHistory = new ItemComparerHistory(this);
		try
		{
			HistoryListView.ListViewItemSorter = itemComparerHistory;
			HistoryListView.ColumnClick += OnColumnClick;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void OnColumnClick(object sender, ColumnClickEventArgs e)
	{
		try
		{
			itemComparerHistory.ColumnIndex = e.Column;
			HistoryListView.VirtualListSize = HistoryList.Count;
			HistoryListView.VirtualListSize -= 1;
			HistoryListView.VirtualListSize += 1;
		}
		catch
		{
			MessageBox.Show("Нечего сортировать");
		}
	}

	private void HistoryViewer_Load(object sender, EventArgs e)
	{
		HistorySearcher();
		comboboxUsersMaker(UserComboBox1);
		comboboxGroupsMaker(GroupsComboBox1);
	}

	private void HistorySearcher(string fio = "", string date = "", string WHO = "", string WHAT = "")
	{
		HistoryListView.Items.Clear();
		HistoryList.Clear();
		DataTable dataTable = mainForm.basa.HISTORYSearchFIO(fio, date, WHO, WHAT);
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			if (dataSearcherRetriview)
			{
				if (DateTime.Parse(dataTable.Rows[i].ItemArray[4].ToString()) >= dateTimePicker1.Value && DateTime.Parse(dataTable.Rows[i].ItemArray[4].ToString()) <= dateTimePicker2.Value)
				{
					HistoryList.Add(new HistoryViewerListViewLoader(dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString()));
				}
			}
			else
			{
				HistoryList.Add(new HistoryViewerListViewLoader(dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString()));
			}
		}
		dataSearcherRetriview = false;
		HistoryListView.VirtualListSize = HistoryList.Count;
		if (HistoryListView.VirtualListSize > 0)
		{
			HistoryListView.VirtualListSize -= 1;
			HistoryListView.VirtualListSize += 1;
		}
	}

	private void ClientsListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		try
		{
			e.Item = new ListViewItem(HistoryList[e.ItemIndex].id);
			e.Item.SubItems.Add(HistoryList[e.ItemIndex].WHO);
			e.Item.SubItems.Add(HistoryList[e.ItemIndex].WHAT);
			e.Item.SubItems.Add(HistoryList[e.ItemIndex].FULLWHAT);
			e.Item.SubItems.Add(HistoryList[e.ItemIndex].data.ToString("dd-MM-yyyy HH:mm"));
			if (e.ItemIndex >= 0 && e.ItemIndex < HistoryList.Count && e.ItemIndex % 2 == 0)
			{
				e.Item.BackColor = Color.FromArgb(240, 240, 240);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
		dataSearcherRetriview = false;
	}

	private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
	{
		HistorySearcher("", monthCalendar1.SelectionStart.ToString("dd-MM-yyyy"));
	}

	private void comboboxGroupsMaker(ComboBox cmbox)
	{
		cmbox.Items.Clear();
		DataTable dataTable = mainForm.basa.GroupDostupBdRead();
		if (dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				cmbox.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
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

	private void SearchButton_Click(object sender, EventArgs e)
	{
		string fio = UserComboBox1.Text + " " + GroupsComboBox1.Text;
		HistorySearcher(fio);
	}

	private void SearchDataButton_Click(object sender, EventArgs e)
	{
		dataSearcherRetriview = true;
		HistorySearcher();
	}

	private void ResetSearchButton_Click(object sender, EventArgs e)
	{
		dataSearcherRetriview = false;
		HistorySearcher();
	}

	private void HistoryListView_MouseDoubleClick(object sender, MouseEventArgs e)
	{
	}

	private void HistoryListView_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (HistoryListView.SelectedIndices.Count > 0)
		{
			FullWhatTextBox.Text = HistoryListView.Items[HistoryListView.SelectedIndices[0]].SubItems[3].Text;
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
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.UserComboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.GroupsComboBox1 = new System.Windows.Forms.ComboBox();
			this.HistoryListView = new System.Windows.Forms.ListView();
			this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.WHO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.WHAT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FULLWHAT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.SearchButton = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.SearchDataButton = new System.Windows.Forms.Button();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.ResetSearchButton = new System.Windows.Forms.Button();
			this.FullWhatTextBox = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.monthCalendar1.Location = new System.Drawing.Point(948, 0);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 2;
			this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
			// 
			// UserComboBox1
			// 
			this.UserComboBox1.FormattingEnabled = true;
			this.UserComboBox1.Location = new System.Drawing.Point(5, 19);
			this.UserComboBox1.Name = "UserComboBox1";
			this.UserComboBox1.Size = new System.Drawing.Size(152, 21);
			this.UserComboBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(66, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Имя";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(40, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Группа доступа";
			// 
			// GroupsComboBox1
			// 
			this.GroupsComboBox1.FormattingEnabled = true;
			this.GroupsComboBox1.Location = new System.Drawing.Point(5, 59);
			this.GroupsComboBox1.Name = "GroupsComboBox1";
			this.GroupsComboBox1.Size = new System.Drawing.Size(152, 21);
			this.GroupsComboBox1.TabIndex = 3;
			// 
			// HistoryListView
			// 
			this.HistoryListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.HistoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.WHO,
            this.WHAT,
            this.FULLWHAT,
            this.Data});
			this.HistoryListView.FullRowSelect = true;
			this.HistoryListView.GridLines = true;
			this.HistoryListView.Location = new System.Drawing.Point(1, 1);
			this.HistoryListView.MultiSelect = false;
			this.HistoryListView.Name = "HistoryListView";
			this.HistoryListView.Size = new System.Drawing.Size(937, 501);
			this.HistoryListView.TabIndex = 1;
			this.HistoryListView.UseCompatibleStateImageBehavior = false;
			this.HistoryListView.View = System.Windows.Forms.View.Details;
			this.HistoryListView.VirtualMode = true;
			this.HistoryListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ClientsListView_RetrieveVirtualItem);
			this.HistoryListView.SelectedIndexChanged += new System.EventHandler(this.HistoryListView_SelectedIndexChanged);
			this.HistoryListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HistoryListView_MouseDoubleClick);
			// 
			// id
			// 
			this.id.Text = "id";
			this.id.Width = 40;
			// 
			// WHO
			// 
			this.WHO.Text = "Кто менял";
			this.WHO.Width = 200;
			// 
			// WHAT
			// 
			this.WHAT.Text = "Что менял";
			this.WHAT.Width = 150;
			// 
			// FULLWHAT
			// 
			this.FULLWHAT.Text = "Полный список изменений";
			this.FULLWHAT.Width = 381;
			// 
			// Data
			// 
			this.Data.Text = "Дата";
			this.Data.Width = 160;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.SearchButton);
			this.panel1.Controls.Add(this.GroupsComboBox1);
			this.panel1.Controls.Add(this.UserComboBox1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(948, 174);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(164, 144);
			this.panel1.TabIndex = 17;
			// 
			// SearchButton
			// 
			this.SearchButton.Location = new System.Drawing.Point(5, 95);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(152, 23);
			this.SearchButton.TabIndex = 5;
			this.SearchButton.Text = "Поиск";
			this.SearchButton.UseVisualStyleBackColor = true;
			this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.SearchDataButton);
			this.panel2.Controls.Add(this.dateTimePicker2);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.dateTimePicker1);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Location = new System.Drawing.Point(948, 333);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(164, 140);
			this.panel2.TabIndex = 18;
			// 
			// SearchDataButton
			// 
			this.SearchDataButton.Location = new System.Drawing.Point(5, 108);
			this.SearchDataButton.Name = "SearchDataButton";
			this.SearchDataButton.Size = new System.Drawing.Size(152, 23);
			this.SearchDataButton.TabIndex = 35;
			this.SearchDataButton.Text = "Поиск";
			this.SearchDataButton.UseVisualStyleBackColor = true;
			this.SearchDataButton.Click += new System.EventHandler(this.SearchDataButton_Click);
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker2.Location = new System.Drawing.Point(5, 73);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(152, 20);
			this.dateTimePicker2.TabIndex = 34;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(73, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(19, 13);
			this.label3.TabIndex = 32;
			this.label3.Text = "по";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(32, 4);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(99, 13);
			this.label5.TabIndex = 30;
			this.label5.Text = "Выберите период:";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(5, 37);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(152, 20);
			this.dateTimePicker1.TabIndex = 33;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(75, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(13, 13);
			this.label4.TabIndex = 31;
			this.label4.Text = "с";
			// 
			// ResetSearchButton
			// 
			this.ResetSearchButton.Location = new System.Drawing.Point(955, 481);
			this.ResetSearchButton.Name = "ResetSearchButton";
			this.ResetSearchButton.Size = new System.Drawing.Size(152, 23);
			this.ResetSearchButton.TabIndex = 19;
			this.ResetSearchButton.Text = "Сброс поиска";
			this.ResetSearchButton.UseVisualStyleBackColor = true;
			this.ResetSearchButton.Click += new System.EventHandler(this.ResetSearchButton_Click);
			// 
			// FullWhatTextBox
			// 
			this.FullWhatTextBox.Location = new System.Drawing.Point(1, 508);
			this.FullWhatTextBox.Multiline = true;
			this.FullWhatTextBox.Name = "FullWhatTextBox";
			this.FullWhatTextBox.Size = new System.Drawing.Size(1111, 112);
			this.FullWhatTextBox.TabIndex = 20;
			// 
			// HistoryViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1121, 621);
			this.Controls.Add(this.FullWhatTextBox);
			this.Controls.Add(this.ResetSearchButton);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.HistoryListView);
			this.Controls.Add(this.monthCalendar1);
			this.Name = "HistoryViewer";
			this.Text = "Просмотр истории";
			this.Load += new System.EventHandler(this.HistoryViewer_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}
}
