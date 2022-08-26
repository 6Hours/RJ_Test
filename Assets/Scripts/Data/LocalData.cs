using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class LocalData : Singleton<LocalData>
    {
        List<ChatItem> chats = new List<ChatItem>();

        public override void Awake()
        {
            base.Awake();
            
        }
    }
}