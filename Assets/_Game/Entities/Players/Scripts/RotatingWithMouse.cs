using UnityEngine;

public class RotatingWithMouse : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private void Update()
    {
        RotatePlayerWithMouse();
    }

    private void RotatePlayerWithMouse()
    {
        var mousePosition = Input.mousePosition;
        var position = transform.position;
        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, position.z));
        var direction = worldMousePosition - position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
