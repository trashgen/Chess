using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCell {
    private int _x;
    private int _y;
    private Grid<UnitCell> _grid;

    private AbstractUnitSO _unit;
    private GameObject _selection;
    private Transform _transform;

    public int X() => _x;
    public int Y() => _y;
    public AbstractUnitSO Unit => _unit;

    public UnitCell(Grid<UnitCell> grid, int x, int y) {
        _x = x;
        _y = y;
        _grid = grid;
    }

    public void Instantiate(AbstractUnitSO unit, Transform t) {
        _unit = unit;
        _transform = t;
    }

    public bool IsEmpty() {
        return ReferenceEquals(_unit, null);
    }
    
    public void Select() {
        _selection.SetActive(true);
    }

    public void Unselect() {
        _selection.SetActive(false);
    }
}