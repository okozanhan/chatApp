using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Dto.Message;

namespace Business.Abstract
{
    public interface IMessageService
    {
        Task<int> SendMessage(AddMessageDto sendMessage);
        Task<List<GetMessageList>> GetMessageLists(int clientId, int hostId);
    }
}