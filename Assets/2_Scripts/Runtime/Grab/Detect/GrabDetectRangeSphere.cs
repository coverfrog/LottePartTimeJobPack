using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Range Sphere", menuName = "Cf/Grab/Range Sphere")]
public class GrabDetectRangeSphere : GrabDetectActor
{
    public override bool Detect(GrabHelper helper, out List<GrabObject> grabObjectList)
    {
        Collider[] colliders = new Collider[helper.DetectCount];
        
        int size = Physics.OverlapSphereNonAlloc(helper.transform.position, helper.DetectDistance, colliders, helper.DetectLayer);
        
        List<GrabObject> temp = new List<GrabObject>();
        
        for (int i = 0; i < size; ++i)
        {
            Collider collider = colliders[i];

            if (!collider.TryGetComponent(out GrabObject grabObject))
            {
                continue;
            }
            
            temp.Add(grabObject);

            float distance = Vector3.Distance(helper.transform.position, grabObject.transform.position);
            
            grabObject.OnDetect(distance);
        }

        grabObjectList = temp.OrderBy(g => g.Distance).ToList();
        
        return grabObjectList.Count > 0;
    }
}
