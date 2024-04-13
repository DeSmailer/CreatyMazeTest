using UnityEngine;

public class Maze
{
    public MazeGeneratorCell[,] cells;
    public Vector2Int finishPosition;
    public MazeDoorCell mazeDoorCell;
}

public class MazeDoorCell
{
    public int x;
    public int y;

    public bool left = false;
    public bool bottom = false;
}
