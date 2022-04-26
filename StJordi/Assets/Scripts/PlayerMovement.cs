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
    public GameObject bala;
    public GameObject fuego;
    public int fireDelay;
    public GameObject hitboxEscopeta;
    bool saltando;
    public float alturaSalto;
    public float speedSalto;
    public float recargaEscopeta;
    float currentRecargaEscopeta;
    public int balas;
    public float fuegoMun;
    public float fireSpeed;
    public Arma arma;
    public bool lanzallamas;
    public bool envenenado;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
        hitboxEscopeta = transform.GetChild(0).gameObject;
        balas = 2;
        fuegoMun = 25;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentRecargaEscopeta > 0)
        {
            currentRecargaEscopeta -= Time.deltaTime;
        }
        if (Input.GetMouseButton(1) && currentRecargaEscopeta<=0&&fuegoMun>0 & lanzallamas)
        {
            fuegoMun -= Time.deltaTime*fireSpeed;

            int aux = Random.Range(0, fireDelay + 1);
            if (aux == fireDelay)
            {
                Instantiate(fuego, transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).transform.position, transform.rotation);
            }

            arma.lanzallamas = true;
        }
        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1) && currentRecargaEscopeta <= 0 && balas >0)
        {
            Disparar();
            arma.escopeta = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            arma.lanzallamas = false;
        }
        if (Input.GetMouseButtonDown(1) && fuegoMun>0)
        {
            fuegoMun -= 5;
        }
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
        var wantedPos = new Vector3(0, 0, 0);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            wantedPos = raycastHit.point;
        }

        transform.LookAt(wantedPos, Vector3.down);

        //transform.eulerAngles = new Vector3(0, 0, 0);

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        playerPhysics.velocity = movement * Time.deltaTime * forceSpeed;

        if (Input.GetKey(KeyCode.Space) && saltando == false)
        {
            StartCoroutine(Salto());

        }
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
            yield return new WaitForSeconds(0.1f);
            playerPhysics.useGravity = true;
        }
    

    void Disparar()
    {
        animator.SetTrigger("Disparar");
        fuegoMun += 10;
        if (fuegoMun > 50)
        {
            fuegoMun = 50;
        }
        balas--;
        if(balas == 0)
        {
            animator.SetBool("Recargar", true);
            StartCoroutine(Recarga());
        }
        currentRecargaEscopeta = recargaEscopeta;
        //Podría usar un bucle al igual que G2 pudo ganar a Fun Plus Phoenix
        Instantiate(bala, transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).transform.position, transform.rotation);
        Instantiate(bala, transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).transform.position, transform.rotation);
        Instantiate(bala, transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).transform.position, transform.rotation);
        Instantiate(bala, transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).transform.position, transform.rotation);
        Instantiate(bala, transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).transform.position, transform.rotation);
        StartCoroutine(DisparoReset());
    }

    IEnumerator DisparoReset()
    {
        yield return null;
        arma.escopeta = false;
    }
    IEnumerator Recarga()
    {
        yield return new WaitForSeconds(1.4f);
        balas = 2;
        animator.SetBool("Recargar", false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            saltando = false;
        }
    }
    public IEnumerator Envenenarse() 
    {
        envenenado = true;
        yield return new WaitForSeconds(1.5f);
        if (envenenado)
        {
            GetComponent<Unit>().TakeDmg(1);
        }
    }

}
