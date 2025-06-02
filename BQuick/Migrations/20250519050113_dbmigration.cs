using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BQuick.Migrations
{
    /// <inheritdoc />
    public partial class dbmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_CreatedByID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_ModifiedByID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingPICs_Meetings_MeetingID",
                table: "MeetingPICs");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingPICs_Users_UserID",
                table: "MeetingPICs");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_CreatedByID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Items_ItemID",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_ApprovedByID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_CreatedByID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_ModifiedByID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_PreparedByID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQAttachments_Users_UploadedByID",
                table: "RFQAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Companies_CompanyID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_CustomerContacts_ContactID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_AdminSalesID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_BusinessDevelopmentID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_CreatedByID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_ModifiedByID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_PMOID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_PreSalesSupportID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_SalesID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyPICs_Surveys_SurveyID",
                table: "SurveyPICs");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyPICs_Users_CreatedByID",
                table: "SurveyPICs");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyPICs_Users_UserID",
                table: "SurveyPICs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ModifiedByID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ReportsToID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Users_CreatedByID",
                table: "Vendors");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Users_ModifiedByID",
                table: "Vendors");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Users_PurchasingManagerID",
                table: "Vendors");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "BusinessDevelopmentActivities");

            migrationBuilder.DropTable(
                name: "CompanyAttachments");

            migrationBuilder.DropTable(
                name: "InventoryMovements");

            migrationBuilder.DropTable(
                name: "ItemImages");

            migrationBuilder.DropTable(
                name: "ItemVendors");

            migrationBuilder.DropTable(
                name: "MarketingActivityCompanies");

            migrationBuilder.DropTable(
                name: "MeetingAttachments");

            migrationBuilder.DropTable(
                name: "MeetingExternalParticipants");

            migrationBuilder.DropTable(
                name: "MeetingMinutes");

            migrationBuilder.DropTable(
                name: "PMOAssignments");

            migrationBuilder.DropTable(
                name: "QuotationAttachments");

            migrationBuilder.DropTable(
                name: "QuotationHistories");

            migrationBuilder.DropTable(
                name: "ReportAttachments");

            migrationBuilder.DropTable(
                name: "RequestItemAttachments");

            migrationBuilder.DropTable(
                name: "RequestItemResponses");

            migrationBuilder.DropTable(
                name: "RFQItemAddOns");

            migrationBuilder.DropTable(
                name: "RFQNotesItems");

            migrationBuilder.DropTable(
                name: "SurveyAttachments");

            migrationBuilder.DropTable(
                name: "SurveyForms");

            migrationBuilder.DropTable(
                name: "SurveyResults");

            migrationBuilder.DropTable(
                name: "TaskToDos");

            migrationBuilder.DropTable(
                name: "UserDepartments");

            migrationBuilder.DropTable(
                name: "VendorAttachments");

            migrationBuilder.DropTable(
                name: "VendorBankAccounts");

            migrationBuilder.DropTable(
                name: "MarketingActivities");

            migrationBuilder.DropTable(
                name: "CustomerContacts");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "RequestItems");

            migrationBuilder.DropTable(
                name: "RFQItems");

            migrationBuilder.DropTable(
                name: "TaskToDoTemplates");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_CreatedByID",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_ModifiedByID",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_VendorCode",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Users_ModifiedByID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ReportsToID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_AdminSalesID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_CompanyID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_RFQAttachments_UploadedByID",
                table: "RFQAttachments");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_QuotationNumber",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_CreatedByID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Items_CreatedByID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BillingCity",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BillingCountry",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ModifiedByID",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Division",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedByID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReportsToID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SurveyPICs");

            migrationBuilder.DropColumn(
                name: "IsLeader",
                table: "SurveyPICs");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "SurveyPICs");

            migrationBuilder.DropColumn(
                name: "ActualValue",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "AdminSalesID",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "CompetitorInfo",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "EstimatedValue",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "ExpectedClosingDate",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "Opportunity",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RFQAttachments");

            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "RFQAttachments");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "RFQAttachments");

            migrationBuilder.DropColumn(
                name: "UploadedByID",
                table: "RFQAttachments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "DeliveryTerm",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "DeliveryTimeUnit",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "PaymentTerm",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "QuotationNumber",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "QuotationTitle",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReadDate",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReferenceType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReferenceURL",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AttendanceStatus",
                table: "MeetingPICs");

            migrationBuilder.DropColumn(
                name: "IsRequired",
                table: "MeetingPICs");

            migrationBuilder.DropColumn(
                name: "ResponseDate",
                table: "MeetingPICs");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "MeetingPICs");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "EOLDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "EOSDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LeadTime",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MinimumStockLevel",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "WarrantyUnit",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "VendorRating",
                table: "Vendors",
                newName: "DefaultPaymentTermID");

            migrationBuilder.RenameColumn(
                name: "VendorCategory",
                table: "Vendors",
                newName: "RiskLevel");

            migrationBuilder.RenameColumn(
                name: "ShipmentProvince",
                table: "Vendors",
                newName: "ShippingAddressProvince");

            migrationBuilder.RenameColumn(
                name: "ShipmentPostalCode",
                table: "Vendors",
                newName: "ShippingAddressZipCode");

            migrationBuilder.RenameColumn(
                name: "ShipmentCountry",
                table: "Vendors",
                newName: "ShippingAddressCountry");

            migrationBuilder.RenameColumn(
                name: "ShipmentCity",
                table: "Vendors",
                newName: "ShippingAddressCity");

            migrationBuilder.RenameColumn(
                name: "ShipmentAddress",
                table: "Vendors",
                newName: "ShippingAddressStreet");

            migrationBuilder.RenameColumn(
                name: "PurchasingManagerID",
                table: "Vendors",
                newName: "CreatedByUserID");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm",
                table: "Vendors",
                newName: "BillingAddressProvince");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Vendors",
                newName: "LastModifiedTimestamp");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Vendors",
                newName: "CreatedTimestamp");

            migrationBuilder.RenameColumn(
                name: "ContactPerson",
                table: "Vendors",
                newName: "BillingAddressCountry");

            migrationBuilder.RenameColumn(
                name: "BillingProvince",
                table: "Vendors",
                newName: "BillingAddressCity");

            migrationBuilder.RenameColumn(
                name: "BillingPostalCode",
                table: "Vendors",
                newName: "BillingAddressZipCode");

            migrationBuilder.RenameColumn(
                name: "BillingAddress",
                table: "Vendors",
                newName: "ShippingAddressDetail");

            migrationBuilder.RenameIndex(
                name: "IX_Vendors_PurchasingManagerID",
                table: "Vendors",
                newName: "IX_Vendors_CreatedByUserID");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Users",
                newName: "LastModifiedTimestamp");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Users",
                newName: "CreatedTimestamp");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "SurveyPICs",
                newName: "TechnicalUserID");

            migrationBuilder.RenameColumn(
                name: "SurveyID",
                table: "SurveyPICs",
                newName: "SurveyRequestID");

            migrationBuilder.RenameColumn(
                name: "CreatedByID",
                table: "SurveyPICs",
                newName: "PICApprovalStatusID");

            migrationBuilder.RenameColumn(
                name: "SurveyPICID",
                table: "SurveyPICs",
                newName: "SurveyPIC_ID");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyPICs_UserID",
                table: "SurveyPICs",
                newName: "IX_SurveyPICs_TechnicalUserID");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyPICs_SurveyID",
                table: "SurveyPICs",
                newName: "IX_SurveyPICs_SurveyRequestID");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyPICs_CreatedByID",
                table: "SurveyPICs",
                newName: "IX_SurveyPICs_PICApprovalStatusID");

            migrationBuilder.RenameColumn(
                name: "WinProbability",
                table: "RFQs",
                newName: "RFQStatusID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "RFQs",
                newName: "Resource");

            migrationBuilder.RenameColumn(
                name: "SalesID",
                table: "RFQs",
                newName: "RFQOpportunityID");

            migrationBuilder.RenameColumn(
                name: "PreSalesSupportID",
                table: "RFQs",
                newName: "SalesManagerAssignerID");

            migrationBuilder.RenameColumn(
                name: "PMOID",
                table: "RFQs",
                newName: "PersonalResourceEmployeeID");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "RFQs",
                newName: "LastUpdateTimestamp");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                table: "RFQs",
                newName: "RFQCategoryID");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "RFQs",
                newName: "CreationTimestamp");

            migrationBuilder.RenameColumn(
                name: "CreatedByID",
                table: "RFQs",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "ContactID",
                table: "RFQs",
                newName: "CreatedByUserID");

            migrationBuilder.RenameColumn(
                name: "BusinessDevelopmentID",
                table: "RFQs",
                newName: "ContactPersonID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_SalesID",
                table: "RFQs",
                newName: "IX_RFQs_RFQOpportunityID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_PreSalesSupportID",
                table: "RFQs",
                newName: "IX_RFQs_SalesManagerAssignerID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_PMOID",
                table: "RFQs",
                newName: "IX_RFQs_PersonalResourceEmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_ModifiedByID",
                table: "RFQs",
                newName: "IX_RFQs_RFQCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_CreatedByID",
                table: "RFQs",
                newName: "IX_RFQs_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_ContactID",
                table: "RFQs",
                newName: "IX_RFQs_CreatedByUserID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_BusinessDevelopmentID",
                table: "RFQs",
                newName: "IX_RFQs_ContactPersonID");

            migrationBuilder.RenameColumn(
                name: "UploadedDate",
                table: "RFQAttachments",
                newName: "UploadTimestamp");

            migrationBuilder.RenameColumn(
                name: "FileSize",
                table: "RFQAttachments",
                newName: "UploadedByUserID");

            migrationBuilder.RenameColumn(
                name: "AttachmentID",
                table: "RFQAttachments",
                newName: "RFQAttachmentID");

            migrationBuilder.RenameColumn(
                name: "Warranty",
                table: "Quotations",
                newName: "QuotationCode");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "Quotations",
                newName: "ShipmentTermID");

            migrationBuilder.RenameColumn(
                name: "ValidUntil",
                table: "Quotations",
                newName: "LastModifiedTimestamp");

            migrationBuilder.RenameColumn(
                name: "TermsAndConditions",
                table: "Quotations",
                newName: "SentToCustomerProofURL");

            migrationBuilder.RenameColumn(
                name: "TaxAmount",
                table: "Quotations",
                newName: "TotalUnitCost_Internal");

            migrationBuilder.RenameColumn(
                name: "SubTotal",
                table: "Quotations",
                newName: "TotalQuoteAmount_Customer");

            migrationBuilder.RenameColumn(
                name: "ShippingCost",
                table: "Quotations",
                newName: "TotalPPN_Internal");

            migrationBuilder.RenameColumn(
                name: "QuotationDate",
                table: "Quotations",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "PreparedByID",
                table: "Quotations",
                newName: "QuotationStatusID");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Quotations",
                newName: "RemarkToCustomer");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                table: "Quotations",
                newName: "PreparedByUserID");

            migrationBuilder.RenameColumn(
                name: "GrandTotal",
                table: "Quotations",
                newName: "TotalFreight_Internal");

            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "Quotations",
                newName: "TotalEndorsement_Internal");

            migrationBuilder.RenameColumn(
                name: "DeliveryTime",
                table: "Quotations",
                newName: "TechnicalManagerApproverID");

            migrationBuilder.RenameColumn(
                name: "CreatedByID",
                table: "Quotations",
                newName: "PaymentTermID");

            migrationBuilder.RenameColumn(
                name: "ApprovedByID",
                table: "Quotations",
                newName: "SplitParentQuotationID");

            migrationBuilder.RenameColumn(
                name: "ApprovalDate",
                table: "Quotations",
                newName: "SentToCustomerTimestamp");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_PreparedByID",
                table: "Quotations",
                newName: "IX_Quotations_QuotationStatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_ModifiedByID",
                table: "Quotations",
                newName: "IX_Quotations_PreparedByUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_CreatedByID",
                table: "Quotations",
                newName: "IX_Quotations_PaymentTermID");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_ApprovedByID",
                table: "Quotations",
                newName: "IX_Quotations_SplitParentQuotationID");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "QuotationItems",
                newName: "UnitCost_Internal");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "QuotationItems",
                newName: "TotalQuotePrice_Customer");

            migrationBuilder.RenameColumn(
                name: "TaxAmount",
                table: "QuotationItems",
                newName: "TotalCostPerUnit_Internal");

            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "QuotationItems",
                newName: "QuotePricePerUnit_Customer");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Notifications",
                newName: "RecipientUserID");

            migrationBuilder.RenameColumn(
                name: "ReferenceID",
                table: "Notifications",
                newName: "RelatedEntityID");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Notifications",
                newName: "CreationTimestamp");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                newName: "IX_Notifications_RecipientUserID");

            migrationBuilder.RenameColumn(
                name: "MeetingID",
                table: "MeetingPICs",
                newName: "PICApprovalStatusID");

            migrationBuilder.RenameColumn(
                name: "MeetingPICID",
                table: "MeetingPICs",
                newName: "MeetingPIC_ID");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingPICs_MeetingID",
                table: "MeetingPICs",
                newName: "IX_MeetingPICs_PICApprovalStatusID");

            migrationBuilder.RenameColumn(
                name: "WarrantyPeriod",
                table: "Items",
                newName: "ItemTypeID");

            migrationBuilder.RenameColumn(
                name: "UoM",
                table: "Items",
                newName: "SoftwareVersion");

            migrationBuilder.RenameColumn(
                name: "TechnicalSpecification",
                table: "Items",
                newName: "TKDNCertificateAttachmentURL");

            migrationBuilder.RenameColumn(
                name: "StockQty",
                table: "Items",
                newName: "StockQuantity");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Items",
                newName: "LastModifiedTimestamp");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                table: "Items",
                newName: "ItemCategoryID");

            migrationBuilder.RenameColumn(
                name: "ModelNumber",
                table: "Items",
                newName: "TKDNCertificateNumber");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Items",
                newName: "LicenseType");

            migrationBuilder.RenameColumn(
                name: "ItemType",
                table: "Items",
                newName: "ItemServiceType");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Items",
                newName: "SpecificationDetails");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Items",
                newName: "WeightUnit");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Items",
                newName: "CreatedTimestamp");

            migrationBuilder.RenameColumn(
                name: "CertificateNo",
                table: "Items",
                newName: "Brand");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ModifiedByID",
                table: "Items",
                newName: "IX_Items_ItemCategoryID");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "VendorName",
                table: "Vendors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "VendorCode",
                table: "Vendors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Vendors",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressDetail",
                table: "Vendors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressStreet",
                table: "Vendors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyProfileAttachmentURL",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonName",
                table: "Vendors",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DefaultCurrency",
                table: "Vendors",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NPWP",
                table: "Vendors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficeType",
                table: "Vendors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "RFQCode",
                table: "RFQs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "AssignedToAdminSalesID",
                table: "RFQs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OverallBudget",
                table: "RFQs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OverallLeadTime",
                table: "RFQs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileURL",
                table: "RFQAttachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryInfo",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DirectorApproverID",
                table: "Quotations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeRate",
                table: "Quotations",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Quotations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterText",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InternalNotes",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "OverallMarginAmount_Internal",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OverallMarginPercentage_Internal",
                table: "Quotations",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OverallTotalCost_Internal",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SalesManagerApproverID",
                table: "Quotations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                table: "QuotationItems",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "QuotationItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionOverride",
                table: "QuotationItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DisplaySequence",
                table: "QuotationItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DisplayWithDetailInternal",
                table: "QuotationItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Endorsement_Amount",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Freight_AmountPerUnit",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MarginAmount_Internal",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MarginPercentage_Internal",
                table: "QuotationItems",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PPN_FixedAmount",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PPN_Percentage",
                table: "QuotationItems",
                type: "decimal(5,4)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RFQ_ItemID",
                table: "QuotationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesWarranty",
                table: "QuotationItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "NotificationType",
                table: "Notifications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "NavigationURL",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RelatedEntityType",
                table: "Notifications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MeetingRequestID",
                table: "MeetingPICs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DimensionH",
                table: "Items",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DimensionL",
                table: "Items",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DimensionUnit",
                table: "Items",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DimensionW",
                table: "Items",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemImageURL",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Items",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApprovalDecisionStatuses",
                columns: table => new
                {
                    ApprovalDecisionStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalDecisionStatuses", x => x.ApprovalDecisionStatusID);
                });

            migrationBuilder.CreateTable(
                name: "ItemBundles",
                columns: table => new
                {
                    ItemBundleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentItemID = table.Column<int>(type: "int", nullable: false),
                    ChildItemID = table.Column<int>(type: "int", nullable: false),
                    QuantityInBundle = table.Column<int>(type: "int", nullable: false),
                    PriceInBundle = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBundles", x => x.ItemBundleID);
                    table.ForeignKey(
                        name: "FK_ItemBundles_Items_ChildItemID",
                        column: x => x.ChildItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemBundles_Items_ParentItemID",
                        column: x => x.ParentItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    ItemCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.ItemCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ItemVendorPricings",
                columns: table => new
                {
                    ItemVendorPricingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LeadTimeValue = table.Column<int>(type: "int", nullable: true),
                    LeadTimeUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    WarrantyPeriod = table.Column<int>(type: "int", nullable: true),
                    WarrantyUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PriceValidityStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceValidityEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinOrderQuantity = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockAvailableAtVendor = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVendorPricings", x => x.ItemVendorPricingID);
                    table.ForeignKey(
                        name: "FK_ItemVendorPricings_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVendorPricings_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingStatuses",
                columns: table => new
                {
                    MeetingStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingStatuses", x => x.MeetingStatusID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTerms",
                columns: table => new
                {
                    PaymentTermID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTerms", x => x.PaymentTermID);
                });

            migrationBuilder.CreateTable(
                name: "PICApprovalStatuses",
                columns: table => new
                {
                    PICApprovalStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PICApprovalStatuses", x => x.PICApprovalStatusID);
                });

            migrationBuilder.CreateTable(
                name: "PurchasingStatuses",
                columns: table => new
                {
                    PurchasingStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasingStatuses", x => x.PurchasingStatusID);
                });

            migrationBuilder.CreateTable(
                name: "QuotationStatuses",
                columns: table => new
                {
                    QuotationStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationStatuses", x => x.QuotationStatusID);
                });

            migrationBuilder.CreateTable(
                name: "ReportMasters",
                columns: table => new
                {
                    ReportMasterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ReportTemplateDefinition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportMasters", x => x.ReportMasterID);
                });

            migrationBuilder.CreateTable(
                name: "ReportStatuses",
                columns: table => new
                {
                    ReportStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStatuses", x => x.ReportStatusID);
                });

            migrationBuilder.CreateTable(
                name: "ReqItem2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UoM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    reasonForReq = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PIC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReqItem2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFQCategories",
                columns: table => new
                {
                    RFQCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQCategories", x => x.RFQCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "RFQNotes",
                columns: table => new
                {
                    RFQNoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BudgetTarget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LeadTimeTarget = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQNotes", x => x.RFQNoteID);
                    table.ForeignKey(
                        name: "FK_RFQNotes_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RFQOpportunities",
                columns: table => new
                {
                    RFQOpportunityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQOpportunities", x => x.RFQOpportunityID);
                });

            migrationBuilder.CreateTable(
                name: "RFQStatuses",
                columns: table => new
                {
                    RFQStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQStatuses", x => x.RFQStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettingGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SettingKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SettingValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingID);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentTerms",
                columns: table => new
                {
                    ShipmentTermID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentTerms", x => x.ShipmentTermID);
                });

            migrationBuilder.CreateTable(
                name: "SurveyCategories",
                columns: table => new
                {
                    SurveyCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyCategories", x => x.SurveyCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "SurveyFormMasters",
                columns: table => new
                {
                    SurveyFormID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FormTemplateDefinition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyFormMasters", x => x.SurveyFormID);
                });

            migrationBuilder.CreateTable(
                name: "SurveyStatuses",
                columns: table => new
                {
                    SurveyStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyStatuses", x => x.SurveyStatusID);
                });

            migrationBuilder.CreateTable(
                name: "VendorBanks",
                columns: table => new
                {
                    VendorBankID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountHolderName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorBanks", x => x.VendorBankID);
                    table.ForeignKey(
                        name: "FK_VendorBanks_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    ItemTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ItemTypeID);
                    table.ForeignKey(
                        name: "FK_ItemTypes_ItemCategories_ItemCategoryID",
                        column: x => x.ItemCategoryID,
                        principalTable: "ItemCategories",
                        principalColumn: "ItemCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRequests",
                columns: table => new
                {
                    MeetingRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    MeetingCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MeetingName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PrimaryPIC_UserID = table.Column<int>(type: "int", nullable: false),
                    RequestedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotesInternal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingStatusID = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRequests", x => x.MeetingRequestID);
                    table.ForeignKey(
                        name: "FK_MeetingRequests_MeetingStatuses_MeetingStatusID",
                        column: x => x.MeetingStatusID,
                        principalTable: "MeetingStatuses",
                        principalColumn: "MeetingStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingRequests_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingRequests_Users_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingRequests_Users_PrimaryPIC_UserID",
                        column: x => x.PrimaryPIC_UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DefaultCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DefaultTermsOfPaymentID = table.Column<int>(type: "int", nullable: true),
                    BillingAddressStreet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BillingAddressDetail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BillingAddressCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingAddressProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingAddressCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingAddressZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShippingAddressStreet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShippingAddressDetail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShippingAddressCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingAddressProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingAddressCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingAddressZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountReceivableCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountPayableCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PurchasingLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_PaymentTerms_DefaultTermsOfPaymentID",
                        column: x => x.DefaultTermsOfPaymentID,
                        principalTable: "PaymentTerms",
                        principalColumn: "PaymentTermID");
                });

            migrationBuilder.CreateTable(
                name: "PurchasingRequests",
                columns: table => new
                {
                    PurchasingRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    ItemID_IfExists = table.Column<int>(type: "int", nullable: true),
                    RequestedItemName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RequestedItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReasonForRequest = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SalesNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesAttachmentURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedToPurchasingUserID = table.Column<int>(type: "int", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchasingStatusID = table.Column<int>(type: "int", nullable: false),
                    RequestedByUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasingRequests", x => x.PurchasingRequestID);
                    table.ForeignKey(
                        name: "FK_PurchasingRequests_Items_ItemID_IfExists",
                        column: x => x.ItemID_IfExists,
                        principalTable: "Items",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK_PurchasingRequests_PurchasingStatuses_PurchasingStatusID",
                        column: x => x.PurchasingStatusID,
                        principalTable: "PurchasingStatuses",
                        principalColumn: "PurchasingStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasingRequests_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasingRequests_Users_AssignedToPurchasingUserID",
                        column: x => x.AssignedToPurchasingUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PurchasingRequests_Users_RequestedByUserID",
                        column: x => x.RequestedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalCompetencies",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SurveyCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalCompetencies", x => new { x.UserID, x.SurveyCategoryID });
                    table.ForeignKey(
                        name: "FK_TechnicalCompetencies_SurveyCategories_SurveyCategoryID",
                        column: x => x.SurveyCategoryID,
                        principalTable: "SurveyCategories",
                        principalColumn: "SurveyCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalCompetencies_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyRequests",
                columns: table => new
                {
                    SurveyRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    SurveyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurveyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SurveyCategoryID = table.Column<int>(type: "int", nullable: false),
                    CustomerPICName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RequestedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesNotesInternal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyStatusID = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyRequests", x => x.SurveyRequestID);
                    table.ForeignKey(
                        name: "FK_SurveyRequests_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyRequests_SurveyCategories_SurveyCategoryID",
                        column: x => x.SurveyCategoryID,
                        principalTable: "SurveyCategories",
                        principalColumn: "SurveyCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyRequests_SurveyStatuses_SurveyStatusID",
                        column: x => x.SurveyStatusID,
                        principalTable: "SurveyStatuses",
                        principalColumn: "SurveyStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyRequests_Users_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingReportInstances",
                columns: table => new
                {
                    MeetingReportInstanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingRequestID = table.Column<int>(type: "int", nullable: false),
                    ReportMasterID = table.Column<int>(type: "int", nullable: false),
                    ReportContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneratedByUserID = table.Column<int>(type: "int", nullable: false),
                    GeneratedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportStatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingReportInstances", x => x.MeetingReportInstanceID);
                    table.ForeignKey(
                        name: "FK_MeetingReportInstances_MeetingRequests_MeetingRequestID",
                        column: x => x.MeetingRequestID,
                        principalTable: "MeetingRequests",
                        principalColumn: "MeetingRequestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingReportInstances_ReportMasters_ReportMasterID",
                        column: x => x.ReportMasterID,
                        principalTable: "ReportMasters",
                        principalColumn: "ReportMasterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingReportInstances_ReportStatuses_ReportStatusID",
                        column: x => x.ReportStatusID,
                        principalTable: "ReportStatuses",
                        principalColumn: "ReportStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingReportInstances_Users_GeneratedByUserID",
                        column: x => x.GeneratedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerContactPersons",
                columns: table => new
                {
                    ContactPersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContactPersons", x => x.ContactPersonID);
                    table.ForeignKey(
                        name: "FK_CustomerContactPersons_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RFQ_Items",
                columns: table => new
                {
                    RFQ_ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TargetUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesWarranty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChosenVendorID = table.Column<int>(type: "int", nullable: true),
                    OriginatingPurchasingRequestID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQ_Items", x => x.RFQ_ItemID);
                    table.ForeignKey(
                        name: "FK_RFQ_Items_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RFQ_Items_PurchasingRequests_OriginatingPurchasingRequestID",
                        column: x => x.OriginatingPurchasingRequestID,
                        principalTable: "PurchasingRequests",
                        principalColumn: "PurchasingRequestID");
                    table.ForeignKey(
                        name: "FK_RFQ_Items_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RFQ_Items_Vendors_ChosenVendorID",
                        column: x => x.ChosenVendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SurveyInstances",
                columns: table => new
                {
                    SurveyInstanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyRequestID = table.Column<int>(type: "int", nullable: false),
                    SurveyFormID = table.Column<int>(type: "int", nullable: false),
                    ActualSurveyStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualSurveyEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilledFormData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedByUserID = table.Column<int>(type: "int", nullable: false),
                    SubmissionStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubmissionTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyInstances", x => x.SurveyInstanceID);
                    table.ForeignKey(
                        name: "FK_SurveyInstances_SurveyFormMasters_SurveyFormID",
                        column: x => x.SurveyFormID,
                        principalTable: "SurveyFormMasters",
                        principalColumn: "SurveyFormID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyInstances_SurveyRequests_SurveyRequestID",
                        column: x => x.SurveyRequestID,
                        principalTable: "SurveyRequests",
                        principalColumn: "SurveyRequestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyInstances_Users_SubmittedByUserID",
                        column: x => x.SubmittedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyDocumentations",
                columns: table => new
                {
                    SurveyDocumentationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyInstanceID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedByUserID = table.Column<int>(type: "int", nullable: false),
                    UploadTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyDocumentations", x => x.SurveyDocumentationID);
                    table.ForeignKey(
                        name: "FK_SurveyDocumentations_SurveyInstances_SurveyInstanceID",
                        column: x => x.SurveyInstanceID,
                        principalTable: "SurveyInstances",
                        principalColumn: "SurveyInstanceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyDocumentations_Users_UploadedByUserID",
                        column: x => x.UploadedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyReportInstances",
                columns: table => new
                {
                    SurveyReportInstanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyInstanceID = table.Column<int>(type: "int", nullable: false),
                    ReportMasterID = table.Column<int>(type: "int", nullable: false),
                    ReportContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneratedByUserID = table.Column<int>(type: "int", nullable: false),
                    GeneratedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportStatusID = table.Column<int>(type: "int", nullable: false),
                    TechManagerReviewerID = table.Column<int>(type: "int", nullable: true),
                    SalesManagerReviewerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyReportInstances", x => x.SurveyReportInstanceID);
                    table.ForeignKey(
                        name: "FK_SurveyReportInstances_ReportMasters_ReportMasterID",
                        column: x => x.ReportMasterID,
                        principalTable: "ReportMasters",
                        principalColumn: "ReportMasterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyReportInstances_ReportStatuses_ReportStatusID",
                        column: x => x.ReportStatusID,
                        principalTable: "ReportStatuses",
                        principalColumn: "ReportStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyReportInstances_SurveyInstances_SurveyInstanceID",
                        column: x => x.SurveyInstanceID,
                        principalTable: "SurveyInstances",
                        principalColumn: "SurveyInstanceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyReportInstances_Users_GeneratedByUserID",
                        column: x => x.GeneratedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyReportInstances_Users_SalesManagerReviewerID",
                        column: x => x.SalesManagerReviewerID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyReportInstances_Users_TechManagerReviewerID",
                        column: x => x.TechManagerReviewerID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalHistories",
                columns: table => new
                {
                    ApprovalHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityID = table.Column<int>(type: "int", nullable: false),
                    ApproverUserID = table.Column<int>(type: "int", nullable: false),
                    ApproverRoleAtTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApprovalDecisionStatusID = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StepOrder = table.Column<int>(type: "int", nullable: false),
                    QuotationID = table.Column<int>(type: "int", nullable: false),
                    SurveyReportInstanceID = table.Column<int>(type: "int", nullable: false),
                    MeetingReportInstanceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalHistories", x => x.ApprovalHistoryID);
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_ApprovalDecisionStatuses_ApprovalDecisionStatusID",
                        column: x => x.ApprovalDecisionStatusID,
                        principalTable: "ApprovalDecisionStatuses",
                        principalColumn: "ApprovalDecisionStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_MeetingReportInstances_MeetingReportInstanceID",
                        column: x => x.MeetingReportInstanceID,
                        principalTable: "MeetingReportInstances",
                        principalColumn: "MeetingReportInstanceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_Quotations_QuotationID",
                        column: x => x.QuotationID,
                        principalTable: "Quotations",
                        principalColumn: "QuotationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_SurveyReportInstances_SurveyReportInstanceID",
                        column: x => x.SurveyReportInstanceID,
                        principalTable: "SurveyReportInstances",
                        principalColumn: "SurveyReportInstanceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_Users_ApproverUserID",
                        column: x => x.ApproverUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_DefaultPaymentTermID",
                table: "Vendors",
                column: "DefaultPaymentTermID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorCode",
                table: "Vendors",
                column: "VendorCode",
                unique: true,
                filter: "[VendorCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_AssignedToAdminSalesID",
                table: "RFQs",
                column: "AssignedToAdminSalesID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_RFQStatusID",
                table: "RFQs",
                column: "RFQStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQAttachments_UploadedByUserID",
                table: "RFQAttachments",
                column: "UploadedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_DirectorApproverID",
                table: "Quotations",
                column: "DirectorApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationCode",
                table: "Quotations",
                column: "QuotationCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_SalesManagerApproverID",
                table: "Quotations",
                column: "SalesManagerApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ShipmentTermID",
                table: "Quotations",
                column: "ShipmentTermID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_TechnicalManagerApproverID",
                table: "Quotations",
                column: "TechnicalManagerApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationItems_RFQ_ItemID",
                table: "QuotationItems",
                column: "RFQ_ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPICs_MeetingRequestID",
                table: "MeetingPICs",
                column: "MeetingRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeID",
                table: "Items",
                column: "ItemTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalDecisionStatuses_Name",
                table: "ApprovalDecisionStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistories_ApprovalDecisionStatusID",
                table: "ApprovalHistories",
                column: "ApprovalDecisionStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistories_ApproverUserID",
                table: "ApprovalHistories",
                column: "ApproverUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistories_MeetingReportInstanceID",
                table: "ApprovalHistories",
                column: "MeetingReportInstanceID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistories_QuotationID",
                table: "ApprovalHistories",
                column: "QuotationID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistories_SurveyReportInstanceID",
                table: "ApprovalHistories",
                column: "SurveyReportInstanceID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContactPersons_CustomerID",
                table: "CustomerContactPersons",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerCode",
                table: "Customers",
                column: "CustomerCode",
                unique: true,
                filter: "[CustomerCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DefaultTermsOfPaymentID",
                table: "Customers",
                column: "DefaultTermsOfPaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBundles_ChildItemID",
                table: "ItemBundles",
                column: "ChildItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBundles_ParentItemID",
                table: "ItemBundles",
                column: "ParentItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_CategoryName",
                table: "ItemCategories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_ItemCategoryID_ItemTypeName",
                table: "ItemTypes",
                columns: new[] { "ItemCategoryID", "ItemTypeName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendorPricings_ItemID",
                table: "ItemVendorPricings",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendorPricings_VendorID",
                table: "ItemVendorPricings",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingReportInstances_GeneratedByUserID",
                table: "MeetingReportInstances",
                column: "GeneratedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingReportInstances_MeetingRequestID",
                table: "MeetingReportInstances",
                column: "MeetingRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingReportInstances_ReportMasterID",
                table: "MeetingReportInstances",
                column: "ReportMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingReportInstances_ReportStatusID",
                table: "MeetingReportInstances",
                column: "ReportStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequests_CreatedByUserID",
                table: "MeetingRequests",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequests_MeetingCode",
                table: "MeetingRequests",
                column: "MeetingCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequests_MeetingStatusID",
                table: "MeetingRequests",
                column: "MeetingStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequests_PrimaryPIC_UserID",
                table: "MeetingRequests",
                column: "PrimaryPIC_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRequests_RFQID",
                table: "MeetingRequests",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingStatuses_Name",
                table: "MeetingStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTerms_Name",
                table: "PaymentTerms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PICApprovalStatuses_Name",
                table: "PICApprovalStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingRequests_AssignedToPurchasingUserID",
                table: "PurchasingRequests",
                column: "AssignedToPurchasingUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingRequests_ItemID_IfExists",
                table: "PurchasingRequests",
                column: "ItemID_IfExists");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingRequests_PurchasingStatusID",
                table: "PurchasingRequests",
                column: "PurchasingStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingRequests_RequestedByUserID",
                table: "PurchasingRequests",
                column: "RequestedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingRequests_RFQID",
                table: "PurchasingRequests",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingStatuses_Name",
                table: "PurchasingStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuotationStatuses_Name",
                table: "QuotationStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportMasters_ReportName",
                table: "ReportMasters",
                column: "ReportName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportStatuses_Name",
                table: "ReportStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RFQ_Items_ChosenVendorID",
                table: "RFQ_Items",
                column: "ChosenVendorID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQ_Items_ItemID",
                table: "RFQ_Items",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQ_Items_OriginatingPurchasingRequestID",
                table: "RFQ_Items",
                column: "OriginatingPurchasingRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQ_Items_RFQID",
                table: "RFQ_Items",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQCategories_Name",
                table: "RFQCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RFQNotes_RFQID",
                table: "RFQNotes",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQOpportunities_Name",
                table: "RFQOpportunities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RFQStatuses_Name",
                table: "RFQStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settings_SettingGroup_SettingKey",
                table: "Settings",
                columns: new[] { "SettingGroup", "SettingKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentTerms_Name",
                table: "ShipmentTerms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyCategories_CategoryName",
                table: "SurveyCategories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyDocumentations_SurveyInstanceID",
                table: "SurveyDocumentations",
                column: "SurveyInstanceID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyDocumentations_UploadedByUserID",
                table: "SurveyDocumentations",
                column: "UploadedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyFormMasters_FormName",
                table: "SurveyFormMasters",
                column: "FormName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyInstances_SubmittedByUserID",
                table: "SurveyInstances",
                column: "SubmittedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyInstances_SurveyFormID",
                table: "SurveyInstances",
                column: "SurveyFormID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyInstances_SurveyRequestID",
                table: "SurveyInstances",
                column: "SurveyRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyReportInstances_GeneratedByUserID",
                table: "SurveyReportInstances",
                column: "GeneratedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyReportInstances_ReportMasterID",
                table: "SurveyReportInstances",
                column: "ReportMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyReportInstances_ReportStatusID",
                table: "SurveyReportInstances",
                column: "ReportStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyReportInstances_SalesManagerReviewerID",
                table: "SurveyReportInstances",
                column: "SalesManagerReviewerID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyReportInstances_SurveyInstanceID",
                table: "SurveyReportInstances",
                column: "SurveyInstanceID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyReportInstances_TechManagerReviewerID",
                table: "SurveyReportInstances",
                column: "TechManagerReviewerID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyRequests_CreatedByUserID",
                table: "SurveyRequests",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyRequests_RFQID",
                table: "SurveyRequests",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyRequests_SurveyCategoryID",
                table: "SurveyRequests",
                column: "SurveyCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyRequests_SurveyCode",
                table: "SurveyRequests",
                column: "SurveyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyRequests_SurveyStatusID",
                table: "SurveyRequests",
                column: "SurveyStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyStatuses_Name",
                table: "SurveyStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalCompetencies_SurveyCategoryID",
                table: "TechnicalCompetencies",
                column: "SurveyCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorBanks_VendorID",
                table: "VendorBanks",
                column: "VendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCategories_ItemCategoryID",
                table: "Items",
                column: "ItemCategoryID",
                principalTable: "ItemCategories",
                principalColumn: "ItemCategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeID",
                table: "Items",
                column: "ItemTypeID",
                principalTable: "ItemTypes",
                principalColumn: "ItemTypeID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingPICs_MeetingRequests_MeetingRequestID",
                table: "MeetingPICs",
                column: "MeetingRequestID",
                principalTable: "MeetingRequests",
                principalColumn: "MeetingRequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingPICs_PICApprovalStatuses_PICApprovalStatusID",
                table: "MeetingPICs",
                column: "PICApprovalStatusID",
                principalTable: "PICApprovalStatuses",
                principalColumn: "PICApprovalStatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingPICs_Users_UserID",
                table: "MeetingPICs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_RecipientUserID",
                table: "Notifications",
                column: "RecipientUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Items_ItemID",
                table: "QuotationItems",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_RFQ_Items_RFQ_ItemID",
                table: "QuotationItems",
                column: "RFQ_ItemID",
                principalTable: "RFQ_Items",
                principalColumn: "RFQ_ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_PaymentTerms_PaymentTermID",
                table: "Quotations",
                column: "PaymentTermID",
                principalTable: "PaymentTerms",
                principalColumn: "PaymentTermID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_QuotationStatuses_QuotationStatusID",
                table: "Quotations",
                column: "QuotationStatusID",
                principalTable: "QuotationStatuses",
                principalColumn: "QuotationStatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Quotations_SplitParentQuotationID",
                table: "Quotations",
                column: "SplitParentQuotationID",
                principalTable: "Quotations",
                principalColumn: "QuotationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_ShipmentTerms_ShipmentTermID",
                table: "Quotations",
                column: "ShipmentTermID",
                principalTable: "ShipmentTerms",
                principalColumn: "ShipmentTermID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_DirectorApproverID",
                table: "Quotations",
                column: "DirectorApproverID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_PreparedByUserID",
                table: "Quotations",
                column: "PreparedByUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_SalesManagerApproverID",
                table: "Quotations",
                column: "SalesManagerApproverID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_TechnicalManagerApproverID",
                table: "Quotations",
                column: "TechnicalManagerApproverID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQAttachments_Users_UploadedByUserID",
                table: "RFQAttachments",
                column: "UploadedByUserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_CustomerContactPersons_ContactPersonID",
                table: "RFQs",
                column: "ContactPersonID",
                principalTable: "CustomerContactPersons",
                principalColumn: "ContactPersonID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Customers_CustomerID",
                table: "RFQs",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_RFQCategories_RFQCategoryID",
                table: "RFQs",
                column: "RFQCategoryID",
                principalTable: "RFQCategories",
                principalColumn: "RFQCategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_RFQOpportunities_RFQOpportunityID",
                table: "RFQs",
                column: "RFQOpportunityID",
                principalTable: "RFQOpportunities",
                principalColumn: "RFQOpportunityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_RFQStatuses_RFQStatusID",
                table: "RFQs",
                column: "RFQStatusID",
                principalTable: "RFQStatuses",
                principalColumn: "RFQStatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_AssignedToAdminSalesID",
                table: "RFQs",
                column: "AssignedToAdminSalesID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_CreatedByUserID",
                table: "RFQs",
                column: "CreatedByUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_PersonalResourceEmployeeID",
                table: "RFQs",
                column: "PersonalResourceEmployeeID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_SalesManagerAssignerID",
                table: "RFQs",
                column: "SalesManagerAssignerID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyPICs_PICApprovalStatuses_PICApprovalStatusID",
                table: "SurveyPICs",
                column: "PICApprovalStatusID",
                principalTable: "PICApprovalStatuses",
                principalColumn: "PICApprovalStatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyPICs_SurveyRequests_SurveyRequestID",
                table: "SurveyPICs",
                column: "SurveyRequestID",
                principalTable: "SurveyRequests",
                principalColumn: "SurveyRequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyPICs_Users_TechnicalUserID",
                table: "SurveyPICs",
                column: "TechnicalUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_PaymentTerms_DefaultPaymentTermID",
                table: "Vendors",
                column: "DefaultPaymentTermID",
                principalTable: "PaymentTerms",
                principalColumn: "PaymentTermID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Users_CreatedByUserID",
                table: "Vendors",
                column: "CreatedByUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCategories_ItemCategoryID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingPICs_MeetingRequests_MeetingRequestID",
                table: "MeetingPICs");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingPICs_PICApprovalStatuses_PICApprovalStatusID",
                table: "MeetingPICs");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingPICs_Users_UserID",
                table: "MeetingPICs");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_RecipientUserID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Items_ItemID",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_RFQ_Items_RFQ_ItemID",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_PaymentTerms_PaymentTermID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_QuotationStatuses_QuotationStatusID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Quotations_SplitParentQuotationID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_ShipmentTerms_ShipmentTermID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_DirectorApproverID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_PreparedByUserID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_SalesManagerApproverID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_TechnicalManagerApproverID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQAttachments_Users_UploadedByUserID",
                table: "RFQAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_CustomerContactPersons_ContactPersonID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Customers_CustomerID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_RFQCategories_RFQCategoryID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_RFQOpportunities_RFQOpportunityID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_RFQStatuses_RFQStatusID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_AssignedToAdminSalesID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_CreatedByUserID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_PersonalResourceEmployeeID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_SalesManagerAssignerID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyPICs_PICApprovalStatuses_PICApprovalStatusID",
                table: "SurveyPICs");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyPICs_SurveyRequests_SurveyRequestID",
                table: "SurveyPICs");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyPICs_Users_TechnicalUserID",
                table: "SurveyPICs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_PaymentTerms_DefaultPaymentTermID",
                table: "Vendors");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Users_CreatedByUserID",
                table: "Vendors");

            migrationBuilder.DropTable(
                name: "ApprovalHistories");

            migrationBuilder.DropTable(
                name: "CustomerContactPersons");

            migrationBuilder.DropTable(
                name: "ItemBundles");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "ItemVendorPricings");

            migrationBuilder.DropTable(
                name: "PICApprovalStatuses");

            migrationBuilder.DropTable(
                name: "QuotationStatuses");

            migrationBuilder.DropTable(
                name: "ReqItem2");

            migrationBuilder.DropTable(
                name: "RFQ_Items");

            migrationBuilder.DropTable(
                name: "RFQCategories");

            migrationBuilder.DropTable(
                name: "RFQNotes");

            migrationBuilder.DropTable(
                name: "RFQOpportunities");

            migrationBuilder.DropTable(
                name: "RFQStatuses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "ShipmentTerms");

            migrationBuilder.DropTable(
                name: "SurveyDocumentations");

            migrationBuilder.DropTable(
                name: "TechnicalCompetencies");

            migrationBuilder.DropTable(
                name: "VendorBanks");

            migrationBuilder.DropTable(
                name: "ApprovalDecisionStatuses");

            migrationBuilder.DropTable(
                name: "MeetingReportInstances");

            migrationBuilder.DropTable(
                name: "SurveyReportInstances");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ItemCategories");

            migrationBuilder.DropTable(
                name: "PurchasingRequests");

            migrationBuilder.DropTable(
                name: "MeetingRequests");

            migrationBuilder.DropTable(
                name: "ReportMasters");

            migrationBuilder.DropTable(
                name: "ReportStatuses");

            migrationBuilder.DropTable(
                name: "SurveyInstances");

            migrationBuilder.DropTable(
                name: "PaymentTerms");

            migrationBuilder.DropTable(
                name: "PurchasingStatuses");

            migrationBuilder.DropTable(
                name: "MeetingStatuses");

            migrationBuilder.DropTable(
                name: "SurveyFormMasters");

            migrationBuilder.DropTable(
                name: "SurveyRequests");

            migrationBuilder.DropTable(
                name: "SurveyCategories");

            migrationBuilder.DropTable(
                name: "SurveyStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_DefaultPaymentTermID",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_VendorCode",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_AssignedToAdminSalesID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_RFQStatusID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_RFQAttachments_UploadedByUserID",
                table: "RFQAttachments");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_DirectorApproverID",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_QuotationCode",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_SalesManagerApproverID",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_ShipmentTermID",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_TechnicalManagerApproverID",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_QuotationItems_RFQ_ItemID",
                table: "QuotationItems");

            migrationBuilder.DropIndex(
                name: "IX_MeetingPICs_MeetingRequestID",
                table: "MeetingPICs");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemTypeID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BillingAddressDetail",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BillingAddressStreet",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CompanyProfileAttachmentURL",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ContactPersonName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "DefaultCurrency",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "NPWP",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "OfficeType",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AssignedToAdminSalesID",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "OverallBudget",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "OverallLeadTime",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "FileURL",
                table: "RFQAttachments");

            migrationBuilder.DropColumn(
                name: "DeliveryInfo",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "DirectorApproverID",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "FooterText",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "InternalNotes",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "OverallMarginAmount_Internal",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "OverallMarginPercentage_Internal",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "OverallTotalCost_Internal",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "SalesManagerApproverID",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "DescriptionOverride",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "DisplaySequence",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "DisplayWithDetailInternal",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "Endorsement_Amount",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "Freight_AmountPerUnit",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "MarginAmount_Internal",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "MarginPercentage_Internal",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "PPN_FixedAmount",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "PPN_Percentage",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "RFQ_ItemID",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "SalesWarranty",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "NavigationURL",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "RelatedEntityType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "MeetingRequestID",
                table: "MeetingPICs");

            migrationBuilder.DropColumn(
                name: "DimensionH",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DimensionL",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DimensionUnit",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DimensionW",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemDescription",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemImageURL",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressZipCode",
                table: "Vendors",
                newName: "ShipmentPostalCode");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressStreet",
                table: "Vendors",
                newName: "ShipmentAddress");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressProvince",
                table: "Vendors",
                newName: "ShipmentProvince");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressDetail",
                table: "Vendors",
                newName: "BillingAddress");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressCountry",
                table: "Vendors",
                newName: "ShipmentCountry");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressCity",
                table: "Vendors",
                newName: "ShipmentCity");

            migrationBuilder.RenameColumn(
                name: "RiskLevel",
                table: "Vendors",
                newName: "VendorCategory");

            migrationBuilder.RenameColumn(
                name: "LastModifiedTimestamp",
                table: "Vendors",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "DefaultPaymentTermID",
                table: "Vendors",
                newName: "VendorRating");

            migrationBuilder.RenameColumn(
                name: "CreatedTimestamp",
                table: "Vendors",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserID",
                table: "Vendors",
                newName: "PurchasingManagerID");

            migrationBuilder.RenameColumn(
                name: "BillingAddressZipCode",
                table: "Vendors",
                newName: "BillingPostalCode");

            migrationBuilder.RenameColumn(
                name: "BillingAddressProvince",
                table: "Vendors",
                newName: "PaymentTerm");

            migrationBuilder.RenameColumn(
                name: "BillingAddressCountry",
                table: "Vendors",
                newName: "ContactPerson");

            migrationBuilder.RenameColumn(
                name: "BillingAddressCity",
                table: "Vendors",
                newName: "BillingProvince");

            migrationBuilder.RenameIndex(
                name: "IX_Vendors_CreatedByUserID",
                table: "Vendors",
                newName: "IX_Vendors_PurchasingManagerID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedTimestamp",
                table: "Users",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedTimestamp",
                table: "Users",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "TechnicalUserID",
                table: "SurveyPICs",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "SurveyRequestID",
                table: "SurveyPICs",
                newName: "SurveyID");

            migrationBuilder.RenameColumn(
                name: "PICApprovalStatusID",
                table: "SurveyPICs",
                newName: "CreatedByID");

            migrationBuilder.RenameColumn(
                name: "SurveyPIC_ID",
                table: "SurveyPICs",
                newName: "SurveyPICID");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyPICs_TechnicalUserID",
                table: "SurveyPICs",
                newName: "IX_SurveyPICs_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyPICs_SurveyRequestID",
                table: "SurveyPICs",
                newName: "IX_SurveyPICs_SurveyID");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyPICs_PICApprovalStatusID",
                table: "SurveyPICs",
                newName: "IX_SurveyPICs_CreatedByID");

            migrationBuilder.RenameColumn(
                name: "SalesManagerAssignerID",
                table: "RFQs",
                newName: "PreSalesSupportID");

            migrationBuilder.RenameColumn(
                name: "Resource",
                table: "RFQs",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "RFQStatusID",
                table: "RFQs",
                newName: "WinProbability");

            migrationBuilder.RenameColumn(
                name: "RFQOpportunityID",
                table: "RFQs",
                newName: "SalesID");

            migrationBuilder.RenameColumn(
                name: "RFQCategoryID",
                table: "RFQs",
                newName: "ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "PersonalResourceEmployeeID",
                table: "RFQs",
                newName: "PMOID");

            migrationBuilder.RenameColumn(
                name: "LastUpdateTimestamp",
                table: "RFQs",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "RFQs",
                newName: "CreatedByID");

            migrationBuilder.RenameColumn(
                name: "CreationTimestamp",
                table: "RFQs",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserID",
                table: "RFQs",
                newName: "ContactID");

            migrationBuilder.RenameColumn(
                name: "ContactPersonID",
                table: "RFQs",
                newName: "BusinessDevelopmentID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_SalesManagerAssignerID",
                table: "RFQs",
                newName: "IX_RFQs_PreSalesSupportID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_RFQOpportunityID",
                table: "RFQs",
                newName: "IX_RFQs_SalesID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_RFQCategoryID",
                table: "RFQs",
                newName: "IX_RFQs_ModifiedByID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_PersonalResourceEmployeeID",
                table: "RFQs",
                newName: "IX_RFQs_PMOID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_CustomerID",
                table: "RFQs",
                newName: "IX_RFQs_CreatedByID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_CreatedByUserID",
                table: "RFQs",
                newName: "IX_RFQs_ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_ContactPersonID",
                table: "RFQs",
                newName: "IX_RFQs_BusinessDevelopmentID");

            migrationBuilder.RenameColumn(
                name: "UploadedByUserID",
                table: "RFQAttachments",
                newName: "FileSize");

            migrationBuilder.RenameColumn(
                name: "UploadTimestamp",
                table: "RFQAttachments",
                newName: "UploadedDate");

            migrationBuilder.RenameColumn(
                name: "RFQAttachmentID",
                table: "RFQAttachments",
                newName: "AttachmentID");

            migrationBuilder.RenameColumn(
                name: "TotalUnitCost_Internal",
                table: "Quotations",
                newName: "TaxAmount");

            migrationBuilder.RenameColumn(
                name: "TotalQuoteAmount_Customer",
                table: "Quotations",
                newName: "SubTotal");

            migrationBuilder.RenameColumn(
                name: "TotalPPN_Internal",
                table: "Quotations",
                newName: "ShippingCost");

            migrationBuilder.RenameColumn(
                name: "TotalFreight_Internal",
                table: "Quotations",
                newName: "GrandTotal");

            migrationBuilder.RenameColumn(
                name: "TotalEndorsement_Internal",
                table: "Quotations",
                newName: "DiscountAmount");

            migrationBuilder.RenameColumn(
                name: "TechnicalManagerApproverID",
                table: "Quotations",
                newName: "DeliveryTime");

            migrationBuilder.RenameColumn(
                name: "SplitParentQuotationID",
                table: "Quotations",
                newName: "ApprovedByID");

            migrationBuilder.RenameColumn(
                name: "ShipmentTermID",
                table: "Quotations",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "SentToCustomerTimestamp",
                table: "Quotations",
                newName: "ApprovalDate");

            migrationBuilder.RenameColumn(
                name: "SentToCustomerProofURL",
                table: "Quotations",
                newName: "TermsAndConditions");

            migrationBuilder.RenameColumn(
                name: "RemarkToCustomer",
                table: "Quotations",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "QuotationStatusID",
                table: "Quotations",
                newName: "PreparedByID");

            migrationBuilder.RenameColumn(
                name: "QuotationCode",
                table: "Quotations",
                newName: "Warranty");

            migrationBuilder.RenameColumn(
                name: "PreparedByUserID",
                table: "Quotations",
                newName: "ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "PaymentTermID",
                table: "Quotations",
                newName: "CreatedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedTimestamp",
                table: "Quotations",
                newName: "ValidUntil");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Quotations",
                newName: "QuotationDate");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_SplitParentQuotationID",
                table: "Quotations",
                newName: "IX_Quotations_ApprovedByID");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_QuotationStatusID",
                table: "Quotations",
                newName: "IX_Quotations_PreparedByID");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_PreparedByUserID",
                table: "Quotations",
                newName: "IX_Quotations_ModifiedByID");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_PaymentTermID",
                table: "Quotations",
                newName: "IX_Quotations_CreatedByID");

            migrationBuilder.RenameColumn(
                name: "UnitCost_Internal",
                table: "QuotationItems",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "TotalQuotePrice_Customer",
                table: "QuotationItems",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "TotalCostPerUnit_Internal",
                table: "QuotationItems",
                newName: "TaxAmount");

            migrationBuilder.RenameColumn(
                name: "QuotePricePerUnit_Customer",
                table: "QuotationItems",
                newName: "DiscountAmount");

            migrationBuilder.RenameColumn(
                name: "RelatedEntityID",
                table: "Notifications",
                newName: "ReferenceID");

            migrationBuilder.RenameColumn(
                name: "RecipientUserID",
                table: "Notifications",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "CreationTimestamp",
                table: "Notifications",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_RecipientUserID",
                table: "Notifications",
                newName: "IX_Notifications_UserID");

            migrationBuilder.RenameColumn(
                name: "PICApprovalStatusID",
                table: "MeetingPICs",
                newName: "MeetingID");

            migrationBuilder.RenameColumn(
                name: "MeetingPIC_ID",
                table: "MeetingPICs",
                newName: "MeetingPICID");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingPICs_PICApprovalStatusID",
                table: "MeetingPICs",
                newName: "IX_MeetingPICs_MeetingID");

            migrationBuilder.RenameColumn(
                name: "WeightUnit",
                table: "Items",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "TKDNCertificateNumber",
                table: "Items",
                newName: "ModelNumber");

            migrationBuilder.RenameColumn(
                name: "TKDNCertificateAttachmentURL",
                table: "Items",
                newName: "TechnicalSpecification");

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Items",
                newName: "StockQty");

            migrationBuilder.RenameColumn(
                name: "SpecificationDetails",
                table: "Items",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "SoftwareVersion",
                table: "Items",
                newName: "UoM");

            migrationBuilder.RenameColumn(
                name: "LicenseType",
                table: "Items",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "LastModifiedTimestamp",
                table: "Items",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ItemTypeID",
                table: "Items",
                newName: "WarrantyPeriod");

            migrationBuilder.RenameColumn(
                name: "ItemServiceType",
                table: "Items",
                newName: "ItemType");

            migrationBuilder.RenameColumn(
                name: "ItemCategoryID",
                table: "Items",
                newName: "ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "CreatedTimestamp",
                table: "Items",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Items",
                newName: "CertificateNo");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ItemCategoryID",
                table: "Items",
                newName: "IX_Items_ModifiedByID");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "VendorName",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "VendorCode",
                table: "Vendors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "BillingCity",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingCountry",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "Vendors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByID",
                table: "Vendors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Division",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReportsToID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SurveyPICs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsLeader",
                table: "SurveyPICs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "SurveyPICs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RFQCode",
                table: "RFQs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<decimal>(
                name: "ActualValue",
                table: "RFQs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "AdminSalesID",
                table: "RFQs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "RFQs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "RFQs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "RFQs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CompetitorInfo",
                table: "RFQs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedValue",
                table: "RFQs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedClosingDate",
                table: "RFQs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "RFQs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Opportunity",
                table: "RFQs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "RFQs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RFQAttachments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "RFQAttachments",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "RFQAttachments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UploadedByID",
                table: "RFQAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Quotations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTerm",
                table: "Quotations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTimeUnit",
                table: "Quotations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "Quotations",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Quotations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm",
                table: "Quotations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuotationNumber",
                table: "Quotations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuotationTitle",
                table: "Quotations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Quotations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxPercentage",
                table: "Quotations",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                table: "QuotationItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "QuotationItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "QuotationItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "QuotationItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "QuotationItems",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "QuotationItems",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxPercentage",
                table: "QuotationItems",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "NotificationType",
                table: "Notifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadDate",
                table: "Notifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceType",
                table: "Notifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceURL",
                table: "Notifications",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notifications",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AttendanceStatus",
                table: "MeetingPICs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                table: "MeetingPICs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDate",
                table: "MeetingPICs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "MeetingPICs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Items",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EOLDate",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EOSDate",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadTime",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinimumStockLevel",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "WarrantyUnit",
                table: "Items",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityID = table.Column<int>(type: "int", nullable: true),
                    EntityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_AuditLogs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountManagerID = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    AccountPayable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountReceivable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AnnualRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillingAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BillingCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingStreet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BillingZIPCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CustomerLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: true),
                    FaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsShippingSameAsBilling = table.Column<bool>(type: "bit", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NPWP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProfilePictureFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProfilePictureFileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShippingCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingStreet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShippingZIPCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TOP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearEstablished = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Companies_Users_AccountManagerID",
                        column: x => x.AccountManagerID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    DepartmentHeadID = table.Column<int>(type: "int", nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DivisionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Users_DepartmentHeadID",
                        column: x => x.DepartmentHeadID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMovements",
                columns: table => new
                {
                    MovementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    PerformedByID = table.Column<int>(type: "int", nullable: false),
                    CurrentStock = table.Column<int>(type: "int", nullable: false),
                    MovementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovementType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PreviousStock = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReferenceID = table.Column<int>(type: "int", nullable: true),
                    ReferenceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMovements", x => x.MovementID);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_Users_PerformedByID",
                        column: x => x.PerformedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemImages",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemImages", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_ItemImages_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemImages_Users_UploadedByID",
                        column: x => x.UploadedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemVendors",
                columns: table => new
                {
                    ItemVendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsPreferred = table.Column<bool>(type: "bit", nullable: false),
                    LeadTime = table.Column<int>(type: "int", nullable: true),
                    MinimumOrderQuantity = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PriceEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PriceStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WarrantyPeriod = table.Column<int>(type: "int", nullable: true),
                    WarrantyUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVendors", x => x.ItemVendorID);
                    table.ForeignKey(
                        name: "FK_ItemVendors_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVendors_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVendors_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVendors_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarketingActivities",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ResponsibleUserID = table.Column<int>(type: "int", nullable: false),
                    ActivityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActualCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Outcome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingActivities", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK_MarketingActivities_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketingActivities_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketingActivities_Users_ResponsibleUserID",
                        column: x => x.ResponsibleUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    OrganizedByID = table.Column<int>(type: "int", nullable: false),
                    RFQID = table.Column<int>(type: "int", nullable: true),
                    Agenda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MeetingRoom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MeetingTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MeetingType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VirtualMeetingLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingID);
                    table.ForeignKey(
                        name: "FK_Meetings_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meetings_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meetings_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meetings_Users_OrganizedByID",
                        column: x => x.OrganizedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PMOAssignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    PMOID = table.Column<int>(type: "int", nullable: false),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMOAssignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_PMOAssignments_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PMOAssignments_Users_AssignedByID",
                        column: x => x.AssignedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PMOAssignments_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PMOAssignments_Users_PMOID",
                        column: x => x.PMOID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuotationAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationID = table.Column<int>(type: "int", nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationAttachments", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_QuotationAttachments_Quotations_QuotationID",
                        column: x => x.QuotationID,
                        principalTable: "Quotations",
                        principalColumn: "QuotationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationAttachments_Users_UploadedByID",
                        column: x => x.UploadedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuotationHistories",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangedByID = table.Column<int>(type: "int", nullable: false),
                    QuotationID = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChangeDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PreviousStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationHistories", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK_QuotationHistories_Quotations_QuotationID",
                        column: x => x.QuotationID,
                        principalTable: "Quotations",
                        principalColumn: "QuotationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationHistories_Users_ChangedByID",
                        column: x => x.ChangedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestItems",
                columns: table => new
                {
                    RequestItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedToID = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    RequestedByID = table.Column<int>(type: "int", nullable: false),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestItems", x => x.RequestItemID);
                    table.ForeignKey(
                        name: "FK_RequestItems_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestItems_Users_AssignedToID",
                        column: x => x.AssignedToID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestItems_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestItems_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestItems_Users_RequestedByID",
                        column: x => x.RequestedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RFQItems",
                columns: table => new
                {
                    RFQItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryLeadTime = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WarrantyPeriod = table.Column<int>(type: "int", nullable: true),
                    WarrantyUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQItems", x => x.RFQItemID);
                    table.ForeignKey(
                        name: "FK_RFQItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQItems_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RFQItems_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQItems_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RFQNotesItems",
                columns: table => new
                {
                    NotesItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Leadtime = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UoM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQNotesItems", x => x.NotesItemID);
                    table.ForeignKey(
                        name: "FK_RFQNotesItems_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RFQNotesItems_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQNotesItems_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurveyCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SurveyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SurveyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SurveyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyID);
                    table.ForeignKey(
                        name: "FK_Surveys_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Surveys_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Surveys_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskToDoTemplates",
                columns: table => new
                {
                    TemplateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskToDoTemplates", x => x.TemplateID);
                    table.ForeignKey(
                        name: "FK_TaskToDoTemplates_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskToDoTemplates_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendorAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorAttachments", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_VendorAttachments_Users_UploadedByID",
                        column: x => x.UploadedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendorAttachments_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorBankAccounts",
                columns: table => new
                {
                    BankAccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    AccountHolderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorBankAccounts", x => x.BankAccountID);
                    table.ForeignKey(
                        name: "FK_VendorBankAccounts_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendorBankAccounts_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendorBankAccounts_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAttachments", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_CompanyAttachments_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAttachments_Users_UploadedByID",
                        column: x => x.UploadedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerContacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDecisionMaker = table.Column<bool>(type: "bit", nullable: false),
                    IsEndUser = table.Column<bool>(type: "bit", nullable: false),
                    IsPersonal = table.Column<bool>(type: "bit", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProfilePictureFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProfilePictureFileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContacts", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_CustomerContacts_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerContacts_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerContacts_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDepartments",
                columns: table => new
                {
                    UserDepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepartments", x => x.UserDepartmentID);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
                    AttachmentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingAttachments", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_MeetingAttachments_Meetings_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meetings",
                        principalColumn: "MeetingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingAttachments_Users_UploadedByID",
                        column: x => x.UploadedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingMinutes",
                columns: table => new
                {
                    MinuteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedToID = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ActionItem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MinuteContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingMinutes", x => x.MinuteID);
                    table.ForeignKey(
                        name: "FK_MeetingMinutes_Meetings_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meetings",
                        principalColumn: "MeetingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingMinutes_Users_AssignedToID",
                        column: x => x.AssignedToID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingMinutes_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingMinutes_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestItemAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestItemID = table.Column<int>(type: "int", nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestItemAttachments", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_RequestItemAttachments_RequestItems_RequestItemID",
                        column: x => x.RequestItemID,
                        principalTable: "RequestItems",
                        principalColumn: "RequestItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestItemAttachments_Users_UploadedByID",
                        column: x => x.UploadedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestItemResponses",
                columns: table => new
                {
                    ResponseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestItemID = table.Column<int>(type: "int", nullable: false),
                    RespondedByID = table.Column<int>(type: "int", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestItemResponses", x => x.ResponseID);
                    table.ForeignKey(
                        name: "FK_RequestItemResponses_RequestItems_RequestItemID",
                        column: x => x.RequestItemID,
                        principalTable: "RequestItems",
                        principalColumn: "RequestItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestItemResponses_Users_RespondedByID",
                        column: x => x.RespondedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RFQItemAddOns",
                columns: table => new
                {
                    AddOnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQItemID = table.Column<int>(type: "int", nullable: false),
                    AddOnDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AddOnName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AddOnQty = table.Column<int>(type: "int", nullable: false),
                    AddOnUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AddOnUoM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQItemAddOns", x => x.AddOnID);
                    table.ForeignKey(
                        name: "FK_RFQItemAddOns_RFQItems_RFQItemID",
                        column: x => x.RFQItemID,
                        principalTable: "RFQItems",
                        principalColumn: "RFQItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    RFQID = table.Column<int>(type: "int", nullable: true),
                    SurveyID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReportContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReportType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK_Reports_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
                    AttachmentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAttachments", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_SurveyAttachments_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyAttachments_Users_UploadedByID",
                        column: x => x.UploadedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyForms",
                columns: table => new
                {
                    FormID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FormType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyForms", x => x.FormID);
                    table.ForeignKey(
                        name: "FK_SurveyForms_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyForms_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyForms_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResults",
                columns: table => new
                {
                    ResultID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    Conclusion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recommendation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ResultContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResults", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_SurveyResults_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyResults_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyResults_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskToDos",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedByID = table.Column<int>(type: "int", nullable: true),
                    AssignedToID = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    TemplateID = table.Column<int>(type: "int", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceID = table.Column<int>(type: "int", nullable: true),
                    ReferenceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskToDos", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_TaskToDos_TaskToDoTemplates_TemplateID",
                        column: x => x.TemplateID,
                        principalTable: "TaskToDoTemplates",
                        principalColumn: "TemplateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskToDos_Users_AssignedByID",
                        column: x => x.AssignedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskToDos_Users_AssignedToID",
                        column: x => x.AssignedToID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskToDos_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskToDos_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessDevelopmentActivities",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    PerformedByID = table.Column<int>(type: "int", nullable: false),
                    RFQID = table.Column<int>(type: "int", nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextSteps = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Outcome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDevelopmentActivities", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK_BusinessDevelopmentActivities_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessDevelopmentActivities_CustomerContacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "CustomerContacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessDevelopmentActivities_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessDevelopmentActivities_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessDevelopmentActivities_Users_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessDevelopmentActivities_Users_PerformedByID",
                        column: x => x.PerformedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarketingActivityCompanies",
                columns: table => new
                {
                    ActivityCompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingActivityCompanies", x => x.ActivityCompanyID);
                    table.ForeignKey(
                        name: "FK_MarketingActivityCompanies_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketingActivityCompanies_CustomerContacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "CustomerContacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketingActivityCompanies_MarketingActivities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "MarketingActivities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketingActivityCompanies_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingExternalParticipants",
                columns: table => new
                {
                    ExternalParticipantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactID = table.Column<int>(type: "int", nullable: true),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParticipantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingExternalParticipants", x => x.ExternalParticipantID);
                    table.ForeignKey(
                        name: "FK_MeetingExternalParticipants_CustomerContacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "CustomerContacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingExternalParticipants_Meetings_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meetings",
                        principalColumn: "MeetingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportID = table.Column<int>(type: "int", nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAttachments", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_ReportAttachments_Reports_ReportID",
                        column: x => x.ReportID,
                        principalTable: "Reports",
                        principalColumn: "ReportID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportAttachments_Users_UploadedByID",
                        column: x => x.UploadedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_CreatedByID",
                table: "Vendors",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_ModifiedByID",
                table: "Vendors",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorCode",
                table: "Vendors",
                column: "VendorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedByID",
                table: "Users",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ReportsToID",
                table: "Users",
                column: "ReportsToID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_AdminSalesID",
                table: "RFQs",
                column: "AdminSalesID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_CompanyID",
                table: "RFQs",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQAttachments_UploadedByID",
                table: "RFQAttachments",
                column: "UploadedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationNumber",
                table: "Quotations",
                column: "QuotationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedByID",
                table: "Notifications",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CreatedByID",
                table: "Items",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_UserID",
                table: "AuditLogs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDevelopmentActivities_CompanyID",
                table: "BusinessDevelopmentActivities",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDevelopmentActivities_ContactID",
                table: "BusinessDevelopmentActivities",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDevelopmentActivities_CreatedByID",
                table: "BusinessDevelopmentActivities",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDevelopmentActivities_ModifiedByID",
                table: "BusinessDevelopmentActivities",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDevelopmentActivities_PerformedByID",
                table: "BusinessDevelopmentActivities",
                column: "PerformedByID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDevelopmentActivities_RFQID",
                table: "BusinessDevelopmentActivities",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AccountManagerID",
                table: "Companies",
                column: "AccountManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyCode",
                table: "Companies",
                column: "CompanyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedByID",
                table: "Companies",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ModifiedByID",
                table: "Companies",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAttachments_CompanyID",
                table: "CompanyAttachments",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAttachments_UploadedByID",
                table: "CompanyAttachments",
                column: "UploadedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_CompanyID",
                table: "CustomerContacts",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_CreatedByID",
                table: "CustomerContacts",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_ModifiedByID",
                table: "CustomerContacts",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedByID",
                table: "Departments",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentHeadID",
                table: "Departments",
                column: "DepartmentHeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ModifiedByID",
                table: "Departments",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_ItemID",
                table: "InventoryMovements",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_PerformedByID",
                table: "InventoryMovements",
                column: "PerformedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemImages_ItemID",
                table: "ItemImages",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemImages_UploadedByID",
                table: "ItemImages",
                column: "UploadedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendors_CreatedByID",
                table: "ItemVendors",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendors_ItemID",
                table: "ItemVendors",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendors_ModifiedByID",
                table: "ItemVendors",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendors_VendorID",
                table: "ItemVendors",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingActivities_CreatedByID",
                table: "MarketingActivities",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingActivities_ModifiedByID",
                table: "MarketingActivities",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingActivities_ResponsibleUserID",
                table: "MarketingActivities",
                column: "ResponsibleUserID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingActivityCompanies_ActivityID",
                table: "MarketingActivityCompanies",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingActivityCompanies_CompanyID",
                table: "MarketingActivityCompanies",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingActivityCompanies_ContactID",
                table: "MarketingActivityCompanies",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingActivityCompanies_CreatedByID",
                table: "MarketingActivityCompanies",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingAttachments_MeetingID",
                table: "MeetingAttachments",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingAttachments_UploadedByID",
                table: "MeetingAttachments",
                column: "UploadedByID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingExternalParticipants_ContactID",
                table: "MeetingExternalParticipants",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingExternalParticipants_MeetingID",
                table: "MeetingExternalParticipants",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMinutes_AssignedToID",
                table: "MeetingMinutes",
                column: "AssignedToID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMinutes_CreatedByID",
                table: "MeetingMinutes",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMinutes_MeetingID",
                table: "MeetingMinutes",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMinutes_ModifiedByID",
                table: "MeetingMinutes",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_CreatedByID",
                table: "Meetings",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ModifiedByID",
                table: "Meetings",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_OrganizedByID",
                table: "Meetings",
                column: "OrganizedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_RFQID",
                table: "Meetings",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_PMOAssignments_AssignedByID",
                table: "PMOAssignments",
                column: "AssignedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PMOAssignments_ModifiedByID",
                table: "PMOAssignments",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PMOAssignments_PMOID",
                table: "PMOAssignments",
                column: "PMOID");

            migrationBuilder.CreateIndex(
                name: "IX_PMOAssignments_RFQID",
                table: "PMOAssignments",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationAttachments_QuotationID",
                table: "QuotationAttachments",
                column: "QuotationID");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationAttachments_UploadedByID",
                table: "QuotationAttachments",
                column: "UploadedByID");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationHistories_ChangedByID",
                table: "QuotationHistories",
                column: "ChangedByID");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationHistories_QuotationID",
                table: "QuotationHistories",
                column: "QuotationID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAttachments_ReportID",
                table: "ReportAttachments",
                column: "ReportID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAttachments_UploadedByID",
                table: "ReportAttachments",
                column: "UploadedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CreatedByID",
                table: "Reports",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ModifiedByID",
                table: "Reports",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_RFQID",
                table: "Reports",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_SurveyID",
                table: "Reports",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItemAttachments_RequestItemID",
                table: "RequestItemAttachments",
                column: "RequestItemID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItemAttachments_UploadedByID",
                table: "RequestItemAttachments",
                column: "UploadedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItemResponses_RequestItemID",
                table: "RequestItemResponses",
                column: "RequestItemID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItemResponses_RespondedByID",
                table: "RequestItemResponses",
                column: "RespondedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_AssignedToID",
                table: "RequestItems",
                column: "AssignedToID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_CreatedByID",
                table: "RequestItems",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_ModifiedByID",
                table: "RequestItems",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_RequestedByID",
                table: "RequestItems",
                column: "RequestedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_RFQID",
                table: "RequestItems",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQItemAddOns_RFQItemID",
                table: "RFQItemAddOns",
                column: "RFQItemID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQItems_CreatedByID",
                table: "RFQItems",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQItems_ItemID",
                table: "RFQItems",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQItems_ModifiedByID",
                table: "RFQItems",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQItems_RFQID",
                table: "RFQItems",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQNotesItems_CreatedByID",
                table: "RFQNotesItems",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQNotesItems_ModifiedByID",
                table: "RFQNotesItems",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQNotesItems_RFQID",
                table: "RFQNotesItems",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAttachments_SurveyID",
                table: "SurveyAttachments",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAttachments_UploadedByID",
                table: "SurveyAttachments",
                column: "UploadedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyForms_CreatedByID",
                table: "SurveyForms",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyForms_ModifiedByID",
                table: "SurveyForms",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyForms_SurveyID",
                table: "SurveyForms",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_CreatedByID",
                table: "SurveyResults",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_ModifiedByID",
                table: "SurveyResults",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_SurveyID",
                table: "SurveyResults",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_CreatedByID",
                table: "Surveys",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_ModifiedByID",
                table: "Surveys",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_RFQID",
                table: "Surveys",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyCode",
                table: "Surveys",
                column: "SurveyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDos_AssignedByID",
                table: "TaskToDos",
                column: "AssignedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDos_AssignedToID",
                table: "TaskToDos",
                column: "AssignedToID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDos_CreatedByID",
                table: "TaskToDos",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDos_ModifiedByID",
                table: "TaskToDos",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDos_TemplateID",
                table: "TaskToDos",
                column: "TemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDoTemplates_CreatedByID",
                table: "TaskToDoTemplates",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDoTemplates_ModifiedByID",
                table: "TaskToDoTemplates",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_CreatedByID",
                table: "UserDepartments",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_DepartmentID",
                table: "UserDepartments",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_UserID",
                table: "UserDepartments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorAttachments_UploadedByID",
                table: "VendorAttachments",
                column: "UploadedByID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorAttachments_VendorID",
                table: "VendorAttachments",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorBankAccounts_CreatedByID",
                table: "VendorBankAccounts",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorBankAccounts_ModifiedByID",
                table: "VendorBankAccounts",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorBankAccounts_VendorID",
                table: "VendorBankAccounts",
                column: "VendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_CreatedByID",
                table: "Items",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_ModifiedByID",
                table: "Items",
                column: "ModifiedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingPICs_Meetings_MeetingID",
                table: "MeetingPICs",
                column: "MeetingID",
                principalTable: "Meetings",
                principalColumn: "MeetingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingPICs_Users_UserID",
                table: "MeetingPICs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_CreatedByID",
                table: "Notifications",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserID",
                table: "Notifications",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Items_ItemID",
                table: "QuotationItems",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_ApprovedByID",
                table: "Quotations",
                column: "ApprovedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_CreatedByID",
                table: "Quotations",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_ModifiedByID",
                table: "Quotations",
                column: "ModifiedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_PreparedByID",
                table: "Quotations",
                column: "PreparedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQAttachments_Users_UploadedByID",
                table: "RFQAttachments",
                column: "UploadedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Companies_CompanyID",
                table: "RFQs",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_CustomerContacts_ContactID",
                table: "RFQs",
                column: "ContactID",
                principalTable: "CustomerContacts",
                principalColumn: "ContactID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_AdminSalesID",
                table: "RFQs",
                column: "AdminSalesID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_BusinessDevelopmentID",
                table: "RFQs",
                column: "BusinessDevelopmentID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_CreatedByID",
                table: "RFQs",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_ModifiedByID",
                table: "RFQs",
                column: "ModifiedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_PMOID",
                table: "RFQs",
                column: "PMOID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_PreSalesSupportID",
                table: "RFQs",
                column: "PreSalesSupportID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_SalesID",
                table: "RFQs",
                column: "SalesID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyPICs_Surveys_SurveyID",
                table: "SurveyPICs",
                column: "SurveyID",
                principalTable: "Surveys",
                principalColumn: "SurveyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyPICs_Users_CreatedByID",
                table: "SurveyPICs",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyPICs_Users_UserID",
                table: "SurveyPICs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ModifiedByID",
                table: "Users",
                column: "ModifiedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ReportsToID",
                table: "Users",
                column: "ReportsToID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Users_CreatedByID",
                table: "Vendors",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Users_ModifiedByID",
                table: "Vendors",
                column: "ModifiedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Users_PurchasingManagerID",
                table: "Vendors",
                column: "PurchasingManagerID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
