using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Layout", menuName = "Chess/Unit/Layout")]
public class UnitLayoutSO : ScriptableObject {
    [Serializable]
    public class UnitLayout {
        public AbstractUnitSO unitSO;
        public Vector3 pos;
    }
    
    public List<UnitLayout> units;
}
