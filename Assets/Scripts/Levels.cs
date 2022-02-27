using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//Avicii - Levels.cs

public class Levels : MonoBehaviour
{
    public int Level;
    public theBoard boardScript;
    public GameObject levelText;
    public Coins coinScript;
    void Start(){
        Level = PlayerPrefs.GetInt("level", 1);
        levelText.GetComponent<TMPro.TextMeshProUGUI>().text = "LVL: " + Level.ToString();  
    }

    public void LevelUp(){
        if (Level == 8){
            levelText.GetComponent<TMPro.TextMeshProUGUI>().text = "U REACHED THE MAX LVL";
            PlayerPrefs.SetInt("level", 1);
            coinScript.Reset();
            PlayerPrefs.Save();
        }
        Debug.Log("Level UP");
        // Add more multipliers
        for (int i=0;i<2;i++){
            boardScript.CnX[i, 0] += Level;
        }
        PlayerPrefs.SetInt("level", Level+=1);
        PlayerPrefs.Save();
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        levelText.GetComponent<TMPro.TextMeshProUGUI>().text = "LVL: " + Level.ToString();
    }
}
