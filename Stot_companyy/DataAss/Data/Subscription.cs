using Stot_company.DataAss.Entity;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate;



namespace Stot_company.DataAss.Data
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Client>> OnClientCreate([Service] ITopicEventReceiver receiver, CancellationToken cancellationToken)
        {
            return await receiver.SubscribeAsync<Client>("ClientCreated", cancellationToken);
        }
        
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Order>> OnOrderCreate([Service] ITopicEventReceiver receiver, CancellationToken cancellationToken)
        {
            return await receiver.SubscribeAsync<Order>("OrderCreated", cancellationToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Const_Comp>> OnConst_CompCreate([Service] ITopicEventReceiver receiver, CancellationToken cancellationToken)
        {
            return await receiver.SubscribeAsync<Const_Comp>("Const_CompCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Worker>> OnWorkerCreate([Service] ITopicEventReceiver receiver, CancellationToken cancellationToken)
        {
            return await receiver.SubscribeAsync<Worker>("WorkerCreated", cancellationToken);
        }

    }
}
