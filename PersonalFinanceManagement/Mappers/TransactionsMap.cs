using AutoMapper;
using CsvHelper.Configuration;
using PagedList;
using PersonalFinanceManagement.Database;
using PersonalFinanceManagement.Models;
using System.Text.Json.Serialization;

namespace PersonalFinanceManagement.Mappings
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public class TransactionsMap : ClassMap<Transaction>
    {
        public TransactionsMap()
        {


            Map(m => m.Id).Name("id");
            Map(m => m.BeneficiaryName).Name("beneficiary-name");
            Map(m => m.Date).Name("date");
            Map(m => m.Direction).Name("direction").ToString();
            Map(m => m.Amount).Name("amount");
            Map(m => m.Description).Name("description");
            Map(m => m.Currency).Name("currency");
            Map(m => m.Mcc).Name("mcc");
            Map(m => m.Kind).Name("kind").ToString();
            



        }
    }
}