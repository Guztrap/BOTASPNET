using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;

namespace BotsAspNet.Dialogs
{
    [Serializable]
    public class MyDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activityMessage = await result as Activity;
            var message = activityMessage.Text;

            if (message.Contains("Assortment"))
            {
                await context.PostAsync("It´s an application designed for Ann Inc in order to create the season plan");
            }
            else
            {
                await context.PostAsync($"Recibiste: {message}");
            }
            
            context.Wait(MessageReceivedAsync);
        }
    }
}