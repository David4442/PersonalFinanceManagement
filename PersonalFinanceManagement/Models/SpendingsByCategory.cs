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
    ///  
    /// </summary>
    [DataContract]
    public partial class SpendingsByCategory : IEquatable<SpendingsByCategory>
    { 
        /// <summary>
        /// List of spendings by category
        /// </summary>
        /// <value>List of spendings by category</value>

        [DataMember(Name="groups")]
        public List<SpendingInCategory> Groups { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SpendingsByCategory {\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
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
            return obj.GetType() == GetType() && Equals((SpendingsByCategory)obj);
        }

        /// <summary>
        /// Returns true if SpendingsByCategory instances are equal
        /// </summary>
        /// <param name="other">Instance of SpendingsByCategory to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SpendingsByCategory other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Groups == other.Groups ||
                    Groups != null &&
                    Groups.SequenceEqual(other.Groups)
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
                    if (Groups != null)
                    hashCode = hashCode * 59 + Groups.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(SpendingsByCategory left, SpendingsByCategory right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SpendingsByCategory left, SpendingsByCategory right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}