using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private float swichSideSpeed = 0.5f;

    [SerializeField] private GameObject ship;
    [SerializeField] private GameObject shipAnim;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitToMainMenuButton;
    [SerializeField] private Image youLosePlane;


    public static bool isStarted = false;

    public static event Action<Vector2> OnIncline;
    public static event Action OnShipMove;

    private int lineToMove = 2;
    private int lineCount = 4;

    public static int valuableMetals;

    private void Awake()
    {
        Application.targetFrameRate = 1000;
    }
    private void Start()
    {
        SwipeDetection.OnSwipe += Swipe;
        Idle.OnIdle += IdleState;
    }
    private void FixedUpdate()
    {
        if (isStarted)
        {
            if (ship.GetComponent<Ship>().IsAlive)
            {
                OnShipMove.Invoke();

                var shipPos = ship.transform.position;

                SwitchLile(shipPos);
            }
            else
            {
                EndGame();
            }
        }
    }

    public void StartGame()
    {
        isStarted = true;
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

    }
    private void EndGame()
    {
        isStarted = false;
        //var anim = shipAnim.gameObject.GetComponent<Animator>();
        //anim.enabled = false;
        exitToMainMenuButton.gameObject.SetActive(true);
        youLosePlane.gameObject.SetActive(true);


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
    private void Swipe(Vector2 direction)
    {
        if (direction == Vector2.right)
        {
            lineToMove = Mathf.Clamp(++lineToMove, 0, lineCount);

            OnIncline?.Invoke(direction);
        }
        else if (direction == Vector2.left)
        {
            lineToMove = Mathf.Clamp(--lineToMove, 0, lineCount);

            OnIncline?.Invoke(direction);
        }
    }
    private void IdleState()
    {
        OnIncline?.Invoke(Vector2.zero);
    }
}