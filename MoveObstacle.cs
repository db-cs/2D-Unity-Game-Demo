using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [HideInInspector] public float speed;

    void FixedUpdate()
    {
        transform.position += new Vector3(-speed, 0, 0);
    }
}
