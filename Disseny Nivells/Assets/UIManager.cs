using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        coinsText.text = "0";
    }

    public void UpdateCoinsVisuals(int amount)
    {
        coinsText.text = amount.ToString();
    }
}
