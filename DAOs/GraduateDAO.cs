using MySqlConnector;

public class GraduateDAO
{
    private readonly MySqlConnection connection;

    public GraduateDAO(MySqlConnection connection)
    {
        this.connection = connection;
    }

    public ulong? GetGraduateIdByUsername(string username)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                graduate_id
            FROM graduate_user
            WHERE user_id = (
                SELECT
                    id
                FROM user
                WHERE name = @name
            );";

            command.Parameters.AddWithValue("@name", username);

            reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return reader.GetUInt64(0);
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public bool Exists(ulong graduateId)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(id)
            FROM graduate
            WHERE id = @graduateId;";

            command.Parameters.AddWithValue("@graduateId", graduateId);
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

    public bool ExistsIdentification(string identification)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(id)
            FROM graduate
            WHERE identification = @identification;";

            command.Parameters.AddWithValue("@identification", identification);
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

    public ulong Count()
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(id)
            FROM graduate;";

            reader = command.ExecuteReader();

            reader.Read();
            return reader.GetUInt64(0);
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public bool JoinToUser(long graduateId, long userId)
    {
        MySqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"INSERT INTO graduate_user(
                graduate_id,
                user_id
            )VALUES(
                @graduateId,
                @userId
            );";

            command.Parameters.AddWithValue("@graduateId", graduateId);
            command.Parameters.AddWithValue("@userId", userId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public List<GraduateMinimum> PagingMinimum(ulong offset, ulong limit)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT 
                * 
            FROM graduate
            LIMIT @limit
            OFFSET @offset";

            command.Parameters.AddWithValue("@limit", limit);
            command.Parameters.AddWithValue("@offset", offset);

            reader = command.ExecuteReader();

            var graduates = new List<GraduateMinimum>();

            while (reader.Read())
            {
                var id = reader.GetUInt64("id");
                var firstName = reader.GetString("first_name");
                var lastName = reader.GetString("last_name");
                var birthday = reader.GetDateTime("birthday").ToShortDateString();
                var gender = reader.GetChar("gender");
                var identification = reader.GetString("identification");

                var graduate = new GraduateMinimum
                {
                    id = id,
                    firstName = firstName,
                    lastName = lastName,
                    birthday = birthday,
                    gender = gender,
                    identification = identification
                };

                graduates.Add(graduate);
            }

            return graduates;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public List<Graduate> Paging(ulong offset, ulong limit)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT 
                * 
            FROM graduate
            LIMIT @limit
            OFFSET @offset;";

            command.Parameters.AddWithValue("@limit", limit);
            command.Parameters.AddWithValue("@offset", offset);

            reader = command.ExecuteReader();

            var graduates = new List<Graduate>();

            while (reader.Read())
            {
                var id = reader.GetUInt64("id");
                var firstName = reader.GetString("first_name");
                var lastName = reader.GetString("last_name");
                var birthday = reader.GetDateTime("birthday").ToShortDateString();
                var gender = reader.GetChar("gender");
                var identification = reader.GetString("identification");

                var graduate = new Graduate
                {
                    id = id,
                    firstName = firstName,
                    lastName = lastName,
                    birthday = birthday,
                    gender = gender,
                    identification = identification,
                    emails = new List<string>(),
                    telephones = new List<string>(),
                    addresses = new List<string>()
                };

                graduates.Add(graduate);
            }

            return graduates;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public Graduate? Get(ulong graduateId)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                *
            FROM graduate
            WHERE id = @graduateId";

            command.Parameters.AddWithValue("@graduateId", graduateId);

            reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                return null;
            }

            reader.Read();

            var firstName = reader.GetString("first_name");
            var lastName = reader.GetString("last_name");
            var birthday = reader.GetDateTime("birthday").ToShortDateString();
            var gender = reader.GetChar("gender");
            var identification = reader.GetString("identification");

            return new Graduate
            {
                id = graduateId,
                firstName = firstName,
                lastName = lastName,
                birthday = birthday,
                gender = gender,
                identification = identification
            };
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public List<GraduateMinimum> GetAllMinimum()
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT 
                * 
            FROM graduate
            ORDER BY last_name";

            reader = command.ExecuteReader();

            var graduates = new List<GraduateMinimum>();

            while (reader.Read())
            {
                var id = reader.GetUInt64("id");
                var firstName = reader.GetString("first_name");
                var lastName = reader.GetString("last_name");
                var birthday = reader.GetDateTime("birthday").ToShortDateString();
                var gender = reader.GetChar("gender");
                var identification = reader.GetString("identification");

                var graduate = new GraduateMinimum
                {
                    id = id,
                    firstName = firstName,
                    lastName = lastName,
                    birthday = birthday,
                    gender = gender,
                    identification = identification
                };

                graduates.Add(graduate);
            }

            return graduates;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public List<Graduate> GetAll()
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT 
                *
            FROM graduate
            ORDER BY last_name";

            reader = command.ExecuteReader();

            var graduates = new List<Graduate>();

            while (reader.Read())
            {
                var id = reader.GetUInt64("id");
                var firstName = reader.GetString("first_name");
                var lastName = reader.GetString("last_name");
                var birthday = reader.GetDateTime("birthday").ToShortDateString();
                var gender = reader.GetChar("gender");
                var identification = reader.GetString("identification");

                var graduate = new Graduate
                {
                    id = id,
                    firstName = firstName,
                    lastName = lastName,
                    birthday = birthday,
                    gender = gender,
                    identification = identification
                };

                graduates.Add(graduate);
            }

            return graduates;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public long Create(Graduate graduate)
    {
        MySqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"INSERT INTO graduate(
                first_name,
                last_name,
                birthday,
                gender,
                identification,
                nationality_id
            )VALUES(
                @firstName,
                @lastName,
                @birthday,
                @gender,
                @identification,
                @nationalityId
            );";

            command.Parameters.AddWithValue("@firstName", graduate.firstName);
            command.Parameters.AddWithValue("@lastName", graduate.lastName);
            command.Parameters.AddWithValue("@birthday", graduate.birthday);
            command.Parameters.AddWithValue("@gender", graduate.gender);
            command.Parameters.AddWithValue("@identification", graduate.identification);
            command.Parameters.AddWithValue("@nationalityId", graduate.nationality.id);

            int count = command.ExecuteNonQuery();

            if (count == 1)
            {
                return command.LastInsertedId;
            }
            else
            {
                return -1;
            }
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool Update(GraduateMinimum graduate)
    {
        MySqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"UPDATE graduate SET
                first_name = @firstName,
                last_name = @lastName,
                birthday = @birthDay,
                gender = @gender,
                identification = @identification,
                nationality_id = @nationalityId
            WHERE id = @graduateId";

            command.Parameters.AddWithValue("@firstName", graduate.firstName);
            command.Parameters.AddWithValue("@lastName", graduate.lastName);
            command.Parameters.AddWithValue("@birthday", graduate.birthday);
            command.Parameters.AddWithValue("@gender", graduate.gender);
            command.Parameters.AddWithValue("@identification", graduate.identification);
            command.Parameters.AddWithValue("@nationalityId", graduate.nationality.id);
            command.Parameters.AddWithValue("@graduateId", graduate.id);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool Delete(ulong graduateId)
    {
        MySqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"DELETE FROM graduate
            WHERE id = @graduateId";

            command.Parameters.AddWithValue("@graduateId", graduateId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }
}