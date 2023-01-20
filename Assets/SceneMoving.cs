using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneMoving : MonoBehaviour
{
    public Animator AFon;
    public Button NewGame,MainMenu,Quit;
    public GameObject Main, MainF, Sbor, SborF;
    public AudioSource AMain, ASbor;
    void Start()
    {
        NewGame.onClick.AddListener(ToCity);
        MainMenu.onClick.AddListener(ToMenu);
        Quit.onClick.AddListener(QuitAPP);
        Main.SetActive(true);
        MainF.SetActive(true);
        Sbor.SetActive(false);
        SborF.SetActive(false);
    }
    void ToCity()
    {
        AFon.SetBool("Next", true);
    }
    void City()
    {
        AFon.SetBool("Next", false);
        AMain.enabled = false;
        ASbor.enabled = true;
        Main.SetActive(false);
        MainF.SetActive(false);
        Sbor.SetActive(true);
        SborF.SetActive(true);
    }
    void ToMenu()
    {
        AFon.SetBool("ToMenu", true);
    }
    void Menu()
    {
        AFon.SetBool("ToMenu", false);
        AMain.enabled = true;
        ASbor.enabled = false;
        Main.SetActive(true);
        MainF.SetActive(true);
        Sbor.SetActive(false);
        SborF.SetActive(false);
    }
    void QuitAPP()
    {
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitAPP();
        }
    }
}
