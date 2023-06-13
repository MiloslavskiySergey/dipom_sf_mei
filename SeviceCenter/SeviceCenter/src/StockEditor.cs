// StockEditor

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class StockEditor : Form
{
	private MainForm mainForm;

	private string idOfZip = "0";

	private string photoPath = "";

	private string photoPath2 = "";

	private string photoPath3 = "";

	private int photoShow = 0;

	private int maxPhoto = 0;

	private string idInMainBd = "-1";

	private Stock stockForm;

	private ZIP zip;

	private Editor editorForm = null;

	private string clientId = "";

	private bool firstclick = true;

	private IContainer components = null;

	private PictureBox pictureBox1;

	private Panel PicturePanel1;

	private OpenFileDialog openFileDialog1;

	private Button UseZipButton;

	private Label FIOLabel;

	private NumericUpDown CountOfZIPNumericUpDown;

	private Label label11;

	private Panel ZIPUSEPANEL;

	private Panel ZIPPANEL;

	private Button DeletePhotoButton3;

	private Button DeletePhotoButton2;

	private Button DeletePhotoButton1;

	private Button StockEditorPhotoEditButton3;

	private Button StockEditorPhotoEditButton2;

	private Button DeleteStockButton1;

	private Button SaveStockButton;

	private Button StockEditorPhotoEditButton1;

	private Label label9;

	private TextBox PriceTextBox;

	private Label label8;

	private Label label7;

	private Label label6;

	private Label label5;

	private Label label4;

	private Label label3;

	private Label label2;

	private TextBox NapominanieTextBox;

	private Label label1;

	private TextBox CountOfTextBox;

	private TextBox ModelTextBox;

	private ComboBox ColourComboBox;

	private ComboBox BrandComboBox;

	private ComboBox PodKategoryComboBox;

	private ComboBox KategoryComboBox;

	private TextBox PrimechanieTextBox;

	private Button CancelZIPButton;

	private Label UsedZipCounterLabel;

	public StockEditor(MainForm mf, string idOfZip, Stock st1, string idInMainBd = "-1", Editor ed1 = null, string clientId = "")
	{
		InitializeComponent();
		mainForm = mf;
		this.idOfZip = idOfZip;
		stockForm = st1;
		this.idInMainBd = idInMainBd;
		editorForm = ed1;
		this.clientId = clientId;
	}

	private void StockEditor_Load(object sender, EventArgs e)
	{
		SaveStockButton.Enabled = ((TemporaryBase.stockEdit == "1") ? true : false);
		DeleteStockButton1.Enabled = ((TemporaryBase.stockDel == "1") ? true : false);
		if (idInMainBd != "-1" && clientId != "")
		{
			FIOLabel.Text = "ФИО клента: " + mainForm.basa.ClientsReadOne("FIO", clientId);
			if (!mainForm.basa.BdStockMapZIPUsedCheck(idInMainBd, idOfZip))
			{
				CancelZIPButton.Enabled = false;
			}
			UsedZIPCounterLabelUpdate();
		}
		else
		{
			CancelZIPButton.Enabled = false;
		}
		StockEdShower();
		stockForm.Enabled = false;
		Text = "Склад: Редактирование запчисти Арт. " + idOfZip;
	}

	private void StockEdShower()
	{
		try
		{
			DataTable dataTable = mainForm.basa.BdStockEditor(idOfZip);
			int index = 0;
			zip = new ZIP(dataTable.Rows[index].ItemArray[1].ToString(), dataTable.Rows[index].ItemArray[4].ToString(), dataTable.Rows[index].ItemArray[5].ToString(), dataTable.Rows[index].ItemArray[6].ToString(), dataTable.Rows[index].ItemArray[7].ToString(), dataTable.Rows[index].ItemArray[8].ToString(), dataTable.Rows[index].ItemArray[0].ToString(), dataTable.Rows[index].ItemArray[10].ToString(), dataTable.Rows[index].ItemArray[2].ToString(), dataTable.Rows[index].ItemArray[3].ToString(), dataTable.Rows[index].ItemArray[9].ToString(), dataTable.Rows[index].ItemArray[11].ToString(), dataTable.Rows[index].ItemArray[12].ToString(), dataTable.Rows[index].ItemArray[13].ToString());
			if (zip.photo != "" && File.Exists(zip.photo))
			{
				FileStream fileStream = new FileStream(zip.photo, FileMode.Open, FileAccess.Read);
				pictureBox1.Image = Image.FromStream(fileStream);
				pictureBox1.Invalidate();
				photoShow = 1;
				fileStream.Close();
				StockEditorPhotoEditButton1.Text = zip.photo;
				photoPath = zip.photo;
			}
			if (zip.photo2 != "" && File.Exists(zip.photo2))
			{
				StockEditorPhotoEditButton2.Text = zip.photo2;
				photoPath2 = zip.photo2;
				if (!File.Exists(zip.photo))
				{
					FileStream fileStream2 = new FileStream(zip.photo2, FileMode.Open, FileAccess.Read);
					pictureBox1.Image = Image.FromStream(fileStream2);
					pictureBox1.Invalidate();
					fileStream2.Close();
				}
			}
			if (zip.photo3 != "" && File.Exists(zip.photo3))
			{
				StockEditorPhotoEditButton3.Text = zip.photo3;
				photoPath3 = zip.photo3;
				if (!File.Exists(zip.photo) && !File.Exists(zip.photo2))
				{
					FileStream fileStream3 = new FileStream(zip.photo3, FileMode.Open, FileAccess.Read);
					pictureBox1.Image = Image.FromStream(fileStream3);
					pictureBox1.Invalidate();
					fileStream3.Close();
				}
			}
			PrimechanieTextBox.Text = zip.primechanie;
			KategoryComboBox.Text = zip.kategoriya;
			PodKategoryComboBox.Text = zip.podkategoriya;
			BrandComboBox.Text = zip.brand;
			ModelTextBox.Text = zip.model;
			ColourComboBox.Text = zip.colour;
			PriceTextBox.Text = zip.price;
			CountOfTextBox.Text = zip.countOf;
			NapominanieTextBox.Text = zip.napominanie;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void StockEditorPhotoEditButton_Click(object sender, EventArgs e)
	{
		openFileDialog1.Filter = "Файлы изображений|*.bmp;*.jpg;*.jpeg;*.png";
		openFileDialog1.ShowDialog();
		if (File.Exists(openFileDialog1.FileName))
		{
			StockEditorPhotoEditButton1.Text = openFileDialog1.FileName;
			pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
			pictureBox1.Invalidate();
			string str = openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4);
			string destFileName = "settings\\Stock\\Photos\\" + Path.GetRandomFileName() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + str;
			File.Copy(openFileDialog1.FileName, destFileName);
			photoPath = destFileName;
		}
		if (StockEditorPhotoEditButton1.Text == "openFileDialog1")
		{
			StockEditorPhotoEditButton1.Text = "Не загружено";
			photoPath = "";
		}
		openFileDialog1.FileName = "openFileDialog1";
	}

	private void SaveStockButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Сохранить запись Арт. " + idOfZip + " в складe?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.BdStockEdit(NaimenovanieMaker(), KategoryComboBox.Text, PodKategoryComboBox.Text, ColourComboBox.Text, BrandComboBox.Text, ModelTextBox.Text, CountOfTextBox.Text, NapominanieTextBox.Text, PriceTextBox.Text, photoPath, idOfZip, PrimechanieTextBox.Text, photoPath2, photoPath3);
			Close();
		}
	}

	private string NaimenovanieMaker()
	{
		if (PrimechanieTextBox.Text != "")
		{
			return KategoryComboBox.Text + " " + PodKategoryComboBox.Text + " " + BrandComboBox.Text + " " + ModelTextBox.Text + " " + ColourComboBox.Text + " (" + PrimechanieTextBox.Text + ")";
		}
		return KategoryComboBox.Text + " " + PodKategoryComboBox.Text + " " + BrandComboBox.Text + " " + ModelTextBox.Text + " " + ColourComboBox.Text + " " + PrimechanieTextBox.Text;
	}

	private void DeleteStockButton1_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Удалить запись Арт. " + idOfZip + " из склада?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.BdStockDelete(idOfZip);
			Close();
		}
	}

	private void StockEditor_FormClosed(object sender, FormClosedEventArgs e)
	{
		stockForm.Enabled = true;
		stockForm.StockFullSearch();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		openFileDialog1.Filter = "Файлы изображений|*.bmp;*.jpg;*.jpeg;*.png";
		openFileDialog1.ShowDialog();
		if (File.Exists(openFileDialog1.FileName))
		{
			StockEditorPhotoEditButton2.Text = openFileDialog1.FileName;
			pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
			pictureBox1.Invalidate();
			string str = openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4);
			string destFileName = "settings\\Stock\\Photos\\" + Path.GetRandomFileName() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + str;
			File.Copy(openFileDialog1.FileName, destFileName);
			photoPath2 = destFileName;
		}
		if (StockEditorPhotoEditButton2.Text == "openFileDialog1")
		{
			StockEditorPhotoEditButton2.Text = "Не загружено";
			photoPath2 = "";
		}
		openFileDialog1.FileName = "openFileDialog1";
	}

	private void button2_Click(object sender, EventArgs e)
	{
		openFileDialog1.Filter = "Файлы изображений|*.bmp;*.jpg;*.jpeg;*.png";
		openFileDialog1.ShowDialog();
		if (File.Exists(openFileDialog1.FileName))
		{
			StockEditorPhotoEditButton3.Text = openFileDialog1.FileName;
			pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
			pictureBox1.Invalidate();
			string str = openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4);
			string destFileName = "settings\\Stock\\Photos\\" + Path.GetRandomFileName() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + str;
			File.Copy(openFileDialog1.FileName, destFileName);
			photoPath3 = destFileName;
		}
		if (StockEditorPhotoEditButton3.Text == "openFileDialog1")
		{
			StockEditorPhotoEditButton3.Text = "Не загружено";
			photoPath3 = "";
		}
		openFileDialog1.FileName = "openFileDialog1";
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		try
		{
			if (photoPath != "")
			{
				maxPhoto = 1;
			}
			if (photoPath2 != "")
			{
				maxPhoto = 2;
			}
			if (photoPath3 != "")
			{
				maxPhoto = 3;
			}
			if (maxPhoto > 0)
			{
				photoShow++;
			}
			if (photoShow != 0)
			{
				if (photoShow > maxPhoto)
				{
					photoShow = 1;
				}
				if (firstclick)
				{
					photoShow = 1;
					photoShow++;
					firstclick = false;
				}
				if (photoShow == 1 && photoPath != "" && File.Exists(photoPath))
				{
					FileStream fileStream = new FileStream(photoPath, FileMode.Open, FileAccess.Read);
					pictureBox1.Image = Image.FromStream(fileStream);
					pictureBox1.Invalidate();
					fileStream.Close();
				}
				else if (photoShow == 2 && photoPath2 != "" && File.Exists(photoPath2))
				{
					FileStream fileStream2 = new FileStream(photoPath2, FileMode.Open, FileAccess.Read);
					pictureBox1.Image = Image.FromStream(fileStream2);
					pictureBox1.Invalidate();
					fileStream2.Close();
				}
				else if (photoShow == 3 && photoPath3 != "" && File.Exists(photoPath3))
				{
					FileStream fileStream3 = new FileStream(photoPath3, FileMode.Open, FileAccess.Read);
					pictureBox1.Image = Image.FromStream(fileStream3);
					pictureBox1.Invalidate();
					fileStream3.Close();
				}
				else
				{
					photoShow++;
					if (photoShow == 1 && photoPath != "" && File.Exists(photoPath))
					{
						FileStream fileStream4 = new FileStream(photoPath, FileMode.Open, FileAccess.Read);
						pictureBox1.Image = Image.FromStream(fileStream4);
						pictureBox1.Invalidate();
						fileStream4.Close();
					}
					else if (photoShow == 2 && photoPath2 != "" && File.Exists(photoPath2))
					{
						FileStream fileStream5 = new FileStream(photoPath2, FileMode.Open, FileAccess.Read);
						pictureBox1.Image = Image.FromStream(fileStream5);
						pictureBox1.Invalidate();
						fileStream5.Close();
					}
					else if (photoShow == 3 && photoPath3 != "" && File.Exists(photoPath3))
					{
						FileStream fileStream6 = new FileStream(photoPath3, FileMode.Open, FileAccess.Read);
						pictureBox1.Image = Image.FromStream(fileStream6);
						pictureBox1.Invalidate();
						fileStream6.Close();
					}
				}
			}
		}
		catch
		{
			MessageBox.Show("Для нормального пролистывания фото, нужно соблюдать очередность при добавлении фото, сначала 1, потом 2, потом 3");
		}
	}

	private void DeletePhotoButton1_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Удалить фото 1? Так же будет удалён файл фото с компьютера", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			StockEditorPhotoEditButton1.Text = "Загрузить фото 1";
			if (photoShow == 1 && pictureBox1.Image != null)
			{
				pictureBox1.Image.Dispose();
				pictureBox1.Image = null;
			}
			if (File.Exists(photoPath))
			{
				File.Delete(photoPath);
			}
			photoPath = "";
		}
	}

	private void DeletePhotoButton2_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Удалить фото 2? Так же будет удалён файл фото с компьютера", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			StockEditorPhotoEditButton2.Text = "Загрузить фото 2";
			if (photoShow == 2 && pictureBox1.Image != null)
			{
				pictureBox1.Image.Dispose();
				pictureBox1.Image = null;
			}
			if (File.Exists(photoPath2))
			{
				File.Delete(photoPath2);
			}
			photoPath2 = "";
		}
	}

	private void DeletePhotoButton3_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Удалить фото 3? Так же будет удалён файл фото с компьютера", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			StockEditorPhotoEditButton3.Text = "Загрузить фото 3";
			if (photoShow == 3 && pictureBox1.Image != null)
			{
				pictureBox1.Image.Dispose();
				pictureBox1.Image = null;
			}
			if (File.Exists(photoPath3))
			{
				File.Delete(photoPath3);
			}
			photoPath3 = "";
		}
	}

	private void UsedZIPCounterLabelUpdate()
	{
		if (int.Parse(idInMainBd) > -1)
		{
			UsedZipCounterLabel.Text = string.Format("Запчастей с арт. {0} использовано на клиента {1}: {2} Шт. ", idOfZip, mainForm.basa.ClientsReadOne("FIO", clientId), mainForm.basa.BdStockMapZIPUsedCoutner(idInMainBd, idOfZip));
		}
	}

	private void UseZipButton_Click(object sender, EventArgs e)
	{
		if (int.Parse(idInMainBd) > 0)
		{
			if (CountOfZIPNumericUpDown.Value > decimal.Zero)
			{
				if ((decimal)int.Parse(CountOfTextBox.Text) >= CountOfZIPNumericUpDown.Value)
				{
					if (MessageBox.Show("Вы действительно хотите использовать запчать  Арт. " + idOfZip + " для клиента: " + mainForm.basa.ClientsReadOne("FIO", clientId) + " В количестве " + CountOfZIPNumericUpDown.Value.ToString() + "Шт.", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK && editorForm != null)
					{
						editorForm.ZatratyTextBox.Text = ((decimal)int.Parse(editorForm.ZatratyTextBox.Text) + (decimal)int.Parse(PriceTextBox.Text) * CountOfZIPNumericUpDown.Value).ToString();
						string text = ((decimal)int.Parse(CountOfTextBox.Text) - CountOfZIPNumericUpDown.Value).ToString();
						CountOfTextBox.Text = text;
						mainForm.basa.BdStockMapWrite(idInMainBd, idOfZip, CountOfZIPNumericUpDown.Value.ToString(), PriceTextBox.Text);
						mainForm.basa.BdStockEditOne("CountOf", text, idOfZip);
						if (mainForm.basa.BdStockMapZIPUsedCheck(idInMainBd, idOfZip))
						{
							CancelZIPButton.Enabled = true;
						}
						mainForm.basa.BdEditOne("Zatrati", editorForm.ZatratyTextBox.Text, idInMainBd);
						UsedZIPCounterLabelUpdate();
					}
				}
				else
				{
					MessageBox.Show("На скалде нет столько " + NaimenovanieMaker() + ", сколько вы указали в затраты");
				}
			}
			else
			{
				MessageBox.Show("Вы не можете добавить к заказу 0 запчастей! Минимум 1");
			}
		}
		else
		{
			MessageBox.Show("Клиент не выбран");
		}
	}

	private void CancelZIPButton_Click(object sender, EventArgs e)
	{
		try
		{
			if (MessageBox.Show("1. Удалятся все использования данной запчасти клиентом " + mainForm.basa.ClientsReadOne("FIO", clientId) + Environment.NewLine + "2. В складе прибавится количество " + NaimenovanieMaker() + ", которое было потрачено на этого клиента" + Environment.NewLine + "3. Все затраты, сделанные клиентом на эту запчасть, отменятся, изменения сохранятся только для данного клиента ", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				int num = 0;
				int num2 = 0;
				DataTable dataTable = mainForm.basa.BdStockMapZIPDeleteCounter(idInMainBd, idOfZip);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num += int.Parse(dataTable.Rows[i].ItemArray[3].ToString());
					num2 += int.Parse(dataTable.Rows[i].ItemArray[3].ToString()) * int.Parse(dataTable.Rows[i].ItemArray[4].ToString());
				}
				string text = (int.Parse(editorForm.ZatratyTextBox.Text) - num2).ToString();
				editorForm.ZatratyTextBox.Text = text;
				mainForm.basa.BdEditOne("Zatrati", text, idInMainBd);
				CountOfTextBox.Text = (int.Parse(CountOfTextBox.Text) + num).ToString();
				mainForm.basa.BdStockEditOne("CountOf", CountOfTextBox.Text, idOfZip);
				mainForm.basa.BdStockMapDeleteZIP(idInMainBd, idOfZip);
				UsedZIPCounterLabelUpdate();
				MessageBox.Show("Было восстановлено " + num.ToString() + " Запчастей" + Environment.NewLine + "Было списано из затрат " + num2 + " Денег");
			}
			if (!mainForm.basa.BdStockMapZIPUsedCheck(idInMainBd, idOfZip))
			{
				CancelZIPButton.Enabled = false;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
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
            this.PicturePanel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.UseZipButton = new System.Windows.Forms.Button();
            this.FIOLabel = new System.Windows.Forms.Label();
            this.CountOfZIPNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.ZIPUSEPANEL = new System.Windows.Forms.Panel();
            this.CancelZIPButton = new System.Windows.Forms.Button();
            this.ZIPPANEL = new System.Windows.Forms.Panel();
            this.DeletePhotoButton3 = new System.Windows.Forms.Button();
            this.DeletePhotoButton2 = new System.Windows.Forms.Button();
            this.DeletePhotoButton1 = new System.Windows.Forms.Button();
            this.StockEditorPhotoEditButton3 = new System.Windows.Forms.Button();
            this.StockEditorPhotoEditButton2 = new System.Windows.Forms.Button();
            this.DeleteStockButton1 = new System.Windows.Forms.Button();
            this.SaveStockButton = new System.Windows.Forms.Button();
            this.StockEditorPhotoEditButton1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NapominanieTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CountOfTextBox = new System.Windows.Forms.TextBox();
            this.ModelTextBox = new System.Windows.Forms.TextBox();
            this.ColourComboBox = new System.Windows.Forms.ComboBox();
            this.BrandComboBox = new System.Windows.Forms.ComboBox();
            this.PodKategoryComboBox = new System.Windows.Forms.ComboBox();
            this.KategoryComboBox = new System.Windows.Forms.ComboBox();
            this.PrimechanieTextBox = new System.Windows.Forms.TextBox();
            this.UsedZipCounterLabel = new System.Windows.Forms.Label();
            this.PicturePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountOfZIPNumericUpDown)).BeginInit();
            this.ZIPUSEPANEL.SuspendLayout();
            this.ZIPPANEL.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicturePanel1
            // 
            this.PicturePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicturePanel1.AutoScroll = true;
            this.PicturePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicturePanel1.Controls.Add(this.pictureBox1);
            this.PicturePanel1.Location = new System.Drawing.Point(601, 14);
            this.PicturePanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PicturePanel1.Name = "PicturePanel1";
            this.PicturePanel1.Size = new System.Drawing.Size(642, 679);
            this.PicturePanel1.TabIndex = 49;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(17, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 254);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UseZipButton
            // 
            this.UseZipButton.Location = new System.Drawing.Point(9, 92);
            this.UseZipButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UseZipButton.Name = "UseZipButton";
            this.UseZipButton.Size = new System.Drawing.Size(547, 28);
            this.UseZipButton.TabIndex = 58;
            this.UseZipButton.Text = "Использовать запчасть(и)";
            this.UseZipButton.UseVisualStyleBackColor = true;
            this.UseZipButton.Click += new System.EventHandler(this.UseZipButton_Click);
            // 
            // FIOLabel
            // 
            this.FIOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FIOLabel.Location = new System.Drawing.Point(15, 16);
            this.FIOLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FIOLabel.Name = "FIOLabel";
            this.FIOLabel.Size = new System.Drawing.Size(541, 16);
            this.FIOLabel.TabIndex = 59;
            this.FIOLabel.Text = "Клиент не выбран";
            this.FIOLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CountOfZIPNumericUpDown
            // 
            this.CountOfZIPNumericUpDown.Location = new System.Drawing.Point(429, 53);
            this.CountOfZIPNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CountOfZIPNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.CountOfZIPNumericUpDown.Name = "CountOfZIPNumericUpDown";
            this.CountOfZIPNumericUpDown.Size = new System.Drawing.Size(127, 22);
            this.CountOfZIPNumericUpDown.TabIndex = 60;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(96, 55);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(306, 17);
            this.label11.TabIndex = 61;
            this.label11.Text = "Количество использованных запчастей";
            // 
            // ZIPUSEPANEL
            // 
            this.ZIPUSEPANEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ZIPUSEPANEL.Controls.Add(this.CancelZIPButton);
            this.ZIPUSEPANEL.Controls.Add(this.FIOLabel);
            this.ZIPUSEPANEL.Controls.Add(this.label11);
            this.ZIPUSEPANEL.Controls.Add(this.CountOfZIPNumericUpDown);
            this.ZIPUSEPANEL.Controls.Add(this.UseZipButton);
            this.ZIPUSEPANEL.Location = new System.Drawing.Point(13, 428);
            this.ZIPUSEPANEL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ZIPUSEPANEL.Name = "ZIPUSEPANEL";
            this.ZIPUSEPANEL.Size = new System.Drawing.Size(575, 167);
            this.ZIPUSEPANEL.TabIndex = 62;
            // 
            // CancelZIPButton
            // 
            this.CancelZIPButton.Location = new System.Drawing.Point(9, 128);
            this.CancelZIPButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CancelZIPButton.Name = "CancelZIPButton";
            this.CancelZIPButton.Size = new System.Drawing.Size(547, 28);
            this.CancelZIPButton.TabIndex = 62;
            this.CancelZIPButton.Text = "Отменить использования запчасти данным клиентом";
            this.CancelZIPButton.UseVisualStyleBackColor = true;
            this.CancelZIPButton.Click += new System.EventHandler(this.CancelZIPButton_Click);
            // 
            // ZIPPANEL
            // 
            this.ZIPPANEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ZIPPANEL.Controls.Add(this.DeletePhotoButton3);
            this.ZIPPANEL.Controls.Add(this.DeletePhotoButton2);
            this.ZIPPANEL.Controls.Add(this.DeletePhotoButton1);
            this.ZIPPANEL.Controls.Add(this.StockEditorPhotoEditButton3);
            this.ZIPPANEL.Controls.Add(this.StockEditorPhotoEditButton2);
            this.ZIPPANEL.Controls.Add(this.DeleteStockButton1);
            this.ZIPPANEL.Controls.Add(this.SaveStockButton);
            this.ZIPPANEL.Controls.Add(this.StockEditorPhotoEditButton1);
            this.ZIPPANEL.Controls.Add(this.label9);
            this.ZIPPANEL.Controls.Add(this.PriceTextBox);
            this.ZIPPANEL.Controls.Add(this.label8);
            this.ZIPPANEL.Controls.Add(this.label7);
            this.ZIPPANEL.Controls.Add(this.label6);
            this.ZIPPANEL.Controls.Add(this.label5);
            this.ZIPPANEL.Controls.Add(this.label4);
            this.ZIPPANEL.Controls.Add(this.label3);
            this.ZIPPANEL.Controls.Add(this.label2);
            this.ZIPPANEL.Controls.Add(this.NapominanieTextBox);
            this.ZIPPANEL.Controls.Add(this.label1);
            this.ZIPPANEL.Controls.Add(this.CountOfTextBox);
            this.ZIPPANEL.Controls.Add(this.ModelTextBox);
            this.ZIPPANEL.Controls.Add(this.ColourComboBox);
            this.ZIPPANEL.Controls.Add(this.BrandComboBox);
            this.ZIPPANEL.Controls.Add(this.PodKategoryComboBox);
            this.ZIPPANEL.Controls.Add(this.KategoryComboBox);
            this.ZIPPANEL.Controls.Add(this.PrimechanieTextBox);
            this.ZIPPANEL.Location = new System.Drawing.Point(13, 14);
            this.ZIPPANEL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ZIPPANEL.Name = "ZIPPANEL";
            this.ZIPPANEL.Size = new System.Drawing.Size(575, 403);
            this.ZIPPANEL.TabIndex = 63;
            // 
            // DeletePhotoButton3
            // 
            this.DeletePhotoButton3.Location = new System.Drawing.Point(180, 210);
            this.DeletePhotoButton3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeletePhotoButton3.Name = "DeletePhotoButton3";
            this.DeletePhotoButton3.Size = new System.Drawing.Size(77, 27);
            this.DeletePhotoButton3.TabIndex = 82;
            this.DeletePhotoButton3.Text = "Удалить";
            this.DeletePhotoButton3.UseVisualStyleBackColor = true;
            this.DeletePhotoButton3.Click += new System.EventHandler(this.DeletePhotoButton3_Click);
            // 
            // DeletePhotoButton2
            // 
            this.DeletePhotoButton2.Location = new System.Drawing.Point(180, 176);
            this.DeletePhotoButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeletePhotoButton2.Name = "DeletePhotoButton2";
            this.DeletePhotoButton2.Size = new System.Drawing.Size(77, 27);
            this.DeletePhotoButton2.TabIndex = 81;
            this.DeletePhotoButton2.Text = "Удалить";
            this.DeletePhotoButton2.UseVisualStyleBackColor = true;
            this.DeletePhotoButton2.Click += new System.EventHandler(this.DeletePhotoButton2_Click);
            // 
            // DeletePhotoButton1
            // 
            this.DeletePhotoButton1.Location = new System.Drawing.Point(180, 140);
            this.DeletePhotoButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeletePhotoButton1.Name = "DeletePhotoButton1";
            this.DeletePhotoButton1.Size = new System.Drawing.Size(77, 28);
            this.DeletePhotoButton1.TabIndex = 80;
            this.DeletePhotoButton1.Text = "Удалить";
            this.DeletePhotoButton1.UseVisualStyleBackColor = true;
            this.DeletePhotoButton1.Click += new System.EventHandler(this.DeletePhotoButton1_Click);
            // 
            // StockEditorPhotoEditButton3
            // 
            this.StockEditorPhotoEditButton3.Location = new System.Drawing.Point(15, 210);
            this.StockEditorPhotoEditButton3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StockEditorPhotoEditButton3.Name = "StockEditorPhotoEditButton3";
            this.StockEditorPhotoEditButton3.Size = new System.Drawing.Size(157, 27);
            this.StockEditorPhotoEditButton3.TabIndex = 79;
            this.StockEditorPhotoEditButton3.Text = "Загрузить фото 3";
            this.StockEditorPhotoEditButton3.UseVisualStyleBackColor = true;
            this.StockEditorPhotoEditButton3.Click += new System.EventHandler(this.button2_Click);
            // 
            // StockEditorPhotoEditButton2
            // 
            this.StockEditorPhotoEditButton2.Location = new System.Drawing.Point(15, 176);
            this.StockEditorPhotoEditButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StockEditorPhotoEditButton2.Name = "StockEditorPhotoEditButton2";
            this.StockEditorPhotoEditButton2.Size = new System.Drawing.Size(157, 27);
            this.StockEditorPhotoEditButton2.TabIndex = 78;
            this.StockEditorPhotoEditButton2.Text = "Загрузить фото 2";
            this.StockEditorPhotoEditButton2.UseVisualStyleBackColor = true;
            this.StockEditorPhotoEditButton2.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteStockButton1
            // 
            this.DeleteStockButton1.Location = new System.Drawing.Point(12, 350);
            this.DeleteStockButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeleteStockButton1.Name = "DeleteStockButton1";
            this.DeleteStockButton1.Size = new System.Drawing.Size(547, 30);
            this.DeleteStockButton1.TabIndex = 77;
            this.DeleteStockButton1.Text = "Удалить";
            this.DeleteStockButton1.UseVisualStyleBackColor = true;
            this.DeleteStockButton1.Click += new System.EventHandler(this.DeleteStockButton1_Click);
            // 
            // SaveStockButton
            // 
            this.SaveStockButton.Location = new System.Drawing.Point(12, 311);
            this.SaveStockButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveStockButton.Name = "SaveStockButton";
            this.SaveStockButton.Size = new System.Drawing.Size(547, 31);
            this.SaveStockButton.TabIndex = 76;
            this.SaveStockButton.Text = "Сохранить";
            this.SaveStockButton.UseVisualStyleBackColor = true;
            this.SaveStockButton.Click += new System.EventHandler(this.SaveStockButton_Click);
            // 
            // StockEditorPhotoEditButton1
            // 
            this.StockEditorPhotoEditButton1.Location = new System.Drawing.Point(15, 140);
            this.StockEditorPhotoEditButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StockEditorPhotoEditButton1.Name = "StockEditorPhotoEditButton1";
            this.StockEditorPhotoEditButton1.Size = new System.Drawing.Size(157, 28);
            this.StockEditorPhotoEditButton1.TabIndex = 66;
            this.StockEditorPhotoEditButton1.Text = "Загрузить фото 1";
            this.StockEditorPhotoEditButton1.UseVisualStyleBackColor = true;
            this.StockEditorPhotoEditButton1.Click += new System.EventHandler(this.StockEditorPhotoEditButton_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(73, 219);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(280, 16);
            this.label9.TabIndex = 75;
            this.label9.Text = "Цена: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(361, 215);
            this.PriceTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(196, 22);
            this.PriceTextBox.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(20, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 16);
            this.label8.TabIndex = 74;
            this.label8.Text = "Примечание: ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(73, 283);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(280, 16);
            this.label7.TabIndex = 73;
            this.label7.Text = "Напомнить, если количество менее: ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(73, 251);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(280, 16);
            this.label6.TabIndex = 72;
            this.label6.Text = "Количество: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(73, 187);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(280, 16);
            this.label5.TabIndex = 71;
            this.label5.Text = "Цвет: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(73, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "Модель: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(65, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 16);
            this.label3.TabIndex = 69;
            this.label3.Text = "Бренд: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(69, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 16);
            this.label2.TabIndex = 68;
            this.label2.Text = "Тип запчасти (ЗИП): ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NapominanieTextBox
            // 
            this.NapominanieTextBox.Location = new System.Drawing.Point(361, 279);
            this.NapominanieTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NapominanieTextBox.Name = "NapominanieTextBox";
            this.NapominanieTextBox.Size = new System.Drawing.Size(196, 22);
            this.NapominanieTextBox.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(65, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 16);
            this.label1.TabIndex = 67;
            this.label1.Text = "Тип устройства: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CountOfTextBox
            // 
            this.CountOfTextBox.Location = new System.Drawing.Point(361, 247);
            this.CountOfTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CountOfTextBox.Name = "CountOfTextBox";
            this.CountOfTextBox.Size = new System.Drawing.Size(196, 22);
            this.CountOfTextBox.TabIndex = 64;
            // 
            // ModelTextBox
            // 
            this.ModelTextBox.Location = new System.Drawing.Point(361, 150);
            this.ModelTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ModelTextBox.Name = "ModelTextBox";
            this.ModelTextBox.Size = new System.Drawing.Size(196, 22);
            this.ModelTextBox.TabIndex = 61;
            // 
            // ColourComboBox
            // 
            this.ColourComboBox.FormattingEnabled = true;
            this.ColourComboBox.Location = new System.Drawing.Point(361, 182);
            this.ColourComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ColourComboBox.Name = "ColourComboBox";
            this.ColourComboBox.Size = new System.Drawing.Size(196, 24);
            this.ColourComboBox.TabIndex = 62;
            // 
            // BrandComboBox
            // 
            this.BrandComboBox.FormattingEnabled = true;
            this.BrandComboBox.Location = new System.Drawing.Point(361, 117);
            this.BrandComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrandComboBox.Name = "BrandComboBox";
            this.BrandComboBox.Size = new System.Drawing.Size(196, 24);
            this.BrandComboBox.TabIndex = 60;
            // 
            // PodKategoryComboBox
            // 
            this.PodKategoryComboBox.FormattingEnabled = true;
            this.PodKategoryComboBox.Location = new System.Drawing.Point(361, 84);
            this.PodKategoryComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PodKategoryComboBox.Name = "PodKategoryComboBox";
            this.PodKategoryComboBox.Size = new System.Drawing.Size(196, 24);
            this.PodKategoryComboBox.TabIndex = 59;
            // 
            // KategoryComboBox
            // 
            this.KategoryComboBox.FormattingEnabled = true;
            this.KategoryComboBox.Location = new System.Drawing.Point(361, 50);
            this.KategoryComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KategoryComboBox.Name = "KategoryComboBox";
            this.KategoryComboBox.Size = new System.Drawing.Size(196, 24);
            this.KategoryComboBox.TabIndex = 58;
            // 
            // PrimechanieTextBox
            // 
            this.PrimechanieTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.PrimechanieTextBox.Location = new System.Drawing.Point(165, 15);
            this.PrimechanieTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PrimechanieTextBox.Name = "PrimechanieTextBox";
            this.PrimechanieTextBox.Size = new System.Drawing.Size(392, 22);
            this.PrimechanieTextBox.TabIndex = 57;
            // 
            // UsedZipCounterLabel
            // 
            this.UsedZipCounterLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsedZipCounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsedZipCounterLabel.Location = new System.Drawing.Point(13, 608);
            this.UsedZipCounterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsedZipCounterLabel.Name = "UsedZipCounterLabel";
            this.UsedZipCounterLabel.Size = new System.Drawing.Size(575, 84);
            this.UsedZipCounterLabel.TabIndex = 64;
            this.UsedZipCounterLabel.Text = "Чтобы узнать, используются ли запчасти клиентом, выберите клиента. \r\n(Чтобы выбра" +
    "ть клиента, нужно зайти в склад, через редактирование записей, кнопочка рядом с " +
    "полем затраты";
            this.UsedZipCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StockEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 699);
            this.Controls.Add(this.UsedZipCounterLabel);
            this.Controls.Add(this.ZIPPANEL);
            this.Controls.Add(this.ZIPUSEPANEL);
            this.Controls.Add(this.PicturePanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StockEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактировать";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StockEditor_FormClosed);
            this.Load += new System.EventHandler(this.StockEditor_Load);
            this.PicturePanel1.ResumeLayout(false);
            this.PicturePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountOfZIPNumericUpDown)).EndInit();
            this.ZIPUSEPANEL.ResumeLayout(false);
            this.ZIPUSEPANEL.PerformLayout();
            this.ZIPPANEL.ResumeLayout(false);
            this.ZIPPANEL.PerformLayout();
            this.ResumeLayout(false);

	}
}
