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
            PlayerPrefs.SetInt("level", 0);
            coinScript.Reset();
            PlayerPrefs.Save();
        }
        PlayerPrefs.SetInt("level", Level+=1);
        PlayerPrefs.Save();
        Debug.Log("Level UP");
        boardScript.CnX[0, 0] += Level;
        boardScript.CnX[1, 0] += Level;
        boardScript.CnX[2, 0] += Level;
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        levelText.GetComponent<TMPro.TextMeshProUGUI>().text = "LVL: " + Level.ToString();
    }
}
