using JonHuss_CaaS.Embed.Helpers;
using JonHuss_CaaS.Embed.Models.Home;
using Microsoft.Bot.Connector.DirectLine;
using Microsoft.Bot.Connector.DirectLine.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JonHuss_CaaS.Embed.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string userId, string conversationTemplateId, string style = "WebChat")
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(conversationTemplateId))
                return null;

            DirectLineClient client = new DirectLineClient(ConfigurationManager.AppSettings["DirectLineSecret"]);
            Conversation conversation = client.Conversations.NewConversation();
            
            Session["Conversation"] = conversation;
            Session["UserId"] = userId;
            Session["ConversationTemplateId"] = conversationTemplateId;

            HomeViewModel model = new HomeViewModel();
            model.Style = style;

            return View(model);
        }

        public async Task<JsonResult> StartConversation()
        {
            string content = Session["UserId"] + ":" + Session["ConversationTemplateId"];
            return await SendMessage(content);
        }

        public async Task<JsonResult> SendMessage(string messageText)
        {
            Conversation conversation = (Conversation)Session["Conversation"];

            DirectLineClient client = new DirectLineClient(ConfigurationManager.AppSettings["DirectLineSecret"]);
            Message message = new Message();
            message.Text = messageText;
            message.ConversationId = conversation.ConversationId;
            message.FromProperty = Session["From"] as string;
            
            client.Conversations.PostMessage(conversation.ConversationId, message);
            

            MessageSet messages = client.Conversations.GetMessages(conversation.ConversationId);

            if (Session["From"] == null)
                Session["From"] = messages.Messages.First().FromProperty;

            return Json(messages.Messages.OrderBy(m => m.Created).Last(m => m.FromProperty == "JonHuss-CaaS").Text, JsonRequestBehavior.AllowGet);

        }

        private string GetContent(string message)
        {
            dynamic content = new ExpandoObject();
            content.conversationId = Session["ConversationId"];
            content.text = message;

            content.from = Session["From"];
            content.to = null;

            return JsonConvert.SerializeObject(content);
        }
    }
}