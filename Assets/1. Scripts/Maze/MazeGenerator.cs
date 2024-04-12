using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator
{
    public int width;
    public int height;

    public MazeGenerator(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public Maze GenerateMaze()
    {
        MazeGeneratorCell[,] cells = new MazeGeneratorCell[width, height];

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new MazeGeneratorCell { x = x, y = y };
            }
        }

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            cells[x, height - 1].wallLeft = false;
        }

        for (int y = 0; y < cells.GetLength(1); y++)
        {
            cells[width - 1, y].wallBottom = false;
        }

        RemoveWallsWithBacktracker(cells);

        Maze maze = new Maze();

        maze.cells = cells;
        maze.finishPosition = PlaceMazeExit(cells);

        return maze;
    }

    private void RemoveWallsWithBacktracker(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell current = maze[0, 0];
        current.visited = true;
        current.distanceFromStart = 0;

        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();

        do
        {
            List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();

            int x = current.x;
            int y = current.y;

            if (x > 0 && !maze[x - 1, y].visited)
            {
                unvisitedNeighbours.Add(maze[x - 1, y]);
            }
            if (y > 0 && !maze[x, y - 1].visited)
            {
                unvisitedNeighbours.Add(maze[x, y - 1]);
            }
            if (x < width - 2 && !maze[x + 1, y].visited)
            {
                unvisitedNeighbours.Add(maze[x + 1, y]);
            }
            if (y < height - 2 && !maze[x, y + 1].visited)
            {
                unvisitedNeighbours.Add(maze[x, y + 1]);
            }

            if (unvisitedNeighbours.Count > 0)
            {
                MazeGeneratorCell chosen = unvisitedNeighbours[Random.Range(0, unvisitedNeighbours.Count)];
                RemoveWall(current, chosen);

                chosen.visited = true;
                stack.Push(chosen);
                chosen.distanceFromStart = current.distanceFromStart + 1;
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }
        }
        while (stack.Count > 0);
    }

    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
    {
        if (a.x == b.x)
        {
            if (a.y > b.y)
            {
                a.wallBottom = false;
            }
            else
            {
                b.wallBottom = false;
            }
        }
        else
        {
            if (a.x > b.x)
            {
                a.wallLeft = false;
            }
            else
            {
                b.wallLeft = false;
            }
        }
    }

    private Vector2Int PlaceMazeExit(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell furthest = maze[0, 0];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            if (maze[x, height - 2].distanceFromStart > furthest.distanceFromStart)
            {
                furthest = maze[x, height - 2];
            }
            if (maze[x, 0].distanceFromStart > furthest.distanceFromStart)
            {
                furthest = maze[x, 0];
            }
        }

        for (int y = 0; y < maze.GetLength(1); y++)
        {
            if (maze[width - 2, y].distanceFromStart > furthest.distanceFromStart)
            {
                furthest = maze[width - 2, y];
            }
            if (maze[0, y].distanceFromStart > furthest.distanceFromStart)
            {
                furthest = maze[0, y];
            }
        }

        if (furthest.x == 0)
        {
            furthest.wallLeft = false;
        }
        else if (furthest.y == 0)
        {
            furthest.wallBottom = false;
        }
        else if (furthest.x == width - 2)
        {
            maze[furthest.x + 1, furthest.y].wallLeft = false;
        }
        else if (furthest.y == height - 2)
        {
            maze[furthest.x, furthest.y + 1].wallBottom = false;
        }

        return new Vector2Int(furthest.x, furthest.y);
    }
}