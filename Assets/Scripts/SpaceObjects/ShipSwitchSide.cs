using System;
using UnityEngine;

class ShipSwitchSide : MonoBehaviour
{
    private float swichSideSpeed = 0.5f;

    private int lineToMove = 2;
    private int lineCount = 4;

    public static event Action<Vector2> OnIncline;

    private Vector3 targetPosition;


    private void Awake()
    {

        SwipeDetection.OnSwipe += Swipe;
        Idle.OnIdle += IdleState;
        targetPosition = transform.position;
    }

    private void Update()
    {
        SwitchLile();
    }
    private void SwitchLile()
    {

        switch (lineToMove)
        {
            case 0:
                targetPosition = new Vector3(-4f, transform.position.y, transform.position.z);
                break;
            case 1:
                targetPosition = new Vector3(-2f, transform.position.y, transform.position.z);
                break;
            case 2:
                targetPosition = new Vector3(0f, transform.position.y, transform.position.z);
                break;
            case 3:
                targetPosition = new Vector3(2f, transform.position.y, transform.position.z);
                break;
            case 4:
                targetPosition = new Vector3(4f, transform.position.y, transform.position.z);
                break;
            default:
                break;


        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, swichSideSpeed);

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

