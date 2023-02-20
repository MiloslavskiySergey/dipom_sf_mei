// IniFile
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

internal class IniFile
{
	private string Path;

	[DllImport("kernel32")]
	private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

	[DllImport("kernel32")]
	private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

	public IniFile(string IniPath)
	{
		Path = new FileInfo(Application.StartupPath.ToString() + "\\" + IniPath).ToString();
	}

	public string ReadINI(string Section, string Key)
	{
		StringBuilder stringBuilder = new StringBuilder(255);
		GetPrivateProfileString(Section, Key, "", stringBuilder, 255, Path);
		return stringBuilder.ToString();
	}

	public void WriteINI(string Section, string Key, string Value)
	{
		WritePrivateProfileString(Section, Key, Value, Path);
	}

	public void DeleteKey(string Key, string Section = null)
	{
		WriteINI(Section, Key, null);
	}

	public void DeleteSection(string Section = null)
	{
		WriteINI(Section, null, null);
	}

	public bool KeyExists(string Section, string Key)
	{
		return ReadINI(Section, Key).Length > 0;
	}
}
