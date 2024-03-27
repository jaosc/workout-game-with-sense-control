using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    private int playerCurrentScore;
    private int playerCurrentStamina;
    public static event Action<int> OnScoreChange;
    public static event Action<int> OnStaminaChange;

    void Start()
    {
        instance = this;
        ResetValues();
    }

    public int GetCurrentScore(){
        return this.playerCurrentScore;
    }

    public int GetCurrentStamina(){
        return this.playerCurrentStamina;
    }

    public void IncScore(int value){
        this.playerCurrentScore += value;
        OnScoreChange?.Invoke(this.playerCurrentScore);
    }

    public void DecStamina(int value){
        this.playerCurrentStamina -= value;
        OnStaminaChange?.Invoke(this.playerCurrentStamina);
    }

    public void ResetValues(){

        this.playerCurrentScore = 0;
        this.playerCurrentStamina = 3;

        OnScoreChange?.Invoke(this.playerCurrentScore);
        OnStaminaChange?.Invoke(this.playerCurrentStamina);

    }

}
