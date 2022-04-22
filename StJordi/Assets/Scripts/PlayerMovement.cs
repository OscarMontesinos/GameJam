using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forceSpeed = 0;
    public Rigidbody playerPhysics;
    Vector3 movement;
    float horizontalInput = 0;
    float verticalInput = 0;
    public Camera cam;
    public GameObject flecha;
    public GameObject hitboxEscopeta;
    bool saltando;
    public float alturaSalto;
    public float speedSalto;
    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (playerPhysics.useGravity)
        {
            movement = new Vector3(horizontalInput, -10 * Time.deltaTime, verticalInput);
        }
        else
        {

            movement = new Vector3(horizontalInput, 0, verticalInput);
        }


        var mousePos = Input.mousePosition;
        var wantedPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y));
        
        transform.LookAt(wantedPos, Vector3.down);

        //transform.eulerAngles = new Vector3(0, 0, 0);

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        playerPhysics.velocity = movement * Time.deltaTime * forceSpeed;

        if (Input.GetKey(KeyCode.Space) && saltando == false)
        {
            StartCoroutine(Salto());
           
        }

        IEnumerator Salto()
        {
            saltando = true;
            playerPhysics.useGravity = false;
            Vector3 direction = new Vector3(transform.position.x, transform.position.y+10, transform.position.z);
            float recorrido = 0;
            while (recorrido <= alturaSalto)
            {
                transform.Translate(direction.normalized * Time.deltaTime * speedSalto);
                recorrido += Time.deltaTime * speedSalto;
                yield return null;
            }
            yield return new WaitForSeconds(0.8f);
            playerPhysics.useGravity = true;
        }
    }

    void Disparar()
    {
        aux
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            saltando = false;
        }
    }

}
