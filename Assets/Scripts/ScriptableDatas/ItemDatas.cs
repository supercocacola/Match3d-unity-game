using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemData", menuName = "SO/ItemData")]
public class ItemDatas : ScriptableObject
{
    public ModdingType moddingType;
    public List<Sprite> fishModding;
    public List<Sprite> fruitModding;

    public List<Sprite> bonusItem;

    public Sprite GetItemSprite(NormalItem.eNormalType type)
    {
        return moddingType == ModdingType.Fruit ? fruitModding[(int)type] : fishModding[(int)type];
    }

    public Sprite GetBonusSprite(BonusItem.eBonusType type)
    {
        return bonusItem[(int)type];
    }
}

public enum ModdingType
{
    Fruit, Fish
}