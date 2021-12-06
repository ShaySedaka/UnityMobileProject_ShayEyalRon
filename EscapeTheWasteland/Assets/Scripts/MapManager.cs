using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class MapManager : MonoBehaviour
{
    //have a grid for you hole map
    [SerializeField]
    Grid _grid;

    [SerializeField]
    int _mapMaxX;
    [SerializeField]
    int _mapMinX;
    [SerializeField]
    int _mapMaxY;
    [SerializeField]
    int _mapMinY;

    public int Width
    {
        get
        {
            return _mapMaxX - _mapMinX;
        }
    }
    public int Height
    {
        get
        {
            return _mapMaxY - _mapMinY;
        }
    }

    [SerializeField]
    Tilemap _baseGround;

    [SerializeField]
    TileBase _baseGroundTile;

    //paint it with base tile for map

    private void Start()
    {
        CreateMap();
    }
    void CreateMap()
    {
        CreateTileLayer(_baseGround,_baseGroundTile,Width,Height,new Vector2(_mapMinX,_mapMinY));
        CreateTileLayer(_forest,_forestTile,5,8,new Vector2(5,7));
    }
    void CreateTileLayer(Tilemap tileMap,TileBase tile, int width, int height, Vector2 startPos)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tileMap.SetTile(new Vector3Int((int)startPos.x + x, (int)startPos.y + y, 0), tile);
            }
        }
    }
       
    //make lists for every type of environment
    //if the environment is on another type of environment move it
    //paint that environment with a speciphic tile

    //when spawning an object, know about it's environment type
    //find one of the lists that he can spawn on and spawn it there






    private int[,] _terrainMap;
    public Vector3 tMapSize;

    [SerializeField]
    Tilemap _forest;
    [SerializeField]
    Tilemap _iron;
    [SerializeField]
    Tilemap _gold;
    [SerializeField]
    Tilemap _diamonds;

    [SerializeField]
    TileBase _forestTile;
    [SerializeField]
    TileBase _ironTile;
    [SerializeField]
    TileBase _goldTile;
    [SerializeField]
    TileBase _diamondTile;



    public void clearMap(bool complete)
    {
        _baseGround.ClearAllTiles();
        _forest.ClearAllTiles();
        _iron.ClearAllTiles();
        _gold.ClearAllTiles();
        _diamonds.ClearAllTiles();

        if(complete)
        {
            _terrainMap = null;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
        }
    }
}
