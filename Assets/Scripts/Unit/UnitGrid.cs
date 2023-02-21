using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UnitGrid : MonoBehaviour {
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    [SerializeField] private UnitLayoutSO unitLayoutSO;
    [SerializeField] private StringValue unitNameDataRef;
    [SerializeField] private GameEventListListVector3 onMarkMovableCells;
    [SerializeField] private GameEventEmpty onUnmarkMovableCells;

    private UnitCell _enteredCell;
    private UnitCell _selectedCell;
    private Grid<UnitCell> _grid;

    public int Width => width;
    public int Height => height;

    public Grid<UnitCell> Grid() => _grid;
    
    private void Awake() {
        _grid = new Grid<UnitCell>(width, height, cellSize, Vector3.zero,
            (g, x, y) => new UnitCell(g, x, y));
    }

    private void Start() {
        Generate();
    }

    public bool IsEmpty(int x, int y) {
        return ReferenceEquals(_grid.GetGridObjectDirect(x, y)?.Unit, null);
    }

    public bool HasCell(int x, int y) {
        return !ReferenceEquals(_grid.GetGridObjectDirect(x, y), null);
    }

    public bool HasWhiteUnit(int x, int y) {
        var unit = _grid.GetGridObjectDirect(x, y)?.Unit;
        if (ReferenceEquals(unit, null)) {
            return false;
        }

        return unit.side == AbstractUnitSO.Side.White;
    }

    public bool HasBlackUnit(int x, int y) {
        var unit = _grid.GetGridObjectDirect(x, y)?.Unit;
        if (ReferenceEquals(unit, null)) {
            return false;
        }

        return unit.side == AbstractUnitSO.Side.Black;
    }

    private void Generate() {
        foreach (var u in unitLayoutSO.units) {
            var t = Instantiate(u.unitSO.prefab,
                _grid.CalcVector3(u.pos), quaternion.identity);
            var unit = _grid.GetGridObjectDirect(u.pos);
            unit.Instantiate(u.unitSO, t);
        }
    }

    public void SelectCell(Vector3 pos) { 
        if (ReferenceEquals(_selectedCell, null)) {
            _selectedCell = _grid.GetGridObject(pos);
        }
        else {
            var cell = _grid.GetGridObject(pos);
            if (!ReferenceEquals(cell, null)) {
                if (cell == _selectedCell) {
                    _selectedCell = null;
                }
                else {
                    _selectedCell = cell;
                }
                onUnmarkMovableCells.Raise();
            }
        }
        if (!ReferenceEquals(_selectedCell?.Unit, null)) {
            onMarkMovableCells.Raise(_selectedCell?.Unit.AvailableCellsToMove(this, _selectedCell));
        }
        else {
            onUnmarkMovableCells.Raise();
        }
    }

    public void ToggleEnterCell(Vector3 pos) { }
}