using System.Collections;
using UnityEngine;

public class UIContainerToggle : MonoBehaviour
{
    [SerializeField] private RectTransform container;
    [SerializeField] private RectTransform tabsContainer;
    [SerializeField] private float animationDuration;

    private PlaceableButton[] placeableButtons;
    private Vector2 hiddenPosition;
    private Vector2 shownPosition;
    private Vector3 originalTabsScale;
    private Vector2 originalTabsPosition;

    private const float HiddenPositionX = -300f;
    private const float TabsStartX = -695f;

    private bool isVisible;

    private void Awake()
    {
        placeableButtons = GetComponentsInChildren<PlaceableButton>();

        foreach (var button in placeableButtons) {
            button.OnMoneySpent += ToggleContainer;
            button.OnPlaced += ToggleContainer;
        }
    }

    private void Start()
    {
        hiddenPosition = new Vector2(HiddenPositionX, container.anchoredPosition.y);
        shownPosition = new Vector2(0, container.anchoredPosition.y);
        container.anchoredPosition = hiddenPosition;

        originalTabsScale = tabsContainer.localScale;
        originalTabsPosition = tabsContainer.anchoredPosition;
        SetTabsContainerScale(0f);
        tabsContainer.anchoredPosition = new Vector2(TabsStartX, originalTabsPosition.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            ToggleContainer();
        }
    }

    private void ToggleContainer()
    {
        Vector2 targetPosition = isVisible ? hiddenPosition : shownPosition;
        Vector3 targetTabsScale = isVisible ? new Vector3(0f, originalTabsScale.y, originalTabsScale.z) : originalTabsScale;
        Vector2 targetTabsPosition = isVisible ? new Vector2(TabsStartX, originalTabsPosition.y) : originalTabsPosition;

        StartCoroutine(MoveContainer(targetPosition, targetTabsScale, targetTabsPosition));
        isVisible = !isVisible;
    }

    private IEnumerator MoveContainer(Vector2 targetPosition, Vector3 targetTabsScale, Vector2 targetTabsPosition)
    {
        Vector2 initialPosition = container.anchoredPosition;
        Vector3 initialTabsScale = tabsContainer.localScale;
        Vector2 initialTabsPosition = tabsContainer.anchoredPosition;

        for (float elapsedTime = 0; elapsedTime < animationDuration; elapsedTime += Time.deltaTime) {
            float t = elapsedTime / animationDuration;
            container.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, t);
            tabsContainer.localScale = Vector3.Lerp(initialTabsScale, targetTabsScale, t);
            tabsContainer.anchoredPosition = Vector2.Lerp(initialTabsPosition, targetTabsPosition, t);
            yield return null;
        }

        // Ensure final state is set correctly
        container.anchoredPosition = targetPosition;
        tabsContainer.localScale = targetTabsScale;
        tabsContainer.anchoredPosition = targetTabsPosition;
    }

    private void SetTabsContainerScale(float scaleX)
    {
        tabsContainer.localScale = new Vector3(scaleX, originalTabsScale.y, originalTabsScale.z);
    }
}

