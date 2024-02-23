using Xunit;
using ContosoPizzaApp.Data;
using ContosoPizzaApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoPizzaApp.Data.Tests
{
  public class PizzaRepositoryTest
  {
    [Fact]
    public async Task Add_ShouldAddPizzaToRepository()
    {
      // Arrange
      var repository = new PizzaRepository();
      var pizza = new Pizza {Name = "Margherita", IsGlutenFree =  true };

      // Act
      await repository.Add(pizza);

      // Assert
      var result = repository._allPizzas[pizza.Id];
      Assert.Equal(pizza.Id, result.Id);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllPizzasFromRepository()
    {
      // Arrange
      var repository = new PizzaRepository();
      var pizza1 = new Pizza {Name = "Margherita", IsGlutenFree =  true };
      var pizza2 = new Pizza {Name = "Capricciosa", IsGlutenFree =  false };
      await repository.Add(pizza1);
      await repository.Add(pizza2);

      // Act
      var result = await repository.GetAll();

      // Assert
      Assert.Equal(2, result.Count);
      Assert.Equal(pizza1.Id, result[pizza1.Id].Id);
      Assert.Equal(pizza2.Id, result[pizza2.Id].Id);
    }

    [Fact]
    public async Task Get_ShouldReturnPizzaFromRepository()
    {
      // Arrange
      var repository = new PizzaRepository();
      var pizza = new Pizza {Name = "Margherita", IsGlutenFree =  true };
      await repository.Add(pizza);

      // Act
      var result = await repository.Get(pizza.Id);

      // Assert
      Assert.Equal(pizza.Id, result.Id);
    }

    [Fact]
    public async Task Delete_ShouldRemovePizzaFromRepository()
    {
      // Arrange
      var repository = new PizzaRepository();
      var pizza = new Pizza {Name = "Margherita", IsGlutenFree =  true };
      await repository.Add(pizza);

      // Act
      await repository.Delete(pizza.Id);

      // Assert
      var result = await repository.GetAll();
      Assert.DoesNotContain(result, p => p.Key == pizza.Id);
    }

    [Fact]
    public async Task Update_ShouldUpdatePizzaInRepository()
    {
      // Arrange
      var repository = new PizzaRepository();
      var pizza = new Pizza {Name = "Margherita", IsGlutenFree =  true };
      await repository.Add(pizza);
      pizza.Name = "Updated Pizza";

      // Act
      await repository.Update(pizza);

      // Assert
      var result = await repository.Get(pizza.Id);
      Assert.Equal(pizza.Name, result.Name);
    }
  }
}
