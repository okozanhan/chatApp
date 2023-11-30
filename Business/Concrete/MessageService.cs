using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Dal;
using Dal.Context;
using Dal.Dto.Message;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly ChatDbContext _dbContext;

        public MessageService(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetMessageList>> GetMessageLists(int SenderUserId, int ReceiverUserId)
        {
            var message = await _dbContext.Messages.Where(p => !p.IsDeleted && p.SenderUserId == SenderUserId && p.ReceiverUserId == ReceiverUserId).Select(
                p => new GetMessageList
                {
                    Id = p.Id,
                    SenderUserId = p.SenderUserId,
                    ReceiverUserId = p.ReceiverUserId,
                    MessageContent = p.MessageContent,
                    SendDate = p.SendDate
                }
            ).ToListAsync();

            return message;
        }

        public Task<int> SendMessage(AddMessageDto sendMessage)
        {
            var newMessage = new Message
            {
                SenderUserId = sendMessage.SenderUserId,
                ReceiverUserId = sendMessage.ReceiverUserId,
                MessageContent = sendMessage.MessageContent,
                SendDate = DateTime.Now
            };

            _dbContext.Messages.AddAsync(newMessage);
            return _dbContext.SaveChangesAsync();

        }

    }
}