using UnityEngine;
using System.Collections;

public class ZombieBehaviour : MonoBehaviour {

    Transform target;
    Animator anim;

    [SerializeField]
    float zombieSpeed = 3f;
    [SerializeField]
    float zombieHealth = 100f;


	// Use this for initialization
	void Start () {
        if(!GameManager.gameManager.GameEnded())
             target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            Following();
        }
	}

    void Following()
    {
        var dir = target.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * zombieSpeed);

        if (target != null)
        {   
                
            if(Vector3.Distance(transform.position,target.position) < 2f)
            {
                anim.SetBool("IsMoving", false);
                anim.SetTrigger("Attack");
            }
            else
            {
                anim.SetBool("IsMoving", true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        zombieHealth -= 20;
        if(zombieHealth <= 0)
        {
            SpawnRandomBlood();
            GameManager.gameManager.IncreasePoints();
            Destroy(gameObject);
        }
    }

    void SpawnRandomBlood()
    {
        int random = Random.Range(1, 5);
        Instantiate(Resources.Load("Blood" + random), transform.position, Quaternion.identity);
    }

    void AttackPlayer()
    {
        if (target != null)
        {
            target.GetComponent<PlayerDamage>().ZombieHit();
        }
    }
}
