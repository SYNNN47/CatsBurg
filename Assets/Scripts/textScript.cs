using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class textScript : MonoBehaviour
{
    public TMP_Text tmpText;
    public GameObject nextBtn;
    public float delay = 0.1f; // Waktu jeda antar karakter

    private bool text1 = false;
    private bool text2 = false;
    private bool text3 = false;
    private bool text4 = false;
    private bool nxtScene = false;

    public Image image;
    //public Image image2;
    public Sprite newSprite1;
    public Sprite newSprite2;


    private void Start()
    {
        // Mulai animasi teks
        if(SceneManager.GetActiveScene().name.Equals("Pre-Game Cut Scene"))
        {
            StartCoroutine(ShowText("Hey Burdy, aku bosan... dengan lingkungan ini, pasti enak kalo jadi kamu bisa terbang kemana aja..."));
            image.sprite = newSprite1;
        }
        else if (SceneManager.GetActiveScene().name.Equals("EndingScene"))
        {
            StartCoroutine(ShowText("K: uhh capeknya..."));
            image.sprite = newSprite1;
        }

    }

    IEnumerator ShowText(string text)
    {
        nextBtn.SetActive(false);
        tmpText.text = "";
        foreach (char c in text)
        {
            tmpText.text += c;
            yield return new WaitForSeconds(delay); // Tunggu sesuai dengan delay
        }
        //yield return new WaitForSeconds(5f);
        nextBtn.SetActive(true);
    }

    public void showTextCutScene()
    {
        if (SceneManager.GetActiveScene().name.Equals("Pre-Game Cut Scene"))
        {
            if (!text1)
            {
                StartCoroutine(ShowText(" Kamu bosan?? kenapa ga ikut aku aja!"));
                image.sprite = newSprite2;
                text1 = true;
            }
            else if (!text2)
            {
                StartCoroutine(ShowText(" HAH?! emangnya kemana tujuan kita??"));
                image.sprite = newSprite1;
                text2 = true;
            }
            else if (!text3)
            {
                StartCoroutine(ShowText("Udah... kamu ikut aku aja"));
                image.sprite = newSprite2;
                text3 = true;
            }
            else if (!text4)
            {
                StartCoroutine(ShowText(" EHH TUNGGU!!"));
                image.sprite = newSprite1;
                text4 = true;
            }
            else if (!nxtScene)
            {
                SceneManager.LoadScene("Scene1");
                nxtScene = true;
            }
        }
        else if (SceneManager.GetActiveScene().name.Equals("EndingScene"))
        {
            if (!text1)
            {
                StartCoroutine(ShowText(" Akhirnya kamu sampai juga, bagaimana pemandangan disini???"));
                text1 = true;
                image.sprite = newSprite2;
            }
            else if (!text2)
            {
                StartCoroutine(ShowText(" woahhhhhh...menakjubkan, seperti poster dikamar majikanku"));
                text2 = true;
                image.sprite = newSprite1;
            }
            else if (!text3)
            {
                StartCoroutine(ShowText(" nikmatilah..."));
                text3 = true;
                image.sprite = newSprite2;
            }
            else if (!nxtScene)
            {
                SceneManager.LoadScene("Main Menu");
                nxtScene = true;
            }
        }
    }
}

