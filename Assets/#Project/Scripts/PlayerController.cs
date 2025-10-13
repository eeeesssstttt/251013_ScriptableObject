using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const string PLAYER_ACTION_MAP = "Player";
    private const string MOVE_INPUT_ACTION = "Move";
    [SerializeField] InputActionAsset actions;
    private InputAction moveAction;
    [field: SerializeField] public float MoveSpeed { get; set; } = 1f;

    void Awake()
    {
        moveAction = actions.FindActionMap(PLAYER_ACTION_MAP).FindAction(MOVE_INPUT_ACTION);
    }

    void OnEnable()
    {
        actions.FindActionMap(PLAYER_ACTION_MAP).FindAction(MOVE_INPUT_ACTION).Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap(PLAYER_ACTION_MAP).FindAction(MOVE_INPUT_ACTION).Disable();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 move = MoveSpeed * Time.deltaTime * moveAction.ReadValue<Vector2>();
        transform.Translate(move.x, 0, move.y, Space.World); // Space.World means using global axes
    }
}
