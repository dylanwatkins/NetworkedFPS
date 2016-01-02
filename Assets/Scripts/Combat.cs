using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

using System.Collections;

public class Combat : NetworkBehaviour
{

    public const int startingHealth = 100;
    public Slider healthSlider;
    public bool destroyOnDeath;
    public Text scoreValue;
    public GUIManager gui;

    [SyncVar]
    public int  currentHealth;
   // public int scoreValue;

    void Awake()
    {

        currentHealth = startingHealth;

    }

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Debug.Log("Destroyed game object");
            if (destroyOnDeath)
            {
                Destroy(gameObject);
                gui.coinsCollected++;
                Debug.Log("VERY Destroyed game object");
            }
            else
            {
                Debug.Log("Dead!");
                currentHealth = startingHealth;
                healthSlider.value = startingHealth;

                // called on the server, will be invoked on the clients 

                RpcRespawn();
            }
        }
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // move back to zero location 
            transform.position = Vector3.zero;
        }
    }

}
    

