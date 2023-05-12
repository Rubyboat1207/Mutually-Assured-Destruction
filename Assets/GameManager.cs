using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    public TMPro.TextMeshProUGUI Tutorial;
    public string formatStr;
    public Button bombButton;
    public int secondsPerYear = 30;
    float prevYear;
    [SerializeField] float timeTicks = 0.1f;
    public bool isEndgame
    {
        get
        {
            return getYear() > 1970;
        }
    }

    private void Start()
    {
        Singleton = this;
        prevYear = getYear();
        OnYear(prevYear);
        formatStr = Tutorial.text;
        Tutorial.text = string.Format(formatStr, clicksPerBomb);
        MusicManager.SetNormal.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        float year = getYear();
        if (Mathf.Floor(prevYear) < Mathf.Floor(year))
        {
            OnYear(year);
        }
        prevYear = year;
        if(!DialogueBox.Singleton.isShown)
        {
            timeTicks += Time.deltaTime;
        }
    }

    public float getYear()
    {
        return 1947 + (timeTicks / secondsPerYear);
    }

    public void OnYear(float year)
    {
        YearManager.singleton.UpdateWith(year);
    }

    [Header("Clicks")]
    public int bombCount = 0;
    int clicks = 0;
    public int clicksPerBomb = 10;
    public List<ClickEvent> events = new List<ClickEvent>();

    public void Click()
    {
        clicks++;
        if(clicks % clicksPerBomb == 0)
        {
            bombCount += clicksPerBomb < 0 ? -1 : 1;
            BombCounter.bombCounter.UpdateWith(bombCount);
            if(!isEndgame)
                events.ForEach(e => { if (e.clickReq == bombCount) { e.clickEvent.Invoke(); } });
        }
        if(clicksPerBomb < 0)
        {
            if(bombCount <= 0 )
            {
                EndScreenManager.Singleton.Show();
            }
        }
    }

    public void setClicksPerBomb(int cpb)
    {
        clicksPerBomb = cpb;
        Tutorial.text = string.Format(formatStr, clicksPerBomb);
    }

    public void Mult(float mul)
    {
        bombCount = Mathf.FloorToInt(bombCount * mul);
    }

    [System.Serializable]
    public class ClickEvent
    {
        public int clickReq;
        public UnityEvent clickEvent;
    }

    public void SetEndgameMusic()
    {
        MusicManager.SetEndgame.Invoke();
    }
}
