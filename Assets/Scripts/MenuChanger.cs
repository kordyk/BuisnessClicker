using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChanger : MonoBehaviour
{
    [SerializeField] private Menu _currentActiveMenu;

    private void OnEnable()
    {
        OpenMenuButton.OpenMenuButtonClicked += OnOpenMenuButtonClicked;
    }

    private void OnDisable()
    {
        OpenMenuButton.OpenMenuButtonClicked -= OnOpenMenuButtonClicked;
    }

    private void OnOpenMenuButtonClicked(Menu menuToOpen)
    {
        _currentActiveMenu.gameObject.SetActive(false);
        _currentActiveMenu = menuToOpen;
        menuToOpen.gameObject.SetActive(true);
    }
}
