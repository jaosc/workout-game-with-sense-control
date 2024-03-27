using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    // public GameObject GameOverPanel;

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"){
            // UIController.instance.debugText.text = "Game over";
            SceneManager.LoadScene("Game");
        }
    }
}
