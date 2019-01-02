using System;
using System.Collections.Generic;
using Npgsql;

namespace composite_type_test
{
    public class PlaceRepository : IDisposable
    {
        private readonly NpgsqlConnection _connection;

        public PlaceRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
//            _connection.TypeMapper.MapEnum<Language>("mandatory_language"); // Cannot register to the domain type, throws NotSupportedException
            _connection.TypeMapper.MapEnum<Language>("language");
            _connection.TypeMapper.MapComposite<PlaceName>("place_name");
        }

        public List<Place> GetAllPlaces()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM place";
                using (var reader = command.ExecuteReader())
                {
                    var result = new List<Place>();
                    while (reader.Read())
                    {
                        result.Add(MapCurrentRowToPlace(reader));
                    }
                    return result;
                }
            }
        }

        public void SavePlace(Place place)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO place (id, names, tel_code) VALUES (@id, @names, @tel_code)";
                command.Parameters.AddWithValue("id", place.Id);
                command.Parameters.AddWithValue("names", place.Names);
                command.Parameters.AddWithValue("tel_code", place.TelCode);
                command.ExecuteNonQuery();
            }
        }

        private static Place MapCurrentRowToPlace(NpgsqlDataReader reader)
        {
            var result = new Place
            {
                Id = reader.GetFieldValue<Guid>(reader.GetOrdinal("id")),
                Names = reader.GetFieldValue<List<PlaceName>>(reader.GetOrdinal("names")),
                TelCode = reader.GetFieldValue<string>(reader.GetOrdinal("tel_code"))
            };
            return result;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}