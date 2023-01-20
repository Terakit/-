using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ResType{
    public string Name = "";
    public int Count = 0;
    public int Size = 0;
    public int IncC = 0,DecC = 0;
}

public class Characteristics : MonoBehaviour
{
    public List<ResType> Res = new List<ResType>();
    public int numQuest = 0;
    public int CountEndStep;
    void Awake()
    {
        Iniciate();
    }
    void Iniciate()
    {
        CountEndStep = 0;
        Res.Clear();
        Res.Add(new ResType());//0
        Res[Res.Count - 1].Name = "Ќаселение";
        Res[Res.Count - 1].Count = 10;
        Res[Res.Count - 1].Size = 12;
        Res.Add(new ResType());//1
        Res[Res.Count - 1].Name = "„удеса";
        Res[Res.Count - 1].Count = 0;
        Res[Res.Count - 1].Size = 50;
        Res.Add(new ResType());//2
        Res[Res.Count - 1].Name = "ѕровизи€";
        Res[Res.Count - 1].Count = 0;
        Res[Res.Count - 1].Size = 1000;
        Res.Add(new ResType());//3
        Res[Res.Count - 1].Name = "ћатериалы";
        Res[Res.Count - 1].Count = 0;
        Res[Res.Count - 1].Size = 1000;
        Res.Add(new ResType());//4
        Res[Res.Count - 1].Name = "ћеталлы";
        Res[Res.Count - 1].Count = 0;
        Res[Res.Count - 1].Size = 1000;
        Res.Add(new ResType());//5
        Res[Res.Count - 1].Name = "»сследовани€";
        Res[Res.Count - 1].Count = 0;
        Res[Res.Count - 1].Size = 1000;
        //ReRoll();
    }
    void ReRoll()
    {
        Res[0].IncC = Res[2].Count / 25;//население +1 в день за каждые 25 провизии в запасе(провизи€ не уходит);
        Res[1].IncC = Res[0].Count;//„удеса +1 в день за каждые 1 населени€ в запасе(население не уходит);
        Res[2].DecC = Res[0].Count * 5;//провизи€ -5 в день за за каждые 1 населени€ в запасе(если еды не хватает население уменьшаетс€)
        if (Res[2].DecC > Res[2].Count)
        {
            Res[2].DecC = Res[2].Count / 5 * 5;
            Res[0].DecC = Res[0].Count - Res[2].DecC / 5;
        }
    }
    void NextStep()
    {
        CountEndStep++;
        /*ReRoll();
        if (CountEndStep % 6 == 0)
        {

            for(int i=0;i< Res.Count; i++)
            {
                if(Res[i].Size< Res[i].Count + Res[i].IncC - Res[i].DecC)
                {
                    Res[i].Count = Res[i].Size;
                }else if(Res[i].Count + Res[i].IncC - Res[i].DecC < 0)
                {
                    Res[i].Count = 0;
                }
                else
                {
                    Res[i].Count = Res[i].Count + Res[i].IncC - Res[i].DecC;
                }
                Res[i].IncC = 0;
                Res[i].DecC = 0;
            }
            //перерасчет
            ReRoll();
        }*/
    }
}
