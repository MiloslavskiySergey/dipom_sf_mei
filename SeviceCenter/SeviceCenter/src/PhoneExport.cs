// PhoneExport


public class PhoneExport
{
	public string Phone;

	public string FIO;

	public PhoneExport(string phone, string fio)
	{
		Phone = phone;
		FIO = fio;
	}

	public override bool Equals(object obj)
	{
		return ((PhoneExport)obj).Phone == Phone;
	}

	public override int GetHashCode()
	{
		return Phone.GetHashCode();
	}
}
