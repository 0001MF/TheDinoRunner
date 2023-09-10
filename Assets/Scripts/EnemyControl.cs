using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed;
    public bool MoveRight;

    // Use this for initialization
    void Update()
    {
        // Use this for initialization
        if (MoveRight)
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(3.199219f, 3.88676f);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-3.199219f, 3.88676f);
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {

            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
          
        }
    }
}

	

