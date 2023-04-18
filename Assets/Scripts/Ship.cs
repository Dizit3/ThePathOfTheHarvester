using TMPro;
using UnityEngine;
using static Assets.Scripts.EnumStates;

public class Ship : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shipHP;

    [SerializeField] int shipLives = 5;

     public Animator anim;

    public States State
    {
        get { return (States)anim.GetInteger("turnDirection"); }
        set { anim.SetInteger("turnDirection", (int)value); }
    }


    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        GameController.InclineEvent += OnIncline;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            shipLives--;

            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        shipHP.text = $"HP {shipLives}";

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
        else if(direction == Vector2.left)
        {
            State = States.leftIncline;
        }
        else
        {
            State = States.idle;
        }
    }
}
