using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Dto.Message
{
    public class GetMessageList
    {
        public int Id { get; set; }

        public DateTime SendDate { get; set; }

        public int SenderUserId { get; set; } // Mesajı gönderen kullanıcının Id'si

        public int ReceiverUserId { get; set; } // Mesajı alan kullanıcının Id'si

        public string MessageContent { get; set; }
    }
}