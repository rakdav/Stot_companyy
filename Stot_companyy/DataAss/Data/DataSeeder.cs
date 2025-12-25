using Faker;
using Stot_company.DataAss.Entity;
using System.ComponentModel.DataAnnotations;

namespace Stot_company.DataAss.Data
{
    public static class DataSeeder
    {
        public static void SeedData(GgContext stotcomp)
        {
            if (!stotcomp.Clients.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var dep = new Client
                    {
                        NameClient = Lorem.Sentence(),
                        LastNameClient = Lorem.Sentence(),
                        Email = Faker.Internet.Email(),
                        Age = new Random().Next(18, 80),
                        Passport = new Random().Next(100000, 999999),
                        Payment = new Random().Next(10, 10000),
                        ArrearsClient = DateTime.Now,
                        Sex = (new Random().Next(0,2))==1?"Male":"Female"
                    };
                    stotcomp.Clients.Add(dep);
                    stotcomp.SaveChanges();
                    var cnst = new Const_Comp
                    {
                        NameComp = Name.FullName(),
                        Location = Lorem.Sentence(),
                        WorkPrice = new Random().Next(10, 19999).ToString()
                    };
                    stotcomp.Consts.Add(cnst);
                    stotcomp.SaveChanges();

                    var ord = new Order
                    {
                        NameOrder = Name.FullName(),
                        DateOrder = DateTime.Now,
                        Price = new Random().Next(1000, 2232),
                        IdClient = dep.IdClient,
                        IdComp = cnst.IdComp
                    };
                    stotcomp.Orders.Add(ord);
                    stotcomp.SaveChanges();
                    for (int k = 0; k < 5; k++)
                    {
                        var wrk = new Worker
                        {
                            NameWorker = Name.FullName(),
                            LastNameWorker = Name.FullName(),
                            Post = Lorem.Sentence(),
                            IdComp = cnst.IdComp,
                            IdCompNavigation = cnst
                        };
                        stotcomp.Workers.Add(wrk);
                    }
                    stotcomp.SaveChanges();
                }
            }

        }
    }
}
