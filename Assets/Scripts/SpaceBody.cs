using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpaceBody : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        Rotate();
    }

    private void Rotate()
    {
        rb.AddTorque(new Vector3(Rand(), Rand(), Rand()) *5);
    }

    private float Rand()
    {
        return Random.Range(0f, 1f);
    }
}
