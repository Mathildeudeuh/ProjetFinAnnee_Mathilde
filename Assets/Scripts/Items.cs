using UnityEngine;


[RequireComponent(typeof(ItemsAddTime))]
[RequireComponent(typeof(Timer))]

public abstract class Items : MonoBehaviour
{
    public GameObject star { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        star.SetActive(false);
        AddTime();

    }

    public abstract void AddTime();
}
