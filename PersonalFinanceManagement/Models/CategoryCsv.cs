/*
 * Personal Finance Management API
 *
 * Personal Finance Management API allows analyze of a client's spending patterns against pre-defined budgets over time 
 *
 * OpenAPI spec version: v1
 * Contact: aleksandar.milosevic@asseco-see.rs
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PersonalFinanceManagement.Models
{ 
    /// <summary>
    /// category-csv
    /// </summary>
    [DataContract]
    public partial class CategoryCsv : IEquatable<CategoryCsv>
    { 
        /// <summary>
        /// Category code
        /// </summary>
        /// <value>Category code</value>

        [DataMember(Name="code")]
        public string Code { get; set; }

        /// <summary>
        /// Parent code name
        /// </summary>
        /// <value>Parent code name</value>

        [DataMember(Name="parent-code")]
        public string ParentCode { get; set; }

        /// <summary>
        /// Category or sub category name
        /// </summary>
        /// <value>Category or sub category name</value>

        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CategoryCsv {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  ParentCode: ").Append(ParentCode).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CategoryCsv)obj);
        }

        /// <summary>
        /// Returns true if CategoryCsv instances are equal
        /// </summary>
        /// <param name="other">Instance of CategoryCsv to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CategoryCsv other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Code == other.Code ||
                    Code != null &&
                    Code.Equals(other.Code)
                ) && 
                (
                    ParentCode == other.ParentCode ||
                    ParentCode != null &&
                    ParentCode.Equals(other.ParentCode)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Code != null)
                    hashCode = hashCode * 59 + Code.GetHashCode();
                    if (ParentCode != null)
                    hashCode = hashCode * 59 + ParentCode.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CategoryCsv left, CategoryCsv right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CategoryCsv left, CategoryCsv right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
