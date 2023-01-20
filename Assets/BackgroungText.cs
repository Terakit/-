using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BackgroungText : MonoBehaviour
{
    public Characteristics Ch;
    public Image Line;
    public Text CounterEndStep,Product,Material,Metall,Knowledge;

    void Update()
    {
        Line.fillAmount = 1f/6*(Ch.CountEndStep % 6+1);
        CounterEndStep.text = "Δενό - " + ((Ch.CountEndStep / 6) % 30+1);
        //Product.text = "" + Ch.Res[2].Count + "/" + Ch.Res[2].Size;
        //Material.text = "" + Ch.Res[3].Count + "/" + Ch.Res[3].Size;
        //Metall.text = "" + Ch.Res[4].Count + "/" + Ch.Res[4].Size;
        //Knowledge.text = "" + Ch.Res[5].Count + "/" + Ch.Res[5].Size;
    }
}
