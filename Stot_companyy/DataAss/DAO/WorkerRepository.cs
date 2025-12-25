using Stot_company.DataAss.Entity;
using Microsoft.EntityFrameworkCore;


namespace Stot_company.DataAss.DAO
{
    public class WorkerRepository
    {
        private readonly GgContext _stotcomp;
        public WorkerRepository(GgContext stotcomp)
        {
            _stotcomp = stotcomp;
        }

        public Worker GetConst_CompById(int id)
        {
            var worker = _stotcomp.Workers.Include(q => q.IdCompNavigation).Where(q => q.IdWorker == id).FirstOrDefault();
            if (worker != null) return worker;
            return worker!;
        }

        public List<Worker> AllWorker()
        {
            return _stotcomp.Workers.ToList();
        }
        public async Task<Worker> CreateWorker(Worker worker)
        {
            await _stotcomp.Workers.AddAsync(worker);
            await _stotcomp.SaveChangesAsync();
            return worker;
        }
    }
}
