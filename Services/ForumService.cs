using LolApp.Models;
using Microsoft.EntityFrameworkCore;
using SkinApp.Models;
using SkinApp.Repositories;
using SkinApp.ViewModels.CustomViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinApp.Services
{
    public class ForumService : IForumService
    {
        private IGenericRepository _repo;

        public ForumService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<PostVM> GetPosts()
        {
            var posts = _repo.Query<ForumPost>().Select(p => new PostVM {
                Id = p.Id,
                Body = p.Body,
                Category = p.Category,
                AuthorName = p.Author.UserName,
                Topic = p.Topic,
                Replies = p.Replies,
                TimeCreated = p.TimeCreated.ToLocalTime(),
                Votes = p.Votes,
                Views = p.Views,
                CommentCount = p.Replies.Count()
                
            }).ToList();
            return posts;
        }

        public PostVM GetPost(int id)
        {
            var post = _repo.Query<ForumPost>().FirstOrDefault(p => p.Id == id);
            post.Views++;
            _repo.SaveChanges();

            var postVM = _repo.Query<ForumPost>().Where(p => p.Id == id).Include(p => p.Author).Select(p => new PostVM {
                Id = p.Id,
                Body = p.Body,
                Category = p.Category,
                AuthorName = p.Author.UserName,
                Topic = p.Topic,
                Replies = p.Replies,
                TimeCreated = p.TimeCreated.ToLocalTime(),
                Votes = p.Votes,
                Views = p.Views,
                CommentCount = p.Replies.Count()

            }).FirstOrDefault();
            
            return postVM;
            
        }

        public void SavePost(string id, ForumPost post)
        {
            if (post.Id == 0)
            {
                post.TimeCreated = DateTime.UtcNow;
                post.Author = _repo.Query<ApplicationUser>().Where(u => u.Id == id).FirstOrDefault();
                _repo.Add(post);
            }
            else
            {
                var postToEdit = _repo.Query<ForumPost>().FirstOrDefault(p => p.Id == post.Id);
                postToEdit.Topic = post.Topic;
                postToEdit.Body = post.Body;
                postToEdit.Category = post.Category;
                postToEdit.Votes = post.Votes;
                postToEdit.Views = post.Views;
                _repo.SaveChanges();
            }
        }

        public void DeletePost(int id)
        {
            var postToDelete = _repo.Query<ForumPost>().Where(m => m.Id == id).Include(m => m.Replies).FirstOrDefault();
            
            _repo.Delete(postToDelete);
        }
    }
}
