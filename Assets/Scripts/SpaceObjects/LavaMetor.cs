using UnityEngine;

class LavaMetor : SpaceBody
{
    private bool isRotate;

    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isRotate)
        {
            Rotate();

            isRotate = true;
        }

    }

    private void Rotate()
    {
        rb.AddTorque(new Vector3(Rand(), Rand(), Rand()) * 3);
    }

    private float Rand()
    {
        return Random.Range(-1f, 1f);
    }

}
