using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float spaceShipPadding = 1f;

    float xMin;
    float xMax;
    

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        
    }

    private voit SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        // This is for the bottom left screen, only first value (x) is important.
        xMin = gameCamera.ViewportToPoint(new Vector3(0, 0, 0)).x + spaceShipPadding;
        // This is fot the bottom right screen, with value of 1.
        xMax = gameCamera.ViewportToPoint(new Vector3(1, 0, 0)).x - spaceShipPadding;
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
        var newXPosition = Mathf.Clamp(transform.position.x + movingXPosition, xMin, xMax);
        transform.position = new Vector2(newXPosition, transform.position.y);
    }
}


