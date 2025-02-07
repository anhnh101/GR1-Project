using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneFinish : MonoBehaviour
{
    
    [SerializeField] private GameObject finishUI = null;
    [SerializeField] private Text pointText = null;
    [SerializeField] private Text maxPointText = null;

    private int pointCount = 0;
    public int maxPoint = 0;
    //private int currentStage = 0;

    private Rigidbody2D rb;
    private void Awake()
    {
        maxPointText.text = "/ " + maxPoint;
        PlayerPrefs.SetInt("saveMaxPoint", maxPoint);
        
    }

    private void Start()
    {
        DeletePoint();
        PlayerPrefs.SetInt("savePoint", pointCount);
        rb = GetComponent<Rigidbody2D>();
        PlayerPrefs.SetInt("currentStage", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("unlockStage", PlayerPrefs.GetInt("currentStage"));
    }


    private void Update()
    {
        pointText.text = PlayerPrefs.GetInt("savePoint").ToString();
        pointCount = int.Parse(pointText.text);
        if (pointCount == maxPoint)
        {
            if (rb.bodyType != RigidbodyType2D.Static)
            {
                if (finishUI != null)
                {
                    FinishStage();
                    PressToCont();
                }
            }
            
        }
    }

    //public void SetCurrentStage()
    //{
    //    currentStage++;
    //    PlayerPrefs.SetInt("currentStage", currentStage);
    //}

    public void FinishStage()
    {
        
        finishUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void PressToCont()
    {
        if (Input.anyKeyDown && finishUI.activeSelf == true)
        {
            Time.timeScale = 1f;
            //SetCurrentStage();
            //Debug.Log(PlayerPrefs.GetInt("currentStage"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    public void DeletePoint()
    {
        PlayerPrefs.DeleteKey("savePoint");
    }
}
