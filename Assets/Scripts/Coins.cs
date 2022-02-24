using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Levels levelScript;
    public theBoard boardScript;
    public pointsToCards cardScript;
    public int currentCoins;
    public int flippedOverOne;
    public GameObject coinText;
    int overOne = 0;

    void Start(){
        //All multipliers over one
        foreach (var Multiplier in boardScript.board){
            if (Multiplier > 1){
                overOne+=1;
            }
        }
            
        
    }
    
    //Multiply the current coins
    void CardFlip(int multiplier){
        if ((!cardScript.flippedCards.Contains(multiplier)) && (multiplier == 1)){
            currentCoins += 1;
        }
        else {
            currentCoins *= multiplier;
            flippedOverOne+=1;
            if (flippedOverOne==overOne){
                levelScript.LevelUp();
            }
        }
    }

    
}
