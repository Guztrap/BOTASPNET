using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotsAspNet.Controllers
{ 
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        public async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new Dialogs.MyDialog());
            }
            else
            {
                HandleSystemMessage(activity);
            }

            return Request.CreateResponse(HttpStatusCode.OK);            
        }

        private void HandleSystemMessage(Activity message)
        {
            switch (message.Type)
            {
                case ActivityTypes.ConversationUpdate: //Indica que el bot fue agregado a la conversacion u otros miembros se agregaron o quitaron
                    break;
                case ActivityTypes.ContactRelationUpdate: //Bot fue agregado o eliminado de la lista de contactos
                    break;
                case ActivityTypes.Typing: //indica que el opuesto esta escribiendo
                    break;
                case ActivityTypes.Ping: // Checa si el endpoint esta accesible
                    break;
                case ActivityTypes.DeleteUserData: //el usuario pidio que se eliminara toda la informacion almacenada.
                    break;
            }
        }
    }
}
