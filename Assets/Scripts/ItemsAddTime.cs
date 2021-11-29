using UnityEngine;

public class ItemsAddTime : Items
{
    public override void AddTime()
    {
        var itemTime = FindObjectOfType<Timer>();
        itemTime.seconde += itemTime.addTime;
    }
}