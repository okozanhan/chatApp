using AppCore;
using Dal.Entity;
using System;

namespace Dal
{
    public class Message : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public DateTime SendDate { get; set; }
        public int Client { get; set; }
        public int Host { get; set; }
        public string MessageContent { get; set; }


        public User UserFk { get; set; }
        public int UserId { get; set; }

        public bool IsDeleted { get; set; }

    }
}
