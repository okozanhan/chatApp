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
        // alıcı
        public int Client { get; set; }
        // verici
        public int Host { get; set; }
        // içerik
        public string MessageContent { get; set; }


        public User UserFk { get; set; }
        public int UserId { get; set; }

        public bool IsDeleted { get; set; }

    }
}
