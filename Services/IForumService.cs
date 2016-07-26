using System.Collections.Generic;
using LolApp.Models;
using SkinApp.ViewModels.CustomViewModels;

namespace SkinApp.Services
{
    public interface IForumService
    {
        void DeletePost(int id);
        List<PostVM> GetPosts();
        void SavePost(string id, ForumPost post);
        PostVM GetPost(int id);


    }
}