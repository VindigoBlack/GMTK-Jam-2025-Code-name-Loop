using UnityEngine;

public class LogicController : MonoBehaviour
{
    public DialogueLines dialogueLines;
    private int currentPhase;
    void Start()
    {
        currentPhase = dialogueLines.currentPhase;
    }

    void Update()
    {
        
    }
}
