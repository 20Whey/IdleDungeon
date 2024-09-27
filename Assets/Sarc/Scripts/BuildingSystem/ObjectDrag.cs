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
        Vector3 pos = new Vector3(mousePos.x, mousePos.y);
        Vector3Int cellPos = BuildingSystem.Instance.GridLayout.WorldToCell(pos);
        Vector3 spritePos = BuildingSystem.Instance.GridLayout.CellToLocalInterpolated(cellPos);
        spritePos = new Vector3(spritePos.x + 0.5f, spritePos.y + 0.5f);
        transform.position = spritePos;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.F)) {
            gameObject.GetComponent<PlaceableObject>().CheckPlacement();
            Destroy(this);
        }
    }
}
