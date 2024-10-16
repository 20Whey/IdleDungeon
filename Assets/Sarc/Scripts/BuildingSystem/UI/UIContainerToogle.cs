using ImprovedTimers;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIContainerToggle : MonoBehaviour
{
    [Header("Rect Tranforms")]
    [SerializeField] private RectTransform container;
    [SerializeField] private RectTransform tabsContainer;
    [SerializeField] private RectTransform pullButtonTransform;
    [Space]
    [SerializeField] private Button pullButton;
    [Space]
    [SerializeField] private float animationDuration;
    [SerializeField] private float cooldown;

    private PlaceableButton[] placeableButtons;
    private CountdownTimer cooldownTimer;

    private Vector2 hiddenPosition;
    private Vector2 shownPosition;
    private Vector2 originalTabsPosition;
    private Vector3 originalTabsScale;
    private Vector3 originalButtonScale;


    private const float HiddenPositionX = -300f;
    private const float TabsStartX = -695f;

    private bool isVisible;


    private void Awake()
    {
        cooldownTimer = new CountdownTimer(cooldown);

        placeableButtons = GetComponentsInChildren<PlaceableButton>();

        foreach (var button in placeableButtons) {
            button.OnMoneySpent += ToggleContainer;
            button.OnPlaced += ToggleContainer;
        }

        pullButton.onClick.AddListener(ToggleContainer);
    }

    private void Start()
    {
        hiddenPosition = new Vector2(HiddenPositionX, container.anchoredPosition.y);
        shownPosition = new Vector2(0, container.anchoredPosition.y);
        container.anchoredPosition = hiddenPosition;

        originalTabsScale = tabsContainer.localScale;
        originalButtonScale = pullButtonTransform.localScale;
        originalTabsPosition = tabsContainer.anchoredPosition;
        SetTabsContainerScale(0f);
        tabsContainer.anchoredPosition = new Vector2(TabsStartX, originalTabsPosition.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !cooldownTimer.IsRunning) {
            ToggleContainer();
            cooldownTimer.Start();
        }
        //TODO: See if we can remove this from Update
        if (cooldownTimer.IsFinished) {
            cooldownTimer.Reset(cooldown);
        }
    }

    private void OnDestroy()
    {
        cooldownTimer.Dispose();
    }

    private void ToggleContainer()
    {
        Vector2 targetPosition = isVisible ? hiddenPosition : shownPosition;
        Vector3 targetTabsScale = isVisible ? new Vector3(0f, originalTabsScale.y, originalTabsScale.z) : originalTabsScale;
        Vector3 targetButtonScale = isVisible ? originalButtonScale : new Vector3(0f, originalButtonScale.y, originalButtonScale.z);
        Vector2 targetTabsPosition = isVisible ? new Vector2(TabsStartX, originalTabsPosition.y) : originalTabsPosition;

        StartCoroutine(MoveContainer(targetPosition, targetTabsScale, targetButtonScale, targetTabsPosition));
        isVisible = !isVisible;
    }

    private IEnumerator MoveContainer(Vector2 targetPosition, Vector3 targetTabsScale, Vector3 targetButtonScale, Vector2 targetTabsPosition)
    {
        Vector2 initialPosition = container.anchoredPosition;
        Vector3 initialTabsScale = tabsContainer.localScale;
        Vector3 initialButtonScale = pullButtonTransform.localScale;
        Vector2 initialTabsPosition = tabsContainer.anchoredPosition;

        for (float elapsedTime = 0; elapsedTime < animationDuration; elapsedTime += Time.deltaTime) {
            float t = elapsedTime / animationDuration;
            container.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, t);
            tabsContainer.localScale = Vector3.Lerp(initialTabsScale, targetTabsScale, t);
            pullButtonTransform.localScale = Vector3.Lerp(initialButtonScale, targetButtonScale, t * 2);
            tabsContainer.anchoredPosition = Vector2.Lerp(initialTabsPosition, targetTabsPosition, t);
            yield return null;
        }

        // Ensure final state is set correctly
        container.anchoredPosition = targetPosition;
        tabsContainer.localScale = targetTabsScale;
        pullButtonTransform.localScale = targetButtonScale;
        tabsContainer.anchoredPosition = targetTabsPosition;
    }

    private void SetTabsContainerScale(float scaleX)
    {
        tabsContainer.localScale = new Vector3(scaleX, originalTabsScale.y, originalTabsScale.z);
    }
}

