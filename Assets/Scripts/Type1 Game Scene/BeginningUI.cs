using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningUI : MonoBehaviour
{
    [SerializeField] private GameObject beginningUI;

    private void Start()
    {
        Time.timeScale = 0f;
       
    }

    private void Update()
    {
        PressToCont();
    }

    private void PressToCont()
    {
            if (Input.anyKeyDown && beginningUI.activeSelf == true)
            {
                beginningUI.SetActive(false);
                Time.timeScale = 1f;
            }
        
    }

}
