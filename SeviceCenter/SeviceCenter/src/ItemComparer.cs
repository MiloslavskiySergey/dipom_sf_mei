// ItemComparer

using System;
using System.Collections;
using System.Windows.Forms;

internal class ItemComparer : IComparer
{
	private int columnIndex = 0;

	private bool sortAscending = false;

	private Form1 mainForm;

	public int ColumnIndex
	{
		set
		{
			if (columnIndex == value)
			{
				sortAscending = !sortAscending;
				TemporaryBase.ColumnIndex = columnIndex;
				TemporaryBase.SortAscending = sortAscending;
			}
			else
			{
				columnIndex = value;
				sortAscending = true;
				TemporaryBase.ColumnIndex = columnIndex;
				TemporaryBase.SortAscending = sortAscending;
			}
			try
			{
				if (columnIndex == 0)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => int.Parse(vc2.Id).CompareTo(int.Parse(vc1.Id)));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => int.Parse(vc1.Id).CompareTo(int.Parse(vc2.Id)));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 1)
				{
					if (sortAscending)
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
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 2)
				{
					if (sortAscending)
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
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 3)
				{
					if (sortAscending)
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
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 4)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Surname.CompareTo(vc1.Surname));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Surname.CompareTo(vc2.Surname));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 5)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Phone.CompareTo(vc1.Phone));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Phone.CompareTo(vc2.Phone));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 6)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.AboutUs.CompareTo(vc1.AboutUs));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.AboutUs.CompareTo(vc2.AboutUs));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 7)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.WhatRemont.CompareTo(vc1.WhatRemont));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.WhatRemont.CompareTo(vc2.WhatRemont));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 8)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Brand.CompareTo(vc1.Brand));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Brand.CompareTo(vc2.Brand));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 9)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Model.CompareTo(vc1.Model));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Model.CompareTo(vc2.Model));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 10)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.SerialNumber.CompareTo(vc1.SerialNumber));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.SerialNumber.CompareTo(vc2.SerialNumber));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 11)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Sostoyanie.CompareTo(vc1.Sostoyanie));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Sostoyanie.CompareTo(vc2.Sostoyanie));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 12)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Komplektonst.CompareTo(vc1.Komplektonst));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Komplektonst.CompareTo(vc2.Komplektonst));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 13)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Polomka.CompareTo(vc1.Polomka));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Polomka.CompareTo(vc2.Polomka));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 14)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Kommentarij.CompareTo(vc1.Kommentarij));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Kommentarij.CompareTo(vc2.Kommentarij));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 15)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int value11 = (!(vc1.Predvaritelnaya_stoimost == "")) ? int.Parse(vc1.Predvaritelnaya_stoimost) : 0;
							return ((!(vc2.Predvaritelnaya_stoimost == "")) ? int.Parse(vc2.Predvaritelnaya_stoimost) : 0).CompareTo(value11);
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int num5 = (!(vc1.Predvaritelnaya_stoimost == "")) ? int.Parse(vc1.Predvaritelnaya_stoimost) : 0;
							int value10 = (!(vc2.Predvaritelnaya_stoimost == "")) ? int.Parse(vc2.Predvaritelnaya_stoimost) : 0;
							return num5.CompareTo(value10);
						});
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 16)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int value9 = (!(vc1.Predoplata == "")) ? int.Parse(vc1.Predoplata) : 0;
							return ((!(vc2.Predoplata == "")) ? int.Parse(vc2.Predoplata) : 0).CompareTo(value9);
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int num4 = (!(vc1.Predoplata == "")) ? int.Parse(vc1.Predoplata) : 0;
							int value8 = (!(vc2.Predoplata == "")) ? int.Parse(vc2.Predoplata) : 0;
							return num4.CompareTo(value8);
						});
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 17)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int value7 = (!(vc1.Zatrati == "")) ? int.Parse(vc1.Zatrati) : 0;
							return ((!(vc2.Zatrati == "")) ? int.Parse(vc2.Zatrati) : 0).CompareTo(value7);
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int num3 = (!(vc1.Zatrati == "")) ? int.Parse(vc1.Zatrati) : 0;
							int value6 = (!(vc2.Zatrati == "")) ? int.Parse(vc2.Zatrati) : 0;
							return num3.CompareTo(value6);
						});
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 18)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int value5 = (!(vc1.Okonchatelnaya_stoimost_remonta == "")) ? int.Parse(vc1.Okonchatelnaya_stoimost_remonta) : 0;
							return ((!(vc2.Okonchatelnaya_stoimost_remonta == "")) ? int.Parse(vc2.Okonchatelnaya_stoimost_remonta) : 0).CompareTo(value5);
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int num2 = (!(vc1.Okonchatelnaya_stoimost_remonta == "")) ? int.Parse(vc1.Okonchatelnaya_stoimost_remonta) : 0;
							int value4 = (!(vc2.Okonchatelnaya_stoimost_remonta == "")) ? int.Parse(vc2.Okonchatelnaya_stoimost_remonta) : 0;
							return num2.CompareTo(value4);
						});
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 19)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int value3 = (!(vc1.Skidka == "")) ? int.Parse(vc1.Skidka) : 0;
							return ((!(vc2.Skidka == "")) ? int.Parse(vc2.Skidka) : 0).CompareTo(value3);
						});
					}
					else
					{
						mainForm.VCList.Sort(delegate(VirtualClient vc1, VirtualClient vc2)
						{
							int num = (!(vc1.Skidka == "")) ? int.Parse(vc1.Skidka) : 0;
							int value2 = (!(vc2.Skidka == "")) ? int.Parse(vc2.Skidka) : 0;
							return num.CompareTo(value2);
						});
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 20)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Status_remonta.CompareTo(vc1.Status_remonta));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Status_remonta.CompareTo(vc2.Status_remonta));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 21)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Master.CompareTo(vc1.Master));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Master.CompareTo(vc2.Master));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 22)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Vipolnenie_raboti.CompareTo(vc1.Vipolnenie_raboti));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Vipolnenie_raboti.CompareTo(vc2.Vipolnenie_raboti));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 23)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Garanty.CompareTo(vc1.Garanty));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Garanty.CompareTo(vc2.Garanty));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 24)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Wait_zakaz.CompareTo(vc1.Wait_zakaz));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Wait_zakaz.CompareTo(vc2.Wait_zakaz));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 25)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Adress.CompareTo(vc1.Adress));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Adress.CompareTo(vc2.Adress));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 26)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Adress.CompareTo(vc1.Adress));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Adress.CompareTo(vc2.Adress));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
				else if (columnIndex == 27)
				{
					if (sortAscending)
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc2.Adress.CompareTo(vc1.Adress));
					}
					else
					{
						mainForm.VCList.Sort((VirtualClient vc1, VirtualClient vc2) => vc1.Adress.CompareTo(vc2.Adress));
					}
					TemporaryBase.ColumnIndex = columnIndex;
					TemporaryBase.SortAscending = sortAscending;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	}

	public ItemComparer(Form1 mf)
	{
		mainForm = mf;
	}

	public int Compare(object x, object y)
	{
		try
		{
			if (columnIndex == 0 || (columnIndex > 14 && columnIndex < 20))
			{
				int num = (!(((ListViewItem)x).SubItems[columnIndex].Text == "")) ? int.Parse(((ListViewItem)x).SubItems[columnIndex].Text) : (-1);
				int num2 = (!(((ListViewItem)y).SubItems[columnIndex].Text == "")) ? int.Parse(((ListViewItem)y).SubItems[columnIndex].Text) : (-1);
				return ((num > num2) ? 1 : (-1)) * (sortAscending ? 1 : (-1));
			}
			if (columnIndex > 0 && columnIndex != 2 && columnIndex < 4)
			{
				string text = ((ListViewItem)x).SubItems[columnIndex].Text;
				string text2 = ((ListViewItem)y).SubItems[columnIndex].Text;
				if (text == "")
				{
					text = "01.01.1970";
				}
				if (text2 == "")
				{
					text2 = "01.01.1970";
				}
				DateTime t = DateTime.Parse(text);
				DateTime t2 = DateTime.Parse(text2);
				return ((t > t2) ? 1 : (-1)) * (sortAscending ? 1 : (-1));
			}
			if (columnIndex == 2)
			{
				string text3 = ((ListViewItem)x).SubItems[columnIndex].Text;
				string text4 = ((ListViewItem)y).SubItems[columnIndex].Text;
				if (text3 == "")
				{
					text3 = "01.01.1970";
				}
				if (text4 == "")
				{
					text4 = "01.01.1970";
				}
				DateTime t3 = DateTime.Parse(text3);
				DateTime t4 = DateTime.Parse(text4);
				return ((t3 > t4) ? 1 : (-1)) * ((!sortAscending) ? 1 : (-1));
			}
			string text5 = ((ListViewItem)x).SubItems[columnIndex].Text;
			string text6 = ((ListViewItem)y).SubItems[columnIndex].Text;
			return string.Compare(text5, text6) * (sortAscending ? 1 : (-1));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
			return 0;
		}
	}
}
