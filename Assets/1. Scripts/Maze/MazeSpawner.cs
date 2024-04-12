using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Vector3 _cellSize;

    [SerializeField] private int _width;
    [SerializeField] private int _height;

    public Maze maze;

    private void Start()
    {
        MazeGenerator generator = new MazeGenerator(_width, _height);
        maze = generator.GenerateMaze();

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                Cell c = Instantiate(_cellPrefab, new Vector3(x * _cellSize.x, y * _cellSize.y, y * _cellSize.z), Quaternion.identity);

                c.wallLeft.SetActive(maze.cells[x, y].wallLeft);
                c.wallBottom.SetActive(maze.cells[x, y].wallBottom);
            }
        }
    }
}