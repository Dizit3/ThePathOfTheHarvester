//using System;
//using UnityEngine;

//class EventBus : MonoBehaviour
//{
//    public static EventBus Instance { get; private set; }

//    public event Action<Vector3> On;

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//        else
//        {
//            Destroy(gameObject);
//            return;
//        }
//        DontDestroyOnLoad(gameObject);
//    }


//    public void Subscribe(Action handler)
//    {
//        myEvent += handler;
//    }

//    public void Unsubscribe(Action handler)
//    {
//        myEvent -= handler;
//    }

//    public void Publish(MyEventData eventData)
//    {
//        myEvent?.Invoke(eventData);
//    }
//}

