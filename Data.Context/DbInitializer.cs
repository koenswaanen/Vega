using Microsoft.EntityFrameworkCore;
using Models.Domain;
using System.Linq;

namespace Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize(VegaDbContext context)
        {
            context.Database.Migrate();
            if(context.Makes.Any())
            {
                return;
            }

            var makes = new Make[]
            {
                new Make{Name="Mercedes"},
                new Make{Name="BMW"}
            };
            
            context.AddRange(makes);
            context.SaveChanges();

            var models = new Model[]
            {
                new Model {Name="A", MakeId = 1},
                new Model {Name = "B", MakeId = 1},
                new Model {Name = "C", MakeId = 1},
                new Model {Name = "1", MakeId = 2},
                new Model {Name = "2 Active Tourer", MakeId = 2},
                new Model {Name = "2 Grand Tourer", MakeId = 2}
            };

            context.AddRange(models);
            context.SaveChanges();

            var features = new Feature[]
            {
                new Feature {Name = "Airco"},
                new Feature {Name = "ABS"}
            };

            context.AddRange(features);
            context.SaveChanges();
        }
    }
}
