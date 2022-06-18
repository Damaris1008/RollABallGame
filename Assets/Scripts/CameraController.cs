using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // This will set offset equal to the camera transform position minus the player GameObjects transform position. 
        offset = transform.position - player.transform.position;
    }

    // For follow cameras and tasks, like gathering last known states, it's best to use Late Update. 
    // Late Update runs every frame just like Update, but will run after all of the other updates are done. 
    void LateUpdate()
    {
        // Now when a player moves the sphere with controls on the keyboard, the frame before displaying the camera, 
        // the camera GameObject is moved into a new position, aligned with the player GameObject before the frame is displayed. 
        // This is just like what would happen if it were a child of that object, except it's only matching the position and not the rotation of the sphere. 
        transform.position = player.transform.position + offset;
    }

    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
