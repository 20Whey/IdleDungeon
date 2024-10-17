using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionMenuUI : MonoBehaviour
{

    [Header("Both Lists must be on the same order")]
    [SerializeField] private Transform tabContainer;
    [SerializeField] private Transform placeablesContainer;
    [Space]

    [SerializeField] private List<Button> tabs;
    [SerializeField] private List<Transform> placeablesContainers;
    [SerializeField] private List<Button> placeablesList;

    //TODO: Change magic Numbers for a check of stablished width on the scene
    private float selectedWidth = 271f;
    private float deSelectedWidth = 217f;

    private void Start()
    {
        int tabIndex;

        tabs.AddRange(tabContainer.GetComponentsInChildren<Button>());

        placeablesList.AddRange(placeablesContainer.GetComponentsInChildren<Button>());

        placeablesList.ForEach(button => {
            PlaceableButton unitButton = button.GetComponent<PlaceableButton>();

            if (unitButton != null) {
                unitButton.AddListener();
            } else {
                Debug.LogWarning("UnitButton component missing on button: " + button.name);
            }
        });

        //FIX: Refactor for cleaner code
        tabs.ForEach(tab => {

            tab.onClick.AddListener(() => {
                GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
                Button clickedButton = clickedObject.GetComponent<Button>();
                RectTransform clickedRectTransform = clickedObject.GetComponent<RectTransform>();

                tabIndex = tabs.FindIndex(button => button == clickedButton);

                if (clickedRectTransform.sizeDelta.x == deSelectedWidth) {
                    Deselect();
                    DeactivateOtherContainers();
                    ActivateLinkedContainer(tabIndex);

                    Vector2 newSize = new Vector2(selectedWidth, clickedRectTransform.sizeDelta.y);
                    clickedRectTransform.sizeDelta = newSize;
                }
            });

        });

        placeablesContainers = GetValidContainers(placeablesContainer);

        #region Activate Container One
        DeactivateOtherContainers();
        ActivateLinkedContainer(0);
        #endregion
    }


    private void Deselect()
    {
        tabs.ForEach((tab) => {
            RectTransform allTabsRectTransform = tab.GetComponent<RectTransform>();

            allTabsRectTransform.sizeDelta = new Vector2(deSelectedWidth, allTabsRectTransform.sizeDelta.y);
        });
    }

    private void DeactivateOtherContainers()
    {
        placeablesContainers.ForEach(container => {

            container.gameObject.SetActive(false);
        });
    }
    private void ActivateLinkedContainer(int i)
    {
        if (i >= 0 && i < placeablesContainers.Count) {
            Transform selectedContainer = placeablesContainers[i];

            selectedContainer.gameObject.SetActive(true);
        }
    }

    List<Transform> GetValidContainers(Transform parent)
    {
        List<Transform> containers = new List<Transform>();

        // Iterate through each child of the parent container
        foreach (Transform child in parent) {
            // Check if the child has its own children
            if (child.childCount > 0) {
                containers.Add(child);
            }
        }

        return containers;
    }
}
