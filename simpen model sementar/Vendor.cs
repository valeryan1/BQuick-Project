using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Vendor
    {
        [Key]
        public int VendorID { get; set; }

        [Required]
        [StringLength(200)]
        public string VendorName { get; set; }

        [StringLength(50)]
        public string VendorCode { get; set; } // Unik, diindeks

        [StringLength(150)]
        public string ContactPersonName { get; set; }
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        [StringLength(50)]
        public string NPWP { get; set; }

        public int? DefaultPaymentTermID { get; set; } // FK ke PaymentTerm
        [ForeignKey("DefaultPaymentTermID")]
        public virtual PaymentTerm DefaultPaymentTerm { get; set; }

        [StringLength(10)]
        public string DefaultCurrency { get; set; }

        [StringLength(50)]
        public string OfficeType { get; set; } // Pusat, Cabang
        [StringLength(50)]
        public string VendorType { get; set; } // Luar Negeri, Dalam Negeri
        [StringLength(50)]
        public string RiskLevel { get; set; } // High, Medium, Low
        public string CompanyProfileAttachmentURL { get; set; }

        [StringLength(255)]
        public string BillingAddressStreet { get; set; }
        [StringLength(255)]
        public string BillingAddressDetail { get; set; }
        [StringLength(100)]
        public string BillingAddressCity { get; set; }
        [StringLength(100)]
        public string BillingAddressProvince { get; set; }
        [StringLength(100)]
        public string BillingAddressCountry { get; set; }
        [StringLength(20)]
        public string BillingAddressZipCode { get; set; }

        [StringLength(255)]
        public string ShippingAddressStreet { get; set; }
        [StringLength(255)]
        public string ShippingAddressDetail { get; set; }
        [StringLength(100)]
        public string ShippingAddressCity { get; set; }
        [StringLength(100)]
        public string ShippingAddressProvince { get; set; }
        [StringLength(100)]
        public string ShippingAddressCountry { get; set; }
        [StringLength(20)]
        public string ShippingAddressZipCode { get; set; }

        public int? CreatedByUserID { get; set; }
        [ForeignKey("CreatedByUserID")]
        public virtual User CreatedByUser { get; set; }

        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedTimestamp { get; set; } = DateTime.UtcNow;

        public virtual ICollection<VendorBank> BankAccounts { get; set; }
        public virtual ICollection<ItemVendorPricing> ItemPricings { get; set; }

        public Vendor()
        {
            BankAccounts = new HashSet<VendorBank>();
            ItemPricings = new HashSet<ItemVendorPricing>();
        }
    }
}