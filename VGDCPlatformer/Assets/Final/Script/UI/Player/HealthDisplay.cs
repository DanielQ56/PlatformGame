using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Text healthText;
    private PlayerHealth healthComponent;

    private int currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = -1;
        healthText = GetComponent<Text>();
        healthComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth != healthComponent.getCurrentHealth()) {
            currentHealth = healthComponent.getCurrentHealth();
            healthText.text = currentHealth.ToString();
        }
    }
}
