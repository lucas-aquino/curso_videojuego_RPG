using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private ConversationSO _conversation;
    public ConversationSO Conversation { get { return _conversation; } }


    [Header("Broadcasting events")]
    [SerializeField] private ConversationSOGameEvent _conversationResquetEvent;
    public ConversationSOGameEvent ConversationRequestEvent { get { return _conversationResquetEvent; } }

    public void OnTriggerConversation()
    {
        this.ConversationRequestEvent.Raise(this.Conversation);    
    }

}
