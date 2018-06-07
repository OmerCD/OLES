using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using OLES.Classes.Database;
using OLESClass;

namespace OLES.Classes
{
    public class ChatHub : Hub
    {
        public void Send(string connId)
        {
            // Call the broadcastMessage method to update clients.
           var client =  Clients.Group(connId);
            
            var identityName = Context.User.Identity.Name;
            if (GlobalVariables.UserIdLobbyNameDictionary.ContainsKey(identityName) == true)
            {
                Clients.User(identityName).broadcastMessage("You are already in Lobby");
            }
            else
            {
                client.broadcastMessage(DbFactory.UserCRUD.GetOne(identityName).UserName);
                GlobalVariables.UserIdLobbyNameDictionary.Add(identityName, connId);
            }
                
        }
        public void SendToClientsInLobby(string lobbyName)
        {
            // Call the broadcastMessage method to update clients.
            foreach(var pair in GlobalVariables.UserIdLobbyNameDictionary)
            {
                if (pair.Value == lobbyName)
                {
                    GlobalVariables.CurrentLobby.AssignGlobalQuestionVariable();
                    Clients.User(pair.Key).broadcastMessage(1);
                }
            }

        }
        public void Mahmut(string name, string message, string _id) //todo chat.server.mahmut($('#displayname').val(), $('#message').val());
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
        public override Task OnConnected()
        {
            var currentUser = DbFactory.UserCRUD.GetOne(HttpContext.Current.User.Identity.Name);
            switch (currentUser)
            {
                case Teacher _:
                    Groups.Add(Context.ConnectionId, "123456"); break;
            }

            return base.OnConnected();
        }
    }
}
