using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pointsToCards : MonoBehaviour
{
    public GameObject cardParent;
    public theBoard boardScript;
    public Coins coinsScript;
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
    
    public void flipCard(){
        //Button thisBtn = this.gameObject.GetComponent<Button>();
        // Switching card sprite to flippedSprite
        thisBtn.image.sprite = flippedSprite;
        flippedCards.Add(boardScript.board[Cards.IndexOf(this.gameObject)]);
        // Adding the flipped card multiplier text to buttons text attribute.
        this.gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = boardScript.board[Cards.IndexOf(this.gameObject)].ToString();
    }

    
}
