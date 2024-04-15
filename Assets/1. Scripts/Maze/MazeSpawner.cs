using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Door _doorPrefab;

    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [SerializeField] private Maze _maze;
    [SerializeField] private Door _door;
    
    public Maze Maze => _maze;
    public Door Door => _door;

    public void Respawn()
    {
        ClearMaze();
        Spawn();
    }

    public void Spawn()
    {
        MazeGenerator generator = new MazeGenerator(_width, _height);
        _maze = generator.GenerateMaze();

        SpawnWalls();
        SpawnDoor();
    }

    private void SpawnWalls()
    {
        for (int x = 0; x < _maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < _maze.cells.GetLength(1); y++)
            {
                Cell c = Instantiate(_cellPrefab, new Vector3(x, 0, y), Quaternion.identity, transform);

                c.wallLeft.SetActive(_maze.cells[x, y].wallLeft);
                c.wallBottom.SetActive(_maze.cells[x, y].wallBottom);
                c.floor.SetActive(_maze.cells[x, y].floor);
            }
        }
    }

    private void SpawnDoor()
    {
        if (_maze.mazeDoorCell.bottom)
        {
            _door = Instantiate(_doorPrefab,
             new Vector3(_maze.mazeDoorCell.x, 0, _maze.mazeDoorCell.y) + _cellPrefab.wallBottom.transform.position,
        _cellPrefab.wallBottom.transform.rotation * Quaternion.Euler(0, 180, 0),
             transform);
        }
        if (_maze.mazeDoorCell.top)
        {
            _door = Instantiate(_doorPrefab,
                new Vector3(_maze.mazeDoorCell.x, 0, _maze.mazeDoorCell.y) + _cellPrefab.wallBottom.transform.position,
               _cellPrefab.wallBottom.transform.rotation,
                transform);
        }
        else if (_maze.mazeDoorCell.left)
        {
            _door = Instantiate(_doorPrefab,
                new Vector3(_maze.mazeDoorCell.x, 0, _maze.mazeDoorCell.y) + _cellPrefab.wallLeft.transform.position,
                _cellPrefab.wallLeft.transform.rotation,
                transform);
        }
        else if (_maze.mazeDoorCell.rigt)
        {
            _door = Instantiate(_doorPrefab,
                new Vector3(_maze.mazeDoorCell.x, 0, _maze.mazeDoorCell.y) + _cellPrefab.wallLeft.transform.position,
              _cellPrefab.wallLeft.transform.rotation * Quaternion.Euler(0, 180, 0),
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