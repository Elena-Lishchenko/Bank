namespace Transaction.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankId = c.Int(nullable: false),
                        AccountTypeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.AccountTypeId)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.BankId)
                .Index(t => t.AccountTypeId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BankRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankId = c.Int(nullable: false),
                        BankTransactionTypeId = c.Int(nullable: false),
                        TransactionActionId = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.BankTransactionTypes", t => t.BankTransactionTypeId)
                .ForeignKey("dbo.TransactionActions", t => t.TransactionActionId)
                .Index(t => t.BankId)
                .Index(t => t.BankTransactionTypeId)
                .Index(t => t.TransactionActionId);
            
            CreateTable(
                "dbo.BankTransactionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransactionActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StandartRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StandartRuleId = c.Int(nullable: false),
                        ReceiverAccountTypeId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.ReceiverAccountTypeId)
                .ForeignKey("dbo.StandartRules", t => t.StandartRuleId)
                .Index(t => t.StandartRuleId)
                .Index(t => t.ReceiverAccountTypeId);
            
            CreateTable(
                "dbo.StandartRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderAccountTypeId = c.Int(nullable: false),
                        TransactionActionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.SenderAccountTypeId)
                .ForeignKey("dbo.TransactionActions", t => t.TransactionActionId)
                .Index(t => t.SenderAccountTypeId)
                .Index(t => t.TransactionActionId);
            
            CreateTable(
                "dbo.BankTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceiverId = c.Int(nullable: false),
                        StandartRate = c.Double(nullable: false),
                        BankRate = c.Double(nullable: false),
                        OperatorId = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        Operator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Operator_Id)
                .ForeignKey("dbo.Accounts", t => t.ReceiverId)
                .ForeignKey("dbo.Accounts", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId)
                .Index(t => t.Operator_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankTransactions", "SenderId", "dbo.Accounts");
            DropForeignKey("dbo.BankTransactions", "ReceiverId", "dbo.Accounts");
            DropForeignKey("dbo.BankTransactions", "Operator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StandartRates", "StandartRuleId", "dbo.StandartRules");
            DropForeignKey("dbo.StandartRules", "TransactionActionId", "dbo.TransactionActions");
            DropForeignKey("dbo.StandartRules", "SenderAccountTypeId", "dbo.AccountTypes");
            DropForeignKey("dbo.StandartRates", "ReceiverAccountTypeId", "dbo.AccountTypes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BankRates", "TransactionActionId", "dbo.TransactionActions");
            DropForeignKey("dbo.BankRates", "BankTransactionTypeId", "dbo.BankTransactionTypes");
            DropForeignKey("dbo.BankRates", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Accounts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Accounts", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Accounts", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BankTransactions", new[] { "Operator_Id" });
            DropIndex("dbo.BankTransactions", new[] { "ReceiverId" });
            DropIndex("dbo.BankTransactions", new[] { "SenderId" });
            DropIndex("dbo.StandartRules", new[] { "TransactionActionId" });
            DropIndex("dbo.StandartRules", new[] { "SenderAccountTypeId" });
            DropIndex("dbo.StandartRates", new[] { "ReceiverAccountTypeId" });
            DropIndex("dbo.StandartRates", new[] { "StandartRuleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.BankRates", new[] { "TransactionActionId" });
            DropIndex("dbo.BankRates", new[] { "BankTransactionTypeId" });
            DropIndex("dbo.BankRates", new[] { "BankId" });
            DropIndex("dbo.Accounts", new[] { "CustomerId" });
            DropIndex("dbo.Accounts", new[] { "AccountTypeId" });
            DropIndex("dbo.Accounts", new[] { "BankId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BankTransactions");
            DropTable("dbo.StandartRules");
            DropTable("dbo.StandartRates");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TransactionActions");
            DropTable("dbo.BankTransactionTypes");
            DropTable("dbo.BankRates");
            DropTable("dbo.Customers");
            DropTable("dbo.Banks");
            DropTable("dbo.AccountTypes");
            DropTable("dbo.Accounts");
        }
    }
}
