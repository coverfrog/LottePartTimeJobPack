using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopAssistant mShopAssistant;

    [Button]
    private void GameStart()
    {
        Utils.Logs.Log("게임 시작");
    }
}
