using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateSpeed = 1;

    void Update()
    {
        transform.Rotate(rotateSpeed, rotateSpeed, rotateSpeed, Space.World);
    }
}
