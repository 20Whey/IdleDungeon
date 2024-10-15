using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionMenuUI : MonoBehaviour
{

    [Header("Both Lists must be on the same order")]
    [SerializeField] private GameObject tabContainer;
    [SerializeField] private GameObject containersContainer;
    [Space]

    [SerializeField] private List<Button> tabs;
    [Header("This one needs to be filled manually")]
    [SerializeField] private List<Transform> containers;
    [SerializeField] private List<Button> itemTemplatesTestList;

    //TODO: Change magic Numbers for a check of stablished width on the scene
    private float selectedWidth = 271f;
    private float deSelectedWidth = 217f;

    private void Start()
    {
        int tabIndex;

        tabs.AddRange(tabContainer.GetComponentsInChildren<Button>());

        itemTemplatesTestList.AddRange(containersContainer.GetComponentsInChildren<Button>());

        itemTemplatesTestList.ForEach(button => {
            UnitButton unitButton = button.GetComponent<UnitButton>();

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
        containers.ForEach(container => {

            container.gameObject.SetActive(false);
        });
    }
    private void ActivateLinkedContainer(int i)
    {
        if (i >= 0 && i < containers.Count) {
            Transform selectedContainer = containers[i];

            selectedContainer.gameObject.SetActive(true);
        }
    }
}
