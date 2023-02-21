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

    private List<List<Vector3>> _markedCells;
    private LandscapeCell _enteredCell;
    private LandscapeCell _selectedCell;
    private LandscapeCell _blockedCell;
    private Grid<LandscapeCell> _grid;

    private void Awake() {
        _grid = new Grid<LandscapeCell>(width, height, cellSize, Vector3.zero,
            (g, x, y) => new LandscapeCell(g, x, y));
    }

    private void Start() {
        Generate();
    }

    private void Generate() {
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

    public void SelectCell(Vector3 pos) {
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

        _blockedCell?.UnselectBlocked();
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

    public void MarkCells(List<List<Vector3>> posList) {
        if (posList[0].Count == 1) { // only cell w/ selected unit
            var cell = _grid.GetGridObjectDirect(posList[0][0]);
            cell?.SelectBlocked();
            _blockedCell = cell;
            return;
        }
        _markedCells = posList;
        // Mark cells to Move without selected cell
        for (int i = 1; i < _markedCells[0].Count; i++) {
            _grid.GetGridObjectDirect(_markedCells[0][i]).Mark();
        }
        // Mark cells to Attack without selected cell
        foreach (var c in _markedCells[1]) {
            _grid.GetGridObjectDirect(c).MarkAttack();
        }
    }

    public void UnmarkCells() {
        _blockedCell?.UnselectBlocked();
        if (ReferenceEquals(_markedCells, null)) {
            return;
        }
        foreach (var c in _markedCells[0]) {
            _grid.GetGridObjectDirect(c).Unmark();
        }
        foreach (var c in _markedCells[1]) {
            _grid.GetGridObjectDirect(c).UnmarkAttack();
        }
        _markedCells = null;
    }
}