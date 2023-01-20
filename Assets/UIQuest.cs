using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIQuest : MonoBehaviour
{
    public Button QuestInfo,RestartLvl;
    public Characteristics Ch;
    public Text Need, Get,CompleteTherm;
    public List <int> NeedRes = new List <int>();
    public GameObject CompleteQuest,Alpha,Restart;
    void Start()
    {
        NeedRes.Add(120);//2
        NeedRes.Add(80);//3
        NeedRes.Add(60);//4
        NeedRes.Add(40);//5
        NeedRes.Add(Ch.CountEndStep+15*6);//numDays;
        //QuestInfo.onClick.AddListener(Reset);
        RestartLvl.onClick.AddListener(ReLvl);
        CompleteQuest.GetComponent<Button>().onClick.AddListener(SetCompleted);
        Reset();
    }
    void ReLvl()
    {
        Ch.Invoke("Iniciate",0);
        GetComponent<GameLogic>().Drag = true;
    }
    void Reset()
    {
        Need.text = "Собрать:\n- "
            + NeedRes[0] + " ед.провизии\n- "
            + NeedRes[1] + " ед.материалов\n- "
            + NeedRes[2] + " ед.изделий\n- "
            + NeedRes[3] + " ед.книг";
        string Txt = "Собрано:\n- ", TxtLine = "\n";
        if(Ch.Res[2].Count>= NeedRes[0])
        {
            Txt += NeedRes[0];
            TxtLine += "____________\n";
        }
        else
        {
            Txt += Ch.Res[2].Count;
            TxtLine += "\n";
        }
        Txt += " ед.провизии\n- ";
        if (Ch.Res[3].Count >= NeedRes[1])
        {
            Txt += NeedRes[1];
            TxtLine += "_____________\n";
        }
        else
        {
            Txt += Ch.Res[3].Count;
            TxtLine += "\n";
        }
        Txt += " ед.материалов\n- ";
        if (Ch.Res[4].Count >= NeedRes[2])
        {
            Txt += NeedRes[2];
            TxtLine += "__________\n";
        }
        else
        {
            Txt += Ch.Res[4].Count;
            TxtLine += "\n";
        }
        Txt += " ед.изделий\n- ";
        if (Ch.Res[5].Count >= NeedRes[3])
        {
            Txt += NeedRes[3];
            TxtLine += "________";
        }
        else
        {
            Txt += Ch.Res[5].Count;
        }
        Txt += " ед.книг";
        Get.text = Txt;
        CompleteTherm.text = TxtLine;

        if (Ch.CountEndStep >= NeedRes[4])
        {
            Restart.SetActive(true);
            GetComponent<GameLogic>().Drag = false;
        }
        if(Ch.Res[2].Count >= NeedRes[0]&& Ch.Res[3].Count >= NeedRes[1] && Ch.Res[4].Count >= NeedRes[2] && Ch.Res[5].Count >= NeedRes[3])
        {
            CompleteQuest.SetActive(true);
        }
    }
    void SetCompleted()
    {
        for(int i = 0; i < 4; i++)
        {
            Ch.Res[i+2].Count-=NeedRes[i];
        }
        Alpha.SetActive(true);
        //Ch.numQuest++;
    }
}
