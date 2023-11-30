using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Dal;
using Dal.Dto.Message;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet("GetMessageList/{SenderUserId}/{ReceiverUserId}")]
        public async Task<ActionResult<List<GetUserDto>>> GetMessageList(int SenderUserId, int ReceiverUserId)
        {
            try
            {
                var message = await _messageService.GetMessageLists(SenderUserId, ReceiverUserId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SendMessage")]
        public async Task<ActionResult<string>> SendMessage(AddMessageDto sendMessage)
        {
            var list = new List<string>();
            try
            {
                var result = await _messageService.SendMessage(sendMessage);
                if(result > 0){
                    list.Add("Ekleme işlemi başarılı");
                    return Ok(list);
                }
                list.Add("Ekleme işlemi başarısız");
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}