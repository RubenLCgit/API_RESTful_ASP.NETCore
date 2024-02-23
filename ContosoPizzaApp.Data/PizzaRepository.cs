using System.Text.Json;
using ContosoPizzaApp.Model;

namespace ContosoPizzaApp.Data;

public class PizzaRepository : IRepositoryGeneric<Pizza>
{
  public Dictionary<int, Pizza> _allPizzas = new();
  private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"ContosoPizzaApp","Repository","PizzaRepository.json");
  public async Task Add(Pizza entity)
  {
    _allPizzas = await GetAll();
    entity.Id = await GetNextId();
    _allPizzas.Add(entity.Id, entity);
    await Save();
  }

  private async Task<int> GetNextId()
  {
    _allPizzas = await GetAll();
    if (_allPizzas.Keys.Count == 0)
    {
      return 1;
    }
    return _allPizzas.Keys.Max() + 1;
  }

  public async Task Delete(int id)
  {
    _allPizzas = await GetAll();
    _allPizzas.Remove(id);
    await Save();
  }

  public async Task<Pizza> Get(int id)
  {
    try
    {
      _allPizzas = await GetAll();
      return _allPizzas[id];
    }
    catch (KeyNotFoundException ex1)
    {
      throw new KeyNotFoundException($"No pizza found with the id {id}", ex1);
    }
    catch (Exception ex2)
    {
      throw new Exception(ex2.Message);
    }
  }

  public async Task<Dictionary<int,Pizza>> GetAll()
  {
    try
    {
      if (File.Exists(_filePath))
      {
        string jsonString = await File.ReadAllTextAsync(_filePath);
        _allPizzas = JsonSerializer.Deserialize<Dictionary<int, Pizza>>(jsonString); //?? new Dictionary<int, Pizza>(); // Add null check here
        return _allPizzas;
      }
      else
      {
        return _allPizzas;
      }
    }
    catch (IOException ioEx)
    {

      throw new IOException("Failure to access data: ", ioEx);
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task Update(Pizza entity)
  {
    _allPizzas = await GetAll();
    _allPizzas[entity.Id] = entity;
    await Save();
  }
  
  public async Task Save()
  {
    try
    {
      var directoryPath = Path.GetDirectoryName(_filePath);
      var options = new JsonSerializerOptions
      {
        WriteIndented = true
      };
      if (!Directory.Exists(directoryPath))
      {
        Directory.CreateDirectory(directoryPath);
      }
      var jsonString = JsonSerializer.Serialize(_allPizzas, options);
      await File.WriteAllTextAsync(_filePath, jsonString);
    }
    catch (IOException ioEx)
    {

      throw new IOException("Failure to access data: ", ioEx);
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
}