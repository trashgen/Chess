using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitSO : ScriptableObject {
    public enum Side {
        White,
        Black
    }

    public BattleUnitTypeSO type;
    public Transform prefab;
    public Side side = Side.White;
    public float speed = 1;
    public int health = 1;
    public int damage = 1;
    public bool hasFirstMoveBonus = false;
}
