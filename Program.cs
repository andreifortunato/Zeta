using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Zeta.Properties;

namespace Zeta
{
    public class Program;
    {

    
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args[]).Build().Run();
        }
    private Produto[] produtos ?= {
    new Produto {Name = "Camisetas", Category = "Sport Casual", Price = 2M},
    new Produto {Name = "Calças", Category = "Sport Casual", Price = 4M},
    new Produto {Name = "Shorts", Category = "Sport Praia", Price = 19M},
    new Produto {Name = "Sapatos", Category = "Sport Casual", Price = 3M}
 };
    [TestMethod]
    public void Sum_Products_Correctly()
    {
        // arrange
        Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
        mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
        .Returns<decimal>(total => total);
        var target = new LinqValueCalculator(mock.Object);
        // act
        var result = target.ValueProducts(products);
        // assert
        Assert.AreEqual(products.Sum(e => e.Price), result);
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
 
    }
}
private Product[] createProduct(decimal value)
{
    return new[] { new Product { Price = value } };
}
[TestMethod]
[ExpectedException(typeof(System.ArgumentOutOfRangeException))]
public void Pass_Through_Variable_Discounts()
{
    // arrange
    Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
    mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
    .Returns<decimal>(total => total);
    mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0)))
    .Throws<System.ArgumentOutOfRangeException>();
    mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100)))
    .Returns<decimal>(total => (total * 0.9M));
    mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100,
    Range.Inclusive))).Returns<decimal>(total => total - 5);
    var target = new LinqValueCalculator(mock.Object);
    Chapter 6 ■ Essential Tools for MVC
    152
     // act
     decimal FiveDollarDiscount = target.ValueProducts(createProduct(5));
     decimal TenDollarDiscount = target.ValueProducts(createProduct(10));
    decimal FiftyDollarDiscount = target.ValueProducts(createProduct(50));
    decimal HundredDollarDiscount = target.ValueProducts(createProduct(100));
    decimal FiveHundredDollarDiscount = target.ValueProducts(createProduct(500));
    // assert
    Assert.AreEqual(5, FiveDollarDiscount, "$5 Fail");
    Assert.AreEqual(5, TenDollarDiscount, "$10 Fail");
    Assert.AreEqual(45, FiftyDollarDiscount, "$50 Fail");
    Assert.AreEqual(95, HundredDollarDiscount, "$100 Fail");
    Assert.AreEqual(450, FiveHundredDollarDiscount, "$500 Fail");
    target.ValueProducts(createProduct(0));

    return public static object DataTimer { get; set; }
      public int Hour { get => hour; set => hour = value; }
}
 }
}
