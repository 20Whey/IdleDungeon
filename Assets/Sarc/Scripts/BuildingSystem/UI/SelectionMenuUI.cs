using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VInspector.Libs;

public class SelectionMenuUI : MonoBehaviour
{

    [SerializeField] private Button itemTemplateTest;

    [Header("Both Lists must be on the same order")]
    [SerializeField] private GameObject tabContainer;
    [SerializeField] private GameObject containersContainer;
    [Space]

    [SerializeField] private GameObject ArmyTest;

    [SerializeField] private List<Button> tabs;
    [Header("This one needs to be filled manually")]
    [SerializeField] private List<Transform> containers;

    private float selectedWidth = 200f;
    private float deSelectedWidth = 160f;

    private void Awake()
    {
        int tabIndex;

        tabs.Add(tabContainer.GetComponentsInChildren<Button>());

        //Removed cause it caused the List to get filled with the Grandchildren+ Transforms
        //containers.Add(containersContainer.GetComponentsInChildren<Transform>());

        itemTemplateTest.onClick.AddListener(() => {
            Vector3 position = new(transform.position.x, transform.position.y);
            position = Camera.main.ScreenToWorldPoint(position);

            //instanciates the object directly on grid and on the mousePos
            BuildingSystem.Instance.InitializeWithObject(ArmyTest, position);
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
