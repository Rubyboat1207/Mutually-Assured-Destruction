using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public static DialogueBox Singleton;
    [SerializeField] GameObject Box;
    [SerializeField] Image overlay;
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] float charAppearTime = 0.1f;
    [SerializeField] bool doneAppear;
    string targetText = "";
    float timer;

    public bool isShown;

    public void Start()
    {
        Singleton = this;
    }

    public void Display(string text)
    {
        Box.SetActive(true);
        BlurManager.Singleton.Show();
        targetText = text + "\n [Enter to close]";
        Text.text = "";
        isShown = true;
        doneAppear = false;
        MusicManager.SetDialogue.Invoke();
        overlay.raycastTarget = true;
    }

    private void Update()
    {
        if(isShown)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                if(doneAppear)
                {
                    Completed();
                }else
                {
                    Done();
                }
            }
            if(!doneAppear) {
                timer += Time.deltaTime;
                if(timer > charAppearTime)
                {
                    timer = 0;
                    Text.text += targetText[Mathf.Clamp(Text.text.Length, 0, targetText.Length - 1)];
                }
                if(Text.text == targetText)
                {
                    Done();
                }
            }
        }
    }

    void Done()
    {
        doneAppear = true;
        Text.text = targetText;
    }

    void Completed()
    {
        isShown = false;
        Box.SetActive(false);
        BlurManager.Singleton.Hide();
        if(!GameManager.Singleton.isEndgame)
        {
            MusicManager.SetNormal.Invoke();
        }
        overlay.raycastTarget = false;
    }
}
