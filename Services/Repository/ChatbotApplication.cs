using dataModels.dbContext;
using dataModels.Entities;
using dataModels.ViewModels;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class ChatbotApplication : IChatbotApplication
    {
        private readonly ChatDbContext _db;
        public ChatbotApplication(ChatDbContext db) 
        { 
            _db = db;
        }
        public static byte[] HexStringToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        
        public List<Inductionuser> getInductionUserList()
        {
            List<Inductionuser> inductionusers = _db.Inductionusers.ToList();
            return inductionusers;
        }

        public List<User> getUserLIst()
        {
            List<User> users = _db.Users.ToList();
            return users;
        }
        
        public ChatViewModel fetchMessageDetailsForUser(string userId)
        {
            
            byte[] byteArray = HexStringToByteArray(userId.Replace("-", ""));            

            var firstuserBytes = _db.Users.First();
            byte[] FirstUserGuidBytes = firstuserBytes.UserGuid;
            string userGuidString = BitConverter.ToString(FirstUserGuidBytes);

            var userInfo = _db.Users.Where(user => user.UserGuid == byteArray).First();
            ChatViewModel viewModel = new ChatViewModel();
            viewModel.FirstName = userInfo.FirstName;
            viewModel.LastName = userInfo.LastName;
            viewModel.PhoneNumber = userInfo.PhoneNumber;
            viewModel.Userid = userInfo.UserGuid;
            viewModel.StrForFirstUser = userGuidString;
            viewModel.commonUserModels = _db.Smsmsgtousers
            .Where(user => (user.UserId == FirstUserGuidBytes && user.CreatorId == userInfo.UserGuid) || (user.UserId == userInfo.UserGuid && user.CreatorId == FirstUserGuidBytes))
            .OrderBy(user => user.CreationTime)
            .Select(user => new ChatViewModel.CommonUserModel
            {
                //Id = user.Id,
                UserId = user.UserId,
                Sms = user.Sms,
                IsDelete = user.IsDelete,
                CreatorId = user.CreatorId,
                ModificationId = user.ModificationId,
                DeletorId = user.DeletorId,
                ModificationTime = user.ModificationTime,
                CreationTime = user.CreationTime
            })
            .ToList();
            return viewModel;
        }

        public ChatViewModel fetchMessageDetailsForInductionUser(string userId)
        {
            byte[] byteArray = HexStringToByteArray(userId.Replace("-", ""));

            var firstuserBytes = _db.Users.First();
            byte[] FirstUserGuidBytes = firstuserBytes.UserGuid;
            string userGuidString = BitConverter.ToString(FirstUserGuidBytes);

            var userInfo = _db.Inductionusers.Where(user => user.InductionuserGuid == byteArray).First();
            ChatViewModel viewModel = new ChatViewModel();
            viewModel.FirstName = userInfo.FirstName;
            viewModel.LastName = userInfo.LastName;
            viewModel.PhoneNumber = userInfo.PhoneNumber;
            viewModel.Userid = userInfo.InductionuserGuid;
            viewModel.StrForFirstUser = userGuidString;
            viewModel.commonUserModels = _db.Smsmsgtoinductionusers
            .Where(user => (user.InductionUserId == userInfo.InductionuserGuid) && (user.CreatorId == FirstUserGuidBytes))
            .OrderBy(user => user.CreationTime)
            .Select(user => new ChatViewModel.CommonUserModel
            {
                //Id = user.Id,
                UserId = user.InductionUserId,
                Sms = user.Sms,
                IsDelete = user.IsDelete,
                CreatorId = FirstUserGuidBytes,
                ModificationId = user.ModificationId,
                DeletorId = user.DeletorId,
                ModificationTime = user.ModificationTime,
                CreationTime = user.CreationTime
            })
            .ToList();
            return viewModel;
        }

        public bool SaveCommentsForUsers(string sendToUser, string messageTxt)
        {
            byte[] byteArray = HexStringToByteArray(sendToUser.Replace("-", ""));

            var userInfo = _db.Users.Where(user => user.UserGuid == byteArray).FirstOrDefault();


            var firstuserBytes = _db.Users.First();
            byte[] FirstUserGuidBytes = firstuserBytes.UserGuid;
            

            if (userInfo != null)
            {
                var addCommentForUser = new Smsmsgtouser();
                addCommentForUser.UserId = userInfo.UserGuid;
                addCommentForUser.Sms = messageTxt;
                addCommentForUser.CreatorId = FirstUserGuidBytes;
                _db.Smsmsgtousers.Add(addCommentForUser);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveCommnetsForInductionUsers(string sendToUserId, string messageText)
        {
            byte[] byteArray = HexStringToByteArray(sendToUserId.Replace("-", ""));

            var inductionUserInfo = _db.Inductionusers.Where(iuser => iuser.InductionuserGuid == byteArray).FirstOrDefault();

            var firstuserBytes = _db.Users.First();
            byte[] FirstUserGuidBytes = firstuserBytes.UserGuid;

            if (inductionUserInfo != null)
            {
                var addCommentForInductionUser = new Smsmsgtoinductionuser();
                addCommentForInductionUser.InductionUserId = inductionUserInfo.InductionuserGuid;
                addCommentForInductionUser.Sms = messageText;
                addCommentForInductionUser.CreatorId = FirstUserGuidBytes;
                _db.Smsmsgtoinductionusers.Add(addCommentForInductionUser);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
