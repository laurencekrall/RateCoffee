using System.Collections.Generic;

namespace RateCoffee.Data
{
    public interface ICoffeeRepo
    {
        bool Add(string value);
        List<string> GetStuff();
    }
}