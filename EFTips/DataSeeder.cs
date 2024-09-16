namespace EFTips;

public class DataSeeder
{
    public static void SeedData(MyDbContext context, int numberOfRecords)
    {
        var random = new Random();

        for (int i = 1; i <= numberOfRecords; i++)
        {
            var myEntity = new MyEntity
            {
                Id = i,
                Name = $"Entity {i}",
                Description = $"Description for entity {i}",
                CreatedAt = DateTime.Now.AddDays(-random.Next(1000)),
                LargeTextField = new string('A', random.Next(100, 1000)),
                RelatedEntities = []
            };

            for (int j = 1; j <= 10; j++) 
            {
                var relatedEntity = new RelatedEntity
                {
                    Detail = $"Detail {j} for Entity {i}",
                    MyEntityId = myEntity.Id 
                };

                myEntity.RelatedEntities.Add(relatedEntity);
            }

            context.MyEntities.Add(myEntity); 
        }

        context.SaveChanges();
    }
}