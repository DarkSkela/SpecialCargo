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

    public void UpdateMoneyAmount(float Money)
    {
        MoneyText.text = Money.ToString();
    }
    public void UpdateHumanAmount(float Human)
    {
        MoneyText.text = Human.ToString();
    }
    public void UpdateShipAmount(float Ship)
    {
        MoneyText.text = Ship.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
