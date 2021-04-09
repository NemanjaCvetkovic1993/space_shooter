using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float spaceShipPadding = 1f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 22f;

    float xMin;
    float xMax;
    

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        
    }
 

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        // Time.deltaTime makes every computer to work the same, regardless of their FPS
        var movingXPosition = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPosition = Mathf.Clamp(transform.position.x + movingXPosition, xMin, xMax);
        transform.position = new Vector2(newXPosition, transform.position.y);
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1")) {
            GameObject laser =  Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
        }
    }
    
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        // This is for the bottom left screen, only first value (x) is important.
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + spaceShipPadding;
        // This is for the bottom right screen, with value of 1.
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - spaceShipPadding;
    }
}


