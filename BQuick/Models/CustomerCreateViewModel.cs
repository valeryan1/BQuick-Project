// File: BQuick/Models/CustomerCreateViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class CustomerCreateViewModel
    {
        [Required]
        [StringLength(200)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerCode { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerType { get; set; }

        [StringLength(30)]
        public string? Fax { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Phone]
        [StringLength(30)]
        public string? Phone { get; set; }

        [Phone]
        [StringLength(30)]
        public string? Mobile { get; set; }

        [StringLength(10)]
        public string DefaultCurrency { get; set; }

        public int? DefaultTermsOfPaymentID { get; set; }

        [StringLength(25)]
        public string? NPWP { get; set; }

        [StringLength(50)]
        public string? AccountReceivableCode { get; set; }

        [StringLength(50)]
        public string? AccountPayableCode { get; set; }

        [StringLength(255)]
        public string? BillingAddressStreet { get; set; }
        [StringLength(100)]
        public string? BillingAddressCity { get; set; }
        [StringLength(100)]
        public string? BillingAddressProvince { get; set; }
        [StringLength(100)]
        public string? BillingAddressCountry { get; set; }
        [StringLength(20)]
        public string? BillingAddressZipCode { get; set; }

        [StringLength(255)]
        public string? BillingAddressDetail { get; set; }

        [StringLength(255)]
        public string? ShippingAddressStreet { get; set; }
        [StringLength(100)]
        public string? ShippingAddressCity { get; set; }
        [StringLength(100)]
        public string? ShippingAddressProvince { get; set; }
        [StringLength(100)]
        public string? ShippingAddressCountry { get; set; }
        [StringLength(20)]
        public string? ShippingAddressZipCode { get; set; }

        [StringLength(255)]
        public string? ShippingAddressDetail { get; set; }

        public List<ContactPersonCreateViewModel> ContactPersons { get; set; } = new List<ContactPersonCreateViewModel>();
    }
}
