using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitDB : MonoBehaviour {
    [SerializeField] private List<BattleUnitSO> sos;
    
    private Dictionary<Type, BattleUnitSO> battleUnitTemplates = new();
    
    public enum Type {
        BishopBlack,
        BishopWhite,
        KingBlack,
        KingWhite,
        KnightBlack,
        KnightWhite,
        PawnBlack,
        PawnWhite,
        QueenBlack,
        QueenWhite,
        RookBlack,
        RookWhite
    }

    private void Awake() {
        foreach (var so in sos) {
            battleUnitTemplates[so.type] = so;
        }
    }

    // public BattleUnitSO BishopBlack; // Horse
    // public BattleUnitSO BishopWhite; // Horse
    //
    // public BattleUnitSO KingBlack; 
    // public BattleUnitSO KingWhite;
    //
    // public BattleUnitSO KnightBlack; 
    // public BattleUnitSO KnightWhite; 
    //
    // public BattleUnitSO PawnBlack; 
    // public BattleUnitSO PawnWhite;
    //
    // public BattleUnitSO QueenBlack; 
    // public BattleUnitSO QueenWhite; 
    //
    // public BattleUnitSO RookBlack; 
    // public BattleUnitSO RookWhite; 
    
    public BattleUnit SpawnUnit(Type type, Vector3 pos) {
        var so = battleUnitTemplates[type];
        var t = Instantiate(so.pfVisual, pos, Quaternion.identity);
        return new BattleUnit(so, t, t.Find("icon"));
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
