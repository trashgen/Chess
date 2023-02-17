using CodeMonkey;
using UnityEngine;

public class ChessInput : MonoBehaviour {
    [SerializeField] private Map map;

    private Camera _camera;

    private void Start() {
        _camera = Camera.main;
    }

    private void Update() {
        if ((Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0)) {
            var pos = GetMouseWorldPosition();
            map.ToggleEnterCell(pos);
        }
        if (Input.GetMouseButtonDown(0)) {
            var pos = GetMouseWorldPosition();
            // map.SetCell(pos);
            map.SelectCell(pos);
        }
        if (Input.GetMouseButtonDown(1)) {
            var pos = GetMouseWorldPosition();
            map.RemoveBattleUnit(pos);
        }
        if (Input.GetMouseButtonDown(2)) {
            var pos = GetMouseWorldPosition();
            map.SpawnRook(pos);
            CMDebug.TextPopupMouse($"{pos.ToString()}");
        }
    }
    
    private Vector3 GetMouseWorldPosition() {
        Vector3 vec = _camera.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }

}
