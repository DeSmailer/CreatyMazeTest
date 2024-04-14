using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] private Key _keyPrefab;
    [SerializeField] private Vector3 _offset;

    public List<Key> Spawn(Maze maze, int count)
    {
        HashSet<MazeGeneratorCell> randomCells = SelectCells(maze, count);
        List<Key> keys = new List<Key>();

        foreach (var cell in randomCells)
        {
            Key key = Instantiate(_keyPrefab, transform, true);
            key.transform.position = new Vector3(cell.x, 0, cell.y) + _offset;
            keys.Add(key);
        }

        return keys;
    }

    private HashSet<MazeGeneratorCell> SelectCells(Maze maze, int count)
    {
        HashSet<MazeGeneratorCell> randomCells = new HashSet<MazeGeneratorCell>();

        while (randomCells.Count < count)
        {
            int randomX = Random.Range(0, maze.cells.GetLength(0) - 1);
            int randomY = Random.Range(0, maze.cells.GetLength(1) - 1);

            if (!(randomX == 0 && randomY == 0))
            {
                MazeGeneratorCell randomCell = maze.cells[randomX, randomY];

                randomCells.Add(randomCell);
            }
        }
        return randomCells;
    }

    public void Clear()
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
