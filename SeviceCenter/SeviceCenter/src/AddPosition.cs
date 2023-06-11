// AddPosition

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class AddPosition : Form
{
	private Form1 mainForm;

	private IniFile INIF = new IniFile("Config.ini");

	private bool clientIsAlreadyWithUs = false;

	private string clientIdInBase = "";

	private string FILL_FIO_AUTO = "";

	private string FILL_PHONE_AUTO = "";

	private IContainer components = null;

	public CheckBox checkBox3;

	public MaskedTextBox phoneTextBox;

	public TextBox PredvaritelnayaStoimostTextBox;

	public Label label22;

	public Label label21;

	public ComboBox PolomkaComboBox;

	public Label label10;

	public Label label4;

	public TextBox PolomkaTextBox;

	public TextBox KomplektnostTextBox;

	public ComboBox KomplektonstComboBox;

	public Label label20;

	public TextBox SerialTextBox;

	public Label label19;

	public TextBox ModelTextBox;

	public TextBox PredoplataTextBox;

	public Label label12;

	public Label label18;

	public ComboBox BrandComboBox;

	public Label label8;

	public ComboBox AboutUsComboBox;

	public ComboBox What_remont_combo_box;

	public Button NewOrderButton;

	public Label label2;

	public Button AddButton;

	public TextBox kommentarijTextBox;

	public TextBox SurnameTextBox;

	public Label label15;

	public ComboBox MasterComboBox;

	public TextBox SostoyanieTextBox;

	public Label label3;

	public Label label14;

	public Label label13;

	public ComboBox SostoyaniePriemaComboBox;

	public ComboBox StatusComboBox;

	public Label label7;

	public Label label1;

	public TextBox AdressKlientTextBox;

	private Label label9;

	private ComboBox DeviceColourComboBox;

	private Label label6;

	private ComboBox ServiceAdressComboBox;

	public Button button1;

	public TextBox PrimechanieTextBox;

	private Label label5;

	public ComboBox BlackListComboBox;

	private Label label11;

	private Label RepairHistoryLabel;

	public Panel panel1;

	public AddPosition(Form1 mf)
	{
		mainForm = mf;
		InitializeComponent();
		What_remont_combo_box.MouseWheel += What_remont_combo_box_MouseWheel;
		BrandComboBox.MouseWheel += BrandComboBox_MouseWheel;
		DeviceColourComboBox.MouseWheel += DeviceColourComboBox_MouseWheel;
		ServiceAdressComboBox.MouseWheel += ServiceAdressComboBox_MouseWheel;
		AboutUsComboBox.MouseWheel += AboutUsComboBox_MouseWheel;
		MasterComboBox.MouseWheel += MasterComboBox_MouseWheel;
		StatusComboBox.MouseWheel += StatusComboBox_MouseWheel;
		SostoyaniePriemaComboBox.MouseWheel += SostoyaniePriemaComboBox_MouseWheel;
		KomplektonstComboBox.MouseWheel += KomplektonstComboBox_MouseWheel;
		PolomkaComboBox.MouseWheel += PolomkaComboBox_MouseWheel;
		mainForm.adPos = true;
	}

	private void What_remont_combo_box_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void BrandComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void DeviceColourComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void ServiceAdressComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void AboutUsComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void MasterComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void StatusComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void SostoyaniePriemaComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void KomplektonstComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void PolomkaComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void AddButton_Click(object sender, EventArgs e)
	{
		try
		{
			bool flag = false;
			string text = "";
			if (SurnameTextBox.Text == "")
			{
				text = text + " Введите ФИО " + Environment.NewLine;
				flag = true;
			}
			if (phoneTextBox.Text == "")
			{
				text = text + " Введите номер телефона " + Environment.NewLine;
				flag = true;
			}
			if (What_remont_combo_box.Text == "")
			{
				text = text + " Введите тип устройства " + Environment.NewLine;
				flag = true;
			}
			if (BrandComboBox.Text == "")
			{
				text = text + " Введите бренд устройства " + Environment.NewLine;
				flag = true;
			}
			if (ModelTextBox.Text == "")
			{
				text = text + " Введите модель " + Environment.NewLine;
				flag = true;
			}
			if (SerialTextBox.Text == "")
			{
				text = text + " Введите серийный номер " + Environment.NewLine;
				flag = true;
			}
			if (SostoyanieTextBox.Text == "")
			{
				text = text + " Не указано состояние приема " + Environment.NewLine;
				flag = true;
			}
			if (KomplektnostTextBox.Text == "")
			{
				text = text + " Не указана комплектность " + Environment.NewLine;
				flag = true;
			}
			if (PolomkaTextBox.Text == "")
			{
				text = text + " Не указана неисправность " + Environment.NewLine;
				flag = true;
			}
			if (flag)
			{
				MessageBox.Show(text, "Не заполнены обязательные поля");
			}
			if (flag || MessageBox.Show("Сохранить все изменения и напечатать акт приема?", "Вы уверены?", MessageBoxButtons.OKCancel) != DialogResult.OK)
			{
				return;
			}
			if (FILL_FIO_AUTO != "" && FILL_PHONE_AUTO != "")
			{
				if (FILL_FIO_AUTO != SurnameTextBox.Text || FILL_PHONE_AUTO != phoneTextBox.Text)
				{
					switch (MessageBox.Show("Ввёденные данные о клиенте (ФИО или телефон) изменились" + Environment.NewLine + "Вы действитльно хотитие сохранить их в таком виде, это приведёт к изменению данных клента во всех его заказах. C" + Environment.NewLine + FILL_FIO_AUTO + " " + FILL_PHONE_AUTO + " На" + Environment.NewLine + SurnameTextBox.Text + " " + phoneTextBox.Text + Environment.NewLine + Environment.NewLine + "Нажав Да вы подтвердите эти изменения" + Environment.NewLine + "Нажав Нет вы создате нового клиента, с  данными: " + Environment.NewLine + SurnameTextBox.Text + " " + phoneTextBox.Text + Environment.NewLine + "Нажав Отмена, вы вернётесь в окно добавления записи" + Environment.NewLine + "Данное уведомление показано так как, вы изначально ввели данные одного клиента, а в процессе редактирования записи их изменили", "Вы уверены?", MessageBoxButtons.YesNoCancel))
					{
						case DialogResult.Yes:
							{
								ClientOfficer();
								mainForm.basa.BdWrite(DateTime.Now.ToString("dd-MM-yyyy HH:mm"), "", PredoplataDate(PredoplataTextBox.Text), "", "", "", What_remont_combo_box.Text, BrandComboBox.Text, ModelTextBox.Text, SerialTextBox.Text, SostoyanieTextBox.Text, KomplektnostTextBox.Text, PolomkaTextBox.Text, kommentarijTextBox.Text, EmptyStringToZeroMaker(PredvaritelnayaStoimostTextBox.Text), EmptyStringToZeroMaker(PredoplataTextBox.Text), "0", "0", "0", StatusComboBox.Text, MasterComboBox.Text, "", "", NeedZakaz(), "", "", ServiceAdressComboBox.Text.ToUpper().Trim(), DeviceColourComboBox.Text.ToUpper().Trim(), clientIdInBase);
								string text4 = mainForm.basa.BdReadAdvertsDataTop().ToString();
								mainForm.StatusStripLabel.Text = "Запись номрер " + text4 + " добавлена";
								TemporaryBase.SearchFULLBegin();
								mainForm.basa.StatesMapWrite(text4, DateTime.Now.ToString("dd-MM-yyyy HH-mm"), "Установлен статус" + Environment.NewLine + StatusComboBox.Text);

									Printing_AKT_PRIEMA printing_AKT_PRIEMA2 = new Printing_AKT_PRIEMA(mainForm.basa.BdReadOneEditor(text4), mainForm, TemporaryBase.valuta);
									printing_AKT_PRIEMA2.Show();

								mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Добавление новой записи", "", text4);
								if (TemporaryBase.openClientFolder)
								{
									string text5 = "ClientFiles\\" + clientIdInBase + "\\" + text4;
									if (!Directory.Exists(text5))
									{
										Directory.CreateDirectory(text5);
									}
									Process.Start("explorer", text5 ?? "");
								}
								Close();
								break;
							}
						case DialogResult.No:
							{
								clientIsAlreadyWithUs = false;
								clientIdInBase = "";
								ClientOfficer();
								mainForm.basa.BdWrite(DateTime.Now.ToString("dd-MM-yyyy HH:mm"), "", PredoplataDate(PredoplataTextBox.Text), "", "", "", What_remont_combo_box.Text, BrandComboBox.Text, ModelTextBox.Text, SerialTextBox.Text, SostoyanieTextBox.Text, KomplektnostTextBox.Text, PolomkaTextBox.Text, kommentarijTextBox.Text, EmptyStringToZeroMaker(PredvaritelnayaStoimostTextBox.Text), EmptyStringToZeroMaker(PredoplataTextBox.Text), "0", "0", "0", StatusComboBox.Text, MasterComboBox.Text, "", "", NeedZakaz(), "", "", ServiceAdressComboBox.Text.ToUpper().Trim(), DeviceColourComboBox.Text.ToUpper().Trim(), clientIdInBase);
								string text2 = mainForm.basa.BdReadAdvertsDataTop().ToString();
								mainForm.StatusStripLabel.Text = "Запись номрер " + text2 + " добавлена";
								TemporaryBase.SearchFULLBegin();
								mainForm.basa.StatesMapWrite(text2, DateTime.Now.ToString("dd-MM-yyyy HH-mm"), "Установлен статус" + Environment.NewLine + StatusComboBox.Text);

									Printing_AKT_PRIEMA printing_AKT_PRIEMA = new Printing_AKT_PRIEMA(mainForm.basa.BdReadOneEditor(text2), mainForm, TemporaryBase.valuta);
									printing_AKT_PRIEMA.Show();

								if (TemporaryBase.openClientFolder)
								{
									string text3 = "ClientFiles\\" + clientIdInBase + "\\" + text2;
									if (!Directory.Exists(text3))
									{
										Directory.CreateDirectory(text3);
									}
									Process.Start("explorer", text3 ?? "");
								}
								mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Добавление новой записи", "", text2);
								Close();
								break;
							}
					}
					return;
				}
				ClientOfficer();
				mainForm.basa.BdWrite(DateTime.Now.ToString("dd-MM-yyyy HH:mm"), "", PredoplataDate(PredoplataTextBox.Text), "", "", "", What_remont_combo_box.Text, BrandComboBox.Text, ModelTextBox.Text, SerialTextBox.Text, SostoyanieTextBox.Text, KomplektnostTextBox.Text, PolomkaTextBox.Text, kommentarijTextBox.Text, EmptyStringToZeroMaker(PredvaritelnayaStoimostTextBox.Text), EmptyStringToZeroMaker(PredoplataTextBox.Text), "0", "0", "0", StatusComboBox.Text, MasterComboBox.Text, "", "", NeedZakaz(), "", "", ServiceAdressComboBox.Text.ToUpper().Trim(), DeviceColourComboBox.Text.ToUpper().Trim(), clientIdInBase);
				string text6 = mainForm.basa.BdReadAdvertsDataTop().ToString();
				mainForm.StatusStripLabel.Text = "Запись номер " + text6 + " добавлена";
				TemporaryBase.SearchFULLBegin();
				mainForm.basa.StatesMapWrite(text6, DateTime.Now.ToString("dd-MM-yyyy HH-mm"), "Установлен статус" + Environment.NewLine + StatusComboBox.Text);

					Printing_AKT_PRIEMA printing_AKT_PRIEMA3 = new Printing_AKT_PRIEMA(mainForm.basa.BdReadOneEditor(text6), mainForm, TemporaryBase.valuta);
					printing_AKT_PRIEMA3.Show();

				if (TemporaryBase.openClientFolder)
				{
					string text7 = "ClientFiles\\" + clientIdInBase + "\\" + text6;
					if (!Directory.Exists(text7))
					{
						Directory.CreateDirectory(text7);
					}
					Process.Start("explorer", text7 ?? "");
				}
				mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Добавление новой записи", "", text6);
				Close();
				return;
			}
			ClientOfficer();
			mainForm.basa.BdWrite(DateTime.Now.ToString("dd-MM-yyyy HH:mm"), "", PredoplataDate(PredoplataTextBox.Text), "", "", "", What_remont_combo_box.Text, BrandComboBox.Text, ModelTextBox.Text, SerialTextBox.Text, SostoyanieTextBox.Text, KomplektnostTextBox.Text, PolomkaTextBox.Text, kommentarijTextBox.Text, EmptyStringToZeroMaker(PredvaritelnayaStoimostTextBox.Text), EmptyStringToZeroMaker(PredoplataTextBox.Text), "0", "0", "0", StatusComboBox.Text, MasterComboBox.Text, "", "", NeedZakaz(), "", "", ServiceAdressComboBox.Text.ToUpper().Trim(), DeviceColourComboBox.Text.ToUpper().Trim(), clientIdInBase);
			string text8 = mainForm.basa.BdReadAdvertsDataTop().ToString();
			mainForm.StatusStripLabel.Text = "Запись номрер " + text8 + " добавлена";
			TemporaryBase.SearchFULLBegin();
			mainForm.basa.StatesMapWrite(text8, DateTime.Now.ToString("dd-MM-yyyy HH-mm"), "Установлен статус" + Environment.NewLine + StatusComboBox.Text);

				Printing_AKT_PRIEMA printing_AKT_PRIEMA4 = new Printing_AKT_PRIEMA(mainForm.basa.BdReadOneEditor(text8), mainForm, TemporaryBase.valuta);
				printing_AKT_PRIEMA4.Show();

			if (TemporaryBase.openClientFolder)
			{
				string text9 = "ClientFiles\\" + clientIdInBase + "\\" + text8;
				if (!Directory.Exists(text9))
				{
					Directory.CreateDirectory(text9);
				}
				Process.Start("explorer", text9 ?? "");
			}
			mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Добавление новой записи", "", text8);
			Close();

		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
		}
	}

	public void MyMethod(object sender, EventArgs e)
	{
		Label label = (Label)sender;
		string input = label.Tag.ToString();
		string pattern = "(.*)\\n(.*)\\n(.*)\\n(.*)\\n";
		Regex regex = new Regex(pattern);
		Match match = regex.Match(input);
		if (match.Success)
		{
			What_remont_combo_box.Text = match.Groups[1].ToString();
			BrandComboBox.Text = match.Groups[2].ToString();
			ModelTextBox.Text = match.Groups[3].ToString();
			SerialTextBox.Text = match.Groups[4].ToString();
		}
	}

	public void ClientsHistoryMaker()
	{
		DataTable dataTable = mainForm.basa.ClientsShowHistory(clientIdInBase);
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
			item2.Click += MyMethod;
			item2.Tag = dataTable.Rows[num4].ItemArray[7].ToString() + Environment.NewLine + dataTable.Rows[num4].ItemArray[8].ToString() + Environment.NewLine + dataTable.Rows[num4].ItemArray[9].ToString() + Environment.NewLine + dataTable.Rows[num4].ItemArray[10].ToString() + Environment.NewLine;
			panel1.Controls.Add(item2);
			toolTip.SetToolTip(item2, "Адрес СЦ: " + dataTable.Rows[num4].ItemArray[27].ToString() + Environment.NewLine + "Выполненные работы: " + dataTable.Rows[num4].ItemArray[22].ToString() + Environment.NewLine + "Мастер: " + dataTable.Rows[num4].ItemArray[21].ToString() + Environment.NewLine + "Поломка: " + dataTable.Rows[num4].ItemArray[13].ToString() + Environment.NewLine + "Серийний №: " + dataTable.Rows[num4].ItemArray[10].ToString() + Environment.NewLine + "Комментарий: " + dataTable.Rows[num4].ItemArray[14].ToString() + Environment.NewLine);
			num4++;
		}
	}

	private void notifyFormShower(int showThis)
	{
	}

	private void ClientOfficer()
	{
		if (clientIsAlreadyWithUs)
		{
			if (clientIdInBase != "")
			{
				mainForm.basa.ClientsMapEditAll(SurnameTextBox.Text, phoneTextBox.Text.Replace(" ", ""), AdressKlientTextBox.Text, PrimechanieTextBox.Text, BlistOfClients(), ClientFirstDate(), AboutUsComboBox.Text, clientIdInBase);
				return;
			}
			mainForm.basa.ClientsMapWrite(SurnameTextBox.Text, phoneTextBox.Text.Replace(" ", ""), AdressKlientTextBox.Text, PrimechanieTextBox.Text, BlistOfClients(), DateTime.Now.ToString("dd-MM-yyyy HH:mm"), AboutUsComboBox.Text);
			clientIdInBase = mainForm.basa.ClientReadId(SurnameTextBox.Text, phoneTextBox.Text);
		}
		else
		{
			mainForm.basa.ClientsMapWrite(SurnameTextBox.Text, phoneTextBox.Text.Replace(" ", ""), AdressKlientTextBox.Text, PrimechanieTextBox.Text, BlistOfClients(), DateTime.Now.ToString("dd-MM-yyyy HH:mm"), AboutUsComboBox.Text);
			clientIdInBase = mainForm.basa.ClientReadId(SurnameTextBox.Text, phoneTextBox.Text);
		}
	}

	private string ClientFirstDate()
	{
		return mainForm.basa.ClientReadDate(clientIdInBase);
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

	private string NeedZakaz()
	{
		if (checkBox3.Checked)
		{
			return "Заказать";
		}
		return "";
	}

	private string PredoplataDate(string str1)
	{
		if (str1 != "" && str1 != "0")
		{
			if (checkBox3.Checked)
			{
				return DateTime.Now.ToString("dd-MM-yyyy HH:mm");
			}
			return "";
		}
		return "";
	}

	private void coloredLables()
	{
		if (SurnameTextBox.Text != "")
		{
			label3.ForeColor = Color.Black;
		}
		if (phoneTextBox.Text != "")
		{
			label10.ForeColor = Color.Black;
		}
		if (What_remont_combo_box.Text != "")
		{
			label2.ForeColor = Color.Black;
		}
		if (BrandComboBox.Text != "")
		{
			label7.ForeColor = Color.Black;
		}
		if (ModelTextBox.Text != "")
		{
			label18.ForeColor = Color.Black;
		}
		if (SerialTextBox.Text != "")
		{
			label19.ForeColor = Color.Black;
		}
		if (SostoyanieTextBox.Text != "")
		{
			label14.ForeColor = Color.Black;
		}
		if (KomplektnostTextBox.Text != "")
		{
			label20.ForeColor = Color.Black;
		}
		if (PolomkaTextBox.Text != "")
		{
			label4.ForeColor = Color.Black;
		}
		if (SurnameTextBox.Text == "")
		{
			label3.ForeColor = Color.RoyalBlue;
		}
		if (phoneTextBox.Text == "")
		{
			label10.ForeColor = Color.RoyalBlue;
		}
		if (What_remont_combo_box.Text == "")
		{
			label2.ForeColor = Color.RoyalBlue;
		}
		if (BrandComboBox.Text == "")
		{
			label7.ForeColor = Color.RoyalBlue;
		}
		if (ModelTextBox.Text == "")
		{
			label18.ForeColor = Color.RoyalBlue;
		}
		if (SerialTextBox.Text == "")
		{
			label19.ForeColor = Color.RoyalBlue;
		}
		if (SostoyanieTextBox.Text == "")
		{
			label14.ForeColor = Color.RoyalBlue;
		}
		if (KomplektnostTextBox.Text == "")
		{
			label20.ForeColor = Color.RoyalBlue;
		}
		if (PolomkaTextBox.Text == "")
		{
			label4.ForeColor = Color.RoyalBlue;
		}
	}

	private void AddPosition_MouseDown(object sender, MouseEventArgs e)
	{
		base.Capture = false;
		Message m = Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
		WndProc(ref m);
	}

	private void label5_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void NewOrderButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Очистить содержимое полей?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			SurnameTextBox.Text = "";
			phoneTextBox.Text = "";
			AboutUsComboBox.Text = "";
			What_remont_combo_box.Text = "";
			BrandComboBox.Text = "";
			ModelTextBox.Text = "";
			SerialTextBox.Text = "";
			SostoyaniePriemaComboBox.SelectedIndex = -1;
			SostoyanieTextBox.Text = "";
			KomplektonstComboBox.SelectedIndex = -1;
			KomplektnostTextBox.Text = "";
			PolomkaComboBox.SelectedIndex = -1;
			PolomkaTextBox.Text = "";
			kommentarijTextBox.Text = "";
			PredvaritelnayaStoimostTextBox.Text = "";
			PredoplataTextBox.Text = "";
			StatusComboBox.SelectedIndex = 0;
			MasterComboBox.Text = "";
			clientIsAlreadyWithUs = false;
			clientIdInBase = "";
			PrimechanieTextBox.Text = "";
			BlackListComboBox.Text = "";
			panel1.Controls.Clear();
		}
	}

	private void label20_MouseDown(object sender, MouseEventArgs e)
	{
		label20.Capture = false;
		Message m = Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
		WndProc(ref m);
	}

	private void label21_MouseDown(object sender, MouseEventArgs e)
	{
		label21.Capture = false;
		Message m = Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
		WndProc(ref m);
	}

	private void PredvaritelnayaStoimostTextBox_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsDigit(e.KeyChar))
		{
			if (e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}
		else if (PredvaritelnayaStoimostTextBox.Text == "" && e.KeyChar == '0')
		{
			e.Handled = true;
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

	private void PredoplataTextBox_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsDigit(e.KeyChar))
		{
			if (e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}
		else if (PredoplataTextBox.Text == "" && e.KeyChar == '0')
		{
			checkBox3.Checked = false;
			e.Handled = true;
		}
		else
		{
			checkBox3.Checked = true;
		}
	}

	private void PredoplataTextBox_KeyUp(object sender, KeyEventArgs e)
	{
		if (PredoplataTextBox.Text == "" || int.Parse(PredoplataTextBox.Text) == 0)
		{
			checkBox3.Checked = false;
		}
	}

	private string EmptyStringToZeroMaker(string str1)
	{
		if (str1 == "")
		{
			return 0.ToString();
		}
		return str1;
	}

	private void SurnameTextBox_TextChanged(object sender, EventArgs e)
	{
		coloredLables();
	}

	private void phoneTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
	{
		coloredLables();
	}

	private void What_remont_combo_box_SelectedIndexChanged(object sender, EventArgs e)
	{
		coloredLables();
	}

	private void BrandComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		coloredLables();
	}

	private void ModelTextBox_TextChanged(object sender, EventArgs e)
	{
		coloredLables();
	}

	private void SerialTextBox_TextChanged(object sender, EventArgs e)
	{
		coloredLables();
		SerialTextBox.Text = SerialTextBox.Text.Replace('а', 'f');
		SerialTextBox.Text = SerialTextBox.Text.Replace('в', 'd');
		SerialTextBox.Text = SerialTextBox.Text.Replace('г', 'u');
		SerialTextBox.Text = SerialTextBox.Text.Replace('д', 'l');
		SerialTextBox.Text = SerialTextBox.Text.Replace('е', 't');
		SerialTextBox.Text = SerialTextBox.Text.Replace('з', 'p');
		SerialTextBox.Text = SerialTextBox.Text.Replace('и', 'b');
		SerialTextBox.Text = SerialTextBox.Text.Replace('к', 'r');
		SerialTextBox.Text = SerialTextBox.Text.Replace('л', 'k');
		SerialTextBox.Text = SerialTextBox.Text.Replace('м', 'v');
		SerialTextBox.Text = SerialTextBox.Text.Replace('н', 'y');
		SerialTextBox.Text = SerialTextBox.Text.Replace('о', 'j');
		SerialTextBox.Text = SerialTextBox.Text.Replace('п', 'g');
		SerialTextBox.Text = SerialTextBox.Text.Replace('р', 'h');
		SerialTextBox.Text = SerialTextBox.Text.Replace('с', 'c');
		SerialTextBox.Text = SerialTextBox.Text.Replace('т', 'n');
		SerialTextBox.Text = SerialTextBox.Text.Replace('у', 'e');
		SerialTextBox.Text = SerialTextBox.Text.Replace('ф', 'a');
		SerialTextBox.Text = SerialTextBox.Text.Replace('ц', 'w');
		SerialTextBox.Text = SerialTextBox.Text.Replace('ч', 'x');
		SerialTextBox.Text = SerialTextBox.Text.Replace('ш', 'i');
		SerialTextBox.Text = SerialTextBox.Text.Replace('щ', 'o');
		SerialTextBox.Text = SerialTextBox.Text.Replace('ы', 's');
		SerialTextBox.Text = SerialTextBox.Text.Replace('ь', 'm');
		SerialTextBox.Text = SerialTextBox.Text.Replace('я', 'z');
		SerialTextBox.Text = SerialTextBox.Text.Replace('А', 'F');
		SerialTextBox.Text = SerialTextBox.Text.Replace('В', 'D');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Г', 'U');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Д', 'L');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Е', 'T');
		SerialTextBox.Text = SerialTextBox.Text.Replace('З', 'P');
		SerialTextBox.Text = SerialTextBox.Text.Replace('И', 'B');
		SerialTextBox.Text = SerialTextBox.Text.Replace('К', 'R');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Л', 'K');
		SerialTextBox.Text = SerialTextBox.Text.Replace('М', 'V');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Н', 'Y');
		SerialTextBox.Text = SerialTextBox.Text.Replace('О', 'J');
		SerialTextBox.Text = SerialTextBox.Text.Replace('П', 'G');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Р', 'H');
		SerialTextBox.Text = SerialTextBox.Text.Replace('С', 'C');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Т', 'N');
		SerialTextBox.Text = SerialTextBox.Text.Replace('У', 'E');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Ф', 'A');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Ц', 'W');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Ч', 'X');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Ш', 'I');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Щ', 'O');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Ы', 'S');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Ь', 'M');
		SerialTextBox.Text = SerialTextBox.Text.Replace('Я', 'Z');
		SerialTextBox.SelectionStart = SerialTextBox.Text.Length;
	}

	private void SostoyanieTextBox_TextChanged(object sender, EventArgs e)
	{
		coloredLables();
	}

	private void KomplektnostTextBox_TextChanged(object sender, EventArgs e)
	{
		coloredLables();
	}

	private void PolomkaTextBox_TextChanged(object sender, EventArgs e)
	{
		coloredLables();
	}

	private void What_remont_combo_box_TextChanged(object sender, EventArgs e)
	{
		coloredLables();
	}

	private void BrandComboBox_TextChanged(object sender, EventArgs e)
	{
		coloredLables();
	}

	private void phoneTextBox_TextChanged(object sender, EventArgs e)
	{
		coloredLables();
	}

	private void AddPosition_Load(object sender, EventArgs e)
	{
		ComboboxMaker("settings/sostoyaniePriema.txt", SostoyaniePriemaComboBox);
		ComboboxMaker("settings/komplektonst.txt", KomplektonstComboBox);
		ComboboxMaker("settings/neispravnost.txt", PolomkaComboBox);
		ComboboxMaker("settings/aboutUs.txt", AboutUsComboBox);
		ComboboxMaker("settings/masters.txt", MasterComboBox);
		ComboboxMaker("settings/ustrojstvo.txt", What_remont_combo_box);
		ComboboxMaker("settings/brands.txt", BrandComboBox);
		ComboboxMaker("settings/AdresSC.txt", ServiceAdressComboBox);
		ComboboxMaker("settings/DeviceColour.txt", DeviceColourComboBox);
		if (TemporaryBase.AdressSCDefault.ToString() != "" && ServiceAdressComboBox.Items.Count > int.Parse(TemporaryBase.AdressSCDefault.ToString()))
		{
			ServiceAdressComboBox.SelectedIndex = int.Parse(TemporaryBase.AdressSCDefault.ToString());
		}
		if (TemporaryBase.MasterDefault != "")
		{
			MasterComboBox.Text = TemporaryBase.MasterDefault;
		}
		appendTextSurname();
	}

	private void appendTextSurname()
	{
		SurnameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		SurnameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
		new AutoCompleteStringCollection();
		AutoCompleteStringCollection autoCompleteCustomSource = mainForm.basa.AddCollectionFIO();
		SurnameTextBox.AutoCompleteCustomSource = autoCompleteCustomSource;
	}

	private void SurnameTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyData == Keys.Return && phoneTextBox.Text.Length < 3)
		{
			phoneTextBox.Text = SurnamePhoneAdder(SurnameTextBox.Text);
		}
	}

	public string SurnamePhoneAdder(string fio)
	{
		string text = "";
		if (fio != "")
		{
			try
			{
				DataTable dataTable = mainForm.basa.BdReadFIOPhone(fio);
				if (dataTable.Rows.Count > 0)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						if (dataTable.Rows[i].ItemArray[1].ToString() != "")
						{
							text = (phoneTextBox.Text = dataTable.Rows[i].ItemArray[1].ToString());
						}
						if (dataTable.Rows[i].ItemArray[2].ToString() != "")
						{
							AdressKlientTextBox.Text = dataTable.Rows[i].ItemArray[2].ToString();
						}
						if (dataTable.Rows[i].ItemArray[3].ToString() != "")
						{
							PrimechanieTextBox.Text = dataTable.Rows[i].ItemArray[3].ToString();
						}
						if (dataTable.Rows[i].ItemArray[6].ToString() != "")
						{
							AboutUsComboBox.Text = dataTable.Rows[i].ItemArray[6].ToString();
						}
						if (dataTable.Rows[i].ItemArray[4].ToString() != "")
						{
							BlackListComboBox.Text = BlackLIstComboWriter(dataTable.Rows[i].ItemArray[4].ToString());
						}
						if (dataTable.Rows.Count > 1 && MessageBox.Show("Найдено более одного клиента с таким ФИО, исходя из номера телефона, можете определить это тот клиент, который вам нужен? ", "Совпадение", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							break;
						}
					}
					FILL_PHONE_AUTO = text;
					FILL_FIO_AUTO = SurnameTextBox.Text;
					clientIdInBase = mainForm.basa.ClientReadId(SurnameTextBox.Text, text);
					ClientsHistoryMaker();
					clientIsAlreadyWithUs = true;
					return text;
				}
				return text;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			return text;
		}
		return text;
	}

	private string BlackLIstComboWriter(string SomeNumber)
	{
		if (SomeNumber == "0")
		{
			return "Не проблемный";
		}
		if (SomeNumber == "1")
		{
			return "Проблемный";
		}
		return "";
	}

	private void SurnameTextBox_Click(object sender, EventArgs e)
	{
		if (phoneTextBox.Text.Length < 3)
		{
			phoneTextBox.Text = SurnamePhoneAdder(SurnameTextBox.Text);
		}
	}

	private void SostoyaniePriemaComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (SostoyaniePriemaComboBox.SelectedIndex != -1)
		{
			SostoyanieTextBox.AppendText(SostoyaniePriemaComboBox.Items[SostoyaniePriemaComboBox.SelectedIndex].ToString() + ", ");
		}
	}

	private void KomplektonstComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (KomplektonstComboBox.SelectedIndex != -1)
		{
			KomplektnostTextBox.AppendText(KomplektonstComboBox.Items[KomplektonstComboBox.SelectedIndex].ToString());
		}
	}

	private void PolomkaComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (PolomkaComboBox.SelectedIndex != -1)
		{
			PolomkaTextBox.AppendText(PolomkaComboBox.Items[PolomkaComboBox.SelectedIndex].ToString() + ", ");
		}
	}

	private void phoneTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyData != Keys.Back)
		{
			if (phoneTextBox.Text.Length > 0 && phoneTextBox.Text.Length < 2)
			{
				phoneTextBox.AppendText(" ");
			}
			if (phoneTextBox.Text.Length > 4 && phoneTextBox.Text.Length < 6)
			{
				phoneTextBox.AppendText(" ");
			}
			if (phoneTextBox.Text.Length > 8 && phoneTextBox.Text.Length < 10)
			{
				phoneTextBox.AppendText(" ");
			}
			if (phoneTextBox.Text.Length > 13 && phoneTextBox.Text.Length < 15)
			{
				phoneTextBox.AppendText(" ");
			}
		}
	}

	private void AddPosition_FormClosed(object sender, FormClosedEventArgs e)
	{
		mainForm.adPos = false;
	}

	private void button1_Click(object sender, EventArgs e)
	{
	}

	private void zzz(object sender, EventArgs e)
	{
	}

	private void zz(object sender, EventArgs e)
	{
	}

	private void z(object sender, EventArgs e)
	{
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

	private void SerialTextBox_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	private void PredvaritelnayaStoimostTextBox_TextChanged(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		textBox.Text.Replace(",", ".");
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
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.phoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.PredvaritelnayaStoimostTextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.PolomkaComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PolomkaTextBox = new System.Windows.Forms.TextBox();
            this.KomplektnostTextBox = new System.Windows.Forms.TextBox();
            this.KomplektonstComboBox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.SerialTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ModelTextBox = new System.Windows.Forms.TextBox();
            this.PredoplataTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.BrandComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AboutUsComboBox = new System.Windows.Forms.ComboBox();
            this.What_remont_combo_box = new System.Windows.Forms.ComboBox();
            this.NewOrderButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.kommentarijTextBox = new System.Windows.Forms.TextBox();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.MasterComboBox = new System.Windows.Forms.ComboBox();
            this.SostoyanieTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SostoyaniePriemaComboBox = new System.Windows.Forms.ComboBox();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AdressKlientTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DeviceColourComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ServiceAdressComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PrimechanieTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BlackListComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.RepairHistoryLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox3.Location = new System.Drawing.Point(464, 482);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(148, 21);
            this.checkBox3.TabIndex = 18;
            this.checkBox3.Text = "Требует заказа";
            this.checkBox3.UseVisualStyleBackColor = false;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(16, 124);
            this.phoneTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(348, 22);
            this.phoneTextBox.TabIndex = 3;
            this.phoneTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.phoneTextBox_MaskInputRejected);
            this.phoneTextBox.TextChanged += new System.EventHandler(this.phoneTextBox_TextChanged);
            this.phoneTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phoneTextBox_KeyDown);
            // 
            // PredvaritelnayaStoimostTextBox
            // 
            this.PredvaritelnayaStoimostTextBox.Location = new System.Drawing.Point(379, 411);
            this.PredvaritelnayaStoimostTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PredvaritelnayaStoimostTextBox.Name = "PredvaritelnayaStoimostTextBox";
            this.PredvaritelnayaStoimostTextBox.Size = new System.Drawing.Size(348, 22);
            this.PredvaritelnayaStoimostTextBox.TabIndex = 16;
            this.PredvaritelnayaStoimostTextBox.TextChanged += new System.EventHandler(this.PredvaritelnayaStoimostTextBox_TextChanged);
            this.PredvaritelnayaStoimostTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PredvaritelnayaStoimostTextBox_KeyPress);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(417, 396);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(267, 15);
            this.label22.TabIndex = 164;
            this.label22.Text = "Предв. стоим. ремонта";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(15, 649);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(1075, 15);
            this.label21.TabIndex = 163;
            this.label21.Text = "Комментарий к записи, не виден клиенту";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label21.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label21_MouseDown);
            // 
            // PolomkaComboBox
            // 
            this.PolomkaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PolomkaComboBox.FormattingEnabled = true;
            this.PolomkaComboBox.Location = new System.Drawing.Point(379, 171);
            this.PolomkaComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PolomkaComboBox.Name = "PolomkaComboBox";
            this.PolomkaComboBox.Size = new System.Drawing.Size(348, 24);
            this.PolomkaComboBox.TabIndex = 12;
            this.PolomkaComboBox.SelectedIndexChanged += new System.EventHandler(this.PolomkaComboBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(149, 107);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 17);
            this.label10.TabIndex = 146;
            this.label10.Text = "Телефон";
            this.label10.Click += new System.EventHandler(this.z);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(420, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 15);
            this.label4.TabIndex = 123;
            this.label4.Text = "Неисправность";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PolomkaTextBox
            // 
            this.PolomkaTextBox.Location = new System.Drawing.Point(379, 196);
            this.PolomkaTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PolomkaTextBox.Multiline = true;
            this.PolomkaTextBox.Name = "PolomkaTextBox";
            this.PolomkaTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PolomkaTextBox.Size = new System.Drawing.Size(348, 70);
            this.PolomkaTextBox.TabIndex = 13;
            this.PolomkaTextBox.TextChanged += new System.EventHandler(this.PolomkaTextBox_TextChanged);
            // 
            // KomplektnostTextBox
            // 
            this.KomplektnostTextBox.Location = new System.Drawing.Point(379, 55);
            this.KomplektnostTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KomplektnostTextBox.Multiline = true;
            this.KomplektnostTextBox.Name = "KomplektnostTextBox";
            this.KomplektnostTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.KomplektnostTextBox.Size = new System.Drawing.Size(348, 93);
            this.KomplektnostTextBox.TabIndex = 11;
            this.KomplektnostTextBox.TextChanged += new System.EventHandler(this.KomplektnostTextBox_TextChanged);
            // 
            // KomplektonstComboBox
            // 
            this.KomplektonstComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KomplektonstComboBox.FormattingEnabled = true;
            this.KomplektonstComboBox.Location = new System.Drawing.Point(379, 31);
            this.KomplektonstComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KomplektonstComboBox.Name = "KomplektonstComboBox";
            this.KomplektonstComboBox.Size = new System.Drawing.Size(348, 24);
            this.KomplektonstComboBox.TabIndex = 10;
            this.KomplektonstComboBox.SelectedIndexChanged += new System.EventHandler(this.KomplektonstComboBox_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label20.Location = new System.Drawing.Point(420, 12);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(267, 15);
            this.label20.TabIndex = 162;
            this.label20.Text = "Комплектность";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label20_MouseDown);
            // 
            // SerialTextBox
            // 
            this.SerialTextBox.Location = new System.Drawing.Point(16, 336);
            this.SerialTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SerialTextBox.Name = "SerialTextBox";
            this.SerialTextBox.Size = new System.Drawing.Size(348, 22);
            this.SerialTextBox.TabIndex = 7;
            this.SerialTextBox.TextChanged += new System.EventHandler(this.SerialTextBox_TextChanged);
            this.SerialTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SerialTextBox_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label19.Location = new System.Drawing.Point(97, 316);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(169, 17);
            this.label19.TabIndex = 161;
            this.label19.Text = "Серийный номер/IMEI";
            // 
            // ModelTextBox
            // 
            this.ModelTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ModelTextBox.Location = new System.Drawing.Point(16, 261);
            this.ModelTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ModelTextBox.Multiline = true;
            this.ModelTextBox.Name = "ModelTextBox";
            this.ModelTextBox.Size = new System.Drawing.Size(348, 51);
            this.ModelTextBox.TabIndex = 6;
            this.ModelTextBox.TextChanged += new System.EventHandler(this.ModelTextBox_TextChanged);
            // 
            // PredoplataTextBox
            // 
            this.PredoplataTextBox.Location = new System.Drawing.Point(379, 454);
            this.PredoplataTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PredoplataTextBox.Name = "PredoplataTextBox";
            this.PredoplataTextBox.Size = new System.Drawing.Size(348, 22);
            this.PredoplataTextBox.TabIndex = 17;
            this.PredoplataTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PredoplataTextBox_KeyPress);
            this.PredoplataTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PredoplataTextBox_KeyUp);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(417, 438);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(267, 15);
            this.label12.TabIndex = 150;
            this.label12.Text = "Предоплата";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label18.Location = new System.Drawing.Point(155, 244);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 17);
            this.label18.TabIndex = 160;
            this.label18.Text = "Модель";
            // 
            // BrandComboBox
            // 
            this.BrandComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "4PARTS",
            "ACER",
            "ADVOCAM",
            "AMD",
            "APACER",
            "APPLE",
            "ASUS",
            "ASX",
            "BBK",
            "BEELINE",
            "BEKO",
            "BENQ",
            "BLACKBERRY",
            "BLACKVIEW",
            "BQ",
            "COMPAQ",
            "COOLER MASTER",
            "CREATIVE",
            "DAEWOO",
            "DELL",
            "DEXP",
            "DIGMA",
            "DNS",
            "ELENBERG",
            "EMACHINES",
            "EPLUTUS",
            "EPSON",
            "EPSON",
            "ETULINE",
            "EXPLAY",
            "FLY",
            "GARMIN",
            "GIGABYTE",
            "HAIER",
            "HEWLETT PACKARD",
            "HIGHSCREEN",
            "HTC",
            "HUAWEI",
            "ICONBIT",
            "IMPRESSION",
            "INTEGO",
            "INVIN",
            "INWIN",
            "IRBIS",
            "IRU",
            "IRULU",
            "JINGA",
            "JVC",
            "LENOVO",
            "LENTEL",
            "LG",
            "MAXVI",
            "MEGAFON",
            "MERSEDES-BENZ",
            "MI",
            "MICROLAB",
            "MICROMAX",
            "MICROSOFT",
            "MSI",
            "MYSTERY",
            "NOKIA",
            "ORIEL",
            "OUSTERS",
            "PACKARD BELL",
            "PANASONIC",
            "PHILIPS",
            "POLAR",
            "PRESTIGIO",
            "QUMO",
            "REKAM",
            "RITMIX",
            "SAMSUNG",
            "SATELLITE",
            "SC",
            "SHARP+Environment.NewLineDELTA",
            "SIEMENS",
            "SILICON POWER",
            "SMARTBUY",
            "SONY",
            "STARK",
            "STRIKE",
            "SUPRA",
            "TESLA",
            "TESLER",
            "TEXET",
            "TEXET",
            "THOMPSON",
            "TOSHIBA",
            "TREELOGIC",
            "TURBOPAD",
            "TWOCHI",
            "UNITED",
            "VALEO",
            "WEXLER",
            "XEROX",
            "XIAOMI",
            "YOTAPHONE",
            "ZIFRO",
            "ZTE",
            "БЕЗ МАРКИ",
            "БИЛАЙН",
            "КЕЙ",
            "МТС",
            "СПЛАЙН"});
            this.BrandComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.BrandComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.BrandComboBox.FormattingEnabled = true;
            this.BrandComboBox.Location = new System.Drawing.Point(16, 217);
            this.BrandComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrandComboBox.Name = "BrandComboBox";
            this.BrandComboBox.Size = new System.Drawing.Size(348, 24);
            this.BrandComboBox.TabIndex = 5;
            this.BrandComboBox.SelectedIndexChanged += new System.EventHandler(this.BrandComboBox_SelectedIndexChanged);
            this.BrandComboBox.TextChanged += new System.EventHandler(this.BrandComboBox_TextChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(417, 347);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(267, 15);
            this.label8.TabIndex = 159;
            this.label8.Text = "Откуда о нас узнали";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AboutUsComboBox
            // 
            this.AboutUsComboBox.FormattingEnabled = true;
            this.AboutUsComboBox.Location = new System.Drawing.Point(379, 363);
            this.AboutUsComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AboutUsComboBox.Name = "AboutUsComboBox";
            this.AboutUsComboBox.Size = new System.Drawing.Size(348, 24);
            this.AboutUsComboBox.TabIndex = 15;
            // 
            // What_remont_combo_box
            // 
            this.What_remont_combo_box.AutoCompleteCustomSource.AddRange(new string[] {
            "DVD ПРИСТАВКА",
            "FLASH НАКОПИТЕЛЬ",
            "MACBOOK",
            "MP3 ПЛЕЕР",
            "TV",
            "АВТОМАГНИТОЛА",
            "АККУМУЛЯТОРНАЯ БАТАРЕЯ",
            "БЛОК ПИТАНИЯ",
            "ВИДЕОКАРТА",
            "ВИДЕОРЕГИСТРАТОР",
            "ДЖОЙСТИК",
            "ДЫМОВАЯ МАШИНА",
            "ЖЕСТКИЙ ДИСК",
            "ЗАРЯДНОЕ УСТРОЙСТВО",
            "ИГРОВАЯ КОНСОЛЬ",
            "МАГНИТОФОН",
            "МИКРОВОЛНОВАЯ ПЕЧЬ",
            "МОНИТОР",
            "МОНИТОР",
            "МОНОБЛОК",
            "МУЗЫКАЛЬНЫЙ ЦЕНТР",
            "МФУ",
            "НАВИГАТОР",
            "НАУШНИКИ",
            "НЕТБУК",
            "НЕТБУК",
            "НОУТБУК",
            "ПЛАНШЕТ",
            "ПЛАТА",
            "ПОРТАТИВНАЯ КОЛОНКА",
            "ПРИНТЕР",
            "ПРОЕКТОР",
            "РАДИОПРИЕМНИК",
            "РАДИОУПРАВЛЯЕМЫЙ ВЕРТОЛЕТ",
            "РОУТЕР",
            "СИСТЕМНЫЙ БЛОК",
            "ТЕЛЕВИЗЕОННАЯ ПРИСТАВКА",
            "ТЕЛЕФОН",
            "УСИЛИТЕЛЬ",
            "ФОТОРАМКА",
            "ЭЛЕКТРОННАЯ КНИГА"});
            this.What_remont_combo_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.What_remont_combo_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.What_remont_combo_box.FormattingEnabled = true;
            this.What_remont_combo_box.Location = new System.Drawing.Point(16, 171);
            this.What_remont_combo_box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.What_remont_combo_box.Name = "What_remont_combo_box";
            this.What_remont_combo_box.Size = new System.Drawing.Size(348, 24);
            this.What_remont_combo_box.TabIndex = 4;
            this.What_remont_combo_box.SelectedIndexChanged += new System.EventHandler(this.What_remont_combo_box_SelectedIndexChanged);
            this.What_remont_combo_box.TextChanged += new System.EventHandler(this.What_remont_combo_box_TextChanged);
            // 
            // NewOrderButton
            // 
            this.NewOrderButton.BackColor = System.Drawing.Color.White;
            this.NewOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewOrderButton.Location = new System.Drawing.Point(16, 15);
            this.NewOrderButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewOrderButton.Name = "NewOrderButton";
            this.NewOrderButton.Size = new System.Drawing.Size(349, 47);
            this.NewOrderButton.TabIndex = 1;
            this.NewOrderButton.Text = "Очистить содержимое полей";
            this.NewOrderButton.UseVisualStyleBackColor = false;
            this.NewOrderButton.Click += new System.EventHandler(this.NewOrderButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(123, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 133;
            this.label2.Text = "Тип устройства";
            // 
            // AddButton
            // 
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.Location = new System.Drawing.Point(15, 612);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(1075, 33);
            this.AddButton.TabIndex = 22;
            this.AddButton.Text = "Добавить запись";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // kommentarijTextBox
            // 
            this.kommentarijTextBox.Location = new System.Drawing.Point(15, 667);
            this.kommentarijTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kommentarijTextBox.Multiline = true;
            this.kommentarijTextBox.Name = "kommentarijTextBox";
            this.kommentarijTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.kommentarijTextBox.Size = new System.Drawing.Size(1073, 150);
            this.kommentarijTextBox.TabIndex = 21;
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SurnameTextBox.Location = new System.Drawing.Point(16, 82);
            this.SurnameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(348, 23);
            this.SurnameTextBox.TabIndex = 2;
            this.SurnameTextBox.Click += new System.EventHandler(this.SurnameTextBox_Click);
            this.SurnameTextBox.TextChanged += new System.EventHandler(this.SerialTextBox_TextChanged);
            this.SurnameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SurnameTextBox_KeyDown);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label15.Location = new System.Drawing.Point(417, 560);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(267, 15);
            this.label15.TabIndex = 157;
            this.label15.Text = "Мастер";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MasterComboBox
            // 
            this.MasterComboBox.FormattingEnabled = true;
            this.MasterComboBox.Location = new System.Drawing.Point(379, 578);
            this.MasterComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MasterComboBox.Name = "MasterComboBox";
            this.MasterComboBox.Size = new System.Drawing.Size(348, 24);
            this.MasterComboBox.TabIndex = 20;
            // 
            // SostoyanieTextBox
            // 
            this.SostoyanieTextBox.Location = new System.Drawing.Point(16, 409);
            this.SostoyanieTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SostoyanieTextBox.Multiline = true;
            this.SostoyanieTextBox.Name = "SostoyanieTextBox";
            this.SostoyanieTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SostoyanieTextBox.Size = new System.Drawing.Size(348, 195);
            this.SostoyanieTextBox.TabIndex = 9;
            this.SostoyanieTextBox.TextChanged += new System.EventHandler(this.SostoyanieTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(164, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 120;
            this.label3.Text = "ФИО";
            this.label3.Click += new System.EventHandler(this.zzz);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label14.Location = new System.Drawing.Point(111, 366);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(148, 17);
            this.label14.TabIndex = 156;
            this.label14.Text = "Состояние приема";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label13.Location = new System.Drawing.Point(419, 508);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(265, 15);
            this.label13.TabIndex = 155;
            this.label13.Text = "Статус заказа";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SostoyaniePriemaComboBox
            // 
            this.SostoyaniePriemaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SostoyaniePriemaComboBox.FormattingEnabled = true;
            this.SostoyaniePriemaComboBox.Location = new System.Drawing.Point(16, 384);
            this.SostoyaniePriemaComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SostoyaniePriemaComboBox.Name = "SostoyaniePriemaComboBox";
            this.SostoyaniePriemaComboBox.Size = new System.Drawing.Size(348, 24);
            this.SostoyaniePriemaComboBox.TabIndex = 8;
            this.SostoyaniePriemaComboBox.SelectedIndexChanged += new System.EventHandler(this.SostoyaniePriemaComboBox_SelectedIndexChanged);
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Items.AddRange(new object[] {
            "Диагностика",
            "Согласование с клиентом",
            "Согласовано",
            "Принят в работу",
            "Ждёт запчасть",
            "Принят по гарантии",
            "Готов"});
            this.StatusComboBox.Location = new System.Drawing.Point(380, 526);
            this.StatusComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(347, 24);
            this.StatusComboBox.TabIndex = 19;
            this.StatusComboBox.Text = "Диагностика";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(116, 198);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 17);
            this.label7.TabIndex = 130;
            this.label7.Text = "Название бренда";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(417, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 15);
            this.label1.TabIndex = 181;
            this.label1.Text = "Адрес клиента";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdressKlientTextBox
            // 
            this.AdressKlientTextBox.Location = new System.Drawing.Point(379, 290);
            this.AdressKlientTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AdressKlientTextBox.Multiline = true;
            this.AdressKlientTextBox.Name = "AdressKlientTextBox";
            this.AdressKlientTextBox.Size = new System.Drawing.Size(348, 50);
            this.AdressKlientTextBox.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(740, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(349, 15);
            this.label9.TabIndex = 196;
            this.label9.Text = "Цвет устройства";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeviceColourComboBox
            // 
            this.DeviceColourComboBox.FormattingEnabled = true;
            this.DeviceColourComboBox.Location = new System.Drawing.Point(740, 31);
            this.DeviceColourComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeviceColourComboBox.Name = "DeviceColourComboBox";
            this.DeviceColourComboBox.Size = new System.Drawing.Size(348, 24);
            this.DeviceColourComboBox.TabIndex = 195;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(740, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(349, 15);
            this.label6.TabIndex = 194;
            this.label6.Text = "Адрес СЦ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServiceAdressComboBox
            // 
            this.ServiceAdressComboBox.FormattingEnabled = true;
            this.ServiceAdressComboBox.Items.AddRange(new object[] {
            ""});
            this.ServiceAdressComboBox.Location = new System.Drawing.Point(740, 80);
            this.ServiceAdressComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ServiceAdressComboBox.Name = "ServiceAdressComboBox";
            this.ServiceAdressComboBox.Size = new System.Drawing.Size(348, 24);
            this.ServiceAdressComboBox.TabIndex = 193;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(15, 836);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(829, 33);
            this.button1.TabIndex = 197;
            this.button1.Text = "Напечатать пустой акт приёма, без занесения в базу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PrimechanieTextBox
            // 
            this.PrimechanieTextBox.Location = new System.Drawing.Point(740, 128);
            this.PrimechanieTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PrimechanieTextBox.Multiline = true;
            this.PrimechanieTextBox.Name = "PrimechanieTextBox";
            this.PrimechanieTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrimechanieTextBox.Size = new System.Drawing.Size(348, 422);
            this.PrimechanieTextBox.TabIndex = 198;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(740, 110);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(349, 15);
            this.label5.TabIndex = 199;
            this.label5.Text = "Заметка о клиенте (клиенту не видна)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BlackListComboBox
            // 
            this.BlackListComboBox.FormattingEnabled = true;
            this.BlackListComboBox.Items.AddRange(new object[] {
            "Не проблемный",
            "Проблемный"});
            this.BlackListComboBox.Location = new System.Drawing.Point(740, 578);
            this.BlackListComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BlackListComboBox.Name = "BlackListComboBox";
            this.BlackListComboBox.Size = new System.Drawing.Size(348, 24);
            this.BlackListComboBox.TabIndex = 200;
            this.BlackListComboBox.Text = "Не проблемный";
            this.BlackListComboBox.TextChanged += new System.EventHandler(this.BlackListComboBox_TextChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(740, 560);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(349, 15);
            this.label11.TabIndex = 201;
            this.label11.Text = "Тип клиента";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RepairHistoryLabel
            // 
            this.RepairHistoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RepairHistoryLabel.Location = new System.Drawing.Point(1149, 4);
            this.RepairHistoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RepairHistoryLabel.Name = "RepairHistoryLabel";
            this.RepairHistoryLabel.Size = new System.Drawing.Size(221, 23);
            this.RepairHistoryLabel.TabIndex = 202;
            this.RepairHistoryLabel.Text = "История клиента";
            this.RepairHistoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(1101, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 787);
            this.panel1.TabIndex = 203;
            // 
            // AddPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1416, 823);
            this.Controls.Add(this.RepairHistoryLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BlackListComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PrimechanieTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DeviceColourComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ServiceAdressComboBox);
            this.Controls.Add(this.AdressKlientTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.PredvaritelnayaStoimostTextBox);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.PolomkaComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PolomkaTextBox);
            this.Controls.Add(this.KomplektnostTextBox);
            this.Controls.Add(this.KomplektonstComboBox);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.SerialTextBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.ModelTextBox);
            this.Controls.Add(this.PredoplataTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.BrandComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AboutUsComboBox);
            this.Controls.Add(this.What_remont_combo_box);
            this.Controls.Add(this.NewOrderButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.kommentarijTextBox);
            this.Controls.Add(this.SurnameTextBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.MasterComboBox);
            this.Controls.Add(this.SostoyanieTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.SostoyaniePriemaComboBox);
            this.Controls.Add(this.StatusComboBox);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "AddPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить заказ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddPosition_FormClosed);
            this.Load += new System.EventHandler(this.AddPosition_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddPosition_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

	}
}
