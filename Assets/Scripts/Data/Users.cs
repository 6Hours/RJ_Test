using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Users
    {
        public List<UserItem> UsersList = new List<UserItem>();

        public void Initialize()
        {
            Test_Config_controller.Instance.OnUsersInfoReceive += LoadData;
        }

        private void LoadData(Test_Config_controller.TempUserItem[] items)
        {
            foreach(var item in items)
            {
                UsersList.Add(new UserItem(item.Id, item.Name, item.AvatarSprite));
            }
        }
    }
}