using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletpower;
    [SerializeField] float firefate;
    private float nextfire = 0f;
    private bool cambiar = true;
    private float time = 0;


    float minX, maxX, maxY, minY;

    // Start is called before the first frame update
    void Start()
    {
        // Limite del que no pasa el personaje
      Vector2 esqInfIzq= Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = esqInfIzq.x;
        minY = esqInfIzq.y;


        Vector2 esqSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = esqSupDer.x;
        maxY = esqSupDer.y;
    }

    // Update is called once per frame
    void Update()

    {
        Recarga();

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            cambiar = !cambiar;
        }
        //Movimiento del personaje
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");


        transform.Translate(new Vector2(dirH * speed * Time.deltaTime,
            dirV * speed * Time.deltaTime));

        //para los limites del que el personaje no se pasa
        transform.position = new Vector2(
        Mathf.Clamp(transform.position.x, minX, maxX),
        Mathf.Clamp(transform.position.y, minY, maxY)
        );

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextfire && cambiar == true)

        {
            nextfire = Time.time + firefate;

            Instantiate(bullet, transform.position, transform.rotation);
        }


       
            if (Input.GetKeyUp(KeyCode.Space) && Time.time > nextfire  && cambiar == false && time >= 3)


            {
                nextfire = Time.time + firefate;
                Instantiate(bulletpower, transform.position, transform.rotation);



        }


        

    }

    private void Recarga()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            time = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            {
            time = Time.time - time;
        }
    }
}

