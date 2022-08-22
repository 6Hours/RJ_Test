using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Data.Items;

namespace UI.Visualizators
{
    public class MessageVisualizator : BaseVisualizator<MessageItem>
    {
        [SerializeField] private Image userIcon;
        [SerializeField] private TextMeshProUGUI senderName;
        [SerializeField] private TextMeshProUGUI messageContent;
        [SerializeField] private TextMeshProUGUI messageTime;
        [SerializeField] private Button deleteButton;

        [Header("Message Background")]
        [SerializeField] private Image lastBlue;
        [SerializeField] private Image noLastBlue;
        [SerializeField] private Image lastGrey;
        [SerializeField] private Image noLastGrey;

        public void Start()
        {
            
        }
        public override void UpdateItem(MessageItem _item)
        {
            base.UpdateItem(_item);

            
        }
    }
}