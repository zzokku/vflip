using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pointsToCards : MonoBehaviour
{
    public GameObject cardParent;
    public Coins coinScript;
    public theBoard boardScript;
    public Sprite flippedSprite;
    public List<GameObject> Cards;
    public List<int> flippedCards;
    public Button thisBtn;
    

    void Start(){
        // Creating List from all cards.
        foreach (Transform child in this.gameObject.transform.parent){
            Cards.Add(child.gameObject); 
        }
    }
    // Function to change all visual aspects in card flip.
    public void flipCard(){
        // If game is not over
        if (!coinScript.GO){
            Button thisBtn = this.gameObject.GetComponent<Button>();
            // Switching card sprite to flippedSprite
            thisBtn.image.sprite = flippedSprite;
            // Function to multiply coins or lose the game.
            coinScript.CardFlip(boardScript.board[Cards.IndexOf(this.gameObject)]);
            Debug.Log(boardScript.board[Cards.IndexOf(this.gameObject)]);
            // Adding the flipped card multiplier text to buttons text attribute.
            this.gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = boardScript.board[Cards.IndexOf(this.gameObject)].ToString();
            }
    }

    
}
