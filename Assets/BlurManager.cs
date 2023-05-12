using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlurManager : MonoBehaviour
{
    public static BlurManager Singleton;
    [SerializeField] float transitionDuration;
    Image img;
    float a;
    // Start is called before the first frame update
    void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        var col = img.color;
        col.a = Mathf.Lerp(col.a, a, Time.deltaTime * transitionDuration);
        img.color = col;
    }

    public void Show()
    {
        // GetComponent<Image>().enabled = true;
        a = 0.5f;
    }

    public void Hide()
    {
        // GetComponent<Image>().enabled = false;
        a = 0;
    }
}
