using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Door _doorPrefab;

    [SerializeField] private int _width;
    [SerializeField] private int _height;

    public Maze maze;

    public void Respawn()
    {
        ClearMaze();
        Spawn();
    }

    public void Spawn()
    {
        MazeGenerator generator = new MazeGenerator(_width, _height);
        maze = generator.GenerateMaze();

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                Cell c = Instantiate(_cellPrefab, new Vector3(x, 0, y), Quaternion.identity, transform);

                c.wallLeft.SetActive(maze.cells[x, y].wallLeft);
                c.wallBottom.SetActive(maze.cells[x, y].wallBottom);
            }
        }
        Door d;
        if (maze.mazeDoorCell.bottom)
        {
            d = Instantiate(_doorPrefab,
                new Vector3(maze.mazeDoorCell.x, 0, maze.mazeDoorCell.y) + _cellPrefab.wallBottom.transform.position,
               _cellPrefab.wallBottom.transform.rotation,
                transform);
        }
        if (maze.mazeDoorCell.left)
        {
            d = Instantiate(_doorPrefab,
                new Vector3(maze.mazeDoorCell.x, 0, maze.mazeDoorCell.y) + _cellPrefab.wallLeft.transform.position,
                _cellPrefab.wallLeft.transform.rotation,
                transform);
        }
    }

    public void ClearMaze()
    {
        Transform[] children = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
        }

        foreach (Transform child in children)
        {
            Destroy(child.gameObject);
        }
    }
}