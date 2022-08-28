using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class LocalData : Singleton<LocalData>
    {
        public Users UsersModel => usersModel;
        public Chats ChatsModel => chatsModel;

        private Users usersModel = new Users();
        private Chats chatsModel = new Chats();

        public override void Awake()
        {
            base.Awake();
            usersModel.Initialize();
            chatsModel.Initialize();
        }
    }
}