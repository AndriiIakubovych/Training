using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using MiniChat.Models;

namespace MiniChat.Hubs
{
    public class ChatHub : Hub
    {
        private static List<User> usersList = new List<User>();
        private static List<Message> messagesList = new List<Message>();

        public void Connect(string userName)
        {
            string userId = Context.ConnectionId;
            if (!usersList.Any(u => u.UserId == userId))
            {
                usersList.Add(new User { UserId = userId, UserName = userName, MessagesList = new List<Message>() });
                Clients.Caller.onConnected(userId, userName, usersList, messagesList);
                Clients.AllExcept(userId).onNewUserConnected(userId, userName);
            }
        }

        public void Send(string userId, string userName, string text)
        {
            int usersMessagesMaxCount = 10, allMessagesMaxCount = 20;
            int messageId = messagesList.Count() > 0 ? messagesList.Select(m => m.MessageId).Max() + 1 : 1;
            User user = usersList.Where(u => u.UserId == userId).Single();
            DateTime date = DateTime.Now;
            Message message = new Message { MessageId = messageId, User = user, Date = date, Text = text };
            messagesList.Add(message);
            if (messagesList.Count > allMessagesMaxCount)
                messagesList.RemoveAt(0);
            user.MessagesList.Add(new Message { MessageId = messageId, Date = date, Text = text });
            if (user.MessagesList.Count > usersMessagesMaxCount)
                user.MessagesList.RemoveAt(0);
            Clients.All.showAllMessages(userId, messagesList);
        }

        public void FilterByUserId(string userId)
        {
            Clients.Caller.filterMessages(usersList.Where(u => u.UserId == userId).Single());
        }

        public void FilterByMessageId(int messageId)
        {
            string userId = messagesList.Where(m => m.MessageId == messageId).Single().User.UserId;
            Clients.Caller.filterMessages(usersList.Where(u => u.UserId == userId).Single());
        }

        public void RemoveFilter(string sortType, string sortOrder)
        {
            Sort(sortType, sortOrder);
        }

        public void Sort(string sortType, string sortOrder)
        {
            List<Message> newMessagesList = new List<Message>();
            for (int i = 0; i < messagesList.Count; i++)
                newMessagesList.Add(messagesList[i]);
            if (sortOrder == "По возрастанию")
            {
                if (sortType == "По идентификатору")
                    newMessagesList = newMessagesList.OrderBy(m => m.MessageId).ToList();
                else
                    newMessagesList = newMessagesList.OrderBy(m => m.Date).ToList();
            }
            else
            {
                if (sortType == "По идентификатору")
                    newMessagesList = newMessagesList.OrderByDescending(m => m.MessageId).ToList();
                else
                    newMessagesList = newMessagesList.OrderByDescending(m => m.Date).ToList();
            }
            Clients.Caller.showAllMessages(null, newMessagesList);
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            User user = usersList.FirstOrDefault(u => u.UserId == Context.ConnectionId);
            string userId;
            if (user != null)
            {
                usersList.Remove(user);
                userId = Context.ConnectionId;
                Clients.All.onUserDisconnected(userId);
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}