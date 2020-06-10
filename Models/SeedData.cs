using Foods_CompShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foods_CompShop.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Foods_CompShopContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Foods_CompShopContext>>()))
            {
                // Look for any movies.
                if (context.CompShop.Any())
                {
                    return;   // DB has been seeded
                }

                context.CompShop.AddRange(
                    new CompShop
                    {
                        CompShopId = 1,
                        Dept = "23",
                        ItemNo = "",
                        Description = "",
                        WHSE = "",
                        State = "",
                        MAC = "",
                        Sell = "",
                        IMU = "",
                        FutureSellPrice = "",
                        FutureSellDate = "",
                        LowestComp = "",
                        MaxPrice = "",
                        NewSell = "",
                        NewPrice = "",
                        SamsConvPrice = "",
                        SamsShelfPrice = "",
                        SamsAddtnPrice = "",
                        SamsShoppedURL = "",
                        SamsShoppedZip = "",
                        BJsConvPrice = "",
                        BJsShelfPrice = "",
                        BJsAddtnPrice = "",
                        BJsShoppedURL = "",
                        BJsShoppedZip = "",
                        BuyerNo = "",
                        Category = "",
                        BuyerComments = "",
                        PulledDate = ""
                    },

                    new CompShop
                    {
                        CompShopId = 2,
                        Dept = "23",
                        ItemNo = "",
                        Description = "",
                        WHSE = "",
                        State = "",
                        MAC = "",
                        Sell = "",
                        IMU = "",
                        FutureSellPrice = "",
                        FutureSellDate = "",
                        LowestComp = "",
                        MaxPrice = "",
                        NewSell = "",
                        NewPrice = "",
                        SamsConvPrice = "",
                        SamsShelfPrice = "",
                        SamsAddtnPrice = "",
                        SamsShoppedURL = "",
                        SamsShoppedZip = "",
                        BJsConvPrice = "",
                        BJsShelfPrice = "",
                        BJsAddtnPrice = "",
                        BJsShoppedURL = "",
                        BJsShoppedZip = "",
                        BuyerNo = "",
                        Category = "",
                        BuyerComments = "",
                        PulledDate = ""
                    }
                );
                context.SaveChanges();
            }
        }
    }
}