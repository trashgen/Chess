using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitDB : MonoBehaviour
{
    public BattleUnit BishopBlack; // Horse
    public BattleUnit BishopWhite; // Horse
    
    public BattleUnit KingBlack; 
    public BattleUnit KingWhite;
    
    public BattleUnit KnightBlack; 
    public BattleUnit KnightWhite; 
    
    public BattleUnit PawnBlack; 
    public BattleUnit PawnWhite;
    
    public BattleUnit QueenBlack; 
    public BattleUnit QueenWhite; 
    
    public BattleUnit RookBlack; 
    public BattleUnit RookWhite; 
    
    private void Start() {
        
    }

    public int[,] PawnMove(int fromX, int fromY, bool isFirstMove) {
        int[,] res;
        if (isFirstMove) {
            res = new int[2, 2];
            res[fromX, fromY + 1] = 0;
        }
        else {
            res = new int[1, 1];
        }

        return res;
    }
}
