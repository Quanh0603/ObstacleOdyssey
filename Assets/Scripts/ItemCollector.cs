using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private int crystal = 0;
    private int totalCrystals;
    [SerializeField] private TextMeshProUGUI crystalsText;
    [SerializeField] private AudioSource collectsoundeffect;
    private int currentLevelIndex;
    void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        totalCrystals = GameObject.FindGameObjectsWithTag("Crystal").Length;
        crystalsText.text = "Level " + currentLevelIndex + " - Crystals: " + crystal + "/" + totalCrystals;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crystal"))
        {
            collectsoundeffect.Play();
            Destroy(collision.gameObject);
            crystal++;
            crystalsText.text = "Level " + currentLevelIndex + " - Crystal: " + crystal + "/" + totalCrystals;
            PlayerPrefs.SetInt("Crystal", crystal);
        }
    }
    public bool checkCrystals()
    {
        return crystal == totalCrystals;
    }
}
