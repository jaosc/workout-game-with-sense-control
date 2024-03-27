using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUIController : MonoBehaviour
{

    public Button startBt;

    void Start()
    {
        startBt.onClick.AddListener(()=>{
            SceneManager.LoadScene("workoutScene");
        });
        
    }
}
