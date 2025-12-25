using Stot_company.DataAss.Entity;
using Microsoft.EntityFrameworkCore;


namespace Stot_company.DataAss.DAO
{
    public class OrderRepository
    {
        private readonly GgContext _stotcomp;
        public OrderRepository(GgContext stotcomp)
        {
            _stotcomp = stotcomp;
        }

        public List<Order> GetAllClientonly()
        {
            return _stotcomp.Orders.ToList();

        }

        public List<Order> GetOrderByClientId(int id)
        {
            var order = _stotcomp.Orders.Include(q => q.IdClientNavigation).Where(q => q.IdClient == id).ToList();
            if (order != null) return order;
            return order!;
        }

        public List<Client> GetAllClientWithOrder()
        {
            return _stotcomp.Clients.Include(q => q.Orders).ToList();
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _stotcomp.Orders.AddAsync(order);
            await _stotcomp.SaveChangesAsync();
            return order;
        }

        public List<Order> GetAllOrdersDefiniteConst_Comp(string start, string end)
        {
            return _stotcomp.Orders.Where(q => q.DateOrder >= DateTime.Parse(start) &&
            q.DateOrder <= (DateTime.Parse(end))).ToList();
        }

        public decimal AllSumOrder()
        {
            return _stotcomp.Orders.Sum(q => q.Price);
        }
        public List<Order> TimeOverdueWork(DateTime date)
        {
            return _stotcomp.Orders.Include(q => q.DateOrder).ToList();
        }
        public List<Order> OrderNearestOne(DateTime date)
        {
            return _stotcomp.Orders.Include(q => q.DateOrder).ToList();
        }
    }
}
