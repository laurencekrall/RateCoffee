using System.Collections.Generic;

namespace RateCoffee.Service
{
    public interface ICoffeeService
    {
        bool Add(string value);
        List<string> GetStuff();
    }
}