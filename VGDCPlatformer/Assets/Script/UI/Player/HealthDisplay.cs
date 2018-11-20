using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Text healthText;
    private PlayerHealth healthComponent;

    // Use this for initialization
    void Start()
    {
        healthText = GetComponent<Text>();
        healthComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = healthComponent.getCurrentHealth().ToString();
    }
}
