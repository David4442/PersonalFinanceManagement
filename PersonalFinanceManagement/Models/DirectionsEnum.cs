using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PersonalFinanceManagement.Models
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DirectionsEnum
    {   
       d=0,
       c=1,
       
       
    }
}
