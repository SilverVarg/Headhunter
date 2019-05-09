using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase : ScriptableObject {

    public virtual void Initialize(DoAction owner) { }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void HandleUpdate() { }
    public virtual void AddMusic(AudioClip audioClip) { }
    public virtual bool Done() { return false; }
}
