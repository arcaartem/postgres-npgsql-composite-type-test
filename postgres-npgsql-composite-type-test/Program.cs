using System;
using System.Collections.Generic;

namespace composite_type_test
{
    class Program
    {
        static void Main()
        {
            var repository = new PlaceRepository("Host=localhost;Port=5432;Username=docker;Password=docker");

            Console.WriteLine("Saving a 'Place' object into the DB...");
            repository.SavePlace(new Place
            {
                Id = Guid.NewGuid(),
                Names = new List<PlaceName>
                {
                    new PlaceName {Language = Language.en_us, Name = "The Shire"},
                    new PlaceName {Language = Language.en_gb, Name = "The Shire"},
                    new PlaceName {Language = Language.de_de, Name = "Die Shire"}
                },
                TelCode = "+12345"
            });


            Console.WriteLine("Reading all 'Place' objects from the DB...");
            var places = repository.GetAllPlaces();

            places.ForEach(Console.WriteLine);
        }
    }
}