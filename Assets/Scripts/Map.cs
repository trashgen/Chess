using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Map : MonoBehaviour {
    [SerializeField] private Transform pfWhiteCell;
    [SerializeField] private Transform pfBlackCell;
    [SerializeField] private BattleUnitDB battleUnitDB;
    
    private GridWrapper grid;
    private BattleUnit selectedBattleUnit;

    private void Awake() {
        grid = new GridWrapper();
    }

    private void Start() {
        for (int x = 0; x < grid.Width; x++) {
            for (int y = 0; y < grid.Height; y++) {
                Vector3 pos = grid.CalcBattleUnitPost(x, y);
                if ((x + y) % 2 == 1) {
                    grid.SetChessCell(Instantiate(pfBlackCell, pos, quaternion.identity));
                }
                else {
                    grid.SetChessCell(Instantiate(pfWhiteCell, pos, quaternion.identity));
                }
                if (y == grid.Height - 2) {
                    grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.PawnBlack, pos));
                } 
                if (y == 1) {
                    grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.PawnWhite, pos));
                }
            }
        }
        
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.RookWhite, grid.CalcBattleUnitPost(0, 0)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.RookWhite, grid.CalcBattleUnitPost(7, 0)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.RookBlack, grid.CalcBattleUnitPost(0, 7)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.RookBlack, grid.CalcBattleUnitPost(7, 7)));
        
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.BishopWhite, grid.CalcBattleUnitPost(1, 0)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.BishopWhite, grid.CalcBattleUnitPost(6, 0)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.BishopBlack, grid.CalcBattleUnitPost(1, 7)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.BishopBlack, grid.CalcBattleUnitPost(6, 7)));
        //
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.KnightWhite, grid.CalcBattleUnitPost(2, 0)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.KnightWhite, grid.CalcBattleUnitPost(5, 0)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.KnightBlack, grid.CalcBattleUnitPost(2, 7)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.KnightBlack, grid.CalcBattleUnitPost(5, 7)));
        //
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.KingWhite, grid.CalcBattleUnitPost(3, 0)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.QueenWhite, grid.CalcBattleUnitPost(4, 0)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.KingBlack, grid.CalcBattleUnitPost(3, 7)));
        grid.AddBattleUnitToCell(battleUnitDB.SpawnUnit(BattleUnitDB.Type.QueenBlack, grid.CalcBattleUnitPost(4, 7)));
    }

    public void SetCell(Vector3 pos) {
        
    }

    public void SelectCell(Vector3 pos) {
        var go = grid.GetBattleUnit(pos);
        if (!ReferenceEquals(go, null)) {
            if (go == selectedBattleUnit) {
                selectedBattleUnit = null;
                go.Unselect();
            }
            else {
                if (!ReferenceEquals(selectedBattleUnit, null)) {
                    selectedBattleUnit.Unselect();
                }
        
                go.Select();
                selectedBattleUnit = go;
            }
        }
        else {
            if (!ReferenceEquals(selectedBattleUnit, null)) {
                selectedBattleUnit.Unselect();
            }
            selectedBattleUnit = null;
        }
    }
}
