using CsvHelper.Configuration.Attributes;

namespace PersonalFinanceManagement.Models
{
    public class file
    {
        [Index(0)] public string id { get; set; }
        [Index(1)] public string beneficiaryname { get; set; }
        [Index(2)] public string date { get; set; }
        [Index(3)] public DirectionsEnum direction { get; set; }
        [Index(4)] public double amount { get; set; }
        [Index(5)] public string description { get; set; }
        [Index(6)] public string currency { get; set; }
        [Index(7)] public MccCodeEnum mcc { get; set; }
        [Index(8)] public TransactionKindsEnum kind { get; set; }




    }
}
