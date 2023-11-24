using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Dto.Message
{
    public class AddMessageDto
    {
        public DateTime SendDate { get; set; }
        public int Client { get; set; }
        public int Host { get; set; }
        public string MessageContent { get; set; }
    }
}