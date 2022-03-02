using UnityEngine;

public class Animal : MonoBehaviour
{
    Rigidbody2D myBody;

    [SerializeField] float speed;
    [SerializeField] GameObject bullet;


    float minX, maxX, maxY, minY;

    [SerializeField] int life = 3;



    // Start is called before the first frame update
    void Start()
    {
        // Limite del que no pasa el personaje
        Vector2 esqInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = esqInfIzq.x;
        minY = esqInfIzq.y;


        Vector2 esqSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = esqSupDer.x;
        maxY = esqSupDer.y;

        myBody = GetComponent<Rigidbody2D>();

        myBody.velocity = new Vector2(speed, myBody.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        //para los limites del que el personaje no se pasa
        transform.position = new Vector2(
        Mathf.Clamp(transform.position.x, minX, maxX),
        Mathf.Clamp(transform.position.y, minY, maxY)
        );

        if (life == 0)
            Destroy(this.gameObject);



    }
    private void FixedUpdate()

    {
        // Genera un random en la velocidad de los mostrouos
        float deltaSpeed = Random.Range(1, 3);
        
        // identifica si llego al limite del mapa
        if (transform.position.x == minX || transform.position.x == maxX)
            speed = speed * -1 * deltaSpeed;
        // control de velocidad para que no se descontrole
        if (speed > 30)
                speed = 10;

        myBody.velocity = new Vector2(speed, myBody.velocity.y);


    }

    private void OnCollisionEnter2D(Collision2D collision)

    {

        Debug.Log("Choco contra: " + collision.gameObject.name);
        if (collision.gameObject.name == "Bullet(Clone)")
        {

            life = life - 1;
        }

        if (collision.gameObject.name == "BulletPower(Clone)")
        {
            life = 0;
        }
       

       
            
        
    }

}