using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class ChatItem : BaseItem
    {
        public string ChatName { get; private set; }
        public UserItem Owner { get; private set; }

        public MessageItem LastMessage { get; private set; }

        public System.Action<MessageItem> OnMessageAdded;

        public ChatItem(string name, UserItem owner, MessageItem lastMessage)
        {
            ChatName = name;
            Owner = owner;
            LastMessage = lastMessage;

            if (LastMessage != null)
            {
                LastMessage.OnDelete += OnDelete;
            }
        }

        public void AddMessage(MessageItem message)
        {
            if(LastMessage != null) LastMessage.OnDelete -= OnDelete;

            LastMessage.NextMessage = message;
            LastMessage = message;
            LastMessage.OnDelete += OnDelete;

            OnMessageAdded?.Invoke(message);
        }

        private void OnDelete()
        {
            if (LastMessage != null) LastMessage.OnDelete -= OnDelete;
            
            LastMessage = LastMessage.PreviousMessage;
            
            if (LastMessage != null) LastMessage.OnDelete += OnDelete;
        }
    }
}