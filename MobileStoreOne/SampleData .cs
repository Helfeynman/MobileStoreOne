using System.Linq;
using MobileStoreOne.Models;

namespace MobileStoreOne
{
    public static class SampleData
    {
        public static void Initialize(MobileContext context)
        {
            if (context.Phones.Count() < 5)
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone X",
                        Company = "Apple",
                        Price = 600
                    },
                    new Phone
                    {
                        Name = "Samsung Galaxy Edge",
                        Company = "Samsung",
                        Price = 550
                    },
                    new Phone
                    {
                        Name = "Pixel 3",
                        Company = "Google",
                        Price = 500
                    },
                    new Phone
                    {
                        Name = "Mi A1",
                        Company = "Xiaomi",
                        Price = 500
                    },
                    new Phone
                    {
                        Name = "Some",
                        Company = "Some",
                        Price = 500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}