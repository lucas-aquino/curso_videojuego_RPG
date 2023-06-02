using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Scriptable Objects/Conversation/Character")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] private string _fullname;
    [SerializeField] private Sprite _portrait;

    public string Fullname { get { return _fullname; } }
    public Sprite Portrait { get { return _portrait; } }
}
