using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string _IS_WALKING = "IsWalking";

    private Animator _animator;

    [SerializeField]
    private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(_IS_WALKING, _player.IsWalking());
    }
}
