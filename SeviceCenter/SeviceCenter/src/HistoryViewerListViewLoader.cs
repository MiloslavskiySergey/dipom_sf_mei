// HistoryViewerListViewLoader
using System;

public class HistoryViewerListViewLoader
{
	public string id = "";

	public string WHO = "";

	public string WHAT = "";

	public string FULLWHAT = "";

	public DateTime data = default(DateTime);

	public HistoryViewerListViewLoader(string id, string WHO, string WHAT, string FULLWHAT, string data)
	{
		this.id = id;
		this.WHO = WHO;
		this.WHAT = WHAT;
		this.FULLWHAT = FULLWHAT;
		this.data = DateTime.Parse(data);
	}
}
