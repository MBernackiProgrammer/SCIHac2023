using Hackathon.dbContext;
using Hackathon.dbContext.chat;
using Microsoft.AspNetCore.SignalR;
using System.Data;

namespace AuthServices.Helpers.SharedSessions.MyDay.MyReminder
{
    public class Sessions_Chat : Hub
    {
        public async Task JoinChatSession(Int64 ChatID)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, ChatID.ToString());
        }

        public async Task LeaveChatSession(Int64 ChatID)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, ChatID.ToString());
        }

        public async Task SendMessageToGroup(string message, Int64 ByUserID, Int64 ToChatID, Int64 AnwserTo)
        {
            using(var dbContext = new Data_context())
            {
                var NewEntity = new chat_messages
                {
                    by_id = ByUserID,
                    to_chat_id = ToChatID,
                    value = message,
                    answer_to_id = AnwserTo
                };

                dbContext.chat_messages.Add(NewEntity);
                dbContext.SaveChanges();
                await Clients.Group(ToChatID.ToString()).SendAsync("ReceiveMessage", message, ByUserID, NewEntity.id, AnwserTo);
            }
        }
    }
}
