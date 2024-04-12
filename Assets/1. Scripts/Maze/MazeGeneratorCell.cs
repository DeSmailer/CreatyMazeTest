public class MazeGeneratorCell
{
    public int x;
    public int y;

    public bool wallLeft = true;
    public bool wallBottom = true;

    public bool visited = false;
    public int distanceFromStart;
}
