using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewPhraseList", menuName = "Scriptable Objects/Phrase List")]
public class PhraseListSO : ScriptableObject
{
    [SerializeField] private List<string> _phraseList;

    public List<string> PhraseList { get { return _phraseList; } }
}
