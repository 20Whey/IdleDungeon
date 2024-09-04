using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionMenuUI : MonoBehaviour
{

    [SerializeField] private Button itemTemplateTest;
    //TODO: Make this the array of possible Tabs
    [SerializeField] private Button tabTest;
    [SerializeField] private GameObject ArmyTest;

    private float selectedWidth = 200f;
    private float deSelectedWidth = 160f;

    private void Awake()
    {
        itemTemplateTest.onClick.AddListener(() => {
            Vector3 position = new(transform.position.x, transform.position.y);
            position = Camera.main.ScreenToWorldPoint(position);

            //instanciates the object directly on grid and on the mousePos
            BuildingSystem.Instance.InitializeWithObject(ArmyTest, position);
        });

        tabTest.onClick.AddListener(() => {
            GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
            RectTransform clickedRectTransform = clickedObject.GetComponent<RectTransform>();

            if (clickedRectTransform.sizeDelta.x == deSelectedWidth) {
                Vector2 newSize = new Vector2(selectedWidth, clickedRectTransform.sizeDelta.y);
                clickedRectTransform.sizeDelta = newSize;
                //Add to deselect all other buttons once the array has been created
            }
        });
    }
}
