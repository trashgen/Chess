using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractUnitSO : ScriptableObject {
    public enum Side {
        White,
        Black
    }

    public UnitTypeSO type;
    public Side side;
    public Transform prefab;

    public abstract List<List<Vector3>> AvailableCellsToMove(UnitGrid grid, UnitCell cell);
    
    protected bool addCellsToActionLists(UnitGrid grid, UnitCell cell, int x, int y, ref List<Vector3> toMove, ref List<Vector3> toAttack) {
        if (grid.HasCell(x, y)) {
            if (grid.IsEmpty(x, y)) {
                toMove.Add(new Vector3(x, y));
            }
            else {
                if (cell.Unit.side == Side.White) {
                    if (grid.HasBlackUnit(x, y)) {
                        toAttack.Add(new Vector3(x, y));
                    }
                }
                else {
                    if (grid.HasWhiteUnit(x, y)) {
                        toAttack.Add(new Vector3(x, y));
                    }
                }

                return true;
            }
        }

        return false;
    }
}