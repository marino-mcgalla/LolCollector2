using LolApp.Models;
using SkinApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SkinApp.Services
{
    public class ReplyService : IReplyService
    {
        private object replyToEdit;
        private IGenericRepository _repo;

        public ReplyService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public void SaveReply(int id, Reply reply)
        {
            if (reply.Id == 0)
            {
                var forum = _repo.Query<ForumPost>().Include(p => p.Replies).FirstOrDefault(p => p.Id == id);
                forum.Replies.Add(reply);
                _repo.SaveChanges();
            }
            else
            {
                var replyToEdit = _repo.Query<Reply>().FirstOrDefault(p => p.Id == reply.Id);
                replyToEdit.Message = reply.Message;
                _repo.SaveChanges();
            }
        }

    }
}
