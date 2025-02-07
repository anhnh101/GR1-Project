using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text textUI;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource deathSFX;

    private Rigidbody2D rb;
    private Animator animator;

    private int remainingDuration;
    public int Duration;


    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        TimeRun(Duration);
    }

    private void TimeRun(int second)
    {
        remainingDuration = second;
        StartCoroutine(UpdateTimer());
        
    }

    private IEnumerator UpdateTimer()
    {
        
        while (remainingDuration >= 0) 
        {
            textUI.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            remainingDuration--;
            if (remainingDuration < 0)
            {
                Die();
            }
            yield return new WaitForSeconds(1f);
            
        }
    }

    private void Die()
    {
        deathSFX.Play();
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }
}
