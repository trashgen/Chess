using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "DEO/EventEmpty"), System.Serializable]
public class GameEventEmpty : ScriptableObject {
    private List<GameEventListenerEmpty> _listeners = new();

    public virtual void Raise() {
        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised();
    }

    public virtual void RegisterListener(GameEventListenerEmpty listener) => _listeners.Add(listener);

    public virtual void UnregisterListener(GameEventListenerEmpty listener) => _listeners.Remove(listener);
}
