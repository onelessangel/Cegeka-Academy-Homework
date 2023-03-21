namespace GenericsDemo.Entities
{
  public class Organization : EntityBase
  {
    public string? Name { get; set; }
    public int NumberOfEmployee { get; set; }

    public override string ToString() => $"Id: {Id}, Name: {Name}";
  }
}
