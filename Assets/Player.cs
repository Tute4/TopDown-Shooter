using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    public GameObject projectilePrefab;

    
    private Collider playerCollider;

    void Start()
    {
        
        playerCollider = GetComponent<Collider>();
    }

    void Update()
    {
        
        Move();

        
        MirarCursor();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Move()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        
        Quaternion camRotation = Camera.main.transform.rotation;

        
        Vector3 moveDirection = camRotation * movementDirection;

        
        rb.MovePosition(rb.position + new Vector3(moveDirection.x, 0f, moveDirection.z) * moveSpeed * Time.deltaTime);
    }

    void MirarCursor()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mousePos = hit.point;
            
            Vector3 lookDir = mousePos - transform.position;
            lookDir.y = 0; 
            if (lookDir != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDir);
                rb.MoveRotation(targetRotation);
            }
        }
    }

    void Shoot()
    {
        
        playerCollider.enabled = false;

        
        Instantiate(projectilePrefab, transform.position, transform.rotation);

        
        StartCoroutine(EnablePlayerCollider());
    }

    IEnumerator EnablePlayerCollider()
    {
        
        yield return new WaitForSeconds(0.1f);

        
        playerCollider.enabled = true;
    }
}
