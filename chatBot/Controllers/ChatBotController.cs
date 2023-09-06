using dataModels.dbContext;
using dataModels.Entities;
using dataModels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace chatBot.Controllers
{
    public class ChatBotController : Controller
    {
        private readonly ChatDbContext _db;
        public ChatBotController(ChatDbContext db)
        {
            _db = db;
        }
        public IActionResult chatBot()
        {
            return View();
        }
        public IActionResult userLIst()
        {
            var userList = _db.Users.ToList();
            return PartialView("userList", userList);

        }public IActionResult InductionUser()
        {
            var inductionusers = _db.Inductionusers.ToList();
            return PartialView("InductionUser", inductionusers);

        }
        public IActionResult chatView(int userId)
        {
            var userInfo = _db.Users.Where(user=>user.Userid == userId).First();
                ChatViewModel viewModel = new ChatViewModel();
                viewModel.FirstName = userInfo.FirstName;
                viewModel.LastName = userInfo.LastName;
                viewModel.PhoneNumber = userInfo.PhoneNumber;
                viewModel.Userid = userInfo.Userid;
                viewModel.commonUserModels = _db.Smsmsgtousers
                .Where(user => (user.UserId == 1 && user.CreatorId == userInfo.Userid) || (user.UserId == userInfo.Userid && user.CreatorId == 1))
                .OrderBy(user => user.CreationTime)
                .Select(user => new ChatViewModel.CommonUserModel
                {
                    Id = user.Id,
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
                return PartialView("chatView", viewModel);
        }
        public IActionResult chatViewForInductionUser(int userId)
        {
            var userInfo = _db.Inductionusers.Where(user => user.Inductionuserid == userId).First();
            ChatViewModel viewModel = new ChatViewModel();
            viewModel.FirstName = userInfo.FirstName;
            viewModel.LastName = userInfo.LastName;
            viewModel.PhoneNumber = userInfo.PhoneNumber;
            viewModel.Userid = userInfo.Inductionuserid;
            viewModel.commonUserModels = _db.Smsmsgtoinductionusers
            .Where(user => (user.InductionUserId == userInfo.Inductionuserid) && (user.CreatorId == 1))
            .OrderBy(user => user.CreationTime)
            .Select(user => new ChatViewModel.CommonUserModel
            {
                Id = user.Id,
                UserId = user.InductionUserId,
                Sms = user.Sms,
                IsDelete = user.IsDelete,
                CreatorId = 1,
                ModificationId = user.ModificationId,
                DeletorId = user.DeletorId,
                ModificationTime = user.ModificationTime,
                CreationTime = user.CreationTime
            })
            .ToList();
            return PartialView("chatViewForInductionUser", viewModel);
        }


        [HttpPost]
        public bool SaveComments(int sendToUser, string messageTxt)
        {
            var userInfo = _db.Users.Where(user => user.Userid == sendToUser).FirstOrDefault();
            if (userInfo != null)
            {
                var addCommentForUser = new Smsmsgtouser();
                addCommentForUser.UserId = userInfo.Userid;
                addCommentForUser.Sms = messageTxt;
                addCommentForUser.CreatorId = 1;
                _db.Smsmsgtousers.Add(addCommentForUser);
                _db.SaveChanges();
                return true;
            }
            else 
            { 
                return false; 
            }  
            
        }

        [HttpPost]
        public bool SaveCommnetsForInductionUser(int sendToUserId, string messageText)
        {
            var inductionUserInfo = _db.Inductionusers.Where(iuser => iuser.Inductionuserid == sendToUserId).FirstOrDefault();
            if (inductionUserInfo != null)
            {
                var addCommentForInductionUser = new Smsmsgtoinductionuser();
                addCommentForInductionUser.InductionUserId = inductionUserInfo.Inductionuserid;
                addCommentForInductionUser.Sms = messageText;
                addCommentForInductionUser.CreatorId = 1;
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
