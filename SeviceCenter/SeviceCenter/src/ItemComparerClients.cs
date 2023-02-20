// ItemComparerClients

using System;
using System.Collections;
using System.Windows.Forms;

public class ItemComparerClients : IComparer
{
	private int columnIndex = 0;

	private ClientsEditor ClientsForm;

	private bool sortAscending = false;

	public int ColumnIndex
	{
		set
		{
			if (columnIndex == value)
			{
				sortAscending = !sortAscending;
			}
			else
			{
				columnIndex = value;
				sortAscending = true;
			}
			try
			{
				if (columnIndex == 0)
				{
					if (sortAscending)
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => int.Parse(vc2.id).CompareTo(int.Parse(vc1.id)));
					}
					else
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => int.Parse(vc1.id).CompareTo(int.Parse(vc2.id)));
					}
				}
				else if (columnIndex == 1)
				{
					if (sortAscending)
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc2.FIO.CompareTo(vc1.FIO));
					}
					else
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc1.FIO.CompareTo(vc2.FIO));
					}
				}
				else if (columnIndex == 2)
				{
					if (sortAscending)
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc2.Phone.CompareTo(vc1.Phone));
					}
					else
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc1.Phone.CompareTo(vc2.Phone));
					}
				}
				else if (columnIndex == 3)
				{
					if (sortAscending)
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc2.Adress.CompareTo(vc1.Adress));
					}
					else
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc1.Adress.CompareTo(vc2.Adress));
					}
				}
				else if (columnIndex == 4)
				{
					if (sortAscending)
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc2.AboutUs.CompareTo(vc1.AboutUs));
					}
					else
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc1.AboutUs.CompareTo(vc2.AboutUs));
					}
				}
				else if (columnIndex == 5)
				{
					if (sortAscending)
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc2.Blist.CompareTo(vc1.Blist));
					}
					else
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc1.Blist.CompareTo(vc2.Blist));
					}
				}
				else if (columnIndex == 6)
				{
					if (sortAscending)
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc2.Primechanie.CompareTo(vc1.Primechanie));
					}
					else
					{
						ClientsForm.ClientsList.Sort((KlientBase vc1, KlientBase vc2) => vc1.Primechanie.CompareTo(vc2.Primechanie));
					}
				}
				else if (columnIndex == 7)
				{
					if (sortAscending)
					{
						ClientsForm.ClientsList.Sort(delegate(KlientBase vc1, KlientBase vc2)
						{
							string text3 = vc1.Date;
							string text4 = vc2.Date;
							if (text3 == "")
							{
								text3 = "01.01.1970";
							}
							if (text4 == "")
							{
								text4 = "01.01.1970";
							}
							return DateTime.Parse(text4).CompareTo(DateTime.Parse(text3));
						});
					}
					else
					{
						ClientsForm.ClientsList.Sort(delegate(KlientBase vc1, KlientBase vc2)
						{
							string text = vc1.Date;
							string text2 = vc2.Date;
							if (text == "")
							{
								text = "01.01.1970";
							}
							if (text2 == "")
							{
								text2 = "01.01.1970";
							}
							return DateTime.Parse(text).CompareTo(DateTime.Parse(text2));
						});
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при сортировке " + Environment.NewLine + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public ItemComparerClients(ClientsEditor cm)
	{
		ClientsForm = cm;
	}

	public int Compare(object x, object y)
	{
		KlientBase klientBase = (KlientBase)x;
		KlientBase klientBase2 = (KlientBase)y;
		if (int.Parse(klientBase.id) < int.Parse(klientBase2.id))
		{
			return -1;
		}
		if (int.Parse(klientBase.id) > int.Parse(klientBase2.id))
		{
			return 1;
		}
		return 0;
	}
}
