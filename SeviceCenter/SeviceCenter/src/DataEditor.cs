// DataEditor

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class DataEditor : Form
{
	private Form1 mainForm;

	private Editor ed1;

	private string id_bd;

	private IContainer components = null;

	private Button DeleteDataPredButton;

	private Button DataVidDeleteButton;

	private Label DataVidachiLabel;

	private Label DataPredoplatiLabel;

	private Label DataPriemaLabel;

	private Button SaveDataVidButton;

	private Button SaveDataPredButton;

	private Button SaveDataPriemaButton;

	private Label label3;

	private Label label2;

	private Label label1;

	private MonthCalendar DataVidachiCalendar;

	private MonthCalendar DataPredoplatiCalendar;

	private MonthCalendar DataPriemaCalendar;

	public Label label6;

	public DataEditor(Form1 mf, string id_bd, Editor ed)
	{
		mainForm = mf;
		this.id_bd = id_bd;
		ed1 = ed;
		InitializeComponent();
	}

	private void SaveDataPriemaButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Сохранить дату приёма?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.BdEditOne("Data_priema", DataPriemaCalendar.SelectionStart.ToString("dd-MM-yyyy HH:mm"), id_bd);
			DataPriemaLabel.Text = DataPriemaCalendar.SelectionStart.ToString("dd-MM-yyyy HH:mm");
			mainForm.StatusStripLabel.Text = "Дата приема записи номер " + id_bd + " изменена на " + DataPriemaCalendar.SelectionStart.ToString("dd-MM-yyyy HH:mm");
			TemporaryBase.SearchFULLBegin();
			mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Изменение даты приёма", "", id_bd);
		}
	}

	private void SaveDataVidButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Сохранить дату выдачи?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.BdEditOne("Data_vidachi", DataVidachiCalendar.SelectionStart.ToString("dd-MM-yyyy HH:mm"), id_bd);
			DataVidachiLabel.Text = DataVidachiCalendar.SelectionStart.ToString("dd-MM-yyyy HH:mm");
			mainForm.StatusStripLabel.Text = "Дата выдачи записи номер " + id_bd + " изменена на " + DataVidachiCalendar.SelectionStart.ToString("dd-MM-yyyy HH:mm");
			TemporaryBase.SearchFULLBegin();
			mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Изменение даты выдачи", "", id_bd);
		}
	}

	private void DataVidDeleteButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Удалить дату выдачи?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.BdEditOne("Data_vidachi", "", id_bd);
			DataVidachiLabel.Text = "Не указана";
			mainForm.StatusStripLabel.Text = "Дата выдачи записи номер " + id_bd + " удалена";
			TemporaryBase.SearchFULLBegin();
			mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Удаление даты выдачи", "", id_bd);
		}
	}

	private void SaveDataPredButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Сохранить дату предоплаты?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.BdEditOne("Data_predoplaty", DataPredoplatiCalendar.SelectionStart.ToString("dd-MM-yyyy HH:mm"), id_bd);
			DataPredoplatiLabel.Text = DataPredoplatiCalendar.SelectionStart.ToString("dd-MM-yyyy HH:mm");
			mainForm.StatusStripLabel.Text = "Дата предоплаты записи номер " + id_bd + " изменена на " + DataPredoplatiCalendar.SelectionStart.ToString("dd-MM-yyyy HH:mm");
			TemporaryBase.SearchFULLBegin();
			mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Сохранение даты предоплаты", "", id_bd);
		}
	}

	private void DeleteDataPredButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Удалить дату предоплаты?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.BdEditOne("Data_predoplaty", "", id_bd);
			DataPredoplatiLabel.Text = "Не указана";
			mainForm.StatusStripLabel.Text = "Дата предоплаты записи номер " + id_bd + " удалена";
			TemporaryBase.SearchFULLBegin();
			mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Удаление даты предоплаты", "", id_bd);
		}
	}

	private void DataEditor_MouseDown(object sender, MouseEventArgs e)
	{
		base.Capture = false;
		Message m = Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
		WndProc(ref m);
	}

	private void label6_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void DataEditor_Load(object sender, EventArgs e)
	{
		SaveDataPriemaButton.Enabled = ((TemporaryBase.editDates == "1") ? true : false);
		SaveDataPredButton.Enabled = ((TemporaryBase.editDates == "1") ? true : false);
		DeleteDataPredButton.Enabled = ((TemporaryBase.editDates == "1") ? true : false);
		SaveDataVidButton.Enabled = ((TemporaryBase.editDates == "1") ? true : false);
		DataVidDeleteButton.Enabled = ((TemporaryBase.editDates == "1") ? true : false);
		DataPriemaLabel.Text = labelDataWorker(mainForm.basa.BdReadOne("Data_priema", id_bd));
		DataPredoplatiLabel.Text = labelDataWorker(mainForm.basa.BdReadOne("Data_predoplaty", id_bd));
		DataVidachiLabel.Text = labelDataWorker(mainForm.basa.BdReadOne("Data_vidachi", id_bd));
		DateTime dateTime = DateTime.Parse(calendarDateWorker(mainForm.basa.BdReadOne("Data_priema", id_bd)));
		DateTime dateTime2 = DateTime.Parse(calendarDateWorker(mainForm.basa.BdReadOne("Data_predoplaty", id_bd)));
		DateTime dateTime3 = DateTime.Parse(calendarDateWorker(mainForm.basa.BdReadOne("Data_vidachi", id_bd)));
		DataPriemaCalendar.SelectionStart = dateTime;
		DataPriemaCalendar.SelectionEnd = dateTime;
		DataPredoplatiCalendar.SelectionStart = dateTime2;
		DataPredoplatiCalendar.SelectionEnd = dateTime2;
		DataVidachiCalendar.SelectionStart = dateTime3;
		DataVidachiCalendar.SelectionEnd = dateTime3;
	}

	private string labelDataWorker(string date)
	{
		if (date != "")
		{
			return date;
		}
		return "Не указана";
	}

	private string calendarDateWorker(string date)
	{
		if (date != "")
		{
			return date;
		}
		return DateTime.Now.ToString();
	}

	private void DataEditor_FormClosed(object sender, FormClosedEventArgs e)
	{
		ed1.Enabled = true;
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
		DeleteDataPredButton = new System.Windows.Forms.Button();
		DataVidDeleteButton = new System.Windows.Forms.Button();
		DataVidachiLabel = new System.Windows.Forms.Label();
		DataPredoplatiLabel = new System.Windows.Forms.Label();
		DataPriemaLabel = new System.Windows.Forms.Label();
		SaveDataVidButton = new System.Windows.Forms.Button();
		SaveDataPredButton = new System.Windows.Forms.Button();
		SaveDataPriemaButton = new System.Windows.Forms.Button();
		label3 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		DataVidachiCalendar = new System.Windows.Forms.MonthCalendar();
		DataPredoplatiCalendar = new System.Windows.Forms.MonthCalendar();
		DataPriemaCalendar = new System.Windows.Forms.MonthCalendar();
		label6 = new System.Windows.Forms.Label();
		SuspendLayout();
		DeleteDataPredButton.Location = new System.Drawing.Point(300, 203);
		DeleteDataPredButton.Name = "DeleteDataPredButton";
		DeleteDataPredButton.Size = new System.Drawing.Size(75, 24);
		DeleteDataPredButton.TabIndex = 27;
		DeleteDataPredButton.Text = "Удалить";
		DeleteDataPredButton.UseVisualStyleBackColor = true;
		DeleteDataPredButton.Click += new System.EventHandler(DeleteDataPredButton_Click);
		DataVidDeleteButton.Location = new System.Drawing.Point(499, 203);
		DataVidDeleteButton.Name = "DataVidDeleteButton";
		DataVidDeleteButton.Size = new System.Drawing.Size(75, 23);
		DataVidDeleteButton.TabIndex = 26;
		DataVidDeleteButton.Text = "Удалить";
		DataVidDeleteButton.UseVisualStyleBackColor = true;
		DataVidDeleteButton.Click += new System.EventHandler(DataVidDeleteButton_Click);
		DataVidachiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		DataVidachiLabel.Location = new System.Drawing.Point(409, 229);
		DataVidachiLabel.Name = "DataVidachiLabel";
		DataVidachiLabel.Size = new System.Drawing.Size(164, 16);
		DataVidachiLabel.TabIndex = 25;
		DataVidachiLabel.Text = "Не указана";
		DataVidachiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		DataPredoplatiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		DataPredoplatiLabel.Location = new System.Drawing.Point(211, 229);
		DataPredoplatiLabel.Name = "DataPredoplatiLabel";
		DataPredoplatiLabel.Size = new System.Drawing.Size(164, 16);
		DataPredoplatiLabel.TabIndex = 24;
		DataPredoplatiLabel.Text = "Не указана";
		DataPredoplatiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		DataPriemaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		DataPriemaLabel.Location = new System.Drawing.Point(9, 229);
		DataPriemaLabel.Name = "DataPriemaLabel";
		DataPriemaLabel.Size = new System.Drawing.Size(164, 16);
		DataPriemaLabel.TabIndex = 23;
		DataPriemaLabel.Text = "Не указана";
		DataPriemaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		SaveDataVidButton.Location = new System.Drawing.Point(409, 203);
		SaveDataVidButton.Name = "SaveDataVidButton";
		SaveDataVidButton.Size = new System.Drawing.Size(75, 23);
		SaveDataVidButton.TabIndex = 22;
		SaveDataVidButton.Text = "Сохранить";
		SaveDataVidButton.UseVisualStyleBackColor = true;
		SaveDataVidButton.Click += new System.EventHandler(SaveDataVidButton_Click);
		SaveDataPredButton.Location = new System.Drawing.Point(211, 203);
		SaveDataPredButton.Name = "SaveDataPredButton";
		SaveDataPredButton.Size = new System.Drawing.Size(74, 23);
		SaveDataPredButton.TabIndex = 21;
		SaveDataPredButton.Text = "Сохранить";
		SaveDataPredButton.UseVisualStyleBackColor = true;
		SaveDataPredButton.Click += new System.EventHandler(SaveDataPredButton_Click);
		SaveDataPriemaButton.Location = new System.Drawing.Point(9, 203);
		SaveDataPriemaButton.Name = "SaveDataPriemaButton";
		SaveDataPriemaButton.Size = new System.Drawing.Size(164, 23);
		SaveDataPriemaButton.TabIndex = 20;
		SaveDataPriemaButton.Text = "Сохранить";
		SaveDataPriemaButton.UseVisualStyleBackColor = true;
		SaveDataPriemaButton.Click += new System.EventHandler(SaveDataPriemaButton_Click);
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label3.Location = new System.Drawing.Point(449, 7);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(84, 13);
		label3.TabIndex = 19;
		label3.Text = "Дата выдачи";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label2.Location = new System.Drawing.Point(236, 7);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(112, 13);
		label2.TabIndex = 18;
		label2.Text = "Дата предоплаты";
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label1.Location = new System.Drawing.Point(50, 7);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(85, 13);
		label1.TabIndex = 17;
		label1.Text = "Дата приема";
		DataVidachiCalendar.Location = new System.Drawing.Point(410, 29);
		DataVidachiCalendar.Name = "DataVidachiCalendar";
		DataVidachiCalendar.TabIndex = 16;
		DataPredoplatiCalendar.Location = new System.Drawing.Point(211, 29);
		DataPredoplatiCalendar.Name = "DataPredoplatiCalendar";
		DataPredoplatiCalendar.TabIndex = 15;
		DataPriemaCalendar.Location = new System.Drawing.Point(9, 29);
		DataPriemaCalendar.Name = "DataPriemaCalendar";
		DataPriemaCalendar.TabIndex = 14;
		label6.AutoSize = true;
		label6.Cursor = System.Windows.Forms.Cursors.Hand;
		label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		label6.ForeColor = System.Drawing.Color.Red;
		label6.Location = new System.Drawing.Point(561, 2);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(22, 22);
		label6.TabIndex = 186;
		label6.Text = "X";
		label6.Click += new System.EventHandler(label6_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
		base.ClientSize = new System.Drawing.Size(583, 254);
		base.Controls.Add(label6);
		base.Controls.Add(DeleteDataPredButton);
		base.Controls.Add(DataVidDeleteButton);
		base.Controls.Add(DataVidachiLabel);
		base.Controls.Add(DataPredoplatiLabel);
		base.Controls.Add(DataPriemaLabel);
		base.Controls.Add(SaveDataVidButton);
		base.Controls.Add(SaveDataPredButton);
		base.Controls.Add(SaveDataPriemaButton);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(DataVidachiCalendar);
		base.Controls.Add(DataPredoplatiCalendar);
		base.Controls.Add(DataPriemaCalendar);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.Name = "DataEditor";
		Text = "Редактирование дат";
		base.TopMost = true;
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(DataEditor_FormClosed);
		base.Load += new System.EventHandler(DataEditor_Load);
		base.MouseDown += new System.Windows.Forms.MouseEventHandler(DataEditor_MouseDown);
		ResumeLayout(false);
		PerformLayout();
	}
}
