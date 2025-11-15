using UnityEngine;
using UnityEngine.InputSystem;
using static Framework;

public class HandController : MonoBehaviour
{
    public float handSpeed = 5;
    public GameObject handLeft;
    public GameObject handRight;

    public Vector2 handLeftMoveVector = Vector2.zero;
    public Vector2 handRightMoveVector = Vector2.zero;

    private InputService InputService;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        InputService = Game.GetService<InputService>();

        InputService.Connect("Gameplay/MoveHandLeft", MoveHandLeft);
        InputService.Connect("Gameplay/MoveHandRight", MoveHandRight);
    }

    // Update is called once per frame
    void Update()
    {
        MoveHand(handLeft, handLeftMoveVector);
        MoveHand(handRight, handRightMoveVector);
    }

    void MoveHandLeft(InputAction.CallbackContext context)
    {
        handLeftMoveVector = context.ReadValue<Vector2>();
    }

    void MoveHandRight(InputAction.CallbackContext context)
    {
        handRightMoveVector = context.ReadValue<Vector2>();
    }

    void MoveHand(GameObject hand, Vector2 moveVector)
    {
        Vector3 moveVector3 = new Vector3(moveVector.x, moveVector.y, 0);
        hand.transform.position += (moveVector3 * handSpeed * Time.deltaTime);
    }
}
