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
        foreach (var Multiplierr in multScript.currentBoard){
            if (Multiplierr > 1){
                overOne+=1;
            }
        }
        Debug.Log(overOne);
    }
    public void CardFlip(int multiplier){
        //All multipliers over one to recognize when player has flipped all over one multipliers.
        Debug.Log("OO: ");
        Debug.Log(overOne);
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
        levelScript.Level = 1;
        currentCoins = 0;
        // Reloading scene 
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        boardScript.generateBoard();
    }

    
}
