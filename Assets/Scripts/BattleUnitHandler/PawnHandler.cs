using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PawnHandler : BattleUnitHandler {

    private BattleUnit _bu;

    public override IBattleUnitHandler Init(BattleUnit bu) {
        _bu = bu;
        return this;
    }

    public override List<LandscapeCell> AvailableCellsToMove() {
        var res = new List<LandscapeCell>();
        // res.Add(_grid.GetBackgroundCell(new Vector3(_bu.X, _bu.Y)));
        // var delta = _grid.LandshaftCell;
        // if (_bu.Y > 4) {
        //     delta *= -1;
        // }
        // var pos = new Vector3(_bu.X, _bu.Y + delta);
        // if (!_grid.HasBattleUnit(pos))
        // {
        //     res.Add(_grid.GetBackgroundCell(pos));
        // }
        // if (_bu.BattleUnitSO().hasFirstMoveBonus) {
        //     delta = _grid.LandshaftCell * 2;
        //     if (_bu.Y > 4) {
        //         delta *= -1;
        //     }
        //     pos = new Vector3(_bu.X, _bu.Y + delta);
        //     if (!_grid.HasBattleUnit(pos))
        //     {
        //         res.Add(_grid.GetBackgroundCell(pos));
        //     }
        // }
        //
        return res;
    }
}
