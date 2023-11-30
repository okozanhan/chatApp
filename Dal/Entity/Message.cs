using AppCore;
using Dal.Entity;
using System;

namespace Dal
{
    public class Message : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        //gönderilme tarihi
        public DateTime SendDate { get; set; }

        // içerik
        public string MessageContent { get; set; }

        public int SenderUserId { get; set; } // Mesajı gönderen kullanıcının Id'si
        public User SenderUser { get; set; } // Mesajı gönderen kullanıcı

        public int ReceiverUserId { get; set; } // Mesajı alan kullanıcının Id'si
        public User ReceiverUser { get; set; } // Mesajı alan kullanıcı

        public bool IsDeleted { get; set; }

    }
}
