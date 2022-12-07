using System;
using System.Collections.Generic;

namespace chatapp_server.Models
{
    public partial class ChatGroup
    {
        public ChatGroup()
        {
            ChatMessages = new HashSet<ChatMessage>();
            Users = new HashSet<ChatUser>();
        }

        public Guid GroupId { get; set; }
        public string? GroupName { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ChatUser CreatedByNavigation { get; set; } = null!;
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }

        public virtual ICollection<ChatUser> Users { get; set; }
    }
}
