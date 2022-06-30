namespace SimplePondres.Models
{
    public class SeedHelper
    {
        /// <summary>
        /// Seeded data for product.
        /// </summary>
        /// <returns>List of products.</returns>
        public static IEnumerable<Product> GetProductSeeds()
        {
            var product = new List<Product>()
            {
                new Product(){
                 ProductId = 1,
                 Name = "Simple card",
                 Stock = 5,
                 Description = "This is a wonderful card",
                 Type = "Card",
                 ExternalReference = "Pondres simple card"

                },

                new Product(){
                 ProductId = 2,
                 Name = "Amazing bord",
                 Stock = 0,
                 Description = "The best bord ever",
                 Type = "Bord",
                 ExternalReference = "Pondres amazing bord"

                },

                new Product(){
                 ProductId = 3,
                 Name = "Paper",
                 Stock = 10,
                 Description = "Magic paper",
                 Type = "Print Paper",
                 ExternalReference = "Pondres paper"

                }

         };
            return product;
        }


        /// <summary>
        /// Seeded data for company.
        /// </summary>
        /// <returns>List of companies.</returns>
        public static IEnumerable<Company> GetCompanySeeds()
        {
            var company = new List<Company>()
            {
                new Company(){
                 CompanyId = 1,
                 CompanyName = "Package solutions",
                 CompanyPhoneNumber = 310401574,
                 Email = "package@solutions.com"

                },

                 new Company(){
                 CompanyId = 2,
                 CompanyName = "Het thuiszorg BV",
                 CompanyPhoneNumber = 310401575,
                 Email = "ana@thuiszorg.nl"

                },

         };
            return company;
        }

        /// <summary>
        /// Seeded data for order.
        /// </summary>
        /// <returns>List of orders.</returns>
        public static IEnumerable<Order> GetOrderSeeds()
        {
            var order = new List<Order>()
            {
                new Order(){
                 OrderId = 1,
                 State = "Created",
                 TimeOfDelivery = DateTime.Now,
                 Adress = "Molenlaan 5",
                 ExternalReference = "Customer 1",
                 ExtraRequirements = "Please deliver the order at the warehouse",
                 CompanyId =2,
                 ProductId = 3,
                },

                new Order(){
                 OrderId = 2,
                 State = "Picked",
                 TimeOfDelivery = DateTime.Now,
                 Adress = "Sonseweg 7",
                 ExternalReference = "Customer 2",
                 ExtraRequirements = "No extra requirements",
                 CompanyId =2,
                 ProductId = 3,

                },

                  new Order(){
                 OrderId = 3,
                 State = "Delivered",
                 TimeOfDelivery = DateTime.Now,
                 Adress = "Planetelaan 1",
                 ExternalReference = "Customer 3",
                 ExtraRequirements = "No extra requirements",
                 CompanyId = 1,
                 ProductId = 1,

                }

         };
            return order;
        }

    }
}
