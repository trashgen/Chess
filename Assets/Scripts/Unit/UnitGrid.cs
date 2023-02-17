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

    private UnitCell _enteredCell;
    private UnitCell _selectedCell;
    private Grid<UnitCell> _grid;
    
    private void Awake() {
        _grid = new Grid<UnitCell>(width, height, cellSize, Vector3.zero,
            (g, x, y) => new UnitCell(g, x, y));
    }

    public void Generate() {
        foreach (var u in unitLayoutSO.units) {
            var t = Instantiate(u.unitSO.prefab,
                _grid.CalcVector3(u.pos), quaternion.identity);
            var unit = _grid.GetGridObjectDirect(u.pos);
            unit.Instantiate(u.unitSO, t);
        }
    }

    public List<Vector3> SelectCell(Vector3 pos) { 
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
            }
        }

        if (!ReferenceEquals(_selectedCell, null)) {
            return _selectedCell.Unit.AvailableCellsToMove(this);
        }

        return null;
    }

    public void ToggleEnterCell(Vector3 pos) { }
}