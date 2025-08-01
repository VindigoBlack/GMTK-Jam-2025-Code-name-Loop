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
    private int currentPhaseIndex;
    private int nextPhaseIndex;

    void Start()
    {
        currentPhaseIndex = dialogueLines.phaseLineIndexes[dialogueLines.currentPhase];
        if (System.Array.IndexOf(dialogueLines.phaseLineIndexes, dialogueLines.phaseLineIndexes[dialogueLines.currentPhase]) == dialogueLines.phaseLineIndexes.Length - 1)
        {
            nextPhaseIndex = dialogueLines.lines.Length;
        }
        else
        {
            nextPhaseIndex = dialogueLines.phaseLineIndexes[dialogueLines.currentPhase + 1];
        }
        speechCoroutine = StartCoroutine(SayText());
    }

    void Update()
    {
        
    }

    private IEnumerator SayText()
    {
        for (int i = currentPhaseIndex; i < nextPhaseIndex; i++)
        {
            string s = dialogueLines.lines[i];
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
