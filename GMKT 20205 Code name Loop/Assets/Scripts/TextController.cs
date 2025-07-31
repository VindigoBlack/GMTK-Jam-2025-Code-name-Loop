using System.Collections;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField]
    private string textToSay;
    [SerializeField]
    private float characterIntervalInSeconds;

    public TextMeshPro textComponent;

    private Coroutine speechCoroutine;

    void Start()
    {
        if (textToSay == "") textToSay = "Hello, this is an example text";

        speechCoroutine = StartCoroutine(SayText());
    }

    void Update()
    {
        
    }

    private IEnumerator SayText()
    {
        textComponent.text = "";
        foreach (char c in textToSay)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(characterIntervalInSeconds);
        }
    }
}
