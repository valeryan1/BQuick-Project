using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Company
    {
        public Company()
        {
            CustomerContacts = new HashSet<CustomerContact>();
            CompanyAttachments = new HashSet<CompanyAttachment>();
            RFQs = new HashSet<RFQ>();
        }

        [Key]
        public int CompanyID { get; set; }

        [Required, StringLength(100)]
        public string CompanyName { get; set; }

        [Required, StringLength(20)]
        public string CompanyCode { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Province { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(20)]
        public string PostalCode { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string MobileNumber { get; set; }

        [StringLength(50)]
        public string FaxNumber { get; set; }

        [StringLength(100), EmailAddress]
        public string Email { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        [StringLength(20)]
        public string CustomerLevel { get; set; }

        [StringLength(100)]
        public string Industry { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? AnnualRevenue { get; set; }

        public int? EmployeeCount { get; set; }

        public int? YearEstablished { get; set; }

        [StringLength(10)]
        public string Currency { get; set; } = "IDR";

        [StringLength(50)]
        public string TOP { get; set; }

        [StringLength(30)]
        public string NPWP { get; set; }

        [StringLength(100)]
        public string AccountReceivable { get; set; }

        [StringLength(100)]
        public string AccountPayable { get; set; }

        [StringLength(255)]
        public string BillingAddress { get; set; }

        [StringLength(255)]
        public string BillingStreet { get; set; }

        [StringLength(100)]
        public string BillingCity { get; set; }

        [StringLength(100)]
        public string BillingProvince { get; set; }

        [StringLength(100)]
        public string BillingCountry { get; set; }

        [StringLength(20)]
        public string BillingZIPCode { get; set; }

        [StringLength(255)]
        public string ShippingAddress { get; set; }

        [StringLength(255)]
        public string ShippingStreet { get; set; }

        [StringLength(100)]
        public string ShippingCity { get; set; }

        [StringLength(100)]
        public string ShippingProvince { get; set; }

        [StringLength(100)]
        public string ShippingCountry { get; set; }

        [StringLength(20)]
        public string ShippingZIPCode { get; set; }

        public bool IsShippingSameAsBilling { get; set; } = false;

        public int? AccountManagerID { get; set; }

        public byte[] ProfilePicture { get; set; }

        [StringLength(255)]
        public string ProfilePictureFileName { get; set; }

        [StringLength(100)]
        public string ProfilePictureFileType { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("AccountManagerID")]
        public virtual User AccountManager { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }
        public virtual ICollection<CompanyAttachment> CompanyAttachments { get; set; }
        public virtual ICollection<RFQ> RFQs { get; set; }
    }
}
