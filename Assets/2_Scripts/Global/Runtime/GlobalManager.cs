using Sirenix.OdinInspector;
using UnityEngine;

public class GlobalManager : Singleton<GlobalManager>
{
    [Title("References")]
    [SerializeField] private InputHandler mInputHandler;
    [SerializeField] private CamHandler mCamHandler;
    [SerializeField] private DataHandler mDataHandler;
    [SerializeField] private UIHandler mUIHandler;

    public InputHandler Input => mInputHandler;
    public CamHandler Cam => mCamHandler;
    public DataHandler Data => mDataHandler;
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
        mDataHandler.Setup(this);
        mUIHandler.Setup(this);
    }
}
