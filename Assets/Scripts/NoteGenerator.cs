using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public GameObject Note;
    public TextAsset OsuChart;
    public List<Sprite> NoteSprite;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        string[] data = OsuChart.text.Split(new char[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        bool start = false;
        int i = 0, j = 0;
        foreach (string line in data)
        {
            if (start)
            {
                string[] t = line.Split(',');
                if (t.Length != 6) continue;
                GameObject note = Instantiate(Note);
                note.GetComponent<NoteController>().Time = float.Parse(t[2]) / 1000;
                note.GetComponent<NoteController>().Index = j;
                note.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = NoteSprite[i];
                note.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = NoteSprite[i];
                i++; j++;
                if (i >= NoteSprite.Count) i = 0;
            }
            if (line == "[HitObjects]") start = true;
        }
        Judgement.FullCombo = j;
        Note.SetActive(false);
    }
}
