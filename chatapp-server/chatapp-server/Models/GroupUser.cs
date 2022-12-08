using System;
using System.Collections.Generic;

namespace chatapp_server.Models
{
    public partial class GroupUser
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
        public string? IsApproved { get; set; }

        public virtual ChatGroup Group { get; set; } = null!;
        public virtual ChatUser User { get; set; } = null!;
    }
}
