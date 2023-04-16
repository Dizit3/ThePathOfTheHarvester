using UnityEngine;


class TouchDetection : MonoBehaviour
{

    private bool isMobile;

    public static event OnTouchInput TouchEvent;
    public delegate void OnTouchInput(bool isTouch);

    private bool isTouch = false;

    private void Start()
    {
        isMobile = Application.isMobilePlatform;
    }



    private void Update()
    {

        if (!isMobile && TouchEvent != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TouchEvent(isTouch = true);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                TouchEvent(isTouch = false);

            }
        }
        else if (Input.touchCount > 0 && TouchEvent != null)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                TouchEvent(isTouch = true);

            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                TouchEvent(isTouch = false);
            }
        }

    }

}

