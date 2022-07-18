using PersonalFinanceManagement.Database.Entities;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManagement

{
    public class Transaction
    {
        
        public string TransactionId { get; set; }

        public string beneficiaryname { get; set; }

        public DateTime date { get; set; }

        public string direction { get; set; }

        public float amount{ get; set; }

        public TransactionCurrency currency { get; set; }
        public string mcc { get; set; }
        public TransactionKind kind { get; set; }

    }
}
