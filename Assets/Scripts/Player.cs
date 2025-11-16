using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rigd;
    public float speed; //colocar velocidade no boneco

    public float jumpForce = 7f;
    public bool isground; //verificar se ta no chão

    public Vector2 PosicaoInicial;
    public GameManager GameManager;

    void Start()
    {

        anim = GetComponent<Animator>();
        rigd = GetComponent<Rigidbody2D>();
        PosicaoInicial = transform.position;

    }
    void Update()
    {
        Move();
        Jump();
    }

    public void RestartPosition()
    {
        transform.position = PosicaoInicial;
    }
    void Move()
    {
        float teclas = Input.GetAxis("Horizontal");
        rigd.linearVelocity = new Vector2(teclas * speed, rigd.linearVelocity.y);

        if (teclas > 0 && isground == true)
        {
            transform.eulerAngles = new Vector2(0, 0);
            anim.SetBool("IsWalking", true);
        }
        if (teclas < 0 && isground == true)
        {
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetBool("IsWalking", true);
        }

        if (teclas == 0 && isground == true)
            anim.SetBool("IsWalking", false);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isground == true)
        {
            rigd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
            isground = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("IsJumping", false);
            isground = true;
            Debug.Log("esta no chão");
        }

        if (collision.gameObject.tag == "lost")
        {
            Debug.Log("Morreu");
        }
    }
}