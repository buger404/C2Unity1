using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoPlaySwitch : MonoBehaviour
{
    public List<Sprite> Sprites;
    public void Touch()
    {
        Judgement.AutoPlay = !Judgement.AutoPlay;
        GetComponent<Image>().sprite = Sprites[Judgement.AutoPlay ? 1 : 0];
    }
}
