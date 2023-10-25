using System;
using System.Data.SqlClient;

public class Database
{
    public static SqlConnection GetConnection()
    {
        var connectionString = "Data Source=34.23.161.151;Initial Catalog=PortalEgresados;User ID=backend;Password=#@egresados809@#";

        var connection = new SqlConnection(connectionString);
        connection.Open();

        return connection;
    }
}
