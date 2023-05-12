using System;
using UnityEngine;

class ShipSwitchSide : MonoBehaviour
    {
    private float swichSideSpeed = 0.5f;

    private Vector3 shipPos;
    

    private int lineToMove = 2;
    private int lineCount = 4;

    public static event Action<Vector2> OnIncline;


    private void Awake()
    {
        shipPos = gameObject.GetComponent<Ship>().transform.position;
        SwipeDetection.OnSwipe += Swipe;
        Idle.OnIdle += IdleState;

    }

    private void SwitchLile()
    {
        switch (lineToMove)
        {
            case 0:
                transform.position = Vector3.Lerp(transform.position, new Vector3(-4f, transform.position.y, transform.position.z), swichSideSpeed);
                break;
            case 1:
                transform.position = Vector3.Lerp(transform.position, new Vector3(-2f, transform.position.y, transform.position.z), swichSideSpeed);
                break;
            case 2:
                transform.position = Vector3.Lerp(transform.position, new Vector3(0f, transform.position.y, transform.position.z), swichSideSpeed);
                break;
            case 3:
                transform.position = Vector3.Lerp(transform.position, new Vector3(2f, transform.position.y, transform.position.z), swichSideSpeed);
                break;
            case 4:
                transform.position = Vector3.Lerp(transform.position, new Vector3(4f, transform.position.y, transform.position.z), swichSideSpeed);
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
            SwitchLile();
        }
        else if (direction == Vector2.left)
        {
            lineToMove = Mathf.Clamp(--lineToMove, 0, lineCount);

            OnIncline?.Invoke(direction);
            SwitchLile();
        }
    }

    private void IdleState()
    {
        OnIncline?.Invoke(Vector2.zero);
    }

}

