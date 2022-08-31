using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI expText;
    public GameObject deathMenuUI;
    public static float currentExp = 0;
    public static float maxExp = 0;
    public AudioSource gemAudio;
    public Collider2D playerCollider;
    public GameObject exp;
    public static float currentLevel = 1;
    public GameObject levelUp;
    public AudioSource levelUpAudio;
    public bool leveledUp = false;
    public GameObject levelUpUI;

    public float offsetTime = 2f;
    private float timer = 0f;
    void Start()
    {
        currentExp = 0;
        maxExp = 25;
    }

    // Update is called once per frame
    void Update()
    {
        expText.text = "Level: " + ExpScript.currentLevel;

        if (currentExp == maxExp)
        {
            if (currentLevel < 10)
            {
                leveledUp = true;
                currentLevel++;
                ExpScript.currentExp = 0;
                levelUpAudio.Play();
                levelUp.SetActive(false);
                levelUp.SetActive(true);
            }
        }
        if (leveledUp)
        {
            timer += Time.deltaTime;
            if (timer > offsetTime)
            {
                timer = 0f;
                levelUpUI.SetActive(true); //brings up level up menu
                Time.timeScale = 0f; //freezes game
                leveledUp = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem") && !deathMenuUI.activeSelf)
        {
            Destroy(collision.gameObject);
            gemAudio.Play();
            ExpScript.currentExp += 1;
            exp.SetActive(false);
            exp.SetActive(true);
        }
    }
}
