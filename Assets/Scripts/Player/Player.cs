using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 7f;

    private bool _isWalking;

    private void Update()
    {
        Vector2 inputVec = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVec.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVec.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVec.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVec.x = +1;
        }

        inputVec = inputVec.normalized;

        Vector3 moveDir = new Vector3(inputVec.x, 0f, inputVec.y);
        transform.position += moveDir * _moveSpeed * Time.deltaTime;

        _isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return _isWalking;
    }
}
