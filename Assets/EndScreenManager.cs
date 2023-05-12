using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    public static EndScreenManager Singleton;
    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;
    }

    public void Show(bool failed=false)
    {
        endScreen.SetActive(true);
        if(failed)
        {
            endScreen.GetComponent<Image>().color = Color.red;
            Invoke("reload", 5);
        }
    }

    void reload()
    {
        SceneManager.LoadScene(0);
    }
}
