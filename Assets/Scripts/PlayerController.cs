using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10;
    public float xRange = 10;
    private InputAction moveAction;
    private InputAction shootAcition;
    public GameObject foodPrefab;
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAcition = InputSystem.actions.FindAction("Shoot");

    }

    // Update is called once per frame
    void Update()
    {
        var hIput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(hIput * Speed * Time.deltaTime * Vector3.right);
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(xRange, 
                transform.position.y,
                transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange,
                transform.position.y,
                transform.position.z);
        }
        if (shootAcition.triggered)
        {
            Instantiate(foodPrefab, transform.position, Quaternion.identity);
        }
        Instantiate(foodPrefab, transform.position, Quaternion.identity);

    }
          

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, 1f);
        //Gizmos.color = Color.orange;
        //Gizmos.DrawLine(transform.position, Camera.main.transform.position);
        
        Vector3 left = new Vector3(-xRange,
            transform.position.y,transform.position.z);
        Vector3 right = new Vector3(xRange,
            transform.position.y,transform.position.z);
        Gizmos.DrawLine(left, right);
        
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(left, 0.5f);
        Gizmos.DrawSphere(right, 0.5f);
    }
}
