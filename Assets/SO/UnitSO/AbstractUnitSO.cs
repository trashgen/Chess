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

    public abstract void Init(UnitCell type);
    public abstract List<Vector3> AvailableCellsToMove(UnitGrid grid);
}