using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed;    
    private float baseSpeed = 500;
    private float boostSpeed = 1500;
    private float boostTime = 1.2f;
    private float currentBoostTime;
    private float boostDelayTime = 1.5f;
    private float currentBoostDelayTime = 0; 
    private bool boosting = false;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;
    
    
    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    public ParticleSystem boostParticles;
    
    void Start()
    {
        speed = baseSpeed;
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Boost() { 
        if (Input.GetKeyDown(KeyCode.Space) && !boosting && Time.time > currentBoostDelayTime) {
            boostParticles.gameObject.SetActive(true);
            boostParticles.Play();
            currentBoostTime = Time.time + boostTime;
            boosting = true; 
        }
        if ((Time.time > currentBoostTime) && boosting) {
            currentBoostDelayTime = Time.time + boostDelayTime; 
            boosting = false;
        }
        if (boosting) {
            speed = boostSpeed;
        }
        if (!boosting) {
            speed = baseSpeed;
        }
    }
    void Update()
    {
        Boost();
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 
       
        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            CancelInvoke("PowerupCooldown"); //new
            powerupIndicator.SetActive(true);
            Invoke("PowerupCooldown", powerUpDuration); //new
            
        }
    }

    void PowerupCooldown()
    {
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position;
            
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer.normalized * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }



}
