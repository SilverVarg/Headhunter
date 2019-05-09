using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : ActionBase
{
   
    protected DoAction owner;

    // Methods
  

    public override void Initialize(DoAction owner)
    {
        this.owner = (DoAction)owner;
    }
    


}