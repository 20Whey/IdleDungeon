using UnityEngine;
using UnityEngine.Tilemaps;

public class MapSystem : Singleton<MapSystem>
{
    [SerializeField] private GridLayout gridLayout;
    [SerializeField] private Tilemap groundTileMap;
    [SerializeField] private TileBase takenTile;

    public GridLayout GridLayout => gridLayout;

    #region Tilemap Management
    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y];
        int counter = 0;

        foreach (var v in area.allPositionsWithin) {
            Vector3Int position = new(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(position);
            counter++;
        }

        return array;
    }

    private static void SetTilesBlock(BoundsInt area, TileBase tileBase, Tilemap tilemap)
    {
        TileBase[] tileArray = new TileBase[area.size.x * area.size.y];
        FillTiles(tileArray, tileBase);
        tilemap.SetTilesBlock(area, tileArray);
    }

    private static void FillTiles(TileBase[] arr, TileBase tileBase)
    {
        for (int i = 0; i < arr.Length; i++) {
            arr[i] = tileBase;
        }
    }

    public void ClearArea(BoundsInt area, Tilemap tilemap)
    {
        SetTilesBlock(area, null, tilemap);
    }


    #endregion

    #region Item Placement

    public GameObject InitializeWithObject(GameObject item, Vector3 position)
    {
        position.z = 0;
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        Vector3 newPosition = gridLayout.CellToLocalInterpolated(cellPos);

        GameObject obj = Instantiate(item, newPosition, Quaternion.identity);
        obj.AddComponent<ObjectDrag>();

        return obj;
    }

    public bool CanTakeArea(BoundsInt area)
    {
        TileBase[] baseArray = GetTilesBlock(area, groundTileMap);

        foreach (var b in baseArray) {
            if (b != null && b != takenTile) {
                return true;
            }
        }

        return false;
    }

    public void TakeArea(BoundsInt area)
    {
        SetTilesBlock(area, takenTile, groundTileMap);
    }

    #endregion
}

