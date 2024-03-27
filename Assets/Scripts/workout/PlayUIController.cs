using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayUIController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text couchDialogueText;
    public TMP_Text playerDialogueText;
    public TMP_Text gameDialogueText;
    public TMP_Text coachDialogueText;
    public Image coachaBallonImg;
    public Image[] hearts;
    
    void Start()
    {
        
        hideCoachTalk();
        scoreText.text = PlayerStats.instance.GetCurrentScore().ToString();
        gameDialogueText.text = "SE PREPARE...O GAME VAI COMEÇAR!!";

        PlayerStats.OnScoreChange += ShowNewScore;
        PlayerStats.OnStaminaChange += UpdateStaminaBar;
        
    }

    void OnDisable(){
        PlayerStats.OnScoreChange -= ShowNewScore;
        PlayerStats.OnStaminaChange -= UpdateStaminaBar;
    }

    public void CoachTalkUpdate(string msg){

        coachaBallonImg.enabled = true;
        coachDialogueText.text = msg;
        coachDialogueText.enabled = true;

    }

    public void hideCoachTalk(){
        if(coachaBallonImg.enabled){
            coachaBallonImg.enabled = false;
            coachDialogueText.enabled = false;
        }
    }

    void ShowNewScore(int value){
        scoreText.text = value.ToString();
    }

    void UpdateStaminaBar(int value){
        for(int i = 0; i < hearts.Length; i++){
            hearts[i].gameObject.SetActive(i < value);
        }
    }

}
