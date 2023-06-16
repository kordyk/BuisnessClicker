using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenMenuButton : MonoBehaviour
{
    [SerializeField] private Menu _menuToOpen;

    private Button _button;

    public static event UnityAction<Menu> OpenMenuButtonClicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnOpenMenuButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnOpenMenuButtonClicked);
    }

    private void OnOpenMenuButtonClicked()
    {
        OpenMenuButtonClicked?.Invoke(_menuToOpen);
    }
}
