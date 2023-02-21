using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Chess/Unit/Bishop")]
public class BishopUnitSO : AbstractUnitSO
{
    public override List<List<Vector3>> AvailableCellsToMove(UnitGrid grid, UnitCell cell) {
        var toAttack = new List<Vector3>();
        var toMove = new List<Vector3> {
            new(cell.X(), cell.Y())
        };
        addCellsToActionLists(grid, cell, cell.X() + 1, cell.Y() + 2, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() - 1, cell.Y() + 2, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() + 2, cell.Y() + 1, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() + 2, cell.Y() - 1, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() - 1, cell.Y() - 2, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() + 1, cell.Y() - 2, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() - 2, cell.Y() + 1, ref toMove, ref toAttack);
        addCellsToActionLists(grid, cell, cell.X() - 2, cell.Y() - 1, ref toMove, ref toAttack);
        return new List<List<Vector3>> {
            toMove,
            toAttack
        };
    }
}