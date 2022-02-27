using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{
    public Levels levelScript;
    public Multipliers multScript;
    public theBoard boardScript;
    public GameObject coinText;
    public int currentCoins, flippedOverOne, overOne = 0;
    public bool started = false, GO = false;
    
    void Start(){
        currentCoins = PlayerPrefs.GetInt("coins", 0);
    }
    public void CardFlip(int multiplier){
        //All multipliers over one to recognize when player has flipped all over one multipliers.
        if (multiplier==0){
            Debug.Log("GAME OVER");
            GO = true;
            //Execute reset after 5 seconds
            Invoke("Reset", 5.0f);
        }
        // To multiplying coins with 1x. 
        if ((!started) && (multiplier == 1)){
            currentCoins += 1;
        }
        else if (multiplier!=1) {
            //Multiply the current coins
            currentCoins *= multiplier;
            PlayerPrefs.SetInt("coins", currentCoins);
            PlayerPrefs.Save();
            flippedOverOne+=1;
            if (flippedOverOne==overOne){
                levelScript.LevelUp();
                coinText.GetComponent<TMPro.TextMeshProUGUI>().text = "Coins: " + currentCoins.ToString();
                flippedOverOne = 0;
            }
        }
        coinText.GetComponent<TMPro.TextMeshProUGUI>().text = "Coins: " + currentCoins.ToString();
        started = true;
    }

    public void Reset(){
        // Back to base level and coins
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.Save();
        // Reloading scene 
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        boardScript.generateBoard();
    }

    
}
