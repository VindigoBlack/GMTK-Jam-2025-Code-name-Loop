using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            switch (currentScene)
            {
                case "StartScene":
                    SceneManager.LoadScene("TestScene");
                    break;
                default:
                    Debug.Log("No next scene");
                    break;
            }
        }
    }
}
