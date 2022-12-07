using System;
using System.Collections.Generic;

namespace chatapp_server.Models
{
    public partial class Invitation
    {
        public Guid InvitationId { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid IsInvitedUserId { get; set; }
        public string? Status { get; set; }

        public virtual ChatUser CreatedByNavigation { get; set; } = null!;
        public virtual ChatUser IsInvitedUser { get; set; } = null!;
    }
}
