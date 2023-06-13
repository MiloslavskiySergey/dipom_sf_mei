// DataEditor

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class DataEditor : Form
{
	private MainForm mainForm;

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

	public DataEditor(MainForm mf, string id_bd, Editor ed)
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
            this.DeleteDataPredButton = new System.Windows.Forms.Button();
            this.DataVidDeleteButton = new System.Windows.Forms.Button();
            this.DataVidachiLabel = new System.Windows.Forms.Label();
            this.DataPredoplatiLabel = new System.Windows.Forms.Label();
            this.DataPriemaLabel = new System.Windows.Forms.Label();
            this.SaveDataVidButton = new System.Windows.Forms.Button();
            this.SaveDataPredButton = new System.Windows.Forms.Button();
            this.SaveDataPriemaButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DataVidachiCalendar = new System.Windows.Forms.MonthCalendar();
            this.DataPredoplatiCalendar = new System.Windows.Forms.MonthCalendar();
            this.DataPriemaCalendar = new System.Windows.Forms.MonthCalendar();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DeleteDataPredButton
            // 
            this.DeleteDataPredButton.Location = new System.Drawing.Point(400, 250);
            this.DeleteDataPredButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeleteDataPredButton.Name = "DeleteDataPredButton";
            this.DeleteDataPredButton.Size = new System.Drawing.Size(100, 30);
            this.DeleteDataPredButton.TabIndex = 27;
            this.DeleteDataPredButton.Text = "Удалить";
            this.DeleteDataPredButton.UseVisualStyleBackColor = true;
            this.DeleteDataPredButton.Click += new System.EventHandler(this.DeleteDataPredButton_Click);
            // 
            // DataVidDeleteButton
            // 
            this.DataVidDeleteButton.Location = new System.Drawing.Point(665, 250);
            this.DataVidDeleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataVidDeleteButton.Name = "DataVidDeleteButton";
            this.DataVidDeleteButton.Size = new System.Drawing.Size(100, 28);
            this.DataVidDeleteButton.TabIndex = 26;
            this.DataVidDeleteButton.Text = "Удалить";
            this.DataVidDeleteButton.UseVisualStyleBackColor = true;
            this.DataVidDeleteButton.Click += new System.EventHandler(this.DataVidDeleteButton_Click);
            // 
            // DataVidachiLabel
            // 
            this.DataVidachiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DataVidachiLabel.Location = new System.Drawing.Point(545, 282);
            this.DataVidachiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DataVidachiLabel.Name = "DataVidachiLabel";
            this.DataVidachiLabel.Size = new System.Drawing.Size(219, 20);
            this.DataVidachiLabel.TabIndex = 25;
            this.DataVidachiLabel.Text = "Не указана";
            this.DataVidachiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataPredoplatiLabel
            // 
            this.DataPredoplatiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DataPredoplatiLabel.Location = new System.Drawing.Point(281, 282);
            this.DataPredoplatiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DataPredoplatiLabel.Name = "DataPredoplatiLabel";
            this.DataPredoplatiLabel.Size = new System.Drawing.Size(219, 20);
            this.DataPredoplatiLabel.TabIndex = 24;
            this.DataPredoplatiLabel.Text = "Не указана";
            this.DataPredoplatiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataPriemaLabel
            // 
            this.DataPriemaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DataPriemaLabel.Location = new System.Drawing.Point(12, 282);
            this.DataPriemaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DataPriemaLabel.Name = "DataPriemaLabel";
            this.DataPriemaLabel.Size = new System.Drawing.Size(219, 20);
            this.DataPriemaLabel.TabIndex = 23;
            this.DataPriemaLabel.Text = "Не указана";
            this.DataPriemaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveDataVidButton
            // 
            this.SaveDataVidButton.Location = new System.Drawing.Point(545, 250);
            this.SaveDataVidButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveDataVidButton.Name = "SaveDataVidButton";
            this.SaveDataVidButton.Size = new System.Drawing.Size(100, 28);
            this.SaveDataVidButton.TabIndex = 22;
            this.SaveDataVidButton.Text = "Сохранить";
            this.SaveDataVidButton.UseVisualStyleBackColor = true;
            this.SaveDataVidButton.Click += new System.EventHandler(this.SaveDataVidButton_Click);
            // 
            // SaveDataPredButton
            // 
            this.SaveDataPredButton.Location = new System.Drawing.Point(281, 250);
            this.SaveDataPredButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveDataPredButton.Name = "SaveDataPredButton";
            this.SaveDataPredButton.Size = new System.Drawing.Size(99, 28);
            this.SaveDataPredButton.TabIndex = 21;
            this.SaveDataPredButton.Text = "Сохранить";
            this.SaveDataPredButton.UseVisualStyleBackColor = true;
            this.SaveDataPredButton.Click += new System.EventHandler(this.SaveDataPredButton_Click);
            // 
            // SaveDataPriemaButton
            // 
            this.SaveDataPriemaButton.Location = new System.Drawing.Point(12, 250);
            this.SaveDataPriemaButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveDataPriemaButton.Name = "SaveDataPriemaButton";
            this.SaveDataPriemaButton.Size = new System.Drawing.Size(219, 28);
            this.SaveDataPriemaButton.TabIndex = 20;
            this.SaveDataPriemaButton.Text = "Сохранить";
            this.SaveDataPriemaButton.UseVisualStyleBackColor = true;
            this.SaveDataPriemaButton.Click += new System.EventHandler(this.SaveDataPriemaButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(599, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Дата выдачи";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(315, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Дата предоплаты";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(67, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Дата приема";
            // 
            // DataVidachiCalendar
            // 
            this.DataVidachiCalendar.Location = new System.Drawing.Point(547, 36);
            this.DataVidachiCalendar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.DataVidachiCalendar.Name = "DataVidachiCalendar";
            this.DataVidachiCalendar.TabIndex = 16;
            // 
            // DataPredoplatiCalendar
            // 
            this.DataPredoplatiCalendar.Location = new System.Drawing.Point(281, 36);
            this.DataPredoplatiCalendar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.DataPredoplatiCalendar.Name = "DataPredoplatiCalendar";
            this.DataPredoplatiCalendar.TabIndex = 15;
            // 
            // DataPriemaCalendar
            // 
            this.DataPriemaCalendar.Location = new System.Drawing.Point(12, 36);
            this.DataPriemaCalendar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.DataPriemaCalendar.Name = "DataPriemaCalendar";
            this.DataPriemaCalendar.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(748, 2);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 26);
            this.label6.TabIndex = 186;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // DataEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(777, 313);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DeleteDataPredButton);
            this.Controls.Add(this.DataVidDeleteButton);
            this.Controls.Add(this.DataVidachiLabel);
            this.Controls.Add(this.DataPredoplatiLabel);
            this.Controls.Add(this.DataPriemaLabel);
            this.Controls.Add(this.SaveDataVidButton);
            this.Controls.Add(this.SaveDataPredButton);
            this.Controls.Add(this.SaveDataPriemaButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataVidachiCalendar);
            this.Controls.Add(this.DataPredoplatiCalendar);
            this.Controls.Add(this.DataPriemaCalendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "DataEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование дат";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataEditor_FormClosed);
            this.Load += new System.EventHandler(this.DataEditor_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataEditor_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

	}
}
