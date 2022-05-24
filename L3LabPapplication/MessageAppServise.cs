using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3LabPapplication
{
    internal class MessageAppServise : IMessageAppService
    {
        private L3LabMessage _l3LabRepository;
        private MessagesContext _context;

        /*ToDo >> IRepository include*/
        public MessageAppServise(L3LabMessage l3LabRepository)
        {
            this._l3LabRepository = l3LabRepository;
        }
        public void AddMessage(L3LabMessage input)
        {
            
        }

        public void DeleteMessage(int id)
        {
            throw new NotImplementedException();
        }

        public L3LabMessage GetMessageById(int id)
        {
            throw new NotImplementedException();
        }

        public List<L3LabMessage> GetMessages()
        {
            throw new NotImplementedException();
        }

        public L3LabMessage UpdateMessage(L3LabMessage m)
        {
            throw new NotImplementedException();
        }
    }
}
