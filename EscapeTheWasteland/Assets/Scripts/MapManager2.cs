using UnityEngine;
public enum TileType
{
    Ground = 0,
    Forest = 1,
    Iron = 2,
    Gold = 3,
    Diamonds = 4
}
public class MapManager2 : MonoBehaviour
{
    MapManager2(int[,] size)
    {
        _mapSize = size;
    }

    int[,] _mapSize;

    TileNode[,] _map;

    //public void PaintMap(TileType tileType)
    //{
    //    for (int i = 0; i < length; i++)
    //    {

    //    }
    //}
}
