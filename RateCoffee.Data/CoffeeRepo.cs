using RateCoffee.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCoffee.Data
{
    public class CoffeeRepo : ICoffeeRepo
    {
        private RateCoffeeContext _rateCoffeeContext;

        public CoffeeRepo(RateCoffeeContext rateCoffeeContext)
        {
            _rateCoffeeContext = rateCoffeeContext;
        }

        public List<string> GetStuff()
		{
			var list = new List<string>();
			// Display all Blogs from the database
			var query = from b in _rateCoffeeContext.Coffee
						orderby b.Name
						select b;

			foreach (var item in query)
			{
				list.Add(item.Name);
			}

			return list;
		
		}

        public bool Add(string value)
        {           
            var coffee = new Coffee()
            {
                Name = value,
                Roast = Roast.Light,
                Type = CoffeeType.None
            };
            _rateCoffeeContext.Coffee.Add(coffee);
            _rateCoffeeContext.SaveChanges();
            
            return true;
        }
    }
}
