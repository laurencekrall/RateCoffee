﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCoffee.Service
{
    public class CoffeeRepo
    {
		public List<string> GetStuff()
		{
			using (var db = new RateCoffee.Data.RateCoffeeContext())
			{
				var list = new List<string>();
				// Display all Blogs from the database
				var query = from b in db.Coffee
							orderby b.Name
							select b;

				Console.WriteLine("All blogs in the database:");
				foreach (var item in query)
				{
					list.Add(item.Name);
				}

				return list;
			}
		}
    }
}