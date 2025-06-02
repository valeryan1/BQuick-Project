using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [StringLength(50)]
        public string CustomerCode { get; set; } // misalnya "PEB"

        [Required]
        [StringLength(200)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string CustomerType { get; set; } // "Company", "Personal"

        [StringLength(10)]
        public string DefaultCurrency { get; set; } = "IDR";

        public int? DefaultTermsOfPaymentID { get; set; } // FK ke PaymentTerm
        [ForeignKey("DefaultTermsOfPaymentID")]
        public virtual PaymentTerm DefaultTermsOfPayment { get; set; }

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

        [StringLength(50)]
        public string AccountReceivableCode { get; set; }
        [StringLength(50)]
        public string AccountPayableCode { get; set; }
        [StringLength(50)]
        public string PurchasingLevel { get; set; } // Platinum, Gold, Silver

        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedTimestamp { get; set; } = DateTime.UtcNow;

        public virtual ICollection<CustomerContactPerson> ContactPersons { get; set; }
        public virtual ICollection<RFQ> RFQs { get; set; }

        public Customer()
        {
            ContactPersons = new HashSet<CustomerContactPerson>();
            RFQs = new HashSet<RFQ>();
        }
    }
}