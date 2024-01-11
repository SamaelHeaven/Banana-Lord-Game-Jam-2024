using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Properties")] 
    
    [SerializeField] private Vector2 velocity = new (7, 7);
    [SerializeField] private Rigidbody2D body;
    
    private void FixedUpdate()
    {
        MoveCharacter();
    }
        
    private void MoveCharacter()
    {
        var movement = TopDownInputController.Instance.Movement * velocity * Time.deltaTime;
        body.MovePosition(body.position + movement);
    }
}
