using UnityEngine;

public class LogicController : MonoBehaviour
{
    public DialogueLines dialogueLines;
    private int currentPhase;
    void Start()
    {
        // Add self check for duplicates
        currentPhase = dialogueLines.currentPhase;
    }

    void Update()
    {
        
    }
}
