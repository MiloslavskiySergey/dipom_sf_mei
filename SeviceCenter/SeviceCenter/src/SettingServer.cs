using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeviceCenter.src
{

	public partial class SettingServer : Form
	{
		private Properties.Settings settings = Properties.Settings.Default;



		public SettingServer()
		{
			InitializeComponent();

			txtServerHost.Text = settings.DbServerHost;
			txtServerPort.Text = settings.DbServerPort.ToString();
			txtName.Text = settings.DbName;
			txtUserName.Text = settings.DbUserName;
			txtUserPassword.Text = settings.DbUserPassword;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			settings.DbServerHost = txtServerHost.Text;
			settings.DbServerPort = int.Parse(txtServerPort.Text);
			settings.DbName = txtName.Text;
			settings.DbUserName = txtUserName.Text;
			settings.DbUserPassword = txtUserPassword.Text;

			settings.Save();
			//Close();
			Application.Restart();
            Environment.Exit(0);


        }
	}
}
