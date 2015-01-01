using System.Data.Entity;

namespace WeddingInvites.Models
{
    public class Invite
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        // Bride or Grooms
        public string Party { get; set; }

        // enum for this?
        // type of invitee: 
        // guest, groomsmen, bridesmaid, etc.
        public string Type { get; set; }

        // How many invitees are invited
        public int Invitees { get; set; }

        // Keeping track of sent/unsent
        public bool InviteSent { get; set; }
        public bool Confirmed { get; set; }

        // How many actually coming
        public int Attending { get; set; }
    }

    public class InviteDBContext : DbContext
    {
        public DbSet<Invite> Invites { get; set; }
    }
}