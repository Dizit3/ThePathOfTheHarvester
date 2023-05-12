using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject ship;
    [SerializeField] private GameObject shipAnim;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitToMainMenuButton;
    [SerializeField] private Image youLosePlane;


    public static bool isStarted = false;

    public static event Action OnShipMove;


    private void Awake()
    {
        Application.targetFrameRate = 1000;
    }

    private void FixedUpdate()
    {
        if (isStarted)
        {
            if (ship.GetComponent<Ship>().IsAlive)
            {
                OnShipMove.Invoke();
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

}