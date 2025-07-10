using System.Collections.Generic;
using UnityEngine;

public abstract class GrabDetectActor : ScriptableObject
{
    public abstract bool Detect(GrabHelper helper, out List<GrabObject> grabObjectList);
}
