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

    public BattleUnit SpawnUnit(GridWrapper grid, Type type, Vector3 pos) {
        var so = battleUnitTemplates[type];
        var t = Instantiate(so.pfVisual, pos, Quaternion.identity);
        return new BattleUnit(grid, pos).Instantiate(so, t);
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
