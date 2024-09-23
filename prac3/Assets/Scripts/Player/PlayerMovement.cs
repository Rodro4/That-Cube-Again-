using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    public bool canMove = true;

    public Rigidbody2D rb;

    public Sprite[] skins = new Sprite[2];

    [SerializeField] private AudioClip jump;

    void Start()
    {
        int skinColor = PlayerPrefs.GetInt("SkinColor", 0);

        rb = GetComponent<Rigidbody2D>();

        if (skinColor == 1)
        {
            transform.GetComponent<SpriteRenderer>().sprite = skins[1];
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().sprite = skins[0];
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0)
        {
            MoveLeft();
        }
        else if (horizontalInput > 0)
        {
            MoveRight();
        }
        else if (!LeftButton.leftIsPressed && !RightButton.rightIsPressed)
        {
            StopMoving();
        }

        if (Input.GetKey(KeyCode.Space) && CheckGround.onGround)
        {
            //rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            //onGround = false;

            Jump();
        }
    }

    public void MoveLeft()
    {
        if (!canMove) return;
        //rb.AddForce(Vector2.left * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        //transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }

    public void MoveRight()
    {
        if (!canMove) return;
        //rb.AddForce(Vector2.right * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        //transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }

    public void StopMoving()
    {
        //if (!canMove) return;
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void Jump()
    {
        if (!canMove) return;
        if (!ControladorEscena.GetSceneName().Equals("Level7") || !AirplaneLevel.modoAvion.Equals("1"))
        {
            ControladorSonido.Instance.EjecutarSonido(jump);
        }
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        //rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);

        //transform.Translate(0, jumpHeight * Time.deltaTime, 0);
        //onGround = false;
    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag != "Floor") return;
    //    onGround = true;
    //}
}
