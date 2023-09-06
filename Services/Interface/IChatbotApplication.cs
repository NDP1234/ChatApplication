using dataModels.Entities;
using dataModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IChatbotApplication
    {
        public List<User> getUserLIst();
        public List<Inductionuser> getInductionUserList();
    
        public ChatViewModel fetchMessageDetailsForUser(int userId);

        public ChatViewModel fetchMessageDetailsForInductionUser(int userId);

        public bool SaveCommentsForUsers(int sendToUser, string messageTxt);
        public bool SaveCommnetsForInductionUsers(int sendToUserId, string messageText);
    }
}
