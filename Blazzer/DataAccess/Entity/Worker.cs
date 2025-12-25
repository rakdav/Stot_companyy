using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace Stot_company.DataAss.Entity
{
    public class Worker
    {
        public int IdWorker { get; set; }
        public string? NameWorker { get; set; }
        public string? LastNameWorker { get; set; }

        public string? Post { get; set; }
        public int IdComp {  get; set; }
        public override string ToString()
        {
            return $"IdWorker: {IdWorker},\n" +
                $"Name_Worker: {NameWorker},\n" +
                $"Last_Name_Worker: {LastNameWorker},\n" +
                $"Post: {Post},\n" +
                $"IdComp: {IdComp},\n";
        }
    }
}
