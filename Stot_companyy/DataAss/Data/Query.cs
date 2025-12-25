using Stot_company.DataAss.DAO;
using Stot_company.DataAss.Entity;
using HotChocolate.Subscriptions;
using HotChocolate;

namespace Stot_company.DataAss.Data
{
    public class Query
    {
        public List<Client> AllEmployeeOnly([Service] ClientRepositiry clientRepositiry) => clientRepositiry.GetAllClientonly();
        public List<Order> AllOrderByClientId([Service] OrderRepository orderRepository, [Service] ITopicEventSender eventSender, int id) => orderRepository.GetOrderByClientId(id);

        public List<Worker> AllWorker([Service] WorkerRepository workerrepository) =>workerrepository.AllWorker();

        public List<Const_Comp> AllConst_CompandAllWorker([Service] Const_CompRepository const_CompRepository) => const_CompRepository.AllConst_CompandAllWorker();

        public List<Order> AllOrderByComp([Service] OrderRepository orderRepository, string start, string end) => orderRepository.GetAllOrdersDefiniteConst_Comp(start, end);

        public decimal AllOrderSum([Service] OrderRepository orderRepository) => orderRepository.AllSumOrder();

        public List<Order> OverdueTime([Service] OrderRepository orderRepository, DateTime date) => orderRepository.TimeOverdueWork(date);
        public List<Order> NearestOne([Service] OrderRepository orderRepository, DateTime date) => orderRepository.OrderNearestOne(date);

        public List<Client> PaymentClient([Service] ClientRepositiry clientRepositiry) => clientRepositiry.ListPaymentClient();

        public List<Client> Arrears([Service] ClientRepositiry clientRepositiry) => clientRepositiry.ArrearsClient();



    }
}
