using Chathub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chathub.Logic
{
    public interface IMessageLogic
    {
        void Create(Message msg);
        void Delete(int id);
        Message Get(int id);
        IQueryable<Message> GetAll();
        void Update(Message msg);
    }
}
