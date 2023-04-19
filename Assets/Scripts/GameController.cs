using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float swichSideSpeed = 0.5f;

    [SerializeField] private GameObject movingZone;
    [SerializeField] private GameObject ship;
    [SerializeField] private Button startButton;

    public static bool isStarted = false;


    public static event OnIncline InclineEvent;
    public delegate void OnIncline(Vector2 direction);


    private int lineToMove = 2;
    private int lineCount = 4;

    private void Start()
    {


        SwipeDetection.SwipeEvent += OnSwipe;
        Idle.IdleEvent += OnIdle;
    }

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }


    private void FixedUpdate()
    {
        if (isStarted)
        {
            if (ship != null)
            {
                Move();

                var shipPos = ship.transform.position;

                SwitchLile(shipPos);
            }
            else
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        isStarted = false;
    }
    public void StartGame()
    {
        isStarted = true;
        startButton.gameObject.SetActive(false);

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
                ship.transform.position = Vector3.Lerp(shipPos, new Vector3(-4f, shipPos.y, shipPos.z), swichSideSpeed);
                break;
            case 1:
                ship.transform.position = Vector3.Lerp(shipPos, new Vector3(-2f, shipPos.y, shipPos.z), swichSideSpeed);
                break;
            case 2:
                ship.transform.position = Vector3.Lerp(shipPos, new Vector3(0f, shipPos.y, shipPos.z), swichSideSpeed);
                break;
            case 3:
                ship.transform.position = Vector3.Lerp(shipPos, new Vector3(2f, shipPos.y, shipPos.z), swichSideSpeed);
                break;
            case 4:
                ship.transform.position = Vector3.Lerp(shipPos, new Vector3(4f, shipPos.y, shipPos.z), swichSideSpeed);
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

            InclineEvent(direction);
        }
        else if (direction == Vector2.left)
        {
            lineToMove = Mathf.Clamp(--lineToMove, 0, lineCount);

            InclineEvent(direction);
        }
    }

    private void OnIdle()
    {
        InclineEvent(Vector2.zero);
    }
}