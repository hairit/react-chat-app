using System;
using System.Collections.Generic;

namespace chatapp_server.Models
{
    public partial class ChatUser
    {
        public ChatUser()
        {
            ChatGroups = new HashSet<ChatGroup>();
            ChatMessages = new HashSet<ChatMessage>();
            GroupUsers = new HashSet<GroupUser>();
        }

        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<ChatGroup> ChatGroups { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
        public virtual ICollection<GroupUser> GroupUsers { get; set; }
    }
}
