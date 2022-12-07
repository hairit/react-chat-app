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
            InvitationCreatedByNavigations = new HashSet<Invitation>();
            InvitationIsInvitedUsers = new HashSet<Invitation>();
            Groups = new HashSet<ChatGroup>();
        }

        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<ChatGroup> ChatGroups { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
        public virtual ICollection<Invitation> InvitationCreatedByNavigations { get; set; }
        public virtual ICollection<Invitation> InvitationIsInvitedUsers { get; set; }

        public virtual ICollection<ChatGroup> Groups { get; set; }
    }
}
