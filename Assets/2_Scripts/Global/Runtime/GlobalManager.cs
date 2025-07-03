using UnityEngine;

public class GlobalManager : Singleton<GlobalManager>
{
    [SerializeField] private InputHandler mInputHandler;
    [SerializeField] private CamHandler mCamHandler;
    [SerializeField] private UIHandler mUIHandler;

    public InputHandler Input => mInputHandler;
    public CamHandler Cam => mCamHandler;
    public UIHandler UI => mUIHandler;

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
        mUIHandler.Setup(this);
    }
}
