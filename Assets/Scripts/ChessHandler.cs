using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey;
using CodeMonkey.Utils;
using UnityEngine;

public class ChessHandler : MonoBehaviour {
    [SerializeField] private Map map;
    
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var pos = UtilsClass.GetMouseWorldPosition();
            map.SetCell(pos);
            map.SelectCell(pos);
        }
    }
}
