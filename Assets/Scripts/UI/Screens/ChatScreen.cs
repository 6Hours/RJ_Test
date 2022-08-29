using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Data.Items;
using UI.Visualizators;
using Data;
using DG.Tweening;
using System.Linq;

namespace UI.Screens
{
    public class ChatScreen : MonoBehaviour
    {
        [SerializeField] private List<MessageVisualizator> visualizators = new List<MessageVisualizator>();
        [SerializeField] private RectTransform contentRect;

        [Header("Footer")]
        [SerializeField] private CanvasGroup createStateContainer;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button sendButton;
        [SerializeField] private Button deleteButton;

        [SerializeField] private CanvasGroup deleteStateContainer;
        [SerializeField] private Button deleteFinishButton;

        public void Start()
        {
            sendButton.onClick.AddListener(SendMessage);
            deleteButton.onClick.AddListener(() => ChangeState(true));
            deleteFinishButton.onClick.AddListener(() => ChangeState(false));
        }

        public void GenerateMessagesList(MessageItem curMsg)
        {
            LocalData.Instance.ChatsModel.CurrentChat.OnMessageAdded += AddMessage;

            for(var i = 0; i < visualizators.Count || curMsg != null; i++)
            {
                if (i >= visualizators.Count) 
                    visualizators.Add(Instantiate(visualizators[0], visualizators[0].transform.parent));
                
                visualizators[i].gameObject.SetActive(curMsg != null);

                if (curMsg != null)
                {
                    visualizators[i].UpdateItem(curMsg);
                    curMsg = curMsg.NextMessage;
                }
            }
        }

        private void SendMessage()
        {
            if (inputField.text == string.Empty) return;

            LocalData.Instance.ChatsModel.CurrentChat.AddMessage(new MessageItem(
                inputField.text,
                LocalData.Instance.ChatsModel.CurrentChat.Owner,
                LocalData.Instance.ChatsModel.CurrentChat,
                System.DateTime.Now,
                LocalData.Instance.ChatsModel.CurrentChat.LastMessage));

            inputField.text = string.Empty;
        }

        private void AddMessage(MessageItem item)
        {
            var inactiveVis = visualizators.Find((vis) => !vis.gameObject.activeSelf);

            if(inactiveVis == null)
            {
                visualizators.Add(Instantiate(visualizators[0], visualizators[0].transform.parent));
                visualizators.Last().UpdateItem(LocalData.Instance.ChatsModel.CurrentChat.LastMessage);
                visualizators.Last().gameObject.SetActive(true);
            }
            else
            {
                inactiveVis.UpdateItem(LocalData.Instance.ChatsModel.CurrentChat.LastMessage);
                inactiveVis.gameObject.SetActive(true);
            }
        }

        private void ChangeState(bool isDeleteState)
        {
            createStateContainer.interactable = false;
            deleteStateContainer.interactable = false;

            DOTween.To(() => 0f, (val) =>
            {
                createStateContainer.alpha = isDeleteState? 1f - val : val;
                deleteStateContainer.alpha = isDeleteState? val : 1f - val;

                contentRect.anchoredPosition = new Vector2(-178f * (isDeleteState ? val : 1f - val), 0f);
            }, 
            1f, 0.25f).OnComplete(() =>
            {
                createStateContainer.interactable = !isDeleteState;
                deleteStateContainer.interactable = isDeleteState;
            });
        }
    }
}
