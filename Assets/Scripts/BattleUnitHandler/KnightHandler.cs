using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHandler : IBattleUnitHandler {

    private BattleUnit _bu;

    public IBattleUnitHandler Init(BattleUnit bu) {
        _bu = bu;
        return this;
    }

    public List<LandscapeCell> AvailableCellsToMove() {
        var res = new List<LandscapeCell>();
        // var pos = new Vector3(_bu.X, _bu.Y);
        // res.Add(_grid.GetBackgroundCell(pos));
        // pos = _grid.GetBackgroundXY(pos);
        // // RightUp
        // var xLimit = _grid.Width - pos.x;
        // var yLimit = _grid.Height - pos.y;
        // var limit = Mathf.Min(xLimit, yLimit);
        // for (int i = 1; i < limit; i++) {
        //      var p = new Vector3(_bu.X + i * _grid.LandshaftCell, _bu.Y + i * _grid.LandshaftCell);
        //      var b = _grid.GetBattleUnit(p);
        //      if (!ReferenceEquals(b, null)) {
        //          break;
        //      }
        //      res.Add(_grid.GetBackgroundCell(p));
        // }
        // // LeftDown
        // xLimit = pos.x;
        // yLimit = pos.y;
        // limit = Mathf.Min(xLimit, yLimit);
        // for (int i = 1; i <= limit; i++) {
        //     var p = new Vector3(_bu.X - i * _grid.LandshaftCell, _bu.Y - i * _grid.LandshaftCell);
        //     var b = _grid.GetBattleUnit(p);
        //     if (!ReferenceEquals(b, null)) {
        //         break;
        //     }
        //     res.Add(_grid.GetBackgroundCell(p));
        // }
        // // RightDown
        // xLimit = _grid.Width - pos.x;
        // yLimit = _grid.Height - pos.y;
        // limit = Mathf.Max(xLimit, yLimit);
        // for (int i = 1; i <= limit; i++) {
        //     var p = new Vector3(_bu.X + i * _grid.LandshaftCell, _bu.Y - i * _grid.LandshaftCell);
        //     var b = _grid.GetBattleUnit(p);
        //     if (!ReferenceEquals(b, null)) {
        //         break;
        //     }
        //     var unit = _grid.GetBackgroundCell(p);
        //     if (!ReferenceEquals(unit, null)) {
        //         res.Add(unit);
        //     }
        // }
        // // LeftUp
        // xLimit = _grid.Width - pos.x;
        // yLimit = _grid.Height - pos.y;
        // limit = Mathf.Max(xLimit, yLimit);
        // for (int i = 1; i <= limit; i++) {
        //     var p = new Vector3(_bu.X - i * _grid.LandshaftCell, _bu.Y + i * _grid.LandshaftCell);
        //     var b = _grid.GetBattleUnit(p);
        //     if (!ReferenceEquals(b, null)) {
        //         break;
        //     }
        //     var unit = _grid.GetBackgroundCell(p);
        //     if (!ReferenceEquals(unit, null)) {
        //         res.Add(unit);
        //     }
        // }

        return res;
    }
}