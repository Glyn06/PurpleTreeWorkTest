using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI rockCount;
    [SerializeField] TextMeshProUGUI coinCount;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void SetTimerText(string newText)
    {
        timerText.text = newText;
    }

    public void SetRockCountText(string newText)
    {
        rockCount.text = newText;
    }

    public void SetCoinCountText(string newText)
    {
        coinCount.text = newText;
    }
}
