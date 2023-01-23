using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit {
    private Transform transform;
    private Transform iconTransform;
    private BattleUnitSO battleUnitSO;
    private SpriteRenderer spriteRenderer;

    public Transform UnitTransform() => transform;
    public Transform VisualTransform() => iconTransform;
    public BattleUnitSO BattleUnitSO() => battleUnitSO;

    public BattleUnit(BattleUnitSO so, Transform t, Transform it) {
        transform = t;
        battleUnitSO = so;
        iconTransform = it;
        spriteRenderer = it.gameObject.GetComponent<SpriteRenderer>();
    }

    public void Select() {
        spriteRenderer.color = Color.green;
    }
    
    public void Unselect() {
        spriteRenderer.color = Color.white;
    }

}
