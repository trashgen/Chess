using System.Collections.Generic;
using UnityEngine;

public abstract class IGridHandler : MonoBehaviour {
    protected int x;
    public abstract void Generate();
    public abstract List<Vector3> SelectCellFree(List<Vector3> posList);
    public abstract void ToggleEnterCell(Vector3 pos);
}