using System.Data.SqlClient;
using System.Data;

public class GraduateContactDAO
{
    private readonly SqlConnection connection;

    public GraduateContactDAO(SqlConnection connection)
    {
        this.connection = connection;
    }

    /*public bool ExistsTelephone(string telephone)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(Nombre)
            FROM Contacto
            WHERE value = @value;";

            command.Parameters.AddWithValue("@value", telephone);
            reader = command.ExecuteReader();

            reader.Read();
            return reader.GetInt32(0) == 1;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }*/

    public bool ExistsEmail(string email)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(Nombre)
            FROM Contacto
            WHERE value = @value;";

            command.Parameters.AddWithValue("@value", email);
            reader = command.ExecuteReader();

            reader.Read();
            return reader.GetInt32(0) == 1;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public long CountTelephones(long graduateId)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(*)
            FROM graduate_telephone
            WHERE graduate_id = @graduateId;";

            command.Parameters.AddWithValue("@graduateId", graduateId);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32(0);
            }

            return 0;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public long CountEmails(long graduateId)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(*)
            FROM graduate_email
            WHERE graduate_id = @graduateId;";

            command.Parameters.AddWithValue("@graduateId", graduateId);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32(0);
            }

            return 0;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public long CountAddresses(long graduateId)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(*)
            FROM graduate_address
            WHERE graduate_id = @graduateId;";

            command.Parameters.AddWithValue("@graduateId", graduateId);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32(0);
            }

            return 0;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public bool CreateTelephone(long graduateId, string telephone)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"INSERT INTO graduate_telephone(
                value,
                graduate_id
            )VALUES(
                @value,
                @graduateId
            );";

            command.Parameters.AddWithValue("@value", telephone);
            command.Parameters.AddWithValue("@graduateId", graduateId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool CreateAddress(long graduateId, string address)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"INSERT INTO graduate_address(
                value,
                graduate_id
            )VALUES(
                @value,
                @graduateId
            );";

            command.Parameters.AddWithValue("@value", address);
            command.Parameters.AddWithValue("@graduateId", graduateId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool CreateEmail(long graduateId, string telephone)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"INSERT INTO graduate_email(
                value,
                graduate_id
            )VALUES(
                @value,
                @graduateId
            );";

            command.Parameters.AddWithValue("@value", telephone);
            command.Parameters.AddWithValue("@graduateId", graduateId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool DeleteTelephones(long graduateId)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"DELETE FROM graduate_telephone
            WHERE graduate_id = @graduateId";

            command.Parameters.AddWithValue("@graduateId", graduateId);

            return command.ExecuteNonQuery() > 0;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool DeleteEmails(long graduateId)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"DELETE FROM graduate_email
            WHERE graduate_id = @graduateId";

            command.Parameters.AddWithValue("@graduateId", graduateId);

            return command.ExecuteNonQuery() > 0;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool DeleteAddresses(long graduateId)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"DELETE FROM graduate_address
            WHERE graduate_id = @graduateId";

            command.Parameters.AddWithValue("@graduateId", graduateId);

            return command.ExecuteNonQuery() > 0;
        }
        finally
        {
            command?.Dispose();
        }
    }

    //OBTENER DATOS DE CONTACTOS
    public List<string> GetTelephones(long graduate_id)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        List<string> telephones = new List<string>();

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                value
            FROM graduate_telephone
            WHERE graduate_id = @graduate_id;";

            command.Parameters.AddWithValue("@graduate_id", graduate_id);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                var telephone = reader.GetString("value");
                telephones.Add(telephone);
            }

            return telephones;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public List<string> GetEmails(long graduate_id)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        var emails = new List<string>();

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                value
            FROM graduate_email
            WHERE graduate_id = @graduate_id;";

            command.Parameters.AddWithValue("@graduate_id", graduate_id);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                var email = reader.GetString("value");
                emails.Add(email);
            }

            return emails;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public List<string> GetAddresses(long graduate_id)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        var Addresses = new List<string>();

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                value
            FROM graduate_address
            WHERE graduate_id = @graduate_id;";

            command.Parameters.AddWithValue("@graduate_id", graduate_id);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                var Address = reader.GetString("value");
                Addresses.Add(Address);
            }

            return Addresses;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }

    }
}