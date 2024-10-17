using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    public bool MenuOpenCloseInput { get; private set; }

    private PlayerInput playerInput;

    private InputAction menuOpenCloseAction;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        menuOpenCloseAction = playerInput.actions["MenuOpenClose"];
    }

    private void Update()
    {
        MenuOpenCloseInput = menuOpenCloseAction.WasPressedThisFrame();
    }
}
