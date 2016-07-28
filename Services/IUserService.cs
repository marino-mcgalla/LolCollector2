using SkinApp.Models;
using System.Collections.Generic;

namespace SkinApp.Services
{
    public interface IUserService
    {
        ApplicationUser GetUser(string id);
        void SaveSkin(string id, string[] skins);
        List<ApplicationUser> GetAllUsers();
        void DeleteUser(string id);
        void AdminDeletePost(int id);
        void RemoveSkin(int id);
    }
}