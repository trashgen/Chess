using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventListListVector3 : UnityEvent<List<List<Vector3>>> { }

public class GameEventListenerListListVector3 : MonoBehaviour
{
    public GameEventListListVector3 Event;
    public EventListListVector3 Response;

    private void OnEnable() {
        Event.RegisterListener(this);
    }

    private void OnDisable() {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(List<List<Vector3>> posList) {
        Response.Invoke(posList);
    }
}
