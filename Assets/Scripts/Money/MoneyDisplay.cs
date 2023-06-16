using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private Text _currentMoneyText;

    private void OnEnable()
    {
        _moneyManager.CurrentMoneyChanged += OnCurrentMoneyChanged;
    }

    private void OnDisable()
    {
        _moneyManager.CurrentMoneyChanged -= OnCurrentMoneyChanged;

    }

    private void OnCurrentMoneyChanged(float newValue)
    {
        _currentMoneyText.text = ((int)newValue).ToString();
    }
}
