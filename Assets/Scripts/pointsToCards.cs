using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pointsToCards : MonoBehaviour
{
    public GameObject cardParent;
    public theBoard boardScript;
    public Sprite flippedSprite;
    public List<GameObject> Cards;
    public Button thisBtn;

    void Start(){
        // Creating List from all cards.
        foreach (Transform child in this.gameObject.transform.parent){
            Cards.Add(child.gameObject); 
        }
    }
    
    public void flipCard(){
        Button thisBtn = this.gameObject.GetComponent<Button>();
        thisBtn.image.sprite = flippedSprite;
        // Adding the flipped card multiplier text to buttons text attribute.
        this.gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = boardScript.board[Cards.IndexOf(this.gameObject)].ToString();
    }

    
}
