using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float coinSpinSpeed = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, coinSpinSpeed, Space.Self);
    }
}
