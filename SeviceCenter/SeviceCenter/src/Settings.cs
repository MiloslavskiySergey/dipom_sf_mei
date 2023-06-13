// Settings

using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Settings : Form
{
	private string delZapis = "1";

	private string addZapis = "1";

	private string saveZapis = "1";

	private string graf = "1";

	private string sms = "1";

	private string stock = "1";

	private string clients = "1";

	private string stockAdd = "1";

	private string stockDel = "1";

	private string stockEdit = "1";

	private string clientAdd = "1";

	private string clientDel = "1";

	private string clientConcat = "1";

	private string settings = "1";

	private string dates = "1";

	private string editDates = "1";

	private MainForm mainForm;

	private IniFile INIF = new IniFile("Config.ini");

	private string color1 = "-8323328";

	private IContainer components = null;

	public Button SaveButton;

	public ColorDialog colorDialog1;

	public Label label4;

	private ColorDialog colorDialogBlist;

	private ContextMenuStrip contextMenuStrip1;
	private TabPage GroupDostupTab;
	private Panel panel5;
	private Label label6;
	private Button DeleteGroupButton;
	private Button SaveGroupDostupButton;
	private Label label21;
	private ComboBox GroupDostupComboBox;
	private Panel panel4;
	private Label label22;
	private TextBox GroupDostupNameTextBox;
	private Button AddGroupDostupButton;
	private Panel panel3;
	private CheckBox editDatesCheckBox;
	private CheckBox datesCheckBox;
	private CheckBox settingsCheckBox;
	private CheckBox clientConcatCheckBox;
	private CheckBox clientDelCheckBox;
	private CheckBox clientAddCheckBox;
	private CheckBox stockEditCheckBox;
	private CheckBox stockDelCheckBox;
	private CheckBox stockAddCheckBox;
	private CheckBox clientsCheckBox;
	private CheckBox stockCheckBox;
	private CheckBox smsCheckBox;
	private CheckBox grafCheckBox;
	private CheckBox saveZapisCheckBox;
	private CheckBox addZapisCheckBox;
	private CheckBox delZapisCheckBox;
	private TabPage Dostup;
	private Button ShowHistoryButton;
	private Panel panel2;
	private TextBox UserChangePasswordTextBox;
	private Label label26;
	private Button UserChangePasswordButton;
	private Button UserDeleteButton;
	private Button ReselectUserRulesButton;
	private Label label25;
	private Label label24;
	private ComboBox UserComboBox1;
	private ComboBox UsersComboBoxGroupEdit;
	private Panel panel1;
	private TextBox UserPasswordTextBox;
	private Label label23;
	private ComboBox UsersGroupDostupComboboxAdd;
	private Button UserDostupAddButton;
	private Label label20;
	private TextBox UserNameTextBox;
	private Label label19;
	public TabPage tabPage3;
	public Button PhoneExportButton;
	public TabPage tabPage2;
	private Label label18;
	private Label label17;
	private Label label16;
	private TextBox BarcodeHTextBox;
	private TextBox BarcodeWTextBox;
	public TextBox ValutaTextBox;
	public Label label3;
	public Button ReAktor;
	public TabPage tabPage1;
	private Button pathbutton1;
	public CheckBox openClientFilesCheckBox;
	public Button StolbButton;
	public CheckBox PoloskiCheckBox;
	public Button BlistButtonColor;
	public Button ShowBackupsButton;
	public CheckBox EveryDayBackupCheckBox;
	public ComboBox MasterComboBox;
	public CheckBox GarantyDefaultCheckBox;
	public Label label15;
	public NumericUpDown NumericDiagnosikDays;
	public Button FallDownListSetButton;
	public CheckBox ColorDiagnosticCheckBox;
	public Button ColorButton;
	public Label label1;
	public Label label7;
	public Label label2;
	public ComboBox ServiceAdressComboBox;
	public TabControl SetTab;
	private FolderBrowserDialog folderBrowserDialog1;

	public Settings(MainForm fm1)
	{
		mainForm = fm1;
		InitializeComponent();
		mainForm.setBool = true;
		colorDialog1.FullOpen = true;
		if (INIF.KeyExists("PROGRAMM_SETTINGS", "daysDiagnostik"))
		{
			NumericDiagnosikDays.Value = -1 * int.Parse(INIF.ReadINI("PROGRAMM_SETTINGS", "daysDiagnostik"));
		}
		if (INIF.KeyExists("PROGRAMM_SETTINGS", "colorDiagnostik"))
		{
			colorDialog1.Color = Color.FromArgb(int.Parse(INIF.ReadINI("PROGRAMM_SETTINGS", "colorDiagnostik")));
		}
		else
		{
			colorDialog1.Color = Color.YellowGreen;
		}
		ColorButton.BackColor = colorDialog1.Color;
		if (INIF.KeyExists("PROGRAMM_SETTINGS", "colorCheckBox"))
		{
			if (INIF.ReadINI("PROGRAMM_SETTINGS", "colorCheckBox") == "Checked")
			{
				ColorDiagnosticCheckBox.Checked = true;
			}
			else
			{
				ColorDiagnosticCheckBox.Checked = false;
			}
		}
		if (INIF.KeyExists("PROGRAMM_SETTINGS", "valuta"))
		{
			ValutaTextBox.Text = INIF.ReadINI("PROGRAMM_SETTINGS", "valuta");
			return;
		}
		ValutaTextBox.Text = "Рублей";
		TemporaryBase.valuta = ValutaTextBox.Text;
		INIF.WriteINI("PROGRAMM_SETTINGS", "valuta", ValutaTextBox.Text);
	}

	private void ColorButton_Click(object sender, EventArgs e)
	{
		if (colorDialog1.ShowDialog() != DialogResult.Cancel)
		{
			color1 = colorDialog1.Color.ToArgb().ToString();
			ColorButton.BackColor = colorDialog1.Color;
		}
	}

	private void SaveButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Сохранить настройки?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			INIF.WriteINI("PROGRAMM_SETTINGS", "daysDiagnostik", (NumericDiagnosikDays.Value * decimal.MinusOne).ToString());
			INIF.WriteINI("PROGRAMM_SETTINGS", "colorDiagnostik", color1);
			INIF.WriteINI("PROGRAMM_SETTINGS", "colorCheckBox", ColorDiagnosticCheckBox.CheckState.ToString());
			INIF.WriteINI("PROGRAMM_SETTINGS", "valuta", ValutaTextBox.Text);
			INIF.WriteINI("CHECKBOX", "garantyDefault", GarantyDefaultCheckBox.CheckState.ToString());
			INIF.WriteINI("CHECKBOX", "EveryDayBackup", EveryDayBackupCheckBox.CheckState.ToString());
			TemporaryBase.everyDayBackup = EveryDayBackupCheckBox.CheckState.ToString();
			if (ServiceAdressComboBox.SelectedIndex >= 0)
			{
				TemporaryBase.AdressSCDefault = ServiceAdressComboBox.SelectedIndex.ToString();
				INIF.WriteINI(Registration.getHDD(), "AdressSCDefault", ServiceAdressComboBox.SelectedIndex.ToString());
			}
			TemporaryBase.MasterDefault = MasterComboBox.Text;
			INIF.WriteINI(Registration.getHDD(), "MasterDefault", MasterComboBox.Text);
			TemporaryBase.valuta = ValutaTextBox.Text;
			if (BarcodeHTextBox.Text != "" && BarcodeWTextBox.Text != "")
			{
				INIF.WriteINI("ACTS", "BarcodeH", BarcodeHTextBox.Text);
				INIF.WriteINI("ACTS", "BarcodeW", BarcodeWTextBox.Text);
				TemporaryBase.barcodeH = int.Parse(BarcodeHTextBox.Text);
				TemporaryBase.barcodeW = int.Parse(BarcodeWTextBox.Text);
			}
			mainForm.StatusStripLabel.Text = "Настройки программы сохранены";
			TemporaryBase.SearchFULLBegin();
			Close();
		}
	}

	private void ReAktor_Click(object sender, EventArgs e)
	{
		RedaktorAktov redaktorAktov = new RedaktorAktov(mainForm);
		redaktorAktov.Show();
		Close();
	}

	private void button1_Click(object sender, EventArgs e)
	{
	}

	private void Settings_Load(object sender, EventArgs e)
	{

			base.Height = 484;

		BarcodeHTextBox.Text = TemporaryBase.barcodeH.ToString();
		BarcodeWTextBox.Text = TemporaryBase.barcodeW.ToString();
		ComboboxMaker("settings/AdresSC.txt", ServiceAdressComboBox);
		ComboboxMaker("settings/masters.txt", MasterComboBox);
		if (TemporaryBase.AdressSCDefault.ToString() != "" && ServiceAdressComboBox.Items.Count > int.Parse(TemporaryBase.AdressSCDefault.ToString()))
		{
			ServiceAdressComboBox.SelectedIndex = int.Parse(TemporaryBase.AdressSCDefault.ToString());
		}
		if (TemporaryBase.MasterDefault.ToString() != "")
		{
			MasterComboBox.Text = TemporaryBase.MasterDefault;
		}
		if (INIF.KeyExists("CHECKBOX", "garantyDefault") && INIF.ReadINI("CHECKBOX", "garantyDefault") == "Checked")
		{
			GarantyDefaultCheckBox.Checked = true;
		}
		if (TemporaryBase.everyDayBackup != "Checked")
		{
			EveryDayBackupCheckBox.Checked = false;
		}
		else
		{
			EveryDayBackupCheckBox.Checked = true;
		}
		ToolTip toolTip = new ToolTip();
		toolTip.SetToolTip(GarantyDefaultCheckBox, "Если галочка не нажата, то по умолчанию гарантия будет ставиться 30 дней, если нажата, то без гарантии");
		toolTip.SetToolTip(ShowBackupsButton, "Бэкапы сохраняются в момент закрытия программы");
		if (TemporaryBase.BlistColor != "")
		{
			BlistButtonColor.BackColor = Color.FromArgb(int.Parse(TemporaryBase.BlistColor));
		}
		else
		{
			BlistButtonColor.BackColor = Color.Yellow;
		}
		if (TemporaryBase.Poloski)
		{
			PoloskiCheckBox.Checked = true;
		}
		else
		{
			PoloskiCheckBox.Checked = false;
		}
		if (TemporaryBase.openClientFolder)
		{
			openClientFilesCheckBox.Checked = true;
		}
		comboboxGroupsMaker(GroupDostupComboBox);
		comboboxGroupsMaker(UsersGroupDostupComboboxAdd);
		comboboxGroupsMaker(UsersComboBoxGroupEdit);
		comboboxUsersMaker(UserComboBox1);
		if (Directory.Exists(TemporaryBase.pathtoSaveBD))
		{
			folderBrowserDialog1.SelectedPath = TemporaryBase.pathtoSaveBD;
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

	private void label4_Click(object sender, EventArgs e)
	{
		Process.Start("https://vk.com/clubremontuchet");
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("https://vk.com/scrypto");
	}

	private void PasswordBox_MouseDown(object sender, MouseEventArgs e)
	{
	}

	private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
	{
	}

	private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
	{
	}

	private void PhoneExportButton_Click(object sender, EventArgs e)
	{
		Export export = new Export(mainForm);
		export.Show(mainForm);
	}

	private void Settings_FormClosed(object sender, FormClosedEventArgs e)
	{
		mainForm.setBool = false;
	}

	private void FallDownListSetButton_Click(object sender, EventArgs e)
	{
		Process.Start("explorer", "settings");
	}

	private void button1_Click_1(object sender, EventArgs e)
	{
		Process.Start("https://mywork.sms.ru");
	}


	private void ShowBackupsButton_Click(object sender, EventArgs e)
	{
		Process process = new Process();
		ProcessStartInfo processStartInfo = new ProcessStartInfo();
		string pathtoSaveBD = TemporaryBase.pathtoSaveBD;
		processStartInfo.CreateNoWindow = true;
		processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
		processStartInfo.FileName = "explorer";
		processStartInfo.Arguments = pathtoSaveBD;
		process.StartInfo = processStartInfo;
		process.Start();
	}

	private void BlistButtonColor_Click(object sender, EventArgs e)
	{
		if (colorDialogBlist.ShowDialog() == DialogResult.OK)
		{
			TemporaryBase.BlistColor = colorDialogBlist.Color.ToArgb().ToString();
			BlistButtonColor.BackColor = colorDialogBlist.Color;
			INIF.WriteINI(Registration.getHDD(), "BlistColor", colorDialogBlist.Color.ToArgb().ToString());
		}
	}

	private void PoloskiCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		INIF.WriteINI(TemporaryBase.UserKey, "Poloski", PoloskiCheckBox.CheckState.ToString());
		if (!PoloskiCheckBox.Checked)
		{
			TemporaryBase.Poloski = false;
		}
		else
		{
			TemporaryBase.Poloski = true;
		}
	}

	private void BarcodeWTextBox_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
		{
			e.Handled = true;
		}
	}

	private void BarcodeHTextBox_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
		{
			e.Handled = true;
		}
	}

	private void StolbButton_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < mainForm.MainListView.Columns.Count; i++)
		{
			if (mainForm.MainListView.Columns[i].Width < 3)
			{
				mainForm.MainListView.Columns[i].Width = 30;
			}
		}
	}

	private void openClientFilesCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		INIF.WriteINI(TemporaryBase.UserKey, "openClientFolder", openClientFilesCheckBox.CheckState.ToString());
		if (!openClientFilesCheckBox.Checked)
		{
			TemporaryBase.openClientFolder = false;
		}
		else
		{
			TemporaryBase.openClientFolder = true;
		}
	}

	private void AddGroupDostupButton_Click(object sender, EventArgs e)
	{
		if (GroupDostupNameTextBox.Text != "")
		{
			if (MessageBox.Show("Добавить новую группу " + GroupDostupNameTextBox.Text + "?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				dostupRulesMaker();
				mainForm.basa.GroupDostupBDWrite(GroupDostupNameTextBox.Text, delZapis, addZapis, saveZapis, graf, sms, stock, clients, stockAdd, stockDel, stockEdit, clientAdd, clientDel, clientConcat, settings, dates, editDates);
				comboboxGroupsMaker(GroupDostupComboBox);
				comboboxGroupsMaker(UsersGroupDostupComboboxAdd);
				comboboxGroupsMaker(UsersComboBoxGroupEdit);
				GroupDostupNameTextBox.Text = "";
			}
		}
		else
		{
			MessageBox.Show("Введите название группы");
		}
	}

	private void AllCheckBoxTrue()
	{
		delZapisCheckBox.Checked = true;
		addZapisCheckBox.Checked = true;
		saveZapisCheckBox.Checked = true;
		grafCheckBox.Checked = true;
		smsCheckBox.Checked = true;
		stockCheckBox.Checked = true;
		clientsCheckBox.Checked = true;
		stockAddCheckBox.Checked = true;
		stockDelCheckBox.Checked = true;
		stockEditCheckBox.Checked = true;
		clientAddCheckBox.Checked = true;
		clientDelCheckBox.Checked = true;
		clientConcatCheckBox.Checked = true;
		settingsCheckBox.Checked = true;
		datesCheckBox.Checked = true;
		editDatesCheckBox.Checked = true;
	}

	private void dostupRulesMaker()
	{
		delZapis = (delZapisCheckBox.Checked ? "1" : "0");
		addZapis = (addZapisCheckBox.Checked ? "1" : "0");
		saveZapis = (saveZapisCheckBox.Checked ? "1" : "0");
		graf = (grafCheckBox.Checked ? "1" : "0");
		sms = (smsCheckBox.Checked ? "1" : "0");
		stock = (stockCheckBox.Checked ? "1" : "0");
		clients = (clientsCheckBox.Checked ? "1" : "0");
		stockAdd = (stockAddCheckBox.Checked ? "1" : "0");
		stockDel = (stockDelCheckBox.Checked ? "1" : "0");
		stockEdit = (stockEditCheckBox.Checked ? "1" : "0");
		clientAdd = (clientAddCheckBox.Checked ? "1" : "0");
		clientDel = (clientDelCheckBox.Checked ? "1" : "0");
		clientConcat = (clientConcatCheckBox.Checked ? "1" : "0");
		settings = (settingsCheckBox.Checked ? "1" : "0");
		dates = (datesCheckBox.Checked ? "1" : "0");
		editDates = (editDatesCheckBox.Checked ? "1" : "0");
	}

	private void comboboxGroupsMaker(ComboBox cmbox)
	{
		cmbox.Items.Clear();
		AllCheckBoxTrue();
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

	private void GroupDostupComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		checkBoxGroupsMaker(GroupDostupComboBox.SelectedItem.ToString());
	}

	private void checkBoxGroupsMaker(string grName)
	{
		DataTable dataTable = mainForm.basa.GroupDostupBdRead(grName);
		if (dataTable.Rows.Count > 0)
		{
			int index = 0;
			delZapisCheckBox.Checked = ((dataTable.Rows[index].ItemArray[2].ToString() == "1") ? true : false);
			addZapisCheckBox.Checked = ((dataTable.Rows[index].ItemArray[3].ToString() == "1") ? true : false);
			saveZapisCheckBox.Checked = ((dataTable.Rows[index].ItemArray[4].ToString() == "1") ? true : false);
			grafCheckBox.Checked = ((dataTable.Rows[index].ItemArray[5].ToString() == "1") ? true : false);
			smsCheckBox.Checked = ((dataTable.Rows[index].ItemArray[6].ToString() == "1") ? true : false);
			stockCheckBox.Checked = ((dataTable.Rows[index].ItemArray[7].ToString() == "1") ? true : false);
			clientsCheckBox.Checked = ((dataTable.Rows[index].ItemArray[8].ToString() == "1") ? true : false);
			stockAddCheckBox.Checked = ((dataTable.Rows[index].ItemArray[9].ToString() == "1") ? true : false);
			stockDelCheckBox.Checked = ((dataTable.Rows[index].ItemArray[10].ToString() == "1") ? true : false);
			stockEditCheckBox.Checked = ((dataTable.Rows[index].ItemArray[11].ToString() == "1") ? true : false);
			clientAddCheckBox.Checked = ((dataTable.Rows[index].ItemArray[12].ToString() == "1") ? true : false);
			clientDelCheckBox.Checked = ((dataTable.Rows[index].ItemArray[13].ToString() == "1") ? true : false);
			clientConcatCheckBox.Checked = ((dataTable.Rows[index].ItemArray[14].ToString() == "1") ? true : false);
			settingsCheckBox.Checked = ((dataTable.Rows[index].ItemArray[15].ToString() == "1") ? true : false);
			datesCheckBox.Checked = ((dataTable.Rows[index].ItemArray[16].ToString() == "1") ? true : false);
			editDatesCheckBox.Checked = ((dataTable.Rows[index].ItemArray[17].ToString() == "1") ? true : false);
		}
	}

	private void SaveGroupDostupButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Применить права доступа к " + GroupDostupComboBox.SelectedItem.ToString() + "?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			dostupRulesMaker();
			mainForm.basa.GroupDostupBdEditAll(GroupDostupComboBox.SelectedItem.ToString(), delZapis, addZapis, saveZapis, graf, sms, stock, clients, stockAdd, stockDel, stockEdit, clientAdd, clientDel, clientConcat, settings, dates, editDates);
		}
	}

	private void DeleteGroupButton_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Удалить группу  " + GroupDostupComboBox.SelectedItem.ToString() + "?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
		{
			mainForm.basa.GroupDostupDelete(GroupDostupComboBox.SelectedItem.ToString());
			comboboxGroupsMaker(GroupDostupComboBox);
			comboboxGroupsMaker(UsersGroupDostupComboboxAdd);
			comboboxGroupsMaker(UsersComboBoxGroupEdit);
		}
	}

	private void UserDostupAddButton_Click(object sender, EventArgs e)
	{
		if (UserNameTextBox.Text != "" && UserPasswordTextBox.Text != "" && UsersGroupDostupComboboxAdd.Text != "")
		{
			if (MessageBox.Show("Добавить пользователя  " + UserNameTextBox.Text + " в группу " + UsersGroupDostupComboboxAdd.Text + "?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				mainForm.basa.UsersBDWrite(UsersGroupDostupComboboxAdd.Text, UserNameTextBox.Text, mainForm.basa.GroupDostupGetIdByGrNameBdRead(UsersGroupDostupComboboxAdd.Text), Registration.sha1(UserPasswordTextBox.Text));
				comboboxUsersMaker(UserComboBox1);
			}
		}
		else
		{
			MessageBox.Show("Одно из полей: ИМЯ, ПАРОЛЬ или ГРУППА ДОСТУПА пустое", "Заполните все поля");
		}
	}

	private void UserDeleteButton_Click(object sender, EventArgs e)
	{
		UsersComboBoxGroupEdit.Text = "";
		if (UserComboBox1.Text != "")
		{
			if (MessageBox.Show("Удалить пользователя: " + UserComboBox1.Text + "?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				mainForm.basa.UserDelete(UserComboBox1.Text);
				comboboxUsersMaker(UserComboBox1);
				comboboxGroupsMaker(UsersComboBoxGroupEdit);
			}
		}
		else
		{
			MessageBox.Show("Выберите пользователя, для удаления");
		}
	}

	private void UserChangePasswordButton_Click(object sender, EventArgs e)
	{
		if (UserComboBox1.Text != "" && UserChangePasswordTextBox.Text != "")
		{
			if (MessageBox.Show("Сменить пароль пользователю: " + UserComboBox1.Text + "?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				mainForm.basa.UsersBdEditPassword("user_pwd", Registration.sha1(UserChangePasswordTextBox.Text), UserComboBox1.Text);
			}
		}
		else
		{
			MessageBox.Show("Заполните поля новый пароль и выберите пользователя");
		}
	}

	private void ReselectUserRulesButton_Click(object sender, EventArgs e)
	{
		if (UserComboBox1.Text != "" && UsersComboBoxGroupEdit.Text != "")
		{
			if (MessageBox.Show("Сменить права пользователя : " + UserComboBox1.Text + " на " + UsersComboBoxGroupEdit.Text + "?", "Вы уверены?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				mainForm.basa.UserBdEditAll(UsersComboBoxGroupEdit.Text, UserComboBox1.Text, mainForm.basa.GroupDostupGetIdByGrNameBdRead(UsersComboBoxGroupEdit.Text));
			}
		}
		else
		{
			MessageBox.Show("Заполните поля имени пользователя и прав доступа");
		}
	}

	private void UserComboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		DataTable dataTable = mainForm.basa.UsersBdRead(UserComboBox1.Text);
		if (dataTable.Rows.Count > 0)
		{
			UsersComboBoxGroupEdit.Text = dataTable.Rows[0].ItemArray[1].ToString();
		}
	}

	private void ShowHistoryButton_Click(object sender, EventArgs e)
	{
		HistoryViewer historyViewer = new HistoryViewer(mainForm);
		historyViewer.Show(mainForm);
	}

	private void pathbutton1_Click(object sender, EventArgs e)
	{
		if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
		{
			TemporaryBase.pathtoSaveBD = folderBrowserDialog1.SelectedPath;
			INIF.WriteINI(TemporaryBase.UserKey, "backupPath", TemporaryBase.pathtoSaveBD);
			pathbutton1.Text = TemporaryBase.pathtoSaveBD;
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
			this.components = new System.ComponentModel.Container();
			this.SaveButton = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.label4 = new System.Windows.Forms.Label();
			this.colorDialogBlist = new System.Windows.Forms.ColorDialog();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.GroupDostupTab = new System.Windows.Forms.TabPage();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.DeleteGroupButton = new System.Windows.Forms.Button();
			this.SaveGroupDostupButton = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.GroupDostupComboBox = new System.Windows.Forms.ComboBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label22 = new System.Windows.Forms.Label();
			this.GroupDostupNameTextBox = new System.Windows.Forms.TextBox();
			this.AddGroupDostupButton = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.editDatesCheckBox = new System.Windows.Forms.CheckBox();
			this.datesCheckBox = new System.Windows.Forms.CheckBox();
			this.settingsCheckBox = new System.Windows.Forms.CheckBox();
			this.clientConcatCheckBox = new System.Windows.Forms.CheckBox();
			this.clientDelCheckBox = new System.Windows.Forms.CheckBox();
			this.clientAddCheckBox = new System.Windows.Forms.CheckBox();
			this.stockEditCheckBox = new System.Windows.Forms.CheckBox();
			this.stockDelCheckBox = new System.Windows.Forms.CheckBox();
			this.stockAddCheckBox = new System.Windows.Forms.CheckBox();
			this.clientsCheckBox = new System.Windows.Forms.CheckBox();
			this.stockCheckBox = new System.Windows.Forms.CheckBox();
			this.smsCheckBox = new System.Windows.Forms.CheckBox();
			this.grafCheckBox = new System.Windows.Forms.CheckBox();
			this.saveZapisCheckBox = new System.Windows.Forms.CheckBox();
			this.addZapisCheckBox = new System.Windows.Forms.CheckBox();
			this.delZapisCheckBox = new System.Windows.Forms.CheckBox();
			this.Dostup = new System.Windows.Forms.TabPage();
			this.ShowHistoryButton = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.UserChangePasswordTextBox = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.UserChangePasswordButton = new System.Windows.Forms.Button();
			this.UserDeleteButton = new System.Windows.Forms.Button();
			this.ReselectUserRulesButton = new System.Windows.Forms.Button();
			this.label25 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.UserComboBox1 = new System.Windows.Forms.ComboBox();
			this.UsersComboBoxGroupEdit = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.UserPasswordTextBox = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.UsersGroupDostupComboboxAdd = new System.Windows.Forms.ComboBox();
			this.UserDostupAddButton = new System.Windows.Forms.Button();
			this.label20 = new System.Windows.Forms.Label();
			this.UserNameTextBox = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.PhoneExportButton = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.BarcodeHTextBox = new System.Windows.Forms.TextBox();
			this.BarcodeWTextBox = new System.Windows.Forms.TextBox();
			this.ValutaTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ReAktor = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pathbutton1 = new System.Windows.Forms.Button();
			this.openClientFilesCheckBox = new System.Windows.Forms.CheckBox();
			this.StolbButton = new System.Windows.Forms.Button();
			this.PoloskiCheckBox = new System.Windows.Forms.CheckBox();
			this.BlistButtonColor = new System.Windows.Forms.Button();
			this.ShowBackupsButton = new System.Windows.Forms.Button();
			this.EveryDayBackupCheckBox = new System.Windows.Forms.CheckBox();
			this.MasterComboBox = new System.Windows.Forms.ComboBox();
			this.GarantyDefaultCheckBox = new System.Windows.Forms.CheckBox();
			this.label15 = new System.Windows.Forms.Label();
			this.NumericDiagnosikDays = new System.Windows.Forms.NumericUpDown();
			this.FallDownListSetButton = new System.Windows.Forms.Button();
			this.ColorDiagnosticCheckBox = new System.Windows.Forms.CheckBox();
			this.ColorButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ServiceAdressComboBox = new System.Windows.Forms.ComboBox();
			this.SetTab = new System.Windows.Forms.TabControl();
			this.GroupDostupTab.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.Dostup.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericDiagnosikDays)).BeginInit();
			this.SetTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(12, 417);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(233, 23);
			this.SaveButton.TabIndex = 0;
			this.SaveButton.Text = "Сохранить";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label4.Location = new System.Drawing.Point(12, 456);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(570, 81);
			this.label4.TabIndex = 9;
			this.label4.Text = "Это бесплатная версия программы, полную верисю можно купить у автора https://vk.c" +
    "om/scrypto\r\nПрочитать о возможностях программы можно в ее группе https://vk.com/" +
    "clubremontuchet";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// GroupDostupTab
			// 
			this.GroupDostupTab.Controls.Add(this.panel5);
			this.GroupDostupTab.Controls.Add(this.panel4);
			this.GroupDostupTab.Controls.Add(this.panel3);
			this.GroupDostupTab.Location = new System.Drawing.Point(4, 22);
			this.GroupDostupTab.Name = "GroupDostupTab";
			this.GroupDostupTab.Padding = new System.Windows.Forms.Padding(3);
			this.GroupDostupTab.Size = new System.Drawing.Size(566, 373);
			this.GroupDostupTab.TabIndex = 5;
			this.GroupDostupTab.Text = "Группы доступа";
			this.GroupDostupTab.UseVisualStyleBackColor = true;
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.label6);
			this.panel5.Controls.Add(this.DeleteGroupButton);
			this.panel5.Controls.Add(this.SaveGroupDostupButton);
			this.panel5.Controls.Add(this.label21);
			this.panel5.Controls.Add(this.GroupDostupComboBox);
			this.panel5.Location = new System.Drawing.Point(11, 54);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(544, 116);
			this.panel5.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.label6.Location = new System.Drawing.Point(9, 98);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(526, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "При смене прав доступа, нужно перезагрузить программу, чтобы настройки вступили в" +
    " силу";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// DeleteGroupButton
			// 
			this.DeleteGroupButton.Location = new System.Drawing.Point(9, 73);
			this.DeleteGroupButton.Name = "DeleteGroupButton";
			this.DeleteGroupButton.Size = new System.Drawing.Size(526, 23);
			this.DeleteGroupButton.TabIndex = 13;
			this.DeleteGroupButton.Text = "Удалить группу";
			this.DeleteGroupButton.UseVisualStyleBackColor = true;
			this.DeleteGroupButton.Click += new System.EventHandler(this.DeleteGroupButton_Click);
			// 
			// SaveGroupDostupButton
			// 
			this.SaveGroupDostupButton.Location = new System.Drawing.Point(9, 44);
			this.SaveGroupDostupButton.Name = "SaveGroupDostupButton";
			this.SaveGroupDostupButton.Size = new System.Drawing.Size(526, 23);
			this.SaveGroupDostupButton.TabIndex = 12;
			this.SaveGroupDostupButton.Text = "Сохранить права доступа";
			this.SaveGroupDostupButton.UseVisualStyleBackColor = true;
			this.SaveGroupDostupButton.Click += new System.EventHandler(this.SaveGroupDostupButton_Click);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label21.Location = new System.Drawing.Point(237, 20);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(112, 13);
			this.label21.TabIndex = 11;
			this.label21.Text = "Выберите группу:";
			// 
			// GroupDostupComboBox
			// 
			this.GroupDostupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.GroupDostupComboBox.FormattingEnabled = true;
			this.GroupDostupComboBox.Location = new System.Drawing.Point(362, 17);
			this.GroupDostupComboBox.Name = "GroupDostupComboBox";
			this.GroupDostupComboBox.Size = new System.Drawing.Size(173, 21);
			this.GroupDostupComboBox.TabIndex = 10;
			this.GroupDostupComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupDostupComboBox_SelectedIndexChanged);
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.label22);
			this.panel4.Controls.Add(this.GroupDostupNameTextBox);
			this.panel4.Controls.Add(this.AddGroupDostupButton);
			this.panel4.Location = new System.Drawing.Point(11, 6);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(544, 42);
			this.panel4.TabIndex = 11;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label22.Location = new System.Drawing.Point(18, 15);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(115, 13);
			this.label22.TabIndex = 9;
			this.label22.Text = "Название группы:";
			// 
			// GroupDostupNameTextBox
			// 
			this.GroupDostupNameTextBox.Location = new System.Drawing.Point(144, 12);
			this.GroupDostupNameTextBox.Name = "GroupDostupNameTextBox";
			this.GroupDostupNameTextBox.Size = new System.Drawing.Size(127, 20);
			this.GroupDostupNameTextBox.TabIndex = 8;
			// 
			// AddGroupDostupButton
			// 
			this.AddGroupDostupButton.Location = new System.Drawing.Point(277, 10);
			this.AddGroupDostupButton.Name = "AddGroupDostupButton";
			this.AddGroupDostupButton.Size = new System.Drawing.Size(258, 23);
			this.AddGroupDostupButton.TabIndex = 7;
			this.AddGroupDostupButton.Text = "Добавить группу";
			this.AddGroupDostupButton.UseVisualStyleBackColor = true;
			this.AddGroupDostupButton.Click += new System.EventHandler(this.AddGroupDostupButton_Click);
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.editDatesCheckBox);
			this.panel3.Controls.Add(this.datesCheckBox);
			this.panel3.Controls.Add(this.settingsCheckBox);
			this.panel3.Controls.Add(this.clientConcatCheckBox);
			this.panel3.Controls.Add(this.clientDelCheckBox);
			this.panel3.Controls.Add(this.clientAddCheckBox);
			this.panel3.Controls.Add(this.stockEditCheckBox);
			this.panel3.Controls.Add(this.stockDelCheckBox);
			this.panel3.Controls.Add(this.stockAddCheckBox);
			this.panel3.Controls.Add(this.clientsCheckBox);
			this.panel3.Controls.Add(this.stockCheckBox);
			this.panel3.Controls.Add(this.smsCheckBox);
			this.panel3.Controls.Add(this.grafCheckBox);
			this.panel3.Controls.Add(this.saveZapisCheckBox);
			this.panel3.Controls.Add(this.addZapisCheckBox);
			this.panel3.Controls.Add(this.delZapisCheckBox);
			this.panel3.Location = new System.Drawing.Point(11, 176);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(544, 191);
			this.panel3.TabIndex = 6;
			// 
			// editDatesCheckBox
			// 
			this.editDatesCheckBox.AutoSize = true;
			this.editDatesCheckBox.Checked = true;
			this.editDatesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.editDatesCheckBox.Location = new System.Drawing.Point(343, 170);
			this.editDatesCheckBox.Name = "editDatesCheckBox";
			this.editDatesCheckBox.Size = new System.Drawing.Size(175, 17);
			this.editDatesCheckBox.TabIndex = 20;
			this.editDatesCheckBox.Text = "Редактирование дат записей";
			this.editDatesCheckBox.UseVisualStyleBackColor = true;
			// 
			// datesCheckBox
			// 
			this.datesCheckBox.AutoSize = true;
			this.datesCheckBox.Checked = true;
			this.datesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.datesCheckBox.Location = new System.Drawing.Point(343, 147);
			this.datesCheckBox.Name = "datesCheckBox";
			this.datesCheckBox.Size = new System.Drawing.Size(141, 17);
			this.datesCheckBox.TabIndex = 19;
			this.datesCheckBox.Text = "Открытие дат записей";
			this.datesCheckBox.UseVisualStyleBackColor = true;
			// 
			// settingsCheckBox
			// 
			this.settingsCheckBox.AutoSize = true;
			this.settingsCheckBox.Checked = true;
			this.settingsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.settingsCheckBox.Location = new System.Drawing.Point(343, 124);
			this.settingsCheckBox.Name = "settingsCheckBox";
			this.settingsCheckBox.Size = new System.Drawing.Size(188, 17);
			this.settingsCheckBox.TabIndex = 18;
			this.settingsCheckBox.Text = "Открытие настроек программы";
			this.settingsCheckBox.UseVisualStyleBackColor = true;
			// 
			// clientConcatCheckBox
			// 
			this.clientConcatCheckBox.AutoSize = true;
			this.clientConcatCheckBox.Checked = true;
			this.clientConcatCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clientConcatCheckBox.Location = new System.Drawing.Point(343, 101);
			this.clientConcatCheckBox.Name = "clientConcatCheckBox";
			this.clientConcatCheckBox.Size = new System.Drawing.Size(145, 17);
			this.clientConcatCheckBox.TabIndex = 17;
			this.clientConcatCheckBox.Text = "Объединение клиентов";
			this.clientConcatCheckBox.UseVisualStyleBackColor = true;
			// 
			// clientDelCheckBox
			// 
			this.clientDelCheckBox.AutoSize = true;
			this.clientDelCheckBox.Checked = true;
			this.clientDelCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clientDelCheckBox.Location = new System.Drawing.Point(343, 78);
			this.clientDelCheckBox.Name = "clientDelCheckBox";
			this.clientDelCheckBox.Size = new System.Drawing.Size(126, 17);
			this.clientDelCheckBox.TabIndex = 16;
			this.clientDelCheckBox.Text = "Удаление клиентов";
			this.clientDelCheckBox.UseVisualStyleBackColor = true;
			// 
			// clientAddCheckBox
			// 
			this.clientAddCheckBox.AutoSize = true;
			this.clientAddCheckBox.Checked = true;
			this.clientAddCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clientAddCheckBox.Location = new System.Drawing.Point(343, 55);
			this.clientAddCheckBox.Name = "clientAddCheckBox";
			this.clientAddCheckBox.Size = new System.Drawing.Size(139, 17);
			this.clientAddCheckBox.TabIndex = 15;
			this.clientAddCheckBox.Text = "Добавление клиентов";
			this.clientAddCheckBox.UseVisualStyleBackColor = true;
			// 
			// stockEditCheckBox
			// 
			this.stockEditCheckBox.AutoSize = true;
			this.stockEditCheckBox.Checked = true;
			this.stockEditCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.stockEditCheckBox.Location = new System.Drawing.Point(343, 32);
			this.stockEditCheckBox.Name = "stockEditCheckBox";
			this.stockEditCheckBox.Size = new System.Drawing.Size(123, 17);
			this.stockEditCheckBox.TabIndex = 14;
			this.stockEditCheckBox.Text = "Изменение склада";
			this.stockEditCheckBox.UseVisualStyleBackColor = true;
			// 
			// stockDelCheckBox
			// 
			this.stockDelCheckBox.AutoSize = true;
			this.stockDelCheckBox.Checked = true;
			this.stockDelCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.stockDelCheckBox.Location = new System.Drawing.Point(343, 9);
			this.stockDelCheckBox.Name = "stockDelCheckBox";
			this.stockDelCheckBox.Size = new System.Drawing.Size(130, 17);
			this.stockDelCheckBox.TabIndex = 13;
			this.stockDelCheckBox.Text = "Удаление со склада";
			this.stockDelCheckBox.UseVisualStyleBackColor = true;
			// 
			// stockAddCheckBox
			// 
			this.stockAddCheckBox.AutoSize = true;
			this.stockAddCheckBox.Checked = true;
			this.stockAddCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.stockAddCheckBox.Location = new System.Drawing.Point(9, 170);
			this.stockAddCheckBox.Name = "stockAddCheckBox";
			this.stockAddCheckBox.Size = new System.Drawing.Size(131, 17);
			this.stockAddCheckBox.TabIndex = 12;
			this.stockAddCheckBox.Text = "Добавление в склад";
			this.stockAddCheckBox.UseVisualStyleBackColor = true;
			// 
			// clientsCheckBox
			// 
			this.clientsCheckBox.AutoSize = true;
			this.clientsCheckBox.Checked = true;
			this.clientsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clientsCheckBox.Location = new System.Drawing.Point(9, 147);
			this.clientsCheckBox.Name = "clientsCheckBox";
			this.clientsCheckBox.Size = new System.Drawing.Size(127, 17);
			this.clientsCheckBox.TabIndex = 11;
			this.clientsCheckBox.Text = "Просмотр клиентов";
			this.clientsCheckBox.UseVisualStyleBackColor = true;
			// 
			// stockCheckBox
			// 
			this.stockCheckBox.AutoSize = true;
			this.stockCheckBox.Checked = true;
			this.stockCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.stockCheckBox.Location = new System.Drawing.Point(9, 124);
			this.stockCheckBox.Name = "stockCheckBox";
			this.stockCheckBox.Size = new System.Drawing.Size(116, 17);
			this.stockCheckBox.TabIndex = 10;
			this.stockCheckBox.Text = "Просмотр склада";
			this.stockCheckBox.UseVisualStyleBackColor = true;
			// 
			// smsCheckBox
			// 
			this.smsCheckBox.AutoSize = true;
			this.smsCheckBox.Checked = true;
			this.smsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.smsCheckBox.Location = new System.Drawing.Point(9, 101);
			this.smsCheckBox.Name = "smsCheckBox";
			this.smsCheckBox.Size = new System.Drawing.Size(154, 17);
			this.smsCheckBox.TabIndex = 9;
			this.smsCheckBox.Text = "Настройка/отправка sms";
			this.smsCheckBox.UseVisualStyleBackColor = true;
			// 
			// grafCheckBox
			// 
			this.grafCheckBox.AutoSize = true;
			this.grafCheckBox.Checked = true;
			this.grafCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.grafCheckBox.Location = new System.Drawing.Point(9, 78);
			this.grafCheckBox.Name = "grafCheckBox";
			this.grafCheckBox.Size = new System.Drawing.Size(180, 17);
			this.grafCheckBox.TabIndex = 8;
			this.grafCheckBox.Text = "Просмотр графиков и отчётов";
			this.grafCheckBox.UseVisualStyleBackColor = true;
			// 
			// saveZapisCheckBox
			// 
			this.saveZapisCheckBox.AutoSize = true;
			this.saveZapisCheckBox.Checked = true;
			this.saveZapisCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.saveZapisCheckBox.Location = new System.Drawing.Point(9, 55);
			this.saveZapisCheckBox.Name = "saveZapisCheckBox";
			this.saveZapisCheckBox.Size = new System.Drawing.Size(131, 17);
			this.saveZapisCheckBox.TabIndex = 7;
			this.saveZapisCheckBox.Text = "Сохранение записей";
			this.saveZapisCheckBox.UseVisualStyleBackColor = true;
			// 
			// addZapisCheckBox
			// 
			this.addZapisCheckBox.AutoSize = true;
			this.addZapisCheckBox.Checked = true;
			this.addZapisCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.addZapisCheckBox.Location = new System.Drawing.Point(9, 32);
			this.addZapisCheckBox.Name = "addZapisCheckBox";
			this.addZapisCheckBox.Size = new System.Drawing.Size(134, 17);
			this.addZapisCheckBox.TabIndex = 6;
			this.addZapisCheckBox.Text = "Добавление записей";
			this.addZapisCheckBox.UseVisualStyleBackColor = true;
			// 
			// delZapisCheckBox
			// 
			this.delZapisCheckBox.AutoSize = true;
			this.delZapisCheckBox.Checked = true;
			this.delZapisCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.delZapisCheckBox.Location = new System.Drawing.Point(9, 9);
			this.delZapisCheckBox.Name = "delZapisCheckBox";
			this.delZapisCheckBox.Size = new System.Drawing.Size(124, 17);
			this.delZapisCheckBox.TabIndex = 5;
			this.delZapisCheckBox.Text = "Удаление записей ";
			this.delZapisCheckBox.UseVisualStyleBackColor = true;
			// 
			// Dostup
			// 
			this.Dostup.Controls.Add(this.ShowHistoryButton);
			this.Dostup.Controls.Add(this.panel2);
			this.Dostup.Controls.Add(this.panel1);
			this.Dostup.Location = new System.Drawing.Point(4, 22);
			this.Dostup.Name = "Dostup";
			this.Dostup.Padding = new System.Windows.Forms.Padding(3);
			this.Dostup.Size = new System.Drawing.Size(566, 373);
			this.Dostup.TabIndex = 4;
			this.Dostup.Text = "Права доступа пользователей";
			this.Dostup.ToolTipText = "Настройка прав доступа, и групп пользователей";
			this.Dostup.UseVisualStyleBackColor = true;
			// 
			// ShowHistoryButton
			// 
			this.ShowHistoryButton.Location = new System.Drawing.Point(18, 190);
			this.ShowHistoryButton.Name = "ShowHistoryButton";
			this.ShowHistoryButton.Size = new System.Drawing.Size(533, 23);
			this.ShowHistoryButton.TabIndex = 7;
			this.ShowHistoryButton.Text = "Показать историю изменений";
			this.ShowHistoryButton.UseVisualStyleBackColor = true;
			this.ShowHistoryButton.Click += new System.EventHandler(this.ShowHistoryButton_Click);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.UserChangePasswordTextBox);
			this.panel2.Controls.Add(this.label26);
			this.panel2.Controls.Add(this.UserChangePasswordButton);
			this.panel2.Controls.Add(this.UserDeleteButton);
			this.panel2.Controls.Add(this.ReselectUserRulesButton);
			this.panel2.Controls.Add(this.label25);
			this.panel2.Controls.Add(this.label24);
			this.panel2.Controls.Add(this.UserComboBox1);
			this.panel2.Controls.Add(this.UsersComboBoxGroupEdit);
			this.panel2.Location = new System.Drawing.Point(11, 77);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(544, 96);
			this.panel2.TabIndex = 6;
			// 
			// UserChangePasswordTextBox
			// 
			this.UserChangePasswordTextBox.Location = new System.Drawing.Point(123, 64);
			this.UserChangePasswordTextBox.Name = "UserChangePasswordTextBox";
			this.UserChangePasswordTextBox.Size = new System.Drawing.Size(162, 20);
			this.UserChangePasswordTextBox.TabIndex = 14;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label26.Location = new System.Drawing.Point(4, 67);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(96, 13);
			this.label26.TabIndex = 15;
			this.label26.Text = "Новый пароль:";
			// 
			// UserChangePasswordButton
			// 
			this.UserChangePasswordButton.Location = new System.Drawing.Point(291, 63);
			this.UserChangePasswordButton.Name = "UserChangePasswordButton";
			this.UserChangePasswordButton.Size = new System.Drawing.Size(248, 22);
			this.UserChangePasswordButton.TabIndex = 18;
			this.UserChangePasswordButton.Text = "Сменить пароль";
			this.UserChangePasswordButton.UseVisualStyleBackColor = true;
			this.UserChangePasswordButton.Click += new System.EventHandler(this.UserChangePasswordButton_Click);
			// 
			// UserDeleteButton
			// 
			this.UserDeleteButton.Location = new System.Drawing.Point(291, 35);
			this.UserDeleteButton.Name = "UserDeleteButton";
			this.UserDeleteButton.Size = new System.Drawing.Size(248, 23);
			this.UserDeleteButton.TabIndex = 17;
			this.UserDeleteButton.Text = "Удалить пользователя";
			this.UserDeleteButton.UseVisualStyleBackColor = true;
			this.UserDeleteButton.Click += new System.EventHandler(this.UserDeleteButton_Click);
			// 
			// ReselectUserRulesButton
			// 
			this.ReselectUserRulesButton.Location = new System.Drawing.Point(291, 8);
			this.ReselectUserRulesButton.Name = "ReselectUserRulesButton";
			this.ReselectUserRulesButton.Size = new System.Drawing.Size(248, 23);
			this.ReselectUserRulesButton.TabIndex = 16;
			this.ReselectUserRulesButton.Text = "Переназначить права доступа";
			this.ReselectUserRulesButton.UseVisualStyleBackColor = true;
			this.ReselectUserRulesButton.Click += new System.EventHandler(this.ReselectUserRulesButton_Click);
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label25.Location = new System.Drawing.Point(4, 39);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(113, 13);
			this.label25.TabIndex = 15;
			this.label25.Text = "Уровень доступа:";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label24.Location = new System.Drawing.Point(4, 12);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 13);
			this.label24.TabIndex = 14;
			this.label24.Text = "Пользователь: ";
			// 
			// UserComboBox1
			// 
			this.UserComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.UserComboBox1.FormattingEnabled = true;
			this.UserComboBox1.Location = new System.Drawing.Point(123, 9);
			this.UserComboBox1.Name = "UserComboBox1";
			this.UserComboBox1.Size = new System.Drawing.Size(162, 21);
			this.UserComboBox1.TabIndex = 13;
			this.UserComboBox1.SelectedIndexChanged += new System.EventHandler(this.UserComboBox1_SelectedIndexChanged);
			// 
			// UsersComboBoxGroupEdit
			// 
			this.UsersComboBoxGroupEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.UsersComboBoxGroupEdit.FormattingEnabled = true;
			this.UsersComboBoxGroupEdit.Location = new System.Drawing.Point(123, 36);
			this.UsersComboBoxGroupEdit.Name = "UsersComboBoxGroupEdit";
			this.UsersComboBoxGroupEdit.Size = new System.Drawing.Size(162, 21);
			this.UsersComboBoxGroupEdit.TabIndex = 12;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.UserPasswordTextBox);
			this.panel1.Controls.Add(this.label23);
			this.panel1.Controls.Add(this.UsersGroupDostupComboboxAdd);
			this.panel1.Controls.Add(this.UserDostupAddButton);
			this.panel1.Controls.Add(this.label20);
			this.panel1.Controls.Add(this.UserNameTextBox);
			this.panel1.Controls.Add(this.label19);
			this.panel1.Location = new System.Drawing.Point(11, 9);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(544, 62);
			this.panel1.TabIndex = 5;
			// 
			// UserPasswordTextBox
			// 
			this.UserPasswordTextBox.Location = new System.Drawing.Point(129, 35);
			this.UserPasswordTextBox.Name = "UserPasswordTextBox";
			this.UserPasswordTextBox.Size = new System.Drawing.Size(127, 20);
			this.UserPasswordTextBox.TabIndex = 12;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label23.Location = new System.Drawing.Point(3, 38);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(55, 13);
			this.label23.TabIndex = 13;
			this.label23.Text = "Пароль:";
			// 
			// UsersGroupDostupComboboxAdd
			// 
			this.UsersGroupDostupComboboxAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.UsersGroupDostupComboboxAdd.FormattingEnabled = true;
			this.UsersGroupDostupComboboxAdd.Location = new System.Drawing.Point(377, 9);
			this.UsersGroupDostupComboboxAdd.Name = "UsersGroupDostupComboboxAdd";
			this.UsersGroupDostupComboboxAdd.Size = new System.Drawing.Size(162, 21);
			this.UsersGroupDostupComboboxAdd.TabIndex = 11;
			// 
			// UserDostupAddButton
			// 
			this.UserDostupAddButton.Location = new System.Drawing.Point(269, 34);
			this.UserDostupAddButton.Name = "UserDostupAddButton";
			this.UserDostupAddButton.Size = new System.Drawing.Size(271, 22);
			this.UserDostupAddButton.TabIndex = 0;
			this.UserDostupAddButton.Text = "Добавить пользователя";
			this.UserDostupAddButton.UseVisualStyleBackColor = true;
			this.UserDostupAddButton.Click += new System.EventHandler(this.UserDostupAddButton_Click);
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label20.Location = new System.Drawing.Point(265, 12);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(113, 13);
			this.label20.TabIndex = 4;
			this.label20.Text = "Уровень доступа:";
			// 
			// UserNameTextBox
			// 
			this.UserNameTextBox.Location = new System.Drawing.Point(129, 9);
			this.UserNameTextBox.Name = "UserNameTextBox";
			this.UserNameTextBox.Size = new System.Drawing.Size(127, 20);
			this.UserNameTextBox.TabIndex = 1;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label19.Location = new System.Drawing.Point(3, 12);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(123, 13);
			this.label19.TabIndex = 2;
			this.label19.Text = "Имя пользователя:";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.PhoneExportButton);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(566, 373);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Импорт/Экспорт";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// PhoneExportButton
			// 
			this.PhoneExportButton.Location = new System.Drawing.Point(44, 12);
			this.PhoneExportButton.Name = "PhoneExportButton";
			this.PhoneExportButton.Size = new System.Drawing.Size(484, 23);
			this.PhoneExportButton.TabIndex = 17;
			this.PhoneExportButton.Text = "Настройка экспорта телефонных номеров";
			this.PhoneExportButton.UseVisualStyleBackColor = true;
			this.PhoneExportButton.Click += new System.EventHandler(this.PhoneExportButton_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.Controls.Add(this.label17);
			this.tabPage2.Controls.Add(this.label16);
			this.tabPage2.Controls.Add(this.BarcodeHTextBox);
			this.tabPage2.Controls.Add(this.BarcodeWTextBox);
			this.tabPage2.Controls.Add(this.ValutaTextBox);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.ReAktor);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(566, 373);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Акты";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(55, 179);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(48, 13);
			this.label18.TabIndex = 13;
			this.label18.Text = "Высота:";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(55, 147);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(49, 13);
			this.label17.TabIndex = 12;
			this.label17.Text = "Ширина:";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(41, 115);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(146, 13);
			this.label16.TabIndex = 11;
			this.label16.Text = "Размер штрихкода в актах:";
			// 
			// BarcodeHTextBox
			// 
			this.BarcodeHTextBox.Location = new System.Drawing.Point(109, 178);
			this.BarcodeHTextBox.Name = "BarcodeHTextBox";
			this.BarcodeHTextBox.Size = new System.Drawing.Size(100, 20);
			this.BarcodeHTextBox.TabIndex = 10;
			this.BarcodeHTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BarcodeHTextBox_KeyPress);
			// 
			// BarcodeWTextBox
			// 
			this.BarcodeWTextBox.Location = new System.Drawing.Point(109, 144);
			this.BarcodeWTextBox.Name = "BarcodeWTextBox";
			this.BarcodeWTextBox.Size = new System.Drawing.Size(100, 20);
			this.BarcodeWTextBox.TabIndex = 9;
			this.BarcodeWTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BarcodeWTextBox_KeyPress);
			// 
			// ValutaTextBox
			// 
			this.ValutaTextBox.Location = new System.Drawing.Point(279, 16);
			this.ValutaTextBox.Name = "ValutaTextBox";
			this.ValutaTextBox.Size = new System.Drawing.Size(250, 20);
			this.ValutaTextBox.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(41, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(232, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Название валюты в актах выдачи и приёма:";
			// 
			// ReAktor
			// 
			this.ReAktor.Location = new System.Drawing.Point(44, 69);
			this.ReAktor.Name = "ReAktor";
			this.ReAktor.Size = new System.Drawing.Size(485, 23);
			this.ReAktor.TabIndex = 6;
			this.ReAktor.Text = "Редактор Актов";
			this.ReAktor.UseVisualStyleBackColor = true;
			this.ReAktor.Click += new System.EventHandler(this.ReAktor_Click);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.pathbutton1);
			this.tabPage1.Controls.Add(this.openClientFilesCheckBox);
			this.tabPage1.Controls.Add(this.StolbButton);
			this.tabPage1.Controls.Add(this.PoloskiCheckBox);
			this.tabPage1.Controls.Add(this.BlistButtonColor);
			this.tabPage1.Controls.Add(this.ShowBackupsButton);
			this.tabPage1.Controls.Add(this.EveryDayBackupCheckBox);
			this.tabPage1.Controls.Add(this.MasterComboBox);
			this.tabPage1.Controls.Add(this.GarantyDefaultCheckBox);
			this.tabPage1.Controls.Add(this.label15);
			this.tabPage1.Controls.Add(this.NumericDiagnosikDays);
			this.tabPage1.Controls.Add(this.FallDownListSetButton);
			this.tabPage1.Controls.Add(this.ColorDiagnosticCheckBox);
			this.tabPage1.Controls.Add(this.ColorButton);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.ServiceAdressComboBox);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(566, 373);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Основные";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// pathbutton1
			// 
			this.pathbutton1.Location = new System.Drawing.Point(447, 121);
			this.pathbutton1.Name = "pathbutton1";
			this.pathbutton1.Size = new System.Drawing.Size(94, 21);
			this.pathbutton1.TabIndex = 28;
			this.pathbutton1.Text = "Путь";
			this.pathbutton1.UseVisualStyleBackColor = true;
			this.pathbutton1.Click += new System.EventHandler(this.pathbutton1_Click);
			// 
			// openClientFilesCheckBox
			// 
			this.openClientFilesCheckBox.AutoSize = true;
			this.openClientFilesCheckBox.Location = new System.Drawing.Point(10, 169);
			this.openClientFilesCheckBox.Name = "openClientFilesCheckBox";
			this.openClientFilesCheckBox.Size = new System.Drawing.Size(449, 17);
			this.openClientFilesCheckBox.TabIndex = 27;
			this.openClientFilesCheckBox.Text = "Открывать папку с файлами клиента автомтически, при добавлении новой записи";
			this.openClientFilesCheckBox.UseVisualStyleBackColor = true;
			this.openClientFilesCheckBox.CheckedChanged += new System.EventHandler(this.openClientFilesCheckBox_CheckedChanged);
			// 
			// StolbButton
			// 
			this.StolbButton.Location = new System.Drawing.Point(10, 247);
			this.StolbButton.Name = "StolbButton";
			this.StolbButton.Size = new System.Drawing.Size(531, 23);
			this.StolbButton.TabIndex = 26;
			this.StolbButton.Text = "Показать свернутые столбцы в главном окне";
			this.StolbButton.UseVisualStyleBackColor = true;
			this.StolbButton.Click += new System.EventHandler(this.StolbButton_Click);
			// 
			// PoloskiCheckBox
			// 
			this.PoloskiCheckBox.AutoSize = true;
			this.PoloskiCheckBox.Checked = true;
			this.PoloskiCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.PoloskiCheckBox.Location = new System.Drawing.Point(10, 147);
			this.PoloskiCheckBox.Name = "PoloskiCheckBox";
			this.PoloskiCheckBox.Size = new System.Drawing.Size(208, 17);
			this.PoloskiCheckBox.TabIndex = 25;
			this.PoloskiCheckBox.Text = "Черезстрочное выделение записей";
			this.PoloskiCheckBox.UseVisualStyleBackColor = true;
			this.PoloskiCheckBox.CheckedChanged += new System.EventHandler(this.PoloskiCheckBox_CheckedChanged);
			// 
			// BlistButtonColor
			// 
			this.BlistButtonColor.Location = new System.Drawing.Point(10, 189);
			this.BlistButtonColor.Name = "BlistButtonColor";
			this.BlistButtonColor.Size = new System.Drawing.Size(531, 23);
			this.BlistButtonColor.TabIndex = 24;
			this.BlistButtonColor.Text = "Цвет проблемных клиентов";
			this.BlistButtonColor.UseVisualStyleBackColor = true;
			this.BlistButtonColor.Click += new System.EventHandler(this.BlistButtonColor_Click);
			// 
			// ShowBackupsButton
			// 
			this.ShowBackupsButton.Location = new System.Drawing.Point(300, 121);
			this.ShowBackupsButton.Name = "ShowBackupsButton";
			this.ShowBackupsButton.Size = new System.Drawing.Size(141, 21);
			this.ShowBackupsButton.TabIndex = 21;
			this.ShowBackupsButton.Text = "Резервные копии";
			this.ShowBackupsButton.UseVisualStyleBackColor = true;
			this.ShowBackupsButton.Click += new System.EventHandler(this.ShowBackupsButton_Click);
			// 
			// EveryDayBackupCheckBox
			// 
			this.EveryDayBackupCheckBox.AutoSize = true;
			this.EveryDayBackupCheckBox.Location = new System.Drawing.Point(10, 124);
			this.EveryDayBackupCheckBox.Name = "EveryDayBackupCheckBox";
			this.EveryDayBackupCheckBox.Size = new System.Drawing.Size(284, 17);
			this.EveryDayBackupCheckBox.TabIndex = 23;
			this.EveryDayBackupCheckBox.Text = "Ежедневное резервное копирование базы данных";
			this.EveryDayBackupCheckBox.UseVisualStyleBackColor = true;
			// 
			// MasterComboBox
			// 
			this.MasterComboBox.FormattingEnabled = true;
			this.MasterComboBox.Location = new System.Drawing.Point(275, 74);
			this.MasterComboBox.Name = "MasterComboBox";
			this.MasterComboBox.Size = new System.Drawing.Size(250, 21);
			this.MasterComboBox.TabIndex = 22;
			// 
			// GarantyDefaultCheckBox
			// 
			this.GarantyDefaultCheckBox.AutoSize = true;
			this.GarantyDefaultCheckBox.Location = new System.Drawing.Point(10, 101);
			this.GarantyDefaultCheckBox.Name = "GarantyDefaultCheckBox";
			this.GarantyDefaultCheckBox.Size = new System.Drawing.Size(332, 17);
			this.GarantyDefaultCheckBox.TabIndex = 21;
			this.GarantyDefaultCheckBox.Text = "Гарантия по умолчанию: Без гарантии/30 дней (Акт выдачи)";
			this.GarantyDefaultCheckBox.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(147, 77);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(122, 13);
			this.label15.TabIndex = 20;
			this.label15.Text = "Мастер по умолчанию:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NumericDiagnosikDays
			// 
			this.NumericDiagnosikDays.Location = new System.Drawing.Point(446, 15);
			this.NumericDiagnosikDays.Name = "NumericDiagnosikDays";
			this.NumericDiagnosikDays.Size = new System.Drawing.Size(35, 20);
			this.NumericDiagnosikDays.TabIndex = 4;
			// 
			// FallDownListSetButton
			// 
			this.FallDownListSetButton.Location = new System.Drawing.Point(10, 218);
			this.FallDownListSetButton.Name = "FallDownListSetButton";
			this.FallDownListSetButton.Size = new System.Drawing.Size(531, 23);
			this.FallDownListSetButton.TabIndex = 18;
			this.FallDownListSetButton.Text = "Настройка выпадающих списков";
			this.FallDownListSetButton.UseVisualStyleBackColor = true;
			this.FallDownListSetButton.Click += new System.EventHandler(this.FallDownListSetButton_Click);
			// 
			// ColorDiagnosticCheckBox
			// 
			this.ColorDiagnosticCheckBox.AutoSize = true;
			this.ColorDiagnosticCheckBox.Location = new System.Drawing.Point(17, 18);
			this.ColorDiagnosticCheckBox.Name = "ColorDiagnosticCheckBox";
			this.ColorDiagnosticCheckBox.Size = new System.Drawing.Size(78, 17);
			this.ColorDiagnosticCheckBox.TabIndex = 1;
			this.ColorDiagnosticCheckBox.Text = "Отмечать ";
			this.ColorDiagnosticCheckBox.UseVisualStyleBackColor = true;
			// 
			// ColorButton
			// 
			this.ColorButton.Location = new System.Drawing.Point(101, 14);
			this.ColorButton.Name = "ColorButton";
			this.ColorButton.Size = new System.Drawing.Size(75, 23);
			this.ColorButton.TabIndex = 2;
			this.ColorButton.Text = "цветом";
			this.ColorButton.UseVisualStyleBackColor = true;
			this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(182, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(267, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "устройства, диагносика которых проходит дольше ";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(59, 50);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(210, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Адрес сервисного ценра по умолчанию:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(487, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "дней";
			// 
			// ServiceAdressComboBox
			// 
			this.ServiceAdressComboBox.FormattingEnabled = true;
			this.ServiceAdressComboBox.Items.AddRange(new object[] {
            ""});
			this.ServiceAdressComboBox.Location = new System.Drawing.Point(275, 47);
			this.ServiceAdressComboBox.Name = "ServiceAdressComboBox";
			this.ServiceAdressComboBox.Size = new System.Drawing.Size(250, 21);
			this.ServiceAdressComboBox.TabIndex = 15;
			// 
			// SetTab
			// 
			this.SetTab.Controls.Add(this.tabPage1);
			this.SetTab.Controls.Add(this.tabPage2);
			this.SetTab.Controls.Add(this.tabPage3);
			this.SetTab.Controls.Add(this.Dostup);
			this.SetTab.Controls.Add(this.GroupDostupTab);
			this.SetTab.Location = new System.Drawing.Point(12, 12);
			this.SetTab.Name = "SetTab";
			this.SetTab.SelectedIndex = 0;
			this.SetTab.Size = new System.Drawing.Size(574, 399);
			this.SetTab.TabIndex = 20;
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(593, 442);
			this.Controls.Add(this.SetTab);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.SaveButton);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Settings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Настройки";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
			this.Load += new System.EventHandler(this.Settings_Load);
			this.GroupDostupTab.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.Dostup.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericDiagnosikDays)).EndInit();
			this.SetTab.ResumeLayout(false);
			this.ResumeLayout(false);

	}
}
