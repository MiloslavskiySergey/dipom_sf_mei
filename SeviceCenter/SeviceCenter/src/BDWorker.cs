// BDWorker
using SeviceCenter.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class BDWorker
{

	private MainForm mainForm;

	public string dbFileName = "baza.sqlite";

	public BDWorker(MainForm fm)
	{
		mainForm = fm;
	}

	public void CreateBd()
	{
		DbCommand m_sqlCmd = DbContext.Instance.Command();

		//if (!File.Exists(dbFileName))
		//{
		//	BaseLineNumber baseLineNumber = new BaseLineNumber(mainForm);
		//	baseLineNumber.Show();
		//	SQLiteConnection.CreateFile(dbFileName);
		//}
		try
		{
			m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Catalog (id INTEGER PRIMARY KEY AUTO_INCREMENT, Data_priema TEXT, Data_vidachi TEXT, Data_predoplaty TEXT, surname TEXT,phone TEXT, AboutUs TEXT, WhatRemont TEXT, brand TEXT, model TEXT, SerialNumber TEXT, sostoyanie TEXT, komplektonst TEXT, polomka TEXT,kommentarij  TEXT, predvaritelnaya_stoimost TEXT, Predoplata TEXT, Zatrati TEXT, okonchatelnaya_stoimost_remonta TEXT,Skidka TEXT, Status_remonta TEXT,master TEXT, vipolnenie_raboti TEXT,Garanty TEXT, wait_zakaz TEXT,Adress TEXT, Image_key TEXT, AdressSC TEXT, DeviceColour TEXT, ClientId TEXT, Barcode TEXT)";
			m_sqlCmd.ExecuteNonQuery();
			SovmestimostBDTester();
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу установить соединение с базой данных " + ex.ToString() + Environment.NewLine);
		}
	}

	public void CreateBd(string incr_auto_number)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();
		if (incr_auto_number != "1" || incr_auto_number != "0" || incr_auto_number != "")
		{
			try
			{



				m_sqlCmd.CommandText = $"UPDATE sqlite_sequence SET seq = {incr_auto_number} WHERE name = 'Catalog'";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу установить соединение с базой данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	private void SovmestimostBDTester()
	{
		DataTable dataTable = new DataTable();

		var m_sqlCmd = DbContext.Instance.Command();

		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		try
		{
			CreateStock();
			CreateStockMap();
			HistoryBDTable_Create();
			GroupDostupTable_Create();
			string commandText = "DESCRIBE Catalog";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			mainForm.basa.ClientsMapTable_Create();
			if (dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows.Count < 27)
				{
					m_sqlCmd.CommandText = "ALTER TABLE Catalog ADD COLUMN Adress TEXT";
					m_sqlCmd.ExecuteNonQuery();
					m_sqlCmd.CommandText = "ALTER TABLE Catalog ADD COLUMN Image_key TEXT";
					m_sqlCmd.ExecuteNonQuery();
				}
				if (dataTable.Rows.Count < 29)
				{
					m_sqlCmd.CommandText = "ALTER TABLE Catalog ADD COLUMN AdressSC TEXT";
					m_sqlCmd.ExecuteNonQuery();
					m_sqlCmd.CommandText = "ALTER TABLE Catalog ADD COLUMN DeviceColour TEXT";
					m_sqlCmd.ExecuteNonQuery();
					mainForm.basa.BdNoNull("Image_key");
					mainForm.basa.BdNoNull("Adress");
					mainForm.basa.BdNoNull("wait_zakaz");
					mainForm.basa.BdNoNull("AdressSC");
					mainForm.basa.BdNoNull("DeviceColour");
				}
				if (dataTable.Rows.Count < 30)
				{
					if (!Directory.Exists("settings/backup"))
					{
						Directory.CreateDirectory("settings/backup");
					}
					if (File.Exists(dbFileName))
					{
						File.Copy(dbFileName, "settings/backup/baza.sqlite_backup" + DateTime.Now.ToString("dd-MM-yyyy HH-mm"));
					}
					mainForm.basa.CreateStock();
					mainForm.basa.CreateStockMap();
					
					m_sqlCmd.CommandText = "ALTER TABLE Catalog ADD COLUMN ClientId INTEGER";
					m_sqlCmd.ExecuteNonQuery();
					DataTable dataTable2 = mainForm.basa.BdReadAll();
					List<VirtualClient> list = new List<VirtualClient>();
					List<VirtualClient> list2 = new List<VirtualClient>();
					if (dataTable2.Rows.Count > 0)
					{
						for (int i = 0; i < dataTable2.Rows.Count; i++)
						{
							list.Add(new VirtualClient(dataTable2.Rows[i].ItemArray[0].ToString(), dataTable2.Rows[i].ItemArray[1].ToString(), dataTable2.Rows[i].ItemArray[2].ToString(), dataTable2.Rows[i].ItemArray[3].ToString(), dataTable2.Rows[i].ItemArray[4].ToString(), dataTable2.Rows[i].ItemArray[5].ToString(), dataTable2.Rows[i].ItemArray[6].ToString(), dataTable2.Rows[i].ItemArray[7].ToString(), dataTable2.Rows[i].ItemArray[8].ToString(), dataTable2.Rows[i].ItemArray[9].ToString(), dataTable2.Rows[i].ItemArray[10].ToString(), dataTable2.Rows[i].ItemArray[11].ToString(), dataTable2.Rows[i].ItemArray[12].ToString(), dataTable2.Rows[i].ItemArray[13].ToString(), dataTable2.Rows[i].ItemArray[14].ToString(), dataTable2.Rows[i].ItemArray[15].ToString(), dataTable2.Rows[i].ItemArray[16].ToString(), dataTable2.Rows[i].ItemArray[17].ToString(), dataTable2.Rows[i].ItemArray[18].ToString(), dataTable2.Rows[i].ItemArray[19].ToString(), dataTable2.Rows[i].ItemArray[20].ToString(), dataTable2.Rows[i].ItemArray[21].ToString(), dataTable2.Rows[i].ItemArray[22].ToString(), dataTable2.Rows[i].ItemArray[23].ToString(), dataTable2.Rows[i].ItemArray[24].ToString(), dataTable2.Rows[i].ItemArray[25].ToString(), dataTable2.Rows[i].ItemArray[26].ToString(), true, dataTable2.Rows[i].ItemArray[27].ToString(), dataTable2.Rows[i].ItemArray[28].ToString()));
						}
					}
					for (int j = 0; j < list.Count; j++)
					{
						bool flag = false;
						for (int k = 0; k < list2.Count; k++)
						{
							if (list[j].Surname == list2[k].Surname && list[j].Phone == list2[k].Phone && list[j].Id != list2[k].Id)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							list2.Add(list[j]);
						}
					}
					
					//DbContext.Instance.Command("begin").ExecuteNonQuery();

					foreach (VirtualClient item in list)
					{
						for (int l = 0; l < list2.Count; l++)
						{
							if (item.Surname == list2[l].Surname && item.Phone == list2[l].Phone)
							{
								if (DbContext.Instance.State != ConnectionState.Open)
								{
									MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
									return;
								}
								try
								{
									m_sqlCmd.CommandText = "UPDATE Catalog SET ClientId ='" + (l + 1).ToString() + "' WHERE ID = " + item.Id;
									m_sqlCmd.ExecuteNonQuery();
								}
								catch (Exception ex)
								{
									MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
								}
							}
						}
					}

					//DbContext.Instance.Command("end").ExecuteNonQuery();

					try
					{
						if (DbContext.Instance.State != ConnectionState.Open)
						{
							MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
							return;
						}
						if (list2.Count == 1)
						{
							foreach (VirtualClient item2 in list2)
							{
								m_sqlCmd.CommandText = "INSERT INTO ClientsMap (FIO,Phone,Adress,Primechanie,Blist,Date,aboutUs) values ('" + item2.Surname.Trim().ToUpper() + "' , '" + item2.Phone.Trim() + "', '" + item2.Adress.Trim() + "', '" + "', '0', '" + item2.Data_priema + "', '" + item2.AboutUs.Trim() + "')";
								m_sqlCmd.ExecuteNonQuery();
							}
						}
						else
						{
							//DbContext.Instance.Command("begin").ExecuteNonQuery();
							foreach (VirtualClient item3 in list2)
							{
								m_sqlCmd.CommandText = "INSERT INTO ClientsMap (FIO,Phone,Adress,Primechanie,Blist,Date,aboutUs) values ('" + item3.Surname.Trim().ToUpper() + "' , '" + item3.Phone.Trim() + "', '" + item3.Adress.Trim() + "', '" + "', '0', '" + item3.Data_priema + "', '" + item3.AboutUs.Trim() + "')";
								m_sqlCmd.ExecuteNonQuery();
							}
							//DbContext.Instance.Command("end").ExecuteNonQuery();
						}
					}
					catch (Exception ex2)
					{
						MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex2.ToString() + Environment.NewLine);
					}
					MessageBox.Show(string.Format("В базе найдено {0} уникальных клиентов{2} Всего записей в базе {1} {2} ", list2.Count(), list.Count(), Environment.NewLine), "База данных обновилась", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
				}
				if (dataTable.Rows.Count < 31)
				{
					m_sqlCmd.CommandText = "ALTER TABLE Catalog ADD COLUMN Barcode TEXT";
					m_sqlCmd.ExecuteNonQuery();
					mainForm.basa.BdNoNull("Barcode");
					mainForm.basa.BdNoNullRename("Status_remonta", "Ждёт запчасть", "Ждет ЗИП");
				}
				if (dataTable.Rows.Count < 32)
				{
					m_sqlCmd.CommandText = "ALTER TABLE Catalog ADD COLUMN Deleted TEXT";
					m_sqlCmd.ExecuteNonQuery();
					mainForm.basa.BdNoNull("Deleted");
				}
			}
		}
		catch (Exception ex3)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при получении id записи из базы данных " + ex3.ToString() + Environment.NewLine);
		}
	}

	public int BdReadAdvertsDataTop()
	{
		DataTable dataTable = new DataTable();
		int result = 0;

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return result;
		}
		try
		{
			string commandText = "SELECT id FROM Catalog ORDER BY id DESC LIMIT 1";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return int.Parse(dataTable.Rows[0].ItemArray[0].ToString());
			}
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": База данных пуста" + Environment.NewLine);
			return result;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при получении id записи из базы данных " + ex.ToString() + Environment.NewLine);
			return result;
		}
	}

	public int CatlogIDExists(string Catalog_id)
	{
		DataTable dataTable = new DataTable();
		int result = 0;

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return result;
		}
		try
		{
			string commandText = $"SELECT EXISTS(SELECT * FROM Catalog WHERE id = '{Catalog_id}' LIMIT 1)";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return int.Parse(dataTable.Rows[0].ItemArray[0].ToString());
			}
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": База данных пуста" + Environment.NewLine);
			return result;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при получении id записи из базы данных " + ex.ToString() + Environment.NewLine);
			return result;
		}
	}

	public int BdReadAdvertsDataFirt()
	{
		DataTable dataTable = new DataTable();
		int result = 0;

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return result;
		}
		try
		{
			string commandText = "SELECT id FROM Catalog LIMIT 1";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return int.Parse(dataTable.Rows[0].ItemArray[0].ToString());
			}
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": База данных пуста" + Environment.NewLine);
			return result;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при получении id записи из базы данных " + ex.ToString() + Environment.NewLine);
			return result;
		}
	}

	public DataTable BdRead(bool trfl)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText;
			if (!trfl)
			{
				commandText = "SELECT * FROM Catalog WHERE NOT Data_Vidachi = ''";
				var dataAdapter = DbContext.Instance.DataAdapter(commandText);
				dataAdapter.Fill(dataTable);
				return dataTable;
			}
			commandText = "SELECT * FROM Catalog WHERE Data_Vidachi = ''";
			var dataAdapter2 = DbContext.Instance.DataAdapter(commandText);
			dataAdapter2.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public DataTable BdReadAll()
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = "SELECT * FROM Catalog";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public DataTable BdReadOneEditor(string id_bd)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = "SELECT * FROM Catalog WHERE id = " + id_bd;
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public DataSet BdReadGraf(string calendar1, string calendar2, string master)
	{
		DataSet dataSet = new DataSet();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataSet;
		}
		try
		{
			string commandText = string.Format("SELECT * FROM Catalog WHERE( [{0}] BETWEEN '{1}' AND '{2}') AND Data_vidachi !='' AND master LIKE'%{3}%'", "Data_vidachi", calendar1, calendar2, master.ToUpper());
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataSet);
			return dataSet;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataSet;
	}

	public List<VirtualClient> BdReadGrafList(string calendar1, string calendar2, string master, string AdressSCINBD, string whatRemont, string brand)
	{
		List<VirtualClient> list = new List<VirtualClient>();
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return list;
		}
		try
		{
			string commandText = $"SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE NOT c.Data_Vidachi = '' AND c.master LIKE'%{master.ToUpper().Trim()}%' AND c.AdressSC LIKE '%{AdressSCINBD.ToUpper().Trim()}%' AND c.WhatRemont LIKE '%{whatRemont.ToUpper().Trim()}%' AND c.brand LIKE '%{brand.ToUpper().Trim()}%'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if (DateTime.Parse(DateTime.Parse(dataTable.Rows[i].ItemArray[2].ToString()).ToShortDateString()) >= DateTime.Parse(calendar1) && DateTime.Parse(DateTime.Parse(dataTable.Rows[i].ItemArray[2].ToString()).ToShortDateString()) <= DateTime.Parse(calendar2))
					{
						VirtualClient item = new VirtualClient(dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString(), dataTable.Rows[i].ItemArray[5].ToString(), dataTable.Rows[i].ItemArray[6].ToString(), dataTable.Rows[i].ItemArray[7].ToString(), dataTable.Rows[i].ItemArray[8].ToString(), dataTable.Rows[i].ItemArray[9].ToString(), dataTable.Rows[i].ItemArray[10].ToString(), dataTable.Rows[i].ItemArray[11].ToString(), dataTable.Rows[i].ItemArray[12].ToString(), dataTable.Rows[i].ItemArray[13].ToString(), dataTable.Rows[i].ItemArray[14].ToString(), dataTable.Rows[i].ItemArray[15].ToString(), dataTable.Rows[i].ItemArray[16].ToString(), dataTable.Rows[i].ItemArray[17].ToString(), dataTable.Rows[i].ItemArray[18].ToString(), dataTable.Rows[i].ItemArray[19].ToString(), dataTable.Rows[i].ItemArray[20].ToString(), dataTable.Rows[i].ItemArray[21].ToString(), dataTable.Rows[i].ItemArray[22].ToString(), dataTable.Rows[i].ItemArray[23].ToString(), dataTable.Rows[i].ItemArray[24].ToString(), dataTable.Rows[i].ItemArray[25].ToString(), dataTable.Rows[i].ItemArray[26].ToString(), false, dataTable.Rows[i].ItemArray[27].ToString(), dataTable.Rows[i].ItemArray[28].ToString(), -1, dataTable.Rows[i].ItemArray[30].ToString());
						list.Add(item);
					}
				}
				return list;
			}
			return list;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return list;
	}

	public List<VirtualClient> ExportPhonesVCList(string from, string to)
	{
		List<VirtualClient> list = new List<VirtualClient>();
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return list;
		}
		try
		{
			string commandText = $"SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE c.id >= {from} AND c.id <={to}";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					VirtualClient item = new VirtualClient(dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString(), dataTable.Rows[i].ItemArray[5].ToString(), dataTable.Rows[i].ItemArray[6].ToString(), dataTable.Rows[i].ItemArray[7].ToString(), dataTable.Rows[i].ItemArray[8].ToString(), dataTable.Rows[i].ItemArray[9].ToString(), dataTable.Rows[i].ItemArray[10].ToString(), dataTable.Rows[i].ItemArray[11].ToString(), dataTable.Rows[i].ItemArray[12].ToString(), dataTable.Rows[i].ItemArray[13].ToString(), dataTable.Rows[i].ItemArray[14].ToString(), dataTable.Rows[i].ItemArray[15].ToString(), dataTable.Rows[i].ItemArray[16].ToString(), dataTable.Rows[i].ItemArray[17].ToString(), dataTable.Rows[i].ItemArray[18].ToString(), dataTable.Rows[i].ItemArray[19].ToString(), dataTable.Rows[i].ItemArray[20].ToString(), dataTable.Rows[i].ItemArray[21].ToString(), dataTable.Rows[i].ItemArray[22].ToString(), dataTable.Rows[i].ItemArray[23].ToString(), dataTable.Rows[i].ItemArray[24].ToString(), dataTable.Rows[i].ItemArray[25].ToString(), dataTable.Rows[i].ItemArray[26].ToString(), false, dataTable.Rows[i].ItemArray[27].ToString(), dataTable.Rows[i].ItemArray[28].ToString(), -1, dataTable.Rows[i].ItemArray[30].ToString());
					list.Add(item);
				}
				return list;
			}
			return list;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return list;
	}

	public string BdReadBarcode(string barcode)
	{
		DataTable dataTable = new DataTable();
		string result = "";

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return result;
		}
		try
		{
			string commandText = $"SELECT id FROM Catalog Where Barcode = '{barcode}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return dataTable.Rows[0].ItemArray[0].ToString();
			}
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу прочитать данные записи со штрихкодом  " + barcode + Environment.NewLine);
			return result;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при получении записи из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return result;
	}

	public string BdReadOne(string readWhat, string id_bd)
	{
		DataTable dataTable = new DataTable();
		string result = "";

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return result;
		}
		try
		{
			string commandText = "SELECT " + readWhat + " FROM Catalog Where id =" + id_bd;
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return dataTable.Rows[0].ItemArray[0].ToString();
			}
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу прочитать даты записи номер " + id_bd + Environment.NewLine);
			return result;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при получении записи из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return result;
	}

	public void BdWrite(string Data_priema, string Data_vidachi, string Data_predoplaty, string surname, string phone, string AboutUs, string WhatRemont, string brand, string model, string SerialNumber, string sostoyanie, string komplektonst, string polomka, string kommentarij, string predvaritelnaya_stoimost, string Predoplata, string Zatrati, string okonchatelnaya_stoimost_remonta, string Skidka, string Status_remonta, string master, string vipolnenie_raboti, string Garanty, string wait_zakaz, string Adress, string Image_key, string AdressSC, string DeviceColour, string ClientId)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return;
		}
		string str = DateTime.Now.ToString("ddMMHHmmss");
		string text = DateTime.Now.ToString("yyyy");
		text = text.Substring(3);
		str += text;
		str = barcodeLastDigit(str);
		string text2 = "";
		try
		{
			if (Data_priema != "")
			{
				Data_priema = DateTime.Parse(Data_priema).ToString("dd-MM-yyyy HH:mm");
			}
			m_sqlCmd.CommandText = "INSERT INTO Catalog (Data_priema,Data_vidachi,Data_predoplaty,surname,phone,AboutUs,WhatRemont,brand,model,SerialNumber,sostoyanie,komplektonst,polomka,kommentarij,predvaritelnaya_stoimost,Predoplata,Zatrati,okonchatelnaya_stoimost_remonta,Skidka,Status_remonta,master,vipolnenie_raboti,Garanty,wait_zakaz,Adress,Image_key,AdressSC,DeviceColour,ClientId,Barcode,Deleted) values ('" + Data_priema + "' , '" + Data_vidachi + "', '" + Data_predoplaty + "', '" + surname.Trim().ToUpper() + "', '" + phone.Trim() + "', '" + AboutUs.Trim() + "', '" + WhatRemont.Trim().ToUpper() + "', '" + brand.Trim().ToUpper() + "', '" + model.Trim().ToUpper() + "', '" + SerialNumber.Trim().ToUpper() + "', '" + sostoyanie.Trim() + "', '" + komplektonst.Trim() + "', '" + polomka.Trim() + "', '" + kommentarij.Trim() + "', '" + predvaritelnaya_stoimost.Trim() + "', '" + Predoplata.Trim() + "', '" + Zatrati.Trim() + "', '" + okonchatelnaya_stoimost_remonta.Trim() + "', '" + Skidka + "', '" + Status_remonta.Trim() + "', '" + master.Trim().ToUpper() + "', '" + vipolnenie_raboti.Trim() + "', '" + Garanty.Trim() + "', '" + wait_zakaz + "', '" + Adress + "', '" + Image_key + "', '" + AdressSC + "', '" + DeviceColour + "', '" + ClientId + "', '" + str + "', '" + text2 + "')";
			m_sqlCmd.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
		}
	}

	public void BdEdit(string data_predoplaty, string data_vidachi, string surname, string phone, string AboutUs, string WhatRemont, string brand, string model, string SerialNumber, string sostoyanie, string komplektonst, string polomka, string kommentarij, string predvaritelnaya_stoimost, string Predoplata, string Zatrati, string okonchatelnaya_stoimost_remonta, string Skidka, string Status_remonta, string master, string vipolnenie_raboti, string Garanty, string wait_zakaz, string Adress, string Image_key, string id_bd, string AdressSC, string DeviceColour)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE Catalog SET surname ='" + surname.Trim().ToUpper() + "',Data_predoplaty ='" + data_predoplaty + "',Data_vidachi ='" + data_vidachi + "',phone ='" + phone.Trim() + "',AboutUs ='" + AboutUs.Trim() + "',WhatRemont ='" + WhatRemont.ToUpper() + "',brand ='" + brand.Trim().ToUpper() + "',model ='" + model.Trim().ToUpper() + "',SerialNumber ='" + SerialNumber.Trim().ToUpper() + "',sostoyanie ='" + sostoyanie.Trim() + "',komplektonst ='" + komplektonst.Trim() + "',polomka ='" + polomka.Trim() + "',kommentarij ='" + kommentarij.Trim() + "',predvaritelnaya_stoimost ='" + predvaritelnaya_stoimost.Trim() + "',Predoplata ='" + Predoplata.Trim() + "',Zatrati ='" + Zatrati.Trim() + "',okonchatelnaya_stoimost_remonta ='" + okonchatelnaya_stoimost_remonta.Trim() + "',Skidka ='" + Skidka + "',Status_remonta ='" + Status_remonta + "',master ='" + master.Trim().ToUpper() + "',vipolnenie_raboti ='" + vipolnenie_raboti.Trim() + "',Garanty ='" + Garanty + "',wait_zakaz ='" + wait_zakaz + "',Adress ='" + Adress + "',Image_key ='" + Image_key + "',AdressSC ='" + AdressSC.ToUpper().Trim() + "',DeviceColour ='" + DeviceColour.ToUpper().Trim() + "' WHERE ID = " + id_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void BdEditVidachiPoGarantii(string data_predoplaty, string data_vidachi, string surname, string phone, string AboutUs, string WhatRemont, string brand, string model, string SerialNumber, string sostoyanie, string komplektonst, string polomka, string kommentarij, string predvaritelnaya_stoimost, string Predoplata, string Zatrati, string okonchatelnaya_stoimost_remonta, string Skidka, string Status_remonta, string master, string vipolnenie_raboti, string Garanty, string wait_zakaz, string Adress, string Image_key, string id_bd, string AdressSC, string DeviceColour)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE Catalog SET surname ='" + surname.Trim().ToUpper() + "',Data_predoplaty ='" + data_predoplaty + "',phone ='" + phone.Trim() + "',AboutUs ='" + AboutUs.Trim() + "',WhatRemont ='" + WhatRemont.ToUpper() + "',brand ='" + brand.Trim().ToUpper() + "',model ='" + model.Trim().ToUpper() + "',SerialNumber ='" + SerialNumber.Trim().ToUpper() + "',sostoyanie ='" + sostoyanie.Trim() + "',komplektonst ='" + komplektonst.Trim() + "',polomka ='" + polomka.Trim() + "',kommentarij ='" + kommentarij.Trim() + "',predvaritelnaya_stoimost ='" + predvaritelnaya_stoimost.Trim() + "',Predoplata ='" + Predoplata.Trim() + "',Zatrati ='" + Zatrati.Trim() + "',okonchatelnaya_stoimost_remonta ='" + okonchatelnaya_stoimost_remonta.Trim() + "',Skidka ='" + Skidka + "',Status_remonta ='" + Status_remonta + "',master ='" + master.Trim().ToUpper() + "',vipolnenie_raboti ='" + vipolnenie_raboti.Trim() + "',Garanty ='" + Garanty + "',wait_zakaz ='" + wait_zakaz + "',Adress ='" + Adress + "',Image_key ='" + Image_key + "',AdressSC ='" + AdressSC.ToUpper().Trim() + "',DeviceColour ='" + DeviceColour.ToUpper().Trim() + "' WHERE ID = " + id_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void BdEditOne(string EditWhat, string EditThis, string id_bd)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE Catalog SET " + EditWhat + " ='" + EditThis + "' WHERE ID = " + id_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void BdNoNull(string WhatToDo)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE Catalog SET " + WhatToDo + " ='" + "' WHERE " + WhatToDo + " is null";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void BdNoNullRename(string WhatToDo, string DoThis, string WithThis)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE Catalog SET " + WhatToDo + " ='" + DoThis.Trim() + "' WHERE " + WhatToDo + "='" + WithThis + "'";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void BdDelete(string id_bd)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "DELETE FROM Catalog WHERE id =" + id_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public DataTable SearchFIO(string FIO, bool Chek)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		string commandText = "";
		DataTable dataTable = new DataTable();
		try
		{
			if (DbContext.Instance.State != ConnectionState.Open)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
				return dataTable;
			}
			if (Chek)
			{
				commandText = $"SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE NOT c.Data_Vidachi = '' AND cm.FIO LIKE '%{FIO.ToUpper()}%'";
			}
			if (!Chek)
			{
				commandText = $"SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE c.Data_Vidachi = ''AND cm.FIO LIKE '%{FIO.ToUpper()}%'";
			}
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
		}
		catch (Exception ex)
		{
			MessageBox.Show("Что-то пошло не так при проведении поиска" + Environment.NewLine + ex.ToString());
		}
		return dataTable;
	}

	public DataTable BdReadFullSearch(string FIO, string phone, string TypeOf, string brand, string model, string status, string master, string zakaz, bool trfl, string idInBd, string serialImei, string AdressSC, string garanty = "", string soglasovat = "")
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			if (garanty == "garanty")
			{
				if (idInBd != "")
				{
					string commandText = $"SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE cm.FIO LIKE'%{FIO.ToUpper().Trim()}%' AND c.brand LIKE'%{brand.ToUpper().Trim()}%' AND cm.Phone LIKE'%{phone.Trim()}%' AND c.WhatRemont LIKE'%{TypeOf.ToUpper().Trim()}%' AND c.model LIKE'%{model.ToUpper().Trim()}%'  AND c.Status_remonta LIKE'%{status}%' AND c.master LIKE'%{master.ToUpper().Trim()}%' AND c.wait_zakaz LIKE'%{zakaz}%' AND c.Image_key LIKE '%{soglasovat}%' AND c.id = '{idInBd}' AND c.SerialNumber LIKE '%{serialImei.ToUpper()}%' AND c.AdressSC LIKE '%{AdressSC.ToUpper()}%' AND NOT c.Deleted = '1'";
					var dataAdapter = DbContext.Instance.DataAdapter(commandText);
					dataAdapter.Fill(dataTable);
				}
				else
				{
					string commandText = $"SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE cm.FIO LIKE'%{FIO.ToUpper().Trim()}%' AND c.brand LIKE'%{brand.ToUpper().Trim()}%' AND cm.Phone LIKE'%{phone.Trim()}%' AND c.WhatRemont LIKE'%{TypeOf.ToUpper().Trim()}%' AND c.model LIKE'%{model.ToUpper().Trim()}%'  AND c.Status_remonta LIKE'%{status.Trim()}%' AND c.master LIKE'%{master.ToUpper().Trim()}%' AND c.wait_zakaz LIKE'%{zakaz}%' AND c.Image_key LIKE '%{soglasovat}%' AND c.id LIKE '%{idInBd}%' AND c.SerialNumber LIKE '%{serialImei.ToUpper()}%' AND c.AdressSC LIKE '%{AdressSC.ToUpper()}%' AND NOT c.Deleted = '1'";
					var dataAdapter = DbContext.Instance.DataAdapter(commandText);
					dataAdapter.Fill(dataTable);
				}
				return dataTable;
			}
			if (!trfl)
			{
				if (idInBd != "")
				{
					string commandText = string.Format("SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE cm.FIO LIKE'%{0}%' AND c.brand LIKE'%{1}%' AND cm.Phone LIKE'%{2}%' AND c.WhatRemont LIKE'%{3}%' AND c.model LIKE'%{4}%' AND NOT c.Data_vidachi = '{5}' AND c.Status_remonta LIKE'%{6}%' AND c.master LIKE'%{7}%' AND c.wait_zakaz LIKE'%{8}%' AND c.Image_key LIKE '%{9}%' AND c.id = '{10}' AND c.SerialNumber LIKE '%{11}%' AND c.AdressSC LIKE '%{12}%' AND NOT c.Deleted = '1'", FIO.ToUpper().Trim(), brand.ToUpper().Trim(), phone.Trim(), TypeOf.ToUpper().Trim(), model.ToUpper().Trim(), "", status, master.ToUpper().Trim(), zakaz, soglasovat, idInBd, serialImei.ToUpper(), AdressSC.ToUpper());
					var dataAdapter3 = DbContext.Instance.DataAdapter(commandText);
					dataAdapter3.Fill(dataTable);
				}
				else
				{
					string commandText = string.Format("SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE cm.FIO LIKE'%{0}%' AND c.brand LIKE'%{1}%' AND cm.Phone LIKE'%{2}%' AND c.WhatRemont LIKE'%{3}%' AND c.model LIKE'%{4}%' AND NOT c.Data_vidachi = '{5}' AND c.Status_remonta LIKE'%{6}%' AND c.master LIKE'%{7}%' AND c.wait_zakaz LIKE'%{8}%' AND c.Image_key LIKE '%{9}%' AND c.id LIKE '%{10}%' AND c.SerialNumber LIKE '%{11}%' AND c.AdressSC LIKE '%{12}%' AND NOT c.Deleted = '1'", FIO.ToUpper().Trim(), brand.ToUpper().Trim(), phone.Trim(), TypeOf.ToUpper().Trim(), model.ToUpper().Trim(), "", status, master.ToUpper().Trim(), zakaz, soglasovat, idInBd, serialImei.ToUpper(), AdressSC.ToUpper());
					var dataAdapter4 = DbContext.Instance.DataAdapter(commandText);
					dataAdapter4.Fill(dataTable);
				}
				return dataTable;
			}
			if (idInBd != "")
			{
				string commandText = string.Format("SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE cm.FIO LIKE'%{0}%' AND c.brand LIKE'%{1}%' AND cm.Phone LIKE'%{2}%' AND c.WhatRemont LIKE'%{3}%' AND c.model LIKE'%{4}%' AND NOT c.Data_vidachi = '{5}' AND c.Status_remonta LIKE'%{6}%' AND c.master LIKE'%{7}%' AND c.wait_zakaz LIKE'%{8}%' AND c.Image_key LIKE '%{9}%' AND c.id = '{10}' AND c.SerialNumber LIKE '%{11}%' AND c.AdressSC LIKE '%{12}%' AND NOT c.Deleted = '1'", FIO.ToUpper().Trim(), brand.ToUpper().Trim(), phone.Trim(), TypeOf.ToUpper().Trim(), model.ToUpper().Trim(), "", status, master.ToUpper().Trim(), zakaz, soglasovat, idInBd, serialImei.ToUpper(), AdressSC.ToUpper());
				var dataAdapter5 = DbContext.Instance.DataAdapter(commandText);
				dataAdapter5.Fill(dataTable);
			}
			else
			{
				string commandText = string.Format("SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE cm.FIO LIKE'%{0}%' AND c.brand LIKE'%{1}%' AND cm.Phone LIKE'%{2}%' AND c.WhatRemont LIKE'%{3}%' AND c.model LIKE'%{4}%' AND c.Data_vidachi = '{5}' AND c.Status_remonta LIKE'%{6}%' AND c.master LIKE'%{7}%' AND c.wait_zakaz LIKE'%{8}%' AND c.Image_key LIKE '%{9}%' AND c.id LIKE '%{10}%' AND c.SerialNumber LIKE '%{11}%' AND c.AdressSC LIKE '%{12}%' AND NOT c.Status_remonta = 'Выдан' AND NOT c.Deleted = '1' OR (c.Status_remonta = 'Принят по гарантии' AND cm.FIO LIKE'%{0}%' AND c.brand LIKE'%{1}%' AND cm.Phone LIKE'%{2}%' AND c.WhatRemont LIKE'%{3}%' AND c.model LIKE'%{4}%' AND c.master LIKE'%{7}%' AND c.wait_zakaz LIKE'%{8}%' AND c.Image_key LIKE '%{9}%' AND c.id LIKE '%{10}%' AND c.SerialNumber LIKE '%{11}%' AND c.AdressSC LIKE '%{12}%' AND NOT c.Deleted = '1')", FIO.ToUpper().Trim(), brand.ToUpper().Trim(), phone.Trim(), TypeOf.ToUpper().Trim(), model.ToUpper().Trim(), "", status, master.ToUpper().Trim(), zakaz, soglasovat, idInBd, serialImei.ToUpper(), AdressSC.ToUpper());
				var dataAdapter6 = DbContext.Instance.DataAdapter(commandText);
				dataAdapter6.Fill(dataTable);
			}
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public DataTable BdReadFullSearch(string FIO, string phone, string TypeOf, string brand, string model, string status, string master, string zakaz, bool trfl, string idInBd, string serialImei, string AdressSC, string garanty = "", string soglasovat = "", bool vidannoe = false)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = string.Format("SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE cm.FIO LIKE'%{0}%' AND c.brand LIKE'%{1}%' AND cm.Phone LIKE'%{2}%' AND c.WhatRemont LIKE'%{3}%' AND c.model LIKE'%{4}%' AND NOT c.Data_vidachi = '{5}' AND c.Status_remonta LIKE'%{6}%' AND c.master LIKE'%{7}%' AND c.wait_zakaz LIKE'%{8}%' AND c.Image_key LIKE '%{9}%' AND c.id LIKE '%{10}%' AND c.SerialNumber LIKE '%{11}%' AND c.AdressSC LIKE '%{12}%' AND NOT c.Deleted = '1'", FIO.ToUpper().Trim(), brand.ToUpper().Trim(), phone.Trim(), TypeOf.ToUpper().Trim(), model.ToUpper().Trim(), "", "", master.ToUpper().Trim(), zakaz, soglasovat, idInBd, serialImei.ToUpper(), AdressSC.ToUpper());
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public DataTable BdSearchPhoneWaiting()
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = string.Format("SELECT c.id,c.Data_priema,c.Data_vidachi,c.Data_predoplaty,cm.FIO,cm.Phone,cm.AboutUs,c.WhatRemont,c.brand,c.model,c.SerialNumber,c.Sostoyanie,c.komplektonst,c.polomka,c.kommentarij,c.predvaritelnaya_stoimost,c.Predoplata,c.Zatrati, c.okonchatelnaya_stoimost_remonta,c.Skidka,c.Status_remonta,c.master,c.vipolnenie_raboti,c.Garanty,c.wait_zakaz,cm.Adress,c.Image_key, c.AdressSC, c.DeviceColour, c.ClientId,c.Barcode FROM Catalog c JOIN ClientsMap cm ON c.clientID = cm.id WHERE c.Image_key = '{0}'", "1");
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
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

	public void CreateStock()
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();
		try
		{



			m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Stock (id INTEGER PRIMARY KEY AUTO_INCREMENT, Naimenovanie TEXT, Kategoriya TEXT, Podkategoriya TEXT, Colour TEXT, Brand TEXT, Model TEXT,CountOf TEXT, Price TEXT, Napominanie TEXT, Photo TEXT, Primechanie TEXT, Photo2 TEXT, Photo3 TEXT)";
			m_sqlCmd.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу установить соединение с базой данных " + ex.ToString() + Environment.NewLine);
		}
	}

	public void CreateStockMap()
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();
		try
		{



			m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS StockMap (id INTEGER PRIMARY KEY AUTO_INCREMENT, clientId TEXT,ZIPId TEXT ,countOfZIP TEXT, priceOfZIP TEXT)";
			m_sqlCmd.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу установить соединение с базой данных " + ex.ToString() + Environment.NewLine);
		}
	}

	public void BdStockWrite(string Naimenovanie, string Kategoriya, string Podkategoriya, string Colour, string Brand, string Model, string CountOf, string Napominanie, string Price, string Primechanie, string Photo = "", string Photo2 = "", string Photo3 = "")
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "INSERT INTO Stock (Naimenovanie,Kategoriya,Podkategoriya,Colour,Brand,Model,CountOf,Napominanie,Price,Photo,Primechanie,Photo2,Photo3) values ('" + Naimenovanie.Trim().ToUpper() + "' , '" + Kategoriya.Trim().ToUpper() + "', '" + Podkategoriya.Trim().ToUpper() + "', '" + Colour.Trim().ToUpper() + "', '" + Brand.Trim().ToUpper() + "', '" + Model.Trim().ToUpper() + "', '" + CountOf.Trim().ToUpper() + "', '" + Napominanie.Trim().ToUpper() + "','" + Price.Trim().ToUpper() + "','" + Photo.Trim() + "','" + Primechanie.Trim().ToUpper() + "','" + Photo2.Trim() + "','" + Photo3.Trim() + "')";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void BdStockEdit(string Naimenovanie, string Kategoriya, string Podkategoriya, string Colour, string Brand, string Model, string CountOf, string Napominanie, string Price, string Photo, string id_bd, string Primechanie, string Photo2, string Photo3)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE Stock SET Naimenovanie ='" + Naimenovanie.Trim().ToUpper() + "',Kategoriya ='" + Kategoriya.Trim().ToUpper() + "',Podkategoriya ='" + Podkategoriya.Trim().ToUpper() + "',Colour ='" + Colour.Trim().ToUpper() + "',Brand ='" + Brand.Trim().ToUpper() + "',Model ='" + Model.Trim().ToUpper() + "',CountOf ='" + CountOf.Trim().ToUpper() + "',Napominanie ='" + Napominanie.Trim().ToUpper() + "',Price ='" + Price.Trim().ToUpper() + "',Photo ='" + Photo.Trim() + "',Primechanie ='" + Primechanie.Trim().ToUpper() + "',Photo2 ='" + Photo2.Trim() + "',Photo3 ='" + Photo3.Trim() + "' WHERE id = " + id_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void BdStockEditOne(string EditWhat, string EditThis, string idOfZIP)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE Stock SET " + EditWhat + " ='" + EditThis + "' WHERE ID = " + idOfZIP;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public DataTable BdStockFullSearch(string Naimenovanie, string Kategoriya, string Podkategoriya, string Colour, string Brand, string Model, string CountOf, string Napominanie)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = $"SELECT * FROM Stock WHERE Naimenovanie LIKE'%{Naimenovanie.ToUpper().Trim()}%' AND Kategoriya LIKE'%{Kategoriya.ToUpper().Trim()}%' AND Podkategoriya LIKE'%{Podkategoriya.Trim().ToUpper()}%' AND Colour LIKE'%{Colour.ToUpper().Trim()}%' AND Brand LIKE'%{Brand.ToUpper().Trim()}%'  AND Model LIKE'%{Model.ToUpper().Trim()}%'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public DataTable BdStockEditor(string id)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = $"SELECT * FROM Stock WHERE id ={id.Trim()}";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public void BdStockDelete(string id_bd)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "DELETE FROM Stock WHERE id =" + id_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void BdStockMapWrite(string clientId, string ZIPId, string countOfZIP, string priceOfZIP)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "INSERT INTO StockMap (clientId,ZIPId,countOfZIP,priceOfZIP) values ('" + clientId.Trim() + "' , '" + ZIPId.Trim() + "', '" + countOfZIP.Trim() + "', '" + priceOfZIP.Trim() + "')";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void BdStockMapDelete(string id_bd)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "DELETE FROM StockMap WHERE clientId =" + id_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public DataTable BdStockMapZIPDeleteCounter(string idClient, string idZIP)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = $"SELECT * FROM StockMap WHERE clientId = '{idClient.Trim()}' AND ZIPId = '{idZIP.Trim()}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public void BdStockMapDeleteZIP(string id_bd, string idZIP)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "DELETE FROM StockMap WHERE clientId =" + id_bd + " AND ZIPId =" + idZIP;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public bool BdStockMapZIPUsedCheck(string id_bd, string idZIP)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return false;
		}
		try
		{
			string commandText = $"SELECT * FROM StockMap WHERE clientId = '{id_bd.Trim()}' AND ZIPId = '{idZIP.Trim()}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
			return false;
		}
	}

	public DataTable BdStockMapZIPUsedCheckOptimised()
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = $"SELECT * FROM StockMap";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
			return dataTable;
		}
	}

	public string BdStockMapZIPUsedCoutner(string id_bd, string idZIP)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return "0";
		}
		try
		{
			string commandText = $"SELECT * FROM StockMap WHERE clientId = '{id_bd.Trim()}' AND ZIPId = '{idZIP.Trim()}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			int num = 0;
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num += int.Parse(dataTable.Rows[i].ItemArray[3].ToString());
				}
				return num.ToString();
			}
			return "0";
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
			return "0";
		}
	}

	public void StatesMapTable_Create()
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();
		try
		{



			m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS StatesMap (id INTEGER PRIMARY KEY AUTO_INCREMENT, clientId TEXT, State TEXT ,date TEXT)";
			m_sqlCmd.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу установить соединение с базой данных " + ex.ToString() + Environment.NewLine);
		}
	}

	public void StatesMapDelete(string id_bd)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "DELETE FROM StatesMap WHERE id =" + id_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void StatesMapWrite(string clientId, string state, string date)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "INSERT INTO StatesMap (clientId,State,date) values ('" + clientId.Trim() + "' , '" + state.Trim() + "', '" + date.Trim() + "')";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public DataTable StatesMapGiver(string idClient)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = $"SELECT * FROM StatesMap WHERE clientId = '{idClient.Trim()}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public void StatesMapEdit(string EditWhat, string EditThis, string id_map_bd)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE StatesMap SET " + EditWhat + " ='" + EditThis + "' WHERE ID = " + id_map_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void ClientsMapTable_Create()
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();
		try
		{



			m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS ClientsMap (id INTEGER PRIMARY KEY AUTO_INCREMENT, FIO TEXT, Phone TEXT, Adress Text, Primechanie TEXT, Blist TEXT ,date TEXT, aboutUs TEXT)";
			m_sqlCmd.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу установить соединение с базой данных " + ex.ToString() + Environment.NewLine);
		}
	}

	public void ClientsMapDelete(string id_client)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "DELETE FROM ClientsMap WHERE id =" + id_client;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void ClientsMapZapisiDelete(string id_client)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = $"DELETE FROM Catalog WHERE ClientId = '{id_client}'";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void ClientsMapWrite(string FIO, string Phone, string Adress, string Primechanie, string Blist, string Date, string aboutUs)
	{
		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				var m_sqlCmd = DbContext.Instance.Command();
				m_sqlCmd.CommandText = "INSERT INTO ClientsMap (FIO,Phone,Adress,Primechanie,Blist,Date,aboutUs) values ('" + FIO.Trim().ToUpper() + "' , '" + Phone.Trim() + "', '" + Adress.Trim() + "', '" + Primechanie.Trim() + "', '" + Blist.Trim() + "', '" + Date.Trim() + "', '" + aboutUs.Trim() + "')";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public DataTable ClientsMapGiver(string idClient)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = $"SELECT * FROM ClientsMap WHERE id = '{idClient.Trim()}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public DataTable ClientsAllMapGiver()
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = $"SELECT * FROM ClientsMap";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public DataTable ClientsFIOPhoneSearch(string fio, string phone)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = string.Format("SELECT * FROM ClientsMap WHERE FIO LIKE '%{0}%' AND Phone LIKE'%{1}%'", fio.Trim().ToUpper(), phone.Trim().Replace(" ", ""));
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public void ClientsMapEditOne(string EditWhat, string EditThis, string id_map_bd)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE ClientsMap SET " + EditWhat + " ='" + EditThis + "' WHERE ID = " + id_map_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void ClientsToClitens(string firstClient, string secondClient)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = string.Format("UPDATE Catalog SET ClientId= '{1}' WHERE ClientId = '{0}'", firstClient, secondClient);
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void ClientsMapEditAll(string FIO, string Phone, string Adress, string Primechanie, string Blist, string date, string aboutUs, string id_bd)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE ClientsMap SET FIO ='" + FIO.Trim().ToUpper() + "',Phone ='" + Phone.Trim() + "',Adress ='" + Adress.Trim() + "',Primechanie ='" + Primechanie.Trim() + "',Blist ='" + Blist.Trim() + "',date ='" + date.Trim() + "',aboutUs ='" + aboutUs.Trim() + "' WHERE id = " + id_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void ClientsMapEditWithoutDate(string FIO, string Phone, string Adress, string Primechanie, string Blist, string aboutUs, string id_bd)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE ClientsMap SET FIO ='" + FIO.Trim().ToUpper() + "',Phone ='" + Phone.Trim() + "',Adress ='" + Adress.Trim() + "',Primechanie ='" + Primechanie.Trim() + "',Blist ='" + Blist.Trim() + "',aboutUs ='" + aboutUs.Trim() + "' WHERE id = " + id_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void ClientsMapEditInEditor(string FIO, string Phone, string Adress, string aboutUs, string id_bd)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE ClientsMap SET FIO ='" + FIO.Trim().ToUpper() + "',Phone ='" + Phone.Trim() + "',Adress ='" + Adress.Trim() + "',aboutUs ='" + aboutUs.Trim() + "' WHERE id = " + id_bd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public string ClientReadId(string FIO, string Phone)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return "";
		}
		try
		{
			string commandText = string.Format("SELECT id FROM ClientsMap WHERE FIO = '{0}' AND Phone = '{1}'", FIO.Trim().ToUpper(), Phone.Trim().Replace(" ", ""));
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return dataTable.Rows[0].ItemArray[0].ToString();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return "";
	}

	public string ClientReadDate(string id)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return "";
		}
		try
		{
			string commandText = $"SELECT date FROM ClientsMap WHERE id = '{id}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return dataTable.Rows[0].ItemArray[0].ToString();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return "";
	}

	public AutoCompleteStringCollection AddCollectionFIO()
	{
		AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
		try
		{
			DataTable dataTable = new DataTable();

			DbCommand m_sqlCmd = DbContext.Instance.Command();



			if (DbContext.Instance.State != ConnectionState.Open)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			}
			string commandText = $"SELECT FIO FROM ClientsMap";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					autoCompleteStringCollection.Add(FirstLetterToUpper(dataTable.Rows[i].ItemArray[0].ToString()));
				}
				return autoCompleteStringCollection;
			}
			return autoCompleteStringCollection;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
		return autoCompleteStringCollection;
	}

	public DataTable BdReadFIOPhone(string fio)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = $"SELECT FIO, Phone, Adress, Primechanie, Blist, Date, aboutUs  FROM ClientsMap WHERE FIO = '{fio.ToUpper()}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public DataTable ClientsShowHistory(string clientId)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		DataTable dataTable = new DataTable();
		try
		{
			if (DbContext.Instance.State != ConnectionState.Open)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
				return dataTable;
			}
			string commandText = $"SELECT * FROM Catalog WHERE ClientId = '{clientId.Trim()}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
		}
		catch (Exception ex)
		{
			MessageBox.Show("Что-то пошло не так при проведении поиска" + Environment.NewLine + ex.ToString());
		}
		return dataTable;
	}

	public string ClientsReadOne(string readWhat, string Clientid)
	{
		DataTable dataTable = new DataTable();
		string result = "";

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return result;
		}
		try
		{
			string commandText = "SELECT " + readWhat + " FROM ClientsMap Where id =" + Clientid;
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return dataTable.Rows[0].ItemArray[0].ToString();
			}
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу прочитать даты записи номер " + Clientid + Environment.NewLine);
			return result;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при получении записи из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return result;
	}

	public DataTable ClientsSearchFIO(string FIO)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		DataTable dataTable = new DataTable();
		try
		{
			if (DbContext.Instance.State != ConnectionState.Open)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
				return dataTable;
			}
			string commandText = $"SELECT * FROM ClientsMap WHERE FIO LIKE'%{FIO.ToUpper()}%'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
		}
		catch (Exception ex)
		{
			MessageBox.Show("Что-то пошло не так при проведении поиска" + Environment.NewLine + ex.ToString());
		}
		return dataTable;
	}

	public string barcodeLastDigit(string barcode11)
	{
		string text = barcode11.Substring(0, 11);
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < text.Length; i++)
		{
			if (i % 2 == 0)
			{
				num2 += int.Parse(text.Substring(i, 1)) * 3;
			}
			else
			{
				num += int.Parse(text.Substring(i, 1));
			}
		}
		int num3 = num + num2;
		int num4 = num3 % 10;
		num4 = 10 - num4;
		if (num4 == 10)
		{
			num4 = 0;
		}
		return text + num4.ToString()[0].ToString();
	}

	public void bdBarcodeAllGenerator()
	{
		DataTable dataTable = mainForm.basa.BdReadAll();
		List<VirtualClient> list = new List<VirtualClient>();
		if (dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				list.Add(new VirtualClient(dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString(), dataTable.Rows[i].ItemArray[5].ToString(), dataTable.Rows[i].ItemArray[6].ToString(), dataTable.Rows[i].ItemArray[7].ToString(), dataTable.Rows[i].ItemArray[8].ToString(), dataTable.Rows[i].ItemArray[9].ToString(), dataTable.Rows[i].ItemArray[10].ToString(), dataTable.Rows[i].ItemArray[11].ToString(), dataTable.Rows[i].ItemArray[12].ToString(), dataTable.Rows[i].ItemArray[13].ToString(), dataTable.Rows[i].ItemArray[14].ToString(), dataTable.Rows[i].ItemArray[15].ToString(), dataTable.Rows[i].ItemArray[16].ToString(), dataTable.Rows[i].ItemArray[17].ToString(), dataTable.Rows[i].ItemArray[18].ToString(), dataTable.Rows[i].ItemArray[19].ToString(), dataTable.Rows[i].ItemArray[20].ToString(), dataTable.Rows[i].ItemArray[21].ToString(), dataTable.Rows[i].ItemArray[22].ToString(), dataTable.Rows[i].ItemArray[23].ToString(), dataTable.Rows[i].ItemArray[24].ToString(), dataTable.Rows[i].ItemArray[25].ToString(), dataTable.Rows[i].ItemArray[26].ToString(), true, dataTable.Rows[i].ItemArray[27].ToString(), dataTable.Rows[i].ItemArray[28].ToString(), -1, dataTable.Rows[i].ItemArray[30].ToString()));
			}
		}
		DbCommand m_sqlCmd = DbContext.Instance.Command();
		//m_sqlCmd.ExecuteNonQuery();

		Random random = new Random();
		Random random2 = new Random();
		Random random3 = new Random();
		foreach (VirtualClient item in list)
		{
			if (item.Barcode == "")
			{
				if (DbContext.Instance.State != ConnectionState.Open)
				{
					MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
					return;
				}
				try
				{
					string str = random.Next(1111, 9999).ToString();
					string str2 = random2.Next(1111, 9999).ToString();
					string str3 = random3.Next(333, 999).ToString();
					string barcode = str + str2 + str3;
					barcode = barcodeLastDigit(barcode);
					m_sqlCmd.CommandText = $"UPDATE Catalog SET Barcode = '{barcode}' WHERE ID = {item.Id}";
					m_sqlCmd.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
				}
			}
		}

		DbContext.Instance.Command("end", m_sqlCmd.Connection).ExecuteNonQuery();
	}

	public void HistoryBDTable_Create()
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();
		try
		{



			m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS HistoryBD(id INTEGER PRIMARY KEY AUTO_INCREMENT, WHO TEXT, WHAT TEXT, FULLWHAT TEXT, DATA TEXT, IDINCATALOG TEXT)";
			m_sqlCmd.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу установить соединение с базой данных " + ex.ToString() + Environment.NewLine);
		}
	}

	public DataTable HISTORYSearchFIO(string FIO = "", string Date = "", string WHAT_HistoryBD = "", string WHO_HistoryBD = "")
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		DataTable dataTable = new DataTable();
		try
		{
			if (DbContext.Instance.State != ConnectionState.Open)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
				return dataTable;
			}
			string commandText = $"SELECT hbd.*,clmap.FIO, cat.* FROM Catalog cat JOIN ClientsMap clmap ON cat.clientID = clmap.id JOIN HistoryBD hbd ON cat.id = hbd.IDINCATALOG WHERE hbd.WHO LIKE'%{FIO.ToUpper().Trim()}%' AND hbd.WHO LIKE'%{WHO_HistoryBD.ToUpper()}%' AND hbd.WHAT LIKE'%{WHAT_HistoryBD.ToUpper()}%' AND hbd.DATA LIKE'%{Date}%'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
		}
		catch (Exception ex)
		{
			MessageBox.Show("Что-то пошло не так при проведении поиска" + Environment.NewLine + ex.ToString());
		}
		return dataTable;
	}

	public void HistoryBDWrite(string WHO, string WHAT, string FULLWHAT, string IDINCATALOG, string DATA = "")
	{
		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				string text = (DATA == "") ? DateTime.Now.ToString("dd-MM-yyyy HH:mm") : DATA;

				var m_sqlCmd = DbContext.Instance.Command();
				m_sqlCmd.CommandText = "INSERT INTO HistoryBD (WHO,WHAT,FULLWHAT,IDINCATALOG,DATA) values ('" + WHO.Trim().ToUpper() + "' , '" + WHAT.Trim().ToUpper() + "', '" + FULLWHAT.Trim() + "', '" + IDINCATALOG.Trim() + "', '" + text + "')";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void UsersTable_Create()
	{
		DbCommand m_sqlCmd = DbContext.Instance.Command();
		try
		{
			m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Users(id INTEGER PRIMARY KEY AUTO_INCREMENT, type TEXT, name TEXT, id_gruppi_dostupa TEXT, user_pwd TEXT)";
			m_sqlCmd.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу установить соединение с базой данных " + ex.ToString() + Environment.NewLine);
		}
	}

	public void UsersBDWrite(string type, string name, string id_gruppi_dostupa, string user_pwd)
	{
		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				var m_sqlCmd = DbContext.Instance.Command();
				m_sqlCmd.CommandText = "INSERT INTO Users (type,name,id_gruppi_dostupa,user_pwd) values ('" + type.Trim() + "' , '" + name.Trim() + "', '" + id_gruppi_dostupa + "', '" + user_pwd + "')";
				var res = m_sqlCmd.ExecuteNonQuery();
				int test = 0;
				test++;
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void UsersBdEditPassword(string EditWhat, string EditThis, string name)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = string.Format("UPDATE Users SET " + EditWhat + " ='" + EditThis.Trim() + "' WHERE name = '{0}'", name);
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public DataTable UsersBdRead()
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = "SELECT * FROM users";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public DataTable UsersBdRead(string name)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = $"SELECT * FROM users WHERE name = '{name}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public void UserDelete(string userName)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = $"DELETE FROM users WHERE name = '{userName}'";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void UserBdEditAll(string type, string name, string id_gruppi_dostupa)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE users SET type ='" + type + "',name ='" + name + "',id_gruppi_dostupa ='" + id_gruppi_dostupa + "' WHERE name = '" + name + "'";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public string UsersGetPass(string name)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return "-1";
		}
		try
		{
			string commandText = $"SELECT user_pwd FROM users WHERE name = '{name}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return dataTable.Rows[0].ItemArray[0].ToString();
			}
			return "-1";
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return "-1";
	}

	public string UsersGetGroupIdByUserName(string name)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return "-1";
		}
		try
		{
			string commandText = $"SELECT id_gruppi_dostupa FROM users WHERE name = '{name}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return dataTable.Rows[0].ItemArray[0].ToString();
			}
			return "-1";
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return "-1";
	}

	public void GroupDostupTable_Create()
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();
		try
		{



			m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS GroupDostup(id INTEGER PRIMARY KEY AUTO_INCREMENT, grName TEXT, delZapis TEXT, addZapis  TEXT, saveZapis TEXT, graf TEXT, sms TEXT, stock TEXT, clients TEXT, stockAdd TEXT, stockDel TEXT, stockEdit TEXT, clientAdd TEXT, clientDel TEXT, clientConcat TEXT, settings TEXT, dates TEXT, editDates TEXT)";
			m_sqlCmd.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Не могу установить соединение с базой данных " + ex.ToString() + Environment.NewLine);
		}
	}

	public void GroupDostupBDWrite(string grName, string delZapis, string addZapis, string saveZapis, string graf, string sms, string stock, string clients, string stockAdd, string stockDel, string stockEdit, string clientAdd, string clientDel, string clientConcat, string settings, string dates, string editDates)
	{
		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				var m_sqlCmd = DbContext.Instance.Command();
				m_sqlCmd.CommandText = "INSERT INTO GroupDostup (grName,delZapis,addZapis,saveZapis,graf,sms,stock,clients,stockAdd,stockDel,stockEdit,clientAdd,clientDel,clientConcat,settings,dates,editDates) values ('" + grName + "' , '" + delZapis + "', '" + addZapis + "', '" + saveZapis + "', '" + graf + "', '" + sms + "', '" + stock + "', '" + clients + "', '" + stockAdd + "', '" + stockDel + "', '" + stockEdit + "', '" + clientAdd + "', '" + clientDel + "', '" + clientConcat + "', '" + settings + "', '" + dates + "', '" + editDates + "')";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void GroupDostupBdEditOne(string EditWhat, string EditThis, string id_in_Usersbd)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE GroupDostup SET " + EditWhat + " ='" + EditThis + "' WHERE ID = " + id_in_Usersbd;
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public void GroupDostupBdEditAll(string grName, string delZapis, string addZapis, string saveZapis, string graf, string sms, string stock, string clients, string stockAdd, string stockDel, string stockEdit, string clientAdd, string clientDel, string clientConcat, string settings, string dates, string editDates)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = "UPDATE GroupDostup SET delZapis ='" + delZapis + "',addZapis ='" + addZapis + "',saveZapis ='" + saveZapis + "',graf ='" + graf + "',sms ='" + sms + "',stock ='" + stock + "',clients ='" + clients + "',stockAdd ='" + stockAdd + "',stockDel ='" + stockDel + "',stockEdit ='" + stockEdit + "',clientAdd ='" + clientAdd + "',clientDel ='" + clientDel + "',clientConcat ='" + clientConcat + "',settings ='" + settings + "',dates ='" + dates + "',editDates ='" + editDates + "' WHERE grName = '" + grName + "'";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public DataTable GroupDostupBdRead()
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = "SELECT * FROM GroupDostup";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public DataTable GroupDostupBdRead(string grName)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return dataTable;
		}
		try
		{
			string commandText = $"SELECT * FROM GroupDostup WHERE grName = '{grName}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return dataTable;
	}

	public string GroupDostupGetIdByGrNameBdRead(string grName)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return "-1";
		}
		try
		{
			string commandText = $"SELECT id FROM GroupDostup WHERE grName = '{grName}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return dataTable.Rows[0].ItemArray[0].ToString();
			}
			return "-1";
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return "-1";
	}

	public string GroupDostupGetgrNameByIdBdRead(string id)
	{
		DataTable dataTable = new DataTable();

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
			return "-1";
		}
		try
		{
			string commandText = $"SELECT grName FROM GroupDostup WHERE id = '{id}'";
			var dataAdapter = DbContext.Instance.DataAdapter(commandText);
			dataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				return dataTable.Rows[0].ItemArray[0].ToString();
			}
			return "-1";
		}
		catch (Exception ex)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при чтении из базы данных " + ex.ToString() + Environment.NewLine);
		}
		return "-1";
	}

	public void GroupDostupDelete(string grName)
	{

		DbCommand m_sqlCmd = DbContext.Instance.Command();



		if (DbContext.Instance.State != ConnectionState.Open)
		{
			MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Соединение с базой данных потеряно, установите соединение" + Environment.NewLine);
		}
		else
		{
			try
			{
				m_sqlCmd.CommandText = $"DELETE FROM GroupDostup WHERE grName = '{grName}'";
				m_sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(DateTime.Now.ToShortTimeString() + ": Что-то пошло не так, при записи в базу данных " + ex.ToString() + Environment.NewLine);
			}
		}
	}
}
