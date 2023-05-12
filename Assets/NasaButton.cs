using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NasaButton : MonoBehaviour
{
    [SerializeField] Sprite nasa;
    public void Bonus()
    {
        StartCoroutine("DoBonus");
        GetComponent<Button>().interactable = false;
        Invoke("EnableButton", 15);
    }

    public void EnableButton()
    {
        GetComponent<Button>().interactable = true;
    }

    IEnumerator DoBonus()
    {
        var sprite = GameManager.Singleton.bombButton.image.sprite;
        GameManager.Singleton.bombButton.interactable = false;
        yield return new WaitForSeconds(5);

        GameManager.Singleton.bombButton.interactable = true;
        int old = GameManager.Singleton.clicksPerBomb;
        GameManager.Singleton.setClicksPerBomb(2);
        GameManager.Singleton.bombButton.image.sprite = nasa;
        yield return new WaitForSeconds(Random.Range(2, 7));

        GameManager.Singleton.setClicksPerBomb(old);
        GameManager.Singleton.bombButton.image.sprite = sprite;
    }
}
