using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>
{
}

public class GameEventListenerVector3 : MonoBehaviour
{
    public GameEventVector3 Event;
    public EventVector3 Response;
 
    private void OnEnable(){ Event.RegisterListener(this); }
 
    private void OnDisable(){ Event.UnregisterListener(this); }
 
    public void OnEventRaised(Vector3 pos){ Response.Invoke(pos); }
}
