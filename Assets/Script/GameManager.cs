using Script.Core;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI wattText;

    public Button upButton;
    public Button downButton;
    public Button spendButton;
    
    public WattState wattState;



    void Start()
    {
        InvokeRepeating("GenerateWatts", 1f, 1f);

        if (upButton != null)
        {
            upButton.onClick.AddListener(OnUpButtonPressed);
        }
        else
        {
            Debug.LogError("Up Button reference is not assigned.");
        }

        if (downButton != null)
        {
            downButton.onClick.AddListener(OnDownButtonPressed);
        }
        else
        {
            Debug.LogError("Down Button reference is not assigned.");
        }
        if (spendButton != null)
        {
            spendButton.onClick.AddListener(OnSpendButtonPressed);
        }
        else
        {
            Debug.LogError("Down Button reference is not assigned.");
        }
    }

    void Update()
    {
        wattText.text = "Watts: " + wattState.TotalWatts.ToString("F2");
        
        
    }


    public void OnUpButtonPressed()
    {
        IncreaseWatts();    
        Debug.Log("Up Button was pressed!");
    }

    public void OnSpendButtonPressed()
    {
        if(wattState.Dollars >= 10)
        {
            wattState.Dollars -= 10;
            IncreaseWatts();

        }
        Debug.Log("Spend Button was pressed!");
    }

    public void OnDownButtonPressed()
    {
        DecreaseWatts();
        Debug.Log("Down Button was pressed!");
    }


    void GenerateWatts()
    {
        wattState.TotalWatts += wattState.wattsPerSecond;
    }

    void IncreaseWatts()
    {
        wattState.wattsPerSecond += 1;

    }

    void DecreaseWatts()
    {
        wattState.wattsPerSecond -= 1;
    }
}