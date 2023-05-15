using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Transform _gridHolder;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private int _tileCounter;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for(int i = 0; i < _tileCounter; i++)
            Instantiate(_tilePrefab, _gridHolder);
    }
}