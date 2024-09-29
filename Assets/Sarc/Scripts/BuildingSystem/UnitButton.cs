using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public UnitSO unitSO;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        if (button == null) {
            Debug.LogError("Button component is missing on this GameObject: " + gameObject.name);
        }
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


