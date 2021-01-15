using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield : MonoBehaviour
{

    public static int w = 10;
    public static int h = 20;
    public static Transform[,] grid = new Transform[w, h]; // tetris sekillerinin oldugu oyun alani


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //vektorleri tam sayi yapsin diye
    public static Vector2 RoundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public static bool InsideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < w && (int)pos.y >= 0);
    }

    public static void DeleteRow(int y)
    {
        for(int x = 0; x < w; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public static void DecreaseRow(int y)
    {
        for(int x = 0; x < w; ++x)
        {
            if(grid[x,y] != null)
            {
                //satiri bir asagi indirme
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                //update block position
                grid[x, y - 1].position += new Vector3(0, -1, 0);

            }
        }
    }

    public static void DecreaseRowsAbove(int y) //silinen row'un ustundeki rowlari asagi indirecek
    {
        for(int i = y; i < h; ++i)
            DecreaseRow(i);
    }

    public static bool IsRowFull(int y)
    {
        for (int x = 0; x < w; ++x)
            if (grid[x, y] == null)
                return false;
        return true;
    }

    public static void DeleteFullRows()
    {
        for(int y = 0; y < h; y++)
        {
            if(IsRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y + 1);
                --y;
            }
        }
    }

}
