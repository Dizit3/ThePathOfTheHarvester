using System;
using UnityEngine;

public class Idle : MonoBehaviour
{
    public static event Action OnIdle;

    public void OnIdleState()
    {
        OnIdle();
    }
}
