using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Vector3 _currentDirectionVector = new Vector3(0, 1f, 0);

    public Vector3 CurrentDirectionVector => _currentDirectionVector;

    private void FixedUpdate()
    {
        HandleInput();
    }
    
    private void HandleInput()
    {
        if(Input.GetKey(KeyCode.W))
            _currentDirectionVector = new Vector3(0, 1f, 0);
        else if(Input.GetKey(KeyCode.S))
            _currentDirectionVector = new Vector3(0, -1f, 0);
        else if(Input.GetKey(KeyCode.D))
            _currentDirectionVector = new Vector3(1f, 0, 0);
        else if(Input.GetKey(KeyCode.A))
            _currentDirectionVector = new Vector3(-1f, 0, 0);
    }
}
