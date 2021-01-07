using ChatApplication.Models.Model;
using ChatApplication.Repository.Base;
using ChatApplication.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApplication.Repository
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
    }
}
