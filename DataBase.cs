using MySql.Data.MySqlClient;

namespace BotLauncherBeta
{
    class DataBase
    {
        private MySqlConnection connection;

        public DataBase(string server, string port, string username, string password, string dataname)
        {
            connection = new MySqlConnection(
                $"server={server};" +
                $"port={port};" +
                $"username={username};" +
                $"password={password};" +
                $"database={dataname}"
                );
        }
        public int openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                    return 0; 
                }
                catch
                {
                    return 1; //открыть соединение не получилось
                }
            }
            else return 2; //соединение уже было открыто
        }
        public int closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                    return 0; 
                }
                catch
                {
                    return 1; //закрыть соединение не получилось
                }
            }
            else 
                return 2; //соединение уже было закрыто
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
