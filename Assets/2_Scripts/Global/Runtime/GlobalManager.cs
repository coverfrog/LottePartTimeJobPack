using UnityEngine;

public class GlobalManager : Singleton<GlobalManager>
{
    [SerializeField] private InputHandler mInputHandler;
    [SerializeField] private CamHandler mCamHandler;

    public InputHandler Input => mInputHandler;

    public CamHandler Cam => mCamHandler;

    protected override void Awake()
    {
        // base
        base.Awake();
        
        // awake
        Setup();
    }

    private void Setup()
    {
        mInputHandler.Setup(this);
        mCamHandler.Setup(this);
    }
}
