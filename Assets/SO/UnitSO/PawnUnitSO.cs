using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Chess/Unit/Pawn")]
public class PawnUnitSO : AbstractUnitSO
{
    public override List<List<Vector3>> AvailableCellsToMove(UnitGrid grid, UnitCell cell) {
        var res = new List<List<Vector3>>();
        res.Add(findCellsToMove(grid, cell));
        res.Add(findCellsToAttack(grid, cell));
        return res;
    }

    private List<Vector3> findCellsToMove(UnitGrid grid, UnitCell cell) {
        var cellsToMove = new List<Vector3>();
        cellsToMove.Add(new Vector3(cell.X(), cell.Y()));
        if (cell.Unit.side == Side.White) {
            if (!grid.IsEmpty(cell.X(), cell.Y() + 1)) {
                return cellsToMove;
            }
            cellsToMove.Add(new Vector3(cell.X(), cell.Y() + 1));

            if (!grid.IsEmpty(cell.X(), cell.Y() + 2)) {
                return cellsToMove;
            }
            cellsToMove.Add(new Vector3(cell.X(), cell.Y() + 2));
        }
        else {
            if (!grid.IsEmpty(cell.X(), cell.Y() - 1)) {
                return cellsToMove;
            }
            cellsToMove.Add(new Vector3(cell.X(), cell.Y() - 1));

            if (!grid.IsEmpty(cell.X(), cell.Y() - 2)) {
                return cellsToMove;
            }
            cellsToMove.Add(new Vector3(cell.X(), cell.Y() - 2));
        }

        return cellsToMove;
    }

    private List<Vector3> findCellsToAttack(UnitGrid grid, UnitCell cell) {
        var cellsToAttack = new List<Vector3>();
        if (cell.Unit.side == Side.White) {
            if (grid.HasBlackUnit(cell.X() + 1, cell.Y() + 1)) {
                cellsToAttack.Add(new Vector3(cell.X() + 1, cell.Y() + 1));
            }
            if (grid.HasBlackUnit(cell.X() - 1, cell.Y() + 1)) {
                cellsToAttack.Add(new Vector3(cell.X() - 1, cell.Y() + 1));
            }
        }
        else {
            if (grid.HasWhiteUnit(cell.X() - 1, cell.Y() - 1)) {
                cellsToAttack.Add(new Vector3(cell.X() - 1, cell.Y() - 1));
            }
            if (grid.HasWhiteUnit(cell.X() + 1, cell.Y() - 1)) {
                cellsToAttack.Add(new Vector3(cell.X() + 1, cell.Y() - 1));
            }
        }

        return cellsToAttack;
    }
}
