using UnityEngine;

public class Idle : MonoBehaviour
{
    public static event OnIdle IdleEvent;
    public delegate void OnIdle();



    public void OnIdleState()
    {
        IdleEvent();
    }
}
