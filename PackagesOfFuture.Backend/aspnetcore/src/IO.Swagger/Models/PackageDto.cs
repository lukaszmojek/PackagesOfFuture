/*
 * PackagesOfFuture.Api
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
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

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PackageDto : IEquatable<PackageDto>
    { 
        /// <summary>
        /// Gets or Sets DeliveryDate
        /// </summary>
        [DataMember(Name="deliveryDate")]
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status")]
        public PackageStatus Status { get; set; }

        /// <summary>
        /// Gets or Sets Width
        /// </summary>
        [DataMember(Name="width")]
        public double? Width { get; set; }

        /// <summary>
        /// Gets or Sets Height
        /// </summary>
        [DataMember(Name="height")]
        public double? Height { get; set; }

        /// <summary>
        /// Gets or Sets Length
        /// </summary>
        [DataMember(Name="length")]
        public double? Length { get; set; }

        /// <summary>
        /// Gets or Sets Weight
        /// </summary>
        [DataMember(Name="weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// Gets or Sets Payment
        /// </summary>
        [DataMember(Name="payment")]
        public PaymentDto Payment { get; set; }

        /// <summary>
        /// Gets or Sets DeliveryAddress
        /// </summary>
        [DataMember(Name="deliveryAddress")]
        public AddressDto DeliveryAddress { get; set; }

        /// <summary>
        /// Gets or Sets ReceiveAddress
        /// </summary>
        [DataMember(Name="receiveAddress")]
        public AddressDto ReceiveAddress { get; set; }

        /// <summary>
        /// Gets or Sets DeliveryAddressId
        /// </summary>
        [DataMember(Name="deliveryAddressId")]
        public int? DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or Sets ReceiveAddressId
        /// </summary>
        [DataMember(Name="receiveAddressId")]
        public int? ReceiveAddressId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PackageDto {\n");
            sb.Append("  DeliveryDate: ").Append(DeliveryDate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Length: ").Append(Length).Append("\n");
            sb.Append("  Weight: ").Append(Weight).Append("\n");
            sb.Append("  Payment: ").Append(Payment).Append("\n");
            sb.Append("  DeliveryAddress: ").Append(DeliveryAddress).Append("\n");
            sb.Append("  ReceiveAddress: ").Append(ReceiveAddress).Append("\n");
            sb.Append("  DeliveryAddressId: ").Append(DeliveryAddressId).Append("\n");
            sb.Append("  ReceiveAddressId: ").Append(ReceiveAddressId).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PackageDto)obj);
        }

        /// <summary>
        /// Returns true if PackageDto instances are equal
        /// </summary>
        /// <param name="other">Instance of PackageDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PackageDto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    DeliveryDate == other.DeliveryDate ||
                    DeliveryDate != null &&
                    DeliveryDate.Equals(other.DeliveryDate)
                ) && 
                (
                    Status == other.Status ||
                    Status != null &&
                    Status.Equals(other.Status)
                ) && 
                (
                    Width == other.Width ||
                    Width != null &&
                    Width.Equals(other.Width)
                ) && 
                (
                    Height == other.Height ||
                    Height != null &&
                    Height.Equals(other.Height)
                ) && 
                (
                    Length == other.Length ||
                    Length != null &&
                    Length.Equals(other.Length)
                ) && 
                (
                    Weight == other.Weight ||
                    Weight != null &&
                    Weight.Equals(other.Weight)
                ) && 
                (
                    Payment == other.Payment ||
                    Payment != null &&
                    Payment.Equals(other.Payment)
                ) && 
                (
                    DeliveryAddress == other.DeliveryAddress ||
                    DeliveryAddress != null &&
                    DeliveryAddress.Equals(other.DeliveryAddress)
                ) && 
                (
                    ReceiveAddress == other.ReceiveAddress ||
                    ReceiveAddress != null &&
                    ReceiveAddress.Equals(other.ReceiveAddress)
                ) && 
                (
                    DeliveryAddressId == other.DeliveryAddressId ||
                    DeliveryAddressId != null &&
                    DeliveryAddressId.Equals(other.DeliveryAddressId)
                ) && 
                (
                    ReceiveAddressId == other.ReceiveAddressId ||
                    ReceiveAddressId != null &&
                    ReceiveAddressId.Equals(other.ReceiveAddressId)
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
                    if (DeliveryDate != null)
                    hashCode = hashCode * 59 + DeliveryDate.GetHashCode();
                    if (Status != null)
                    hashCode = hashCode * 59 + Status.GetHashCode();
                    if (Width != null)
                    hashCode = hashCode * 59 + Width.GetHashCode();
                    if (Height != null)
                    hashCode = hashCode * 59 + Height.GetHashCode();
                    if (Length != null)
                    hashCode = hashCode * 59 + Length.GetHashCode();
                    if (Weight != null)
                    hashCode = hashCode * 59 + Weight.GetHashCode();
                    if (Payment != null)
                    hashCode = hashCode * 59 + Payment.GetHashCode();
                    if (DeliveryAddress != null)
                    hashCode = hashCode * 59 + DeliveryAddress.GetHashCode();
                    if (ReceiveAddress != null)
                    hashCode = hashCode * 59 + ReceiveAddress.GetHashCode();
                    if (DeliveryAddressId != null)
                    hashCode = hashCode * 59 + DeliveryAddressId.GetHashCode();
                    if (ReceiveAddressId != null)
                    hashCode = hashCode * 59 + ReceiveAddressId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(PackageDto left, PackageDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PackageDto left, PackageDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
