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
        //Place 0x until Cnx[2, 0] = 0
        
        for (int i=0;i<board.Length;i++){
            int r = Random.Range(0, 2);       
            if (r==1){
                if (CnX[2, 0] > 0){
                    board[i] = 0;
                    CnX[2, 0] -= 1;
                    Debug.Log(CnX[2, 0]);
                }
                else {
                    break;
                }
            }
        }
        // Place other multipliers
        for (int i=0;i<board.Length;i++){
            int r = Random.Range(0, 2);
            Debug.Log(r);
            if (CnX[0, 0] == 0 || CnX[1, 0] == 0){
                break;
            }
            if (r==0){
                if ((board[i] != 0) && (CnX[0, 0] > 0)){
                    board[i] = CnX[0, 1];
                    CnX[0, 0] -= 1;
                }
            }
            else {
                if ((board[i] != 0) && (CnX[1, 1] > 0)){
                    board[i] = CnX[1, 1];
                    CnX[1, 0] -= 1;
                }
            }
        }
        foreach (var integer in board){
            Debug.Log(integer);
        }
    }    
}
