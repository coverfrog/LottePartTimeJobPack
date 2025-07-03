using System;
using System.Collections.Generic;
using UnityEngine;

public class CamHandler : GlobalHandler
{
    private Dictionary<CamType, List<Cam>> _mCamDict;
    
    private GlobalManager _mGlobalManager;

    public Cam GetMainCam()
    {
        return _mCamDict[CamType.Main][0];
    }
    
    public override void Setup(GlobalManager globalManager)
    {
        _mGlobalManager = globalManager;
        _mCamDict = new Dictionary<CamType, List<Cam>>()
        {
            { CamType.Main, new List<Cam>() },
            { CamType.UI, new List<Cam>() }
        };
    }

    public void Sub(Cam cam)
    {
        switch (cam.Option.CamType)
        {
            case CamType.Main:
                _mCamDict[CamType.Main].Add(cam);
                break;
            case CamType.UI:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void UnSub(Cam cam)
    {
        switch (cam.Option.CamType)
        {
            case CamType.Main:
                break;
            case CamType.UI:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
