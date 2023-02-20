// Form1

using SeviceCenter.DB;
using SeviceCenter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

public class Form1 : Form
{
	public List<VirtualClient> VCList = new List<VirtualClient>();

	private IniFile INIF = new IniFile("Config.ini");

	private ImageList imageListSmall = new ImageList();

	public BDWorker basa;

	private ItemComparer itemComparer;

	private int daysDiagnostik = -4;

	private Color backOfColour;

	public bool adPos = false;

	public bool setBool = false;

	private IContainer components = null;

	public ListView MainListView;

	public Button NewClientButton;

	public Button button1;

	public StatusStrip statusStrip;

	public ToolStrip toolStrip1;

	public ToolStripButton AddPositionButton;

	public ToolStripSeparator toolStripSeparator1;

	public ToolStripButton SearchFullButton;

	public ColumnHeader Number;

	public ColumnHeader DataPriema;

	public ColumnHeader surname;

	public ToolStripButton SettingsButton;

	public ToolStripSeparator toolStripSeparator2;

	public ToolStripStatusLabel StatusStripLabel;

	private ColumnHeader DataVidachi;

	private ColumnHeader DataPredoplati;

	private ColumnHeader phonee;

	private ColumnHeader AboutUS;

	private ColumnHeader WhatRemont;

	private ColumnHeader Brand;

	private ColumnHeader Model;

	private ColumnHeader SerialNumber;

	private ColumnHeader Sostoyanie;

	private ColumnHeader komplektnost;

	private ColumnHeader polomka;

	private ColumnHeader komment;

	private ColumnHeader PredvCoast;

	private ColumnHeader Predoplata;

	private ColumnHeader Zatrati;

	private ColumnHeader Price;

	private ColumnHeader Skidka;

	private ColumnHeader Status;

	private ColumnHeader master;

	private ColumnHeader VipolnRaboti;

	private ColumnHeader garanty;

	private ColumnHeader WaitZakaz;

	private ColumnHeader Adress;

	private ToolStripStatusLabel toolStripStatusLabel2;

	public ToolStripStatusLabel CountListViewLabel;

	private ToolStripButton SearchFIOButton;

	private ToolStripButton toolStripButton1;

	private ToolStripSeparator toolStripSeparator4;

	private ToolStripButton toolStripButton2;

	private ToolStripSeparator toolStripSeparator5;

	private ToolStripSeparator toolStripSeparator7;

	private TextBox SearchFIOTextBox;

	private ToolStripLabel toolStripLabel2;

	private ColumnHeader AdressSC;

	private ColumnHeader DeviceColour;

	public ToolStripButton ShowPhoneWaitingButton;

	public ToolStripButton WaitZakazButton;

	private ToolStripButton StockButton;

	public ToolStripComboBox ServiceAdressComboBox;

	public ToolStripButton ReadyFilterCheckBox;

	private ToolStripSeparator toolStripSeparator3;

	private ToolStripButton toolStripButton3;

	private ToolStripSeparator toolStripSeparator6;

	private ToolStrip toolStrip2;

	private ToolStripButton AllOrdersButton;

	private ToolStripButton DiagnosticksButton;

	private ToolStripButton SoglasovanieSKlientomButton;

	private ToolStripButton SoglasovanoButton1;

	private ToolStripButton InWorkButton;

	private ToolStripButton PartWaitingButton;

	private ToolStripButton PrinyatPoGarantiiButton;

	private ToolStripButton ReadyStatButton;

	private ToolStripButton OutOfSCButton;

	private ToolStripSeparator toolStripSeparator8;

	private ToolStripSeparator toolStripSeparator9;

	private ToolStripSeparator toolStripSeparator10;

	private ToolStripSeparator toolStripSeparator11;

	private ToolStripSeparator toolStripSeparator12;

	private ToolStripSeparator toolStripSeparator13;

	private ToolStripSeparator toolStripSeparator14;

	private ToolStripSeparator toolStripSeparator15;

	private ToolStrip toolStrip3;

	private ToolStripLabel toolStripLabel1;

	private ToolStripTextBox FullSearchPhone;

	private ToolStripLabel toolStripLabel3;

	private ToolStripComboBox FullSearchType;

	private ToolStripLabel toolStripLabel4;

	private ToolStripComboBox FullSearchBrand;

	private ToolStripLabel toolStripLabel5;

	private ToolStripTextBox FullSearchModel;

	private ToolStripLabel toolStripLabel6;

	private ToolStripTextBox FullSearchSerial;

	private ToolStripLabel toolStripLabel7;
	private ToolStripButton SmsStripButton;
	private ToolStripComboBox FullSearchMaster;

	public Form1()
	{
		DbContext.Instance.Connect();
		TemporaryBase.UserKey = Registration.getHDD();
		basa = new BDWorker(this);
		InitializeComponent();
		MainListView.KeyDown += Program_KeyDown;
		if (INIF.KeyExists("PROGRAMM_SETTINGS", "colorDiagnostik"))
		{
			backOfColour = Color.FromArgb(int.Parse(INIF.ReadINI("PROGRAMM_SETTINGS", "colorDiagnostik")));
		}
		for (int i = 0; i < MainListView.Columns.Count; i++)
		{
			if (INIF.KeyExists(TemporaryBase.UserKey, i.ToString()))
			{
				try
				{
					MainListView.Columns[i].Width = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, i.ToString()));
				}
				catch (Exception ex)
				{
					MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex.ToString() + Environment.NewLine);
				}
			}
		}
		if (INIF.KeyExists("PROGRAMM_SETTINGS", "daysDiagnostik"))
		{
			daysDiagnostik = int.Parse(INIF.ReadINI("PROGRAMM_SETTINGS", "daysDiagnostik"));
		}
		MainListViewColumnIndexWriter();
		
		try
		{
			imageListSmall.Images.Add(Resources.phone);
			MainListView.SmallImageList = imageListSmall;
			itemComparer = new ItemComparer(this);
			MainListView.ListViewItemSorter = itemComparer;
			MainListView.ColumnClick += OnColumnClick;
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.ToString());
		}
	}

	private void Program_KeyDown(object sender, KeyEventArgs e)
	{
		Keys keyData = e.KeyData;
		if (keyData == Keys.F12)
		{
			AddPosition addPosition = new AddPosition(this);
			addPosition.Show(this);
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
			itemComparer.ColumnIndex = e.Column;
			MainListView.VirtualListSize = VCList.Count;
			MainListView.VirtualListSize -= 1;
			MainListView.VirtualListSize += 1;
		}
		catch
		{
			MessageBox.Show("Нечего сортировать");
		}
	}

	public void TempBaseUpdateSearch(string FIO, bool SearchInOld, string Phone = "", string TypeOf = "", string Brand = "", string Model = "", string Status = "", string Master = "", string NeedZakaz = "")
	{
		TemporaryBase.FIO = FIO;
		TemporaryBase.SearchInOld = SearchInOld;
		TemporaryBase.Phone = Phone;
		TemporaryBase.TypeOf = TypeOf;
		TemporaryBase.Brand = Brand;
		TemporaryBase.Model = Model;
		TemporaryBase.Status = Status;
		TemporaryBase.Master = Master;
		TemporaryBase.NeedZakaz = NeedZakaz;
	}

	private void AddPositionButton_Click(object sender, EventArgs e)
	{
		if (!adPos)
		{
			AddPosition addPosition = new AddPosition(this);
			addPosition.Show(this);
		}
	}

	private void MainListView_ColumnClick(object sender, ColumnClickEventArgs e)
	{
		MainListView.Sorting = SortOrder.Descending;
	}

	private void MainListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
	{
		int width = MainListView.Columns[e.ColumnIndex].Width;
		INIF.WriteINI(TemporaryBase.UserKey, e.ColumnIndex.ToString(), width.ToString());
	}

	private void SearchFullButton_Click(object sender, EventArgs e)
	{
		ReadyFilterCheckBox.BackColor = Color.FromArgb(179, 215, 243);
		ShowPhoneWaitingButton.Checked = false;
		WaitZakazButton.Checked = false;
		ShowPhoneWaitingButton.Image = Resources.phone;
		WaitZakazButton.Image = Resources.chip;
		FullSearchBrand.Text = "";
		FullSearchMaster.Text = "";
		FullSearchModel.Text = "";
		FullSearchPhone.Text = "";
		FullSearchSerial.Text = "";
		FullSearchType.Text = "";
		if (!toolStrip3.Visible)
		{
			toolStrip3.Visible = true;
			MainListView.Location = new Point(0, 79);
		}
		else
		{
			MainListView.Location = new Point(0, 54);
			toolStrip3.Visible = false;
		}
	}

	private void EditButton_Click(object sender, EventArgs e)
	{
		if (MainListView.SelectedItems.Count > 0)
		{
			string text = MainListView.SelectedItems[0].Text;
			StatusStripLabel.Text = "Редактирование записи номер: " + text;
			Editor editor = new Editor(this, text);
			editor.Show();
		}
		else
		{
			MessageBox.Show("Не выбрана запись для редактирования");
		}
	}

	public void ComboboxMaker(string location, ToolStripComboBox cmb)
	{
		StreamReader streamReader = new StreamReader(location, Encoding.Default);
		for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
		{
			cmb.Items.Add(text);
		}
		streamReader.Close();
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		TemporaryBase.UserKey = Registration.getHDD();
		basa.CreateBd();
		basa.UsersTable_Create();
		DataTable dataTable = basa.UsersBdRead();
		if (dataTable.Rows.Count > 0)
		{
			base.Enabled = false;
			Authorisation authorisation = new Authorisation(this);
			authorisation.Show(this);
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "backupPath"))
		{
			string text = INIF.ReadINI(TemporaryBase.UserKey, "backupPath");
			if (Directory.Exists(text))
			{
				TemporaryBase.pathtoSaveBD = text;
			}
		}
		ReadyFilterCheckBox.BackColor = Color.FromArgb(179, 215, 243);
		AllOrdersButton.BackColor = Color.FromArgb(179, 215, 243);
		if (INIF.KeyExists("ACTS", "BarcodeH") && INIF.KeyExists("ACTS", "BarcodeW"))
		{
			TemporaryBase.barcodeH = int.Parse(INIF.ReadINI("ACTS", "BarcodeH"));
			TemporaryBase.barcodeW = int.Parse(INIF.ReadINI("ACTS", "BarcodeW"));
		}
		if (INIF.KeyExists("CHECKBOX", "EveryDayBackup"))
		{
			TemporaryBase.everyDayBackup = INIF.ReadINI("CHECKBOX", "EveryDayBackup");
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "BlistColor"))
		{
			TemporaryBase.BlistColor = INIF.ReadINI(TemporaryBase.UserKey, "BlistColor");
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "AdressSCDefault"))
		{
			TemporaryBase.AdressSCDefault = INIF.ReadINI(TemporaryBase.UserKey, "AdressSCDefault");
		}
		if (INIF.KeyExists(Registration.getHDD(), "MasterDefault"))
		{
			TemporaryBase.MasterDefault = INIF.ReadINI(Registration.getHDD(), "MasterDefault");
		}
		TemporaryBase.mainForm = this;
		FilesExistsOrNot();
		ToolTip toolTip = new ToolTip();
		toolTip.SetToolTip(SearchFIOTextBox, "Нажмите Enter для поиска");
		ComboboxMaker("settings/AdresSC.txt", ServiceAdressComboBox);
		ComboboxMaker("settings/ustrojstvo.txt", FullSearchType);
		ComboboxMaker("settings/brands.txt", FullSearchBrand);
		ComboboxMaker("settings/masters.txt", FullSearchMaster);
		if (TemporaryBase.AdressSCDefault.ToString() != "" && ServiceAdressComboBox.Items.Count > int.Parse(TemporaryBase.AdressSCDefault.ToString()))
		{
			ServiceAdressComboBox.SelectedIndex = int.Parse(TemporaryBase.AdressSCDefault.ToString());
		}
		if (INIF.KeyExists("PROGRAMM_SETTINGS", "valuta"))
		{
			TemporaryBase.valuta = INIF.ReadINI("PROGRAMM_SETTINGS", "valuta");
		}
		else
		{
			TemporaryBase.valuta = "Рублей";
			INIF.WriteINI("PROGRAMM_SETTINGS", "valuta", "Рублей");
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "MainFormPosition"))
		{
			try
			{
				base.Width = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "MfWidth"));
				base.Height = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "MfHeight"));
				base.Left = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "MfLeft"));
				base.Top = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "MfTop"));
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
		if (INIF.KeyExists("PROGRAMM_SETTINGS", "colorCheckBox") && INIF.ReadINI("PROGRAMM_SETTINGS", "colorCheckBox") == "Checked" && INIF.KeyExists("PROGRAMM_SETTINGS", "colorDiagnostik"))
		{
			TemporaryBase.diagnostika = true;
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "Poloski"))
		{
			if (INIF.ReadINI(TemporaryBase.UserKey, "Poloski") == "Unchecked")
			{
				TemporaryBase.Poloski = false;
			}
			else
			{
				TemporaryBase.Poloski = true;
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "openClientFolder"))
		{
			TemporaryBase.openClientFolder = ((!(INIF.ReadINI(TemporaryBase.UserKey, "openClientFolder") == "Unchecked")) ? true : false);
		}
		TemporaryBase.SearchFULLBegin();
		basa.StatesMapTable_Create();

		Text += File.ReadAllText("Settings/Akts/FirmName.txt").Replace("<br>", "");
		if (!Directory.Exists("ClientFiles"))
		{
			Directory.CreateDirectory("ClientFiles");
		}
	}

	public void RulesMackerMainWindow()
	{
		AddPositionButton.Enabled = ((TemporaryBase.addZapis == "1") ? true : false);
		SettingsButton.Enabled = ((TemporaryBase.settings == "1") ? true : false);
		SmsStripButton.Enabled = ((TemporaryBase.sms == "1") ? true : false);
		toolStripButton2.Enabled = ((TemporaryBase.graf == "1") ? true : false);
		StockButton.Enabled = ((TemporaryBase.stock == "1") ? true : false);
		toolStripButton3.Enabled = ((TemporaryBase.clients == "1") ? true : false);
	}

	private static void FilesExistsOrNot()
	{
		FileInfo fileInfo = new FileInfo("settings/aboutUs.txt");
		FileInfo fileInfo2 = new FileInfo("settings/AdresSC.txt");
		FileInfo fileInfo3 = new FileInfo("settings/brands.txt");
		FileInfo fileInfo4 = new FileInfo("settings/DeviceColour.txt");
		FileInfo fileInfo5 = new FileInfo("settings/komplektonst.txt");
		FileInfo fileInfo6 = new FileInfo("settings/masters.txt");
		FileInfo fileInfo7 = new FileInfo("settings/neispravnost.txt");
		FileInfo fileInfo8 = new FileInfo("settings/sostoyaniePriema.txt");
		FileInfo fileInfo9 = new FileInfo("settings/ustrojstvo.txt");
		FileInfo fileInfo10 = new FileInfo("settings/vipolnRaboti.txt");
		FileInfo fileInfo11 = new FileInfo("settings/Akts/DannieOFirme.txt");
		FileInfo fileInfo12 = new FileInfo("settings/Akts/DogovorTextPriem.txt");
		FileInfo fileInfo13 = new FileInfo("settings/Akts/DogovorTextVidacha.txt");
		FileInfo fileInfo14 = new FileInfo("settings/Akts/FirmName.txt");
		FileInfo fileInfo15 = new FileInfo("settings/Akts/Phone.txt");
		FileInfo fileInfo16 = new FileInfo("settings/Akts/URDannie.txt");
		if (!Directory.Exists("settings"))
		{
			Directory.CreateDirectory("settings");
		}
		if (!Directory.Exists("settings/Akts"))
		{
			Directory.CreateDirectory("settings/Akts");
		}
		if (!Directory.Exists("reports"))
		{
			Directory.CreateDirectory("reports");
		}
		if (!Directory.Exists("settings/Stock"))
		{
			Directory.CreateDirectory("settings/Stock");
		}
		if (!Directory.Exists("settings/Stock/Photos"))
		{
			Directory.CreateDirectory("settings/Stock/Photos");
		}
		if (!Directory.Exists("settings/backup"))
		{
			Directory.CreateDirectory("settings/backup");
		}
		if (!fileInfo.Exists)
		{
			FileStream stream = new FileStream(fileInfo.ToString(), FileMode.Create);
			StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding(1251));
			streamWriter.WriteLine("Наружняя реклама");
			streamWriter.WriteLine("Интернет");
			streamWriter.WriteLine("Этот текст можно");
			streamWriter.WriteLine("поменять в файле");
			streamWriter.WriteLine("settings/aboutUs.txt");
			streamWriter.Close();
		}
		if (!fileInfo2.Exists)
		{
			FileStream stream2 = new FileStream(fileInfo2.ToString(), FileMode.Create);
			StreamWriter streamWriter2 = new StreamWriter(stream2, Encoding.GetEncoding(1251));
			streamWriter2.WriteLine("Улица 3й ноги");
			streamWriter2.WriteLine("Переулок 2го уха");
			streamWriter2.WriteLine("Этот текст можно");
			streamWriter2.WriteLine("поменять в файле");
			streamWriter2.WriteLine("settings/AdresSC.txt");
			streamWriter2.Close();
		}
		if (!fileInfo3.Exists)
		{
			FileStream stream3 = new FileStream(fileInfo3.ToString(), FileMode.Create);
			StreamWriter streamWriter3 = new StreamWriter(stream3, Encoding.GetEncoding(1251));
			streamWriter3.WriteLine("ACER");
			streamWriter3.WriteLine("ASUS");
			streamWriter3.WriteLine("APPLE");
			streamWriter3.WriteLine("LENOVO");
			streamWriter3.WriteLine("SAMSUNG");
			streamWriter3.WriteLine("HEWLETT PACKARD");
			streamWriter3.WriteLine("DELL");
			streamWriter3.WriteLine("MSI");
			streamWriter3.WriteLine("DIGMA");
			streamWriter3.WriteLine("BENQ");
			streamWriter3.WriteLine("BBK");
			streamWriter3.Close();
		}
		if (!fileInfo4.Exists)
		{
			FileStream stream4 = new FileStream(fileInfo4.ToString(), FileMode.Create);
			StreamWriter streamWriter4 = new StreamWriter(stream4, Encoding.GetEncoding(1251));
			streamWriter4.WriteLine("Белый");
			streamWriter4.WriteLine("Чёрный");
			streamWriter4.WriteLine("Серебристый");
			streamWriter4.WriteLine("Золотоистый");
			streamWriter4.WriteLine("Синий");
			streamWriter4.Close();
		}
		if (!fileInfo5.Exists)
		{
			FileStream stream5 = new FileStream(fileInfo5.ToString(), FileMode.Create);
			StreamWriter streamWriter5 = new StreamWriter(stream5, Encoding.GetEncoding(1251));
			streamWriter5.WriteLine("Аппарат");
			streamWriter5.WriteLine("АКБ");
			streamWriter5.WriteLine("Зарядное устройство");
			streamWriter5.WriteLine("Чехол");
			streamWriter5.WriteLine("Блок питания");
			streamWriter5.WriteLine("Этот текст можно");
			streamWriter5.WriteLine("поменять в файле");
			streamWriter5.WriteLine("settings/komplektonst.txt");
			streamWriter5.Close();
		}
		if (!fileInfo6.Exists)
		{
			FileStream stream6 = new FileStream(fileInfo6.ToString(), FileMode.Create);
			StreamWriter streamWriter6 = new StreamWriter(stream6, Encoding.GetEncoding(1251));
			streamWriter6.WriteLine("Мастер1");
			streamWriter6.WriteLine("Этот текст можно");
			streamWriter6.WriteLine("поменять в файле");
			streamWriter6.WriteLine("settings/masters.txt");
			streamWriter6.Close();
		}
		if (!fileInfo7.Exists)
		{
			FileStream stream7 = new FileStream(fileInfo7.ToString(), FileMode.Create);
			StreamWriter streamWriter7 = new StreamWriter(stream7, Encoding.GetEncoding(1251));
			streamWriter7.WriteLine("Что-то сломано");
			streamWriter7.WriteLine("Этот текст можно");
			streamWriter7.WriteLine("поменять в файле");
			streamWriter7.WriteLine("settings/neispravnost.txt");
			streamWriter7.Close();
		}
		if (!fileInfo8.Exists)
		{
			FileStream stream8 = new FileStream(fileInfo8.ToString(), FileMode.Create);
			StreamWriter streamWriter8 = new StreamWriter(stream8, Encoding.GetEncoding(1251));
			streamWriter8.WriteLine("Не бит, не крашен");
			streamWriter8.WriteLine("Этот текст можно");
			streamWriter8.WriteLine("поменять в файле");
			streamWriter8.WriteLine("settings/sostoyaniePriema.txt");
			streamWriter8.Close();
		}
		if (!fileInfo9.Exists)
		{
			FileStream stream9 = new FileStream(fileInfo9.ToString(), FileMode.Create);
			StreamWriter streamWriter9 = new StreamWriter(stream9, Encoding.GetEncoding(1251));
			streamWriter9.WriteLine("Ноутбук");
			streamWriter9.WriteLine("Телефон");
			streamWriter9.WriteLine("Патифон");
			streamWriter9.WriteLine("Этот текст можно");
			streamWriter9.WriteLine("поменять в файле");
			streamWriter9.WriteLine("settings/ustrojstvo.txt");
			streamWriter9.Close();
		}
		if (!fileInfo10.Exists)
		{
			FileStream stream10 = new FileStream(fileInfo10.ToString(), FileMode.Create);
			StreamWriter streamWriter10 = new StreamWriter(stream10, Encoding.GetEncoding(1251));
			streamWriter10.WriteLine("Замена чего-нибудь");
			streamWriter10.WriteLine("Диагностика");
			streamWriter10.WriteLine("Этот текст можно");
			streamWriter10.WriteLine("поменять в файле");
			streamWriter10.WriteLine("settings/vipolnRaboti.txt");
			streamWriter10.Close();
		}
		if (!fileInfo11.Exists)
		{
			FileStream stream11 = new FileStream(fileInfo11.ToString(), FileMode.Create);
			StreamWriter streamWriter11 = new StreamWriter(stream11);
			streamWriter11.WriteLine("Режим работы: пн-пт: 10-19, сб: 10-16, вс: выходной <br>г.Петрозаводск, уд.Древлянка д.18, 2 этаж(ТЦ Находка)");
			streamWriter11.Close();
		}
		if (!fileInfo12.Exists)
		{
			FileStream stream12 = new FileStream(fileInfo12.ToString(), FileMode.Create);
			StreamWriter streamWriter12 = new StreamWriter(stream12);
			streamWriter12.WriteLine("        1. Стоимость услуг определяется сервис-инженером только после проведения диагностики оборудования в соответствии с прайс-листом.<br>\r\n\r\n        2.Сроки ремонта устанавливаются  в зависимости от наличия запчастей и сложности выполнения работ.<br>\r\n\r\n        3.Аппараты принимаются на ремонт / диагностику без SIM карт и карт памяти, а также зарядных устройств, гарнитур, кабелей и других аксессуаров, кроме тех случаев, когда это необходимо для диагностики.Такой случай фиксируется в квитанции дополнительно.Исполнитель не несет ответственности за сохранность перечисленных устройств, при отсутствии записи о них в квитанции.<br>\r\n\r\n        4.Оборудование с согласия клиента принято без разборки и проверки неисправностей.Клиент согласен, что все неисправности и внутренние повреждения, которые могут быть обнаружены в оборудовании при техническом обслуживании, возникли до приема оборудования по данной квитанции.<br>\r\n\r\n        5.Заказчик согласен на обработку персональных данных, а также несет ответственность за достоверность предоставленной информации.Сервисный центр не несет ответственности за сохранность данных, хранящихся в памяти(носителе памяти) оборудования сданного в ремонт.<br>\r\n\r\n       6.Исполнитель предоставляет гарантию на ремонт узлов оборудования до 14 дней на установленные комплектующие в соответствии с гарантийным талоном.При этом гарантия Исполнителя распространяется только на те узлы или комплектующие, которые подвергались ремонту или замене Исполнителем.<br>\r\n\r\n        7.Заказчик обязан проверить работоспособность оборудования или настроенного программного обеспечения в присутствии сервис - инженера.<br>\r\n\r\n        8.Установленные узлы или расходные материалы возврату не подлежат.<br>\r\n\r\n        9.В случае утери квитанции выдача аппарата производится при предъявлении паспорта лица сдававшего аппарат и письменного заявления.<br>\r\n\r\n       10.Сданный в ремонт или на диагностику аппарат должен быть получен в течении 30 дней с момента извещения(в случае недоступности отправляется SMS на номер телефона).При невыполнении этого требования взимается пени в размере 10 рублей за каждый день просрочки.Аппараты, невостребованные в течении 90 дней, могут быть реализованы в установленном законом порядке для погашения задолженности Заказчика перед Исполнителем. * Правила бытового обслуживания населения в РФ, глава IV, пункт 15.<br>\r\n\r\n        &nbsp;<br>\r\n        С комплектацией, описанием неисправностей и повреждений, условиями ремонта оборудования ознакомлен(а) и согласен(а).\r\n        <br> ");
			streamWriter12.Close();
		}
		if (!fileInfo13.Exists)
		{
			FileStream stream13 = new FileStream(fileInfo13.ToString(), FileMode.Create);
			StreamWriter streamWriter13 = new StreamWriter(stream13);
			streamWriter13.WriteLine("   1. Гарантийный ремонт производится в срок от 1 до 7 дней после поступления запчастей.<br>\r\n\r\n        2.Выход устройства из строя в результате действий пользователя или заражения вирусами гарантийным случаем не является.<br>\r\n\r\n        3.Исполнитель предоставляет гарантию на ремонт в соответствии с гарантийным талоном.При этом гарантия Исполнителя распространяется только на те узлы или комплектующие, которые подвергались ремонту или замене Исполнителем.<br>\r\n\r\n        4.Гарантийное обслуживание производится по адресу, указанному в Акте и только при наличии у Заказчика Акта сдачи - приемки работ, подписанных обеими сторонами.<br>\r\n\r\n       5.Исполнитель несет ответственность только за услуги, оказанные в соответствии с данным Договором.<br>\r\n\r\n       6.Ремонт и обслуживание оборудования осуществляются в соответствии с требованиями нормативных документов, в том числе ГОСТ 12.2006 - 87 п.9.1, ГОСТР 50377 - 92 п.2.1.4, ГОСТР 50936 - 96, ГОСТР50938 - 96, и согласно Федеральному Закону «О защите прав потребителей».<br>\r\n\r\n       7.Исполнитель не несет гарантийных обязательств в случаях отсутствия или повреждения гарантийной пломбы Исполнителя, внесения каких - либо изменений в конфигурацию оборудования, в том числе программное обеспечение устройства, в случае замены узлов, комплектующих или расходных материалов, в случае установки или настройки программного обеспечения, в случае монтажных работ, работ по администрированию без присутствия представителя Исполнителя.<br>\r\n\r\n        8.Требования по устранению недостатков оказанных услуг принимаются Исполнителем только в письменном виде и при условии выполнения установленных производителем правил эксплуатации оборудования.<br>\r\n\r\n        9.Установленные узлы или расходные материалы возврату не подлежат.<br>\r\n\r\n       &nbsp;<br>\r\n        Подтверждаю, что работа была выполнена в полном объеме, претензий к Исполнителю не имею.\r\n        <br> ");
			streamWriter13.Close();
		}
		if (!fileInfo14.Exists)
		{
			FileStream stream14 = new FileStream(fileInfo14.ToString(), FileMode.Create);
			StreamWriter streamWriter14 = new StreamWriter(stream14);
			streamWriter14.WriteLine("Название Вашей Фирмы");
			streamWriter14.Close();
		}
		if (!fileInfo15.Exists)
		{
			FileStream stream15 = new FileStream(fileInfo15.ToString(), FileMode.Create);
			StreamWriter streamWriter15 = new StreamWriter(stream15);
			streamWriter15.WriteLine("тел.: Вашей фирмы");
			streamWriter15.Close();
		}
		if (!fileInfo16.Exists)
		{
			FileStream stream16 = new FileStream(fileInfo16.ToString(), FileMode.Create);
			StreamWriter streamWriter16 = new StreamWriter(stream16);
			streamWriter16.WriteLine("ИП Какойктото В.Е., ОГРНИП 315100234567334 от 19.05.2015 г., ИНН 112301774509");
			streamWriter16.Close();
		}
	}

	public void CheckUpdates()
	{
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load("http://mywork2.ru/version.xml");
			Version v = new Version(xmlDocument.GetElementsByTagName("version")[0].InnerText);
			Version v2 = new Version(Application.ProductVersion);
			if (v2 < v && MessageBox.Show("Обнаружено обновление, скачать?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				Process.Start("http://mywork2.ru/update.html");
			}
		}
		catch (Exception)
		{
		}
	}

	private string FirstLetterToUpper(string krolik)
	{
		string source = " \r\n\t";
		StringBuilder stringBuilder = new StringBuilder(krolik.ToLower());
		if (stringBuilder.Length > 0 && char.IsLetter(stringBuilder[0]))
		{
			stringBuilder[0] = char.ToUpper(stringBuilder[0]);
		}
		for (int i = 1; i < stringBuilder.Length; i++)
		{
			char c = stringBuilder[i];
			if (source.Contains(stringBuilder[i - 1]) && char.IsLetter(c))
			{
				stringBuilder[i] = char.ToUpper(c);
			}
		}
		return stringBuilder.ToString();
	}

	private void MainListView_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		if (VCList.Count > 0)
		{
			string text = MainListView.Items[MainListView.SelectedIndices[0]].SubItems[0].Text;
			StatusStripLabel.Text = "Редактирование записи номер: " + text;
			Editor editor = new Editor(this, text);
			editor.Show(this);
		}
	}

	private void SettingsButton_Click(object sender, EventArgs e)
	{
		if (!setBool)
		{
			Settings settings = new Settings(this);
			settings.Show(this);
		}
	}

	private void MainListViewColumnIndexReader()
	{
		INIF.WriteINI(TemporaryBase.UserKey, "id", MainListView.Columns[0].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "Data_priema", MainListView.Columns[1].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "Data_vidachi", MainListView.Columns[2].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "Data_predoplaty", MainListView.Columns[3].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "surname", MainListView.Columns[4].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "phone", MainListView.Columns[5].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "AboutUs", MainListView.Columns[6].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "WhatRemont", MainListView.Columns[7].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "brand", MainListView.Columns[8].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "model", MainListView.Columns[9].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "SerialNumber", MainListView.Columns[10].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "sostoyanie", MainListView.Columns[11].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "komplektonst", MainListView.Columns[12].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "polomka", MainListView.Columns[13].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "kommentarij", MainListView.Columns[14].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "predvaritelnaya_stoimost", MainListView.Columns[15].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "Predoplata", MainListView.Columns[16].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "Zatrati", MainListView.Columns[17].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "okonchatelnaya_stoimost_remonta", MainListView.Columns[18].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "Skidka", MainListView.Columns[19].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "Status_remonta", MainListView.Columns[20].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "master", MainListView.Columns[21].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "vipolnenie_raboti", MainListView.Columns[22].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "Garanty", MainListView.Columns[23].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "wait_zakaz", MainListView.Columns[24].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "Adress", MainListView.Columns[25].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "AdressSC", MainListView.Columns[26].DisplayIndex.ToString());
		INIF.WriteINI(TemporaryBase.UserKey, "DeviceColour", MainListView.Columns[27].DisplayIndex.ToString());
	}

	private void MainListViewColumnIndexWriter()
	{
		if (INIF.KeyExists(TemporaryBase.UserKey, "id"))
		{
			try
			{
				MainListView.Columns[0].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "id"));
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "Data_priema"))
		{
			try
			{
				MainListView.Columns[1].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "Data_priema"));
			}
			catch (Exception ex2)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex2.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "Data_vidachi"))
		{
			try
			{
				MainListView.Columns[2].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "Data_vidachi"));
			}
			catch (Exception ex3)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex3.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "Data_predoplaty"))
		{
			try
			{
				MainListView.Columns[3].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "Data_predoplaty"));
			}
			catch (Exception ex4)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex4.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "surname"))
		{
			try
			{
				MainListView.Columns[4].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "surname"));
			}
			catch (Exception ex5)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex5.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "phone"))
		{
			try
			{
				MainListView.Columns[5].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "phone"));
			}
			catch (Exception ex6)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex6.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "AboutUs"))
		{
			try
			{
				MainListView.Columns[6].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "AboutUs"));
			}
			catch (Exception ex7)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex7.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "WhatRemont"))
		{
			try
			{
				MainListView.Columns[7].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "WhatRemont"));
			}
			catch (Exception ex8)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex8.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "brand"))
		{
			try
			{
				MainListView.Columns[8].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "brand"));
			}
			catch (Exception ex9)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex9.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "model"))
		{
			try
			{
				MainListView.Columns[9].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "model"));
			}
			catch (Exception ex10)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex10.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "SerialNumber"))
		{
			try
			{
				MainListView.Columns[10].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "SerialNumber"));
			}
			catch (Exception ex11)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex11.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "sostoyanie"))
		{
			try
			{
				MainListView.Columns[11].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "sostoyanie"));
			}
			catch (Exception ex12)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex12.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "komplektonst"))
		{
			try
			{
				MainListView.Columns[12].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "komplektonst"));
			}
			catch (Exception ex13)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex13.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "polomka"))
		{
			try
			{
				MainListView.Columns[13].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "polomka"));
			}
			catch (Exception ex14)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex14.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "kommentarij"))
		{
			try
			{
				MainListView.Columns[14].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "kommentarij"));
			}
			catch (Exception ex15)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex15.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "predvaritelnaya_stoimost"))
		{
			try
			{
				MainListView.Columns[15].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "predvaritelnaya_stoimost"));
			}
			catch (Exception ex16)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex16.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "Predoplata"))
		{
			try
			{
				MainListView.Columns[16].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "Predoplata"));
			}
			catch (Exception ex17)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex17.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "Zatrati"))
		{
			try
			{
				MainListView.Columns[17].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "Zatrati"));
			}
			catch (Exception ex18)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex18.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "okonchatelnaya_stoimost_remonta"))
		{
			try
			{
				MainListView.Columns[18].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "okonchatelnaya_stoimost_remonta"));
			}
			catch (Exception ex19)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex19.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "Skidka"))
		{
			try
			{
				MainListView.Columns[19].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "Skidka"));
			}
			catch (Exception ex20)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex20.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "Status_remonta"))
		{
			try
			{
				MainListView.Columns[20].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "Status_remonta"));
			}
			catch (Exception ex21)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex21.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "master"))
		{
			try
			{
				MainListView.Columns[21].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "master"));
			}
			catch (Exception ex22)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex22.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "vipolnenie_raboti"))
		{
			try
			{
				MainListView.Columns[22].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "vipolnenie_raboti"));
			}
			catch (Exception ex23)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex23.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "Garanty"))
		{
			try
			{
				MainListView.Columns[23].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "Garanty"));
			}
			catch (Exception ex24)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex24.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "wait_zakaz"))
		{
			try
			{
				MainListView.Columns[24].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "wait_zakaz"));
			}
			catch (Exception ex25)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex25.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "Adress"))
		{
			try
			{
				MainListView.Columns[25].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "Adress"));
			}
			catch (Exception ex26)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex26.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "AdressSC"))
		{
			try
			{
				MainListView.Columns[26].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "AdressSC"));
			}
			catch (Exception ex27)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex27.ToString() + Environment.NewLine);
			}
		}
		if (INIF.KeyExists(TemporaryBase.UserKey, "DeviceColour"))
		{
			try
			{
				MainListView.Columns[27].DisplayIndex = int.Parse(INIF.ReadINI(TemporaryBase.UserKey, "DeviceColour"));
			}
			catch (Exception ex28)
			{
				MessageBox.Show(DateTime.Now.ToString() + " Что-то с шириной колонок нет так " + ex28.ToString() + Environment.NewLine);
			}
		}
	}

	private void MainListView_ColumnReordered(object sender, ColumnReorderedEventArgs e)
	{
		MainListViewColumnIndexReader();
	}

	private void Form1_FormClosed(object sender, FormClosedEventArgs e)
	{
		MainListViewColumnIndexReader();
		if (base.Left > -10000 && base.Top > -10000)
		{
			INIF.WriteINI(TemporaryBase.UserKey, "MainFormPosition", "1");
			INIF.WriteINI(TemporaryBase.UserKey, "MfLeft", base.Left.ToString());
			INIF.WriteINI(TemporaryBase.UserKey, "MfTop", base.Top.ToString());
			INIF.WriteINI(TemporaryBase.UserKey, "MfWidth", base.Width.ToString());
			INIF.WriteINI(TemporaryBase.UserKey, "MfHeight", base.Height.ToString());
		}
		//if (TemporaryBase.everyDayBackup == "Checked" && !File.Exists(TemporaryBase.pathtoSaveBD + "/Backup_" + DateTime.Now.ToString("dd-MM-yyyy HH") + ".sqlite"))
		//{
		//	File.Copy(basa.dbFileName, TemporaryBase.pathtoSaveBD + "/Backup_" + DateTime.Now.ToString("dd-MM-yyyy HH") + ".sqlite");
		//}

		DbContext.Instance.Close();
	}

	private void toolStripButton1_Click(object sender, EventArgs e)
	{
	}

	private void SearchFIOTextBox_Click(object sender, EventArgs e)
	{
	}

	private void SearchFIOButton_Click(object sender, EventArgs e)
	{
		ShowPhoneWaitingButton.Checked = false;
		WaitZakazButton.Checked = false;
		ShowPhoneWaitingButton.Image = Resources.phone;
		WaitZakazButton.Image = Resources.chip;
		if (SearchFIOTextBox.Text == "QWERTY777")
		{
			SURPRISE sURPRISE = new SURPRISE(this);
			sURPRISE.Show();
		}
		else
		{
			TemporaryBase.SearchFULLBegin();
		}
	}

	private void toolStripButton1_Click_1(object sender, EventArgs e)
	{
		StatusButtonColorer();
		SearchFIOTextBox.Text = "";
		if (SeviceCenter.Properties.Settings.Default["AdressSCDefault"].ToString() != "" && ServiceAdressComboBox.Items.Count > int.Parse(SeviceCenter.Properties.Settings.Default["AdressSCDefault"].ToString()))
		{
			ServiceAdressComboBox.SelectedIndex = int.Parse(SeviceCenter.Properties.Settings.Default["AdressSCDefault"].ToString());
		}
		ShowPhoneWaitingButton.Checked = false;
		WaitZakazButton.Checked = false;
		ShowPhoneWaitingButton.Image = Resources.phone;
		WaitZakazButton.Image = Resources.chip;
		FullSearchBrand.Text = "";
		FullSearchMaster.Text = "";
		FullSearchModel.Text = "";
		FullSearchPhone.Text = "";
		FullSearchSerial.Text = "";
		FullSearchType.Text = "";
		ReadyFilterCheckBox.BackColor = Color.FromArgb(179, 215, 243);
		ReadyFilterCheckBox.Image = Resources.check_circle_outline_16;
		TemporaryBase.SearchCleaner();
		TemporaryBase.SearchFULLBegin();
		AllOrdersButton.BackColor = Color.FromArgb(179, 215, 243);
	}

	private void toolStripButton2_Click(object sender, EventArgs e)
	{
		Graf graf = new Graf(this);
		graf.Show(this);
	}

	private void ShowPhoneWaitingButton_Click(object sender, EventArgs e)
	{
		TemporaryBase.IskatVseVidannoe = false;
		StatusButtonColorer();
		ReadyFilterCheckBox.BackColor = Color.FromArgb(179, 215, 243);
		if (!ShowPhoneWaitingButton.Checked)
		{
			ShowPhoneWaitingButton.Image = Resources.Check1;
			ShowPhoneWaitingButton.Checked = true;
			TemporaryBase.SearchCleaner();
			TemporaryBase.soglasovat = "1";
			TemporaryBase.Status = " ";
			TemporaryBase.SearchFULLBegin("SearchInOldToo");
		}
		else
		{
			if (AllOrdersButton.BackColor != Color.FromArgb(179, 215, 243) && DiagnosticksButton.BackColor != Color.FromArgb(179, 215, 243) && SoglasovanieSKlientomButton.BackColor != Color.FromArgb(179, 215, 243) && SoglasovanoButton1.BackColor != Color.FromArgb(179, 215, 243) && InWorkButton.BackColor != Color.FromArgb(179, 215, 243) && PartWaitingButton.BackColor != Color.FromArgb(179, 215, 243) && ReadyStatButton.BackColor != Color.FromArgb(179, 215, 243) && PrinyatPoGarantiiButton.BackColor != Color.FromArgb(179, 215, 243) && OutOfSCButton.BackColor != Color.FromArgb(179, 215, 243))
			{
				AllOrdersButton.BackColor = Color.FromArgb(179, 215, 243);
				TemporaryBase.ColumnIndex = 0;
				TemporaryBase.SortAscending = false;
				TemporaryBase.SearchInOld = true;
				ShowPhoneWaitingButton.Checked = false;
				WaitZakazButton.Checked = false;
				ShowPhoneWaitingButton.Image = Resources.phone;
				WaitZakazButton.Image = Resources.chip;
				TemporaryBase.soglasovat = "";
				TemporaryBase.NeedZakaz = "";
				TemporaryBase.Status = "";
			}
			ShowPhoneWaitingButton.Image = Resources.phone;
			ShowPhoneWaitingButton.Checked = false;
			TemporaryBase.SearchCleaner();
			TemporaryBase.SearchFULLBegin();
		}
		WaitZakazButton.Checked = false;
		WaitZakazButton.Image = Resources.chip;
	}

	private void SearchPhone()
	{
		try
		{
			MainListView.Items.Clear();
			VCList.Clear();
			DataTable dataTable = basa.BdSearchPhoneWaiting();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				VirtualClient item = new VirtualClient(dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString(), dataTable.Rows[i].ItemArray[5].ToString(), dataTable.Rows[i].ItemArray[6].ToString(), dataTable.Rows[i].ItemArray[7].ToString(), dataTable.Rows[i].ItemArray[8].ToString(), dataTable.Rows[i].ItemArray[9].ToString(), dataTable.Rows[i].ItemArray[10].ToString(), dataTable.Rows[i].ItemArray[11].ToString(), dataTable.Rows[i].ItemArray[12].ToString(), dataTable.Rows[i].ItemArray[13].ToString(), dataTable.Rows[i].ItemArray[14].ToString(), dataTable.Rows[i].ItemArray[15].ToString(), dataTable.Rows[i].ItemArray[16].ToString(), dataTable.Rows[i].ItemArray[17].ToString(), dataTable.Rows[i].ItemArray[18].ToString(), dataTable.Rows[i].ItemArray[19].ToString(), dataTable.Rows[i].ItemArray[20].ToString(), dataTable.Rows[i].ItemArray[21].ToString(), dataTable.Rows[i].ItemArray[22].ToString(), dataTable.Rows[i].ItemArray[23].ToString(), dataTable.Rows[i].ItemArray[24].ToString(), dataTable.Rows[i].ItemArray[25].ToString(), dataTable.Rows[i].ItemArray[26].ToString(), TemporaryBase.diagnostika, dataTable.Rows[i].ItemArray[27].ToString(), dataTable.Rows[i].ItemArray[28].ToString(), -1, dataTable.Rows[i].ItemArray[30].ToString());
				VCList.Add(item);
			}
			MainListView.VirtualListSize = VCList.Count;
			CountListViewLabel.Text = "Найдено записей: " + dataTable.Rows.Count;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void DiagnostikSearchButton_Click(object sender, EventArgs e)
	{
	}

	private void WaitZakazButton_Click(object sender, EventArgs e)
	{
		TemporaryBase.IskatVseVidannoe = false;
		StatusButtonColorer();
		ReadyFilterCheckBox.BackColor = Color.FromArgb(179, 215, 243);
		if (!WaitZakazButton.Checked)
		{
			WaitZakazButton.Image = Resources.Check1;
			WaitZakazButton.Checked = true;
			TemporaryBase.SearchCleaner();
			TemporaryBase.Status = " ";
			TemporaryBase.NeedZakaz = "Заказать";
			TemporaryBase.SearchFULLBegin();
		}
		else
		{
			if (AllOrdersButton.BackColor != Color.FromArgb(179, 215, 243) && DiagnosticksButton.BackColor != Color.FromArgb(179, 215, 243) && SoglasovanieSKlientomButton.BackColor != Color.FromArgb(179, 215, 243) && SoglasovanoButton1.BackColor != Color.FromArgb(179, 215, 243) && InWorkButton.BackColor != Color.FromArgb(179, 215, 243) && PartWaitingButton.BackColor != Color.FromArgb(179, 215, 243) && ReadyStatButton.BackColor != Color.FromArgb(179, 215, 243) && PrinyatPoGarantiiButton.BackColor != Color.FromArgb(179, 215, 243) && OutOfSCButton.BackColor != Color.FromArgb(179, 215, 243))
			{
				AllOrdersButton.BackColor = Color.FromArgb(179, 215, 243);
				TemporaryBase.ColumnIndex = 0;
				TemporaryBase.SortAscending = false;
				TemporaryBase.SearchInOld = true;
				ShowPhoneWaitingButton.Checked = false;
				WaitZakazButton.Checked = false;
				ShowPhoneWaitingButton.Image = Resources.phone;
				WaitZakazButton.Image = Resources.chip;
				TemporaryBase.soglasovat = "";
				TemporaryBase.NeedZakaz = "";
				TemporaryBase.Status = "";
			}
			WaitZakazButton.Image = Resources.chip;
			WaitZakazButton.Checked = false;
			TemporaryBase.SearchCleaner();
			TemporaryBase.SearchFULLBegin();
		}
		ShowPhoneWaitingButton.Checked = false;
		ShowPhoneWaitingButton.Image = Resources.phone;
	}

	private void MainListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		if (e.ItemIndex < 0 || e.ItemIndex >= VCList.Count)
		{
			return;
		}
		e.Item = new ListViewItem(VCList[e.ItemIndex].Id);
		if (VCList[e.ItemIndex].Image_key == "1")
		{
			e.Item.ImageIndex = 0;
		}
		Color backOfColour2 = backOfColour;
		if (VCList[e.ItemIndex].Data_priema != "")
		{
			bool flag = DateTime.Parse(VCList[e.ItemIndex].Data_priema) < DateTime.Today.AddDays(daysDiagnostik);
			if (VCList[e.ItemIndex].Data_vidachi == "" && flag && VCList[e.ItemIndex].Status_remonta == "Диагностика")
			{
				if (VCList[e.ItemIndex].Diagnosik)
				{
					e.Item.BackColor = backOfColour;
				}
			}
			else if (TemporaryBase.Poloski && e.ItemIndex % 2 == 0)
			{
				e.Item.BackColor = Color.FromArgb(240, 240, 240);
			}
		}
		e.Item.SubItems.Add(VCList[e.ItemIndex].Data_priema);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Data_vidachi);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Data_predoplaty);
		e.Item.SubItems.Add(FirstLetterToUpper(VCList[e.ItemIndex].Surname));
		e.Item.SubItems.Add(VCList[e.ItemIndex].Phone);
		e.Item.SubItems.Add(VCList[e.ItemIndex].AboutUs);
		e.Item.SubItems.Add(FirstLetterToUpper(VCList[e.ItemIndex].WhatRemont));
		e.Item.SubItems.Add(VCList[e.ItemIndex].Brand);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Model);
		e.Item.SubItems.Add(VCList[e.ItemIndex].SerialNumber);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Sostoyanie);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Komplektonst);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Polomka);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Kommentarij);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Predvaritelnaya_stoimost);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Predoplata);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Zatrati);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Okonchatelnaya_stoimost_remonta);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Skidka);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Status_remonta);
		e.Item.SubItems.Add(FirstLetterToUpper(VCList[e.ItemIndex].Master));
		e.Item.SubItems.Add(VCList[e.ItemIndex].Vipolnenie_raboti);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Garanty);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Wait_zakaz);
		e.Item.SubItems.Add(VCList[e.ItemIndex].Adress);
		e.Item.SubItems.Add(VCList[e.ItemIndex].AdressSC);
		e.Item.SubItems.Add(VCList[e.ItemIndex].DeviceColour);
	}

	private void MainListView_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void MainListView_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
	{
		TemporaryBase.startIndex = e.StartIndex;
		TemporaryBase.endIndex = e.EndIndex;
	}

	private void SearchFIOTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Return)
		{
			return;
		}
		if (AllOrdersButton.BackColor != Color.FromArgb(179, 215, 243) && DiagnosticksButton.BackColor != Color.FromArgb(179, 215, 243) && SoglasovanieSKlientomButton.BackColor != Color.FromArgb(179, 215, 243) && SoglasovanoButton1.BackColor != Color.FromArgb(179, 215, 243) && InWorkButton.BackColor != Color.FromArgb(179, 215, 243) && PartWaitingButton.BackColor != Color.FromArgb(179, 215, 243) && ReadyStatButton.BackColor != Color.FromArgb(179, 215, 243) && PrinyatPoGarantiiButton.BackColor != Color.FromArgb(179, 215, 243) && OutOfSCButton.BackColor != Color.FromArgb(179, 215, 243))
		{
			AllOrdersButton.BackColor = Color.FromArgb(179, 215, 243);
			TemporaryBase.ColumnIndex = 0;
			TemporaryBase.SortAscending = false;
			TemporaryBase.SearchInOld = true;
			ShowPhoneWaitingButton.Checked = false;
			WaitZakazButton.Checked = false;
			ShowPhoneWaitingButton.Image = Resources.phone;
			WaitZakazButton.Image = Resources.chip;
			TemporaryBase.soglasovat = "";
			TemporaryBase.NeedZakaz = "";
			TemporaryBase.Status = "";
		}
		if (int.TryParse(SearchFIOTextBox.Text, out int result))
		{
			if (basa.CatlogIDExists(SearchFIOTextBox.Text) != 0)
			{
				Editor editor = new Editor(this, result.ToString());
				editor.Show(this);
			}
			else
			{
				MessageBox.Show("Запись с данным номером в базе не найдена");
			}
			SearchFIOTextBox.Text = "";
		}
		else
		{
			ShowPhoneWaitingButton.Checked = false;
			WaitZakazButton.Checked = false;
			ShowPhoneWaitingButton.Image = Resources.phone;
			WaitZakazButton.Image = Resources.chip;
			TemporaryBase.SearchFULLBegin();
		}
	}

	private void ReadyFilterCheckBox_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void ServiceAdressComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		ShowPhoneWaitingButton.Checked = false;
		WaitZakazButton.Checked = false;
		ShowPhoneWaitingButton.Image = Resources.phone;
		WaitZakazButton.Image = Resources.chip;
		TemporaryBase.SearchFULLBegin();
	}

	private void ReadyFilterCheckBox_MouseClick(object sender, MouseEventArgs e)
	{
		ShowPhoneWaitingButton.Checked = false;
		WaitZakazButton.Checked = false;
		ShowPhoneWaitingButton.Image = Resources.phone;
		WaitZakazButton.Image = Resources.chip;
		TemporaryBase.SearchFULLBegin();
	}

	private void button2_Click(object sender, EventArgs e)
	{
	}

	private void SearchFIOTextBox_TextChanged(object sender, EventArgs e)
	{
		if (SearchFIOTextBox.Text.Length == 12)
		{
			if (long.TryParse(SearchFIOTextBox.Text, out long _))
			{
				string text = basa.BdReadBarcode(SearchFIOTextBox.Text.Trim());
				SearchFIOTextBox.Text = "";
				if (text != "")
				{
					Editor editor = new Editor(this, text);
					editor.Show(this);
				}
			}
			else
			{
				TemporaryBase.FIO = SearchFIOTextBox.Text.ToUpper();
			}
		}
		else
		{
			TemporaryBase.FIO = SearchFIOTextBox.Text.ToUpper();
		}
	}

	private void StockButton_Click(object sender, EventArgs e)
	{
		basa.CreateStock();
		basa.CreateStockMap();

		Stock stock = new Stock(this);
		stock.Show(this);
	}

	private void ReadyFilterCheckBox_Click(object sender, EventArgs e)
	{
		if (ReadyFilterCheckBox.BackColor == Color.FromArgb(179, 215, 243))
		{
			ReadyFilterCheckBox.BackColor = Color.FromArgb(240, 240, 240);
			ReadyFilterCheckBox.Image = Resources.check_circle_outline_blank_16;
		}
		else
		{
			ReadyFilterCheckBox.BackColor = Color.FromArgb(179, 215, 243);
			ReadyFilterCheckBox.Image = Resources.check_circle_outline_16;
		}
		ShowPhoneWaitingButton.Checked = false;
		WaitZakazButton.Checked = false;
		ShowPhoneWaitingButton.Image = Resources.phone;
		WaitZakazButton.Image = Resources.chip;
		TemporaryBase.SearchFULLBegin();
	}

	private void ServiceAdressComboBox_TextChanged(object sender, EventArgs e)
	{
		TemporaryBase.SearchFULLBegin();
	}

	private void SmsStripButton_Click(object sender, EventArgs e)
	{
		MessageBox.Show("В разработке");
	}

	private void toolStripButton3_Click(object sender, EventArgs e)
	{
		ClientsEditor clientsEditor = new ClientsEditor(this);
		clientsEditor.Show(this);
	}

	private void SoglasovanoButton_Click(object sender, EventArgs e)
	{
	}

	private void AllOrdersButton_Click(object sender, EventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)sender;
		if (toolStripButton.BackColor == Color.FromArgb(179, 215, 243))
		{
			ButtonTool(AllOrdersButton);
		}
		else
		{
			ButtonTool((ToolStripButton)sender);
		}
	}

	private void DiagnosticksButton_Click(object sender, EventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)sender;
		if (toolStripButton.BackColor == Color.FromArgb(179, 215, 243))
		{
			ButtonTool(AllOrdersButton);
		}
		else
		{
			ButtonTool((ToolStripButton)sender);
		}
	}

	private void SoglasovanieSKlientomButton_Click(object sender, EventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)sender;
		if (toolStripButton.BackColor == Color.FromArgb(179, 215, 243))
		{
			ButtonTool(AllOrdersButton);
		}
		else
		{
			ButtonTool((ToolStripButton)sender);
		}
	}

	private void SoglasovanoButton1_Click(object sender, EventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)sender;
		if (toolStripButton.BackColor == Color.FromArgb(179, 215, 243))
		{
			ButtonTool(AllOrdersButton);
		}
		else
		{
			ButtonTool((ToolStripButton)sender);
		}
	}

	private void InWorkButton_Click(object sender, EventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)sender;
		if (toolStripButton.BackColor == Color.FromArgb(179, 215, 243))
		{
			ButtonTool(AllOrdersButton);
		}
		else
		{
			ButtonTool((ToolStripButton)sender);
		}
	}

	private void PartWaitingButton_Click(object sender, EventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)sender;
		if (toolStripButton.BackColor == Color.FromArgb(179, 215, 243))
		{
			ButtonTool(AllOrdersButton);
		}
		else
		{
			ButtonTool((ToolStripButton)sender);
		}
	}

	private void ReadyStatButton_Click(object sender, EventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)sender;
		if (toolStripButton.BackColor == Color.FromArgb(179, 215, 243))
		{
			ButtonTool(AllOrdersButton);
		}
		else
		{
			ButtonTool((ToolStripButton)sender);
		}
	}

	private void OutOfSCButton_Click(object sender, EventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)sender;
		if (toolStripButton.BackColor == Color.FromArgb(179, 215, 243))
		{
			ButtonTool(AllOrdersButton);
		}
		else
		{
			ButtonTool((ToolStripButton)sender);
		}
	}

	private void PrinyatPoGarantiiButton_Click(object sender, EventArgs e)
	{
		ToolStripButton toolStripButton = (ToolStripButton)sender;
		if (toolStripButton.BackColor == Color.FromArgb(179, 215, 243))
		{
			ButtonTool(AllOrdersButton);
		}
		else
		{
			ButtonTool((ToolStripButton)sender);
		}
	}

	private void ButtonTool(ToolStripButton tsb)
	{
		StatusButtonColorer();
		tsb.BackColor = Color.FromArgb(179, 215, 243);
		if (tsb.Tag == null || tsb.Tag.ToString() == "")
		{
			tsb.Tag = "";
			TemporaryBase.ColumnIndex = 0;
			TemporaryBase.SortAscending = false;
			TemporaryBase.SearchInOld = true;
			TemporaryBase.IskatVseVidannoe = false;
		}
		else if (tsb.Tag.ToString() == "Выдан")
		{
			TemporaryBase.ColumnIndex = 2;
			TemporaryBase.SortAscending = false;
			TemporaryBase.SearchInOld = false;
			TemporaryBase.IskatVseVidannoe = true;
		}
		else
		{
			TemporaryBase.ColumnIndex = 0;
			TemporaryBase.SortAscending = false;
			TemporaryBase.SearchInOld = false;
			TemporaryBase.IskatVseVidannoe = false;
		}
		ShowPhoneWaitingButton.Checked = false;
		WaitZakazButton.Checked = false;
		ShowPhoneWaitingButton.Image = Resources.phone;
		WaitZakazButton.Image = Resources.chip;
		TemporaryBase.soglasovat = "";
		TemporaryBase.NeedZakaz = "";
		TemporaryBase.Status = tsb.Tag.ToString();
		TemporaryBase.SearchFULLBegin();
	}

	private void StatusButtonColorer()
	{
		AllOrdersButton.BackColor = Color.FromArgb(240, 240, 240);
		DiagnosticksButton.BackColor = Color.FromArgb(240, 240, 240);
		SoglasovanieSKlientomButton.BackColor = Color.FromArgb(240, 240, 240);
		SoglasovanoButton1.BackColor = Color.FromArgb(240, 240, 240);
		InWorkButton.BackColor = Color.FromArgb(240, 240, 240);
		PartWaitingButton.BackColor = Color.FromArgb(240, 240, 240);
		ReadyStatButton.BackColor = Color.FromArgb(240, 240, 240);
		OutOfSCButton.BackColor = Color.FromArgb(240, 240, 240);
		PrinyatPoGarantiiButton.BackColor = Color.FromArgb(240, 240, 240);
	}

	private void FullSearchType_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			ShowPhoneWaitingButton.Checked = false;
			WaitZakazButton.Checked = false;
			ShowPhoneWaitingButton.Image = Resources.phone;
			WaitZakazButton.Image = Resources.chip;
			TemporaryBase.SearchFULLBegin();
		}
	}

	private void FullSearchBrand_TextChanged(object sender, EventArgs e)
	{
		TemporaryBase.Brand = FullSearchBrand.Text.ToUpper().Trim();
	}

	private void FullSearchModel_TextChanged(object sender, EventArgs e)
	{
		TemporaryBase.Model = FullSearchModel.Text.ToUpper().Trim();
	}

	private void FullSearchSerial_TextChanged(object sender, EventArgs e)
	{
		TemporaryBase.SerialImei = FullSearchSerial.Text.ToUpper().Trim();
	}

	private void FullSearchMaster_TextChanged(object sender, EventArgs e)
	{
		TemporaryBase.Master = FullSearchMaster.Text.Trim();
	}

	private void FullSearchType_TextChanged(object sender, EventArgs e)
	{
		TemporaryBase.TypeOf = FullSearchType.Text.ToUpper().Trim();
	}

	private void FullSearchPhone_TextChanged(object sender, EventArgs e)
	{
		TemporaryBase.Phone = FullSearchPhone.Text.Trim().Replace(" ", "");
	}

	private void FullSearchPhone_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			ShowPhoneWaitingButton.Checked = false;
			WaitZakazButton.Checked = false;
			ShowPhoneWaitingButton.Image = Resources.phone;
			WaitZakazButton.Image = Resources.chip;
			TemporaryBase.SearchFULLBegin();
		}
	}

	private void FullSearchBrand_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			ShowPhoneWaitingButton.Checked = false;
			WaitZakazButton.Checked = false;
			ShowPhoneWaitingButton.Image = Resources.phone;
			WaitZakazButton.Image = Resources.chip;
			TemporaryBase.SearchFULLBegin();
		}
	}

	private void FullSearchModel_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			ShowPhoneWaitingButton.Checked = false;
			WaitZakazButton.Checked = false;
			ShowPhoneWaitingButton.Image = Resources.phone;
			WaitZakazButton.Image = Resources.chip;
			TemporaryBase.SearchFULLBegin();
		}
	}

	private void FullSearchSerial_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			ShowPhoneWaitingButton.Checked = false;
			WaitZakazButton.Checked = false;
			ShowPhoneWaitingButton.Image = Resources.phone;
			WaitZakazButton.Image = Resources.chip;
			TemporaryBase.SearchFULLBegin();
		}
	}

	private void FullSearchMaster_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			ShowPhoneWaitingButton.Checked = false;
			WaitZakazButton.Checked = false;
			ShowPhoneWaitingButton.Image = Resources.phone;
			WaitZakazButton.Image = Resources.chip;
			TemporaryBase.SearchFULLBegin();
		}
	}

	private void FullSearchType_SelectedIndexChanged(object sender, EventArgs e)
	{
		ShowPhoneWaitingButton.Checked = false;
		WaitZakazButton.Checked = false;
		ShowPhoneWaitingButton.Image = Resources.phone;
		WaitZakazButton.Image = Resources.chip;
		TemporaryBase.SearchFULLBegin();
	}

	private void FullSearchBrand_SelectedIndexChanged(object sender, EventArgs e)
	{
		ShowPhoneWaitingButton.Checked = false;
		WaitZakazButton.Checked = false;
		ShowPhoneWaitingButton.Image = Resources.phone;
		WaitZakazButton.Image = Resources.chip;
		TemporaryBase.SearchFULLBegin();
	}

	private void FullSearchMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		ShowPhoneWaitingButton.Checked = false;
		WaitZakazButton.Checked = false;
		ShowPhoneWaitingButton.Image = Resources.phone;
		WaitZakazButton.Image = Resources.chip;
		TemporaryBase.SearchFULLBegin();
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
			this.MainListView = new System.Windows.Forms.ListView();
			this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DataPriema = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DataVidachi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DataPredoplati = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.surname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.phonee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.AboutUS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.WhatRemont = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Brand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SerialNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Sostoyanie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.komplektnost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.polomka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.komment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PredvCoast = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Predoplata = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Zatrati = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Skidka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.master = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.VipolnRaboti = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.garanty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.WaitZakaz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Adress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.AdressSC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DeviceColour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.NewClientButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.StatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.CountListViewLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.AddPositionButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.SearchFIOButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.SearchFullButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.ShowPhoneWaitingButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.WaitZakazButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.SmsStripButton = new System.Windows.Forms.ToolStripButton();
			this.SettingsButton = new System.Windows.Forms.ToolStripButton();
			this.ReadyFilterCheckBox = new System.Windows.Forms.ToolStripButton();
			this.ServiceAdressComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.StockButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.SearchFIOTextBox = new System.Windows.Forms.TextBox();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.AllOrdersButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.DiagnosticksButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.SoglasovanieSKlientomButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.SoglasovanoButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.InWorkButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.PartWaitingButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.ReadyStatButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.PrinyatPoGarantiiButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.OutOfSCButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.FullSearchPhone = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.FullSearchType = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.FullSearchBrand = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
			this.FullSearchModel = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
			this.FullSearchSerial = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
			this.FullSearchMaster = new System.Windows.Forms.ToolStripComboBox();
			this.statusStrip.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainListView
			// 
			this.MainListView.AllowColumnReorder = true;
			this.MainListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.DataPriema,
            this.DataVidachi,
            this.DataPredoplati,
            this.surname,
            this.phonee,
            this.AboutUS,
            this.WhatRemont,
            this.Brand,
            this.Model,
            this.SerialNumber,
            this.Sostoyanie,
            this.komplektnost,
            this.polomka,
            this.komment,
            this.PredvCoast,
            this.Predoplata,
            this.Zatrati,
            this.Price,
            this.Skidka,
            this.Status,
            this.master,
            this.VipolnRaboti,
            this.garanty,
            this.WaitZakaz,
            this.Adress,
            this.AdressSC,
            this.DeviceColour});
			this.MainListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MainListView.FullRowSelect = true;
			this.MainListView.GridLines = true;
			this.MainListView.HideSelection = false;
			this.MainListView.Location = new System.Drawing.Point(0, 54);
			this.MainListView.MultiSelect = false;
			this.MainListView.Name = "MainListView";
			this.MainListView.Size = new System.Drawing.Size(1183, 592);
			this.MainListView.TabIndex = 2;
			this.MainListView.UseCompatibleStateImageBehavior = false;
			this.MainListView.View = System.Windows.Forms.View.Details;
			this.MainListView.VirtualMode = true;
			this.MainListView.CacheVirtualItems += new System.Windows.Forms.CacheVirtualItemsEventHandler(this.MainListView_CacheVirtualItems);
			this.MainListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.MainListView_ColumnClick);
			this.MainListView.ColumnReordered += new System.Windows.Forms.ColumnReorderedEventHandler(this.MainListView_ColumnReordered);
			this.MainListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.MainListView_ColumnWidthChanged);
			this.MainListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.MainListView_RetrieveVirtualItem);
			this.MainListView.SelectedIndexChanged += new System.EventHandler(this.MainListView_SelectedIndexChanged);
			this.MainListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainListView_MouseDoubleClick);
			// 
			// Number
			// 
			this.Number.Text = "№";
			// 
			// DataPriema
			// 
			this.DataPriema.Text = "Дата приёма";
			this.DataPriema.Width = 80;
			// 
			// DataVidachi
			// 
			this.DataVidachi.Text = "Дата выдачи";
			this.DataVidachi.Width = 80;
			// 
			// DataPredoplati
			// 
			this.DataPredoplati.Text = "Дата предоплаты";
			this.DataPredoplati.Width = 80;
			// 
			// surname
			// 
			this.surname.Text = "ФИО";
			// 
			// phonee
			// 
			this.phonee.Text = "Телефон";
			this.phonee.Width = 90;
			// 
			// AboutUS
			// 
			this.AboutUS.Text = "Узнали о нас";
			this.AboutUS.Width = 80;
			// 
			// WhatRemont
			// 
			this.WhatRemont.Text = "Тип устройства";
			this.WhatRemont.Width = 95;
			// 
			// Brand
			// 
			this.Brand.Text = "Бренд";
			// 
			// Model
			// 
			this.Model.Text = "Модель";
			// 
			// SerialNumber
			// 
			this.SerialNumber.Text = "Серийный номер";
			this.SerialNumber.Width = 84;
			// 
			// Sostoyanie
			// 
			this.Sostoyanie.Text = "Состояние";
			this.Sostoyanie.Width = 70;
			// 
			// komplektnost
			// 
			this.komplektnost.Text = "Комплект";
			this.komplektnost.Width = 65;
			// 
			// polomka
			// 
			this.polomka.Text = "Неисправность";
			this.polomka.Width = 80;
			// 
			// komment
			// 
			this.komment.Text = "Комментарий";
			this.komment.Width = 80;
			// 
			// PredvCoast
			// 
			this.PredvCoast.Text = "Предв. стоимость";
			// 
			// Predoplata
			// 
			this.Predoplata.Text = "Предоплата";
			// 
			// Zatrati
			// 
			this.Zatrati.Text = "Затраты";
			// 
			// Price
			// 
			this.Price.Text = "Цена";
			// 
			// Skidka
			// 
			this.Skidka.Text = "Скидка";
			// 
			// Status
			// 
			this.Status.Text = "Статус";
			// 
			// master
			// 
			this.master.Text = "Мастер";
			// 
			// VipolnRaboti
			// 
			this.VipolnRaboti.Text = "Выполненные работы";
			// 
			// garanty
			// 
			this.garanty.Text = "Гарантия";
			// 
			// WaitZakaz
			// 
			this.WaitZakaz.Text = "Заказать";
			// 
			// Adress
			// 
			this.Adress.Text = "Адрес";
			// 
			// AdressSC
			// 
			this.AdressSC.Text = "Адрес СЦ";
			// 
			// DeviceColour
			// 
			this.DeviceColour.Text = "Цвет";
			// 
			// NewClientButton
			// 
			this.NewClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.NewClientButton.Location = new System.Drawing.Point(0, 1);
			this.NewClientButton.Name = "NewClientButton";
			this.NewClientButton.Size = new System.Drawing.Size(115, 23);
			this.NewClientButton.TabIndex = 1;
			this.NewClientButton.Text = "Новый клиент";
			this.NewClientButton.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(121, 1);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(114, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Редактировать";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// statusStrip
			// 
			this.statusStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statusStrip.AutoSize = false;
			this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripLabel,
            this.toolStripStatusLabel2,
            this.CountListViewLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 646);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1183, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// StatusStripLabel
			// 
			this.StatusStripLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
			this.StatusStripLabel.Name = "StatusStripLabel";
			this.StatusStripLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
			this.toolStripStatusLabel2.Text = "|";
			// 
			// CountListViewLabel
			// 
			this.CountListViewLabel.Name = "CountListViewLabel";
			this.CountListViewLabel.Size = new System.Drawing.Size(0, 17);
			this.CountListViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Comic Sans MS", 10F);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPositionButton,
            this.toolStripSeparator1,
            this.SearchFIOButton,
            this.toolStripLabel2,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.SearchFullButton,
            this.toolStripSeparator4,
            this.ShowPhoneWaitingButton,
            this.toolStripSeparator3,
            this.WaitZakazButton,
            this.toolStripSeparator7,
            this.toolStripButton2,
            this.toolStripSeparator5,
            this.SmsStripButton,
            this.SettingsButton,
            this.ReadyFilterCheckBox,
            this.ServiceAdressComboBox,
            this.StockButton,
            this.toolStripSeparator6,
            this.toolStripButton3});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1183, 26);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// AddPositionButton
			// 
			this.AddPositionButton.Image = global::SeviceCenter.Properties.Resources.add;
			this.AddPositionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddPositionButton.Name = "AddPositionButton";
			this.AddPositionButton.Size = new System.Drawing.Size(92, 23);
			this.AddPositionButton.Text = "Добавить";
			this.AddPositionButton.Click += new System.EventHandler(this.AddPositionButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
			// 
			// SearchFIOButton
			// 
			this.SearchFIOButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SearchFIOButton.Name = "SearchFIOButton";
			this.SearchFIOButton.Size = new System.Drawing.Size(47, 23);
			this.SearchFIOButton.Text = "ФИО:";
			this.SearchFIOButton.Click += new System.EventHandler(this.SearchFIOButton_Click);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.AutoSize = false;
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(146, 23);
			this.toolStripLabel2.Text = "toolStripLabel2";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(101, 23);
			this.toolStripButton1.Text = "Сброс поиска";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
			// 
			// SearchFullButton
			// 
			this.SearchFullButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SearchFullButton.Name = "SearchFullButton";
			this.SearchFullButton.Size = new System.Drawing.Size(105, 23);
			this.SearchFullButton.Text = "Расширенный";
			this.SearchFullButton.Click += new System.EventHandler(this.SearchFullButton_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 26);
			// 
			// ShowPhoneWaitingButton
			// 
			this.ShowPhoneWaitingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ShowPhoneWaitingButton.Image = global::SeviceCenter.Properties.Resources.phone;
			this.ShowPhoneWaitingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ShowPhoneWaitingButton.Name = "ShowPhoneWaitingButton";
			this.ShowPhoneWaitingButton.RightToLeftAutoMirrorImage = true;
			this.ShowPhoneWaitingButton.Size = new System.Drawing.Size(23, 23);
			this.ShowPhoneWaitingButton.Text = "Показать  ожидающие звонка";
			this.ShowPhoneWaitingButton.Click += new System.EventHandler(this.ShowPhoneWaitingButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
			// 
			// WaitZakazButton
			// 
			this.WaitZakazButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.WaitZakazButton.Image = global::SeviceCenter.Properties.Resources.chip;
			this.WaitZakazButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.WaitZakazButton.Name = "WaitZakazButton";
			this.WaitZakazButton.Size = new System.Drawing.Size(23, 23);
			this.WaitZakazButton.Text = "Требует заказа";
			this.WaitZakazButton.Click += new System.EventHandler(this.WaitZakazButton_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 26);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = global::SeviceCenter.Properties.Resources.graf;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 23);
			this.toolStripButton2.Text = "Графики и отчёты";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 26);
			// 
			// SmsStripButton
			// 
			this.SmsStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.SmsStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SmsStripButton.Name = "SmsStripButton";
			this.SmsStripButton.Size = new System.Drawing.Size(23, 23);
			this.SmsStripButton.Text = "Отправка смс";
			this.SmsStripButton.Click += new System.EventHandler(this.SmsStripButton_Click);
			// 
			// SettingsButton
			// 
			this.SettingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SettingsButton.Name = "SettingsButton";
			this.SettingsButton.Size = new System.Drawing.Size(85, 23);
			this.SettingsButton.Text = "Настройки";
			this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
			// 
			// ReadyFilterCheckBox
			// 
			this.ReadyFilterCheckBox.BackColor = System.Drawing.SystemColors.Control;
			this.ReadyFilterCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ReadyFilterCheckBox.Image = global::SeviceCenter.Properties.Resources.Gotovo;
			this.ReadyFilterCheckBox.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ReadyFilterCheckBox.Name = "ReadyFilterCheckBox";
			this.ReadyFilterCheckBox.Size = new System.Drawing.Size(76, 23);
			this.ReadyFilterCheckBox.Text = "Готово";
			this.ReadyFilterCheckBox.ToolTipText = "Показывать записи со статусом Готов, вместе с остальными.\r\nТак же при поиске учит" +
    "ывается, какой из статусов выбран";
			this.ReadyFilterCheckBox.Click += new System.EventHandler(this.ReadyFilterCheckBox_Click);
			// 
			// ServiceAdressComboBox
			// 
			this.ServiceAdressComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.ServiceAdressComboBox.Items.AddRange(new object[] {
            ""});
			this.ServiceAdressComboBox.Name = "ServiceAdressComboBox";
			this.ServiceAdressComboBox.Size = new System.Drawing.Size(130, 26);
			this.ServiceAdressComboBox.ToolTipText = "Искать только в этом сервисе, если пусто, то во всех";
			this.ServiceAdressComboBox.TextChanged += new System.EventHandler(this.ServiceAdressComboBox_TextChanged);
			// 
			// StockButton
			// 
			this.StockButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.StockButton.Name = "StockButton";
			this.StockButton.Size = new System.Drawing.Size(52, 23);
			this.StockButton.Text = "Склад";
			this.StockButton.ToolTipText = "Склад";
			this.StockButton.Click += new System.EventHandler(this.StockButton_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 26);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(74, 23);
			this.toolStripButton3.Text = "Клиенты";
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// SearchFIOTextBox
			// 
			this.SearchFIOTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.SearchFIOTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SearchFIOTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SearchFIOTextBox.ForeColor = System.Drawing.SystemColors.InfoText;
			this.SearchFIOTextBox.Location = new System.Drawing.Point(155, 1);
			this.SearchFIOTextBox.Name = "SearchFIOTextBox";
			this.SearchFIOTextBox.Size = new System.Drawing.Size(142, 23);
			this.SearchFIOTextBox.TabIndex = 4;
			this.SearchFIOTextBox.TextChanged += new System.EventHandler(this.SearchFIOTextBox_TextChanged);
			this.SearchFIOTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchFIOTextBox_KeyDown);
			// 
			// toolStrip2
			// 
			this.toolStrip2.AllowItemReorder = true;
			this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
			this.toolStrip2.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AllOrdersButton,
            this.toolStripSeparator8,
            this.DiagnosticksButton,
            this.toolStripSeparator9,
            this.SoglasovanieSKlientomButton,
            this.toolStripSeparator10,
            this.SoglasovanoButton1,
            this.toolStripSeparator11,
            this.InWorkButton,
            this.toolStripSeparator12,
            this.PartWaitingButton,
            this.toolStripSeparator14,
            this.ReadyStatButton,
            this.toolStripSeparator15,
            this.PrinyatPoGarantiiButton,
            this.toolStripSeparator13,
            this.OutOfSCButton});
			this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.toolStrip2.Location = new System.Drawing.Point(0, 26);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(1183, 26);
			this.toolStrip2.TabIndex = 5;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// AllOrdersButton
			// 
			this.AllOrdersButton.Image = global::SeviceCenter.Properties.Resources.Status_allOreders;
			this.AllOrdersButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AllOrdersButton.Name = "AllOrdersButton";
			this.AllOrdersButton.Size = new System.Drawing.Size(89, 23);
			this.AllOrdersButton.Text = "Текущие";
			this.AllOrdersButton.ToolTipText = "Показывает все записи, которые в данный момент в сервисе, и не имеют даты выдачи";
			this.AllOrdersButton.Click += new System.EventHandler(this.AllOrdersButton_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 26);
			// 
			// DiagnosticksButton
			// 
			this.DiagnosticksButton.Image = global::SeviceCenter.Properties.Resources.Status_diagnostika;
			this.DiagnosticksButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DiagnosticksButton.Name = "DiagnosticksButton";
			this.DiagnosticksButton.Size = new System.Drawing.Size(116, 23);
			this.DiagnosticksButton.Tag = "Диагностика";
			this.DiagnosticksButton.Text = "Диагностика";
			this.DiagnosticksButton.Click += new System.EventHandler(this.DiagnosticksButton_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 26);
			// 
			// SoglasovanieSKlientomButton
			// 
			this.SoglasovanieSKlientomButton.Image = global::SeviceCenter.Properties.Resources.Status_SoglasovanieSClientom;
			this.SoglasovanieSKlientomButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SoglasovanieSKlientomButton.Name = "SoglasovanieSKlientomButton";
			this.SoglasovanieSKlientomButton.Size = new System.Drawing.Size(203, 23);
			this.SoglasovanieSKlientomButton.Tag = "Согласование с клиентом";
			this.SoglasovanieSKlientomButton.Text = "Согласование с клиентом";
			this.SoglasovanieSKlientomButton.Click += new System.EventHandler(this.SoglasovanieSKlientomButton_Click);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 26);
			// 
			// SoglasovanoButton1
			// 
			this.SoglasovanoButton1.Image = global::SeviceCenter.Properties.Resources.Status_Soglasovano;
			this.SoglasovanoButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SoglasovanoButton1.Name = "SoglasovanoButton1";
			this.SoglasovanoButton1.Size = new System.Drawing.Size(113, 23);
			this.SoglasovanoButton1.Tag = "Согласовано";
			this.SoglasovanoButton1.Text = "Согласовано";
			this.SoglasovanoButton1.Click += new System.EventHandler(this.SoglasovanoButton1_Click);
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 26);
			// 
			// InWorkButton
			// 
			this.InWorkButton.Image = global::SeviceCenter.Properties.Resources.Status_inWork;
			this.InWorkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.InWorkButton.Name = "InWorkButton";
			this.InWorkButton.Size = new System.Drawing.Size(138, 23);
			this.InWorkButton.Tag = "Принят в работу";
			this.InWorkButton.Text = "Принят в работу";
			this.InWorkButton.Click += new System.EventHandler(this.InWorkButton_Click);
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 26);
			// 
			// PartWaitingButton
			// 
			this.PartWaitingButton.Image = global::SeviceCenter.Properties.Resources.Status_parts;
			this.PartWaitingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PartWaitingButton.Name = "PartWaitingButton";
			this.PartWaitingButton.Size = new System.Drawing.Size(125, 23);
			this.PartWaitingButton.Tag = "Ждёт запчасть";
			this.PartWaitingButton.Text = "Ждёт запчасть";
			this.PartWaitingButton.Click += new System.EventHandler(this.PartWaitingButton_Click);
			// 
			// toolStripSeparator14
			// 
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 26);
			// 
			// ReadyStatButton
			// 
			this.ReadyStatButton.Image = global::SeviceCenter.Properties.Resources.StatusReady;
			this.ReadyStatButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ReadyStatButton.Name = "ReadyStatButton";
			this.ReadyStatButton.Size = new System.Drawing.Size(68, 23);
			this.ReadyStatButton.Tag = "Готов";
			this.ReadyStatButton.Text = "Готов";
			this.ReadyStatButton.Click += new System.EventHandler(this.ReadyStatButton_Click);
			// 
			// toolStripSeparator15
			// 
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(6, 26);
			// 
			// PrinyatPoGarantiiButton
			// 
			this.PrinyatPoGarantiiButton.Image = global::SeviceCenter.Properties.Resources.Status_PrinyatPoGarantii;
			this.PrinyatPoGarantiiButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PrinyatPoGarantiiButton.Name = "PrinyatPoGarantiiButton";
			this.PrinyatPoGarantiiButton.Size = new System.Drawing.Size(166, 23);
			this.PrinyatPoGarantiiButton.Tag = "Принят по гарантии";
			this.PrinyatPoGarantiiButton.Text = "Принят по гарантии";
			this.PrinyatPoGarantiiButton.Click += new System.EventHandler(this.PrinyatPoGarantiiButton_Click);
			// 
			// toolStripSeparator13
			// 
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(6, 26);
			// 
			// OutOfSCButton
			// 
			this.OutOfSCButton.Image = global::SeviceCenter.Properties.Resources.Status_Vidan;
			this.OutOfSCButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.OutOfSCButton.Name = "OutOfSCButton";
			this.OutOfSCButton.Size = new System.Drawing.Size(72, 23);
			this.OutOfSCButton.Tag = "Выдан";
			this.OutOfSCButton.Text = "Выдан";
			this.OutOfSCButton.Click += new System.EventHandler(this.OutOfSCButton_Click);
			// 
			// toolStrip3
			// 
			this.toolStrip3.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.FullSearchPhone,
            this.toolStripLabel3,
            this.FullSearchType,
            this.toolStripLabel4,
            this.FullSearchBrand,
            this.toolStripLabel5,
            this.FullSearchModel,
            this.toolStripLabel6,
            this.FullSearchSerial,
            this.toolStripLabel7,
            this.FullSearchMaster});
			this.toolStrip3.Location = new System.Drawing.Point(0, 52);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(1183, 25);
			this.toolStrip3.TabIndex = 6;
			this.toolStrip3.Text = "toolStrip3";
			this.toolStrip3.Visible = false;
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(40, 22);
			this.toolStripLabel1.Text = "Тел:";
			// 
			// FullSearchPhone
			// 
			this.FullSearchPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FullSearchPhone.Name = "FullSearchPhone";
			this.FullSearchPhone.Size = new System.Drawing.Size(130, 25);
			this.FullSearchPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullSearchPhone_KeyDown);
			this.FullSearchPhone.TextChanged += new System.EventHandler(this.FullSearchPhone_TextChanged);
			// 
			// toolStripLabel3
			// 
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(41, 22);
			this.toolStripLabel3.Text = "Тип:";
			// 
			// FullSearchType
			// 
			this.FullSearchType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.FullSearchType.Name = "FullSearchType";
			this.FullSearchType.Size = new System.Drawing.Size(150, 25);
			this.FullSearchType.SelectedIndexChanged += new System.EventHandler(this.FullSearchType_SelectedIndexChanged);
			this.FullSearchType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullSearchType_KeyDown);
			this.FullSearchType.TextChanged += new System.EventHandler(this.FullSearchType_TextChanged);
			// 
			// toolStripLabel4
			// 
			this.toolStripLabel4.Name = "toolStripLabel4";
			this.toolStripLabel4.Size = new System.Drawing.Size(52, 22);
			this.toolStripLabel4.Text = "Бренд:";
			// 
			// FullSearchBrand
			// 
			this.FullSearchBrand.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.FullSearchBrand.Name = "FullSearchBrand";
			this.FullSearchBrand.Size = new System.Drawing.Size(128, 25);
			this.FullSearchBrand.SelectedIndexChanged += new System.EventHandler(this.FullSearchBrand_SelectedIndexChanged);
			this.FullSearchBrand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullSearchBrand_KeyDown);
			this.FullSearchBrand.TextChanged += new System.EventHandler(this.FullSearchBrand_TextChanged);
			// 
			// toolStripLabel5
			// 
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(65, 22);
			this.toolStripLabel5.Text = "Модель:";
			// 
			// FullSearchModel
			// 
			this.FullSearchModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FullSearchModel.Name = "FullSearchModel";
			this.FullSearchModel.Size = new System.Drawing.Size(122, 25);
			this.FullSearchModel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullSearchModel_KeyDown);
			this.FullSearchModel.TextChanged += new System.EventHandler(this.FullSearchModel_TextChanged);
			// 
			// toolStripLabel6
			// 
			this.toolStripLabel6.Name = "toolStripLabel6";
			this.toolStripLabel6.Size = new System.Drawing.Size(102, 22);
			this.toolStripLabel6.Text = "Серийный №:";
			// 
			// FullSearchSerial
			// 
			this.FullSearchSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FullSearchSerial.Name = "FullSearchSerial";
			this.FullSearchSerial.Size = new System.Drawing.Size(110, 25);
			this.FullSearchSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullSearchSerial_KeyDown);
			this.FullSearchSerial.TextChanged += new System.EventHandler(this.FullSearchSerial_TextChanged);
			// 
			// toolStripLabel7
			// 
			this.toolStripLabel7.Name = "toolStripLabel7";
			this.toolStripLabel7.Size = new System.Drawing.Size(61, 22);
			this.toolStripLabel7.Text = "Мастер:";
			// 
			// FullSearchMaster
			// 
			this.FullSearchMaster.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.FullSearchMaster.Name = "FullSearchMaster";
			this.FullSearchMaster.Size = new System.Drawing.Size(121, 25);
			this.FullSearchMaster.SelectedIndexChanged += new System.EventHandler(this.FullSearchMaster_SelectedIndexChanged);
			this.FullSearchMaster.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullSearchMaster_KeyDown);
			this.FullSearchMaster.TextChanged += new System.EventHandler(this.FullSearchMaster_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1183, 668);
			this.Controls.Add(this.toolStrip3);
			this.Controls.Add(this.toolStrip2);
			this.Controls.Add(this.SearchFIOTextBox);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.NewClientButton);
			this.Controls.Add(this.MainListView);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}
}
