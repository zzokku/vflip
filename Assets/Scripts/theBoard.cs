using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theBoard : MonoBehaviour
{
    // Counts of multipliers
    // 0x = GAME OVER
    public int[,] CnX = {
        {3, 3},
        {5, 2},
        {6, 0}
    };
    // The Board
    public int[] board = {
        1,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1
    };

    
    
    // Apply multipliers to the board .
    public void generateBoard(){
        for (int i=0;i<board.Length;i++){
            int r = Random.Range(0, 5);
            if (r < 3){
                if (CnX[r, 0] > 0){
                    board[i] = CnX[r, 1];
                    CnX[r, 0] -= 1;
                } 
                else {
                    break;
                    }
            }
            else if ((CnX[2, 0] > 0) && r == 5){
                    board[i] = 0;
                    CnX[2, 0] -= 1;
                }
            
        }
    }    
}
