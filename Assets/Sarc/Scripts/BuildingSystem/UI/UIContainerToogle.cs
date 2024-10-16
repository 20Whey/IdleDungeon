using System.Collections;
using UnityEngine;

public class UIContainerToggle : MonoBehaviour
{
    [SerializeField] private RectTransform container;
    [SerializeField] private float animationDuration;
    private Vector2 hiddenPosition;
    private Vector2 shownPosition;
    [Space]
    [Tooltip("This value may need editing if Canvas changes size for some reason")]
    [SerializeField] private float hiddenPositionX = -300f;

    private bool isVisible = false;

    void Start()
    {
        hiddenPosition = new Vector2(hiddenPositionX, container.anchoredPosition.y);
        shownPosition = new Vector2(0, container.anchoredPosition.y);

        container.anchoredPosition = hiddenPosition;
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
            StartCoroutine(MoveContainer(hiddenPosition));
        } else {
            StartCoroutine(MoveContainer(shownPosition));
        }
        isVisible = !isVisible;
    }

    private IEnumerator MoveContainer(Vector2 targetPosition)
    {
        Vector2 initialPosition = container.anchoredPosition;
        float elapsedTime = 0;

        while (elapsedTime < animationDuration) {
            // Calculate the current position using Lerp
            container.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, (elapsedTime / animationDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // End at the target position
        container.anchoredPosition = targetPosition;
    }
}
