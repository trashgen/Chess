using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ChessVisual : MonoBehaviour {
    [SerializeField] private Transform pfWhiteCell;
    [SerializeField] private Transform pfBlackCell;
    [SerializeField] private BattleUnitDB battleUnitDB;

    private Map map;
    private Cell selectedCell;

    public void SelectCell(Vector3 pos) {
        var go = map.GetGrid().GetGridObject(pos);
        if (go.HasBattleUnit()) {
            if (go == selectedCell) {
                selectedCell = null;
                var t = go.GetBattleUnitTransform();
                t.Find("icon").gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else {
                if (!ReferenceEquals(selectedCell, null)) {
                    var t = selectedCell.GetBattleUnitTransform();
                    t.Find("icon").gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }

                selectedCell = go;
            }

            if (!ReferenceEquals(selectedCell, null)) {
                List<Cell> cellsToMove = ShowAvailableCellsToGo(selectedCell);
            }
        }
        else {
            if (!ReferenceEquals(selectedCell, null)) {
                var t = selectedCell.GetBattleUnitTransform();
                t.Find("icon").gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            selectedCell = null;
        }
    }

    private List<Cell> ShowAvailableCellsToGo(Cell cell) {
        if (cell.HasBattleUnit()) {
            switch (cell.GetBattleUnit()) { }
        }
    }

    private void Update() {
        if (!ReferenceEquals(selectedCell, null) && selectedCell.HasBattleUnit()) {
            var t = selectedCell.GetBattleUnitTransform();
            t.Find("icon").gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    public void Setup(Map map) {
        this.map = map;
        for (int x = 0; x < map.GetGrid().GetWidth(); x++) {
            for (int y = 0; y < map.GetGrid().GetHeight(); y++) {
                var cell = map.GetGrid().GetGridObject(x, y);
                Vector3 pos = CalcBattleUnitPost(x, y);
                if ((x + y) % 2 == 1) {
                    cell.SetCellTransform(CreateCell(pfBlackCell, pos));
                }
                else {
                    cell.SetCellTransform(CreateCell(pfWhiteCell, pos));
                }

                if (y == map.GetGrid().GetHeight() - 2) {
                    cell.AddBattleUnit(battleUnitDB.PawnBlack, CreateCell(battleUnitDB.PawnBlack.pfVisual, pos));
                }

                if (y == 1) {
                    cell.AddBattleUnit(battleUnitDB.PawnWhite, CreateCell(battleUnitDB.PawnWhite.pfVisual, pos));
                }
            }
        }

        map.AddBattleUnit(0, 0, battleUnitDB.RookWhite,
            CreateCell(battleUnitDB.RookWhite.pfVisual, CalcBattleUnitPost(0, 0)));
        map.AddBattleUnit(7, 0, battleUnitDB.RookWhite,
            CreateCell(battleUnitDB.RookWhite.pfVisual, CalcBattleUnitPost(7, 0)));
        map.AddBattleUnit(0, 7, battleUnitDB.RookBlack,
            CreateCell(battleUnitDB.RookBlack.pfVisual, CalcBattleUnitPost(0, 7)));
        map.AddBattleUnit(7, 7, battleUnitDB.RookBlack,
            CreateCell(battleUnitDB.RookBlack.pfVisual, CalcBattleUnitPost(7, 7)));

        map.AddBattleUnit(1, 0, battleUnitDB.BishopWhite,
            CreateCell(battleUnitDB.BishopWhite.pfVisual, CalcBattleUnitPost(1, 0)));
        map.AddBattleUnit(6, 0, battleUnitDB.BishopWhite,
            CreateCell(battleUnitDB.BishopWhite.pfVisual, CalcBattleUnitPost(6, 0)));
        map.AddBattleUnit(1, 7, battleUnitDB.BishopBlack,
            CreateCell(battleUnitDB.BishopBlack.pfVisual, CalcBattleUnitPost(1, 7)));
        map.AddBattleUnit(6, 7, battleUnitDB.BishopBlack,
            CreateCell(battleUnitDB.BishopBlack.pfVisual, CalcBattleUnitPost(6, 7)));

        map.AddBattleUnit(2, 0, battleUnitDB.KnightWhite,
            CreateCell(battleUnitDB.KnightWhite.pfVisual, CalcBattleUnitPost(2, 0)));
        map.AddBattleUnit(5, 0, battleUnitDB.KnightWhite,
            CreateCell(battleUnitDB.KnightWhite.pfVisual, CalcBattleUnitPost(5, 0)));
        map.AddBattleUnit(2, 7, battleUnitDB.KnightBlack,
            CreateCell(battleUnitDB.KnightBlack.pfVisual, CalcBattleUnitPost(2, 7)));
        map.AddBattleUnit(5, 7, battleUnitDB.KnightBlack,
            CreateCell(battleUnitDB.KnightBlack.pfVisual, CalcBattleUnitPost(5, 7)));

        map.AddBattleUnit(3, 0, battleUnitDB.KingWhite,
            CreateCell(battleUnitDB.KingWhite.pfVisual, CalcBattleUnitPost(3, 0)));
        map.AddBattleUnit(4, 0, battleUnitDB.QueenWhite,
            CreateCell(battleUnitDB.QueenWhite.pfVisual, CalcBattleUnitPost(4, 0)));
        map.AddBattleUnit(3, 7, battleUnitDB.KingBlack,
            CreateCell(battleUnitDB.KingBlack.pfVisual, CalcBattleUnitPost(3, 7)));
        map.AddBattleUnit(4, 7, battleUnitDB.QueenBlack,
            CreateCell(battleUnitDB.QueenBlack.pfVisual, CalcBattleUnitPost(4, 7)));
    }

    private Vector3 CalcBattleUnitPost(int x, int y) {
        return new Vector3(x, y) * map.GetGrid().GetCellSize() + Vector3.one * map.GetGrid().GetCellSize() * .5f;
    }

    private Transform CreateCell(Transform pf, Vector3 pos) {
        return Instantiate(pf, pos, quaternion.identity);
    }
}