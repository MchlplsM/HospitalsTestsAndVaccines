namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Phone], [Amka], [DateOfBirth], [HealthIssues], [Address], [City], [PostalCode], [State], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4e4d08da-550e-4b24-b8f8-484026108108', N'haris', N'Arapakis', N'+306979607117', N'1456', N'1/13/1996 12:00:00 AM', N'none', N'anoixews 42', N'athens', N'14564', N'attiki', N'harisarapakis-4@hotmail.com', 0, N'AHNw5qRZytErbYZQHaFgwHjupgYWG1jZyb54AwYJdXRhlnnzGen30WwbRZitqhl4kg==', N'23b6b1ae-12e6-465c-82cf-796c0089ddf7', NULL, 0, 0, NULL, 1, 0, N'harisarapakis-4@hotmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Phone], [Amka], [DateOfBirth], [HealthIssues], [Address], [City], [PostalCode], [State], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6f4e22f9-4272-4a1b-9f8c-cde3b531454c', N'haris', N'Arapakis', N'+306979607117', N'21', N'1994-12-02', N'none', N'anoixews 42', N'athens', N'14564', N'peristeri', N'Guest@guest.com', 1, N'AP9B30X8S1+B5EHRldBjf1GV3gnyUpnNeZE+iskvujNif0A84nT9KI5Rn8QIz34//g==', N'0a5a6a14-ee57-4a66-9996-cef67561fd0a', NULL, 0, 0, NULL, 1, 0, N'Guest1@guest.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Phone], [Amka], [DateOfBirth], [HealthIssues], [Address], [City], [PostalCode], [State], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'82b3930a-5b54-4e0b-a380-485c41806db7', N'Kostas', N'Skylos', N'+306979607117', N'21', N'1/25/1994 12:00:00 AM', N'none', N'anoixews 42', N'athens', N'14564', N'attiki', N'Skylos@Skylos.com', 0, N'ANPTlR2sOW96TXNwsj9eu+01xWuOQe4u+gDkMoUCrytOFXIiHen42WRV4/dwqHlsJA==', N'8ce4bade-0546-4b3a-a70b-825b40da1321', NULL, 0, 0, NULL, 1, 0, N'Skylos@Skylos.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Devs')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3', N'Patient')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4e4d08da-550e-4b24-b8f8-484026108108', N'1')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6f4e22f9-4272-4a1b-9f8c-cde3b531454c', N'3')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'82b3930a-5b54-4e0b-a380-485c41806db7', N'3')

");
        }
        
        public override void Down()
        {
        }
    }
}
