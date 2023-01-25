using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCell {
    private int x;
    private int y;
    private Grid<BackgroundCell> grid;

    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    public BackgroundCell(Grid<BackgroundCell> grid, int x, int y) {
        this.x = x;
        this.y = y;
        this.grid = grid;
    }

    public void Instantiate(Transform t) {
        _transform = t;
        _spriteRenderer = t.Find("background").GetComponent<SpriteRenderer>();
    }

}
