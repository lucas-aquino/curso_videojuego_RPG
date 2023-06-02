using UnityEngine;

[System.Serializable]
public class Sentence
{

    [SerializeField] private CharacterSO _character;
    
    [TextArea(2,5)]
    [SerializeField] private string _text;

    public CharacterSO Character { get { return _character; } }
    
    public string Text { get { return _text; } }

}

[CreateAssetMenu(fileName = "NewConversation", menuName = "Scriptable Objects/Conversation/Character")]
public class ConversationSO : ScriptableObject
{
    [SerializeField] private CharacterSO _leftCharacter;
    [SerializeField] private CharacterSO _rightCharacter;
    [SerializeField] private Sentence[] _sentences;

    public CharacterSO LeftCharacter { get { return _leftCharacter; } }
    public CharacterSO RightCharacter { get { return _rightCharacter; } }
    public Sentence[] Sentences { get {  return _sentences; } }
}
