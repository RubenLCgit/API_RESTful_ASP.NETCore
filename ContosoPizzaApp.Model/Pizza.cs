namespace ContosoPizzaApp.Model;

public class Pizza
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public bool IsGlutenFree { get; set; }


  public Pizza(string name, bool isGlutenFree)
  {
    Name = name;
    IsGlutenFree = isGlutenFree;
  }

  public Pizza() { }
}
