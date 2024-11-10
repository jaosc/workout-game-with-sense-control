using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreModel
{
    public int score;
    public System.DateTime date;

    public ScoreModel(int score, System.DateTime date){
        this.score = score;
        this.date = date;
    }
}


public enum Moviment {
    IDLE,
    JUMP,
    SWING,
    BREAK,
}

public class WorkoutManager : MonoBehaviour
{
    private Moviment currentMoviment = Moviment.IDLE;
    private Moviment nextMoviment;

    // Let 7 to sincronize with audio sound
    private int currentMovimentDurationInSecs = 7;
    public CoachController coachController;
    public AthleteController athleteController;
    public PlayUIController playUIController;
    public UIGameOverController uiGameOverController;

    
    const int MAX_ROUND_TIME_IN_SECS = 15;
    const string SCORE_FILE_PATH = "scores.json";

    void Start()
    {

        Time.timeScale = 1f;
        if(coachController == null){
            throw new System.Exception("No coach object attach to workoutmanager");
        }

        if(playUIController == null){
            throw new System.Exception("No PlayerUIController object attach to workoutmanager");
        }

        StartCoroutine(CountPassedTime(currentMovimentDurationInSecs));
        this.nextMoviment = GenerateRandomMoviment();

    }

    void SetupNewRound(){

        PlayerStats.instance.IncScore(1);

        this.currentMovimentDurationInSecs = GenerateRandomTimeInSeconds(MAX_ROUND_TIME_IN_SECS);
        StartCoroutine(CountPassedTime(currentMovimentDurationInSecs));
        playUIController.gameDialogueText.text = CreateNewMovimentMessage(currentMovimentDurationInSecs, nextMoviment);
        this.coachController.StartMoviment(this.nextMoviment);
        this.currentMoviment = this.nextMoviment;
        this.nextMoviment = GenerateRandomMoviment();

        Debug.Log("currentMovimentDuration: " + currentMovimentDurationInSecs);
        Debug.Log("currentMoviment: " + currentMoviment);
        Debug.Log("nextMoviment: " + nextMoviment);

    }

    string CreateNewMovimentMessage(int time, Moviment moviment){

        return "Bora pro " + moviment.ToString() + " durante " + time.ToString() + " segundos";
        
    }

    int GenerateRandomTimeInSeconds(int maxSecs){
        return Random.Range(5, maxSecs);
    }

    Moviment GenerateRandomMoviment(){
        
        int enumLength = System.Enum.GetValues(typeof(Moviment)).Length;
        int randomIndex = Random.Range(0, enumLength);
        return (Moviment)randomIndex;

    }

    IEnumerator CountPassedTime(int waitTime){

        float timer = 0f;
        float damageTime = 0f;
        while(timer <= waitTime){

            timer += Time.deltaTime;

            if(currentMoviment != Moviment.IDLE && athleteController.mCurrentMoviment != currentMoviment){
                damageTime += Time.deltaTime;
                playUIController.CoachTalkUpdate("Me siga no movimento para ganhar mais pontos e não perder!");
            }else{
                damageTime = 0;
                playUIController.hideCoachTalk();
            }

            if(damageTime >= 4){
                PlayerStats.instance.DecStamina(1);
                damageTime = 0;
            }

            if(PlayerStats.instance.GetCurrentStamina() <= 0){
                GameOverStart();
            }

            yield return null;
        }

        SetupNewRound();

    }

    void GameOverStart(){
        uiGameOverController.gameObject.SetActive(true);
        playUIController.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    private void SaveScore(int newScore) {
        List<ScoreModel> scores = LoadScore();
        scores.Add(new ScoreModel(newScore, System.DateTime.Now));
        string output_json = JsonUtility.ToJson(scores);
        File.WriteAllText(SCORE_FILE_PATH, output_json);
    }

    private List<ScoreModel> LoadScore() {
        if(File.Exists(SCORE_FILE_PATH)) {
            return JsonUtility.FromJson<List<ScoreModel>>(File.ReadAllText(SCORE_FILE_PATH));
        }
        return new List<ScoreModel>();
    }

}
