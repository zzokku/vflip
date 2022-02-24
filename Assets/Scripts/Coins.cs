using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{
    public Levels levelScript;
    public theBoard boardScript;
    public int currentCoins, flippedOverOne, int overOne = 0;
    public GameObject coinText;
    public bool started = false;
    
    void Start(){
        //All multipliers over one to recognize when player has flipped all over one multipliers.
        foreach (var Multiplier in boardScript.board){
            if (Multiplier > 1){
                overOne+=1;
            }
        }
    }
    
    //Multiply the current coins
    void CardFlip(int multiplier){
        if (multiplier==0){
            Debug.Log("GAME OVER");
            Reset();
        }
        // To multiplying coins with 1x. 
        if ((!started) && (multiplier == 1)){
            currentCoins += 1;
        }
        else {
            currentCoins *= multiplier;
            flippedOverOne+=1;
            if (flippedOverOne==overOne){
                levelScript.LevelUp();
            }
        }
        started = true;
    }

    void Reset(){
        // Back to base level and coins
        levelScript.Level = 1;
        currentCoins = 0;
        // Reloading scene 
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    
}
