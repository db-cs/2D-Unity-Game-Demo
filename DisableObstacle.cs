using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObstacle : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.x < -15)
        {
            gameObject.SetActive(false);
        }
    }
}
