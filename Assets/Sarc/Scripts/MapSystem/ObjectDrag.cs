using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private PlaceableObject placeableObject;

    private Vector3 startPosition;
    private float deltaX, deltaY;

    private void Awake()
    {
        placeableObject = GetComponent<PlaceableObject>();
        placeableObject.OnPlaced += PlaceableObject_OnPlaced;
    }

    private void PlaceableObject_OnPlaced(GameObject obj)
    {
        Destroy(this);
    }

    private void Start()
    {
        startPosition = Input.mousePosition;
    }


    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = new Vector3(mousePos.x, mousePos.y);
        Vector3Int cellPos = MapSystem.Instance.GridLayout.WorldToCell(pos);
        Vector3 spritePos = MapSystem.Instance.GridLayout.CellToLocalInterpolated(cellPos);
        spritePos = new Vector3(spritePos.x + 0.5f, spritePos.y + 0.5f);
        transform.position = spritePos;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            gameObject.GetComponent<PlaceableObject>().CheckPlacement();
        }
    }
}
