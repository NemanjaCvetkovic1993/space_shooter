using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is to destroy instance of every laser firing, when leaves the screen.

public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
