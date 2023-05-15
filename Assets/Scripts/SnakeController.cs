using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class SnakeController : MonoBehaviour
{
    [SerializeField] private float _movementDelay;
    private Transform _snakeHolder;
    private bool _canMove = true;
    private Vector3 _currentDirectionVector;

    private void Start()
    {
        _snakeHolder = transform.parent;
    }

    private void FixedUpdate()
    {
        GetCurrentMoveVector();
        if(_canMove)
            StartCoroutine(Move());
    }

    private void GetCurrentMoveVector()
    {
        _currentDirectionVector = GetComponent<InputHandler>().CurrentDirectionVector;
    }

    private IEnumerator Move()
    {
        _canMove = false;
        yield return new WaitForSeconds(_movementDelay);
        
        Vector3 currentSnakePartPosition = transform.position;
        transform.position += _currentDirectionVector;
        CheckEdges();
        MoveBodyParts(currentSnakePartPosition);
        
        _canMove = true;
    }

    private void CheckEdges()
    {
        float minX = -7.5f, maxX = 7.5f, minY = -4f, maxY = 4f;
        
        Vector3 currentPostition = transform.position;
        
        if(currentPostition.x < minX)
            currentPostition = new Vector3(maxX, currentPostition.y, 0);
        else if(currentPostition.x > maxX)
            currentPostition = new Vector3(minX, currentPostition.y, 0);
        else if(currentPostition.y < minY)
            currentPostition = new Vector3(currentPostition.x, maxY, 0);
        else if(currentPostition.y > maxY)
            currentPostition = new Vector3(currentPostition.x, minY, 0);
        
        transform.position = currentPostition;
    }

    private void MoveBodyParts(Vector3 currentSnakePartPosition)
    {
        for(int i = 1; i < _snakeHolder.childCount; i++)
        {
            GameObject currentSnakePart = _snakeHolder.GetChild(i).gameObject;
            
            var tmpPosition = currentSnakePart.transform.position;
            currentSnakePart.transform.position = currentSnakePartPosition;
            currentSnakePartPosition = tmpPosition;
        }
    }
}