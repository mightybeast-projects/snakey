using UnityEngine;

public class OnTriggerAddSnakePart: MonoBehaviour
{
    [SerializeField] private GameObject _snakePart;
    [SerializeField] private Transform _snakeHolder;
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        FoodBehaviour fb = other.gameObject.GetComponent<FoodBehaviour>();
        if(fb != null)
            AddSnakePart();
    }

    private void AddSnakePart()
    {
        Vector3 lastSnakePartLocation = 
            _snakeHolder.GetChild(_snakeHolder.childCount - 1).gameObject.transform.position;
        GameObject newSnakePart = Instantiate(_snakePart, _snakeHolder);
        newSnakePart.transform.position = lastSnakePartLocation;
    }
}