using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Chats
    {
        public List<ChatItem> ChatsList = new List<ChatItem>();


        private ChatItem currentChat;
        public ChatItem CurrentChat
        {
            get
            {
                return currentChat is null ? ChatsList[0] : currentChat; 
            }
        }

        public void Initialize()
        {
            Test_Config_controller.Instance.OnChatInfoReceive += LoadData;
        }

        private void LoadData(Test_Config_controller.TempChatItem[] items)
        {
            foreach(var item in items)
            {
                ChatsList.Add(new ChatItem(item.Id, item.Name,
                    LocalData.Instance.UsersModel.UsersList.Find((user) => user.Id == item.OwnerId), null)); //haven't msgs yet 
            }
        }
    }
}