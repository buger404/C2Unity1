using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUISet : MonoBehaviour
{
    public Text Perfect, Good, Bad, Miss, MaxCombo, Score, Accuracy, Grade;
    private void Awake()
    {
        Perfect.text = Judgement.ComboStat[(int)Judgement.ComboType.Perfect].ToString();
        Good.text = Judgement.ComboStat[(int)Judgement.ComboType.Good].ToString();
        Bad.text = Judgement.ComboStat[(int)Judgement.ComboType.Bad].ToString();
        Miss.text = Judgement.ComboStat[(int)Judgement.ComboType.Miss].ToString();
        MaxCombo.text = Judgement.MaxCombo.ToString();
        Score.text = Judgement.Score.ToString("000000");
        Accuracy.text = (Mathf.Round(Judgement.Accuracy * 10000f) / 100f).ToString(".00") + "%";
        Grade.text = Judgement.Grade;
    }
}
