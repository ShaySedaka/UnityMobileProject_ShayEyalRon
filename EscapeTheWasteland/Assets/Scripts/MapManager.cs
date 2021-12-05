using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class MapManager : MonoBehaviour
{
    [SerializeField][Range(0,100)]
    int _initChance;

    [SerializeField][Range(1,8)]
    int _birthLimit;

    [SerializeField] [Range(1, 8)]
    int _numR;
    int _count = 0;

    private int[,] _terrainMap;
    public Vector3 tMapSize;

    [SerializeField]
    Tilemap _baseGround;
    [SerializeField]
    Tilemap _forest;
    [SerializeField]
    Tilemap _iron;
    [SerializeField]
    Tilemap _gold;
    [SerializeField]
    Tilemap _diamonds;

    [SerializeField]
    Tile _baseGroundTile;
    [SerializeField]
    Tile _forestTile;
    [SerializeField]
    Tile _ironTile;
    [SerializeField]
    Tile _goldTile;
    [SerializeField]
    Tile _diamondTile;

    int _width;
    int _height;

    public void doSim(int numR)
    {
        clearMap(false);
        _width = (int)tMapSize.x;
        _height = (int)tMapSize.y;

        if(_terrainMap == null)
        {
            _terrainMap = new int[_width, _height];
            InitPos();
        }
    }
    public void InitPos()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _terrainMap[x, y] = Random.Range(1, 101) < _initChance ? 1 : 0;
            }
        }

    }
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
    [SerializeField]
    int _mapMaxX;
    [SerializeField]
    int _mapMinX;
    [SerializeField]
    int _mapMaxY;
    [SerializeField]
    int _mapMinY;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
        }
    }
}
