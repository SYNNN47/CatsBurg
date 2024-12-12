using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Start()
    {   
        // Mulai animasi teks
        StartCoroutine(ShowText("Hey Burdy, aku bosan... dengan lingkungan ini, pasti enak kalo jadi kamu bisa terbang kemana aja..."));
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
        if (!text1)
        {
            StartCoroutine(ShowText("Kamu bosan?? kenapa ga ikut aku aja!"));
            text1 = true;
        }
        else if (!text2)
        {
            StartCoroutine(ShowText("HAH?! emangnya kemana tujuan kita??"));
            text2 = true;
        }
        else if (!text3)
        {
            StartCoroutine(ShowText("Udah... kamu ikut aku aja"));
            text3 = true;
        }
        else if (!text4)
        {
            StartCoroutine(ShowText("EHH TUNGGU!!"));
            text4 = true;
        }
        else if (!nxtScene)
        {
            SceneManager.LoadScene("Scene1");
            nxtScene = true;
        }
    }
}

