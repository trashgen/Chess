using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridWrapper
{
    private Grid<Cell> gridBackground;

    public int Width => gridBackground.GetWidth();
    public int Height => gridBackground.GetHeight();

    public GridWrapper() {
        gridBackground = new Grid<Cell>(8, 8, 10f, Vector3.zero,
            (g, x, y) => new Cell(g, x, y));
    }

    public void SetChessCell(Transform t) {
        gridBackground.GetGridObject(t.position).SetCellTransform(t);
    }

    public void AddBattleUnitToCell(BattleUnit bu) {
        gridBackground.GetGridObject(bu.UnitTransform().position).AddBattleUnit(bu);
    }

    public BattleUnit GetBattleUnit(Vector3 pos) {
        return gridBackground.GetGridObject(pos).GetBattleUnit();
    }
    
    public Vector3 CalcBattleUnitPost(int x, int y) {
        return new Vector3(x, y) * gridBackground.GetCellSize() + Vector3.one * gridBackground.GetCellSize() * .5f;
    }
    
    // private List<Cell> ShowAvailableCellsToGo(Cell cell) {
    //     if (cell.HasBattleUnit()) {
    //         switch (cell.GetBattleUnit()) { }
    //     }
    // }

}
