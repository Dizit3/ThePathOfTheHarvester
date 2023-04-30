using UnityEngine;

public class GoldAsteroid : MonoBehaviour, IWeighted
{

    [SerializeField] private int weight = 1;

    private bool isRotate;

    private Rigidbody rb;

    public readonly int price = 50;

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

    public int GetWeight()
    {
        return weight;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

}