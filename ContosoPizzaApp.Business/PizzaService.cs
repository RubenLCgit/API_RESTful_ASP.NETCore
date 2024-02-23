using ContosoPizzaApp.Data;
using ContosoPizzaApp.Model;

namespace ContosoPizzaApp.Business;

public class PizzaService : IPizzaService
{
  private readonly IRepositoryGeneric<Pizza> _repository;

  public PizzaService(IRepositoryGeneric<Pizza> repository)
  {
    _repository = repository;
  }
  public void Add(Pizza pizza) => _repository.Add(pizza);


  public void Delete(int id) => _repository.Delete(id);

  public async Task<Pizza> Get(int id) => await _repository.Get(id);

  public async Task<Dictionary<int, Pizza>> GetAll() => await _repository.GetAll();

  public void Update(Pizza pizza) => _repository.Update(pizza);
}
