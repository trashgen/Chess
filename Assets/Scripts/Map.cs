using UnityEngine;

public class Map : MonoBehaviour {
    [SerializeField] private GameEventVector3 onSelectEvent;
    [SerializeField] private GameEventVector3 onMouseMove;

    public void SelectCell(Vector3 pos) {
        onSelectEvent.Raise(pos);
    }

    public void ToggleEnterCell(Vector3 pos) {
        onMouseMove.Raise(pos);
    }

    public void RemoveBattleUnit(Vector3 pos) { }
}