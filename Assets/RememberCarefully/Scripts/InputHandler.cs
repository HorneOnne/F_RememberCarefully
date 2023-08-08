using UnityEngine;

namespace RememberCarefully
{
    public class InputHandler : MonoBehaviour
    {
        private void Update()
        {
            // Check if the left mouse button was clicked
            if (Input.GetMouseButtonDown(0))
            {
                // Create a ray from the camera through the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // Check if the ray hits a collider
                if (hit.collider != null)
                {
                    // Check if the hit collider belongs to the object you want to detect clicks on
                    if (hit.collider.gameObject == gameObject)
                    {
                        // Mouse click happened on this object
                        Debug.Log("Mouse click on object.");
                    }
                }
            }
        }
    }
}

