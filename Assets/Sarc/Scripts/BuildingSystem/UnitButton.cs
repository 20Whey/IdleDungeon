using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public UnitSO unitSO;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void AddListener()
    {
        //TODO: Make it spawn at mouse center
        button.onClick.AddListener(() => {
            Vector3 mousePos = Input.mousePosition;
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));

            BuildingSystem.Instance.InitializeWithObject(unitSO.prefabToSpawn, position);
        });
    }
}


