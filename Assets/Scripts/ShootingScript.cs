
using UnityEngine;
using UnityEngine.Networking;

public class ShootingScript : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public ParticleSystem _muzzleFlash;
    public AudioSource _gunAudio;
    public GameObject _impactPrefab;
    public Transform cameraTransform;
    public float bulletSpeed; 

    ParticleSystem _impactEffect;


    void Start()
    {
        _impactEffect = Instantiate(_impactPrefab).GetComponent<ParticleSystem>();
    }

    [Command]
    void CmdFire()
    {
        // create the bullet object locally 
        var bullet = (GameObject)Instantiate(
             bulletPrefab,
             transform.position + transform.forward,
             Quaternion.identity);
             bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

        // spawn the bullet on the clients 
        NetworkServer.Spawn(bullet);

        // when the bullet is destroyed on the server it wil automaticaly be destroyd on clients 
        Destroy(bullet, 2.0f);
    }

        void Update()
    {
        // debug drawing a line to see where we are shooting
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        // Right click to kill yourself to test the respawning network feature
        if (Input.GetButtonDown("Fire2"))
        {
            CmdHitPlayer(gameObject);
        }

        //Shooting the weapon
        if (Input.GetButtonDown("Fire1"))
        {

            // create the bullet from the bullet prefab
            CmdFire();
            _muzzleFlash.Stop();
            _muzzleFlash.Play();
            _gunAudio.Stop();
            _gunAudio.Play();
        }
 /*
            Video Tutorial's Version of hitting players with ray casting and partical effects at hit location

            RaycastHit hit;
            Vector3 rayPos = cameraTransform.position + (1f * cameraTransform.forward);
            

            if (Physics.Raycast(rayPos, cameraTransform.forward, out hit, 50f))
            {
                _impactEffect.transform.position = hit.point;
                _impactEffect.Stop();
                _impactEffect.Play();

                if (hit.transform.tag == "Player")
                {
                    CmdHitPlayer(hit.transform.gameObject);
                    //add 10 damage to player health
                }

                if (hit.transform.tag == "Enemy")
                {
                    CmdHitPlayer(hit.transform.gameObject);
                    //add 10 damage to player health

                }
            }
             */

        
    }

    [Command]
    void CmdHitPlayer(GameObject hit)
    {
        hit.GetComponent<NetworkedPlayerScript>().RpcResolveHit();
    }
}