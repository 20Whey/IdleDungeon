using System.Collections;
using UnityEngine;

public class UIContainerToggle : MonoBehaviour
{
    [SerializeField] private RectTransform container;
    [SerializeField] private RectTransform tabsContainer;
    [Space]
    [SerializeField] private float animationDuration;
    private Vector2 hiddenPosition;
    private Vector2 shownPosition;
    private Vector3 originalTabsScale;
    private Vector3 originalTabsPosition;

    //TODO: Remove Magic Numbers
    private float hiddenPositionX = -300f;
    private float tabsStartX = -695f;

    private bool isVisible = false;
    private float hiddenTabXScale = 0f;

    void Start()
    {
        hiddenPosition = new Vector2(hiddenPositionX, container.anchoredPosition.y);
        shownPosition = new Vector2(0, container.anchoredPosition.y);

        container.anchoredPosition = hiddenPosition;
        originalTabsScale = tabsContainer.localScale;
        originalTabsPosition = tabsContainer.anchoredPosition;
        tabsContainer.localScale = new Vector3(hiddenTabXScale, originalTabsScale.y, originalTabsScale.z);

        tabsContainer.anchoredPosition = new Vector2(tabsStartX, originalTabsPosition.y);
    }

    void Update()
    {
        //TODO: Remove from Update
        if (Input.GetKeyDown(KeyCode.Tab)) {
            ToggleContainer();
        }
    }

    private void ToggleContainer()
    {
        if (isVisible) {
            StartCoroutine(MoveContainer(hiddenPosition, new Vector3(hiddenTabXScale, originalTabsScale.y, originalTabsScale.z),
                new Vector2(tabsStartX, originalTabsPosition.y)));
        } else {
            StartCoroutine(MoveContainer(shownPosition, originalTabsScale, originalTabsPosition));
        }
        isVisible = !isVisible;
    }


    private IEnumerator MoveContainer(Vector2 targetPosition, Vector2 targetTabsScale, Vector2 targetTabsPosition)
    {
        Vector2 initialPosition = container.anchoredPosition;
        Vector3 initialTabsScale = tabsContainer.localScale;
        Vector2 initialTabsPosition = tabsContainer.anchoredPosition;
        float elapsedTime = 0;

        while (elapsedTime < animationDuration) {
            // Calculate the current position using Lerp
            container.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, (elapsedTime / animationDuration));
            tabsContainer.localScale = Vector3.Lerp(initialTabsScale, targetTabsScale, (elapsedTime / animationDuration));
            tabsContainer.anchoredPosition = Vector2.Lerp(initialTabsPosition, targetTabsPosition, (elapsedTime / animationDuration));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // End at the target positions and scale
        container.anchoredPosition = targetPosition;
        tabsContainer.localScale = targetTabsScale;
        tabsContainer.anchoredPosition = targetTabsPosition;
    }
}
