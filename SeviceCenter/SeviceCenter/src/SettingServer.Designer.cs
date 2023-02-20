namespace SeviceCenter.src
{
	partial class SettingServer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSave = new System.Windows.Forms.Button();
			this.txtServerHost = new System.Windows.Forms.TextBox();
			this.txtServerPort = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtUserPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(74, 155);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(109, 23);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.Button1_Click);
			// 
			// txtServerHost
			// 
			this.txtServerHost.Location = new System.Drawing.Point(113, 16);
			this.txtServerHost.Name = "txtServerHost";
			this.txtServerHost.Size = new System.Drawing.Size(132, 20);
			this.txtServerHost.TabIndex = 2;
			this.txtServerHost.Text = "127.0.0.1";
			// 
			// txtServerPort
			// 
			this.txtServerPort.Location = new System.Drawing.Point(113, 42);
			this.txtServerPort.Name = "txtServerPort";
			this.txtServerPort.Size = new System.Drawing.Size(132, 20);
			this.txtServerPort.TabIndex = 3;
			this.txtServerPort.Text = "3306";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(113, 68);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(132, 20);
			this.txtName.TabIndex = 4;
			this.txtName.Text = "servicecenters";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(113, 94);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(132, 20);
			this.txtUserName.TabIndex = 5;
			this.txtUserName.Text = "root";
			// 
			// txtUserPassword
			// 
			this.txtUserPassword.Location = new System.Drawing.Point(113, 120);
			this.txtUserPassword.Name = "txtUserPassword";
			this.txtUserPassword.Size = new System.Drawing.Size(132, 20);
			this.txtUserPassword.TabIndex = 6;
			this.txtUserPassword.Text = "MiLosSerGey7";
			this.txtUserPassword.UseSystemPasswordChar = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Хост";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Порт";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "База данных";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Логин сервера";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 127);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(90, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Пароль сервера";
			// 
			// SettingServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(271, 201);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtUserPassword);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.txtServerPort);
			this.Controls.Add(this.txtServerHost);
			this.Controls.Add(this.btnSave);
			this.Name = "SettingServer";
			this.Text = "Настройка сервера";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtServerHost;
		private System.Windows.Forms.TextBox txtServerPort;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtUserPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}