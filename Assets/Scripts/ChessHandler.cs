using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey;
using CodeMonkey.Utils;
using UnityEngine;

public class ChessHandler : MonoBehaviour {
    [SerializeField] private ChessVisual chessVisual;
    
    private Map map;
    
    private void Start() {
        map = new Map();
        chessVisual.Setup(map);
    }

    private void Update() {
        var pos = UtilsClass.GetMouseWorldPosition();

        if (Input.GetMouseButtonDown(0)) {
            chessVisual.SelectCell(pos);
            CMDebug.TextPopupMouse(map.GetXY(pos));
        }
    }
}
