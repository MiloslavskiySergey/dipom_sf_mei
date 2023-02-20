// SmsInfo

using System.Collections.Generic;

public class SmsInfo
{
	public string status
	{
		get;
		set;
	}

	public int status_code
	{
		get;
		set;
	}

	public Dictionary<long, SmsStatus> sms
	{
		get;
		set;
	}

	public float balance
	{
		get;
		set;
	}
}
