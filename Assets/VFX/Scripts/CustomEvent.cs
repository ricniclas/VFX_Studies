using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomEvent : MonoBehaviour
{
    public static CustomEvent SharedInstance;
    private static UnityEvent myEvent;

    private float myFloat;
    private bool myBool;
    // Start is called before the first frame update
    void Start()
    {
        if(myEvent == null)
            myEvent = new UnityEvent();
    }

    void Awake()
    {
        SharedInstance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            myEvent.Invoke();
        }
    }


    public void subscribeEvent(UnityAction action) => myEvent.AddListener(action);
    public void unsubscribeEvent(UnityAction action) => myEvent.RemoveListener(action);


    public void something() => myFloat = myBool ? 10 : 20;

    IEnumerator corrotine()
    {
        yield return new WaitUntil(() => myBool);
    }
}
