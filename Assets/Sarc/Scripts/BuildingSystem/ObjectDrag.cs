using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 startPosition;
    private float deltaX, deltaY;

    private void Start()
    {
        startPosition = Input.mousePosition;
    }


    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = new(mousePos.x, mousePos.y);

        Vector3Int cellPos = BuildingSystem.Instance.GridLayout.WorldToCell(pos);
        transform.position = BuildingSystem.Instance.GridLayout.CellToLocalInterpolated(cellPos);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.F)) {
            gameObject.GetComponent<PlaceableObject>().CheckPlacement();
            Destroy(this);
        }
    }
}
