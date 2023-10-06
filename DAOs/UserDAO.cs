using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;

public class UserDAO
{
    private readonly MySqlConnection connection;

    public UserDAO(MySqlConnection connection)
    {
        this.connection = connection;
    }

    public string? Login(User user)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                *
            FROM user
            WHERE name = @name AND
            password = @password";

            command.Parameters.AddWithValue("@name", user.name);
            command.Parameters.AddWithValue("@password", user.password);

            reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                return null;
            }

            reader.Read();
            var userTypeId = reader.GetUInt64("user_type_id");

            reader.Close();
            command.Dispose();

            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                name
            FROM user_type
            WHERE id = @userTypeId";

            command.Parameters.AddWithValue("@userTypeId", userTypeId);

            reader = command.ExecuteReader();
            reader.Read();

            var userType = reader.GetString("name");

            var key = "n9EW1FOGFiZ9sJJnap1VqGjO3anEnpcstsygTdVdeme2JwkMMCdmJ6bmn4vSQMrWxkSGlfPm/djrvCvvN/J8kA==";
            var tokenHandler = new JwtSecurityTokenHandler();
            var byteKey = Encoding.UTF8.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim("name", user.name),
                    new Claim("user_type", userType),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public bool Exists(ulong userId)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(id)
            FROM user
            WHERE id = @userId";

            command.Parameters.AddWithValue("@userId", userId);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt64(0) == 1;
            }
            else
            {
                return false;
            }
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public bool Exists(string name)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(id)
            FROM user
            WHERE name = @name";

            command.Parameters.AddWithValue("@name", name);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt64(0) == 1;
            }
            else
            {
                return false;
            }
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public User? Get(ulong graduateId)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
	            u.* 
              FROM
	            graduate g
              JOIN graduate_user gu  ON
	               g.id  = gu.graduate_id 
              JOIN user u ON
	               gu.user_id  = u.id
              WHERE
	              g.id = @graduateId;";

            command.Parameters.AddWithValue("@graduateId", graduateId);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    id = reader.GetUInt64("id"),
                    name = reader.GetString("name"),
                    password = reader.GetString("password")
                };
            }

            return null;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public long Create(User user)
    {
        MySqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"INSERT INTO user(
                name,
                password,
                user_type_id
            )VALUES(
                @name, 
                @password,
                (SELECT
                    id
                FROM user_type
                WHERE name = 'GRADUATE')
            );";

            command.Parameters.AddWithValue("@name", user.name);
            command.Parameters.AddWithValue("@password", user.password);

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

    public bool Update(User user)
    {
        MySqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"UPDATE user SET
                name = @name,
                password = @password
            WHERE id = @userId;";

            command.Parameters.AddWithValue("@userId", user.id);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool Delete(ulong userId)
    {
        MySqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"DELETE FROM user
            WHERE id = @userId";

            command.Parameters.AddWithValue("@userId", userId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool UnjoinGraduate(ulong graduateId)
    {
        MySqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"DELETE FROM graduate_user
            WHERE graduate_id = @graduateId;";

            command.Parameters.AddWithValue("@graduateId", graduateId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool DeleteByGraduate(ulong graduateId)
    {
        MySqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"DELETE FROM user
            WHERE id = (
                SELECT
                    user_id
                FROM graduate_user
                WHERE graduate_id = @graduateId
            );";

            command.Parameters.AddWithValue("@graduateId", graduateId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }
}