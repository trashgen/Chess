using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CellInfoVisual : MonoBehaviour {
    [SerializeField] private StringValue posInfo;
    [SerializeField] private StringValue unitNameInfo;
    [SerializeField] private TextMeshProUGUI posTextRef;
    [SerializeField] private TextMeshProUGUI unitNameTextRef;
    private void Update() {
        posTextRef.text = posInfo.value;
        unitNameTextRef.text = unitNameInfo.value;
    }
}
