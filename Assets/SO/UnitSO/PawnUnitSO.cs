using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Chess/Unit/Pawn")]
public class PawnUnitSO : AbstractUnitSO
{
    public override void Init(UnitCell cell) {
        throw new System.NotImplementedException();
    }

    public override List<Vector3> AvailableCellsToMove(UnitGrid grid) {
        var res = new List<Vector3>();
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

        return res;
    }
}
