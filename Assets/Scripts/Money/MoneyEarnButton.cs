using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MoneyEarnButton : MonoBehaviour
{
    [SerializeField] private Button _earnMoneyButtom;
    public event UnityAction EarneMoneyButtonPressing;

    private void OnEnable()
    {
        _earnMoneyButtom.onClick.AddListener(OnEarneMoneyButtonClicked);
    }

    private void OnDisable()
    {
        _earnMoneyButtom.onClick.RemoveListener(OnEarneMoneyButtonClicked);
    }

    private void OnEarneMoneyButtonClicked()
    {
        EarneMoneyButtonPressing?.Invoke();
    }
}
