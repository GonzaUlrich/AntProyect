using UnityEngine;
using CodeMonkey.Utils;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    public Grid(int width, int height, float cellSize, Color gridColor, Color textColor)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        Singletons();

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x,y] = UtilsClass.CreateWorldText(gridArray[x,y].ToString(),null, GetWorldPos(x,y) + new Vector3(cellSize,cellSize) * .5f,20, textColor, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPos(x,y),GetWorldPos(x,y+1), gridColor, 0.100f);
                Debug.DrawLine(GetWorldPos(x, y), GetWorldPos(x + 1, y), gridColor, 0.100f);
            }
            Debug.DrawLine(GetWorldPos(0, height), GetWorldPos(width ,height), gridColor, 0.100f);
            Debug.DrawLine(GetWorldPos(width, 0), GetWorldPos(width, height), gridColor, 0.100f);
        }
    }


    private Vector3 GetWorldPos(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    private void GetXY(Vector3 wolrdPos, out int x , out int y)
    {
        x = Mathf.FloorToInt(wolrdPos.x/cellSize);
        y = Mathf.FloorToInt(wolrdPos.y / cellSize);
    }

    private void SetValue(int x, int y, int value)
    {
        if(x >= 0 && y >= 0 && x < width && y < height) { 
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }


    public void SetValue(Vector3 woldPos, int value)
    {
        int x, y;
        GetXY(woldPos, out x, out y);
        SetValue(x, y, value);
    }

    private void Singletons()
    {
        if (gridArray == null || debugTextArray == null)
        {
            gridArray = new int[width, height];
            debugTextArray = new TextMesh[width, height];
        }
        
    }

    public void ReArrangeGrid(int width, int height, float cellSize, Color gridColor, Color textColor)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        Singletons();

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPos(x, y) + new Vector3(cellSize, cellSize) * .5f, 20, textColor, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPos(x, y), GetWorldPos(x, y + 1), gridColor, 100f);
                Debug.DrawLine(GetWorldPos(x, y), GetWorldPos(x + 1, y), gridColor, 100f);
            }
            Debug.DrawLine(GetWorldPos(0, height), GetWorldPos(width, height), gridColor, 100f);
            Debug.DrawLine(GetWorldPos(width, 0), GetWorldPos(width, height), gridColor, 100f);
        }
    }
    public void SaveGrid()
    {

    }

}
