using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Data;

public class UserDAO
{
    private readonly SqlConnection connection;

    public UserDAO(SqlConnection connection)
    {
        this.connection = connection;
    }

    public string? Login(User user)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                *
            FROM Usuario
            WHERE UserName = @name AND
            Password = @password";

            command.Parameters.AddWithValue("@name", user.name);
            command.Parameters.AddWithValue("@password", user.password);

            reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                return null;
            }

            reader.Read();
            var userTypeId = reader.GetInt64("RolId");

            reader.Close();
            command.Dispose();

            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                Nombre
            FROM Rol
            WHERE RolId = @userTypeId";

            command.Parameters.AddWithValue("@userTypeId", userTypeId);

            reader = command.ExecuteReader();
            reader.Read();

            var userType = reader.GetString("Nombre");

            var key = "n9EW1FOGFiZ9sJJnap1VqGjO3anEnpcstsygTdVdeme2JwkMMCdmJ6bmn4vSQMrWxkSGlfPm/djrvCvvN/J8kA==";
            var tokenHandler = new JwtSecurityTokenHandler();
            var byteKey = Encoding.UTF8.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim("UserName", user.name),
                    new Claim("Nombre", userType),
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

    public bool Exists(int userId)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(UsuarioID)
            FROM Usuario
            WHERE UsuarioID = @userId";

            command.Parameters.AddWithValue("@userId", userId);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32(0) == 1;
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
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(UsuarioID)
            FROM Usuario
            WHERE Nombre = @name";

            command.Parameters.AddWithValue("@name", name);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32(0) == 1;
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

    public User? Get(int graduateId)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
	            u.* 
              FROM
	            Participante p
              JOIN Egresado e ON
	               p.ParticipanteId  = e.EgresadoId 
              JOIN Usuario u ON
	               p.ParticipanteId  = u.UsuarioId
              WHERE
	              e.EgresadoId = @graduateId;";

            command.Parameters.AddWithValue("@graduateId", graduateId);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    id = reader.GetInt32("UsuarioID"),
                    name = reader.GetString("UserName"),
                    password = reader.GetString("Password")
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

    public int Create(User user)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"INSERT INTO Usuario(
                RolId,
                UserName,
                Password
            )VALUES(
                (SELECT
                    RolId
                FROM Rol
                WHERE Nombre = 'Egresado'),
                @name, 
                @password
            );";

            command.Parameters.AddWithValue("@name", user.name);
            command.Parameters.AddWithValue("@password", user.password);

            int count = command.ExecuteNonQuery();

            if (count == 1)
            {
                return Convert.ToInt32(command.ExecuteScalar());
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
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"UPDATE Usuario SET
                Nombre = @name,
                Password = @password
            WHERE UsuarioID = @userId;";

            command.Parameters.AddWithValue("@userId", user.id);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool Delete(int userId)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"DELETE FROM Usuario
            WHERE UsuarioID = @userId";

            command.Parameters.AddWithValue("@userId", userId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool UnjoinGraduate(int graduateId)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"DELETE FROM Participante
            WHERE UsuarioId = @graduateId;";

            command.Parameters.AddWithValue("@graduateId", graduateId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public bool DeleteByGraduate(int graduateId)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"DELETE FROM Usuario
            WHERE UsuarioID = (
                SELECT
                    Usuarioid
                FROM Participante
                WHERE UsuarioId = @graduateId
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