using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookHandler : IBattleUnitHandler {

    private BattleUnit _bu;
    
    public IBattleUnitHandler Init(BattleUnit bu) {
        _bu = bu;
        return this;
    }

    public List<LandscapeCell> AvailableCellsToMove() {
        var res = new List<LandscapeCell>();
        // var pos = new Vector3(_bu.X, _bu.Y);
        // res.Add(_grid.GetBackgroundCell(pos));
        // int X;
        // int y;
        // _grid.GetBackgroundXY(pos, out X, out y);
        // var maxLeft = X;
        // for (int i = 1; i <= maxLeft; i++) {
        //     pos = new Vector3(_bu.X - i * _grid.LandshaftCell, _bu.Y);
        //     var b = _grid.GetBattleUnit(pos);
        //     if (!ReferenceEquals(b, null)) {
        //         break;
        //     }
        //     res.Add(_grid.GetBackgroundCell(pos));
        // }
        // var maxRight = _grid.Width - X;
        // for (int i = 1; i < maxRight; i++) {
        //     pos = new Vector3(_bu.X + i * _grid.LandshaftCell, _bu.Y);
        //     var b = _grid.GetBattleUnit(pos);
        //     if (!ReferenceEquals(b, null)) {
        //         break;
        //     }
        //     res.Add(_grid.GetBackgroundCell(pos));
        // }
        // var maxBot = y;
        // for (int i = 1; i <= maxBot; i++) {
        //     pos = new Vector3(_bu.X, _bu.Y - i * _grid.LandshaftCell);
        //     var b = _grid.GetBattleUnit(pos);
        //     if (!ReferenceEquals(b, null)) {
        //         break;
        //     }
        //     res.Add(_grid.GetBackgroundCell(pos));
        // }
        // var maxTop = _grid.Height - y;
        // for (int i = 1; i < maxTop; i++) {
        //     pos = new Vector3(_bu.X, _bu.Y + i * _grid.LandshaftCell);
        //     var b = _grid.GetBattleUnit(pos);
        //     if (!ReferenceEquals(b, null)) {
        //         break;
        //     }
        //     res.Add(_grid.GetBackgroundCell(pos));
        // }
        return res;
    }
}
