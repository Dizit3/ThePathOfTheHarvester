using UnityEngine;


class ShipMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform movingZone;

    private void Awake()
    {
        GameController.OnShipMove += Move;
    }

    private void Move()
    {
        movingZone.position += new Vector3(0, 0, speed * Time.fixedDeltaTime);
    }

}

