using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Data.Items;
using UI.Visualizators;

namespace UI.Screens
{
    public class ChatScreen : MonoBehaviour
    {
        [SerializeField] private List<MessageVisualizator> visualizators;

        [Header("Footer")]
        [SerializeField] private CanvasGroup createStateContainer;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button sendButton;
        [SerializeField] private Button deleteButton;

        [SerializeField] private CanvasGroup deleteStateContainer;
        [SerializeField] private Button deleteFinishButton;

        public void Initialize()
        {
            visualizators = new List<MessageVisualizator>();
        }

        public void GenerateMessagesList(MessageItem lastMsg)
        {
            for(var i = 0; i < visualizators.Count || lastMsg != null; i++)
            {
                if (i >= visualizators.Count) 
                    visualizators.Add(Instantiate(visualizators[0], visualizators[0].transform.parent));
            }
        }
    }
}
