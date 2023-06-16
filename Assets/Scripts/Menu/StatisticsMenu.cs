using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsMenu : Menu
{
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private Text _moneyPerClickText;
    [SerializeField] private Text _allMoneyIncome;
    [SerializeField] private Text _moneyPerSecond;

    private void OnEnable()
    {
        _moneyPerClickText.text = _moneyManager.MoneyPerClick.ToString()+"/Click";
        _allMoneyIncome.text = _moneyManager.AllTimeIncome.ToString() + " All earnings";
        _moneyPerSecond.text = _moneyManager.MoneyPerSecond.ToString()+ "/Sec";


    }
}
