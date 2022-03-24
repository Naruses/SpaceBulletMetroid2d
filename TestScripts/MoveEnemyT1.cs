using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyT1 : MonoBehaviour
{
    public float moveSpeed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        if (pos.x < -2)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
            
    }
}
