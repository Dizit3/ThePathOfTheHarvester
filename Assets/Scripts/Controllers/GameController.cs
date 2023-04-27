using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float swichSideSpeed = 0.5f;

    [SerializeField] private GameObject movingZone;
    [SerializeField] private GameObject ship;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI totalScore;




    public static bool isStarted = false;

    public static event Action<Vector2> InclineEvent;

    private int lineToMove = 2;
    private int lineCount = 4;


    public static int valuableMetals;

    private void Start()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
        Idle.IdleEvent += OnIdle;
        Ship.AddMoneyEvent += AddMoney;

        totalScore.text = "0";

    }

    private void AddMoney(int obj)
    {
        var score = int.Parse(totalScore.text) + obj;

        totalScore.text = Convert.ToString(score);
    }

    private void Awake()
    {
        Application.targetFrameRate = 1000;
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
        exitButton.gameObject.SetActive(false);
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

            InclineEvent?.Invoke(direction);
        }
        else if (direction == Vector2.left)
        {
            lineToMove = Mathf.Clamp(--lineToMove, 0, lineCount);

            InclineEvent?.Invoke(direction);
        }
    }

    private void OnIdle()
    {
        InclineEvent?.Invoke(Vector2.zero);
    }
}