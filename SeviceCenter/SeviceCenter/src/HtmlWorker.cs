// HtmlWorker
using HtmlAgilityPack;
using System;
using System.Windows.Forms;

internal class HtmlWorker
{
	private string FirmName = "";

	private string FirmPhone = "";

	private string FirmDannie = "";

	private string FirmUrDannie = "";

	private string FirmDogovor = "";

	public string firmName
	{
		get
		{
			return FirmName;
		}
		set
		{
		}
	}

	public string firmPhone
	{
		get
		{
			return FirmPhone;
		}
		set
		{
		}
	}

	public string firmDannie
	{
		get
		{
			return FirmDannie;
		}
		set
		{
		}
	}

	public string firmUrDannie
	{
		get
		{
			return FirmUrDannie;
		}
		set
		{
		}
	}

	public string firmDogovor
	{
		get
		{
			return FirmDogovor;
		}
		set
		{
		}
	}

	public void ParseShablon(string Shablon)
	{
		try
		{
			HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
			htmlDocument.LoadHtml(Shablon);
			FirmName = htmlDocument.GetElementbyId("ServiceName").InnerHtml;
			FirmPhone = htmlDocument.GetElementbyId("phone").InnerHtml;
			FirmDannie = htmlDocument.GetElementbyId("Dannie").InnerHtml;
			FirmUrDannie = htmlDocument.GetElementbyId("UrDannie").InnerHtml;
			FirmDogovor = htmlDocument.GetElementbyId("Dogovor").InnerHtml;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}
}
