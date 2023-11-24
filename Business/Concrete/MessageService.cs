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

        public async Task<List<GetMessageList>> GetMessageLists(int clientId, int hostId)
        {
            var message = await _dbContext.Messages.Where(p => !p.IsDeleted && p.Client == clientId && p.Host == hostId).Select(
                p => new GetMessageList
                {
                    Id = p.Id,
                    Client = p.Client,
                    Host = p.Host,
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
                Client = sendMessage.Client,
                Host = sendMessage.Host,
                MessageContent = sendMessage.MessageContent,
                SendDate = DateTime.Now
            };

            _dbContext.Messages.AddAsync(newMessage);
            return _dbContext.SaveChangesAsync();

        }

    }
}