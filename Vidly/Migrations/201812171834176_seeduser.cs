namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seeduser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'81822dac-3074-452c-a6a2-6a9cc1844ace', N'admin@vidly.com', 0, N'AMqCr2yRqYBw6RM8j5m94pMRlQNOn/RUUtOvWFDjmwyMicmvF9i5VBTuWLEiTRlcoA==', N'565595c1-3c92-4a0b-ac84-f72e75e684c5', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bf79c9d7-e5c2-411e-893e-671c0d644270', N'guest@vidly.com', 0, N'AGUTr2/jXZ1iiSEnX+aNy7I+hU6jK0d7KrdTLNOuzCIILaH2N72PeLzFOZbBoyuf3A==', N'a5f2e013-a95b-40b8-8690-1ed15df20b95', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a3c546ea-7398-45ff-a5eb-e707c9821d6d', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'81822dac-3074-452c-a6a2-6a9cc1844ace', N'a3c546ea-7398-45ff-a5eb-e707c9821d6d')
");
        }
        
        public override void Down()
        {

        }
    }
}
