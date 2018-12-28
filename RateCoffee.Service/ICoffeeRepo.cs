using System.Collections.Generic;

namespace RateCoffee.Service
{
    public interface ICoffeeRepo
    {
        bool Add(string value);
        List<string> GetStuff();
    }
}