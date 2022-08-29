using Data;
using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UI.Screens;
using UnityEngine;

public class Test_Config_controller : Singleton<Test_Config_controller>
{
    /// <summary>
    ///  остыль дл€ демонстрации тестового задани€
    /// </summary>

    [System.Serializable]
    public struct TempUserItem
    {
        public int Id;
        public string Name;
        public Sprite AvatarSprite;
    }

    [System.Serializable]
    public struct TempChatItem
    {
        public int Id;
        public string Name;
        public int OwnerId;
    }

    public TempUserItem[] tempUserItems;
    public TempChatItem[] tempChatItems;

    public System.Action<TempUserItem[]> OnUsersInfoReceive;
    public System.Action<TempChatItem[]> OnChatInfoReceive;

    [SerializeField] private ChatScreen chatScreen;

    private List<int> botUsers = new List<int>();

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //Bots type sorting
        foreach (var item in tempUserItems)
        {
            if (item.Id != tempChatItems[0].OwnerId)
            {
                botUsers.Add(item.Id);
            }
        }

        OnUsersInfoReceive?.Invoke(tempUserItems);
        yield return null;
        OnChatInfoReceive?.Invoke(tempChatItems);
        yield return null;
        chatScreen.GenerateMessagesList(null);

        Invoke("InvokeRepeaterBots", 5f);
    }
    private void InvokeRepeaterBots()
    {
        var user = LocalData.Instance.UsersModel.UsersList.Find(
            (usr) => usr.Id == botUsers[Random.Range(0, botUsers.Count)]);
        var msgsCount = Random.Range(1, 3);
        for (var i = 0; i < msgsCount; i++)
            LocalData.Instance.ChatsModel.CurrentChat.AddMessage(Random.Range(0, 100).ToString(), user);
        Invoke("InvokeRepeaterBots", 10f);
    }
}
