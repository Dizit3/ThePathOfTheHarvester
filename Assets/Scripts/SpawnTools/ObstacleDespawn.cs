using UnityEngine;

public class ObstacleDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            other.gameObject.SetActive(false);
        }
    }

}
