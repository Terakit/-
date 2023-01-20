using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public UIQuest Quest;
    public GameObject Tile;
    [HideInInspector] public Vector2Int PosTile;
     public List<Resources> ClonRes = new List<Resources>();
     public List<Resources> ClonResMove = new List<Resources>();
    [HideInInspector] public bool Drag = true;
    [HideInInspector] public Resources [,] Map = new Resources[9,9];
    public Characteristics Ch;
    void Start()
    {
        GameObject GO;
        for(int x = 0; x < 9; x++)
        {
            for (int z = 0; z < 9; z++)
            {
                GO = Instantiate(Tile, new Vector3(x, 0, z), Quaternion.identity);
                GO.transform.SetParent(transform, false);
                Map[x, z] = GO.GetComponent<Resources>();
                Map[x, z].GL = this;
                if (z > 0 && x > 0 && z < 8 && x < 8)
                {
                    Map[x, z].Type = Random.Range(2, 6);
                    Map[x, z].Invoke("SetNew", 0);
                }
                else
                {
                    Map[x, z].Type = -1;
                }
            }
        }
    }
    void GetTiles()
    {
        ClonRes.Add(Map[PosTile.x, PosTile.y]);
        RecGetTiles(PosTile.x,  PosTile.y, ClonRes);
        if (Ch.Res[ClonRes[0].Type].Size- Ch.Res[ClonRes[0].Type].Count < ClonRes.Count) 
        {
            Ch.Res[ClonRes[0].Type].Count = Ch.Res[ClonRes[0].Type].Size; 
        } 
        else
        {
            Ch.Res[ClonRes[0].Type].Count += ClonRes.Count;
        }
        for (int N = ClonRes.Count - 1; N >= 0; N--)
        {
            ClonRes[N].Invoke("GetResource", 0);
        }
    }
    void RecGetTiles(int x,int z,List<Resources> R)
    {
        if (!R.Contains(Map[x + 1, z]) &&Map[x+1, z].Type == R[0].Type)
        {
            R.Add(Map[x+1, z]);
            RecGetTiles(x + 1, z, R);
        }
        if (!R.Contains(Map[x - 1, z]) && Map[x - 1, z].Type == R[0].Type)
        {
            R.Add(Map[x - 1, z]);
            RecGetTiles(x - 1, z, R);
        }
        if (!R.Contains(Map[x, z+1]) && Map[x, z+1].Type == R[0].Type)
        {
            R.Add(Map[x, z+1]);
            RecGetTiles(x, z+1, R);
        }
        if (!R.Contains(Map[x, z-1]) && Map[x, z-1].Type == R[0].Type)
        {
            R.Add(Map[x, z-1]);
            RecGetTiles(x, z-1, R);
        }
    }
    void GetResourceNext()
    {
        Ch.Invoke("NextStep", 0);
        DownTiles();
    }
    void DownTiles()
    {
        for (int x = 1; x <= 7; x++)
        {
            for (int z = 1; z <= 7; z++)
            {
                if (Map[x, z].Type == -1)
                {
                    ClonRes.Add(Map[x, 8]);
                    DownRow(x, z);
                    z = 8;
                }
            }
        }
        for (int N = ClonRes.Count - 1; N >= 0; N--)
        {
            ClonRes[N].Invoke("Instance", 0);
        }
        for (int N = ClonResMove.Count - 1; N >= 0; N--)
        {
            ClonResMove[N].Invoke("Jump", 0);
        }
    }
    void DownRow(int x, int z)
    {
        for (int R = z; R <= 6; R++)
        {
            if (Map[x, R].Type == -1&& Map[x, R + 1].Type != -1)
            {
                Map[x, R].Type = Map[x, R + 1].Type;
                Map[x, R+1].Type = -1;
                ClonResMove.Add(Map[x, R + 1]);
            }
        }
        Map[x,8].Type = Random.Range(2, 6);
        Map[x, 7].Type = Map[x, 8].Type;
    }
    void DownRowNext()
    {
        for (int x = 1; x <= 7; x++)
        {
            Map[x, 8].Type = -1;
            for (int z = 1; z <= 7; z++)
            {
                if (Map[x, z].Type!=-1) {
                    ClonRes.Add(Map[x, z]);
                    Map[x, z].Invoke("SetNewNext", 0); 
                }
            }
        }
    }
    void TilesSet()
    {
        if (!IFTilesSetting())
        {
            DownTiles();
        }
        else
        {
            Drag = true;
            Quest.Invoke("Reset", 0);
        }
    }
    bool IFTilesSetting() {
        for (int x = 1; x < 8; x++)
        {
            for (int z = 1; z < 8; z++)
            {
                if (Map[x, z].Type == -1)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
