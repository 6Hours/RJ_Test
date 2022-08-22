using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class MessageItem : BaseItem
    {
        public string Content { get; private set; }
        public int AuthorId { get; private set; } //may be use long?
        public DateTime CreateTime { get; private set; }

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

        public MessageItem(string content, int authorId, DateTime createTime, MessageItem _previousMessage = null)
        {
            Content = content;
            AuthorId = authorId;
            CreateTime = createTime;
            PreviousMessage = _previousMessage;
        }
    }
}
