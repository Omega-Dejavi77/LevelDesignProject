using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    [SerializeField] private Text message;
    
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        coinsText.text = "0";
        message.text = "";
    }

    public void UpdateCoinsVisuals(int amount)
    {
        coinsText.text = amount.ToString();
    }

    public void ShowMessage(string str)
    {
        message.text = str;
        StartCoroutine(HideMessage());
    }

    private IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(2f);
        message.text = "";
    }
}
