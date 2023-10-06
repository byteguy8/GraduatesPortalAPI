using MySqlConnector;

public class NationalityDAO
{
    private readonly MySqlConnection connection;

    public NationalityDAO(MySqlConnection connection)
    {
        this.connection = connection;
    }

    public List<Nationality> GetAll()
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT 
                * 
            FROM nationality 
            ORDER BY name";

            reader = command.ExecuteReader();

            var nationalities = new List<Nationality>();

            while (reader.Read())
            {
                var id = reader.GetUInt64("id");
                var name = reader.GetString("name");

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

    public Nationality? GetNationality(ulong graduateId)
    {
        MySqlCommand? command = null;
        MySqlDataReader? reader = null;

        try
        {
            command = connection.CreateCommand();

            command.CommandText =
            @"SELECT
	              *
              FROM
	              nationality
              INNER JOIN graduate
                          ON
	              nationality.ID = graduate.nationality_id
              WHERE
	              graduate.id= @graduate_id;";

            command.Parameters.AddWithValue("@graduate_id", graduateId);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                var id = reader.GetUInt64("id");
                var name = reader.GetString("name");

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