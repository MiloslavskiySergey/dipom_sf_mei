// itemComparerStock

using System;
using System.Collections;
using System.Windows.Forms;

public class itemComparerStock : IComparer
{
	private int columnIndex = 0;

	private Stock mainForm;

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
				if (columnIndex != 0)
				{
					if (columnIndex == 1)
					{
						if (!sortAscending)
						{
						}
					}
					else if (columnIndex != 2)
					{
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при сортировке " + Environment.NewLine + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public itemComparerStock(Stock fm)
	{
		mainForm = fm;
	}

	public int Compare(object x, object y)
	{
		return 0;
	}
}
