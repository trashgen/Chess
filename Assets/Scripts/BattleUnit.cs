using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit {
    private int x;
    private int y;
    private GridWrapper grid;
    private SpriteRenderer spriteRenderer;

    public Transform Transform { get; private set; }
    public BattleUnitSO BattleUnitSO { get; private set; }

    public BattleUnit(GridWrapper grid, int x, int y) {
        this.x = x;
        this.y = y;
        this.grid = grid;
    }

    public BattleUnit(GridWrapper grid, Vector3 pos) {
        x = (int) pos.x;
        y = (int) pos.y;
        this.grid = grid;
    }

    public BattleUnit Instantiate(BattleUnitSO so, Transform t) {
        Transform = t;
        BattleUnitSO = so;
        spriteRenderer = t.Find("icon").gameObject.GetComponent<SpriteRenderer>();
        return this;
    }

    public void Select() {
        spriteRenderer.color = Color.green;
        var cellsToMark = grid.ShowAvailableCellsToGo(x, y);
        foreach (var cell in cellsToMark) {
            // cell.
        }
    }
    
    public void Unselect() {
        spriteRenderer.color = Color.white;
    }

    public List<BackgroundCell> MovementTemplate(BattleUnitDB.Type type, int x, int y) {
        var res = new List<BackgroundCell>();
        switch (type) {
            case BattleUnitDB.Type.PawnWhite:
                return res;
            default:
                return null;
        }
    }

}
