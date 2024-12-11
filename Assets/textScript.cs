using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textScript : MonoBehaviour
{
    public TMP_Text tmpText;
    public GameObject nextBtn;
    public float delay = 0.1f; // Waktu jeda antar karakter

    private bool text1 = false;

    private void Start()
    {   
        // Mulai animasi teks
        StartCoroutine(ShowText("halo selamat datang di Catsburg"));
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
            StartCoroutine(ShowText("ahahahahaha"));
            text1 = true;
        }
    }
}

