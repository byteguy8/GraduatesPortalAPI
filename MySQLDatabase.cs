using MySqlConnector;
public class MySQLDatabase
{
    public static MySqlConnection GetConnection()
    {
        var builder = new MySqlConnectionStringBuilder
        {
            Server = "db4free.net",
            UserID = "popeye2",
            Password = "Saltaytopa15",
            Database = "graduate_portal",
            IgnoreCommandTransaction = true,
            Port = 3306
        };

        var connection = new MySqlConnection(builder.ConnectionString);
        connection.Open();

        return connection;
    }
}