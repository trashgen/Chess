using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "DEO/EventVector3"), System.Serializable]
public class GameEventVector3 : ScriptableObject {
    private List<GameEventListenerVector3> _listeners = new();

    public virtual void Raise(Vector3 pos) {
        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised(pos);
    }

    public virtual void RegisterListener(GameEventListenerVector3 listener) => _listeners.Add(listener);

    public virtual void UnregisterListener(GameEventListenerVector3 listener) => _listeners.Remove(listener);
}