using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cube;


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(cube);
        }
    }



}
