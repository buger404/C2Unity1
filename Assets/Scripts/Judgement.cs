using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judgement : MonoBehaviour
{
    #region 公开静态部分
    public enum ComboType
    {
        Perfect, Good, Bad, Miss
    }
    public static Judgement Instance;
    public static int HitIndex = 0;
    public static long Combo = 0, MaxCombo = 0, FullCombo = 0;
    public static bool AutoPlay = false;
    public static long[] ComboStat = new long[4];
    public static bool AnykeyUp = true;
    public static string Grade
    {
        get
        {
            float acc = Accuracy;
            if (acc == 1f)
            {
                return "SSS";
            }else if(acc >= 0.95f)
            {
                return "S";
            }
            else if (acc >= 0.9f)
            {
                return "A";
            }
            else if (acc >= 0.8f)
            {
                return "B";
            }
            else if (acc >= 0.7f)
            {
                return "C";
            }
            else
            {
                return "F";
            }
        }
    }
    public static float Score
    {
        get
        {
            return Accuracy * 90000f + (MaxCombo * 1.0f / FullCombo) * 10000f;
        }
    }
    public static float Accuracy
    {
        get
        {
            return (ComboStat[(int)ComboType.Perfect] * 1.0f + ComboStat[(int)ComboType.Good] * 0.6f + ComboStat[(int)ComboType.Bad] * 0.2f) / FullCombo;
        }
    }
    public static void UpdateText()
    {
        Instance.ComboText.text = Combo.ToString();
        Instance.ScoreText.text = Mathf.Ceil(Score).ToString("000000");
    }
    public static void Hit(ComboType type)
    {
        if(type == ComboType.Miss)
        {
            Combo = 0;
        }
        else
        {
            Combo++;
            if (Combo > MaxCombo) MaxCombo = Combo;
            foreach(Animator animator in Instance.Shine)
                animator.Play("Shine", 0, 0.0f);
        }
        GameObject.Instantiate(Instance.StatObj[(int)type]).SetActive(true);
        ComboStat[(int)type]++;
        UpdateText();
        HitIndex++;
    }
    #endregion
    #region 动态部分
    public Text ComboText, ScoreText;
    public List<Animator> Shine;
    public List<GameObject> StatObj;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
}
