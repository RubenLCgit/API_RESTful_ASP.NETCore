namespace ContosoPizzaApp.Data;

public interface IRepositoryGeneric<T> where T : class
{
  Task<Dictionary<int,T>> GetAll();
  Task<T> Get(int id);
  Task Add(T entity);
  Task Delete(int id);
  Task Update(T entity);
  Task Save();
}
