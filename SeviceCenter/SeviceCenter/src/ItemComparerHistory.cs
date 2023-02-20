// ItemComparerHistory

using System;
using System.Collections;
using System.Windows.Forms;

public class ItemComparerHistory : IComparer
{
	private int columnIndex = 0;

	private bool sortAscending = false;

	private HistoryViewer hView;

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
						hView.HistoryList.Sort((HistoryViewerListViewLoader vc1, HistoryViewerListViewLoader vc2) => int.Parse(vc2.id).CompareTo(int.Parse(vc1.id)));
					}
					else
					{
						hView.HistoryList.Sort((HistoryViewerListViewLoader vc1, HistoryViewerListViewLoader vc2) => int.Parse(vc1.id).CompareTo(int.Parse(vc2.id)));
					}
				}
				else if (columnIndex == 1)
				{
					if (sortAscending)
					{
						hView.HistoryList.Sort((HistoryViewerListViewLoader vc1, HistoryViewerListViewLoader vc2) => vc2.WHO.CompareTo(vc1.WHO));
					}
					else
					{
						hView.HistoryList.Sort((HistoryViewerListViewLoader vc1, HistoryViewerListViewLoader vc2) => vc1.WHO.CompareTo(vc2.WHO));
					}
				}
				else if (columnIndex == 2)
				{
					if (sortAscending)
					{
						hView.HistoryList.Sort((HistoryViewerListViewLoader vc1, HistoryViewerListViewLoader vc2) => vc2.WHAT.CompareTo(vc1.WHAT));
					}
					else
					{
						hView.HistoryList.Sort((HistoryViewerListViewLoader vc1, HistoryViewerListViewLoader vc2) => vc1.WHAT.CompareTo(vc2.WHO));
					}
				}
				else if (columnIndex == 3)
				{
					if (sortAscending)
					{
						hView.HistoryList.Sort((HistoryViewerListViewLoader vc1, HistoryViewerListViewLoader vc2) => vc2.FULLWHAT.CompareTo(vc1.FULLWHAT));
					}
					else
					{
						hView.HistoryList.Sort((HistoryViewerListViewLoader vc1, HistoryViewerListViewLoader vc2) => vc1.FULLWHAT.CompareTo(vc2.FULLWHAT));
					}
				}
				else if (columnIndex == 4)
				{
					if (sortAscending)
					{
						hView.HistoryList.Sort((HistoryViewerListViewLoader vc1, HistoryViewerListViewLoader vc2) => vc2.data.CompareTo(vc1.data));
					}
					else
					{
						hView.HistoryList.Sort((HistoryViewerListViewLoader vc1, HistoryViewerListViewLoader vc2) => vc1.data.CompareTo(vc2.data));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при сортировке " + Environment.NewLine + ex.ToString() + Environment.NewLine);
			}
		}
	}

	public ItemComparerHistory(HistoryViewer hv)
	{
		hView = hv;
	}

	public int Compare(object x, object y)
	{
		HistoryViewerListViewLoader historyViewerListViewLoader = (HistoryViewerListViewLoader)x;
		HistoryViewerListViewLoader historyViewerListViewLoader2 = (HistoryViewerListViewLoader)y;
		if (int.Parse(historyViewerListViewLoader.id) < int.Parse(historyViewerListViewLoader2.id))
		{
			return -1;
		}
		if (int.Parse(historyViewerListViewLoader.id) > int.Parse(historyViewerListViewLoader2.id))
		{
			return 1;
		}
		return 0;
	}
}
