using ChatApplication.Manager.Base;
using ChatApplication.Manager.Contract;
using ChatApplication.Models.Model;
using ChatApplication.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApplication.Manager
{
    public class MessageManager : BaseManager<Message>, IMessageManager 
    {
        private readonly IMessageRepository _messageRepository;

        public MessageManager(IMessageRepository messageRepository) : base(messageRepository)
        {
            _messageRepository = messageRepository;
        }
    }
}
