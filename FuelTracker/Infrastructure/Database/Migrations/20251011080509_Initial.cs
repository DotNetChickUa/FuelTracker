using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelTracker.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblAccount",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountStatus = table.Column<short>(type: "INTEGER", nullable: true),
                    AccountNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    DefaultFinancialClassID = table.Column<int>(type: "INTEGER", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MI = table.Column<string>(type: "TEXT", maxLength: 1, nullable: true),
                    Suffix = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    DOB = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateOfDeath = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 1, nullable: true),
                    SSN = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true),
                    Address1 = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    Zip = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    HomePhone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    WorkPhone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    CellPhone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    OtherPhone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PatientMaritalStatus = table.Column<short>(type: "INTEGER", nullable: true),
                    PatientEmploymentStatusID = table.Column<short>(type: "INTEGER", nullable: true),
                    EmployerID = table.Column<int>(type: "INTEGER", nullable: true),
                    EmployerName = table.Column<string>(type: "TEXT", maxLength: 35, nullable: true),
                    PrimaryCareProviderID = table.Column<int>(type: "INTEGER", nullable: true),
                    SignatureonFile = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorizedPaymentToProvider = table.Column<bool>(type: "INTEGER", nullable: true),
                    ReleaseofInformationID = table.Column<int>(type: "INTEGER", nullable: true),
                    HoldFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    UBAdmissionSourceID = table.Column<int>(type: "INTEGER", nullable: true),
                    UBPatientStatusID = table.Column<int>(type: "INTEGER", nullable: true),
                    RequiredDataFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    ClaimProcessingFlag = table.Column<bool>(type: "INTEGER", nullable: true),
                    PatientStatementFlag = table.Column<bool>(type: "INTEGER", nullable: true),
                    LastStatementDate = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    LastStatementDateCareGiverGuarantor = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PatientNotificationFlag = table.Column<bool>(type: "INTEGER", nullable: true),
                    LastNotificationDate = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    CollectionManagementFlag = table.Column<bool>(type: "INTEGER", nullable: true),
                    BadDebtFlag = table.Column<bool>(type: "INTEGER", nullable: true),
                    PaymentPlanFlag = table.Column<bool>(type: "INTEGER", nullable: true),
                    LastStatementPaymentPlanDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BalanceUpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BillPayerCurrentBalance = table.Column<decimal>(type: "money", nullable: true),
                    BillGuarantorCurrentBalance = table.Column<decimal>(type: "money", nullable: true),
                    BillGuarantorBadDebt = table.Column<decimal>(type: "money", nullable: true),
                    BillCareFacilityCurrentBalance = table.Column<decimal>(type: "money", nullable: true),
                    BillCareFacilityBadDebt = table.Column<decimal>(type: "money", nullable: true),
                    PaymentPlanBalance = table.Column<decimal>(type: "money", nullable: true),
                    PaymentPlanBadDebt = table.Column<decimal>(type: "money", nullable: true),
                    GuarantorStatement = table.Column<bool>(type: "INTEGER", nullable: true),
                    CareGiverStatement = table.Column<bool>(type: "INTEGER", nullable: true),
                    PaymentPlanStatement = table.Column<bool>(type: "INTEGER", nullable: true),
                    DataType = table.Column<short>(type: "INTEGER", nullable: true),
                    AliasNamesString = table.Column<string>(type: "TEXT", nullable: true),
                    AliasNumbersString = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryLanguageID = table.Column<int>(type: "INTEGER", nullable: true),
                    DefaultClientID = table.Column<int>(type: "INTEGER", nullable: true),
                    NursingHomeResidentFlag = table.Column<bool>(type: "INTEGER", nullable: true),
                    EmployeeNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    AllowInterfaceUpdate = table.Column<bool>(type: "INTEGER", nullable: true),
                    InterfaceUpdateStatus = table.Column<short>(type: "INTEGER", nullable: true),
                    HostSystemID = table.Column<int>(type: "INTEGER", nullable: true),
                    LastInterfaceUpdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MultiplePrimaryPayerStatus = table.Column<short>(type: "INTEGER", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: true),
                    PurgeFlag = table.Column<bool>(type: "INTEGER", nullable: true),
                    PurgeDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreateDT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ChangedDT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ChangedByID = table.Column<int>(type: "INTEGER", nullable: true),
                    Locked = table.Column<bool>(type: "INTEGER", nullable: true),
                    LockedByID = table.Column<int>(type: "INTEGER", nullable: true),
                    CountyCode = table.Column<string>(type: "TEXT", maxLength: 4, nullable: true),
                    StatementHold = table.Column<bool>(type: "INTEGER", nullable: true),
                    CountrySubdivision = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 140, nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 140, nullable: true),
                    HomePhoneNumber = table.Column<long>(type: "INTEGER", nullable: true),
                    WorkPhoneNumber = table.Column<long>(type: "INTEGER", nullable: true),
                    CellPhoneNumber = table.Column<long>(type: "INTEGER", nullable: true),
                    OtherPhoneNumber = table.Column<long>(type: "INTEGER", nullable: true),
                    AccountNotes = table.Column<bool>(type: "INTEGER", nullable: true),
                    AccountAttentionLevelExists = table.Column<bool>(type: "INTEGER", nullable: true),
                    PerformRequiredFieldCheck = table.Column<bool>(type: "INTEGER", nullable: true),
                    AccountAttentionIDList = table.Column<string>(type: "TEXT", nullable: true),
                    AccountAttentionDescriptionList = table.Column<string>(type: "TEXT", nullable: true),
                    LastAccountPaymentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastAccountPaymentAmount = table.Column<decimal>(type: "money", nullable: true),
                    AccountType = table.Column<byte>(type: "INTEGER", nullable: true),
                    MasterAccountID = table.Column<int>(type: "INTEGER", nullable: true),
                    Transition = table.Column<bool>(type: "INTEGER", nullable: true),
                    LatestAccountRCMNoteID = table.Column<int>(type: "INTEGER", nullable: true),
                    StateIdentification = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FirstDateofDialysis = table.Column<DateOnly>(type: "date", nullable: true),
                    SecondaryClaimHold = table.Column<bool>(type: "INTEGER", nullable: true),
                    LatestPrimaryAccountPayerID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignAction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CampaignId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActionType = table.Column<string>(type: "TEXT", nullable: false),
                    TriggerType = table.Column<string>(type: "TEXT", nullable: false),
                    TriggerOffsetDays = table.Column<int>(type: "INTEGER", nullable: false),
                    RecurrenceDays = table.Column<int>(type: "INTEGER", nullable: true),
                    IsTerminal = table.Column<bool>(type: "INTEGER", nullable: false),
                    PriorityLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderIndex = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignAction_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignCriteria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CampaignId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FieldName = table.Column<string>(type: "TEXT", nullable: false),
                    Operator = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    LogicalGroup = table.Column<string>(type: "TEXT", nullable: true),
                    OrderIndex = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignCriteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignCriteria_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignUserAssignment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CampaignId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleTier = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignUserAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignUserAssignment_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignUserAssignment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Expires = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Revoked = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CampaignId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PriorityLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignTask_CampaignAction_ActionId",
                        column: x => x.ActionId,
                        principalTable: "CampaignAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignTask_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampaignTask_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CampaignTask_tblAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tblAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignUserAllowedAction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssignmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActionType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignUserAllowedAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignUserAllowedAction_CampaignUserAssignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "CampaignUserAssignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignAction_CampaignId",
                table: "CampaignAction",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignCriteria_CampaignId",
                table: "CampaignCriteria",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTask_AccountId",
                table: "CampaignTask",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTask_ActionId",
                table: "CampaignTask",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTask_AssignedUserId",
                table: "CampaignTask",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTask_CampaignId",
                table: "CampaignTask",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUserAllowedAction_AssignmentId",
                table: "CampaignUserAllowedAction",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUserAssignment_CampaignId",
                table: "CampaignUserAssignment",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUserAssignment_UserId",
                table: "CampaignUserAssignment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignCriteria");

            migrationBuilder.DropTable(
                name: "CampaignTask");

            migrationBuilder.DropTable(
                name: "CampaignUserAllowedAction");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "CampaignAction");

            migrationBuilder.DropTable(
                name: "tblAccount");

            migrationBuilder.DropTable(
                name: "CampaignUserAssignment");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
