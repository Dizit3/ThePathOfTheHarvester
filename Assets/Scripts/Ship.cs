using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shipHP;

    [SerializeField] int shipLives = 5;

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

}
