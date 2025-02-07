using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour//, IDataPersistence
{
    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D boxCollider;

    [SerializeField] private AudioSource deathSFX;
    [SerializeField] private Text deathCount = null;

    //[SerializeField] private Text livesCount = null;

    [SerializeField] private DataPersistenceManager dpManager = null;
    private int deathTimes = 0;
    private int saveDeathTimes = 0;
    //private int lives = 1;
    // Start is called before the first frame update
    void Start()
    {
        //lives = 5;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        //bullet = GetComponent<GameObject>();
        if (PlayerPrefs.HasKey("saveDeathTimes"))
        {
            LoadDeathTimes();
            saveDeathTimes = PlayerPrefs.GetInt("saveDeathTimes");
            //Debug.Log(saveDeathTimes + "a");
        }
        else
        {
            SaveDeathTimes(deathTimes);
            saveDeathTimes = PlayerPrefs.GetInt("saveDeathTimes");
            //Debug.Log(saveDeathTimes + "b");
        }
        deathTimes = PlayerPrefs.GetInt("saveDeathTimes");

        /*if (PlayerPrefs.HasKey("saveLives"))
        {
            LoadLives();
        }
        else
        {
            SaveLives(lives);
        }
        lives = PlayerPrefs.GetInt("saveLives");
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("DeathLine"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy Bullet"))
        {
            Die();
            
        }
    }

    public void Die()
    {
        //lives--;
        //SaveLives(lives);
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
        deathSFX.Play();
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        
    }

    public void RestartLevel()
    {
        deathTimes++;                                                        
        SaveDeathTimes(deathTimes);
        DeleteCoin();
        //DeletePoint();
        if(dpManager != null)
        {
            dpManager.DeleteData();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SaveDeathTimes(int deathTimes)
    {
        PlayerPrefs.SetInt("saveDeathTimes", deathTimes);
    }

    private void LoadDeathTimes()
    {
        deathCount.text = PlayerPrefs.GetInt("saveDeathTimes").ToString();
    }

    public void DeleteDeathTimes()
    {
        PlayerPrefs.DeleteKey("saveDeathTimes");
    }

    //private void SaveLives(int lives)
    //{
    //    PlayerPrefs.SetInt("saveLives", lives);
    //
    //}

    //private void LoadLives()
    //{
    //    livesCount.text = PlayerPrefs.GetInt("saveLives").ToString();
    //}

    //public void DeleteLives()
    //{
    //    PlayerPrefs.DeleteKey("saveLives");
    //}

    /*public void LoadData(GameData data) 
    {
        this.saveDeathTimes = data.deathTime;
        PlayerPrefs.SetInt("saveDeathTimes", saveDeathTimes);
    }

    public void SaveData(GameData data)
    {
        //this.deathTimes = PlayerPrefs.GetInt("saveDeathTimes");
        data.deathTime = this.saveDeathTimes;
    }*/

    public void DeleteCoin()
    {
        PlayerPrefs.DeleteKey("saveCoin");
    }

    public void DeletePoint()
    {
        if (PlayerPrefs.HasKey("savePoint"))
        {
            PlayerPrefs.DeleteKey("savePoint");
        }
        
    }
}
