using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Config_controller : Singleton<Test_Config_controller>
{
    /// <summary>
    ///  остыль дл€ демонстрации тестового задани€
    /// </summary>
    public struct TempUserItem
    {
        public string name;
        public Sprite avatarSprite;
    }

    public struct TempChatItem
    {
        public string name;
        public int ownerId;

    }

    public TempUserItem[] tempUserItems;
    public TempChatItem[] tempChatItems;

    public System.Action<TempUserItem[]> OnUsersInfoReceive;
    public System.Action<TempChatItem[]> OnChatInfoReceive;

    // Start is called before the first frame update
    private void Start()
    {
        for(var i = 0; i < tempUserItems.Length; i++)
        {
            if(i != tempChatItems[0].ownerId)
            {
                if(i % 2 == 0)
                {

                }
                else
                {

                }
            }
        }

        OnUsersInfoReceive?.Invoke(tempUserItems);
        
        OnChatInfoReceive?.Invoke(tempChatItems);
    }

    private void OnMessageAdded(MessageItem msg)
    {

    }
}
