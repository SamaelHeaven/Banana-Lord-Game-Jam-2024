using UnityEngine;

public class FlipWithRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;

    private void Update()
    {
        var angle = transform.rotation.eulerAngles.z;
        sprite.flipY = angle is > 90f and < 270f;
    }
}