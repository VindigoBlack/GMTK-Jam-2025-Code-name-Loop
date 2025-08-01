using UnityEngine;

[CreateAssetMenu(fileName = "DialogueLines", menuName = "Scriptable Objects/Dialogue Object")]
public class DialogueLines : ScriptableObject
{
    public string[] lines;
    public int currentPhase;

    private void OnEnable()
    {
        currentPhase = 0;
        Debug.Log("Debug : Set scene to 0");
    }
}
