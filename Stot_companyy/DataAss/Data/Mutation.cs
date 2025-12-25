using HotChocolate;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Hosting;
using Stot_company.DataAss.DAO;
using Stot_company.DataAss.Entity;
using System.Security.Claims;


namespace Stot_company.DataAss.Data
{
    public class Mutation
    {

        public async Task<Client> CreateClient([Service] ClientRepositiry clientRepositiry, [Service] ITopicEventSender eventSender, string depName, string lastName, DateTime dateTime, string email, decimal payment, int age, int passport, string sex, int id)
        {
            var dep = new Client
            { 
                NameClient = depName,
                LastNameClient = lastName,
                Email = email,
                Age = age,
                Passport = passport,
                Sex = sex,
                ArrearsClient = dateTime,
                Payment = payment,
                IdClient = id
                
            };
            var createDep = await clientRepositiry.CreateClient(dep);
            await eventSender.SendAsync("ClientCreated", createDep);
            return createDep;
        }

        public async Task<Order> CreateWithClientId([Service] OrderRepository orderRepository, [Service] ITopicEventSender eventSender, string name_Order, int price,int ClnId, DateTime dataOrder, int id)
        { 
            Order ord = new Order
            {
                IdOrder = id,
                NameOrder = name_Order,
                Price = price,
                DateOrder = dataOrder,
                IdClient = ClnId
            };
            var createOrd = await orderRepository.CreateOrder(ord);
            return createOrd;
        }
        public async Task<Order> CreateWithClientName([Service] OrderRepository orderRepository, [Service] ITopicEventSender eventSender, string name_Order, int price, string clnName, DateTime dataOrder, int id)
        {
            Order ord = new Order
            {
                IdOrder = id,
                NameOrder = name_Order,
                Price = price,
                DateOrder = dataOrder,
                IdClientNavigation= new Client { NameClient = clnName}
            };
            var createOrd = await orderRepository.CreateOrder(ord);
            return createOrd;
        }

        public async Task<Client> EditClient([Service] ClientRepositiry clientRepositiry, [Service] ITopicEventSender eventSender, string depName, string lastName, DateTime dateTime, string email, decimal payment, int age, int passport, string sex, int id)
        {
            Client client = new Client
            {
                NameClient = depName,
                LastNameClient = lastName,
                Email = email,
                Age = age,
                Passport = passport,
                Sex = sex,
                ArrearsClient = dateTime,
                Payment = payment,
                IdClient = id

            };
            var edit = await clientRepositiry.EditClient(client);
            return edit;
        }

        public async Task<Client> DeleteClient([Service] ClientRepositiry clientRepositiry, [Service] ITopicEventSender eventSender, int id)
        {
            return await clientRepositiry.DeleteClient(id);
        }

        public async Task<Order> CreateOrder([Service] OrderRepository orderRepository, [Service] ITopicEventSender eventSender, string name_Order, int price, int ClnId, DateTime dataOrder, int id)
        {
            var dep = new Order
            {
                IdOrder = id,
                NameOrder = name_Order,
                Price = price,
                DateOrder = dataOrder,
                IdClient = ClnId
            };
            var createDep = await orderRepository.CreateOrder(dep);
            await eventSender.SendAsync("OrderCreated", createDep);
            return createDep;
        }

        public async Task<Const_Comp> CreateWithOrderId([Service] Const_CompRepository const_CompRepository, [Service] ITopicEventSender eventSender, int id, string name_Const, string location,string wk_price)
        {
            Const_Comp cnst = new Const_Comp
            {
                IdComp = id,
               NameComp = name_Const,
               Location = location,
               WorkPrice = wk_price,
            };
            var createOrd = await const_CompRepository.CreateConst_Comp(cnst);
            return createOrd;
        }
        public async Task<Const_Comp> CreateWithOrderName([Service] Const_CompRepository const_CompRepository, [Service] ITopicEventSender eventSender, int id, string name_Const, string wk_price,  string  location,string ordName)
        {
            Const_Comp cnst = new Const_Comp
            {
                IdComp = id,
                NameComp = name_Const,
                Location = location,
                WorkPrice = wk_price
            };
            var createOrd = await const_CompRepository.CreateConst_Comp(cnst);
            return createOrd;
        }
        public async Task<Const_Comp> CreateConst_Comp([Service] Const_CompRepository const_CompRepository, [Service] ITopicEventSender eventSender, int id, string wk_price, string name_Const, string location)
        {
            var dep = new Const_Comp 
            {
                IdComp = id,
                NameComp = name_Const,
                Location = location,
                WorkPrice = wk_price,
            };
            var createDep = await const_CompRepository.CreateConst_Comp(dep);
            await eventSender.SendAsync("Const_CompCreated", createDep);
            return createDep;
        }

        public async Task<Worker> CreateWithConst_CompId([Service] WorkerRepository workerRepository, [Service] ITopicEventSender eventSender, int id, string name_Const, string last_Name_Worker, string post, int wrkId)
        {
            Worker wrk = new Worker
            {
               IdWorker = id,
               NameWorker = name_Const,
               LastNameWorker = last_Name_Worker,
               Post = post,
               IdComp = wrkId
            };
            var createOrd = await workerRepository.CreateWorker(wrk);
            return createOrd;
        }
        public async Task<Worker> CreateWithOrderName([Service] WorkerRepository workerRepository, [Service] ITopicEventSender eventSender, int id, string name_Const, string last_Name_Worker, string post, int wrkId)
        {
            Worker wrk = new Worker
            {
                IdWorker = id,
                NameWorker = name_Const,
                LastNameWorker = last_Name_Worker,
                Post = post,
                IdCompNavigation = new Const_Comp { IdComp = wrkId }
            };
            var createOrd = await workerRepository.CreateWorker(wrk);
            return createOrd;
        }
        public async Task<Worker> CreateWorker([Service] WorkerRepository workerRepository, [Service] ITopicEventSender eventSender, int id, string name_Const, string last_Name_Worker, string post, int wrkId)
        {
            var dep = new Worker
            {
                IdWorker = id,
                NameWorker = name_Const,
                LastNameWorker = last_Name_Worker,
                Post = post,
                IdComp = wrkId
            };
            var createDep = await workerRepository.CreateWorker(dep);
            await eventSender.SendAsync("WorkerCreated", createDep);
            return createDep;
        }
    }
}
