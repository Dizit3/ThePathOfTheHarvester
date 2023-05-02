using System;
using UnityEngine;

class LavaMetor : MonoBehaviour, IWeighted
{
    private Rigidbody rb;
    [SerializeField] private int weight = 5;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.velocity = Vector3.zero;
        Rotate();
    }

    public int GetWeight()
    {
        return weight;
    }


    private void Rotate()
    {
        rb.AddTorque(new Vector3(Rand(), Rand(), Rand()) * 3);
    }

    private float Rand()
    {
        return UnityEngine.Random.Range(-1f, 1f);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
