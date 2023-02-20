// TemporaryBase

using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

public static class TemporaryBase
{
	private static IniFile INIF = new IniFile("Config.ini");

	public static BDWorker basa;

	public static Form1 mainForm;

	public static string FIO = "";

	public static string Phone = "";

	public static string TypeOf = "";

	public static string Brand = "";

	public static string Model = "";

	public static string Status = "";

	public static string Master = "";

	public static bool SearchInOld = true;

	public static string NeedZakaz = "";

	public static int ColumnIndex = 0;

	public static bool SortAscending = false;

	public static bool FullSearchOpen = false;

	public static string soglasovat = "";

	public static string idinBd = "";

	public static string SerialImei = "";

	public static string AdressSC = "";

	public static bool IskatVseVidannoe = false;

	public static int startIndex = 0;

	public static int endIndex = 0;

	public static string valuta = "";

	public static string UserKey = "FREEUSER";

	public static string AdressSCDefault = "";

	public static string MasterDefault = "";

	public static bool diagnostika = false;

	public static string everyDayBackup = "Checked";

	public static string BlistColor = "";

	public static bool Poloski = true;

	public static int barcodeW = 180;

	public static int barcodeH = 40;

	public static string USER_SESSION = "Admin";

	public static bool openClientFolder = false;

	public static string delZapis = "1";

	public static string addZapis = "1";

	public static string saveZapis = "1";

	public static string graf = "1";

	public static string sms = "1";

	public static string stock = "1";

	public static string clients = "1";

	public static string stockAdd = "1";

	public static string stockDel = "1";

	public static string stockEdit = "1";

	public static string clientAdd = "1";

	public static string clientDel = "1";

	public static string clientConcat = "1";

	public static string settings = "1";

	public static string dates = "1";

	public static string editDates = "1";

	public static string pathtoSaveBD = "settings/backup/";

	public static void SearchCleaner()
	{
		FIO = "";
		Phone = "";
		TypeOf = "";
		Brand = "";
		Model = "";
		Status = "";
		Master = "";
		SearchInOld = true;
		NeedZakaz = "";
		ColumnIndex = 0;
		SortAscending = false;
		FullSearchOpen = false;
		soglasovat = "";
		SerialImei = "";
		AdressSC = "";
		idinBd = "";
	}

	public static void SearchFULLBegin(string phoneSearchInOld = "")
	{
		try
		{
			mainForm.MainListView.Items.Clear();
			mainForm.VCList.Clear();
			DataTable dataTable;
			if (Status == "")
			{
				dataTable = mainForm.basa.BdReadFullSearch(FIO, Phone, TypeOf, Brand, Model, Status, Master, NeedZakaz, SearchInOld, idinBd, SerialImei, AdressSC, "", soglasovat);
			}
			else if (Status == "Выдан")
			{
				IskatVseVidannoe = false;
				dataTable = mainForm.basa.BdReadFullSearch(FIO, Phone, TypeOf, Brand, Model, Status, Master, NeedZakaz, SearchInOld, idinBd, SerialImei, AdressSC, "garanty", soglasovat, IskatVseVidannoe);
			}
			else
			{
				dataTable = mainForm.basa.BdReadFullSearch(FIO, Phone, TypeOf, Brand, Model, Status, Master, NeedZakaz, SearchInOld, idinBd, SerialImei, AdressSC, "garanty", soglasovat);
			}
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				VirtualClient virtualClient = new VirtualClient(dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[1].ToString(), dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString(), dataTable.Rows[i].ItemArray[5].ToString(), dataTable.Rows[i].ItemArray[6].ToString(), dataTable.Rows[i].ItemArray[7].ToString(), dataTable.Rows[i].ItemArray[8].ToString(), dataTable.Rows[i].ItemArray[9].ToString(), dataTable.Rows[i].ItemArray[10].ToString(), dataTable.Rows[i].ItemArray[11].ToString(), dataTable.Rows[i].ItemArray[12].ToString(), dataTable.Rows[i].ItemArray[13].ToString(), dataTable.Rows[i].ItemArray[14].ToString(), dataTable.Rows[i].ItemArray[15].ToString(), dataTable.Rows[i].ItemArray[16].ToString(), dataTable.Rows[i].ItemArray[17].ToString(), dataTable.Rows[i].ItemArray[18].ToString(), dataTable.Rows[i].ItemArray[19].ToString(), dataTable.Rows[i].ItemArray[20].ToString(), dataTable.Rows[i].ItemArray[21].ToString(), dataTable.Rows[i].ItemArray[22].ToString(), dataTable.Rows[i].ItemArray[23].ToString(), dataTable.Rows[i].ItemArray[24].ToString(), dataTable.Rows[i].ItemArray[25].ToString(), dataTable.Rows[i].ItemArray[26].ToString(), diagnostika, dataTable.Rows[i].ItemArray[27].ToString(), dataTable.Rows[i].ItemArray[28].ToString(), -1, dataTable.Rows[i].ItemArray[29].ToString());
				if (mainForm.ReadyFilterCheckBox.BackColor == Color.FromArgb(240, 240, 240))
				{
					if (virtualClient.Status_remonta != "Готов" || virtualClient.Data_vidachi != "")
					{
						if (mainForm.ServiceAdressComboBox.Text != "")
						{
							if (virtualClient.AdressSC == mainForm.ServiceAdressComboBox.Text.ToUpper())
							{
								mainForm.VCList.Add(virtualClient);
							}
						}
						else
						{
							mainForm.VCList.Add(virtualClient);
						}
					}
				}
				else if (mainForm.ServiceAdressComboBox.Text != "")
				{
					if (virtualClient.AdressSC == mainForm.ServiceAdressComboBox.Text.ToUpper())
					{
						mainForm.VCList.Add(virtualClient);
					}
				}
				else
				{
					mainForm.VCList.Add(virtualClient);
				}
			}
			try
			{
				if (ColumnIndex == 0)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => int.Parse(vc1.Id).CompareTo(int.Parse(vc2.Id)));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => int.Parse(vc2.Id).CompareTo(int.Parse(vc1.Id)));
					}
				}
				else if (ColumnIndex == 1)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							string text11 = vc1.Data_priema;
							string text12 = vc2.Data_priema;
							if (text11 == "")
							{
								text11 = "01.01.1970";
							}
							if (text12 == "")
							{
								text12 = "01.01.1970";
							}
							return DateTime.Parse(text12).CompareTo(DateTime.Parse(text11));
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							string text9 = vc1.Data_priema;
							string text10 = vc2.Data_priema;
							if (text9 == "")
							{
								text9 = "01.01.1970";
							}
							if (text10 == "")
							{
								text10 = "01.01.1970";
							}
							return DateTime.Parse(text9).CompareTo(DateTime.Parse(text10));
						});
					}
				}
				else if (ColumnIndex == 2)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							string text7 = vc1.Data_vidachi;
							string text8 = vc2.Data_vidachi;
							if (text7 == "")
							{
								text7 = "01.01.1970";
							}
							if (text8 == "")
							{
								text8 = "01.01.1970";
							}
							return DateTime.Parse(text7).CompareTo(DateTime.Parse(text8));
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							string text5 = vc1.Data_vidachi;
							string text6 = vc2.Data_vidachi;
							if (text5 == "")
							{
								text5 = "01.01.1970";
							}
							if (text6 == "")
							{
								text6 = "01.01.1970";
							}
							return DateTime.Parse(text6).CompareTo(DateTime.Parse(text5));
						});
					}
				}
				else if (ColumnIndex == 3)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							string text3 = vc1.Data_predoplaty;
							string text4 = vc2.Data_predoplaty;
							if (text3 == "")
							{
								text3 = "01.01.1970";
							}
							if (text4 == "")
							{
								text4 = "01.01.1970";
							}
							return DateTime.Parse(text3).CompareTo(DateTime.Parse(text4));
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							string text = vc1.Data_predoplaty;
							string text2 = vc2.Data_predoplaty;
							if (text == "")
							{
								text = "01.01.1970";
							}
							if (text2 == "")
							{
								text2 = "01.01.1970";
							}
							return DateTime.Parse(text2).CompareTo(DateTime.Parse(text));
						});
					}
				}
				else if (ColumnIndex == 4)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Surname.CompareTo(vc1.Surname));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Surname.CompareTo(vc2.Surname));
					}
				}
				else if (ColumnIndex == 5)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Phone.CompareTo(vc1.Phone));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Phone.CompareTo(vc2.Phone));
					}
				}
				else if (ColumnIndex == 6)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.AboutUs.CompareTo(vc1.AboutUs));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.AboutUs.CompareTo(vc2.AboutUs));
					}
				}
				else if (ColumnIndex == 7)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.WhatRemont.CompareTo(vc1.WhatRemont));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.WhatRemont.CompareTo(vc2.WhatRemont));
					}
				}
				else if (ColumnIndex == 8)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Brand.CompareTo(vc1.Brand));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Brand.CompareTo(vc2.Brand));
					}
				}
				else if (ColumnIndex == 9)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Model.CompareTo(vc1.Model));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Model.CompareTo(vc2.Model));
					}
				}
				else if (ColumnIndex == 10)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.SerialNumber.CompareTo(vc1.SerialNumber));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.SerialNumber.CompareTo(vc2.SerialNumber));
					}
				}
				else if (ColumnIndex == 11)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Sostoyanie.CompareTo(vc1.Sostoyanie));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Sostoyanie.CompareTo(vc2.Sostoyanie));
					}
				}
				else if (ColumnIndex == 12)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Komplektonst.CompareTo(vc1.Komplektonst));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Komplektonst.CompareTo(vc2.Komplektonst));
					}
				}
				else if (ColumnIndex == 13)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Polomka.CompareTo(vc1.Polomka));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Polomka.CompareTo(vc2.Polomka));
					}
				}
				else if (ColumnIndex == 14)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Kommentarij.CompareTo(vc1.Kommentarij));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Kommentarij.CompareTo(vc2.Kommentarij));
					}
				}
				else if (ColumnIndex == 15)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int value10 = (!(vc1.Predvaritelnaya_stoimost == "")) ? int.Parse(vc1.Predvaritelnaya_stoimost) : 0;
							return ((!(vc2.Predvaritelnaya_stoimost == "")) ? int.Parse(vc2.Predvaritelnaya_stoimost) : 0).CompareTo(value10);
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int num5 = (!(vc1.Predvaritelnaya_stoimost == "")) ? int.Parse(vc1.Predvaritelnaya_stoimost) : 0;
							int value9 = (!(vc2.Predvaritelnaya_stoimost == "")) ? int.Parse(vc2.Predvaritelnaya_stoimost) : 0;
							return num5.CompareTo(value9);
						});
					}
				}
				else if (ColumnIndex == 16)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int value8 = (!(vc1.Predoplata == "")) ? int.Parse(vc1.Predoplata) : 0;
							return ((!(vc2.Predoplata == "")) ? int.Parse(vc2.Predoplata) : 0).CompareTo(value8);
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int num4 = (!(vc1.Predoplata == "")) ? int.Parse(vc1.Predoplata) : 0;
							int value7 = (!(vc2.Predoplata == "")) ? int.Parse(vc2.Predoplata) : 0;
							return num4.CompareTo(value7);
						});
					}
				}
				else if (ColumnIndex == 17)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int value6 = (!(vc1.Zatrati == "")) ? int.Parse(vc1.Zatrati) : 0;
							return ((!(vc2.Zatrati == "")) ? int.Parse(vc2.Zatrati) : 0).CompareTo(value6);
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int num3 = (!(vc1.Zatrati == "")) ? int.Parse(vc1.Zatrati) : 0;
							int value5 = (!(vc2.Zatrati == "")) ? int.Parse(vc2.Zatrati) : 0;
							return num3.CompareTo(value5);
						});
					}
				}
				else if (ColumnIndex == 18)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int value4 = (!(vc1.Okonchatelnaya_stoimost_remonta == "")) ? int.Parse(vc1.Okonchatelnaya_stoimost_remonta) : 0;
							return ((!(vc2.Okonchatelnaya_stoimost_remonta == "")) ? int.Parse(vc2.Okonchatelnaya_stoimost_remonta) : 0).CompareTo(value4);
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int num2 = (!(vc1.Okonchatelnaya_stoimost_remonta == "")) ? int.Parse(vc1.Okonchatelnaya_stoimost_remonta) : 0;
							int value3 = (!(vc2.Okonchatelnaya_stoimost_remonta == "")) ? int.Parse(vc2.Okonchatelnaya_stoimost_remonta) : 0;
							return num2.CompareTo(value3);
						});
					}
				}
				else if (ColumnIndex == 19)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int value2 = (!(vc1.Skidka == "")) ? int.Parse(vc1.Skidka) : 0;
							return ((!(vc2.Skidka == "")) ? int.Parse(vc2.Skidka) : 0).CompareTo(value2);
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int num = (!(vc1.Skidka == "")) ? int.Parse(vc1.Skidka) : 0;
							int value = (!(vc2.Skidka == "")) ? int.Parse(vc2.Skidka) : 0;
							return num.CompareTo(value);
						});
					}
				}
				else if (ColumnIndex == 20)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Status_remonta.CompareTo(vc1.Status_remonta));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Status_remonta.CompareTo(vc2.Status_remonta));
					}
				}
				else if (ColumnIndex == 21)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Master.CompareTo(vc1.Master));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Master.CompareTo(vc2.Master));
					}
				}
				else if (ColumnIndex == 22)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Vipolnenie_raboti.CompareTo(vc1.Vipolnenie_raboti));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Vipolnenie_raboti.CompareTo(vc2.Vipolnenie_raboti));
					}
				}
				else if (ColumnIndex == 23)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Garanty.CompareTo(vc1.Garanty));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Garanty.CompareTo(vc2.Garanty));
					}
				}
				else if (ColumnIndex == 24)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Wait_zakaz.CompareTo(vc1.Wait_zakaz));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Wait_zakaz.CompareTo(vc2.Wait_zakaz));
					}
				}
				else if (ColumnIndex == 25)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Adress.CompareTo(vc1.Adress));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Adress.CompareTo(vc2.Adress));
					}
				}
				else if (ColumnIndex == 26)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Adress.CompareTo(vc1.Adress));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Adress.CompareTo(vc2.Adress));
					}
				}
				else if (ColumnIndex == 27)
				{
					if (SortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Adress.CompareTo(vc1.Adress));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Adress.CompareTo(vc2.Adress));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			mainForm.MainListView.VirtualListSize = mainForm.VCList.Count;
			if (mainForm.MainListView.VirtualListSize > 0)
			{
				mainForm.MainListView.VirtualListSize = mainForm.MainListView.VirtualListSize - 1;
				mainForm.MainListView.VirtualListSize = mainForm.MainListView.VirtualListSize + 1;
			}
			mainForm.CountListViewLabel.Text = "Найдено записей: " + mainForm.VCList.Count;
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.ToString());
		}
	}

	public static string GetMd5Hash(MD5 md5Hash, string input)
	{
		byte[] array = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
	{
		string md5Hash2 = GetMd5Hash(md5Hash, input);
		StringComparer ordinalIgnoreCase = StringComparer.OrdinalIgnoreCase;
		if (ordinalIgnoreCase.Compare(md5Hash2, hash) == 0)
		{
			return true;
		}
		return false;
	}
}
