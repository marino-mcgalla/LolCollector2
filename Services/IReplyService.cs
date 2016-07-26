using LolApp.Models;

namespace SkinApp.Services
{
    public interface IReplyService
    {
        void SaveReply(int id, Reply reply);
        
    }
}