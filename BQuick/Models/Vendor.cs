using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Vendor
    {
        public Vendor()
        {
            ItemVendors = new HashSet<ItemVendor>();
            VendorBankAccounts = new HashSet<VendorBankAccount>();
            VendorAttachments = new HashSet<VendorAttachment>();
        }

        [Key]
        public int VendorID { get; set; }

        [Required, StringLength(100)]
        public string VendorName { get; set; }

        [Required, StringLength(20)]
        public string VendorCode { get; set; }

        [StringLength(100)]
        public string ContactPerson { get; set; }

        [StringLength(100), EmailAddress]
        public string Email { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        [StringLength(50)]
        public string VendorType { get; set; }

        [StringLength(50)]
        public string VendorCategory { get; set; }

        public int? VendorRating { get; set; }

        [StringLength(100)]
        public string PaymentTerm { get; set; }

        [StringLength(255)]
        public string BillingAddress { get; set; }

        [StringLength(100)]
        public string BillingCity { get; set; }

        [StringLength(100)]
        public string BillingProvince { get; set; }

        [StringLength(100)]
        public string BillingCountry { get; set; }

        [StringLength(20)]
        public string BillingPostalCode { get; set; }

        [StringLength(255)]
        public string ShipmentAddress { get; set; }

        [StringLength(100)]
        public string ShipmentCity { get; set; }

        [StringLength(100)]
        public string ShipmentProvince { get; set; }

        [StringLength(100)]
        public string ShipmentCountry { get; set; }

        [StringLength(20)]
        public string ShipmentPostalCode { get; set; }

        public int? PurchasingManagerID { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("PurchasingManagerID")]
        public virtual User PurchasingManager { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<ItemVendor> ItemVendors { get; set; }
        public virtual ICollection<VendorBankAccount> VendorBankAccounts { get; set; }
        public virtual ICollection<VendorAttachment> VendorAttachments { get; set; }
    }
}
