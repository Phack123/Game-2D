using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    //public GameManagerScrip gameManager;
    [SerializeField] private AudioSource DeadSound;
    //[SerializeField] private AudioSource HeathSound;

    public Scrollbar healtBar;
    public float healtAmount = 100f;
    public static float Testheath;
    //public Text HeathFull;

    //Set máu khi qua màn
    private void Awake()
    {
        healtBar.size = healtAmount / 100f;
        //if (PointCollect.SaveHeath != 0)
        //{
        //    healtAmount = PointCollect.SaveHeath;
        //    healtBar.fillAmount = healtAmount / 100f;
        //}

    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        //Kiểm tra có mất máu hay không, nếu có thì truyền lượng máu hiên tại => TestHeath;
        if (healtAmount != 100f)
        {
            Testheath = healtAmount;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (healtAmount < 100f)
            {
                Heal(20f);
            }
            else
            {
                //HeathFull.gameObject.SetActive(true);
                //StartCoroutine(WaitForFunction(5));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Trap"))
        {

            if (healtAmount <= 0)
            {
                Die();
               
            }
            else
            {
                TakeDamage(20f);
            }
        }
        if (collision.gameObject.CompareTag("Bullet_cannon"))
        {

            if (healtAmount <= 0)
            {
                Die();
            }
            else
            {
                TakeDamage(20f);
            }
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            healtAmount = 0;
            Die();
        }

        if (collision.gameObject.CompareTag("Enemy") || (collision.gameObject.CompareTag("Enemy2")))
        {
            if (healtAmount <= 0)
            {
                Die();
                
            }
            else
            {
                TakeDamage(20f);
            }
        }
        if (collision.gameObject.CompareTag("Enemy3"))
        {
            if (healtAmount <= 0)
            {
                Die();
            }
            else
            {
                TakeDamage(40f);
            }
        }

        if (collision.gameObject.CompareTag("Enemy4"))
        {
            if (healtAmount <= 0)
            {
                Die();
            }
            else
            {
                TakeDamage(60f);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Heart"))
        //{
        //    HeathSound.Play();
        //    if(healtAmount < 100f)
        //    {
        //        Heal(20f);
        //        Destroy(collision.gameObject);
        //    }
        //    else
        //    {
        //        HeathFull.gameObject.SetActive(true);
        //        Destroy(collision.gameObject);
        //        StartCoroutine(WaitForFunction(2));
        //    }
        //}
    }

    //Nhận sát thương
    public void TakeDamage(float damage)
    {
        healtAmount -= damage;
        healtBar.size = healtAmount / 100f;
    }
    //Hồi máu
    public void Heal(float healingAmount)
    {
        healtAmount += healingAmount;
        // healtAmount = Mathf.Clamp(healingAmount, 0, 100);
        healtBar.size = healtAmount / 100f;
    }

    //Xử lý sự kiện khi chết: hiện Label Game over, chạy SoundDead, set Coin = 0;
    private void Die()
    {
        DeadSound.Play();
        
        anim.SetTrigger("Death");
        //ItemCollector.Coins = 0;
        //gameManager.gameOver();
    }
    IEnumerator WaitForFunction(int time)
    {
        yield return new WaitForSeconds(time);
       
        //HeathFull.gameObject.SetActive(false);
    }

}
