using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private MoneyEarnButton _earneMoneyButtom;

    private float _moneyPerClick = 1;
    private float _moneyPerSecond = 10;
    private float _allTimeIncome = 0;
    private float _currentMoney = 0;

    public float MoneyPerClick => _moneyPerClick;
    public float MoneyPerSecond => _moneyPerSecond;
    public float AllTimeIncome => _allTimeIncome;

    public event UnityAction<float> CurrentMoneyChanged;

    private void Start()
    {
        Application.runInBackground = true;
        float secnodsPast = 0;

        if (PlayerPrefs.HasKey("TotalMoney"))
           _currentMoney = PlayerPrefs.GetFloat("TotalMoney");

        if (PlayerPrefs.HasKey("AllTimeIncome"))
            _allTimeIncome = PlayerPrefs.GetFloat("AllTimeIncome");

        if (PlayerPrefs.HasKey("LastExitDateTime"))
            secnodsPast = (float)DateTime.Now.Subtract(DateTime.Parse(PlayerPrefs.GetString("LastExitDateTime"))).TotalSeconds;


        float offlineIncome = secnodsPast * _moneyPerSecond;
        
        _currentMoney += offlineIncome;
        _allTimeIncome += offlineIncome;      

        StartCoroutine(Incoming());
        CurrentMoneyChanged?.Invoke(_currentMoney);
    }

    private void OnEnable()
    {
        _earneMoneyButtom.EarneMoneyButtonPressing += OnEarneMoneyButtonPressing;
    }

    private void OnDisable()
    {
        _earneMoneyButtom.EarneMoneyButtonPressing -= OnEarneMoneyButtonPressing;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("TotalMoney", _currentMoney);
        PlayerPrefs.SetFloat("AllTimeIncome", _allTimeIncome);
        PlayerPrefs.SetString("LastExitDateTime", DateTime.Now.ToString());
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PlayerPrefs.SetFloat("TotalMoney", _currentMoney);
            PlayerPrefs.SetFloat("AllTimeIncome", _allTimeIncome);
            PlayerPrefs.SetString("LastExitDateTime", DateTime.Now.ToString());
        }
    }

    private void OnEarneMoneyButtonPressing()
    {
        _allTimeIncome += _moneyPerClick;
        _currentMoney += _moneyPerClick;
        CurrentMoneyChanged?.Invoke(_currentMoney);
    }

    private IEnumerator Incoming()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);

            _currentMoney += _moneyPerSecond;
            _allTimeIncome += _moneyPerSecond;

            CurrentMoneyChanged?.Invoke(_currentMoney);
        }
    }
}