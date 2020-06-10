using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Foods_CompShop.Models;

namespace Foods_CompShop.Data
{
    public class Foods_CompShopContext : DbContext
    {
        public Foods_CompShopContext (DbContextOptions<Foods_CompShopContext> options)
            : base(options)
        {
        }

        public DbSet<Foods_CompShop.Models.CompShop> CompShop { get; set; }
    }
}
