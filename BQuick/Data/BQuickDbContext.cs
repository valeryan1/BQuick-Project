using BQuick.Models;
using Microsoft.EntityFrameworkCore;

namespace BQuick.Data
{
    public class BQuickDbContext : DbContext
    {
        public BQuickDbContext(DbContextOptions<BQuickDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RFQ> RFQs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<RFQItem> RFQItems { get; set; }
        public DbSet<RFQNote> RFQNotes { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyForm> SurveyForms { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingParticipant> MeetingParticipants { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationItem> QuotationItems { get; set; }
        public DbSet<QuotationApproval> QuotationApprovals { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<VendorItem> VendorItems { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<VendorBankAccount> VendorBankAccounts { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Customer>().HasIndex(c => c.CustomerCode).IsUnique();

            modelBuilder.Entity<RFQ>().HasIndex(r => r.RFQCode).IsUnique();

            modelBuilder.Entity<Item>().HasIndex(i => i.ItemCode).IsUnique();

            modelBuilder.Entity<Vendor>().HasIndex(v => v.VendorCode).IsUnique();

            modelBuilder.Entity<Survey>().HasIndex(s => s.SurveyCode).IsUnique();

            modelBuilder.Entity<Meeting>().HasIndex(m => m.MeetingCode).IsUnique();

            modelBuilder.Entity<Quotation>().HasIndex(q => q.QuotationCode).IsUnique();

            modelBuilder.Entity<RFQ>().HasOne(r => r.Customer).WithMany(c => c.RFQs).HasForeignKey(r => r.CustomerID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RFQ>().HasOne(r => r.CreatedByUser).WithMany(u => u.CreatedRFQs).HasForeignKey(r => r.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RFQ>().HasOne(r => r.AssignedToUser).WithMany(u => u.AssignedRFQs).HasForeignKey(r => r.AssignedTo).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQItem>().HasOne(ri => ri.RFQ).WithMany(r => r.RFQItems).HasForeignKey(ri => ri.RFQID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RFQItem>().HasOne(ri => ri.Item).WithMany(i => i.RFQItems).HasForeignKey(ri => ri.ItemID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQNote>().HasOne(rn => rn.RFQ).WithMany(r => r.RFQNotes).HasForeignKey(rn => rn.RFQID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Survey>().HasOne(s => s.RFQ).WithMany(r => r.Surveys).HasForeignKey(s => s.RFQID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Survey>().HasOne(s => s.AssignedUser).WithMany(u => u.AssignedSurveys).HasForeignKey(s => s.AssignedTo).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurveyForm>().HasOne(sf => sf.Survey).WithMany(s => s.SurveyForms).HasForeignKey(sf => sf.SurveyID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Meeting>().HasOne(m => m.RFQ).WithMany(r => r.Meetings).HasForeignKey(m => m.RFQID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MeetingParticipant>().HasOne(mp => mp.Meeting).WithMany(m => m.Participants).HasForeignKey(mp => mp.MeetingID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MeetingParticipant>().HasOne(mp => mp.User).WithMany(u => u.MeetingParticipations).HasForeignKey(mp => mp.UserID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quotation>().HasOne(q => q.RFQ).WithMany(r => r.Quotations).HasForeignKey(q => q.RFQID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QuotationItem>().HasOne(qi => qi.Quotation).WithMany(q => q.QuotationItems).HasForeignKey(qi => qi.QuotationID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<QuotationItem>().HasOne(qi => qi.Item).WithMany(i => i.QuotationItems).HasForeignKey(qi => qi.ItemID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QuotationApproval>().HasOne(qa => qa.Quotation).WithMany(q => q.Approvals).HasForeignKey(qa => qa.QuotationID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<QuotationApproval>().HasOne(qa => qa.Approver).WithMany(u => u.QuotationApprovals).HasForeignKey(qa => qa.ApproverID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VendorItem>().HasOne(vi => vi.Vendor).WithMany(v => v.VendorItems).HasForeignKey(vi => vi.VendorID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<VendorItem>().HasOne(vi => vi.Item).WithMany(i => i.VendorItems).HasForeignKey(vi => vi.ItemID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerContact>().HasOne(cc => cc.Customer).WithMany(c => c.Contacts).HasForeignKey(cc => cc.CustomerID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VendorBankAccount>().HasOne(vba => vba.Vendor).WithMany(v => v.BankAccounts).HasForeignKey(vba => vba.VendorID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
