using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleUnitHandler : MonoBehaviour, IBattleUnitHandler {
    public abstract IBattleUnitHandler Init(BattleUnit bu);
    public abstract List<LandscapeCell> AvailableCellsToMove();
}
