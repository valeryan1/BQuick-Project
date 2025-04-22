using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BQuick.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBQuickSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_Users_UserID",
                table: "AuditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContacts_Customers_CustomerID",
                table: "CustomerContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationID",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_UserID",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQItems_RFQs_RFQID",
                table: "RFQItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Customers_CustomerID",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_AssignedTo",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQs_Users_CreatedBy",
                table: "RFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyForms_Surveys_SurveyID",
                table: "SurveyForms");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyForms_Users_UserID",
                table: "SurveyForms");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Users_AssignedTo",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorBankAccounts_Vendors_VendorID",
                table: "VendorBankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Users_UserID",
                table: "Vendors");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MeetingParticipants");

            migrationBuilder.DropTable(
                name: "QuotationApprovals");

            migrationBuilder.DropTable(
                name: "RFQNotes");

            migrationBuilder.DropTable(
                name: "VendorItems");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_CustomerID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_QuotationCode",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_UserID",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_MeetingCode",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Items_UserID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "SurveyName",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "TotalBudget",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Margin",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "MeetingCode",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "MeetingName",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "NewValue",
                table: "AuditLogs");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Vendors",
                newName: "ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Vendors",
                newName: "ShipmentPostalCode");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Vendors",
                newName: "CreatedByID");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Vendors",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Vendors",
                newName: "VendorType");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Vendors",
                newName: "VendorCategory");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Vendors",
                newName: "ShipmentAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Vendors_UserID",
                table: "Vendors",
                newName: "IX_Vendors_ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "BranchName",
                table: "VendorBankAccounts",
                newName: "Branch");

            migrationBuilder.RenameColumn(
                name: "AccountHolder",
                table: "VendorBankAccounts",
                newName: "AccountHolderName");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "VendorBankAccounts",
                newName: "BankAccountID");

            migrationBuilder.RenameColumn(
                name: "LastLogin",
                table: "Users",
                newName: "LastLoginDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "AssignedTo",
                table: "Surveys",
                newName: "ModifiedByID");

            migrationBuilder.RenameIndex(
                name: "IX_Surveys_AssignedTo",
                table: "Surveys",
                newName: "IX_Surveys_ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "SurveyForms",
                newName: "ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "FormData",
                table: "SurveyForms",
                newName: "FormContent");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "SurveyForms",
                newName: "CreatedByID");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "SurveyForms",
                newName: "ModifiedDate");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyForms_UserID",
                table: "SurveyForms",
                newName: "IX_SurveyForms_ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "RFQs",
                newName: "WinProbability");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "RFQs",
                newName: "SalesID");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "RFQs",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "AssignedTo",
                table: "RFQs",
                newName: "ModifiedByID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_CreatedBy",
                table: "RFQs",
                newName: "IX_RFQs_SalesID");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_AssignedTo",
                table: "RFQs",
                newName: "IX_RFQs_ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "RFQItems",
                newName: "WarrantyUnit");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Quotations",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "QuotationCode",
                table: "Quotations",
                newName: "DeliveryTimeUnit");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Quotations",
                newName: "PreparedByID");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Quotations",
                newName: "QuotationDate");

            migrationBuilder.RenameColumn(
                name: "ScheduledDate",
                table: "Meetings",
                newName: "EndDateTime");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Items",
                newName: "StockQty");

            migrationBuilder.RenameColumn(
                name: "UnitOfMeasure",
                table: "Items",
                newName: "WarrantyUnit");

            migrationBuilder.RenameColumn(
                name: "SubCategory",
                table: "Items",
                newName: "UoM");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Items",
                newName: "ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Items",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "CustomerContacts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "CustomerContacts",
                newName: "ModifiedByID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerContacts_CustomerID",
                table: "CustomerContacts",
                newName: "IX_CustomerContacts_ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "TableName",
                table: "AuditLogs",
                newName: "IPAddress");

            migrationBuilder.RenameColumn(
                name: "RecordID",
                table: "AuditLogs",
                newName: "EntityID");

            migrationBuilder.RenameColumn(
                name: "OldValue",
                table: "AuditLogs",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "LoggedAt",
                table: "AuditLogs",
                newName: "LogDate");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "Vendors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "BillingPostalCode",
                table: "Vendors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingProvince",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Vendors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Vendors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PurchasingManagerID",
                table: "Vendors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipmentCity",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShipmentCountry",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShipmentProvince",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VendorRating",
                table: "Vendors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Vendors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "VendorBankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "VendorBankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "VendorBankAccounts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "VendorBankAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByID",
                table: "VendorBankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "VendorBankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SwiftCode",
                table: "VendorBankAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Division",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportsToID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SurveyCode",
                table: "Surveys",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Surveys",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "Surveys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Surveys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Surveys",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Surveys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SurveyDate",
                table: "Surveys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SurveyDescription",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SurveyTitle",
                table: "Surveys",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SurveyForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FormTitle",
                table: "SurveyForms",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "RFQs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "RFQName",
                table: "RFQs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "RFQs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

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

            migrationBuilder.AddColumn<int>(
                name: "BusinessDevelopmentID",
                table: "RFQs",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "RFQs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "RFQs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RFQs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddColumn<int>(
                name: "PMOID",
                table: "RFQs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreSalesSupportID",
                table: "RFQs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "RFQs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "RFQItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "RFQItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "RFQItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RFQItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeliveryLeadTime",
                table: "RFQItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RFQItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "RFQItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByID",
                table: "RFQItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "RFQItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "RFQItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "RFQItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "WarrantyPeriod",
                table: "RFQItems",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidUntil",
                table: "Quotations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Quotations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Quotations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Quotations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedByID",
                table: "Quotations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "Quotations",
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

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTime",
                table: "Quotations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "Quotations",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GrandTotal",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByID",
                table: "Quotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Quotations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<decimal>(
                name: "ShippingCost",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxPercentage",
                table: "Quotations",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TermsAndConditions",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Warranty",
                table: "Quotations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

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
                name: "DiscountAmount",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
                name: "TaxAmount",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxPercentage",
                table: "QuotationItems",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UoM",
                table: "QuotationItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Meetings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "RFQID",
                table: "Meetings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Meetings",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Agenda",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MeetingRoom",
                table: "Meetings",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeetingTitle",
                table: "Meetings",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeetingType",
                table: "Meetings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByID",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrganizedByID",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "VirtualMeetingLink",
                table: "Meetings",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ItemCode",
                table: "Items",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "CertificateNo",
                table: "Items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Items",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsEOL",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEOS",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTKDN",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "Items",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LeadTime",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MinimumStockLevel",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModelNumber",
                table: "Items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShipmentMethod",
                table: "Items",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TKDNPercentage",
                table: "Items",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicalSpecification",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "WarrantyPeriod",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "CustomerContacts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "CustomerContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContactType",
                table: "CustomerContacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "CustomerContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CustomerContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "CustomerContacts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDecisionMaker",
                table: "CustomerContacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEndUser",
                table: "CustomerContacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPersonal",
                table: "CustomerContacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "CustomerContacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CustomerContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CustomerContacts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CustomerContacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "CustomerContacts",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureFileName",
                table: "CustomerContacts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureFileType",
                table: "CustomerContacts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EntityType",
                table: "AuditLogs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserAgent",
                table: "AuditLogs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnnualRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmployeeCount = table.Column<int>(type: "int", nullable: true),
                    YearEstablished = table.Column<int>(type: "int", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TOP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NPWP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AccountReceivable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountPayable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BillingStreet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BillingCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingZIPCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShippingStreet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShippingCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingZIPCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsShippingSameAsBilling = table.Column<bool>(type: "bit", nullable: false),
                    AccountManagerID = table.Column<int>(type: "int", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProfilePictureFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProfilePictureFileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DivisionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentHeadID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
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
                    MovementType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PreviousStock = table.Column<int>(type: "int", nullable: false),
                    CurrentStock = table.Column<int>(type: "int", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReferenceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceID = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PerformedByID = table.Column<int>(type: "int", nullable: false),
                    MovementDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    ImageContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
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
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LeadTime = table.Column<int>(type: "int", nullable: true),
                    MinimumOrderQuantity = table.Column<int>(type: "int", nullable: false),
                    WarrantyPeriod = table.Column<int>(type: "int", nullable: true),
                    WarrantyUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PriceStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PriceEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPreferred = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    ActivityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Outcome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ResponsibleUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "MeetingAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AttachmentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
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
                name: "MeetingExternalParticipants",
                columns: table => new
                {
                    ExternalParticipantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: true),
                    ParticipantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                name: "MeetingMinutes",
                columns: table => new
                {
                    MinuteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    MinuteContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionItem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AssignedToID = table.Column<int>(type: "int", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "MeetingPICs",
                columns: table => new
                {
                    MeetingPICID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingPICs", x => x.MeetingPICID);
                    table.ForeignKey(
                        name: "FK_MeetingPICs_Meetings_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meetings",
                        principalColumn: "MeetingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingPICs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceID = table.Column<int>(type: "int", nullable: true),
                    ReferenceURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ReadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMOAssignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    PMOID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AssignedByID = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
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
                    QuotationID = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChangeDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NewStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChangedByID = table.Column<int>(type: "int", nullable: false),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "Reports",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReportTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReportType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RFQID = table.Column<int>(type: "int", nullable: true),
                    SurveyID = table.Column<int>(type: "int", nullable: true),
                    ReportContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "RequestItems",
                columns: table => new
                {
                    RequestItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    RequestTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RequestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequestedByID = table.Column<int>(type: "int", nullable: false),
                    AssignedToID = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "RFQAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQAttachments", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_RFQAttachments_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RFQAttachments_Users_UploadedByID",
                        column: x => x.UploadedByID,
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
                    AddOnName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AddOnDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AddOnQty = table.Column<int>(type: "int", nullable: false),
                    AddOnUoM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddOnUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                name: "RFQNotesItems",
                columns: table => new
                {
                    NotesItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UoM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Leadtime = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "SurveyAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AttachmentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
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
                name: "SurveyPICs",
                columns: table => new
                {
                    SurveyPICID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsLeader = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyPICs", x => x.SurveyPICID);
                    table.ForeignKey(
                        name: "FK_SurveyPICs_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyPICs_Users_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyPICs_Users_UserID",
                        column: x => x.UserID,
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
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    ResultContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conclusion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Recommendation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "TaskToDoTemplates",
                columns: table => new
                {
                    TemplateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
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
                name: "BusinessDevelopmentActivities",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: true),
                    ActivityTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Outcome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NextSteps = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PerformedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "CompanyAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
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
                name: "UserDepartments",
                columns: table => new
                {
                    UserDepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "MarketingActivityCompanies",
                columns: table => new
                {
                    ActivityCompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "ReportAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "RequestItemAttachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestItemID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
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
                    ResponseText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespondedByID = table.Column<int>(type: "int", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "TaskToDos",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateID = table.Column<int>(type: "int", nullable: true),
                    TaskTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceID = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AssignedToID = table.Column<int>(type: "int", nullable: false),
                    AssignedByID = table.Column<int>(type: "int", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_CreatedByID",
                table: "Vendors",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_PurchasingManagerID",
                table: "Vendors",
                column: "PurchasingManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorBankAccounts_CreatedByID",
                table: "VendorBankAccounts",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorBankAccounts_ModifiedByID",
                table: "VendorBankAccounts",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedByID",
                table: "Users",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ReportsToID",
                table: "Users",
                column: "ReportsToID");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_CreatedByID",
                table: "Surveys",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyForms_CreatedByID",
                table: "SurveyForms",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_AdminSalesID",
                table: "RFQs",
                column: "AdminSalesID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_BusinessDevelopmentID",
                table: "RFQs",
                column: "BusinessDevelopmentID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_CompanyID",
                table: "RFQs",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_ContactID",
                table: "RFQs",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_CreatedByID",
                table: "RFQs",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_PMOID",
                table: "RFQs",
                column: "PMOID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_PreSalesSupportID",
                table: "RFQs",
                column: "PreSalesSupportID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQItems_CreatedByID",
                table: "RFQItems",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQItems_ModifiedByID",
                table: "RFQItems",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ApprovedByID",
                table: "Quotations",
                column: "ApprovedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CreatedByID",
                table: "Quotations",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ModifiedByID",
                table: "Quotations",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_PreparedByID",
                table: "Quotations",
                column: "PreparedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationNumber",
                table: "Quotations",
                column: "QuotationNumber",
                unique: true);

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
                name: "IX_Items_CreatedByID",
                table: "Items",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ModifiedByID",
                table: "Items",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_CompanyID",
                table: "CustomerContacts",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_CreatedByID",
                table: "CustomerContacts",
                column: "CreatedByID");

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
                name: "IX_MeetingPICs_MeetingID",
                table: "MeetingPICs",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPICs_UserID",
                table: "MeetingPICs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedByID",
                table: "Notifications",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                column: "UserID");

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
                name: "IX_RFQAttachments_RFQID",
                table: "RFQAttachments",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQAttachments_UploadedByID",
                table: "RFQAttachments",
                column: "UploadedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQItemAddOns_RFQItemID",
                table: "RFQItemAddOns",
                column: "RFQItemID");

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
                name: "IX_SurveyPICs_CreatedByID",
                table: "SurveyPICs",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyPICs_SurveyID",
                table: "SurveyPICs",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyPICs_UserID",
                table: "SurveyPICs",
                column: "UserID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_Users_UserID",
                table: "AuditLogs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContacts_Companies_CompanyID",
                table: "CustomerContacts",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContacts_Users_CreatedByID",
                table: "CustomerContacts",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContacts_Users_ModifiedByID",
                table: "CustomerContacts",
                column: "ModifiedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Meetings_Users_CreatedByID",
                table: "Meetings",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Users_ModifiedByID",
                table: "Meetings",
                column: "ModifiedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Users_OrganizedByID",
                table: "Meetings",
                column: "OrganizedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationID",
                table: "QuotationItems",
                column: "QuotationID",
                principalTable: "Quotations",
                principalColumn: "QuotationID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_RFQItems_RFQs_RFQID",
                table: "RFQItems",
                column: "RFQID",
                principalTable: "RFQs",
                principalColumn: "RFQID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQItems_Users_CreatedByID",
                table: "RFQItems",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQItems_Users_ModifiedByID",
                table: "RFQItems",
                column: "ModifiedByID",
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
                name: "FK_SurveyForms_Surveys_SurveyID",
                table: "SurveyForms",
                column: "SurveyID",
                principalTable: "Surveys",
                principalColumn: "SurveyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyForms_Users_CreatedByID",
                table: "SurveyForms",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyForms_Users_ModifiedByID",
                table: "SurveyForms",
                column: "ModifiedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Users_CreatedByID",
                table: "Surveys",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Users_ModifiedByID",
                table: "Surveys",
                column: "ModifiedByID",
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
                name: "FK_VendorBankAccounts_Users_CreatedByID",
                table: "VendorBankAccounts",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorBankAccounts_Users_ModifiedByID",
                table: "VendorBankAccounts",
                column: "ModifiedByID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorBankAccounts_Vendors_VendorID",
                table: "VendorBankAccounts",
                column: "VendorID",
                principalTable: "Vendors",
                principalColumn: "VendorID",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_Users_UserID",
                table: "AuditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContacts_Companies_CompanyID",
                table: "CustomerContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContacts_Users_CreatedByID",
                table: "CustomerContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContacts_Users_ModifiedByID",
                table: "CustomerContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_CreatedByID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_ModifiedByID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Users_CreatedByID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Users_ModifiedByID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Users_OrganizedByID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationID",
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
                name: "FK_RFQItems_RFQs_RFQID",
                table: "RFQItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQItems_Users_CreatedByID",
                table: "RFQItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RFQItems_Users_ModifiedByID",
                table: "RFQItems");

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
                name: "FK_SurveyForms_Surveys_SurveyID",
                table: "SurveyForms");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyForms_Users_CreatedByID",
                table: "SurveyForms");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyForms_Users_ModifiedByID",
                table: "SurveyForms");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Users_CreatedByID",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Users_ModifiedByID",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ModifiedByID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ReportsToID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorBankAccounts_Users_CreatedByID",
                table: "VendorBankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorBankAccounts_Users_ModifiedByID",
                table: "VendorBankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorBankAccounts_Vendors_VendorID",
                table: "VendorBankAccounts");

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
                name: "MeetingPICs");

            migrationBuilder.DropTable(
                name: "Notifications");

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
                name: "RFQAttachments");

            migrationBuilder.DropTable(
                name: "RFQItemAddOns");

            migrationBuilder.DropTable(
                name: "RFQNotesItems");

            migrationBuilder.DropTable(
                name: "SurveyAttachments");

            migrationBuilder.DropTable(
                name: "SurveyPICs");

            migrationBuilder.DropTable(
                name: "SurveyResults");

            migrationBuilder.DropTable(
                name: "TaskToDos");

            migrationBuilder.DropTable(
                name: "UserDepartments");

            migrationBuilder.DropTable(
                name: "VendorAttachments");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "MarketingActivities");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "RequestItems");

            migrationBuilder.DropTable(
                name: "TaskToDoTemplates");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_CreatedByID",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_PurchasingManagerID",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_VendorBankAccounts_CreatedByID",
                table: "VendorBankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_VendorBankAccounts_ModifiedByID",
                table: "VendorBankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Users_ModifiedByID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ReportsToID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_CreatedByID",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_SurveyForms_CreatedByID",
                table: "SurveyForms");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_AdminSalesID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_BusinessDevelopmentID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_CompanyID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_ContactID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_CreatedByID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_PMOID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_RFQs_PreSalesSupportID",
                table: "RFQs");

            migrationBuilder.DropIndex(
                name: "IX_RFQItems_CreatedByID",
                table: "RFQItems");

            migrationBuilder.DropIndex(
                name: "IX_RFQItems_ModifiedByID",
                table: "RFQItems");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_ApprovedByID",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_CreatedByID",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_ModifiedByID",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_PreparedByID",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_QuotationNumber",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_CreatedByID",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_ModifiedByID",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_OrganizedByID",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Items_CreatedByID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ModifiedByID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_CustomerContacts_CompanyID",
                table: "CustomerContacts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerContacts_CreatedByID",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BillingCity",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BillingCountry",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BillingPostalCode",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BillingProvince",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PaymentTerm",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PurchasingManagerID",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ShipmentCity",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ShipmentCountry",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ShipmentProvince",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "VendorRating",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "VendorBankAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "VendorBankAccounts");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "VendorBankAccounts");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "VendorBankAccounts");

            migrationBuilder.DropColumn(
                name: "ModifiedByID",
                table: "VendorBankAccounts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "VendorBankAccounts");

            migrationBuilder.DropColumn(
                name: "SwiftCode",
                table: "VendorBankAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Division",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedByID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReportsToID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "SurveyDate",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "SurveyDescription",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "SurveyTitle",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SurveyForms");

            migrationBuilder.DropColumn(
                name: "FormTitle",
                table: "SurveyForms");

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
                name: "BusinessDevelopmentID",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "CompetitorInfo",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
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
                name: "PMOID",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "PreSalesSupportID",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "RFQs");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "RFQItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RFQItems");

            migrationBuilder.DropColumn(
                name: "DeliveryLeadTime",
                table: "RFQItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RFQItems");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "RFQItems");

            migrationBuilder.DropColumn(
                name: "ModifiedByID",
                table: "RFQItems");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "RFQItems");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "RFQItems");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "RFQItems");

            migrationBuilder.DropColumn(
                name: "WarrantyPeriod",
                table: "RFQItems");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ApprovedByID",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "DeliveryTerm",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "GrandTotal",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ModifiedByID",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Notes",
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
                name: "ShippingCost",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "TermsAndConditions",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Warranty",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "UoM",
                table: "QuotationItems");

            migrationBuilder.DropColumn(
                name: "Agenda",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "MeetingRoom",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "MeetingTitle",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "MeetingType",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "ModifiedByID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "OrganizedByID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "VirtualMeetingLink",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "CertificateNo",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "EOLDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "EOSDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsEOL",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsEOS",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsTKDN",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LeadTime",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MinimumStockLevel",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ModelNumber",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ShipmentMethod",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TKDNPercentage",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TechnicalSpecification",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "WarrantyPeriod",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "ContactType",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "IsDecisionMaker",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "IsEndUser",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "IsPersonal",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "ProfilePictureFileName",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "ProfilePictureFileType",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "EntityType",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "UserAgent",
                table: "AuditLogs");

            migrationBuilder.RenameColumn(
                name: "VendorType",
                table: "Vendors",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "VendorCategory",
                table: "Vendors",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "ShipmentPostalCode",
                table: "Vendors",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "ShipmentAddress",
                table: "Vendors",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Vendors",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                table: "Vendors",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "CreatedByID",
                table: "Vendors",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Vendors_ModifiedByID",
                table: "Vendors",
                newName: "IX_Vendors_UserID");

            migrationBuilder.RenameColumn(
                name: "Branch",
                table: "VendorBankAccounts",
                newName: "BranchName");

            migrationBuilder.RenameColumn(
                name: "AccountHolderName",
                table: "VendorBankAccounts",
                newName: "AccountHolder");

            migrationBuilder.RenameColumn(
                name: "BankAccountID",
                table: "VendorBankAccounts",
                newName: "AccountID");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastLoginDate",
                table: "Users",
                newName: "LastLogin");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                table: "Surveys",
                newName: "AssignedTo");

            migrationBuilder.RenameIndex(
                name: "IX_Surveys_ModifiedByID",
                table: "Surveys",
                newName: "IX_Surveys_AssignedTo");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "SurveyForms",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                table: "SurveyForms",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "FormContent",
                table: "SurveyForms",
                newName: "FormData");

            migrationBuilder.RenameColumn(
                name: "CreatedByID",
                table: "SurveyForms",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyForms_ModifiedByID",
                table: "SurveyForms",
                newName: "IX_SurveyForms_UserID");

            migrationBuilder.RenameColumn(
                name: "WinProbability",
                table: "RFQs",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "SalesID",
                table: "RFQs",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "RFQs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                table: "RFQs",
                newName: "AssignedTo");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_SalesID",
                table: "RFQs",
                newName: "IX_RFQs_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_RFQs_ModifiedByID",
                table: "RFQs",
                newName: "IX_RFQs_AssignedTo");

            migrationBuilder.RenameColumn(
                name: "WarrantyUnit",
                table: "RFQItems",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "Quotations",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "QuotationDate",
                table: "Quotations",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "PreparedByID",
                table: "Quotations",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "DeliveryTimeUnit",
                table: "Quotations",
                newName: "QuotationCode");

            migrationBuilder.RenameColumn(
                name: "EndDateTime",
                table: "Meetings",
                newName: "ScheduledDate");

            migrationBuilder.RenameColumn(
                name: "WarrantyUnit",
                table: "Items",
                newName: "UnitOfMeasure");

            migrationBuilder.RenameColumn(
                name: "UoM",
                table: "Items",
                newName: "SubCategory");

            migrationBuilder.RenameColumn(
                name: "StockQty",
                table: "Items",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Items",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                table: "Items",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "CustomerContacts",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                table: "CustomerContacts",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerContacts_ModifiedByID",
                table: "CustomerContacts",
                newName: "IX_CustomerContacts_CustomerID");

            migrationBuilder.RenameColumn(
                name: "LogDate",
                table: "AuditLogs",
                newName: "LoggedAt");

            migrationBuilder.RenameColumn(
                name: "IPAddress",
                table: "AuditLogs",
                newName: "TableName");

            migrationBuilder.RenameColumn(
                name: "EntityID",
                table: "AuditLogs",
                newName: "RecordID");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "AuditLogs",
                newName: "OldValue");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SurveyCode",
                table: "Surveys",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Surveys",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "Surveys",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledDate",
                table: "Surveys",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurveyName",
                table: "Surveys",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "RFQs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "RFQName",
                table: "RFQs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "RFQs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "RFQs",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalBudget",
                table: "RFQs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "RFQItems",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "RFQItems",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidUntil",
                table: "Quotations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Quotations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Quotations",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "QuotationItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Margin",
                table: "QuotationItems",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitCost",
                table: "QuotationItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Meetings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "RFQID",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Meetings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "MeetingCode",
                table: "Meetings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeetingName",
                table: "Meetings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "ItemCode",
                table: "Items",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "CustomerContacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "NewValue",
                table: "AuditLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RelatedID = table.Column<int>(type: "int", nullable: false),
                    RelatedType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_Attachments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingParticipants",
                columns: table => new
                {
                    ParticipantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingParticipants", x => x.ParticipantID);
                    table.ForeignKey(
                        name: "FK_MeetingParticipants_Meetings_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meetings",
                        principalColumn: "MeetingID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingParticipants_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuotationApprovals",
                columns: table => new
                {
                    ApprovalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproverID = table.Column<int>(type: "int", nullable: false),
                    QuotationID = table.Column<int>(type: "int", nullable: false),
                    ApprovalLevel = table.Column<int>(type: "int", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationApprovals", x => x.ApprovalID);
                    table.ForeignKey(
                        name: "FK_QuotationApprovals_Quotations_QuotationID",
                        column: x => x.QuotationID,
                        principalTable: "Quotations",
                        principalColumn: "QuotationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuotationApprovals_Users_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RFQNotes",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    NoteText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQNotes", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_RFQNotes_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQNotes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorItems",
                columns: table => new
                {
                    VendorItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    LeadTime = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "date", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "date", nullable: false),
                    WarrantyPeriod = table.Column<int>(type: "int", nullable: false),
                    WarrantyUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorItems", x => x.VendorItemID);
                    table.ForeignKey(
                        name: "FK_VendorItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendorItems_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_CustomerID",
                table: "RFQs",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationCode",
                table: "Quotations",
                column: "QuotationCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_UserID",
                table: "Quotations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_MeetingCode",
                table: "Meetings",
                column: "MeetingCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserID",
                table: "Items",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_UserID",
                table: "Attachments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerCode",
                table: "Customers",
                column: "CustomerCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID",
                table: "Customers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingParticipants_MeetingID",
                table: "MeetingParticipants",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingParticipants_UserID",
                table: "MeetingParticipants",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationApprovals_ApproverID",
                table: "QuotationApprovals",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationApprovals_QuotationID",
                table: "QuotationApprovals",
                column: "QuotationID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQNotes_RFQID",
                table: "RFQNotes",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQNotes_UserID",
                table: "RFQNotes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorItems_ItemID",
                table: "VendorItems",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorItems_VendorID",
                table: "VendorItems",
                column: "VendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_Users_UserID",
                table: "AuditLogs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContacts_Customers_CustomerID",
                table: "CustomerContacts",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UserID",
                table: "Items",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationID",
                table: "QuotationItems",
                column: "QuotationID",
                principalTable: "Quotations",
                principalColumn: "QuotationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_UserID",
                table: "Quotations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQItems_RFQs_RFQID",
                table: "RFQItems",
                column: "RFQID",
                principalTable: "RFQs",
                principalColumn: "RFQID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Customers_CustomerID",
                table: "RFQs",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_AssignedTo",
                table: "RFQs",
                column: "AssignedTo",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RFQs_Users_CreatedBy",
                table: "RFQs",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyForms_Surveys_SurveyID",
                table: "SurveyForms",
                column: "SurveyID",
                principalTable: "Surveys",
                principalColumn: "SurveyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyForms_Users_UserID",
                table: "SurveyForms",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Users_AssignedTo",
                table: "Surveys",
                column: "AssignedTo",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorBankAccounts_Vendors_VendorID",
                table: "VendorBankAccounts",
                column: "VendorID",
                principalTable: "Vendors",
                principalColumn: "VendorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Users_UserID",
                table: "Vendors",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
