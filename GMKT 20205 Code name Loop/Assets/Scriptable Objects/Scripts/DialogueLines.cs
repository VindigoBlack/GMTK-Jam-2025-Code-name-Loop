using UnityEngine;

[CreateAssetMenu(fileName = "DialogueLines", menuName = "Scriptable Objects/Dialogue Object")]
public class DialogueLines : ScriptableObject
{
    public string[] lines;
    public int[] phaseLineIndexes = new int[] { 0 };
    public int currentPhase;

    private void OnEnable()
    {
        currentPhase = 0;
        if (phaseLineIndexes.Length == 0 || phaseLineIndexes == null)
        {
            phaseLineIndexes = new int[] { 0 }; 
        }
        Debug.Log("Debug : Set scene to 0");
    }
}
