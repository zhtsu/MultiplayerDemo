using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private Player player;
    private float footstepTimer;
    private float footstepTimerMax = .1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer < 0f)
        {
            if (player.IsWalking())
            {
                SoundManager.Instance.PlayFootstepsSound(player.transform.position, 1f);
                footstepTimer = footstepTimerMax;
            }
        }
    }
}
