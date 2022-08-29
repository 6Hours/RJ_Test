using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class ChatItem : BaseItem
    {
        public long Id { get; private set; }
        public string ChatName { get; private set; }
        public UserItem Owner { get; private set; }

        public MessageItem LastMessage { get; private set; }

        public System.Action<MessageItem> OnMessageAdded;
        public System.Action<MessageItem> OnMessageDeleted;

        public ChatItem(long id, string name, UserItem owner, MessageItem lastMessage)
        {
            Id = id;
            ChatName = name;
            Owner = owner;

            if(lastMessage != null) AddMessage(lastMessage);
        }

        public void AddMessage(MessageItem message)
        {
            message.OnDelete += OnDelete;

            if (LastMessage != null)
            {
                LastMessage.NextMessage = message;
            }

            LastMessage = message;

            OnMessageAdded?.Invoke(message);
        }

        public void AddMessage(string content, UserItem author)
        {
            var msg = new MessageItem(content, author, this, System.DateTime.Now, LastMessage);
            AddMessage(msg);
        }

        private void OnDelete(MessageItem msg)
        {
            if(msg == LastMessage)
                LastMessage = LastMessage.PreviousMessage;
            
            OnMessageDeleted?.Invoke(msg);
        }
    }
}