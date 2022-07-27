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
    public partial class ValidationproblemErrors : IEquatable<ValidationproblemErrors>
    { 
        /// <summary>
        /// Name of input element (field or parameter) that is in invalid. If missing or null it is interpreted that validation error refers to entire request rather than to specific element.
        /// </summary>
        /// <value>Name of input element (field or parameter) that is in invalid. If missing or null it is interpreted that validation error refers to entire request rather than to specific element.</value>
        [Required]

        [DataMember(Name="tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Unique literal that identifies kind of validation error
        /// </summary>
        /// <value>Unique literal that identifies kind of validation error</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ErrorEnum
        {
            /// <summary>
            /// Enum MinLengthEnum for min-length
            /// </summary>
            [EnumMember(Value = "min-length")]
            MinLengthEnum = 0,
            /// <summary>
            /// Enum MaxLengthEnum for max-length
            /// </summary>
            [EnumMember(Value = "max-length")]
            MaxLengthEnum = 1,
            /// <summary>
            /// Enum RequiredEnum for required
            /// </summary>
            [EnumMember(Value = "required")]
            RequiredEnum = 2,
            /// <summary>
            /// Enum OutOfRangeEnum for out-of-range
            /// </summary>
            [EnumMember(Value = "out-of-range")]
            OutOfRangeEnum = 3,
            /// <summary>
            /// Enum InvalidFormatEnum for invalid-format
            /// </summary>
            [EnumMember(Value = "invalid-format")]
            InvalidFormatEnum = 4,
            /// <summary>
            /// Enum UnknownEnumEnum for unknown-enum
            /// </summary>
            [EnumMember(Value = "unknown-enum")]
            UnknownEnumEnum = 5,
            /// <summary>
            /// Enum NotOnListEnum for not-on-list
            /// </summary>
            [EnumMember(Value = "not-on-list")]
            NotOnListEnum = 6,
            /// <summary>
            /// Enum CheckDigitInvalidEnum for check-digit-invalid
            /// </summary>
            [EnumMember(Value = "check-digit-invalid")]
            CheckDigitInvalidEnum = 7,
            /// <summary>
            /// Enum CombinationRequiredEnum for combination-required
            /// </summary>
            [EnumMember(Value = "combination-required")]
            CombinationRequiredEnum = 8,
            /// <summary>
            /// Enum ReadOnlyEnum for read-only
            /// </summary>
            [EnumMember(Value = "read-only")]
            ReadOnlyEnum = 9        }

        /// <summary>
        /// Unique literal that identifies kind of validation error
        /// </summary>
        /// <value>Unique literal that identifies kind of validation error</value>
        [Required]

        [DataMember(Name="error")]
        public ErrorEnum? Error { get; set; }

        /// <summary>
        /// Message that explains failed validation. To support translation message may embed variable parameters in curly brackets.
        /// </summary>
        /// <value>Message that explains failed validation. To support translation message may embed variable parameters in curly brackets.</value>
        [Required]

        [DataMember(Name="message")]
        public string Message { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ValidationproblemErrors {\n");
            sb.Append("  Tag: ").Append(Tag).Append("\n");
            sb.Append("  Error: ").Append(Error).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ValidationproblemErrors)obj);
        }

        /// <summary>
        /// Returns true if ValidationproblemErrors instances are equal
        /// </summary>
        /// <param name="other">Instance of ValidationproblemErrors to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ValidationproblemErrors other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Tag == other.Tag ||
                    Tag != null &&
                    Tag.Equals(other.Tag)
                ) && 
                (
                    Error == other.Error ||
                    Error != null &&
                    Error.Equals(other.Error)
                ) && 
                (
                    Message == other.Message ||
                    Message != null &&
                    Message.Equals(other.Message)
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
                    if (Tag != null)
                    hashCode = hashCode * 59 + Tag.GetHashCode();
                    if (Error != null)
                    hashCode = hashCode * 59 + Error.GetHashCode();
                    if (Message != null)
                    hashCode = hashCode * 59 + Message.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ValidationproblemErrors left, ValidationproblemErrors right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValidationproblemErrors left, ValidationproblemErrors right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
