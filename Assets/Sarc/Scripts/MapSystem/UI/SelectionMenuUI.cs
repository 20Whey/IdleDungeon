using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionMenuUI : MonoBehaviour
{
    [Header("First Selected Option")]
    [SerializeField] private GameObject firstContainer;

    [Header("Both Lists must be on the same order as in Hierarchy")]
    [SerializeField] private Transform tabContainer;
    [SerializeField] private Transform placeablesContainer;

    [Header("Shown for Debug Purposes")]
    [SerializeField] private List<Button> tabs = new List<Button>();
    [SerializeField] private List<Transform> placeablesContainers = new List<Transform>();
    [SerializeField] private List<Button> placeablesList = new List<Button>();

    private const float SelectedWidth = 271f;
    private const float DeSelectedWidth = 217f;

    private void Start()
    {
        InitializeTabs();
        InitializePlaceables();

        #region Activate First Container
        DeactivateAllContainers();
        ActivateContainer(0);
        EventSystem.current.SetSelectedGameObject(firstContainer);
        #endregion
    }
    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != null) {
            Button selectedTab = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            if (selectedTab != null) {
                int tabIndex = tabs.IndexOf(selectedTab);
                if (tabIndex >= 0) {
                    HandleTabSelection(tabIndex);
                }
            }
        }
    }

    private void InitializeTabs()
    {
        tabs.AddRange(tabContainer.GetComponentsInChildren<Button>());

        foreach (var tab in tabs) {
            tab.onClick.AddListener(() => OnTabSelected(tab));
        }
    }

    private void InitializePlaceables()
    {
        placeablesList.AddRange(placeablesContainer.GetComponentsInChildren<Button>());

        foreach (var button in placeablesList) {
            if (button.TryGetComponent(out PlaceableButton unitButton)) {
                unitButton.AddListener();
            } else {
                Debug.LogWarning("UnitButton component missing on button: " + button.name);
            }
        }

        placeablesContainers = GetValidContainers(placeablesContainer);
    }

    private void OnTabSelected(Button clickedButton)
    {
        int tabIndex = tabs.IndexOf(clickedButton);
        HandleTabSelection(tabIndex);
    }

    private void HandleTabSelection(int tabIndex)
    {
        if (tabIndex < 0 || tabIndex >= tabs.Count)
            return;

        RectTransform clickedRectTransform = tabs[tabIndex].GetComponent<RectTransform>();

        if (clickedRectTransform.sizeDelta.x == DeSelectedWidth) {
            DeselectAllTabs();
            DeactivateAllContainers();
            ActivateContainer(tabIndex);

            clickedRectTransform.sizeDelta = new Vector2(SelectedWidth, clickedRectTransform.sizeDelta.y);
        }
    }

    private void DeselectAllTabs()
    {
        foreach (var tab in tabs) {
            RectTransform tabRectTransform = tab.GetComponent<RectTransform>();
            tabRectTransform.sizeDelta = new Vector2(DeSelectedWidth, tabRectTransform.sizeDelta.y);
        }
    }

    private void DeactivateAllContainers()
    {
        foreach (var container in placeablesContainers) {
            container.gameObject.SetActive(false);
        }
    }

    private void ActivateContainer(int index)
    {
        if (index >= 0 && index < placeablesContainers.Count) {
            placeablesContainers[index].gameObject.SetActive(true);
        }
    }

    private List<Transform> GetValidContainers(Transform parent)
    {
        var containers = new List<Transform>();
        foreach (Transform child in parent) {
            if (child.childCount > 0) {
                containers.Add(child);
            }
        }
        return containers;
    }
}
