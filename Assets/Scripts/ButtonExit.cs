using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonExit : MonoBehaviour
{
    [SerializeField] private ConfirmWindow _confirmWindow;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        _confirmWindow.Show("Вы действительно хотите выйти?");
        _confirmWindow.ActionConfirmed += OnExitConfirmed;
    }

    private void OnExitConfirmed()
    {
        print("quit");
        Application.Quit();
    }
}
