using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RateCoffee.Data.Classes;

namespace RateCoffee.Data
{
	public class RateCoffeeContext : DbContext
	{
		public DbSet<Coffee> Coffee { get; set; }
		public DbSet<Review> Reviews { get; set; }

        public RateCoffeeContext() : base("RateCoffee")
        { }

        private void FixEfProviderServicesProblem()
        {
            // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            // Make sure the provider assembly is available to the running application. 
            // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }

}
