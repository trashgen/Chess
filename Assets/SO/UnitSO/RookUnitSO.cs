using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Chess/Unit/Rook")]
public class RookUnitSO : AbstractUnitSO
{
    public override List<List<Vector3>> AvailableCellsToMove(UnitGrid grid, UnitCell cell) {
        var toAttack = new List<Vector3>();
        var toMove = new List<Vector3> {
            new(cell.X(), cell.Y())
        };
        for (int i = cell.X() - 1; i >= 0; i--) {
            if (addCellsToActionLists(grid, cell, i, cell.Y(), ref toMove, ref toAttack)) {
                break;
            }
        }
        for (int i = cell.X() + 1; i < grid.Width; i++) {
            if (addCellsToActionLists(grid, cell, i, cell.Y(), ref toMove, ref toAttack)) {
                break;
            }
        }
        for (int i = cell.Y() - 1; i >= 0; i--) {
            if (addCellsToActionLists(grid, cell, cell.X(), i, ref toMove, ref toAttack)) {
                break;
            }
        }
        for (int i = cell.Y() + 1; i < grid.Height; i++) {
            if (addCellsToActionLists(grid, cell, cell.X(), i, ref toMove, ref toAttack)) {
                break;
            }
        }
        return new List<List<Vector3>> {
            toMove,
            toAttack
        };
    }
}
