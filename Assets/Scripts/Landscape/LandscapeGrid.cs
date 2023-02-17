using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LandscapeGrid : MonoBehaviour {
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    [SerializeField] private LandscapeSO landscapeSO;
    [SerializeField] private StringValue posDataRef;

    private LandscapeCell _enteredCell;
    private LandscapeCell _selectedCell;
    private Grid<LandscapeCell> _grid;

    private void Awake() {
        _grid = new Grid<LandscapeCell>(width, height, cellSize, Vector3.zero,
            (g, x, y) => new LandscapeCell(g, x, y));
    }

    public void Generate() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                var pos = _grid.CalcVector3(x, y);
                var t = Instantiate(landscapeSO.prefabs[(x + y) % 2],
                    pos, quaternion.identity);
                var cell = _grid.GetGridObject(x, y);
                cell.Instantiate(landscapeSO, t);
            }
        }
    }

    public List<Vector3> SelectCellFree(List<Vector3> posList) {
        Vector3 pos = Vector3.zero;
        if (posList.Count == 1) {
            pos = posList[0];
        }

        if (ReferenceEquals(_selectedCell, null)) {
            _selectedCell = _grid.GetGridObject(pos);
            _selectedCell?.SelectFree();
        }
        else {
            var cell = _grid.GetGridObject(pos);
            if (!ReferenceEquals(cell, null)) {
                if (cell == _selectedCell) {
                    _selectedCell.UnselectFree();
                    _selectedCell = null;
                }
                else {
                    cell.SelectFree();
                    _selectedCell.UnselectFree();
                    _selectedCell = cell;
                }
            }
        }

        return null;
    }

    public void SelectCellBlocked(Vector3 pos) {
        if (ReferenceEquals(_selectedCell, null)) {
            _selectedCell = _grid.GetGridObject(pos);
            _selectedCell?.SelectBlocked();
        }
        else {
            var cell = _grid.GetGridObject(pos);
            if (!ReferenceEquals(cell, null)) {
                if (cell == _selectedCell) {
                    _selectedCell.UnselectBlocked();
                    _selectedCell = null;
                }
                else {
                    cell.SelectBlocked();
                    _selectedCell.UnselectBlocked();
                    _selectedCell = cell;
                }
            }
        }
    }

    public void ToggleEnterCell(Vector3 pos) {
        var cell = _grid.GetGridObject(pos);
        if (_enteredCell == cell) {
            return;
        }

        if (!ReferenceEquals(cell, null)) {
            if (ReferenceEquals(_enteredCell, null)) {
                _enteredCell = cell;
                _enteredCell.OnEnter();
            }
            else {
                if (_enteredCell != cell) {
                    _enteredCell.OnExit();
                    _enteredCell = cell;
                    _enteredCell.OnEnter();
                }
            }

            int x, y;
            _grid.GetXY(pos, out x, out y);
            posDataRef.value = $"[{x}, {y}]";
        }
    }

    public void MarkCells(List<Vector3> posList) {
        foreach (var p in posList) {
            var cell = _grid.GetGridObject(p);
            cell.Mark();
        }
    }

    public void UnmarkCells(List<Vector3> posList) { }
}