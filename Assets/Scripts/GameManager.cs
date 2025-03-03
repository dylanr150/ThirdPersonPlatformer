using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private InputManager inputManager;

    private CollectTrigger[] coins;
    void Start()
    {
        coins = FindObjectsByType<CollectTrigger>(FindObjectsSortMode.None);
        foreach (CollectTrigger coin in coins)
        {
            coin.OnCoinCollect.AddListener(IncrementScore);
        }
    }
    private void IncrementScore()
    {
        score++;

        scoreText.text = $"Score: {score}";
    }
}
