using AutoMapper;
using CsvHelper.Configuration;
using PagedList;
using PersonalFinanceManagement.Database;
using PersonalFinanceManagement.Database.Entities;
using PersonalFinanceManagement.Models;
using System.Text.Json.Serialization;

namespace PersonalFinanceManagement.Mappings
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public class CategoriesMap : ClassMap<CategoryEntity>
    {
        public CategoriesMap()
        {


            Map(m => m.Code).Name("code").Index(0);
            Map(m => m.ParentCode).Name("parent-code").Index(1);
            Map(m => m.Name).Name("name").Index(2);





        }
    }
}