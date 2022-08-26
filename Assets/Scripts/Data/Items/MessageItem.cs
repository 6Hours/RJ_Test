using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class MessageItem : BaseItem
    {
        public string Content { get; private set; }
        public UserItem Author { get; private set; } //may be use long?
        public DateTime CreateTime { get; private set; }

        public Action OnDelete;

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

        public MessageItem(string content, UserItem author, DateTime createTime, MessageItem _previousMessage = null)
        {
            Content = content;
            Author = author;
            CreateTime = createTime;
            PreviousMessage = _previousMessage;
        }

        public void Delete()
        {
            previousMessage.NextMessage = nextMessage;
            nextMessage.PreviousMessage = previousMessage;

            OnDelete?.Invoke();
        }
    }
}
