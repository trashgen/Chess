using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "DEO/EventListListVector3"), System.Serializable]
public class GameEventListListVector3 : ScriptableObject {
    private List<GameEventListenerListListVector3> _listeners = new();

    public virtual void Raise(List<List<Vector3>> posList) {
        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised(posList);
    }

    public virtual void RegisterListener(GameEventListenerListListVector3 listener) => _listeners.Add(listener);

    public virtual void UnregisterListener(GameEventListenerListListVector3 listener) => _listeners.Remove(listener);
}
