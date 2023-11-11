using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text MoneyText;
    public TMP_Text ShipAmountText;
    public TMP_Text HumanAmountText;

    public static UIManager Instance;

    public int Money = 0;
    public int Ship = 0;
    public int Human = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void DeductMoney(int amount)
    {
        if(Money > amount)
        {
            Money -= amount;
        }else
        {
            Money = 0;
        }
        MoneyText.text = Money.ToString();
    }
    public void UpdateMoneyAmount(int _Money)
    {
        Money += _Money;
        MoneyText.text = Money.ToString();
    }
    public void UpdateHumanAmount(int _Human)
    {
        Human = _Human;
        HumanAmountText.text = Human.ToString();
    }
    public void UpdateShipAmount(int _Ship)
    {
        Ship = _Ship;
        ShipAmountText.text = Ship.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateHumanAmount(0);
        UpdateMoneyAmount(0);
        UpdateShipAmount(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
