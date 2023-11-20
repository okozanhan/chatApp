using AppCore;
using System;
using System.Collections.Generic;

namespace Dal.Entity
{
    public class User : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string  UserName { get; set; }
        public string  Password { get; set; }

        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastSee { get; set; }
        public bool IsOnline { get; set; }



        public ICollection<Message> Messages { get; set; }

        public bool IsDeleted { get; set; }
    }
}
