using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Avicii - Levels.cs

public class Levels : MonoBehaviour
{
    public int Level = 1;
    public theBoard boardScript;
    public GameObject levelText;
    public Coins coinScript;

    void Start(){
        levelText.GetComponent<TMPro.TextMeshProUGUI>().text = Level.ToString();
    }
    

    public void LevelUp(){
        if (Level == 8){
            levelText.GetComponent<TMPro.TextMeshProUGUI>().text = "U REACHED THE MAX LVL";
            coinScript.Reset();
        }
        Debug.Log("Level UP");
        Level+=1;
        boardScript.CnX[0, 0] += 1;
        boardScript.CnX[1, 0] += 1;
        boardScript.CnX[2, 0] += 1;
    }
}
