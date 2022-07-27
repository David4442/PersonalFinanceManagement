using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PersonalFinanceManagement.Models
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum SortOrderEnum
    {
        /// <summary>
        /// Enum AscEnum for asc
        /// </summary>
        [EnumMember(Value = "asc")]
        AscEnum = 0,
        /// <summary>
        /// Enum DescEnum for desc
        /// </summary>
        [EnumMember(Value = "desc")]
        DescEnum = 1
    }
}
