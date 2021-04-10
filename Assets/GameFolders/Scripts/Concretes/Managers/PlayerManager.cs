using AtomGameJamProject.Concretes.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public bool dead = false;
    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        AmIDead();
    }

    void AmIDead()
    {
        if (health <= 0)
        {
            dead = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            health--;
            Debug.Log("Deydi");
        }
        if (SceneManager.GetActiveScene().name == "BossScene" && health <= 0)
        {
            SceneManager.LoadScene(6);
        }
        if(SceneManager.GetActiveScene().name == "BossSceneCopy" && health <= 0)
        {
            SceneManager.LoadScene(9);
        }
        if(SceneManager.GetActiveScene().name == "Level" && health <= 0)
            SceneManager.LoadScene(4);
    }
}