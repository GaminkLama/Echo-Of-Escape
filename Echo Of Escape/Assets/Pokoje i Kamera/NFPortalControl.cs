using UnityEngine;
using UnityEngine.SceneManagement;

public class NFPortalControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Assuming you have a method to handle the next floor transition
            HandleNextFloorTransition();
        }
    }
    private void HandleNextFloorTransition()
    {
        // Logic to transition to the next floor
        Debug.Log("Transitioning to the next floor...");
        // You can add your scene loading logic here, e.g., SceneManager.LoadScene("NextFloor");
        SceneManager.LoadScene(1);
    }
}
