using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [HideInInspector] public GameLogic GL;
    public Animator animator;
    public int Type = 0;//позиция в списке 
    public AudioSource AS_GetRes;
    public List<GameObject> Tiles = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < Tiles.Count; i++)
        {
            Tiles[i].SetActive(false);
        }
    }
    void SetNew()
    {
        for (int i = 0; i < Tiles.Count; i++)
        {
            Tiles[i].SetActive(false);
        }
        Tiles[Type-2].SetActive(true);
        Tiles[Type + 2].SetActive(true);
        Tiles[Type + 6].SetActive(true);
        animator.SetBool("Сбор", false);
        animator.SetBool("Прыжок", false);
        animator.SetBool("Появление", false);
        animator.Play("БлокСтатичная");
    }
    void SetNewNext()
    {
        SetNew();
        GL.ClonRes.Remove(this);
        if (GL.ClonRes.Count == 0)
        {
            GL.Invoke("TilesSet", 0);
        }
    }
    void GetResource()
    {
        animator.SetBool("Сбор", true);
        AS_GetRes.Play();
    }
    void GetResourceAfter()
    {
        Tiles[Type - 2].SetActive(false);
        Tiles[Type + 2].SetActive(false);
        Tiles[Type + 6].SetActive(false);
        Type = -1;
        GL.ClonRes.Remove(this);
        if (GL.ClonRes.Count == 0)
        {
            GL.Invoke("GetResourceNext", 0);
        }
    }
    void Jump()
    {
        animator.SetBool("Прыжок", true);
    }
    void JumpAfter()
    {
        GL.ClonResMove.Remove(this);
        if (GL.ClonResMove.Count ==0 && GL.ClonRes.Count == 0) {
            GL.Invoke("DownRowNext", 0);
        }
    }
    void Instance()
    {
        animator.SetBool("Появление", true);
        Tiles[Type - 2].SetActive(true);
        Tiles[Type + 2].SetActive(true);
        Tiles[Type + 6].SetActive(true);
    }
    void InstanceAfter()
    {
        Tiles[Type - 2].SetActive(false);
        Tiles[Type + 2].SetActive(false);
        Tiles[Type + 6].SetActive(false);
        animator.SetBool("Появление", false);
        GL.ClonRes.Remove(this);
        if (GL.ClonResMove.Count == 0 && GL.ClonRes.Count == 0)
        {
            GL.Invoke("DownRowNext", 0);
        }
    }
}
