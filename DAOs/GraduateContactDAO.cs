using MySqlConnector;

public class GraduateContactDAO
{
    private readonly MySqlConnection connection;

    public GraduateContactDAO(MySqlConnection connection)
    {
        this.connection = connection;
    }

    public bool ExistsTelephone(string telephone)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(id)
            FROM graduate_telephone
            WHERE value = @value;";

            command.Parameters.AddWithValue("@value", telephone);
            reader = command.ExecuteReader();

            reader.Read();
            return reader.GetInt64(0) == 1;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public bool ExistsEmail(string email)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(id)
            FROM graduate_email
            WHERE value = @value;";

            command.Parameters.AddWithValue("@value", email);
            reader = command.ExecuteReader();

            reader.Read();
            return reader.GetInt64(0) == 1;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public ulong CountTelephones(ulong graduateId)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

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
                return reader.GetUInt64(0);
            }

            return 0;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public ulong CountEmails(ulong graduateId)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

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
                return reader.GetUInt64(0);
            }

            return 0;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public ulong CountAddresses(ulong graduateId)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

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
                return reader.GetUInt64(0);
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
        MySqlCommand? command = null;

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
        MySqlCommand? command = null;

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
        MySqlCommand? command = null;

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

    public bool DeleteTelephones(ulong graduateId)
    {
        MySqlCommand? command = null;

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

    public bool DeleteEmails(ulong graduateId)
    {
        MySqlCommand? command = null;

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

    public bool DeleteAddresses(ulong graduateId)
    {
        MySqlCommand? command = null;

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
    public List<string> GetTelephones(ulong graduate_id)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

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

    public List<string> GetEmails(ulong graduate_id)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

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

    public List<string> GetAddresses(ulong graduate_id)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

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