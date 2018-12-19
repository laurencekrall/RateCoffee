using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCoffee.Data.Classes
{
	public class Coffee
	{
		[Key]
		public int CoffeeId { get; set; }
		public string Name { get; set; }
		public CoffeeType Type { get; set; }
		public Roast Roast { get; set; }

		public virtual IEnumerable<Review> Reviews { get; set; }
	}
}
