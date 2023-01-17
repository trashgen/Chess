using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleUnit", menuName = "BattleUnits/BattleUnitSO", order = 1)]
public class BattleUnitSO : ScriptableObject {
    public enum Type {
        Pawn
    }
    
    public Transform pfVisual;
    public Type type;
    public float speed;
    public int health;
}
