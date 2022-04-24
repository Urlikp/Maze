using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSpikes : MonoBehaviour
{
    public float animation_speed = 1f;
    public float animation_delay = 0f;

    private float _animation_cooldown = 3f;

    // Set some variables and start coroutine
    void Start()
    {
        _animation_cooldown = _animation_cooldown * animation_speed;
        StartCoroutine("Animate");
    }

    // Wait for delay and then start the spike animation in loop
    private IEnumerator Animate()
    {
        yield return new WaitForSeconds(animation_delay);

        while (true)
        {
            GetComponent<Animation>().Play();
            yield return new WaitForSeconds(_animation_cooldown);
        }
    }
}
