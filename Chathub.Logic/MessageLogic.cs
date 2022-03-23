using Chathub.Models;
using Chathub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chathub.Logic
{
    public class MessageLogic : IMessageLogic
    {
        IRepository<Message> repo;

        public MessageLogic(IRepository<Message> repo)
        {
            this.repo = repo;
        }

        public void Create(Message msg)
        {
            repo.Create(msg);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Message Get(int id)
        {
            return repo.Get(id);
        }

        public IQueryable<Message> GetAll()
        {
            return repo.GetAll();
        }

        public void Update(Message msg)
        {
            repo.Update(msg);
        }
    }
}
