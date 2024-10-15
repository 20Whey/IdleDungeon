using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public PlaceableSO placeableSO;

    private Button button;

    private Image uIIcon;

    private void Awake()
    {
        button = GetComponent<Button>();
        #region Debug
        if (button == null) {
            Debug.LogError("Button component is missing on this GameObject: " + gameObject.name);
        }
        #endregion
        Image[] images = GetComponentsInChildren<Image>();


        // Filter out the Image component that's on the parent object itself
        foreach (Image img in images) {
            if (img.gameObject != gameObject) {
                uIIcon = img;
                break;
            }
        }

        uIIcon.sprite = placeableSO.uIIcon;
    }

    public void AddListener()
    {
        button.onClick.AddListener(() => {
            SpendGold();
        });
    }

    private void SpendGold()
    {
        GoldManager.Instance.DecreaseGold(placeableSO.goldCost);
        if (GoldManager.Instance.EnoughGold == true) {
            button.interactable = false;
            SpawnDragVisual();
        }
    }

    private void SpawnDragVisual()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));

        GameObject placeablePrefab = BuildingSystem.Instance.InitializeWithObject(placeableSO.prefabToSpawn, position);
        PlaceableObject placeableObject = placeablePrefab.GetComponent<PlaceableObject>();
        placeableObject.OnPlaced += PlaceableObject_OnPlaced;

    }

    private void PlaceableObject_OnPlaced(GameObject obj)
    {
        button.interactable = true;
    }
}

