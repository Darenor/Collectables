using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game Settings")]
    [SerializeField] private int itemsToWin = 5;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private TextMeshProUGUI victoryText;

    private int collectedItems = 0;
    private bool hasWon = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (counterText == null || victoryText == null)
        {
            Debug.LogError(
                "Назначьте CounterText и VictoryText в Inspector!"
                );
            return;
        }

        victoryText.gameObject.SetActive(false);
        UpdateCounter();
    }

    public void CollectItem()
    {
        if (hasWon) return;

        collectedItems++;
        UpdateCounter();

        if (collectedItems >= itemsToWin)
        {
            hasWon = true;
            victoryText.gameObject.SetActive(true);
            victoryText.text = "ПОБЕДА! Все предметы собраны!";
        }
    }

    private void UpdateCounter()
    {
        if (counterText != null)
        {
            counterText.text =
                "Собрано: " + collectedItems + " / " + itemsToWin;
        }
    }
}
