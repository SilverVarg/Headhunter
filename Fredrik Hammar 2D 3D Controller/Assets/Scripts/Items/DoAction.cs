using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAction : MonoBehaviour {

    public ActionBase UsingAction;
    public bool ItemDestroy;
    private bool EnterUsed = false;
    // Use this for initialization
    void Awake () {
      //  ActionBase instance = Instantiate(UsingAction);
        UsingAction.Initialize(this);
        EnterUsed = false;
        Debug.Log("Dothis");
        UsingAction.Enter();
        //UsingAction.Enter();
    }
    void Start()
    {
        Debug.Log("Dothis");
        UsingAction.Enter();
    }
        // Update is called once per frame
    void Update () {
        if (EnterUsed = false)
        {
            Debug.Log("Dothis");
            UsingAction.Enter();
            EnterUsed = true;
        }
        UsingAction.HandleUpdate();
    }
    public void AddMusic(AudioClip audioClips)
    {
       
        UsingAction.AddMusic(audioClips);
    }
    public bool Donewiththelevel()
    {
       return UsingAction.Done();
    }

    public bool ShouldItemBeDestroyed()
    {
        return ItemDestroy;
    }
    public void SetItemDestroyed(bool D)
    {
        ItemDestroy = D;
        Debug.Log("ItemDesto" + ItemDestroy);
    }
    public ActionBase getUsingAction()
    {
        return UsingAction;
    }
}
