using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public float Time, FlowSpeed;
    public AudioSource Source, HitSnd;
    public Transform Destination;
    public int Index;
    public bool Hit = false;
    private void Awake()
    {
        HitSnd = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Hit) return;
        if (Mathf.Abs(Source.time - Time) <= 2)
        {
            Vector3 pos = transform.position;
            pos.x = Destination.position.x - (Source.time - Time) * FlowSpeed;
            transform.position = pos;
        }
        if (Judgement.HitIndex != Index) return;
        float delta = Mathf.Abs(Source.time - Time);
        if (delta > 0.5f) return;
        if (Source.time - Time > 0.3f)
        {
            Judgement.Hit(Judgement.ComboType.Miss);
            Hit = true;
        }
        bool anyKey = Input.anyKeyDown;
        if (!anyKey & !Judgement.AnykeyUp) Judgement.AnykeyUp = true;
        if (!Judgement.AnykeyUp) anyKey = false;
        if (Judgement.AutoPlay) anyKey = false;
        if ((Source.time - Time >= 0 && Judgement.AutoPlay) || anyKey)
        {
            Judgement.AnykeyUp = false;
            if (delta <= 0.1f)
            {
                Judgement.Hit(Judgement.ComboType.Perfect);
            }else if(delta <= 0.2f)
            {
                Judgement.Hit(Judgement.ComboType.Good);
            }else if(delta <= 0.3f)
            {
                Judgement.Hit(Judgement.ComboType.Bad);
            }
            else
            {
                Judgement.Hit(Judgement.ComboType.Miss);
            }
            Hit = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            HitSnd.Play();

        }
    }
}
