using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Data.Items;
using DG.Tweening;

namespace UI.Visualizators
{
    public class MessageVisualizator : BaseVisualizator<MessageItem>
    {
        [SerializeField] private Image userIcon;
        [SerializeField] private Button deleteButton;
        [SerializeField] private TextMeshProUGUI messageContent;
        [SerializeField] private TextMeshProUGUI messageTime;

        [SerializeField] private CanvasGroup canvasGroup;

        [Header("Message Background")]
        [SerializeField] private Image lastBlue;
        [SerializeField] private Image noLastBlue;
        [SerializeField] private Image lastGrey;
        [SerializeField] private Image noLastGrey;

        [SerializeField] private HorizontalLayoutGroup layoutGroup;
        public void Start()
        {
            FadeAnimation(0f, 1f, null);
            deleteButton.onClick.AddListener(OnDeleteClick);
        }

        private void OnEnable()
        {
            FadeAnimation(0f, 1f, null);
        }

        public override void UpdateItem(MessageItem _item)
        {
            base.UpdateItem(_item);

            //Text content
            var isLastMsg = Item.NextMessage is null || Item.NextMessage?.Author.Id != Item.Author.Id;

            messageContent.text = isLastMsg ? string.Format("<color=#7DC8F8>{0}</color> \n", Item.Author.Name) : string.Empty;  
            messageContent.text += Item.Content;

            messageTime.text = Item.CreateTime.ToString("T");

            userIcon.enabled = isLastMsg;
            userIcon.sprite = Item.Author.Icon;


            var isOwner = Item.Chat.Owner.Id == Item.Author.Id;

            layoutGroup.reverseArrangement = !isOwner;
            layoutGroup.childAlignment = isOwner? TextAnchor.LowerRight : TextAnchor.LowerLeft;
            deleteButton.image.enabled = isOwner;
            
            //Background  
            lastBlue.gameObject.SetActive(isOwner && isLastMsg);
            noLastBlue.gameObject.SetActive(isOwner && !isLastMsg);
            lastGrey.gameObject.SetActive(!isOwner && isLastMsg);
            noLastGrey.gameObject.SetActive(!isOwner && !isLastMsg);
        }

        private void OnDeleteClick()
        {
            FadeAnimation(1f, 0f, () =>
            {
                transform.SetAsLastSibling();
                gameObject.SetActive(false);
                Item.Delete();
            });
        }

        private void FadeAnimation(float beginVal, float endVal, Action callback)
        {
            canvasGroup.interactable = false;
            canvasGroup.alpha = beginVal;
            DOTween.To(() => canvasGroup.alpha, (val) => canvasGroup.alpha = val, endVal, 0.5f)
                .OnComplete(() =>
                {
                    callback?.Invoke();
                    canvasGroup.interactable = true;
                });
        }
    }
}