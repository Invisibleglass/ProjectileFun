using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    public TankShoot tankShoot;
    public Projectile bulletPrefab;
    public Transform bulletSpawnpoint;
    public GameObject enemyTankPrefab;
    
    public Button fireButton;
    public InputField velocityInputField;
    public InputField angleInputField;
    public Text scoreText;

    int score = 0;
    private int shotsTaken = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fireButton.onClick.AddListener(OnFireButtonPressed);
        scoreText.text = score.ToString() + " Points";
    }

    //Checks if inputs are valid and fires the cannon if they are
    public void OnFireButtonPressed()
    {
        if(float.TryParse(velocityInputField.text, out float velocity) && float.TryParse(angleInputField.text, out float angle))
        {
            if (velocity > 0 && angle > 0 && (angle % 360 <= 180))
            {
                FireCannon(velocity, angle);
            }
            else
            {
                Debug.LogWarning("Invalid input for velocity and/or angle");
            }
        }
        else
        {
            Debug.LogWarning("Invalid input for velocity and/or angle");
        }
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " Points";
    }
    
    private void FireCannon(float velocity, float angle)
    {
        //counts the amount of bullets fired
        shotsTaken++;

        //rotates the cannon to the angle firing the bullet
        tankShoot.RotateCannon(angle);

        //Create a bullet fired at the angle and velocity stated
        Projectile bulletInstance = Instantiate(bulletPrefab, bulletSpawnpoint.position , transform.rotation = Quaternion.Euler(0f, 0f, angle));
        bulletInstance.bulletSpeed = velocity;
    }

    public void SpawnEnemy()
    {
        GameObject EnemyTank = Instantiate(enemyTankPrefab, transform.position = new Vector3(Random.Range(-7f, 3f), -0.4f, 0f), transform.rotation);
    }
    private void Update()
    {
        //multiple scenes not implemented yet
        if (shotsTaken == 10 && GameObject.FindGameObjectWithTag("Projectile") == null)
        {
            SceneManager.LoadScene(1);
        }
    }
}
