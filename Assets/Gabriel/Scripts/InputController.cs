using UnityEngine;

public class InputController : Singleton<InputController>
{
    public Vector2 Movement { get; set; }

    private PlayerInputActionsTopDown _inputActions;
    
    private void Awake()
    {
        _inputActions = new PlayerInputActionsTopDown();
    }

    private void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
    }

    private void Update()
    {
        Movement = _inputActions.Player.Move.ReadValue<Vector2>();
    }
}
