using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map {
    private Grid<Cell> grid;

    public Grid<Cell> GetGrid() => grid;

    public Map() {
        grid = new Grid<Cell>(8, 8, 10f, Vector3.zero,
            (g, x, y) => new Cell(g, x, y));
    }

    public string GetXY(Vector3 pos) {
        var go = grid.GetGridObject(pos);
        return go.ToString();
    }
    
    public void SetCellTransform(int x, int y, Transform t) {
        grid.GetGridObject(x, y).SetCellTransform(t);
    }

    public void AddBattleUnit(int x, int y, BattleUnit bu, Transform t) {
        grid.GetGridObject(x, y).AddBattleUnit(bu, t);
    }

    public void RemoveBattleUnit(int x, int y) {
        grid.GetGridObject(x, y).RemoveBattleUnit();
    }
}
