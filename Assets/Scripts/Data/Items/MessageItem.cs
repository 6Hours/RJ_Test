using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class MessageItem : BaseItem
    {
        public string Content { get; private set; }
        public UserItem Author { get; private set; }
        public ChatItem Chat { get; private set; }
        public DateTime CreateTime { get; private set; }

        public Action<MessageItem> OnDelete;

        private MessageItem nextMessage;
        public MessageItem NextMessage
        {
            get { return nextMessage; }

            set
            {
                nextMessage = value;
                OnChangeItem?.Invoke();
            }
        }

        private MessageItem previousMessage;
        public MessageItem PreviousMessage 
        {
            get { return previousMessage; }

            set
            {
                previousMessage = value;
                OnChangeItem?.Invoke();
            }
        }

        public MessageItem(string content, UserItem author, ChatItem chat, DateTime createTime, MessageItem _previousMessage = null)
        {
            Content = content;
            Author = author;
            Chat = chat;
            CreateTime = createTime;
            PreviousMessage = _previousMessage;
        }

        public void Delete()
        {
            OnDelete?.Invoke(this);

            previousMessage.NextMessage = nextMessage;
            nextMessage.PreviousMessage = previousMessage;
        }
    }
}
