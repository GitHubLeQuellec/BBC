using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    public GameObject forkPrefab;
    public Transform spawnPoint;
    public Transform player;
    [SerializeField] Collider2D ZgegCol;
    [SerializeField] Collider2D ColDeBase;
    private Animator Anim;
    [SerializeField]  int randomAnimation;
    [SerializeField] Rigidbody2D rbPlayer;

    void Start()
    {
        Anim = GetComponent<Animator>();
        InvokeRepeating("PlayRandomAnimation", 1f, 6f); // Lance une animation toutes les 6 secondes après une première attente de 3 secondes
    }

    void Update()
    {
        
    }
    
    //public void Zgeging()
    //{
    //    ColDeBase.enabled = true;
    //    StartCoroutine(Zgeg(2f));
    //    Anim.SetBool("Zgeging", true);
    //}
    //IEnumerator Zgeg(float cooldownDuration)
    //{
    //    yield return new WaitForSeconds(cooldownDuration);
    //    ColDeBase.enabled = false;
    //}

   
    private void PlayRandomAnimation()
    {
        
            int randomValue = Random.Range(0, 101); // Génère un nombre aléatoire entre 0 et 100 inclus
        Debug.Log(randomValue);

            if (randomValue <= 20)
            {
                Zgeging();
            }
            else
            {
                Forking();
            }
        
        /*randomAnimation = Random.Range(0, 2); // Génère un nombre aléatoire entre 0 et 2 inclus

        switch (randomAnimation)
        {
            case 0:
                Forking();
                break;
            case 1:
                Zgeging();
                break;
            //case 2:
            //    Idle();
            //    break;
            default:
                break;
        }*/
    }
    public void SpawnFork()
    {
        Vector2 direction = (player.position - spawnPoint.position).normalized;
        GameObject fork = Instantiate(forkPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D forkRigidbody = fork.GetComponent<Rigidbody2D>();
        forkRigidbody.velocity = direction * 10f;
    }
    public void Zgegos()
    {
        ZgegCol.enabled = !ZgegCol.enabled;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 forceDirection = (transform.position - other.transform.position).normalized;
            float forceMagnitude = 100f; // Modifier la magnitude de la force selon vos besoins

            rb.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
        }
    }
    private void Zgeging()
    {
        Debug.Log("fdf");
        Anim.SetBool("Zgeging", true);
    }

    public void StopZgeging()
    {
        Anim.SetBool("Zgeging", false);
    }
    private void Forking()
    {
        Anim.SetBool("Forking", true);
        StartCoroutine(StopForking());
    }

    private IEnumerator StopForking()
    {
        yield return new WaitForSeconds(3f); // Remplacez "animationDuration" par la durée réelle de votre animation "Forking"
        Anim.SetBool("Forking", false);
    }
    private void Idle()
    {
        Anim.SetBool("Idle", true);
    }
}
