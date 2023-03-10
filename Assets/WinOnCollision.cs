using UnityEngine;

public class WinOnCollision : MonoBehaviour
{
    // Set this variable to the game object you want to check for collision with
    public GameObject winObject;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the win object and the player has the "Player" tag
        if (collision.gameObject == winObject && collision.collider.CompareTag("Player"))
        {
            // Display "You Win" on the game screen
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "You Win!");
        }
    }
}
