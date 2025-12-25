using Stot_company.DataAss.Entity;
using Microsoft.EntityFrameworkCore;


namespace Stot_company.DataAss.DAO
{
    public class Const_CompRepository
    {
        private readonly GgContext _stotcomp;
        public Const_CompRepository(GgContext stotcomp)
        {
            _stotcomp = stotcomp;
        }

        public List<Const_Comp> GetAllClientonly()
        {
            return _stotcomp.Consts.ToList();
        }

        public Const_Comp GetConst_CompById(int id)
        {
            var const_comp = _stotcomp.Consts.Include(q => q.Orders).Where(q => q.IdComp == id).FirstOrDefault();
            if (const_comp != null) return const_comp;
            return const_comp!;
        }

        public List<Const_Comp> GetAllClientWithOrder()
        {
            return _stotcomp.Consts.Include(q => q.Workers).ToList();
        }

        public async Task<Const_Comp> CreateConst_Comp(Const_Comp const_Comp)
        {
            await _stotcomp.Consts.AddAsync(const_Comp);
            await _stotcomp.SaveChangesAsync();
            return const_Comp;
        }

        public List<Const_Comp> AllConst_CompandAllWorker()
        {
            return _stotcomp.Consts.Include(_ => _.Workers).ToList();
        }

        public decimal AllWorkSum()
        {
            return _stotcomp.Orders.Sum(q => q.Price);
        }

        


    }
}
