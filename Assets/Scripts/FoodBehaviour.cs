using UnityEngine;

public class FoodBehaviour: MonoBehaviour
{
    private void Start()
    {
        Spawn();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        InputHandler inputHandler = other.gameObject.GetComponent<InputHandler>();
        if(inputHandler != null)
            Spawn();
    }

    private void Spawn()
    {
        Vector3 newPostiion = new Vector3(Random.Range(-8, 8), Random.Range(-4, 5), 0);
        transform.localPosition = newPostiion;
    }
}