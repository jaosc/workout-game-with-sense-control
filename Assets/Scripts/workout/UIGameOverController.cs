using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameOverController : MonoBehaviour
{
    public TMP_Text finalScore;
    public Button restartBt;
    public Button quitBt;
    void OnEnable()
    {   
        finalScore.text = PlayerStats.instance.GetCurrentScore().ToString();
        restartBt.onClick.AddListener(()=>{
            SceneManager.LoadScene("workoutScene");
        });
        quitBt.onClick.AddListener(()=>{
            Application.Quit();
        });
    }

}
