using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 1f;
    [SerializeField] private float shakeMagnitude = 1f;
    [SerializeField] private float dampingSpeed = 1f;

    private Vector3 initialPosition;
    private float shakeTimer;



    private void OnEnable()
    {
        Ship.OnShake += TriggerShake;
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeTimer -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeTimer = 0;
            transform.localPosition = initialPosition;
        }


    }

    public void TriggerShake()
    {
        shakeTimer = shakeDuration;
    }
}
