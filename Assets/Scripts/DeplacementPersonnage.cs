using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacementPersonnage : MonoBehaviour
{
    //Composants du perso
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    [Header("Actions du personnage")]
    public InputAction actionMarche;
    public InputAction actionSaut;


    [Header("Déplacement horizontal")]
    public float vitesse = 10f;
    public float inputMarche;

    [Header("Saut")]
    public float forceSaut = 5f;
    public bool inputSaut;
    public bool estAuSol;
    public LayerMask masqueSol;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Récupère les composants
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    void OnEnable()
    {
        //Sert à activer les écouteurs de touches
        actionMarche.Enable();
        actionSaut.Enable();
    }
    void OnDisable()
    {
        //Sert à désactiver les écouteurs de touches
        actionMarche.Disable();
        actionSaut.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        inputMarche = actionMarche.ReadValue<float>();
        //new Vector2(0,-1)
        estAuSol = Physics2D.Raycast(transform.position,Vector2.down,0.1f, masqueSol); /*avoir un rayon dans notre personnage pour détecter les collisions*/
        Debug.DrawRay(transform.position,Vector2.down * 0.1, Color.orange);
        if (actionSaut.WasPressedThisFrame() == true && estAuSol == true) /**/
        {
            inputSaut = true;
        }
        else
        {
            inputSaut = false;
        }

        if (inputMarche < 0)
        {
            sr.flipX = true;
        }
        else if (inputMarche > 0)
        {
            sr.flipX = false;
        }

        float vitesseAbsolue = Mathf.Abs(rb.linearVelocityX);
        anim.SetFloat("vitesse", vitesseAbsolue);
        anim.SetBool("estDansLesAirs", estAuSol == false);
    }

    void FixedUpdate()
    {
        if (inputMarche != 0)
        {
            rb.linearVelocityX = vitesse * inputMarche;
        }

        if (inputSaut == true)
        {
            // rb.AddForce(new Vector2(0, 1) * forceSaut);
            rb.AddForce(Vector2.up * forceSaut, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            anim.SetTrigger("estBlesse");
        }
    }
}
