using UnityEngine;

public class ObjectDrag : MonoBehaviour
{

    //[SerializeField] private Vector3 offset = new Vector3(0, -1f, 0);

    private Vector3 startPosition;
    private float deltaX, deltaY;

    private void Start()
    {
        startPosition = Input.mousePosition;

        //Un-used for now, can be dded to give offset to the visual Drag
        deltaX = startPosition.x - transform.position.x;
        deltaY = startPosition.y - transform.position.y;
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
        if (Input.GetMouseButtonUp(0)) {
            gameObject.GetComponent<PlaceableObject>().CheckPlacement();
            Destroy(this);
        }
    }
}
