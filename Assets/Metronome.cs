using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    private float BPM = 120.0F;
    private bool active = true;
    private float nextTime;
    private float lastTime;

    private RectTransform rectTransformBarL;
    private RectTransform rectTransformBarR;

    public delegate void MetronomeAction();
    public static event MetronomeAction OnMetronomeTick;

    // Start is called before the first frame update
    void Start()
    {
        rectTransformBarL = transform.Find("LeftBar").GetComponent<RectTransform>();
        rectTransformBarR = transform.Find("RightBar").GetComponent<RectTransform>();
        StartCoroutine(MetronomeRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        var range = (Time.time-lastTime)/(nextTime-lastTime);

        this.rectTransformBarL.anchoredPosition = new Vector2(Mathf.Lerp(0f,100f,range),0f);
        new Vector2(Mathf.Lerp(0f,100f,range),0f);
        this.rectTransformBarR.anchoredPosition = new Vector2(Mathf.Lerp(0f,-100f,range),0f);
    }

    public IEnumerator MetronomeRoutine(){
        this.nextTime = Time.time;
        while(active){
            this.lastTime = Time.time;
            this.nextTime += 60/this.BPM;
            yield return new WaitForSecondsRealtime(this.nextTime-Time.time);
            if (OnMetronomeTick != null) {OnMetronomeTick();}
        }
    }
}
