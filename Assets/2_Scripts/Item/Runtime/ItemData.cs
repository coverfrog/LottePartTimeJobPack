using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Cf/Item/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string mDisplayName;
    
    public string CodeName => name;

    public string DisplayName => mDisplayName;
}
