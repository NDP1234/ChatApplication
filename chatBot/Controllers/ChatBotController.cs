using dataModels.dbContext;
using dataModels.Entities;
using dataModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace chatBot.Controllers
{
    public class ChatBotController : Controller
    {
        private readonly ChatDbContext _db;
        private readonly IChatbotApplication _chatbotApplication;
        public ChatBotController(ChatDbContext db, IChatbotApplication chatbotApplication)
        {
            _db = db;
            _chatbotApplication = chatbotApplication;
        }

        public IActionResult chatBot()
        {
            return View();
        }
        public IActionResult userLIst()
        {
            var userList = _chatbotApplication.getUserLIst();
            return PartialView("userList", userList);
        }
        public IActionResult InductionUser()
        {
            var inductionusers = _chatbotApplication.getInductionUserList();
            return PartialView("InductionUser", inductionusers);
        }
        public IActionResult chatView(string userId)
        {
            var myModel = _chatbotApplication.fetchMessageDetailsForUser(userId);
            return PartialView("chatView", myModel);
        }

        public IActionResult chatViewForInductionUser(string userId)
        {
            var myModel = _chatbotApplication.fetchMessageDetailsForInductionUser(userId);
            return PartialView("chatViewForInductionUser", myModel);
        }


        [HttpPost]
        public bool SaveComments(string sendToUser, string messageTxt)
        {
            var status = _chatbotApplication.SaveCommentsForUsers(sendToUser, messageTxt);
            return status;
        }

        [HttpPost]
        public bool SaveCommnetsForInductionUser(string sendToUserId, string messageText)
        {
            var status = _chatbotApplication.SaveCommnetsForInductionUsers(sendToUserId, messageText);
            return status;
        }
    }
}
