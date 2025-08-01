using System.Collections;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField]
    private float characterIntervalInSeconds;
    [SerializeField]
    private float dialougeLinesIntervalInSeconds;

    public DialogueLines dialogueLines;
    public TextMeshPro textComponent;

    private Coroutine speechCoroutine;

    void Start()
    {
        speechCoroutine = StartCoroutine(SayText());
    }

    void Update()
    {
        
    }

    private IEnumerator SayText()
    {
        foreach (string s in dialogueLines.lines) 
        { 
            yield return new WaitForSeconds(dialougeLinesIntervalInSeconds);
            textComponent.text = "";
            foreach (char c in s)
            {
                textComponent.text += c;
                yield return new WaitForSeconds(characterIntervalInSeconds);
            }
        } 
    }
}
