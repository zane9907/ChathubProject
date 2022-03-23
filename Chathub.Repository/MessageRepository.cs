using Chathub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chathub.Repository
{
    public class MessageRepository : Repository<Message>, IRepository<Message>
    {
        public MessageRepository(MessageDBContext ctx) : base(ctx)
        {
        }

        public override Message Get(int id)
        {
            return ctx.Messages.FirstOrDefault(x=>x.MessageID == id);
        }

        public override void Update(Message entity)
        {
            var old = Get(entity.MessageID);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");

            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(x=>x.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(entity));
                }
            }
            ctx.SaveChanges();
        }
    }
}
