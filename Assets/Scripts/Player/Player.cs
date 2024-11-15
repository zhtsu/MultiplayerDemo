using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 7f;

    [SerializeField]
    private GameInput _gameInput;

    private bool _isWalking;

    private void Update()
    {
        Vector2 inputVec = _gameInput.GetMovementVectorNormailized();

        Vector3 moveDir = new Vector3(inputVec.x, 0f, inputVec.y);

        float moveDistance = _moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(
            transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(
                transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
        
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(
                    transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
            
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * _moveSpeed * Time.deltaTime;
        }

        _isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return _isWalking;
    }
}
