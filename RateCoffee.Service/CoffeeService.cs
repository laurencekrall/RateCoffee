using RateCoffee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCoffee.Service
{
    public class CoffeeService : ICoffeeService
    {
        ICoffeeRepo _repo;

        public CoffeeService(ICoffeeRepo repo)
        {
            _repo = repo;
        }

        public bool Add(string value)
        {
            return _repo.Add(value);
        }

        public List<string> GetStuff()
        {
            return _repo.GetStuff();
        }
    }
}
