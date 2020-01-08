using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public ParticleSystem sparkle;

    public AudioClip collectedClip;
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
         
                Instantiate(sparkle,this.transform.position,Quaternion.identity);
                controller.ChangeHealth(1);
                Destroy(gameObject);
                controller.PlaySound(collectedClip);

            }

        }
    }

}
