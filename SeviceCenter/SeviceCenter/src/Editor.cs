// Editor

using SeviceCenter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

public class Editor : Form
{
	private string Close_surname = "";

	private string Close_phone = "";

	private string Close_AboutUs = "";

	private string Close_What_remont = "";

	private string Close_Brand = "";

	private string Close_Model = "";

	private string Close_Serial = "";

	private string Close_Sostoyanie = "";

	private string Close_Komplektnost = "";

	private string Close_Polomka = "";

	private string Close_kommentarij = "";

	private string Close_PredvaritelnayaStoimost = "";

	private string Close_Predoplata = "";

	private string Close_Zatraty = "";

	private string Close_Price = "";

	private string Close_Skidka = "";

	private string Close_Status = "";

	private string Close_Master = "";

	private string Close_VipolnenieRaboti = "";

	private string Close_Garanty = "";

	private string Close_Wait_zakaz = "";

	private string Close_AdressKlient = "";

	private string Close_KlientGalochkaVKurse = "";

	private string Close_ServiceAdress = "";

	private string Close_DeviceColour = "";

	private string ClientId_inBase = "";

	private string id_bd;

	private bool WhenClosing = false;

	private IniFile INIF = new IniFile("Config.ini");

	private MainForm mainForm;

	private bool autoButton = true;

	private bool autoBool = false;

	private bool fuckthemool = true;

	private IContainer components = null;

	public CheckBox checkBox3;

	public MaskedTextBox phoneTextBox;

	public TextBox SkidkaTextBox;

	public Label label1;

	public Label label24;

	public ComboBox GarantyComboBox;

	public TextBox VipolnenieRabotiTextBox;

	public Label label16;

	public Label label23;

	public Button AktVidachiButton;

	public Button AktPriemaButton;

	public TextBox PredvaritelnayaStoimostTextBox;

	public Label label22;

	public Label label21;

	public TextBox PriceTextBox;

	public Label label10;

	public Label label4;

	public TextBox PolomkaTextBox;

	public TextBox KomplektnostTextBox;

	public Label label20;

	public TextBox SerialTextBox;

	public Label label19;

	public Label label11;

	public TextBox ModelTextBox;

	public TextBox PredoplataTextBox;

	public Label label12;

	public TextBox ZatratyTextBox;

	public Label label18;

	public ComboBox BrandComboBox;

	public Label label8;

	public ComboBox AboutUsComboBox;

	public ComboBox What_remont_combo_box;

	public Label label2;

	public Button DeleteButton;

	public TextBox kommentarijTextBox;

	public TextBox SurnameTextBox;

	public Label label15;

	public ComboBox MasterComboBox;

	public TextBox SostoyanieTextBox;

	public Label label3;

	public Label label14;

	public Label label13;

	public ComboBox StatusComboBox;

	public Label label7;

	public Button SaveButton;

	public Label label5;

	public TextBox AdressKlientTextBox;

	private Button DataEditorButton;

	private Label NumberLabel;

	public ComboBox VipolnenieRabotiComboBox;

	private CheckBox KlientVKurse;

	private ComboBox ServiceAdressComboBox;

	private Label label6;

	private ComboBox DeviceColourComboBox;

	private Label label9;

	private Button GoToTheStockButton;

	private Button AktVidachiGarantiiButton;

	private Button AktPriemaGarantiiButton;

	private Button StatusButton;

	private Label RepairHistoryLabel;

	public Panel panel1;

	private TabControl tabControl1;

	private TabPage ZapisPage;

	private TabPage klientPage;

	public Label label17;

	public TextBox ClientFioTextBox;

	public TextBox ClientAdressTextBox;

	public ComboBox ClientAboutUsComboBox;

	public Label label25;

	public Label label26;

	public MaskedTextBox ClientPhoneTextBox;

	public Label label27;

	private Label label28;

	public ComboBox BlackListComboBox;

	private Label label29;

	public TextBox PrimechanieTextBox;

	public Button SaveClientButton;

	private Label label30;

	public Panel panel2;

	public Button OpenFolderButton;

	public Editor(MainForm fm1, string id_bd)
	{
		mainForm = fm1;
		this.id_bd = id_bd;
		InitializeComponent();
		What_remont_combo_box.MouseWheel += What_remont_combo_box_MouseWheel;
		BrandComboBox.MouseWheel += BrandComboBox_MouseWheel;
		DeviceColourComboBox.MouseWheel += DeviceColourComboBox_MouseWheel;
		ServiceAdressComboBox.MouseWheel += ServiceAdressComboBox_MouseWheel;
		AboutUsComboBox.MouseWheel += AboutUsComboBox_MouseWheel;
		MasterComboBox.MouseWheel += MasterComboBox_MouseWheel;
		GarantyComboBox.MouseWheel += GarantyComboBox_MouseWheel;
		StatusComboBox.MouseWheel += StatusComboBox_MouseWheel;
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

	private void GarantyComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void StatusComboBox_MouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void Editor_MouseDown(object sender, MouseEventArgs e)
	{
		base.Capture = false;
		Message m = Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
		WndProc(ref m);
	}

	private void NewOrderButton_Click(object sender, EventArgs e)
	{
	}

	private void label6_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void label20_MouseDown(object sender, MouseEventArgs e)
	{
		label20.Capture = false;
		Message m = Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
		WndProc(ref m);
	}

	private void label13_MouseDown(object sender, MouseEventArgs e)
	{
	}

	private void SaveButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Сохранить запись номер " + id_bd + "?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			WhenClosing = true;
			autoBool = true;
			fuckthemool = true;
			mainForm.basa.ClientsMapEditInEditor(SurnameTextBox.Text, PhoneToNorm(phoneTextBox.Text), AdressKlientTextBox.Text, AboutUsComboBox.Text, ClientId_inBase);
			mainForm.basa.BdEdit(PredoplataDate(PredoplataTextBox.Text), VidachiDate(), "", "", "", What_remont_combo_box.Text, BrandComboBox.Text, ModelTextBox.Text, SerialTextBox.Text, SostoyanieTextBox.Text, KomplektnostTextBox.Text, PolomkaTextBox.Text, kommentarijTextBox.Text, EmptyStringToZeroMaker(PredvaritelnayaStoimostTextBox.Text), EmptyStringToZeroMaker(PredoplataTextBox.Text), EmptyStringToZeroMaker(ZatratyTextBox.Text), EmptyStringToZeroMaker(PriceTextBox.Text), EmptyStringToZeroMaker(SkidkaTextBox.Text), StatusComboBox.Text, MasterComboBox.Text, VipolnenieRabotiTextBox.Text, GarantyComboBox.Text, NeedZakaz(), "", KlinentVKurseTester(), id_bd, ServiceAdressComboBox.Text, DeviceColourComboBox.Text);
			mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Сохранение", editorHistoryMaker(), id_bd);
			mainForm.StatusStripLabel.Text = "Запись номер " + id_bd + " сохранена";
			if (mainForm.ShowPhoneWaitingButton.Checked)
			{
				TemporaryBase.SearchFULLBegin("1");
			}
			else
			{
				TemporaryBase.SearchFULLBegin();
			}
			Close();
		}
	}

	private string editorHistoryMaker()
	{
		string text = "";
		if (!(Close_surname == SurnameTextBox.Text))
		{
			text = text + "Изменено: " + Close_surname + " НА: " + SurnameTextBox.Text + Environment.NewLine;
		}
		if (!(Close_phone == phoneTextBox.Text))
		{
			text = text + "Изменено: " + Close_phone + " НА: " + phoneTextBox.Text + Environment.NewLine;
		}
		if (!(Close_AboutUs == AboutUsComboBox.Text))
		{
			text = text + "Изменено: " + Close_AboutUs + " НА: " + AboutUsComboBox.Text + Environment.NewLine;
		}
		if (!(Close_What_remont == What_remont_combo_box.Text))
		{
			text = text + "Изменено: " + Close_What_remont + " НА: " + What_remont_combo_box.Text + Environment.NewLine;
		}
		if (!(Close_Brand == BrandComboBox.Text))
		{
			text = text + "Изменено: " + Close_Brand + " НА: " + BrandComboBox.Text + Environment.NewLine;
		}
		if (!(Close_Model == ModelTextBox.Text))
		{
			text = text + "Изменено: " + Close_Model + " НА: " + ModelTextBox.Text + Environment.NewLine;
		}
		if (!(Close_Serial == SerialTextBox.Text))
		{
			text = text + "Изменено: " + Close_Serial + " НА: " + SerialTextBox.Text + Environment.NewLine;
		}
		if (!(Close_Sostoyanie == SostoyanieTextBox.Text))
		{
			text = text + "Изменено: " + Close_Sostoyanie + " НА: " + SostoyanieTextBox.Text + Environment.NewLine;
		}
		if (!(Close_Komplektnost == KomplektnostTextBox.Text))
		{
			text = text + "Изменено: " + Close_Komplektnost + " НА: " + KomplektnostTextBox.Text + Environment.NewLine;
		}
		if (!(Close_Polomka == PolomkaTextBox.Text))
		{
			text = text + "Изменено: " + Close_Polomka + " НА: " + PolomkaTextBox.Text + Environment.NewLine;
		}
		if (!(Close_kommentarij == kommentarijTextBox.Text))
		{
			text = text + "Изменено: " + Close_kommentarij + " НА: " + kommentarijTextBox.Text + Environment.NewLine;
		}
		if (!(Close_PredvaritelnayaStoimost == PredvaritelnayaStoimostTextBox.Text))
		{
			text = text + "Изменено: " + Close_PredvaritelnayaStoimost + " НА: " + PredvaritelnayaStoimostTextBox.Text + Environment.NewLine;
		}
		if (!(Close_Predoplata == PredoplataTextBox.Text))
		{
			text = text + "Изменено: " + Close_Predoplata + " НА: " + PredoplataTextBox.Text + Environment.NewLine;
		}
		if (!(Close_Zatraty == ZatratyTextBox.Text))
		{
			text = text + "Изменено: " + Close_Zatraty + " НА: " + ZatratyTextBox.Text + Environment.NewLine;
		}
		if (!(Close_Price == PriceTextBox.Text))
		{
			text = text + "Изменено: " + Close_Price + " НА: " + PriceTextBox.Text + Environment.NewLine;
		}
		if (!(Close_Skidka == SkidkaTextBox.Text))
		{
			text = text + "Изменено: " + Close_Skidka + " НА: " + SkidkaTextBox.Text + Environment.NewLine;
		}
		if (!(Close_Status == StatusComboBox.Text))
		{
			text = text + "Изменено: " + Close_Status + " НА: " + StatusComboBox.Text + Environment.NewLine;
		}
		if (!(Close_Master == MasterComboBox.Text))
		{
			text = text + "Изменено: " + Close_Master + " НА: " + MasterComboBox.Text + Environment.NewLine;
		}
		if (!(Close_VipolnenieRaboti == VipolnenieRabotiTextBox.Text))
		{
			text = text + "Изменено: " + Close_VipolnenieRaboti + " НА: " + VipolnenieRabotiTextBox.Text + Environment.NewLine;
		}
		if (!(Close_AdressKlient == AdressKlientTextBox.Text))
		{
			text = text + "Изменено: " + Close_AdressKlient + " НА: " + AdressKlientTextBox.Text + Environment.NewLine;
		}
		if (!(Close_ServiceAdress == ServiceAdressComboBox.Text))
		{
			text = text + "Изменено: " + Close_ServiceAdress + " НА: " + ServiceAdressComboBox.Text + Environment.NewLine;
		}
		if (!(Close_DeviceColour == DeviceColourComboBox.Text))
		{
			text = text + "Изменено: " + Close_DeviceColour + " НА: " + DeviceColourComboBox.Text + Environment.NewLine;
		}
		return text;
	}

	private string PhoneToNorm(string phone)
	{
		return phone.Replace(" ", "");
	}

	private string KlinentVKurseTester()
	{
		if (KlientVKurse.Checked)
		{
			return "1";
		}
		return "";
	}

	private string VidachiDate()
	{
		if (mainForm.basa.BdReadOne("Data_vidachi", id_bd) != "")
		{
			return mainForm.basa.BdReadOne("Data_vidachi", id_bd);
		}
		return "";
	}

	private string PredoplataDate(string str1)
	{
		if (str1 != "" && str1 != "0")
		{
			return mainForm.basa.BdReadOne("Data_predoplaty", id_bd);
		}
		return "";
	}

	private string NeedZakaz()
	{
		if (checkBox3.Checked)
		{
			return "Заказать";
		}
		return "";
	}

	private void DataEditorButton_Click(object sender, EventArgs e)
	{
		DataEditor dataEditor = new DataEditor(mainForm, id_bd, this);
		base.Enabled = false;
		dataEditor.Show();
	}

	public void MyMethod(object sender, EventArgs e)
	{
		Label label = (Label)sender;
		Editor editor = new Editor(mainForm, label.Tag.ToString());
		editor.Show(mainForm);
	}

	public void ClientsHistoryMaker(string clientNum)
	{
		DataTable dataTable = mainForm.basa.ClientsShowHistory(clientNum);
		int num = 3;
		int num2 = 3;
		int num3 = panel2.Width - num * 2 - 2;
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
			if (num2 > panel2.Height)
			{
				item.MinimumSize = new Size(num3 - 18, 107);
			}
		}
		panel2.Controls.Clear();
		ToolTip toolTip = new ToolTip();
		toolTip.AutoPopDelay = 30000;
		int num4 = 0;
		foreach (Label item2 in list)
		{
			item2.MouseClick += MyMethod;
			panel2.Controls.Add(item2);
			toolTip.SetToolTip(item2, "Адрес СЦ: " + dataTable.Rows[num4].ItemArray[27].ToString() + Environment.NewLine + "Выполненные работы: " + dataTable.Rows[num4].ItemArray[22].ToString() + Environment.NewLine + "Мастер: " + dataTable.Rows[num4].ItemArray[21].ToString() + Environment.NewLine + "Поломка: " + dataTable.Rows[num4].ItemArray[13].ToString() + Environment.NewLine + "Комментарий: " + dataTable.Rows[num4].ItemArray[14].ToString() + Environment.NewLine);
			num4++;
		}
	}

	private void Editor_Load(object sender, EventArgs e)
	{
		DeleteButton.Enabled = ((TemporaryBase.delZapis == "1") ? true : false);
		SaveButton.Enabled = ((TemporaryBase.saveZapis == "1") ? true : false);
		AktPriemaButton.Enabled = ((TemporaryBase.saveZapis == "1") ? true : false);
		AktVidachiButton.Enabled = ((TemporaryBase.saveZapis == "1") ? true : false);
		AktPriemaGarantiiButton.Enabled = ((TemporaryBase.saveZapis == "1") ? true : false);
		AktVidachiGarantiiButton.Enabled = ((TemporaryBase.saveZapis == "1") ? true : false);
		DataEditorButton.Enabled = ((TemporaryBase.dates == "1") ? true : false);
		GoToTheStockButton.Enabled = ((TemporaryBase.stock == "1") ? true : false);
		mainForm.MainListView.Enabled = false;
		DataTable dataTable = mainForm.basa.BdReadOneEditor(id_bd);
		try
		{
			if (dataTable.Rows.Count > 0)
			{
				NumberLabel.Text = "Редактирование записи номер: " + dataTable.Rows[0].ItemArray[0].ToString();
				ClientId_inBase = dataTable.Rows[0].ItemArray[29].ToString();
				label30.Text = "Редактирование клиента номер: " + ClientId_inBase;
				DataTable dataTable2 = mainForm.basa.ClientsMapGiver(ClientId_inBase);
				ClientsHistoryMaker(ClientId_inBase);
				string text2 = Close_What_remont = (What_remont_combo_box.Text = dataTable.Rows[0].ItemArray[7].ToString());
				text2 = (Close_Brand = (BrandComboBox.Text = dataTable.Rows[0].ItemArray[8].ToString()));
				text2 = (Close_Model = (ModelTextBox.Text = dataTable.Rows[0].ItemArray[9].ToString()));
				text2 = (Close_Serial = (SerialTextBox.Text = dataTable.Rows[0].ItemArray[10].ToString()));
				text2 = (Close_Sostoyanie = (SostoyanieTextBox.Text = dataTable.Rows[0].ItemArray[11].ToString()));
				text2 = (Close_Komplektnost = (KomplektnostTextBox.Text = dataTable.Rows[0].ItemArray[12].ToString()));
				text2 = (Close_Polomka = (PolomkaTextBox.Text = dataTable.Rows[0].ItemArray[13].ToString()));
				text2 = (Close_kommentarij = (kommentarijTextBox.Text = dataTable.Rows[0].ItemArray[14].ToString()));
				text2 = (Close_PredvaritelnayaStoimost = (PredvaritelnayaStoimostTextBox.Text = dataTable.Rows[0].ItemArray[15].ToString()));
				text2 = (Close_Predoplata = (PredoplataTextBox.Text = dataTable.Rows[0].ItemArray[16].ToString()));
				text2 = (Close_Zatraty = (ZatratyTextBox.Text = dataTable.Rows[0].ItemArray[17].ToString()));
				text2 = (Close_Price = (PriceTextBox.Text = dataTable.Rows[0].ItemArray[18].ToString()));
				text2 = (Close_Skidka = (SkidkaTextBox.Text = dataTable.Rows[0].ItemArray[19].ToString()));
				text2 = (Close_Status = (StatusComboBox.Text = dataTable.Rows[0].ItemArray[20].ToString()));
				text2 = (Close_Master = (MasterComboBox.Text = dataTable.Rows[0].ItemArray[21].ToString()));
				text2 = (Close_VipolnenieRaboti = (VipolnenieRabotiTextBox.Text = dataTable.Rows[0].ItemArray[22].ToString()));
				if (dataTable.Rows[0].ItemArray[2].ToString() != "")
				{
					DateTime dateTime = default(DateTime);
					DateTime dateTime2 = default(DateTime);
					dateTime2 = DateTime.Now;
					dateTime = DateTime.Parse(dataTable.Rows[0].ItemArray[2].ToString());
					int days = (dateTime2 - dateTime).Days;
					Text = Text + " | Дней со дня выдачи прошло: " + days;
				}
				if (dataTable.Rows[0].ItemArray[23].ToString() == "")
				{
					if (INIF.KeyExists("CHECKBOX", "garantyDefault"))
					{
						if (INIF.ReadINI("CHECKBOX", "garantyDefault") == "Checked")
						{
							GarantyComboBox.Text = "Без гарантии";
						}
						else
						{
							GarantyComboBox.Text = "30 дней";
						}
					}
				}
				else
				{
					GarantyComboBox.Text = dataTable.Rows[0].ItemArray[23].ToString();
				}
				if (dataTable.Rows[0].ItemArray[24].ToString() == "")
				{
					checkBox3.Checked = false;
				}
				else
				{
					checkBox3.Checked = true;
				}
				Close_Garanty = dataTable.Rows[0].ItemArray[23].ToString();
				Close_Wait_zakaz = dataTable.Rows[0].ItemArray[24].ToString();
				Close_KlientGalochkaVKurse = dataTable.Rows[0].ItemArray[26].ToString();
				KlientGalochkaVKurse(dataTable.Rows[0].ItemArray[26].ToString());
				text2 = (Close_ServiceAdress = (ServiceAdressComboBox.Text = dataTable.Rows[0].ItemArray[27].ToString()));
				text2 = (Close_DeviceColour = (DeviceColourComboBox.Text = dataTable.Rows[0].ItemArray[28].ToString()));
				autoButton = false;
				if (dataTable.Rows[0].ItemArray[2].ToString() != "")
				{
					AktPriemaGarantiiButton.Enabled = true;
					AktVidachiGarantiiButton.Enabled = true;
				}
				if (dataTable2.Rows.Count > 0)
				{
					TextBox clientFioTextBox = ClientFioTextBox;
					text2 = (SurnameTextBox.Text = dataTable2.Rows[0].ItemArray[1].ToString());
					clientFioTextBox.Text = (Close_surname = text2);
					MaskedTextBox clientPhoneTextBox = ClientPhoneTextBox;
					text2 = (phoneTextBox.Text = dataTable2.Rows[0].ItemArray[2].ToString());
					clientPhoneTextBox.Text = (Close_phone = text2);
					TextBox clientAdressTextBox = ClientAdressTextBox;
					text2 = (AdressKlientTextBox.Text = dataTable2.Rows[0].ItemArray[3].ToString());
					clientAdressTextBox.Text = (Close_AdressKlient = text2);
					ComboBox clientAboutUsComboBox = ClientAboutUsComboBox;
					text2 = (AboutUsComboBox.Text = dataTable2.Rows[0].ItemArray[7].ToString());
					clientAboutUsComboBox.Text = (Close_AboutUs = text2);
					BlackListComboBox.Text = KlientBlistDecoder(dataTable2.Rows[0].ItemArray[5].ToString(), "");
					PrimechanieTextBox.Text = dataTable2.Rows[0].ItemArray[4].ToString();
					Text = Text + " | " + KlientBlistDecoder(dataTable2.Rows[0].ItemArray[5].ToString());
				}
				else
				{
					MessageBox.Show("Нет данных о клиенте, обратитесь к разработчику vk.com/scrypto");
				}
			}
			ComboboxMaker("settings/aboutUs.txt", AboutUsComboBox);
			ComboboxMaker("settings/masters.txt", MasterComboBox);
			ComboboxMaker("settings/ustrojstvo.txt", What_remont_combo_box);
			ComboboxMaker("settings/brands.txt", BrandComboBox);
			ComboboxMaker("settings/vipolnRaboti.txt", VipolnenieRabotiComboBox);
			ComboboxMaker("settings/AdresSC.txt", ServiceAdressComboBox);
			ComboboxMaker("settings/DeviceColour.txt", DeviceColourComboBox);
			ComboboxMaker("settings/aboutUs.txt", ClientAboutUsComboBox);
			ComboboxMaker("settings/Garanty.txt", GarantyComboBox);
			DynamicLabelMaker();
		}
		catch (Exception ex)
		{
			MessageBox.Show("Ошибка при загрузке данных из базы" + Environment.NewLine + ex.ToString());
		}
	}

	private string KlientBlistDecoder(string blist)
	{
		if (blist == "0")
		{
			return "Клиент не проблемный";
		}
		if (blist == "1")
		{
			return "Клиент проблемный";
		}
		return "";
	}

	private string KlientBlistDecoder(string blist, string str)
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

	public void DynamicLabelMaker()
	{
		DataTable dataTable = mainForm.basa.StatesMapGiver(id_bd);
		int num = 3;
		int num2 = 3;
		int num3 = panel1.Width - num * 2 - 2;
		List<Label> list = new List<Label>();
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			Label label = new Label();
			label.Text = dataTable.Rows[i].ItemArray[2].ToString() + Environment.NewLine + dataTable.Rows[i].ItemArray[3].ToString();
			label.AutoSize = true;
			label.BorderStyle = BorderStyle.FixedSingle;
			label.Location = new Point(num, num2);
			label.BackColor = Color.White;
			num2 = num2 + label.Height + 27;
			label.Font = new Font("Arial", 9f, FontStyle.Bold);
			list.Add(label);
		}
		panel1.Controls.Clear();
		foreach (Label item in list)
		{
			if (num2 > panel1.Height)
			{
				item.MinimumSize = new Size(num3 - 18, item.Height);
			}
			else
			{
				item.MinimumSize = new Size(num3, item.Height);
			}
			panel1.Controls.Add(item);
		}
	}

	private void KlientGalochkaVKurse(string str)
	{
		if (str == "1")
		{
			KlientVKurse.Checked = true;
		}
		else
		{
			KlientVKurse.Checked = false;
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

	private void NumberLabel_MouseDown(object sender, MouseEventArgs e)
	{
		NumberLabel.Capture = false;
		Message m = Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
		WndProc(ref m);
	}

	private void label13_MouseDown_1(object sender, MouseEventArgs e)
	{
		label13.Capture = false;
		Message m = Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
		WndProc(ref m);
	}

	private void DeleteButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Удалить запись номер " + id_bd + " ?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.BdEditOne("Deleted", "1", id_bd);
			mainForm.StatusStripLabel.Text = "Запись номер " + id_bd + " удалена";
			mainForm.basa.BdStockMapDelete(id_bd);
			TemporaryBase.SearchFULLBegin();
			mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Удаление", "", id_bd);
			Close();
		}
	}

	private void AktVidachiButton_Click(object sender, EventArgs e)
	{

			bool flag = false;
			string text = "";
			if (VipolnenieRabotiTextBox.Text == "")
			{
				text = text + "Заполните поле выполненных работ " + Environment.NewLine;
				flag = true;
			}
			if (MasterComboBox.Text == "")
			{
				text = text + "Выберите Мастера " + Environment.NewLine;
				flag = true;
			}
			if (flag)
			{
				MessageBox.Show(text, "Не заполнены обязательные поля");
			}
			if (!flag && MessageBox.Show("Сохранить все изменения и напечатать акт выдачи?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				WhenClosing = true;
				autoBool = true;
				fuckthemool = true;
				StatusComboBox.Text = "Выдан";
				mainForm.basa.ClientsMapEditInEditor(SurnameTextBox.Text, PhoneToNorm(phoneTextBox.Text), AdressKlientTextBox.Text, AboutUsComboBox.Text, ClientId_inBase);
				mainForm.basa.BdEdit(PredoplataDate(PredoplataTextBox.Text), VidachiDateWhenAktP(), "", "", "", What_remont_combo_box.Text, BrandComboBox.Text, ModelTextBox.Text, SerialTextBox.Text, SostoyanieTextBox.Text, KomplektnostTextBox.Text, PolomkaTextBox.Text, kommentarijTextBox.Text, EmptyStringToZeroMaker(PredvaritelnayaStoimostTextBox.Text), EmptyStringToZeroMaker(PredoplataTextBox.Text), EmptyStringToZeroMaker(ZatratyTextBox.Text), EmptyStringToZeroMaker(PriceTextBox.Text), EmptyStringToZeroMaker(SkidkaTextBox.Text), StatusComboBox.Text, MasterComboBox.Text, VipolnenieRabotiTextBox.Text, GarantyComboBox.Text, "", "", "", id_bd, ServiceAdressComboBox.Text, DeviceColourComboBox.Text);
				mainForm.StatusStripLabel.Text = "Запись номер " + id_bd + " сохранена";
				if (mainForm.ShowPhoneWaitingButton.Checked)
				{
					TemporaryBase.SearchFULLBegin("1");
				}
				else
				{
					TemporaryBase.SearchFULLBegin();
				}
				Printing_AKT_VIDACHI printing_AKT_VIDACHI = new Printing_AKT_VIDACHI(mainForm.basa.BdReadOneEditor(id_bd), mainForm, TemporaryBase.valuta);
				printing_AKT_VIDACHI.Show();
				mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Печать акта выдачи", editorHistoryMaker(), id_bd);
				Close();
			}

	}

	private string VidachiDateWhenAktP()
	{
		if (mainForm.basa.BdReadOne("Data_vidachi", id_bd) != "")
		{
			return mainForm.basa.BdReadOne("Data_vidachi", id_bd);
		}
		return DateTime.Now.ToString("dd-MM-yyyy HH:mm");
	}

	private void button5_Click(object sender, EventArgs e)
	{

			if (MessageBox.Show("Сохранить все изменения и напечатать акт приема?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				autoBool = true;
				fuckthemool = true;
				WhenClosing = true;
				mainForm.basa.ClientsMapEditInEditor(SurnameTextBox.Text, PhoneToNorm(phoneTextBox.Text), AdressKlientTextBox.Text, AboutUsComboBox.Text, ClientId_inBase);
				mainForm.basa.BdEdit(PredoplataDate(PredoplataTextBox.Text), VidachiDate(), "", "", "", What_remont_combo_box.Text, BrandComboBox.Text, ModelTextBox.Text, SerialTextBox.Text, SostoyanieTextBox.Text, KomplektnostTextBox.Text, PolomkaTextBox.Text, kommentarijTextBox.Text, EmptyStringToZeroMaker(PredvaritelnayaStoimostTextBox.Text), EmptyStringToZeroMaker(PredoplataTextBox.Text), EmptyStringToZeroMaker(ZatratyTextBox.Text), EmptyStringToZeroMaker(PriceTextBox.Text), EmptyStringToZeroMaker(SkidkaTextBox.Text), StatusComboBox.Text, MasterComboBox.Text, VipolnenieRabotiTextBox.Text, GarantyComboBox.Text, NeedZakaz(), "", KlinentVKurseTester(), id_bd, ServiceAdressComboBox.Text, DeviceColourComboBox.Text);
				mainForm.StatusStripLabel.Text = "Запись номер " + id_bd + " сохранена";
				if (mainForm.ShowPhoneWaitingButton.Checked)
				{
					TemporaryBase.SearchFULLBegin("1");
				}
				else
				{
					TemporaryBase.SearchFULLBegin();
				}
				Printing_AKT_PRIEMA printing_AKT_PRIEMA = new Printing_AKT_PRIEMA(mainForm.basa.BdReadOneEditor(id_bd), mainForm, TemporaryBase.valuta);
				printing_AKT_PRIEMA.Show();
				mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Печать акта приёма", editorHistoryMaker(), id_bd);
				Close();
			}

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

	private void ZatratyTextBox_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsDigit(e.KeyChar))
		{
			if (e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}
		else if (ZatratyTextBox.Text == "" && e.KeyChar == '0')
		{
			e.Handled = true;
		}
	}

	private void PriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsDigit(e.KeyChar))
		{
			if (e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}
		else if (PriceTextBox.Text == "" && e.KeyChar == '0')
		{
			e.Handled = true;
		}
	}

	private void SkidkaTextBox_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
		{
			e.Handled = true;
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

	private void Editor_FormClosed(object sender, FormClosedEventArgs e)
	{
		mainForm.MainListView.Enabled = true;
	}

	private void VipolnenieRabotiComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (VipolnenieRabotiComboBox.SelectedIndex != -1)
		{
			VipolnenieRabotiTextBox.AppendText(VipolnenieRabotiComboBox.Items[VipolnenieRabotiComboBox.SelectedIndex].ToString() + Environment.NewLine);
			if (VipolnenieRabotiComboBox.SelectedItem.ToString() == "Без ремонта, ")
			{
				GarantyComboBox.SelectedIndex = 0;
			}
		}
	}

	private void SkidkaTextBox_MouseClick(object sender, MouseEventArgs e)
	{
		if (SkidkaTextBox.Text == "0")
		{
			SkidkaTextBox.Text = "";
		}
	}

	private void PriceTextBox_MouseClick(object sender, MouseEventArgs e)
	{
		if (PriceTextBox.Text == "0")
		{
			PriceTextBox.Text = "";
		}
	}

	private void PredoplataTextBox_MouseClick(object sender, MouseEventArgs e)
	{
		if (PredoplataTextBox.Text == "0")
		{
			PredoplataTextBox.Text = "";
		}
	}

	private void PredvaritelnayaStoimostTextBox_MouseClick(object sender, MouseEventArgs e)
	{
		if (PredvaritelnayaStoimostTextBox.Text == "0")
		{
			PredvaritelnayaStoimostTextBox.Text = "";
		}
	}

	private void ZatratyTextBox_MouseClick(object sender, MouseEventArgs e)
	{
		if (ZatratyTextBox.Text == "0")
		{
			ZatratyTextBox.Text = "";
		}
	}

	private void checkBox3_CheckedChanged(object sender, EventArgs e)
	{
		if (!checkBox3.Checked)
		{
			StatusComboBox.Text = "Ждёт запчасть";
		}
		if (!autoButton)
		{
			if (checkBox3.Checked)
			{
				mainForm.basa.StatesMapWrite(id_bd, DateTime.Now.ToString("dd-MM-yyyy HH-mm"), "Установлена галочка" + Environment.NewLine + "Требует заказа");
				DynamicLabelMaker();
			}
			else
			{
				mainForm.basa.StatesMapWrite(id_bd, DateTime.Now.ToString("dd-MM-yyyy HH-mm"), "Снята галочка" + Environment.NewLine + "Требует заказа");
				DynamicLabelMaker();
			}
		}
	}

	private void KlientVKurse_CheckedChanged(object sender, EventArgs e)
	{
		if (!autoButton)
		{
			if (KlientVKurse.Checked)
			{
				mainForm.basa.StatesMapWrite(id_bd, DateTime.Now.ToString("dd-MM-yyyy HH-mm"), "Установлена галочка" + Environment.NewLine + "Нужно согласовать");
				DynamicLabelMaker();
			}
			else
			{
				mainForm.basa.StatesMapWrite(id_bd, DateTime.Now.ToString("dd-MM-yyyy HH-mm"), "Снята галочка" + Environment.NewLine + "Нужно согласовать");
				DynamicLabelMaker();
			}
		}
	}

	private void GoToTheStockButton_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
		if (ZatratyTextBox.Text == "")
		{
			ZatratyTextBox.Text = "0";
		}
		Stock stock = new Stock(mainForm, id_bd, this, ClientId_inBase);
		stock.Show(mainForm);
		base.Enabled = false;
	}

	private void AktPriemaGarantii_Click(object sender, EventArgs e)
	{

			if (MessageBox.Show("Сохранить все изменения и напечатать акт приема по гарантии?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				WhenClosing = true;
				autoBool = true;
				fuckthemool = true;
				StatusComboBox.Text = "Принят по гарантии";
				kommentarijTextBox.AppendText(Environment.NewLine + "Устройство было принято на гарантийный ремонт " + DateTime.Now.ToString("dd.MM.yyyy hh:mm"));
				mainForm.basa.ClientsMapEditInEditor(SurnameTextBox.Text, PhoneToNorm(phoneTextBox.Text), AdressKlientTextBox.Text, AboutUsComboBox.Text, ClientId_inBase);
				mainForm.basa.BdEditVidachiPoGarantii(PredoplataDate(PredoplataTextBox.Text), VidachiDate(), "", "", "", What_remont_combo_box.Text, BrandComboBox.Text, ModelTextBox.Text, SerialTextBox.Text, SostoyanieTextBox.Text, KomplektnostTextBox.Text, PolomkaTextBox.Text, kommentarijTextBox.Text, EmptyStringToZeroMaker(PredvaritelnayaStoimostTextBox.Text), EmptyStringToZeroMaker(PredoplataTextBox.Text), EmptyStringToZeroMaker(ZatratyTextBox.Text), EmptyStringToZeroMaker(PriceTextBox.Text), EmptyStringToZeroMaker(SkidkaTextBox.Text), StatusComboBox.Text, MasterComboBox.Text, VipolnenieRabotiTextBox.Text, GarantyComboBox.Text, NeedZakaz(), "", KlinentVKurseTester(), id_bd, ServiceAdressComboBox.Text, DeviceColourComboBox.Text);
				mainForm.StatusStripLabel.Text = "Запись номер " + id_bd + " сохранена";
				if (mainForm.ShowPhoneWaitingButton.Checked)
				{
					TemporaryBase.SearchFULLBegin("1");
				}
				else
				{
					TemporaryBase.SearchFULLBegin();
				}
				ActPriemaPoGarantii actPriemaPoGarantii = new ActPriemaPoGarantii(mainForm.basa.BdReadOneEditor(id_bd), mainForm, TemporaryBase.valuta);
				actPriemaPoGarantii.Show();
				mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Печать акта приёма по гарантии", editorHistoryMaker(), id_bd);
				Close();
			}

	}

	private void AktVidachiGarantiiButton_Click(object sender, EventArgs e)
	{

			bool flag = false;
			string text = "";
			if (VipolnenieRabotiTextBox.Text == "")
			{
				text = text + "Заполните поле выполненных работ " + Environment.NewLine;
				flag = true;
			}
			if (MasterComboBox.Text == "")
			{
				text = text + "Выберите Мастера " + Environment.NewLine;
				flag = true;
			}
			if (flag)
			{
				MessageBox.Show(text, "Не заполнены обязательные поля");
			}
			if (!flag && MessageBox.Show("Сохранить все изменения и напечатать акт выдачи?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				WhenClosing = true;
				autoBool = true;
				fuckthemool = true;
				StatusComboBox.Text = "Выдан";
				kommentarijTextBox.AppendText(Environment.NewLine + "Устройство было выдано после гарантийного ремонта " + DateTime.Now.ToString("dd.MM.yyyy hh:mm"));
				mainForm.basa.ClientsMapEditInEditor(SurnameTextBox.Text, PhoneToNorm(phoneTextBox.Text), AdressKlientTextBox.Text, AboutUsComboBox.Text, ClientId_inBase);
				mainForm.basa.BdEditVidachiPoGarantii(PredoplataDate(PredoplataTextBox.Text), VidachiDateWhenAktP(), "", "", "", What_remont_combo_box.Text, BrandComboBox.Text, ModelTextBox.Text, SerialTextBox.Text, SostoyanieTextBox.Text, KomplektnostTextBox.Text, PolomkaTextBox.Text, kommentarijTextBox.Text, EmptyStringToZeroMaker(PredvaritelnayaStoimostTextBox.Text), EmptyStringToZeroMaker(PredoplataTextBox.Text), EmptyStringToZeroMaker(ZatratyTextBox.Text), EmptyStringToZeroMaker(PriceTextBox.Text), EmptyStringToZeroMaker(SkidkaTextBox.Text), StatusComboBox.Text, MasterComboBox.Text, VipolnenieRabotiTextBox.Text, GarantyComboBox.Text, "", "", "", id_bd, ServiceAdressComboBox.Text, DeviceColourComboBox.Text);
				mainForm.StatusStripLabel.Text = "Запись номер " + id_bd + " сохранена";
				if (mainForm.ShowPhoneWaitingButton.Checked)
				{
					TemporaryBase.SearchFULLBegin("1");
				}
				else
				{
					TemporaryBase.SearchFULLBegin();
				}
				ActVidachiPoGarantii actVidachiPoGarantii = new ActVidachiPoGarantii(mainForm.basa.BdReadOneEditor(id_bd), mainForm, TemporaryBase.valuta);
				actVidachiPoGarantii.Show();
				mainForm.basa.HistoryBDWrite(TemporaryBase.USER_SESSION, "Печать акта выдачи по гарантии", editorHistoryMaker(), id_bd);
				Close();
			}

	}

	private void Editor_FormClosing(object sender, FormClosingEventArgs e)
	{
		DataTable dataTable = mainForm.basa.BdReadOneEditor(id_bd);
		try
		{
			if (dataTable.Rows.Count > 0 && !WhenClosing && (!(Close_surname == SurnameTextBox.Text) || !(Close_phone == phoneTextBox.Text) || !(Close_AboutUs == AboutUsComboBox.Text) || !(Close_What_remont == What_remont_combo_box.Text) || !(Close_Brand == BrandComboBox.Text) || !(Close_Model == ModelTextBox.Text) || !(Close_Serial == SerialTextBox.Text) || !(Close_Sostoyanie == SostoyanieTextBox.Text) || !(Close_Komplektnost == KomplektnostTextBox.Text) || !(Close_Polomka == PolomkaTextBox.Text) || !(Close_kommentarij == kommentarijTextBox.Text) || !(Close_PredvaritelnayaStoimost == PredvaritelnayaStoimostTextBox.Text) || !(Close_Predoplata == PredoplataTextBox.Text) || !(Close_Zatraty == ZatratyTextBox.Text) || !(Close_Price == PriceTextBox.Text) || !(Close_Skidka == SkidkaTextBox.Text) || !(Close_Status == StatusComboBox.Text) || !(Close_Master == MasterComboBox.Text) || !(Close_VipolnenieRaboti == VipolnenieRabotiTextBox.Text) || !(Close_Garanty == dataTable.Rows[0].ItemArray[23].ToString()) || !(Close_Wait_zakaz == dataTable.Rows[0].ItemArray[24].ToString()) || !(Close_KlientGalochkaVKurse == dataTable.Rows[0].ItemArray[26].ToString()) || !(Close_AdressKlient == AdressKlientTextBox.Text) || !(Close_ServiceAdress == ServiceAdressComboBox.Text) || !(Close_DeviceColour == DeviceColourComboBox.Text)))
			{
				if (MessageBox.Show("Есть несохраненные изменения, вы точно хотитие закрыть окно?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				{
					e.Cancel = true;
				}
				else
				{
					e.Cancel = false;
				}
			}
		}
		catch
		{
		}
	}

	private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!autoButton && !autoBool && StatusComboBox.Text == "Выдан" && Close_Status != "Выдан")
		{
			if (MessageBox.Show("Вы поставили статус Выдан в ручном режиме, если вы нажмёте OK, база автоматически установит дату выдачи для этого заказа", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				mainForm.basa.BdEditOne("Data_vidachi", DateTime.Now.ToString("dd-MM-yyyy HH:mm"), id_bd);
				mainForm.basa.BdEditOne("Status_remonta", "Выдан", id_bd);
				Close_Status = "Выдан";
				StatusComboBox.Enabled = false;
				TemporaryBase.SearchFULLBegin();
			}
			else
			{
				fuckthemool = false;
				StatusComboBox.Text = Close_Status;
			}
		}
		if (!autoButton && fuckthemool)
		{
			mainForm.basa.StatesMapWrite(id_bd, DateTime.Now.ToString("dd-MM-yyyy HH-mm"), "Установлен статус" + Environment.NewLine + StatusComboBox.Text);
			DynamicLabelMaker();
		}
	}

	private void StatusButton_Click(object sender, EventArgs e)
	{
		States states = new States(mainForm, id_bd, this);
		states.Show();
		base.Enabled = false;
	}

	private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
	{
		if (tabControl1.SelectedTab == tabControl1.TabPages[0])
		{
			panel2.Visible = false;
			panel1.Visible = true;
			RepairHistoryLabel.Text = "История ремонта";
			base.Width = 1069;
		}
		else if (tabControl1.SelectedTab == tabControl1.TabPages[1])
		{
			panel2.Visible = true;
			panel1.Visible = false;
			RepairHistoryLabel.Text = "История клиента";
			base.Width = 573;
		}
	}

	private void SaveClientButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Сохранить данные о клиенте?" + Environment.NewLine + "Сохраняются только данные о клиенте, окно не закроется, так что информацию о записи можно сохранить во вкладке запись", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.ClientsMapEditWithoutDate(ClientFioTextBox.Text, PhoneToNorm(ClientPhoneTextBox.Text), ClientAdressTextBox.Text, PrimechanieTextBox.Text, BlistOfClients(), ClientAboutUsComboBox.Text, ClientId_inBase);
			string text2 = Close_surname = (SurnameTextBox.Text = ClientFioTextBox.Text);
			text2 = (Close_phone = (phoneTextBox.Text = ClientPhoneTextBox.Text));
			text2 = (Close_AdressKlient = (AdressKlientTextBox.Text = ClientAdressTextBox.Text));
			text2 = (Close_AboutUs = (AboutUsComboBox.Text = ClientAboutUsComboBox.Text));
			Text = "Редактирование | " + KlientBlistDecoder(BlistOfClients());
			TemporaryBase.SearchFULLBegin();
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

	private void MasterComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!autoButton)
		{
			mainForm.basa.StatesMapWrite(id_bd, DateTime.Now.ToString("dd-MM-yyyy HH:mm"), "Назначен мастер" + Environment.NewLine + MasterComboBox.Text);
			DynamicLabelMaker();
		}
	}

	private void klientPage_Click(object sender, EventArgs e)
	{
	}

	private void SerialTextBox_TextChanged(object sender, EventArgs e)
	{
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

	private void OpenFolderButton_Click(object sender, EventArgs e)
	{
		string text = "ClientFiles\\" + ClientId_inBase + "\\" + id_bd;
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		Process.Start("explorer", text ?? "");
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
		checkBox3 = new System.Windows.Forms.CheckBox();
		phoneTextBox = new System.Windows.Forms.MaskedTextBox();
		SkidkaTextBox = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		label24 = new System.Windows.Forms.Label();
		GarantyComboBox = new System.Windows.Forms.ComboBox();
		VipolnenieRabotiTextBox = new System.Windows.Forms.TextBox();
		label16 = new System.Windows.Forms.Label();
		label23 = new System.Windows.Forms.Label();
		PredvaritelnayaStoimostTextBox = new System.Windows.Forms.TextBox();
		label22 = new System.Windows.Forms.Label();
		label21 = new System.Windows.Forms.Label();
		PriceTextBox = new System.Windows.Forms.TextBox();
		label10 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		PolomkaTextBox = new System.Windows.Forms.TextBox();
		KomplektnostTextBox = new System.Windows.Forms.TextBox();
		label20 = new System.Windows.Forms.Label();
		SerialTextBox = new System.Windows.Forms.TextBox();
		label19 = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		ModelTextBox = new System.Windows.Forms.TextBox();
		PredoplataTextBox = new System.Windows.Forms.TextBox();
		label12 = new System.Windows.Forms.Label();
		ZatratyTextBox = new System.Windows.Forms.TextBox();
		label18 = new System.Windows.Forms.Label();
		BrandComboBox = new System.Windows.Forms.ComboBox();
		label8 = new System.Windows.Forms.Label();
		AboutUsComboBox = new System.Windows.Forms.ComboBox();
		What_remont_combo_box = new System.Windows.Forms.ComboBox();
		label2 = new System.Windows.Forms.Label();
		kommentarijTextBox = new System.Windows.Forms.TextBox();
		SurnameTextBox = new System.Windows.Forms.TextBox();
		label15 = new System.Windows.Forms.Label();
		MasterComboBox = new System.Windows.Forms.ComboBox();
		SostoyanieTextBox = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label14 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		StatusComboBox = new System.Windows.Forms.ComboBox();
		label7 = new System.Windows.Forms.Label();
		AdressKlientTextBox = new System.Windows.Forms.TextBox();
		label5 = new System.Windows.Forms.Label();
		NumberLabel = new System.Windows.Forms.Label();
		VipolnenieRabotiComboBox = new System.Windows.Forms.ComboBox();
		ServiceAdressComboBox = new System.Windows.Forms.ComboBox();
		label6 = new System.Windows.Forms.Label();
		DeviceColourComboBox = new System.Windows.Forms.ComboBox();
		label9 = new System.Windows.Forms.Label();
		GoToTheStockButton = new System.Windows.Forms.Button();
		AktVidachiGarantiiButton = new System.Windows.Forms.Button();
		AktPriemaGarantiiButton = new System.Windows.Forms.Button();
		StatusButton = new System.Windows.Forms.Button();
		panel1 = new System.Windows.Forms.Panel();
		RepairHistoryLabel = new System.Windows.Forms.Label();
		tabControl1 = new System.Windows.Forms.TabControl();
		ZapisPage = new System.Windows.Forms.TabPage();
		OpenFolderButton = new System.Windows.Forms.Button();
		SaveButton = new System.Windows.Forms.Button();
		KlientVKurse = new System.Windows.Forms.CheckBox();
		DeleteButton = new System.Windows.Forms.Button();
		DataEditorButton = new System.Windows.Forms.Button();
		AktVidachiButton = new System.Windows.Forms.Button();
		AktPriemaButton = new System.Windows.Forms.Button();
		klientPage = new System.Windows.Forms.TabPage();
		SaveClientButton = new System.Windows.Forms.Button();
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
		panel2 = new System.Windows.Forms.Panel();
		tabControl1.SuspendLayout();
		ZapisPage.SuspendLayout();
		klientPage.SuspendLayout();
		SuspendLayout();
		checkBox3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		checkBox3.Location = new System.Drawing.Point(657, 82);
		checkBox3.Name = "checkBox3";
		checkBox3.Size = new System.Drawing.Size(137, 18);
		checkBox3.TabIndex = 18;
		checkBox3.Text = "Требует заказа";
		checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		checkBox3.UseVisualStyleBackColor = true;
		checkBox3.CheckedChanged += new System.EventHandler(checkBox3_CheckedChanged);
		phoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		phoneTextBox.Location = new System.Drawing.Point(6, 104);
		phoneTextBox.Name = "phoneTextBox";
		phoneTextBox.Size = new System.Drawing.Size(340, 22);
		phoneTextBox.TabIndex = 2;
		SkidkaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		SkidkaTextBox.Location = new System.Drawing.Point(602, 366);
		SkidkaTextBox.Name = "SkidkaTextBox";
		SkidkaTextBox.Size = new System.Drawing.Size(237, 22);
		SkidkaTextBox.TabIndex = 25;
		SkidkaTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(SkidkaTextBox_MouseClick);
		SkidkaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(SkidkaTextBox_KeyPress);
		label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label1.ForeColor = System.Drawing.Color.Red;
		label1.Location = new System.Drawing.Point(602, 350);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(236, 16);
		label1.TabIndex = 167;
		label1.Text = "Скидка";
		label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label24.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label24.ForeColor = System.Drawing.Color.Black;
		label24.Location = new System.Drawing.Point(600, 311);
		label24.Name = "label24";
		label24.Size = new System.Drawing.Size(237, 13);
		label24.TabIndex = 166;
		label24.Text = "Гарантия";
		label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		GarantyComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		GarantyComboBox.FormattingEnabled = true;
		GarantyComboBox.Location = new System.Drawing.Point(602, 326);
		GarantyComboBox.Name = "GarantyComboBox";
		GarantyComboBox.Size = new System.Drawing.Size(237, 24);
		GarantyComboBox.TabIndex = 24;
		VipolnenieRabotiTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		VipolnenieRabotiTextBox.Location = new System.Drawing.Point(602, 178);
		VipolnenieRabotiTextBox.Multiline = true;
		VipolnenieRabotiTextBox.Name = "VipolnenieRabotiTextBox";
		VipolnenieRabotiTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		VipolnenieRabotiTextBox.Size = new System.Drawing.Size(237, 94);
		VipolnenieRabotiTextBox.TabIndex = 22;
		label16.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label16.ForeColor = System.Drawing.Color.Black;
		label16.Location = new System.Drawing.Point(602, 142);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(237, 13);
		label16.TabIndex = 165;
		label16.Text = "Выполненные работы";
		label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label23.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label23.ForeColor = System.Drawing.Color.Red;
		label23.Location = new System.Drawing.Point(600, 392);
		label23.Name = "label23";
		label23.Size = new System.Drawing.Size(237, 13);
		label23.TabIndex = 164;
		label23.Text = "Окончательная стоимость";
		label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		PredvaritelnayaStoimostTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		PredvaritelnayaStoimostTextBox.Location = new System.Drawing.Point(602, 18);
		PredvaritelnayaStoimostTextBox.Name = "PredvaritelnayaStoimostTextBox";
		PredvaritelnayaStoimostTextBox.Size = new System.Drawing.Size(237, 22);
		PredvaritelnayaStoimostTextBox.TabIndex = 16;
		PredvaritelnayaStoimostTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(PredvaritelnayaStoimostTextBox_MouseClick);
		PredvaritelnayaStoimostTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(PredvaritelnayaStoimostTextBox_KeyPress);
		label22.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label22.ForeColor = System.Drawing.Color.Red;
		label22.Location = new System.Drawing.Point(604, 3);
		label22.Name = "label22";
		label22.Size = new System.Drawing.Size(236, 13);
		label22.TabIndex = 163;
		label22.Text = "Предв. стоим. ремонта";
		label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label21.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label21.Location = new System.Drawing.Point(4, 521);
		label21.Name = "label21";
		label21.Size = new System.Drawing.Size(836, 18);
		label21.TabIndex = 162;
		label21.Text = "Комментарий, не виден клиенту";
		label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		PriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		PriceTextBox.Location = new System.Drawing.Point(602, 407);
		PriceTextBox.Name = "PriceTextBox";
		PriceTextBox.Size = new System.Drawing.Size(237, 22);
		PriceTextBox.TabIndex = 26;
		PriceTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(PriceTextBox_MouseClick);
		PriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(PriceTextBox_KeyPress);
		label10.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label10.ForeColor = System.Drawing.Color.RoyalBlue;
		label10.Location = new System.Drawing.Point(6, 89);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(340, 13);
		label10.TabIndex = 146;
		label10.Text = "Телефон";
		label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label4.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label4.ForeColor = System.Drawing.Color.RoyalBlue;
		label4.Location = new System.Drawing.Point(355, 130);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(238, 13);
		label4.TabIndex = 123;
		label4.Text = "Неисправность";
		label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		PolomkaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		PolomkaTextBox.Location = new System.Drawing.Point(355, 146);
		PolomkaTextBox.Multiline = true;
		PolomkaTextBox.Name = "PolomkaTextBox";
		PolomkaTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		PolomkaTextBox.Size = new System.Drawing.Size(238, 82);
		PolomkaTextBox.TabIndex = 9;
		KomplektnostTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		KomplektnostTextBox.Location = new System.Drawing.Point(355, 18);
		KomplektnostTextBox.Multiline = true;
		KomplektnostTextBox.Name = "KomplektnostTextBox";
		KomplektnostTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		KomplektnostTextBox.Size = new System.Drawing.Size(238, 108);
		KomplektnostTextBox.TabIndex = 8;
		label20.AutoSize = true;
		label20.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label20.ForeColor = System.Drawing.Color.RoyalBlue;
		label20.Location = new System.Drawing.Point(424, 3);
		label20.Name = "label20";
		label20.Size = new System.Drawing.Size(95, 15);
		label20.TabIndex = 161;
		label20.Text = "Комплектность";
		label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label20.MouseDown += new System.Windows.Forms.MouseEventHandler(label20_MouseDown);
		SerialTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		SerialTextBox.Location = new System.Drawing.Point(6, 276);
		SerialTextBox.Name = "SerialTextBox";
		SerialTextBox.Size = new System.Drawing.Size(340, 22);
		SerialTextBox.TabIndex = 6;
		SerialTextBox.TextChanged += new System.EventHandler(SerialTextBox_TextChanged);
		label19.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label19.ForeColor = System.Drawing.Color.RoyalBlue;
		label19.Location = new System.Drawing.Point(6, 260);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(340, 13);
		label19.TabIndex = 160;
		label19.Text = "Серийный номер";
		label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label11.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label11.ForeColor = System.Drawing.Color.Red;
		label11.Location = new System.Drawing.Point(603, 103);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(235, 13);
		label11.TabIndex = 148;
		label11.Text = "Затраты";
		label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		ModelTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		ModelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ModelTextBox.Location = new System.Drawing.Point(6, 215);
		ModelTextBox.Multiline = true;
		ModelTextBox.Name = "ModelTextBox";
		ModelTextBox.Size = new System.Drawing.Size(340, 42);
		ModelTextBox.TabIndex = 5;
		PredoplataTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		PredoplataTextBox.Location = new System.Drawing.Point(602, 56);
		PredoplataTextBox.Name = "PredoplataTextBox";
		PredoplataTextBox.Size = new System.Drawing.Size(237, 22);
		PredoplataTextBox.TabIndex = 17;
		PredoplataTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(PredoplataTextBox_MouseClick);
		PredoplataTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(PredoplataTextBox_KeyPress);
		PredoplataTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(PredoplataTextBox_KeyUp);
		label12.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label12.ForeColor = System.Drawing.Color.Red;
		label12.Location = new System.Drawing.Point(602, 41);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(236, 13);
		label12.TabIndex = 149;
		label12.Text = "Предоплата";
		label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		ZatratyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ZatratyTextBox.Location = new System.Drawing.Point(602, 119);
		ZatratyTextBox.Name = "ZatratyTextBox";
		ZatratyTextBox.Size = new System.Drawing.Size(107, 22);
		ZatratyTextBox.TabIndex = 19;
		ZatratyTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(ZatratyTextBox_MouseClick);
		ZatratyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ZatratyTextBox_KeyPress);
		label18.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label18.ForeColor = System.Drawing.Color.RoyalBlue;
		label18.Location = new System.Drawing.Point(6, 201);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(340, 13);
		label18.TabIndex = 159;
		label18.Text = "Модель";
		label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		BrandComboBox.AutoCompleteCustomSource.AddRange(new string[104]
		{
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
			"СПЛАЙН"
		});
		BrandComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
		BrandComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
		BrandComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		BrandComboBox.FormattingEnabled = true;
		BrandComboBox.Location = new System.Drawing.Point(6, 179);
		BrandComboBox.Name = "BrandComboBox";
		BrandComboBox.Size = new System.Drawing.Size(340, 24);
		BrandComboBox.TabIndex = 4;
		label8.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label8.Location = new System.Drawing.Point(354, 311);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(238, 13);
		label8.TabIndex = 158;
		label8.Text = "Откуда о нас узнали";
		label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		AboutUsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		AboutUsComboBox.FormattingEnabled = true;
		AboutUsComboBox.Location = new System.Drawing.Point(355, 326);
		AboutUsComboBox.Name = "AboutUsComboBox";
		AboutUsComboBox.Size = new System.Drawing.Size(238, 24);
		AboutUsComboBox.TabIndex = 12;
		What_remont_combo_box.AutoCompleteCustomSource.AddRange(new string[41]
		{
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
			"ЭЛЕКТРОННАЯ КНИГА"
		});
		What_remont_combo_box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
		What_remont_combo_box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
		What_remont_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		What_remont_combo_box.FormattingEnabled = true;
		What_remont_combo_box.Location = new System.Drawing.Point(6, 140);
		What_remont_combo_box.Name = "What_remont_combo_box";
		What_remont_combo_box.Size = new System.Drawing.Size(340, 24);
		What_remont_combo_box.TabIndex = 3;
		label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label2.ForeColor = System.Drawing.Color.RoyalBlue;
		label2.Location = new System.Drawing.Point(6, 127);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(340, 13);
		label2.TabIndex = 133;
		label2.Text = "Тип устройства";
		label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		kommentarijTextBox.BackColor = System.Drawing.Color.White;
		kommentarijTextBox.Location = new System.Drawing.Point(4, 542);
		kommentarijTextBox.Multiline = true;
		kommentarijTextBox.Name = "kommentarijTextBox";
		kommentarijTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		kommentarijTextBox.Size = new System.Drawing.Size(835, 125);
		kommentarijTextBox.TabIndex = 28;
		SurnameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		SurnameTextBox.Location = new System.Drawing.Point(6, 69);
		SurnameTextBox.Name = "SurnameTextBox";
		SurnameTextBox.Size = new System.Drawing.Size(340, 22);
		SurnameTextBox.TabIndex = 1;
		label15.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label15.ForeColor = System.Drawing.Color.Black;
		label15.Location = new System.Drawing.Point(601, 274);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(238, 13);
		label15.TabIndex = 156;
		label15.Text = "Мастер";
		label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		MasterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		MasterComboBox.FormattingEnabled = true;
		MasterComboBox.Location = new System.Drawing.Point(602, 289);
		MasterComboBox.Name = "MasterComboBox";
		MasterComboBox.Size = new System.Drawing.Size(237, 24);
		MasterComboBox.TabIndex = 23;
		MasterComboBox.SelectedIndexChanged += new System.EventHandler(MasterComboBox_SelectedIndexChanged);
		SostoyanieTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		SostoyanieTextBox.Location = new System.Drawing.Point(6, 316);
		SostoyanieTextBox.Multiline = true;
		SostoyanieTextBox.Name = "SostoyanieTextBox";
		SostoyanieTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		SostoyanieTextBox.Size = new System.Drawing.Size(340, 133);
		SostoyanieTextBox.TabIndex = 7;
		label3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label3.ForeColor = System.Drawing.Color.RoyalBlue;
		label3.Location = new System.Drawing.Point(6, 54);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(340, 13);
		label3.TabIndex = 121;
		label3.Text = "ФИО";
		label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label14.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label14.ForeColor = System.Drawing.Color.RoyalBlue;
		label14.Location = new System.Drawing.Point(6, 300);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(340, 13);
		label14.TabIndex = 155;
		label14.Text = "Состояние приема";
		label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label13.ForeColor = System.Drawing.Color.Black;
		label13.Location = new System.Drawing.Point(431, 410);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(87, 15);
		label13.TabIndex = 154;
		label13.Text = "Статус заказа";
		label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label13.MouseDown += new System.Windows.Forms.MouseEventHandler(label13_MouseDown_1);
		StatusComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		StatusComboBox.FormattingEnabled = true;
		StatusComboBox.Items.AddRange(new object[8]
		{
			"Диагностика",
			"Согласование с клиентом",
			"Согласовано",
			"Принят в работу",
			"Ждёт запчасть",
			"Принят по гарантии",
			"Готов",
			"Выдан"
		});
		StatusComboBox.Location = new System.Drawing.Point(355, 428);
		StatusComboBox.Name = "StatusComboBox";
		StatusComboBox.Size = new System.Drawing.Size(237, 24);
		StatusComboBox.TabIndex = 14;
		StatusComboBox.SelectedIndexChanged += new System.EventHandler(StatusComboBox_SelectedIndexChanged);
		label7.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label7.ForeColor = System.Drawing.Color.RoyalBlue;
		label7.Location = new System.Drawing.Point(6, 164);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(340, 13);
		label7.TabIndex = 130;
		label7.Text = "Название бренда";
		label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		AdressKlientTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		AdressKlientTextBox.Location = new System.Drawing.Point(355, 366);
		AdressKlientTextBox.Multiline = true;
		AdressKlientTextBox.Name = "AdressKlientTextBox";
		AdressKlientTextBox.Size = new System.Drawing.Size(238, 41);
		AdressKlientTextBox.TabIndex = 13;
		label5.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label5.Location = new System.Drawing.Point(357, 350);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(235, 13);
		label5.TabIndex = 183;
		label5.Text = "Адрес клиента";
		label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		NumberLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		NumberLabel.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		NumberLabel.Location = new System.Drawing.Point(6, 3);
		NumberLabel.Name = "NumberLabel";
		NumberLabel.Size = new System.Drawing.Size(340, 46);
		NumberLabel.TabIndex = 188;
		NumberLabel.Text = "Редактирование записи номер";
		NumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		NumberLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(NumberLabel_MouseDown);
		VipolnenieRabotiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		VipolnenieRabotiComboBox.FormattingEnabled = true;
		VipolnenieRabotiComboBox.Location = new System.Drawing.Point(602, 158);
		VipolnenieRabotiComboBox.Name = "VipolnenieRabotiComboBox";
		VipolnenieRabotiComboBox.Size = new System.Drawing.Size(237, 23);
		VipolnenieRabotiComboBox.TabIndex = 21;
		VipolnenieRabotiComboBox.SelectedIndexChanged += new System.EventHandler(VipolnenieRabotiComboBox_SelectedIndexChanged);
		ServiceAdressComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ServiceAdressComboBox.FormattingEnabled = true;
		ServiceAdressComboBox.Items.AddRange(new object[1]
		{
			""
		});
		ServiceAdressComboBox.Location = new System.Drawing.Point(355, 289);
		ServiceAdressComboBox.Name = "ServiceAdressComboBox";
		ServiceAdressComboBox.Size = new System.Drawing.Size(238, 24);
		ServiceAdressComboBox.TabIndex = 11;
		label6.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label6.Location = new System.Drawing.Point(355, 270);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(238, 16);
		label6.TabIndex = 190;
		label6.Text = "Адрес СЦ";
		label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		DeviceColourComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		DeviceColourComboBox.FormattingEnabled = true;
		DeviceColourComboBox.ItemHeight = 16;
		DeviceColourComboBox.Location = new System.Drawing.Point(354, 248);
		DeviceColourComboBox.Name = "DeviceColourComboBox";
		DeviceColourComboBox.Size = new System.Drawing.Size(240, 24);
		DeviceColourComboBox.TabIndex = 10;
		label9.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label9.Location = new System.Drawing.Point(354, 229);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(238, 17);
		label9.TabIndex = 192;
		label9.Text = "Цвет устройства";
		label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		GoToTheStockButton.Location = new System.Drawing.Point(715, 118);
		GoToTheStockButton.Name = "GoToTheStockButton";
		GoToTheStockButton.Size = new System.Drawing.Size(124, 24);
		GoToTheStockButton.TabIndex = 20;
		GoToTheStockButton.Text = "Перейти на склад";
		GoToTheStockButton.UseVisualStyleBackColor = true;
		GoToTheStockButton.Click += new System.EventHandler(GoToTheStockButton_Click);
		AktVidachiGarantiiButton.Enabled = false;
		AktVidachiGarantiiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		AktVidachiGarantiiButton.Location = new System.Drawing.Point(477, 490);
		AktVidachiGarantiiButton.Name = "AktVidachiGarantiiButton";
		AktVidachiGarantiiButton.Size = new System.Drawing.Size(116, 28);
		AktVidachiGarantiiButton.TabIndex = 33;
		AktVidachiGarantiiButton.Text = "Акт выд. Гар";
		AktVidachiGarantiiButton.UseVisualStyleBackColor = true;
		AktVidachiGarantiiButton.Click += new System.EventHandler(AktVidachiGarantiiButton_Click);
		AktPriemaGarantiiButton.Enabled = false;
		AktPriemaGarantiiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		AktPriemaGarantiiButton.Location = new System.Drawing.Point(354, 490);
		AktPriemaGarantiiButton.Name = "AktPriemaGarantiiButton";
		AktPriemaGarantiiButton.Size = new System.Drawing.Size(117, 28);
		AktPriemaGarantiiButton.TabIndex = 32;
		AktPriemaGarantiiButton.Text = "Акт пр. Гар";
		AktPriemaGarantiiButton.UseVisualStyleBackColor = true;
		AktPriemaGarantiiButton.Click += new System.EventHandler(AktPriemaGarantii_Click);
		StatusButton.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
		StatusButton.Location = new System.Drawing.Point(851, 672);
		StatusButton.Name = "StatusButton";
		StatusButton.Size = new System.Drawing.Size(194, 25);
		StatusButton.TabIndex = 999;
		StatusButton.Text = "Редактировать историю";
		StatusButton.UseVisualStyleBackColor = true;
		StatusButton.Click += new System.EventHandler(StatusButton_Click);
		panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
		panel1.AutoScroll = true;
		panel1.BackColor = System.Drawing.SystemColors.Menu;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Location = new System.Drawing.Point(852, 47);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(192, 620);
		panel1.TabIndex = 193;
		RepairHistoryLabel.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
		RepairHistoryLabel.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		RepairHistoryLabel.Location = new System.Drawing.Point(872, 21);
		RepairHistoryLabel.Name = "RepairHistoryLabel";
		RepairHistoryLabel.Size = new System.Drawing.Size(152, 19);
		RepairHistoryLabel.TabIndex = 0;
		RepairHistoryLabel.Text = "История ремонта";
		RepairHistoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		tabControl1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
		tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
		tabControl1.Controls.Add(ZapisPage);
		tabControl1.Controls.Add(klientPage);
		tabControl1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		tabControl1.Location = new System.Drawing.Point(1, 2);
		tabControl1.Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		tabControl1.Size = new System.Drawing.Size(850, 706);
		tabControl1.TabIndex = 194;
		tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(tabControl1_Selecting);
		ZapisPage.BackColor = System.Drawing.SystemColors.ButtonFace;
		ZapisPage.Controls.Add(OpenFolderButton);
		ZapisPage.Controls.Add(NumberLabel);
		ZapisPage.Controls.Add(SaveButton);
		ZapisPage.Controls.Add(label7);
		ZapisPage.Controls.Add(StatusComboBox);
		ZapisPage.Controls.Add(AktPriemaGarantiiButton);
		ZapisPage.Controls.Add(label13);
		ZapisPage.Controls.Add(AktVidachiGarantiiButton);
		ZapisPage.Controls.Add(label14);
		ZapisPage.Controls.Add(GoToTheStockButton);
		ZapisPage.Controls.Add(label3);
		ZapisPage.Controls.Add(label9);
		ZapisPage.Controls.Add(SostoyanieTextBox);
		ZapisPage.Controls.Add(DeviceColourComboBox);
		ZapisPage.Controls.Add(MasterComboBox);
		ZapisPage.Controls.Add(label6);
		ZapisPage.Controls.Add(label15);
		ZapisPage.Controls.Add(ServiceAdressComboBox);
		ZapisPage.Controls.Add(SurnameTextBox);
		ZapisPage.Controls.Add(KlientVKurse);
		ZapisPage.Controls.Add(kommentarijTextBox);
		ZapisPage.Controls.Add(VipolnenieRabotiComboBox);
		ZapisPage.Controls.Add(DeleteButton);
		ZapisPage.Controls.Add(label2);
		ZapisPage.Controls.Add(DataEditorButton);
		ZapisPage.Controls.Add(What_remont_combo_box);
		ZapisPage.Controls.Add(AdressKlientTextBox);
		ZapisPage.Controls.Add(AboutUsComboBox);
		ZapisPage.Controls.Add(label5);
		ZapisPage.Controls.Add(label8);
		ZapisPage.Controls.Add(checkBox3);
		ZapisPage.Controls.Add(BrandComboBox);
		ZapisPage.Controls.Add(phoneTextBox);
		ZapisPage.Controls.Add(label18);
		ZapisPage.Controls.Add(SkidkaTextBox);
		ZapisPage.Controls.Add(ZatratyTextBox);
		ZapisPage.Controls.Add(label1);
		ZapisPage.Controls.Add(label12);
		ZapisPage.Controls.Add(label24);
		ZapisPage.Controls.Add(PredoplataTextBox);
		ZapisPage.Controls.Add(GarantyComboBox);
		ZapisPage.Controls.Add(ModelTextBox);
		ZapisPage.Controls.Add(VipolnenieRabotiTextBox);
		ZapisPage.Controls.Add(label11);
		ZapisPage.Controls.Add(label16);
		ZapisPage.Controls.Add(label19);
		ZapisPage.Controls.Add(label23);
		ZapisPage.Controls.Add(SerialTextBox);
		ZapisPage.Controls.Add(AktVidachiButton);
		ZapisPage.Controls.Add(label20);
		ZapisPage.Controls.Add(AktPriemaButton);
		ZapisPage.Controls.Add(KomplektnostTextBox);
		ZapisPage.Controls.Add(PredvaritelnayaStoimostTextBox);
		ZapisPage.Controls.Add(PolomkaTextBox);
		ZapisPage.Controls.Add(label22);
		ZapisPage.Controls.Add(label4);
		ZapisPage.Controls.Add(label21);
		ZapisPage.Controls.Add(label10);
		ZapisPage.Controls.Add(PriceTextBox);
		ZapisPage.Location = new System.Drawing.Point(4, 27);
		ZapisPage.Name = "ZapisPage";
		ZapisPage.Padding = new System.Windows.Forms.Padding(3);
		ZapisPage.Size = new System.Drawing.Size(842, 675);
		ZapisPage.TabIndex = 0;
		ZapisPage.Text = "Запись";
		//OpenFolderButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("OpenFolderButton.BackgroundImage");
		OpenFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		OpenFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		OpenFolderButton.Location = new System.Drawing.Point(148, 490);
		OpenFolderButton.Name = "OpenFolderButton";
		OpenFolderButton.Size = new System.Drawing.Size(198, 28);
		OpenFolderButton.TabIndex = 193;
		OpenFolderButton.Text = "Открыть папку ремонта";
		OpenFolderButton.UseVisualStyleBackColor = true;
		OpenFolderButton.Click += new System.EventHandler(OpenFolderButton_Click);
		//SaveButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("SaveButton.BackgroundImage");
		SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		SaveButton.Location = new System.Drawing.Point(354, 457);
		SaveButton.Name = "SaveButton";
		SaveButton.Size = new System.Drawing.Size(239, 28);
		SaveButton.TabIndex = 31;
		SaveButton.Text = "Сохранить и выйти";
		SaveButton.UseVisualStyleBackColor = true;
		SaveButton.Click += new System.EventHandler(SaveButton_Click);
		KlientVKurse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		KlientVKurse.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		//KlientVKurse.Image = (System.Drawing.Image)resources.GetObject("KlientVKurse.Image");
		KlientVKurse.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		KlientVKurse.Location = new System.Drawing.Point(643, 430);
		KlientVKurse.Name = "KlientVKurse";
		KlientVKurse.Size = new System.Drawing.Size(162, 26);
		KlientVKurse.TabIndex = 27;
		KlientVKurse.Text = "Нужно согласовать";
		KlientVKurse.UseVisualStyleBackColor = true;
		KlientVKurse.CheckedChanged += new System.EventHandler(KlientVKurse_CheckedChanged);
		//DeleteButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("DeleteButton.BackgroundImage");
		DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		DeleteButton.Location = new System.Drawing.Point(4, 490);
		DeleteButton.Name = "DeleteButton";
		DeleteButton.Size = new System.Drawing.Size(138, 28);
		DeleteButton.TabIndex = 30;
		DeleteButton.Text = "Удалить";
		DeleteButton.UseVisualStyleBackColor = true;
		DeleteButton.Click += new System.EventHandler(DeleteButton_Click);
		DataEditorButton.BackgroundImage = Resources.clock;
		DataEditorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		DataEditorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		DataEditorButton.Location = new System.Drawing.Point(4, 457);
		DataEditorButton.Name = "DataEditorButton";
		DataEditorButton.Size = new System.Drawing.Size(342, 28);
		DataEditorButton.TabIndex = 29;
		DataEditorButton.Text = "Редактировать даты";
		DataEditorButton.UseVisualStyleBackColor = true;
		DataEditorButton.Click += new System.EventHandler(DataEditorButton_Click);
		//AktVidachiButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("AktVidachiButton.BackgroundImage");
		AktVidachiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		AktVidachiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		AktVidachiButton.Location = new System.Drawing.Point(599, 490);
		AktVidachiButton.Name = "AktVidachiButton";
		AktVidachiButton.Size = new System.Drawing.Size(240, 28);
		AktVidachiButton.TabIndex = 35;
		AktVidachiButton.Text = "Акт выдачи";
		AktVidachiButton.UseVisualStyleBackColor = true;
		AktVidachiButton.Click += new System.EventHandler(AktVidachiButton_Click);
		//AktPriemaButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("AktPriemaButton.BackgroundImage");
		AktPriemaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		AktPriemaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		AktPriemaButton.Location = new System.Drawing.Point(599, 457);
		AktPriemaButton.Name = "AktPriemaButton";
		AktPriemaButton.Size = new System.Drawing.Size(240, 28);
		AktPriemaButton.TabIndex = 34;
		AktPriemaButton.Text = "Акт приема";
		AktPriemaButton.UseVisualStyleBackColor = true;
		AktPriemaButton.Click += new System.EventHandler(button5_Click);
		klientPage.BackColor = System.Drawing.SystemColors.ButtonFace;
		klientPage.Controls.Add(SaveClientButton);
		klientPage.Controls.Add(label30);
		klientPage.Controls.Add(label28);
		klientPage.Controls.Add(BlackListComboBox);
		klientPage.Controls.Add(label29);
		klientPage.Controls.Add(PrimechanieTextBox);
		klientPage.Controls.Add(label17);
		klientPage.Controls.Add(ClientFioTextBox);
		klientPage.Controls.Add(ClientAdressTextBox);
		klientPage.Controls.Add(ClientAboutUsComboBox);
		klientPage.Controls.Add(label25);
		klientPage.Controls.Add(label26);
		klientPage.Controls.Add(ClientPhoneTextBox);
		klientPage.Controls.Add(label27);
		klientPage.Location = new System.Drawing.Point(4, 27);
		klientPage.Name = "klientPage";
		klientPage.Padding = new System.Windows.Forms.Padding(3);
		klientPage.Size = new System.Drawing.Size(842, 675);
		klientPage.TabIndex = 1;
		klientPage.Text = "Клиент";
		klientPage.Click += new System.EventHandler(klientPage_Click);
		SaveClientButton.BackgroundImage = Resources.save;
		SaveClientButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		SaveClientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		SaveClientButton.Location = new System.Drawing.Point(7, 640);
		SaveClientButton.Name = "SaveClientButton";
		SaveClientButton.Size = new System.Drawing.Size(340, 28);
		SaveClientButton.TabIndex = 207;
		SaveClientButton.Text = "Сохранить";
		SaveClientButton.UseVisualStyleBackColor = true;
		SaveClientButton.Click += new System.EventHandler(SaveClientButton_Click);
		label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		label30.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label30.Location = new System.Drawing.Point(6, 3);
		label30.Name = "label30";
		label30.Size = new System.Drawing.Size(340, 46);
		label30.TabIndex = 206;
		label30.Text = "Редактирование клиента номер";
		label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label28.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label28.Location = new System.Drawing.Point(6, 593);
		label28.Name = "label28";
		label28.Size = new System.Drawing.Size(340, 12);
		label28.TabIndex = 205;
		label28.Text = "Тип клиента";
		label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		BlackListComboBox.FormattingEnabled = true;
		BlackListComboBox.Items.AddRange(new object[2]
		{
			"Не проблемный",
			"Проблемный"
		});
		BlackListComboBox.Location = new System.Drawing.Point(6, 608);
		BlackListComboBox.Name = "BlackListComboBox";
		BlackListComboBox.Size = new System.Drawing.Size(340, 23);
		BlackListComboBox.TabIndex = 204;
		BlackListComboBox.Text = "Не проблемный";
		BlackListComboBox.TextChanged += new System.EventHandler(BlackListComboBox_TextChanged);
		label29.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label29.Location = new System.Drawing.Point(6, 226);
		label29.Name = "label29";
		label29.Size = new System.Drawing.Size(340, 14);
		label29.TabIndex = 203;
		label29.Text = "Заметка о клиенте (клиенту не видна)";
		label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		PrimechanieTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		PrimechanieTextBox.Location = new System.Drawing.Point(6, 242);
		PrimechanieTextBox.Multiline = true;
		PrimechanieTextBox.Name = "PrimechanieTextBox";
		PrimechanieTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		PrimechanieTextBox.Size = new System.Drawing.Size(340, 344);
		PrimechanieTextBox.TabIndex = 202;
		label17.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label17.ForeColor = System.Drawing.Color.Black;
		label17.Location = new System.Drawing.Point(6, 51);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(340, 13);
		label17.TabIndex = 188;
		label17.Text = "ФИО";
		label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		ClientFioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ClientFioTextBox.Location = new System.Drawing.Point(6, 66);
		ClientFioTextBox.Name = "ClientFioTextBox";
		ClientFioTextBox.Size = new System.Drawing.Size(340, 22);
		ClientFioTextBox.TabIndex = 184;
		ClientAdressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ClientAdressTextBox.Location = new System.Drawing.Point(6, 183);
		ClientAdressTextBox.Multiline = true;
		ClientAdressTextBox.Name = "ClientAdressTextBox";
		ClientAdressTextBox.Size = new System.Drawing.Size(340, 41);
		ClientAdressTextBox.TabIndex = 187;
		ClientAboutUsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ClientAboutUsComboBox.FormattingEnabled = true;
		ClientAboutUsComboBox.Location = new System.Drawing.Point(6, 141);
		ClientAboutUsComboBox.Name = "ClientAboutUsComboBox";
		ClientAboutUsComboBox.Size = new System.Drawing.Size(340, 24);
		ClientAboutUsComboBox.TabIndex = 186;
		label25.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label25.ForeColor = System.Drawing.Color.Black;
		label25.Location = new System.Drawing.Point(9, 167);
		label25.Name = "label25";
		label25.Size = new System.Drawing.Size(337, 13);
		label25.TabIndex = 191;
		label25.Text = "Адрес клиента";
		label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		label26.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label26.ForeColor = System.Drawing.Color.Black;
		label26.Location = new System.Drawing.Point(6, 125);
		label26.Name = "label26";
		label26.Size = new System.Drawing.Size(340, 13);
		label26.TabIndex = 190;
		label26.Text = "Откуда о нас узнали";
		label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		ClientPhoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		ClientPhoneTextBox.Location = new System.Drawing.Point(6, 103);
		ClientPhoneTextBox.Name = "ClientPhoneTextBox";
		ClientPhoneTextBox.Size = new System.Drawing.Size(340, 22);
		ClientPhoneTextBox.TabIndex = 185;
		label27.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		label27.ForeColor = System.Drawing.Color.Black;
		label27.Location = new System.Drawing.Point(6, 87);
		label27.Name = "label27";
		label27.Size = new System.Drawing.Size(340, 13);
		label27.TabIndex = 189;
		label27.Text = "Телефон";
		label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
		panel2.AutoScroll = true;
		panel2.BackColor = System.Drawing.SystemColors.Menu;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Location = new System.Drawing.Point(851, 43);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(202, 624);
		panel2.TabIndex = 209;
		panel2.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1053, 703);
		base.Controls.Add(panel2);
		base.Controls.Add(tabControl1);
		base.Controls.Add(RepairHistoryLabel);
		base.Controls.Add(panel1);
		base.Controls.Add(StatusButton);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		//base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "Editor";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Редактирование";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Editor_FormClosing);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Editor_FormClosed);
		base.Load += new System.EventHandler(Editor_Load);
		base.MouseDown += new System.Windows.Forms.MouseEventHandler(Editor_MouseDown);
		tabControl1.ResumeLayout(false);
		ZapisPage.ResumeLayout(false);
		ZapisPage.PerformLayout();
		klientPage.ResumeLayout(false);
		klientPage.PerformLayout();
		ResumeLayout(false);
	}
}
