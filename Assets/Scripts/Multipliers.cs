using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Multipliers : MonoBehaviour
{
    // Reference to theBoard script
    public theBoard TheBoard;
    // Array to be assigned to current board
    public int[] currentBoard;
    // 24 ints long points list which stores all multipliers per rows and columns
    public List<int> points = new List<int>();
    // xCount = count of multipliers over 0, mineCount = count of multipliers < 1
    int i, j , xCount, mineCount;



    void Start()
    {
        TheBoard.generateBoard();
        currentBoard = TheBoard.board;
        assignMultipliers();
    }
    // Getting the sums of multipliers and "mines" per rows and columns.
    public List<int> sumRC(){
        // Rows
        i=0;
        while (i<24){
            xCount = 0;
            mineCount = 0;
            for(j=0;j<5;j++){
                if (currentBoard[i] > 0){
                   xCount += currentBoard[i];
               } else {
                    mineCount += 1;
               }
               i+=1;
            }
            points.Add(xCount);
            Debug.Log("row multipliers");
            Debug.Log(xCount);
            points.Add(mineCount);
        }

        // Columns
        for (i=0;i<5;i++){
            xCount = 0;
            mineCount = 0;
            j = i;
            while (j<=24){
                if (currentBoard[j] != 0){
                    xCount += currentBoard[j];
                }
                else {
                    mineCount += 1;
                }
                j+=5;
            }
            Debug.Log("multipliers");
            Debug.Log(xCount);
            points.Add(xCount);
            points.Add(mineCount);
        }
        return points;
   }
   // 
   void assignMultipliers(){
       // Generated points list object.
       points = sumRC();
       foreach (var item in points)
       {
        Debug.Log("the point");
        Debug.Log(item);   
       }
       j=0;
       // Iterating through all children (text objects) and assigning xCount and mineCount to them from points List object.
       foreach (Transform child in this.gameObject.transform) {
           child.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = points[j].ToString() + "\n" + points[j+1].ToString();
           j+=2;
           }
   }
}
