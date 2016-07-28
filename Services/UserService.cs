using LolApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkinApp.Models;
using SkinApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinApp.Services
{
    public class UserService : IUserService
    {
        private IGenericRepository _repo;
        
        public UserService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public ApplicationUser GetUser(string id)
        {
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).Include(u => u.Skins).FirstOrDefault();
            return user;
        }

        public List<ApplicationUser> GetAllUsers()
        {
            var users = _repo.Query<ApplicationUser>();
            return users.ToList();
        }

        public void SaveSkin(string id, string[] skins)
        {
            var user = _repo.Query<ApplicationUser>().Include(u => u.Skins).FirstOrDefault(u => u.Id == id);
            List<Skin> inputSkins = new List<Skin>();
            foreach (string skin in skins)
            {
                if (!user.Skins.Where(s => s.UrlString == skin).Any())
                {
                    user.Skins.Add(new Skin { UrlString = skin });
                }
            }
            _repo.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            var userToDelete = _repo.Query<ApplicationUser>().Where(u => u.Id == id).Include(u => u.Skins).FirstOrDefault();
            _repo.Delete(userToDelete);
        }

        public void AdminDeletePost(int id) {
            var postToDelete = _repo.Query<ForumPost>().Where(p => p.Id == id).Include(p => p.Replies).FirstOrDefault();
            _repo.Delete(postToDelete);
        }

        public void RemoveSkin(int id)
        {
            var skinToDelete = _repo.Query<Skin>().Where(s => s.Id == id);
            _repo.Delete(skinToDelete);
        }
    }

}
