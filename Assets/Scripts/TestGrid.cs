using UnityEngine;
using CodeMonkey.Utils;

public class TestGrid : MonoBehaviour
{
    private Grid grid;

    [SerializeField] private int gridHeight;
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridSize;
    [SerializeField] private Color gridColor;
    [SerializeField] private Color textColor;

    private int _gridHeight;
    private int _gridWidth;
    private int _gridSize;
    private Color _gridColor;
    private Color _textColor;
    void Start()
    {
        grid = new Grid(gridHeight, gridWidth, gridSize, gridColor, textColor);

        _gridHeight = gridHeight;
        _gridWidth = gridWidth;
        _gridSize = gridSize;
        _gridColor = gridColor;
        _textColor = textColor;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           grid.SetValue(UtilsClass.GetMouseWorldPosition(),65);
        }

        
    }
    private void LateUpdate()
    {
        CheckIfValueChanged();
    }
    private void CheckIfValueChanged()
    {
        if (_gridHeight != gridHeight ||
            _gridWidth  != gridWidth ||
            _gridSize   != gridSize ||
            _gridColor  != gridColor ||
            _textColor != textColor)
        {
            _gridHeight = gridHeight;
            _gridWidth = gridWidth;
            _gridSize = gridSize;
            _gridColor = gridColor;
            _textColor = textColor;

            grid.ReArrangeGrid(_gridHeight = gridHeight,
            _gridWidth = gridWidth,
            _gridSize = gridSize,
            _gridColor = gridColor,
            _textColor = textColor);

        }
    }

}
