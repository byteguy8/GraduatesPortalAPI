using System.Data;
using System.Data.SqlClient;

public class NationalityDAO
{
    private readonly SqlConnection connection;

    public NationalityDAO(SqlConnection connection)
    {
        this.connection = connection;
    }

    public List<Nationality> GetAll()
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT 
                * 
            FROM Pais 
            ORDER BY Nombre";

            reader = command.ExecuteReader();

            var nationalities = new List<Nationality>();

            while (reader.Read())
            {
                var id = reader.GetInt32("PaisId");
                var name = reader.GetString("Nombre");

                var nationality = new Nationality
                {
                    id = id,
                    name = name
                };

                nationalities.Add(nationality);
            }

            return nationalities;
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }

    public Nationality? GetNationality(int graduateId)
    {
        SqlCommand? command = null;
        SqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
	              *
              FROM
	              Pais
              INNER JOIN Egresado
                          ON
	              Pais.PaisId = Egresado.Nacionalidad
              WHERE
	              Egresado.EgresadoId= @graduate_id;";

            command.Parameters.AddWithValue("@graduate_id", graduateId);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                var id = reader.GetInt32("PaisId");
                var name = reader.GetString("Pais");

                return new Nationality
                {
                    id = id,
                    name = name
                };
            }
            else
            {
                return null;
            }
        }
        finally
        {
            reader?.Close();
            command?.Dispose();
        }
    }
}