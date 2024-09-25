using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VInspector.Libs;

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

    private float selectedWidth = 200f;
    private float deSelectedWidth = 160f;

    private void Awake()
    {
        int tabIndex;

        tabs.Add(tabContainer.GetComponentsInChildren<Button>());

        itemTemplatesTestList.Add(containersContainer.GetComponentsInChildren<Button>());

        itemTemplatesTestList.ForEach(button => {
            UnitButton unitButton = button.GetComponent<UnitButton>();

            unitButton.AddListener();

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
