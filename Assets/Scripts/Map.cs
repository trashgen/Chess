using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    [SerializeField] private UnitGrid unit;
    [SerializeField] private LandscapeGrid landscape;

    private void Start() {
        unit.Generate();
        landscape.Generate();
    }

    public void SpawnRook(Vector3 pos) {

    }

    public void SelectCell(Vector3 pos) {
        var cellsToMove = unit.SelectCell(pos);
        if (!ReferenceEquals(cellsToMove, null)) {
            landscape.SelectCellFree(new List<Vector3>{pos});
            landscape.MarkCells(cellsToMove);
        }
        else {
            landscape.SelectCellBlocked(pos);
        }
    }

    public void ToggleEnterCell(Vector3 pos) {
        unit.ToggleEnterCell(pos);
        landscape.ToggleEnterCell(pos);
    }

    public void RemoveBattleUnit(Vector3 pos) {

    }
}