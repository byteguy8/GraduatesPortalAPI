using System.Data;
using System.Data.SqlClient;

public class GraduateDAO
{
    private readonly SqlConnection connection;

    public GraduateDAO(SqlConnection connection)
    {
        this.connection = connection;
    }

    public int? GetGraduateIdByUsername(string username)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                EgresadoId
            FROM Participante 
            JOIN Egresado ON
                Participante.ParticipanteId = Egresado.ParticipanteId
            WHERE UsuarioId = (
                SELECT
                    UsuarioID
                FROM Usuario
                WHERE UserName = @name
            );";

            command.Parameters.AddWithValue("@name", username);

            reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return reader.GetInt32(0);
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public bool Exists(int graduateId)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(EgresadoId)
            FROM Egresado
            WHERE EgresadoId = @graduateId;";

            command.Parameters.AddWithValue("@graduateId", graduateId);
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

    public bool ExistsIdentification(string identification)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(EgresadoId)
            FROM DocumentoEgresado
            WHERE DocumentoNo = @identification;";

            command.Parameters.AddWithValue("@identification", identification);
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

    public int Count()
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                COUNT(EgresadoId)
            FROM Egresado;";

            reader = command.ExecuteReader();

            reader.Read();
            return reader.GetInt32(0);
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public bool JoinToUser(int ParticipanteId, int userId)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"INSERT INTO Participante(
                ParticipanteId,
                UsuarioId
            )VALUES(
                @ParticipanteId,
                @userId
            );";

            command.Parameters.AddWithValue("@graduateId", ParticipanteId);
            command.Parameters.AddWithValue("@userId", userId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }

    public List<GraduateMinimum> PagingMinimum(int offset, int fetch)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT 
                * 
            FROM Egresado
            JOIN DocumentoEgresado ON
                Egresado.EgresadoId = DocumentoEgresado.EgresadoId

			ORDER BY PrimerNombre

			OFFSET @offset ROWS
            FETCH NEXT @limit ROWS ONLY;";

            command.Parameters.AddWithValue("@limit", fetch);
            command.Parameters.AddWithValue("@offset", offset);

            reader = command.ExecuteReader();

            var graduates = new List<GraduateMinimum>();

            while (reader.Read())
            {
                var id = reader.GetInt32("EgresadoId");
                var firstName = reader.GetString("PrimerNombre");
                var lastName = reader.GetString("PrimerApellido");
                var birthday = reader.GetDateTime("FechaNac").ToShortDateString();
                var gender = reader.GetChar("Genero");
                var identification = reader.GetString("DocumentoNo");

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

    public List<Graduate> Paging(int offset, int fetch)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT 
                * 
            FROM Egresado
            JOIN DocumentoEgresado ON
                Egresado.EgresadoId = DocumentoEgresado.EgresadoId

			ORDER BY PrimerNombre

			OFFSET @offset ROWS
            FETCH NEXT @limit ROWS ONLY;";

            command.Parameters.AddWithValue("@limit", fetch);
            command.Parameters.AddWithValue("@offset", offset);

            reader = command.ExecuteReader();

            var graduates = new List<Graduate>();

            while (reader.Read())
            {
                var id = reader.GetInt32("EgresadoId");
                var firstName = reader.GetString("PrimerNombre");
                var lastName = reader.GetString("PrimerApellido");
                var birthday = reader.GetDateTime("FechaNac").ToShortDateString();
                var gender = reader.GetChar("Genero");
                var identification = reader.GetString("DocumentoNo");

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

    public Graduate? Get(int graduateId)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
                *
            FROM Egresado
            WHERE EgresadoId = @graduateId";

            command.Parameters.AddWithValue("@graduateId", graduateId);

            reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                return null;
            }

            reader.Read();

                var id = reader.GetInt32("EgresadoId");
                var firstName = reader.GetString("PrimerNombre");
                var lastName = reader.GetString("PrimerApellido");
                var birthday = reader.GetDateTime("FechaNac").ToShortDateString();
                var gender = reader.GetChar("Genero");
                var identification = reader.GetString("DocumentoNo");

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
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT 
                * 
            FROM Egresado
            ORDER BY PrimerApellido";

            reader = command.ExecuteReader();

            var graduates = new List<GraduateMinimum>();

            while (reader.Read())
            {
                var id = reader.GetInt32("EgresadoId");
                var firstName = reader.GetString("PrimerNombre");
                var lastName = reader.GetString("PrimerApellido");
                var birthday = reader.GetDateTime("FechaNac").ToShortDateString();
                var gender = reader.GetChar("Genero");
                var identification = reader.GetString("DocumentoNo");

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
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT 
                *
            FROM Egresado
            ORDER BY PrimerApellido";

            reader = command.ExecuteReader();

            var graduates = new List<Graduate>();

            while (reader.Read())
            {
                var id = reader.GetInt32("EgresadoId");
                var firstName = reader.GetString("PrimerNombre");
                var lastName = reader.GetString("PrimerApellido");
                var birthday = reader.GetDateTime("FechaNac").ToShortDateString();
                var gender = reader.GetChar("Genero");
                var identification = reader.GetString("DocumentoNo");

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

    public int Create(Graduate graduate)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"INSERT INTO Egresado(
                PrimerNombre,
                PrimerApellido,
                FechaNac,
                Genero,
                DocumentoNo,
                Nacionalidad
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

    public bool Update(GraduateMinimum graduate)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"UPDATE Egresado SET
                PrimerNombre = @firstName,
                SegundoApellido = @lastName,
                FechaNac = @birthDay,
                Genero = @gender,
                DocumentoNo = @identification,
                Nacionalidad = @nationalityId
            WHERE EgresadoId = @graduateId";

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

    public bool Delete(int graduateId)
    {
        SqlCommand? command = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"DELETE FROM Egresado
            WHERE EgresadoId = @graduateId";

            command.Parameters.AddWithValue("@graduateId", graduateId);

            return command.ExecuteNonQuery() == 1;
        }
        finally
        {
            command?.Dispose();
        }
    }
}