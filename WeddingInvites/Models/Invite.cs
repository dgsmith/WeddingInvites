using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WeddingInvites.Models
{
    public class Invite
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
        public string City { get; set; }

        [StringLength(2), MinLength(2)]
        public string State { get; set; }

        [StringLength(5), MinLength(5)]
        public string Zip { get; set; }

        // Bride or Grooms
        [Required]
        public string Party { get; set; }

        // enum for this?
        // type of invitee: 
        // guest, groomsmen, bridesmaid, etc.
        [Required]
        public string Type { get; set; }

        // How many invitees are invited
        public int? Invitees { get; set; }

        // Keeping track of sent/unsent
        [Display(Name = "Invite Sent?")]
        public bool InviteSent { get; set; }

        [Display(Name = "RSVP Recieved?")]
        public bool Confirmed { get; set; }

        // How many people invited are actually coming
        [Display(Name = "Confirmed Attending")]
        public int? AttendingCount { get; set; }
        
        public string Notes { get; set; }
    }

    public class InviteDBContext : DbContext
    {
        public DbSet<Invite> Invites { get; set; }
    }
}