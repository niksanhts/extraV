using UnityEngine;

namespace _Scripts.Player
{
    public class Vision : MonoBehaviour
    {
        private float xRotation;
        private float yRotation;

        [SerializeField]
        private Transform playerBody;
    
        [SerializeField]
        [Range(1, 200)] private float sensitivity;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        public void Look(Vector2 input)
        {
            input *= (sensitivity * Time.deltaTime);

            yRotation -= input.y;
            xRotation -= input.x;
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(yRotation, 180-xRotation, 0f);
            playerBody.Rotate(Vector3.up * input.x);
        }
    }
}
