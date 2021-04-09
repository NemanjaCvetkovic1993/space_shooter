using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Time.deltaTime makes every computer to work the same, regardless of their FPS
        var movingXPosition = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPosition = transform.position.x + movingXPosition;
        transform.position = new Vector2(newXPosition, transform.position.y);
    }
}
