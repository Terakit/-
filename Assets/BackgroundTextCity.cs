using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BackgroundTextCity : MonoBehaviour
{
    public Characteristics Ch;
    public Text CounterEndStep;
    public Image Line;
    public Text ResCount,ResPlus;

    void Update()
    {
        Line.fillAmount = 1f / 6 * (Ch.CountEndStep % 6 + 1);
        CounterEndStep.text = "День - " + Ch.CountEndStep / 6;
        ResCount.text = "На складе/Вместимость:\n\n" +
            Ch.Res[0].Count + "/" + Ch.Res[0].Size + "\n" +
            Ch.Res[2].Count + "/" + Ch.Res[2].Size + "\n" +
            Ch.Res[3].Count + "/" + Ch.Res[3].Size + "\n" +
            Ch.Res[4].Count + "/" + Ch.Res[4].Size + "\n" +
            Ch.Res[5].Count + "/" + Ch.Res[5].Size + "\n" +
            Ch.Res[1].Count + "/" + Ch.Res[1].Size + "\n";

        ResPlus.text = "Прирост в день:\n\n" +
            (Ch.Res[0].IncC - Ch.Res[0].DecC) + "\n" +
            (Ch.Res[2].IncC - Ch.Res[2].DecC) + "\n" +
            (Ch.Res[3].IncC - Ch.Res[3].DecC) + "\n" +
            (Ch.Res[4].IncC - Ch.Res[4].DecC) + "\n" +
            (Ch.Res[5].IncC - Ch.Res[5].DecC) + "\n" +
            (Ch.Res[1].IncC - Ch.Res[1].DecC) + "\n";
    }
}
