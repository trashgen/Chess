using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Chess/Unit/King")]
public class KingUnitSO : AbstractUnitSO
{
    public override List<List<Vector3>> AvailableCellsToMove(UnitGrid grid, UnitCell cell) {
        var toAttack = new List<Vector3>();
        var toMove = new List<Vector3> {
            new(cell.X(), cell.Y())
        };
        addCellsToActionLists(grid, cell, cell.X() + 1, cell.Y() + 1, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() - 1, cell.Y() - 1, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() - 1, cell.Y() + 1, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() + 1, cell.Y() - 1, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X(), cell.Y() + 1, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() + 1, cell.Y(), ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X(), cell.Y() - 1, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() - 1, cell.Y(), ref toMove, ref toAttack);
        return new List<List<Vector3>> {
            toMove,
            toAttack
        };
    }
}
