using ContosoPizzaApp.Model;

namespace ContosoPizzaApp.Business;

public interface IPizzaService
{
  Task<Dictionary<int,Pizza>> GetAll();
  Task<Pizza> Get(int id);
  void Add(Pizza pizza);
  void Delete(int id);
  void Update(Pizza pizza);
}