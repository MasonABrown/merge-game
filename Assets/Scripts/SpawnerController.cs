using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    // movement speed
    [SerializeField] private float _spawnerMovementSpeed;
    
    // rigidbody to access movement 
    private Rigidbody2D rb;

    //boundaries for movement 
    public float minX;
    public float maxX;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        SpawnerMovementBehavior();
    }

    private void SpawnerMovementBehavior()
    {
        float _horizontalAxisInput = Input.GetAxis("Horizontal");

        // Calculate the velocity vector
        Vector2 moveVelocity = new Vector2(_horizontalAxisInput * _spawnerMovementSpeed, rb.linearVelocity.y);

        // Limit the object's movement within the specified X range
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        //Debug.Log("Current X: " + transform.position.x + " Clamped X: " + clampedX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Apply the velocity to the Rigidbody2D
        if (transform.position.x != minX ||  transform.position.x != maxX)
        {
            rb.linearVelocity = moveVelocity;
        }
        
    }
}
