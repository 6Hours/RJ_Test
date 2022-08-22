using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UI.Screens
{
    public class ChatScreen : MonoBehaviour
    {
        [SerializeField] private RectTransform messagesContainer;



        [Header("Footer")]
        [SerializeField] private CanvasGroup createStateContainer;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button sendButton;
        [SerializeField] private Button deleteButton;

        [SerializeField] private CanvasGroup deleteStateContainer;
        [SerializeField] private Button deleteFinishButton;
    }
}
