using UnityEngine;
using System;
using UnityEngine.Events;

public class CollectTrigger : MonoBehaviour
{
    public UnityEvent OnCoinCollect = new();
    public bool isCoinCollected = false;

    private void OnTriggerEnter()
    {
        isCoinCollected = true;
        OnCoinCollect.Invoke();
        if (isCoinCollected)
        {
            Destroy(gameObject);
        }
    }
}
