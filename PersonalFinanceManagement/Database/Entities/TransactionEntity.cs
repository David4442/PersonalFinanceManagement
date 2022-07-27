﻿using PersonalFinanceManagement.Models;

namespace PersonalFinanceManagement.Database.Entities
{
    public class TransactionEntity
    {
        public string Id { get; set; }

        public string Beneficiaryname { get; set; }

        public string Date { get; set; }
        public DirectionsEnum? Direction { get; set; }

        public double? Amount { get; set; }

        public string Description { get; set; }

        public string Currency { get; set; }

        public MccCodeEnum? Mcc { get; set; }

        public TransactionKindsEnum? Kind { get; set; }

       
    }
}
