using System;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.EnumStates;

public class Ship : MonoBehaviour
{
    [SerializeField] float shipLives = 100f;
    [SerializeField] private GameObject animShip;
    [SerializeField] private Slider slider;

    public bool IsAlive = true;

    private AudioSource audioSource;
    private Animator animator;

    public event Action<int> OnAddMoney;
    public static event Action OnShake;
    public event Action<float> OnHealthChanged;

    public States State
    {
        get { return (States)animator.GetInteger("turnDirection"); }
        set
        {
            if (animator != null)
            {
                animator.SetInteger("turnDirection", (int)value);
            }
            else
            {
                animator = GameObject.FindGameObjectWithTag("ShipAnim").GetComponentInChildren<Animator>();
            }
        }
    }


    private void Awake()
    {

        animator = animShip.GetComponentInChildren<Animator>();




        GameController.OnIncline += Incline;
        OnHealthChanged += ChangeHPBar;

        slider.value = shipLives;

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            shipLives -= 5f;

            OnHealthChanged?.Invoke(shipLives);
            OnShake?.Invoke();


            collision.gameObject.SetActive(false);

            audioSource.Play();
        }
        else if (collision.gameObject.tag == "Resource")
        {
            var cost = collision.gameObject.GetComponent<GoldAsteroid>().price;

            OnAddMoney?.Invoke(cost);

            collision.gameObject.SetActive(false);

        }
        else if (collision.gameObject.tag == "TestCube")
        {
            collision.gameObject.SetActive(false);


        }
    }

    private void ChangeHPBar(float value)
    {
        slider.value = Mathf.Lerp(slider.value, shipLives, 0.1f);
    }

    public void Incline(Vector2 direction)
    {
        if (direction == Vector2.right)
        {
            State = States.rightIncline;
        }
        else if (direction == Vector2.left)
        {
            State = States.leftIncline;
        }
        else
        {
            State = States.idle;
        }
    }
}
