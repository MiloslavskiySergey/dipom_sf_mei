using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace SeviceCenter.DB
{

	public class DbContext
	{

		#region Singleton

		private static DbContext _instance = null;

		public static DbContext Instance
		{
			get
			{
				if (_instance == null)
					_instance = new DbContext();
				return _instance;
			}
		}

		#endregion

		private Properties.Settings Settings { get; }

		private DbConnection context;

		public DbContext()
		{
			Settings = Properties.Settings.Default;
		}

		private string ConnectionString
		{
			get
			{
				return $"Server={Settings.DbServerHost};" +
					   $"Port={Settings.DbServerPort};" +
					   $"Database={Settings.DbName};" +
					   $"Uid={Settings.DbUserName};" +
					   $"Pwd={Settings.DbUserPassword};";
			}
		}

		/// <summary>
		/// Открывает соединение с БД
		/// </summary>
		public void Connect()
		{
			if (context != null)
				Close();

			context = new MySqlConnection(ConnectionString);
			context.Open();
		}


		/// <summary>
		/// Закрывает соединение с БД
		/// </summary>
		public void Close()
		{
			if (context == null)
				return;

			try
			{
				context.Close();
			}
			catch { }

			context = null;
		}

		public DbCommand Command(string text, DbConnection connection)
		{
			var command = new MySqlCommand(text, (MySqlConnection)connection);
			command.CommandText = text;
			return command;
		}

		/// <summary>
		/// Создаёт и возвращает экземпляр команды
		/// </summary>
		/// <param name="sql">SQL команда</param>
		/// <returns></returns>
		public DbCommand Command(string sql = "")
		{
			return Command(sql, context);
		}

		public ConnectionState State
		{
			get
			{
				if (context == null)
					return ConnectionState.Closed;

				return context.State;
			}
		}

		public DbDataAdapter DataAdapter(string sql)
		{
			return new MySqlDataAdapter(sql, (MySqlConnection)context);
		}

	}

}
