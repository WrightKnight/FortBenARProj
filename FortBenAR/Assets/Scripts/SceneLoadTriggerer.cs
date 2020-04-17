using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneLoadTriggerer : MonoBehaviour
{
    public UnityEvent OnStart;
    void Start()
    {
        if (OnStart == null) {
            OnStart = new UnityEvent();

            OnStart.AddListener(Ping);
        }

        OnStart.Invoke();

    }

    void Ping()
    {
        Debug.Log("Ping");
    }
}
