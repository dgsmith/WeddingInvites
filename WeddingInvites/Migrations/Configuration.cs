namespace WeddingInvites.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WeddingInvites.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WeddingInvites.Models.InviteDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WeddingInvites.Models.InviteDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Invites.AddOrUpdate( i => i.Name,
                new Invite
                {
                    Name = "Ms. Cheryl B. Smith",
                    Party = "Groom",
                    Type = "Guest",
                    Address = "908 E. Lakeside Ave.",
                    City = "Coeur d'Alene",
                    State = "ID",
                    Zip = "83814",
                    Invitees = 2,
                    InviteSent = false,
                    Confirmed = false
                },

                new Invite
                {
                    Name = "Mr. David Smith and Mrs. Cynthia Gott",
                    Party = "Groom",
                    Type = "Guest",
                    Address = "664 A St.",
                    City = "Ashland",
                    State = "OR",
                    Zip = "97520",
                    Invitees = 3,
                    InviteSent = false,
                    Confirmed = false
                },

                new Invite
                {
                    Name = "Mr. and Mrs. James Dickinson",
                    Party = "Bride",
                    Type = "Guest",
                    Address = "2464 E. Nantucket Way",
                    City = "Boise",
                    State = "ID",
                    Zip = "83706",
                    Invitees = 2,
                    InviteSent = false,
                    Confirmed = false
                },

                new Invite
                {
                    Name = "Mr. Tim Michaels",
                    Party = "Groom",
                    Type = "Groomsmen",
                    Address = "123 Fake St.",
                    City = "Los Angeles",
                    State = "CA",
                    Zip = "90089",
                    Invitees = 2,
                    InviteSent = false,
                    Confirmed = false
                },

                new Invite
                {
                    Name = "Ms. Glenna Coffey",
                    Party = "Bride",
                    Type = "Bridesmaid",
                    Address = "456 Double-Fake St.",
                    City = "Portland",
                    State = "OR",
                    Zip = "12345",
                    Invitees = 2,
                    InviteSent = false,
                    Confirmed = false
                }
            );

        }
    }
}
