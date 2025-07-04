using Sirenix.OdinInspector;
using UnityEngine;

public class SceneGame0 : SceneGame
{
    [Title("References")]
    [SerializeField] private OrderHandler mOrderHandler;
    
    #region Start

    protected override void Start()
    {
        // base
        base.Start();
        
        //
        mOrderHandler.OnStart(this);
    }

    #endregion
}