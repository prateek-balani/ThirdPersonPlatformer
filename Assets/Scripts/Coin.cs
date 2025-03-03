using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f; 

    private void Update()
    {
    
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.CompareTag("Player"))
        {
           
            GameManager.instance.IncreaseScore();

            Destroy(gameObject);
        }
    }
}