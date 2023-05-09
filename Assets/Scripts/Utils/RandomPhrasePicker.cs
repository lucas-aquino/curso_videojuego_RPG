using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomPhrasePicker : MonoBehaviour
{
    [Header("Phrase List")]
    [SerializeField] private PhraseListSO _phraseList;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    [Header("Configuration")]
    [SerializeField] private float _interval = 1;

    private void Start()
    {
        StartCoroutine(EditTextMeshPro(_interval));
    }

    private IEnumerator EditTextMeshPro(float seconds)
    {
        while (true)
        {
            _textMeshPro.SetText(PickRandomPhrase());
            yield return new WaitForSeconds(seconds);
        }
    }

    private string PickRandomPhrase()
    {
        List<string> phraseList = _phraseList.PhraseList;
        int index = Mathf.Abs(Mathf.FloorToInt(Random.Range(0f, (float)phraseList.Count)));

        return phraseList[index];
    }
}
