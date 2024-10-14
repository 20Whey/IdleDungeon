using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public UnitSO unitSO;

    private Button button;

    [SerializeField] private Image uIIcon;

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

        uIIcon.sprite = unitSO.uIIcon;
    }

    public void AddListener()
    {
        button.onClick.AddListener(() => {
            Vector3 mousePos = Input.mousePosition;
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));

            BuildingSystem.Instance.InitializeWithObject(unitSO.prefabToSpawn, position);
        });
    }
}


