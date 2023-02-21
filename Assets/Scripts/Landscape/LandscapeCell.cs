using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeCell {
    private int _x;
    private int _y;
    private Grid<LandscapeCell> _grid;

    private Transform _transform;
    private LandscapeSO _landscape;
    private GameObject _mark;
    private GameObject _onEnter;
    private GameObject _attackMarker;
    private GameObject _selectionFree;
    private GameObject _selectionBlocked;

    public LandscapeCell(Grid<LandscapeCell> grid, int x, int y) {
        _x = x;
        _y = y;
        _grid = grid;
    }

    public void Instantiate(LandscapeSO landscape, Transform t) {
        _mark = t.Find("mark").gameObject;
        _onEnter = t.Find("infoActiveBorder").gameObject;
        _attackMarker = t.Find("attackMarker").gameObject;
        _selectionFree = t.Find("freeSelectionBorder").gameObject;
        _selectionBlocked = t.Find("blockedSelectionBorder").gameObject;
        _landscape = landscape;
        _transform = t;
    }

    public void Mark() {
        _mark.SetActive(true);
    }

    public void Unmark() {
        _mark.SetActive(false);
    }

    public void MarkAttack() {
        _attackMarker.SetActive(true);
    }

    public void UnmarkAttack() {
        _attackMarker.SetActive(false);
    }

    public void OnEnter() {
        _onEnter.SetActive(true);
    }

    public void OnExit() {
        _onEnter.SetActive(false);
    }

    public void SelectFree() {
        _selectionFree.SetActive(true);
    }

    public void UnselectFree() {
        _selectionFree.SetActive(false);
    }

    public void SelectBlocked() {
        _selectionBlocked.SetActive(true);
    }

    public void UnselectBlocked() {
        _selectionBlocked.SetActive(false);
    }

}
