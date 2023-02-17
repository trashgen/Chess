using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleUnitHandler {
    public IBattleUnitHandler Init(BattleUnit bu);
    public List<LandscapeCell> AvailableCellsToMove();
}
