using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Landscape", menuName = "Chess/Landscape/Prefabs")]
public class LandscapeSO : ScriptableObject {
    public List<Transform> prefabs;
}
