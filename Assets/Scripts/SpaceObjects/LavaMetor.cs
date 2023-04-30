using UnityEngine;

class LavaMetor : MonoBehaviour , IWeighted
{
    private bool isRotate;

    private Rigidbody rb;
    [SerializeField]private int weight = 5;

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
        return Random.Range(-1f, 1f);
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }
}
