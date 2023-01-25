using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleUnit", menuName = "BattleUnits/BattleUnitSO", order = 1)]
public class BattleUnitSO : ScriptableObject {
    public Transform pfVisual;
    public BattleUnitDB.Type type;
    public float speed = 1;
    public int health = 1;
    public int damage = 1;
}
