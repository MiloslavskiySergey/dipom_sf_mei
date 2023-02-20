// Program

using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Process process = RI();
		if (process != null)
		{
			MessageBox.Show("База данных уже запущена", "Учёт в сервисном центре");
		}
		else
		{
			Application.Run(new Form1());
		}
	}

	public static Process RI()
	{
		Process currentProcess = Process.GetCurrentProcess();
		Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
		Process[] array = processesByName;
		foreach (Process process in array)
		{
			if (process.Id != currentProcess.Id && Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == currentProcess.MainModule.FileName)
			{
				return process;
			}
		}
		return null;
	}
}
