using UnityEngine;

public class GlobalManager : Singleton<GlobalManager>
{
    [SerializeField] private InputHandler mInputHandler;

    public InputHandler Input => mInputHandler;

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
    }
}
