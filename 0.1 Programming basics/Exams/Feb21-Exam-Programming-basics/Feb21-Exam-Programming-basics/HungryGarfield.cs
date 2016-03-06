using static System.Console;

public class HungryGarfield
{
    public static void Main()
    {
        decimal money = decimal.Parse(ReadLine()),
         rate = decimal.Parse(ReadLine()),
         pizzaPrice = decimal.Parse(ReadLine()),
         lasagnaPrice = decimal.Parse(ReadLine()),
         sandwichPrice = decimal.Parse(ReadLine()),
         pizzaQuantity = decimal.Parse(ReadLine()),
         lasagnaQuantity = decimal.Parse(ReadLine()),
         sandwichQuantity = decimal.Parse(ReadLine()),
         moneySpent = (pizzaPrice / rate * pizzaQuantity) +
            (lasagnaPrice / rate * lasagnaQuantity) +
            (sandwichPrice / rate * sandwichQuantity);

        WriteLine(
            money >= moneySpent
                ? $"Garfield is well fed, John is awesome. Money left: ${(money - moneySpent):F2}."
                : $"Garfield is hungry. John is a badass. Money needed: ${(moneySpent - money):F2}.");
    }
}