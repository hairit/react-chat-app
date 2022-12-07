using System;
using System.Collections.Generic;

namespace chatapp_server.Models
{
    public partial class ChatMessage
    {
        public Guid MessageId { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? GroupId { get; set; }
        public string Content { get; set; } = null!;

        public virtual ChatUser? CreatedByNavigation { get; set; }
        public virtual ChatGroup? Group { get; set; }
    }
}
