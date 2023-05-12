using UnityEngine;

namespace Assets.Scripts.SpaceObjects
{
    class ShipHealthWatcher : MonoBehaviour
    {
        private Ship ship;


        private void Awake()
        {
            ship = gameObject.GetComponent<Ship>();

            ship.OnHealthChanged += HealthWatcher;
        }


        private void HealthWatcher(float health)
        {
            if (health <= 0)
            {
                    ship.IsAlive = false;
            }
        }

    }
}
