using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventListVector3 : UnityEvent<List<Vector3>> { }

public class GameEventListenerListVector3 : MonoBehaviour {
    public GameEventListVector3 Event;
    public EventListVector3 Response;

    private void OnEnable() {
        Event.RegisterListener(this);
    }

    private void OnDisable() {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(List<Vector3> posList) {
        Response.Invoke(posList);
    }
}