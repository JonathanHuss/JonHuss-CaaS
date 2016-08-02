using JonHuss_CaaS.DataModel;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
//using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace JonHuss_CaaS.Bot.Dialogs
{
    [Serializable]
    public class MasterDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait<IMessageActivity>(StartConversation);
        }

        public async Task StartConversation(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            Activity activity = (await argument) as Activity;

            string[] idParts = activity.Text.Split(':');

            string userId = idParts[0];
            Guid conversationId = Guid.Parse(idParts[1]);
            
            CaaSDataModel db = new CaaSDataModel();

            ConversationTemplate template = db.ConversationTemplates.First(c => c.UserId == userId && c.ConversationWebID == conversationId);
            
            Step startingStep = template.Steps.First(s => s.StartingStep == true);

            context.PrivateConversationData.SetValue("CurrentStepID", startingStep.ID);
            context.PrivateConversationData.SetValue("Properties", new Dictionary<string, string>());

            await startingStep.Execute(context);
        }
    }
}