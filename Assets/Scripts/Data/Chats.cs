using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Chats
    {
        public List<ChatItem> UsersList = new List<ChatItem>();

        public void Initialize()
        {
            Test_Config_controller.Instance.OnChatInfoReceive += LoadData;
        }

        private void LoadData(Test_Config_controller.TempChatItem[] items)
        {

        }
    }
}