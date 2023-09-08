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

        public ChatViewModel fetchMessageDetailsForUser(string userId);

        public ChatViewModel fetchMessageDetailsForInductionUser(string userId);

        public bool SaveCommentsForUsers(string sendToUser, string messageTxt);

        public bool SaveCommnetsForInductionUsers(string sendToUserId, string messageText);
    }
}
