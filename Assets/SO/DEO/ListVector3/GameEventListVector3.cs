using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "DEO/EventListVector3"), System.Serializable]
public class GameEventListVector3 : ScriptableObject {
    private List<GameEventListenerListVector3> _listeners = new();

    public virtual void Raise(List<Vector3> posList) {
        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised(posList);
    }

    public virtual void RegisterListener(GameEventListenerListVector3 listener) => _listeners.Add(listener);

    public virtual void UnregisterListener(GameEventListenerListVector3 listener) => _listeners.Remove(listener);
}