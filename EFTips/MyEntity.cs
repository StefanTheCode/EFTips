namespace EFTips;
public class MyEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string LargeTextField { get; set; } = string.Empty;
    public List<RelatedEntity> RelatedEntities { get; set; } = new List<RelatedEntity>();
}

public class RelatedEntity
{
    public int Id { get; set; }
    public string Detail { get; set; } = string.Empty;
    public int MyEntityId { get; set; }
    public MyEntity MyEntity { get; set; }
}