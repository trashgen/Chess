using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : MonoBehaviour {
    [SerializeField] private BattleUnitHandler handler;
    [SerializeField] private Transform pfVisual;
    [SerializeField] private BattleUnitSO battleUnitSO;

    private List<LandscapeCell> _markedCells;

    public BattleUnitSO BattleUnitSO() => battleUnitSO;
    
    public int X { get;  }
    public int Y { get;  }

    public Transform Transform { get; private set;  }

    private BattleUnit(int x, int y) {
        X = x;
        Y = y;
    }

    public BattleUnit Spawn(int startX, int startY) {
        return Spawn(new Vector3(startX, startY));
    }

    public BattleUnit Spawn(Vector3 pos) {
        handler = pfVisual.GetComponent<BattleUnitHandler>();
        Transform = Instantiate(pfVisual, pos, Quaternion.identity);
        return this;
    }


    public void Select() {
        // _markedCells = handler.AvailableCellsToMove();
        // if (!ReferenceEquals(_markedCells, null)) {
        //     for (int i = 0; i < _markedCells.Count; i++) {
        //         if (i == 0) {
        //             _markedCells[i].Select();
        //         }
        //         else {
        //             _markedCells[i].Mark();
        //         }
        //     }
        // }
    }
    
    public void Unselect() {
        if (!ReferenceEquals(_markedCells, null)) {
            for (int i = 0; i < _markedCells.Count; i++) {
                if (i == 0) {
                    _markedCells[i].UnselectFree();
                }
                else {
                    _markedCells[i].Unmark();
                }
            }
            _markedCells.Clear();
        }
    }

}
