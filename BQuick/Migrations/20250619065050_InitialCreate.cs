using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BQuick.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

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
                    ReportTemplateDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    FormTemplateDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DefaultCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DefaultTermsOfPaymentID = table.Column<int>(type: "int", nullable: true),
                    BillingAddressStreet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BillingAddressDetail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BillingAddressCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BillingAddressProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BillingAddressCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BillingAddressZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ShippingAddressStreet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShippingAddressDetail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShippingAddressCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShippingAddressProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShippingAddressCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShippingAddressZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AccountReceivableCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountPayableCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PurchasingLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCategoryID = table.Column<int>(type: "int", nullable: false),
                    ItemTypeID = table.Column<int>(type: "int", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SpecificationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DimensionL = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DimensionW = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DimensionH = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DimensionUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    WeightUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ShipmentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsTKDN = table.Column<bool>(type: "bit", nullable: false),
                    TKDNPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    TKDNCertificateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TKDNCertificateAttachmentURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftwareVersion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LicenseType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemServiceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    IsEOS = table.Column<bool>(type: "bit", nullable: false),
                    IsEOL = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_ItemCategories_ItemCategoryID",
                        column: x => x.ItemCategoryID,
                        principalTable: "ItemCategories",
                        principalColumn: "ItemCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeID",
                        column: x => x.ItemTypeID,
                        principalTable: "ItemTypes",
                        principalColumn: "ItemTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CustomerContactPersons",
                columns: table => new
                {
                    ContactPersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientUserID = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RelatedEntityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RelatedEntityID = table.Column<int>(type: "int", nullable: true),
                    NavigationURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_RecipientUserID",
                        column: x => x.RecipientUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Vendors",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VendorCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultPaymentTermID = table.Column<int>(type: "int", nullable: true),
                    DefaultCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    OfficeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VendorType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RiskLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyProfileAttachmentURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingAddressStreet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BillingAddressDetail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BillingAddressCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BillingAddressProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BillingAddressCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BillingAddressZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ShippingAddressStreet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShippingAddressDetail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShippingAddressCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShippingAddressProvince = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShippingAddressCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShippingAddressZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorID);
                    table.ForeignKey(
                        name: "FK_Vendors_PaymentTerms_DefaultPaymentTermID",
                        column: x => x.DefaultPaymentTermID,
                        principalTable: "PaymentTerms",
                        principalColumn: "PaymentTermID");
                    table.ForeignKey(
                        name: "FK_Vendors_Users_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.SetNull);
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
                name: "RFQs",
                columns: table => new
                {
                    RFQID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RFQName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ContactPersonID = table.Column<int>(type: "int", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OverallBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OverallLeadTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Resource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersonalResourceEmployeeID = table.Column<int>(type: "int", nullable: true),
                    RFQCategoryID = table.Column<int>(type: "int", nullable: true),
                    RFQOpportunityID = table.Column<int>(type: "int", nullable: true),
                    RFQStatusID = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    AssignedToAdminSalesID = table.Column<int>(type: "int", nullable: true),
                    SalesManagerAssignerID = table.Column<int>(type: "int", nullable: true),
                    CreationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQs", x => x.RFQID);
                    table.ForeignKey(
                        name: "FK_RFQs_CustomerContactPersons_ContactPersonID",
                        column: x => x.ContactPersonID,
                        principalTable: "CustomerContactPersons",
                        principalColumn: "ContactPersonID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RFQs_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQs_RFQCategories_RFQCategoryID",
                        column: x => x.RFQCategoryID,
                        principalTable: "RFQCategories",
                        principalColumn: "RFQCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQs_RFQOpportunities_RFQOpportunityID",
                        column: x => x.RFQOpportunityID,
                        principalTable: "RFQOpportunities",
                        principalColumn: "RFQOpportunityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQs_RFQStatuses_RFQStatusID",
                        column: x => x.RFQStatusID,
                        principalTable: "RFQStatuses",
                        principalColumn: "RFQStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQs_Users_AssignedToAdminSalesID",
                        column: x => x.AssignedToAdminSalesID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQs_Users_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQs_Users_PersonalResourceEmployeeID",
                        column: x => x.PersonalResourceEmployeeID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQs_Users_SalesManagerAssignerID",
                        column: x => x.SalesManagerAssignerID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
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
                    LeadTimeUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WarrantyPeriod = table.Column<int>(type: "int", nullable: true),
                    WarrantyUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PriceValidityStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceValidityEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinOrderQuantity = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "VendorBanks",
                columns: table => new
                {
                    VendorBankID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AccountHolderName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
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
                name: "MeetingRequests",
                columns: table => new
                {
                    MeetingRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    MeetingCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MeetingName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PrimaryPIC_UserID = table.Column<int>(type: "int", nullable: false),
                    RequestedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesInternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "PurchasingRequests",
                columns: table => new
                {
                    PurchasingRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    ItemID_IfExists = table.Column<int>(type: "int", nullable: true),
                    RequestedItemName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RequestedItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReasonForRequest = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SalesNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesAttachmentURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Quotations",
                columns: table => new
                {
                    QuotationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PaymentTermID = table.Column<int>(type: "int", nullable: false),
                    ShipmentTermID = table.Column<int>(type: "int", nullable: false),
                    PreparedByUserID = table.Column<int>(type: "int", nullable: false),
                    TotalUnitCost_Internal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPPN_Internal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalEndorsement_Internal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalFreight_Internal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverallTotalCost_Internal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalQuoteAmount_Customer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverallMarginAmount_Internal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverallMarginPercentage_Internal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    RemarkToCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationStatusID = table.Column<int>(type: "int", nullable: false),
                    SplitParentQuotationID = table.Column<int>(type: "int", nullable: true),
                    SalesManagerApproverID = table.Column<int>(type: "int", nullable: true),
                    TechnicalManagerApproverID = table.Column<int>(type: "int", nullable: true),
                    DirectorApproverID = table.Column<int>(type: "int", nullable: true),
                    SentToCustomerTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SentToCustomerProofURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.QuotationID);
                    table.ForeignKey(
                        name: "FK_Quotations_PaymentTerms_PaymentTermID",
                        column: x => x.PaymentTermID,
                        principalTable: "PaymentTerms",
                        principalColumn: "PaymentTermID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotations_QuotationStatuses_QuotationStatusID",
                        column: x => x.QuotationStatusID,
                        principalTable: "QuotationStatuses",
                        principalColumn: "QuotationStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotations_Quotations_SplitParentQuotationID",
                        column: x => x.SplitParentQuotationID,
                        principalTable: "Quotations",
                        principalColumn: "QuotationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotations_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotations_ShipmentTerms_ShipmentTermID",
                        column: x => x.ShipmentTermID,
                        principalTable: "ShipmentTerms",
                        principalColumn: "ShipmentTermID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotations_Users_DirectorApproverID",
                        column: x => x.DirectorApproverID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotations_Users_PreparedByUserID",
                        column: x => x.PreparedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotations_Users_SalesManagerApproverID",
                        column: x => x.SalesManagerApproverID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotations_Users_TechnicalManagerApproverID",
                        column: x => x.TechnicalManagerApproverID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RFQAttachments",
                columns: table => new
                {
                    RFQAttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedByUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQAttachments", x => x.RFQAttachmentID);
                    table.ForeignKey(
                        name: "FK_RFQAttachments_RFQs_RFQID",
                        column: x => x.RFQID,
                        principalTable: "RFQs",
                        principalColumn: "RFQID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RFQAttachments_Users_UploadedByUserID",
                        column: x => x.UploadedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "RFQNotes",
                columns: table => new
                {
                    RFQNoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BudgetTarget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LeadTimeTarget = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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
                name: "SurveyRequests",
                columns: table => new
                {
                    SurveyRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQID = table.Column<int>(type: "int", nullable: false),
                    SurveyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurveyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CustomerPICName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    RequestStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesNotesInternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "MeetingPICs",
                columns: table => new
                {
                    MeetingPIC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingRequestID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PICApprovalStatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingPICs", x => x.MeetingPIC_ID);
                    table.ForeignKey(
                        name: "FK_MeetingPICs_MeetingRequests_MeetingRequestID",
                        column: x => x.MeetingRequestID,
                        principalTable: "MeetingRequests",
                        principalColumn: "MeetingRequestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingPICs_PICApprovalStatuses_PICApprovalStatusID",
                        column: x => x.PICApprovalStatusID,
                        principalTable: "PICApprovalStatuses",
                        principalColumn: "PICApprovalStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingPICs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingReportInstances",
                columns: table => new
                {
                    MeetingReportInstanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingRequestID = table.Column<int>(type: "int", nullable: false),
                    ReportMasterID = table.Column<int>(type: "int", nullable: false),
                    ReportContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesWarranty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                name: "SurveyCategorySurveyRequest",
                columns: table => new
                {
                    SurveyCategoriesSurveyCategoryID = table.Column<int>(type: "int", nullable: false),
                    SurveyRequestsSurveyRequestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyCategorySurveyRequest", x => new { x.SurveyCategoriesSurveyCategoryID, x.SurveyRequestsSurveyRequestID });
                    table.ForeignKey(
                        name: "FK_SurveyCategorySurveyRequest_SurveyCategories_SurveyCategoriesSurveyCategoryID",
                        column: x => x.SurveyCategoriesSurveyCategoryID,
                        principalTable: "SurveyCategories",
                        principalColumn: "SurveyCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyCategorySurveyRequest_SurveyRequests_SurveyRequestsSurveyRequestID",
                        column: x => x.SurveyRequestsSurveyRequestID,
                        principalTable: "SurveyRequests",
                        principalColumn: "SurveyRequestID",
                        onDelete: ReferentialAction.Cascade);
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
                    FilledFormData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedByUserID = table.Column<int>(type: "int", nullable: false),
                    SubmissionStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                name: "SurveyPICs",
                columns: table => new
                {
                    SurveyPIC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyRequestID = table.Column<int>(type: "int", nullable: false),
                    TechnicalUserID = table.Column<int>(type: "int", nullable: false),
                    PICApprovalStatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyPICs", x => x.SurveyPIC_ID);
                    table.ForeignKey(
                        name: "FK_SurveyPICs_PICApprovalStatuses_PICApprovalStatusID",
                        column: x => x.PICApprovalStatusID,
                        principalTable: "PICApprovalStatuses",
                        principalColumn: "PICApprovalStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyPICs_SurveyRequests_SurveyRequestID",
                        column: x => x.SurveyRequestID,
                        principalTable: "SurveyRequests",
                        principalColumn: "SurveyRequestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyPICs_Users_TechnicalUserID",
                        column: x => x.TechnicalUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuotationItems",
                columns: table => new
                {
                    QuotationItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    RFQ_ItemID = table.Column<int>(type: "int", nullable: true),
                    DescriptionOverride = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UnitCost_Internal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PPN_Percentage = table.Column<decimal>(type: "decimal(5,4)", nullable: true),
                    PPN_FixedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Endorsement_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Freight_AmountPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCostPerUnit_Internal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuotePricePerUnit_Customer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalQuotePrice_Customer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarginAmount_Internal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarginPercentage_Internal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SalesWarranty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayWithDetailInternal = table.Column<bool>(type: "bit", nullable: false),
                    DisplaySequence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationItems", x => x.QuotationItemID);
                    table.ForeignKey(
                        name: "FK_QuotationItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationItems_Quotations_QuotationID",
                        column: x => x.QuotationID,
                        principalTable: "Quotations",
                        principalColumn: "QuotationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationItems_RFQ_Items_RFQ_ItemID",
                        column: x => x.RFQ_ItemID,
                        principalTable: "RFQ_Items",
                        principalColumn: "RFQ_ItemID");
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
                    ReportContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ApproverRoleAtTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApprovalDecisionStatusID = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StepOrder = table.Column<int>(type: "int", nullable: false),
                    QuotationID = table.Column<int>(type: "int", nullable: true),
                    SurveyReportInstanceID = table.Column<int>(type: "int", nullable: true),
                    MeetingReportInstanceID = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "MeetingReportInstanceID");
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_Quotations_QuotationID",
                        column: x => x.QuotationID,
                        principalTable: "Quotations",
                        principalColumn: "QuotationID");
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_SurveyReportInstances_SurveyReportInstanceID",
                        column: x => x.SurveyReportInstanceID,
                        principalTable: "SurveyReportInstances",
                        principalColumn: "SurveyReportInstanceID");
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_Users_ApproverUserID",
                        column: x => x.ApproverUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Items_ItemCategoryID",
                table: "Items",
                column: "ItemCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCode",
                table: "Items",
                column: "ItemCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeID",
                table: "Items",
                column: "ItemTypeID");

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
                name: "IX_MeetingPICs_MeetingRequestID",
                table: "MeetingPICs",
                column: "MeetingRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPICs_PICApprovalStatusID",
                table: "MeetingPICs",
                column: "PICApprovalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPICs_UserID",
                table: "MeetingPICs",
                column: "UserID");

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
                name: "IX_Notifications_RecipientUserID",
                table: "Notifications",
                column: "RecipientUserID");

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
                name: "IX_QuotationItems_ItemID",
                table: "QuotationItems",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationItems_QuotationID",
                table: "QuotationItems",
                column: "QuotationID");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationItems_RFQ_ItemID",
                table: "QuotationItems",
                column: "RFQ_ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_DirectorApproverID",
                table: "Quotations",
                column: "DirectorApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_PaymentTermID",
                table: "Quotations",
                column: "PaymentTermID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_PreparedByUserID",
                table: "Quotations",
                column: "PreparedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationCode",
                table: "Quotations",
                column: "QuotationCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_QuotationStatusID",
                table: "Quotations",
                column: "QuotationStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_RFQID",
                table: "Quotations",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_SalesManagerApproverID",
                table: "Quotations",
                column: "SalesManagerApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ShipmentTermID",
                table: "Quotations",
                column: "ShipmentTermID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_SplitParentQuotationID",
                table: "Quotations",
                column: "SplitParentQuotationID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_TechnicalManagerApproverID",
                table: "Quotations",
                column: "TechnicalManagerApproverID");

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
                name: "IX_RFQAttachments_RFQID",
                table: "RFQAttachments",
                column: "RFQID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQAttachments_UploadedByUserID",
                table: "RFQAttachments",
                column: "UploadedByUserID");

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
                name: "IX_RFQs_AssignedToAdminSalesID",
                table: "RFQs",
                column: "AssignedToAdminSalesID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_ContactPersonID",
                table: "RFQs",
                column: "ContactPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_CreatedByUserID",
                table: "RFQs",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_CustomerID",
                table: "RFQs",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_PersonalResourceEmployeeID",
                table: "RFQs",
                column: "PersonalResourceEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_RFQCategoryID",
                table: "RFQs",
                column: "RFQCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_RFQCode",
                table: "RFQs",
                column: "RFQCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_RFQOpportunityID",
                table: "RFQs",
                column: "RFQOpportunityID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_RFQStatusID",
                table: "RFQs",
                column: "RFQStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_RFQs_SalesManagerAssignerID",
                table: "RFQs",
                column: "SalesManagerAssignerID");

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
                name: "IX_SurveyCategorySurveyRequest_SurveyRequestsSurveyRequestID",
                table: "SurveyCategorySurveyRequest",
                column: "SurveyRequestsSurveyRequestID");

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
                name: "IX_SurveyPICs_PICApprovalStatusID",
                table: "SurveyPICs",
                column: "PICApprovalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyPICs_SurveyRequestID",
                table: "SurveyPICs",
                column: "SurveyRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyPICs_TechnicalUserID",
                table: "SurveyPICs",
                column: "TechnicalUserID");

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
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendorBanks_VendorID",
                table: "VendorBanks",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_CreatedByUserID",
                table: "Vendors",
                column: "CreatedByUserID");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalHistories");

            migrationBuilder.DropTable(
                name: "ItemBundles");

            migrationBuilder.DropTable(
                name: "ItemVendorPricings");

            migrationBuilder.DropTable(
                name: "MeetingPICs");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "QuotationItems");

            migrationBuilder.DropTable(
                name: "RFQAttachments");

            migrationBuilder.DropTable(
                name: "RFQNotes");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SurveyCategorySurveyRequest");

            migrationBuilder.DropTable(
                name: "SurveyDocumentations");

            migrationBuilder.DropTable(
                name: "SurveyPICs");

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
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "RFQ_Items");

            migrationBuilder.DropTable(
                name: "PICApprovalStatuses");

            migrationBuilder.DropTable(
                name: "SurveyCategories");

            migrationBuilder.DropTable(
                name: "MeetingRequests");

            migrationBuilder.DropTable(
                name: "ReportMasters");

            migrationBuilder.DropTable(
                name: "ReportStatuses");

            migrationBuilder.DropTable(
                name: "SurveyInstances");

            migrationBuilder.DropTable(
                name: "QuotationStatuses");

            migrationBuilder.DropTable(
                name: "ShipmentTerms");

            migrationBuilder.DropTable(
                name: "PurchasingRequests");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "MeetingStatuses");

            migrationBuilder.DropTable(
                name: "SurveyFormMasters");

            migrationBuilder.DropTable(
                name: "SurveyRequests");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PurchasingStatuses");

            migrationBuilder.DropTable(
                name: "RFQs");

            migrationBuilder.DropTable(
                name: "SurveyStatuses");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "CustomerContactPersons");

            migrationBuilder.DropTable(
                name: "RFQCategories");

            migrationBuilder.DropTable(
                name: "RFQOpportunities");

            migrationBuilder.DropTable(
                name: "RFQStatuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ItemCategories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "PaymentTerms");
        }
    }
}
