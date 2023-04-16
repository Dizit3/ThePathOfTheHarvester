using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float swichSideSpeed = 0.5f;

    [SerializeField] private GameObject movingZone;
    [SerializeField] private GameObject ship;

    public bool isStarted = false;


    private int lineToMove = 1;
    private int lineCount = 2;

    private Vector3 shipCenter;

    private void Start()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
        shipCenter = ship.transform.position;
    }


    private void FixedUpdate()
    {
        if (isStarted)
        {
            Move();

            var shipPos = ship.transform.position;

            SwitchLile(shipPos);
        }
    }

    public void StartGame()
    {
        isStarted = true;
    }
    private void Move()
    {
        movingZone.transform.position += new Vector3(0, 0, speed * Time.fixedDeltaTime);
    }
    private void SwitchLile(Vector3 shipPos)
    {
        switch (lineToMove)
        {
            case 0:
                ship.transform.position = Vector3.Lerp(,  - new Vector3(4f, shipPos.y, shipPos.z) , swichSideSpeed);
                break;
            case 1:
                ship.transform.position = Vector3.Lerp(, , swichSideSpeed);
                break;
            case 2:
                ship.transform.position = Vector3.Lerp(,  + new Vector3(4f, shipPos.y, shipPos.z), swichSideSpeed); 
                break;
            default:
                break;
        }
    }
    private void OnSwipe(Vector2 direction)
    {
        if (direction == Vector2.right)
        {
            lineToMove = Mathf.Clamp(++lineToMove, 0, lineCount);
        }
        else if (direction == Vector2.left)
        {
            lineToMove = Mathf.Clamp(--lineToMove, 0, lineCount);
        }
    }

}







