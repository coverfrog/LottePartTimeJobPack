using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Yield 사용시 new 최소화를 위한 Class
/// </summary>
public static class StaticYield
{
    private static readonly Dictionary<float, WaitForSeconds> SecDict = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds Sec(float sec)
    {
        if (!SecDict.TryGetValue(sec, out WaitForSeconds waitForSeconds))
        {
            SecDict.Add(sec, new WaitForSeconds(sec));
        }

        return SecDict[sec];
    }

    public static WaitForEndOfFrame EndOfFrame { get; } = new WaitForEndOfFrame();

    public static WaitForFixedUpdate FixedUpdate { get; } = new WaitForFixedUpdate();

}
