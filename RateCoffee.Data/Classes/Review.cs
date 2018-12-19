using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCoffee.Data.Classes
{
	public class Review
	{
		[Key]
		public int ReviewId { get; set; }
		public int Rating { get; set; }
	}
}
