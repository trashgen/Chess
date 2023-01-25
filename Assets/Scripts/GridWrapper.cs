using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridWrapper
{
    private Grid<BackgroundCell> gridBackground;
    private Grid<BattleUnit> gridUnit;

    public int Width => gridBackground.GetWidth();
    public int Height => gridBackground.GetHeight();

    public GridWrapper() {
        gridBackground = new Grid<BackgroundCell>(8, 8, 10f, Vector3.zero,
            (g, x, y) => new BackgroundCell(g, x, y));
        gridUnit = new Grid<BattleUnit>(8, 8, 10f, Vector3.zero,
            (g, x, y) => null);
    }

    public void SetBackgroundCell(Transform t) {
        gridBackground.GetGridObject(t.position).Instantiate(t);
    }

    public void AddBattleUnitToCell(BattleUnit bu) {
        gridUnit.SetGridObject(bu.Transform.position, bu);
    }

    public void RemoveBattleUnitFromCell(BattleUnit bu) {
        gridUnit.SetGridObject(bu.Transform.position, null);
    }

    public BattleUnit GetBattleUnit(Vector3 pos) {
        return gridUnit.GetGridObject(pos);
    }
    
    public Vector3 CalcBattleUnitPost(int x, int y) {
        return new Vector3(x, y) * gridUnit.GetCellSize() + Vector3.one * gridUnit.GetCellSize() * .5f;
    }
    
    public List<BackgroundCell> ShowAvailableCellsToGo(int x, int y) {
        var res = new List<BackgroundCell>();
        
        return res;
    }

}
