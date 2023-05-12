using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RussiaManager : MonoBehaviour
{
    [SerializeField] int randomTime = 0;
    [SerializeField] float time;
    [SerializeField] float espionageTime;
    [SerializeField] int maxTime = 10;

    public int bombs = 0;
    public TextMeshProUGUI bombText;

    // Update is called once per frame
    void Update()
    {
        if(time > randomTime)
        {
            incr();
        }
        if(!DialogueBox.Singleton.isShown)
            time += Time.deltaTime;
    }

    void incr()
    {
        bombs++;
        randomTime = Random.Range(3, maxTime);
        time = 0;
        if(bombs > GameManager.Singleton.bombCount)
        {
            // Game End Scenario
            EndScreenManager.Singleton.Show(true);
        }
    }

    public void UpdateDisplay()
    {
        bombText.text = bombs + " Bombs";
    }

    public void Add(int val)
    {
        bombs += val;
    }

    public void Mult(float val)
    {
        bombs = Mathf.FloorToInt(bombs * val);
    }

    public void Set(int val)
    {
        bombs = val;
    }

    public void Espionage()
    {
        StartCoroutine("EspionageTimer");
    }

    IEnumerator EspionageTimer()
    {
        GameManager.Singleton.bombButton.interactable = false;
        yield return new WaitForSeconds(espionageTime);
        GameManager.Singleton.bombButton.interactable = true;
        UpdateDisplay();
    }

    public void SetEspionageTime(float val)
    {
        espionageTime = val;
    }
    public void SetMaxTime(int max)
    {
        maxTime = max;
    }
}
