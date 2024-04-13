using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] private Key _keyPrefab;
    [SerializeField] private Vector3 _offset;

    public void Spawn(Maze maze, int count)
    {
        List<MazeGeneratorCell> randomCells = SelectCells(maze, count);
        foreach (var cell in randomCells)
        {
            Key key = Instantiate(_keyPrefab, transform, true);
            key.transform.position = new Vector3(cell.x, 0, cell.y) + _offset;
        }
    }

    private List<MazeGeneratorCell> SelectCells(Maze maze, int count)
    {
        List<MazeGeneratorCell> randomCells = new List<MazeGeneratorCell>();

        for (int i = 0; i < count; i++)
        {
            int randomX = Random.Range(0, maze.cells.GetLength(0) - 1);
            int randomY = Random.Range(0, maze.cells.GetLength(1) - 1);

            MazeGeneratorCell randomCell = maze.cells[randomX, randomY];

            randomCells.Add(randomCell);
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
