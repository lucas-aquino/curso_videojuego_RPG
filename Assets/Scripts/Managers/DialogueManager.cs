using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private DialogueUI _dialogueUI;
    public DialogueUI DialogueUI { get { return _dialogueUI; } }

    [Header("Action Events")]
    [SerializeField] private UnityEvent _onConversationStarted;
    [SerializeField] private UnityEvent _onConversationFinished;

    public UnityEvent OnConversationStarted { get { return _onConversationStarted; } }
    public UnityEvent OnConversationFinished { get {  return _onConversationFinished; } }

    private Queue<Sentence> _sentences;

    private void Start()
    {
        _sentences = new Queue<Sentence>();
    }

    public void StartConversation(ConversationSO conversation)
    {
        foreach (Sentence sentence in conversation.Sentences) 
        {
            _sentences.Enqueue(sentence);    
        }

        DialogueUI.StarConversation(conversation);

        OnConversationStarted?.Invoke();

        NextSentence();
    }

    public void NextSentence()
    {
        if (DialogueUI.IsSentenceInProcess())
        {
            DialogueUI.FinishDisplaySentence();
            return;
        }

        if (_sentences.Count == 0)
        {
            EnConversation();
        }

        Sentence sentence = _sentences.Dequeue();

        DialogueUI.DisplaySentence(sentence);
    }

    public void EnConversation()
    {
        DialogueUI.EndConversation();

        OnConversationFinished?.Invoke();
    }

    
}
