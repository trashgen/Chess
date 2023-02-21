using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Chess/Unit/Queen")]
public class QueenUnitSO : AbstractUnitSO
{
    public override List<List<Vector3>> AvailableCellsToMove(UnitGrid grid, UnitCell cell) {
        var toAttack = new List<Vector3>();
        var toMove = new List<Vector3> {
            new(cell.X(), cell.Y())
        };
        var limit = Mathf.Min(grid.Width - cell.X(), grid.Height - cell.Y());
        for (int i = 1; i < limit; i++) {
            if (addCellsToActionLists(grid, cell, cell.X() + i, cell.Y() + i, ref toMove, ref toAttack)) {
                break;
            }
        }
        limit = Mathf.Min(cell.X(), grid.Height - cell.Y() - 1);
        if (limit > 0) {
            for (int i = 1; i <= limit; i++) {
                if (addCellsToActionLists(grid, cell, cell.X() - i, cell.Y() + i, ref toMove, ref toAttack)) {
                    break;
                }
            }
        }
        limit = Mathf.Min(grid.Width - cell.X() - 1, cell.Y());
        if (limit > 0) {
            for (int i = 1; i <= limit; i++) {
                if (addCellsToActionLists(grid, cell, cell.X() + i, cell.Y() - i, ref toMove, ref toAttack)) {
                    break;
                }
            }
        }
        limit = Mathf.Min(cell.X(), cell.Y());
        for (int i = 1; i <= limit; i++) {
            if (addCellsToActionLists(grid, cell, cell.X() - i, cell.Y() - i, ref toMove, ref toAttack)) {
                break;
            }
        }
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
