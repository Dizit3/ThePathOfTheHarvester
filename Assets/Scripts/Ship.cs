using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.EnumStates;

public class Ship : MonoBehaviour
{
    [SerializeField] float shipLives = 100f;

    [SerializeField] private Animator anim;
    [SerializeField] private Slider slider;
     
    public static event OnCameraShake ShakeEvent;
    public delegate void OnCameraShake();



    public States State
    {
        get { return (States)anim.GetInteger("turnDirection"); }
        set { anim.SetInteger("turnDirection", (int)value); }
    }


    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        GameController.InclineEvent += OnIncline;

        slider.value = shipLives;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            shipLives -= 5f;

            ShakeEvent();

            collision.gameObject.SetActive(false);

        }
    }

    private void Update()
    {
        slider.value = Mathf.Lerp(slider.value,shipLives, 0.1f);

        if (shipLives <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void OnIncline(Vector2 direction)
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
