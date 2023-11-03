using System;
using System.Data.SqlClient;

public class Database
{
    public static SqlConnection GetConnection()
    {
        var connectionString = "Data Source=34.23.161.151;Initial Catalog=PortalEgresados;User ID=backend;Password=@uasd809@";
        //var connectionString = "Data Source=localhost\\MONOGRAFICO53;Initial Catalog=PortalEgresados;User ID=sa;Password=Ab123456";

        var connection = new SqlConnection(connectionString);
        connection.Open();

        return connection;
    }
}
