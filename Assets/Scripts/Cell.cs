using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell {
    private int x;
    private int y;
    private Grid<Cell> grid;

    private Transform _transform;
    private BattleUnit _battleUnit;
    private Transform _transformBattleUnit;

    public Cell(Grid<Cell> grid, int x, int y) {
        this.x = x;
        this.y = y;
        this.grid = grid;
    }

    public override string ToString() {
        if (!ReferenceEquals(_battleUnit, null)) {
            return $"{_battleUnit.ToString()}";
        }
        else {
            return "Empty Cell";
        }
    }

    public void SetCellTransform(Transform t) {
        _transform = t;
    }

    public void AddBattleUnit(BattleUnit bu, Transform t) {
        _battleUnit = bu;
        _transformBattleUnit = t;
    }

    public bool HasBattleUnit() {
        return !(ReferenceEquals(_battleUnit, null) && ReferenceEquals(_transformBattleUnit, null));
    }

    public BattleUnit GetBattleUnit() {
        return _battleUnit;
    }

    public Transform GetBattleUnitTransform() {
        return _transformBattleUnit;
    }

    public void RemoveBattleUnit() {
        _battleUnit = null;
        _transformBattleUnit = null;
    }
}
