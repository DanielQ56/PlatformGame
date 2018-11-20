using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    private Text ammoText;
    private PlayerAmmo ammoComponent;

    // Use this for initialization
    void Start()
    {
        ammoText = GetComponent<Text>();
        ammoComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAmmo>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = ammoComponent.getCurrentAmmo().ToString() + " / " + ammoComponent.maxAmmo.ToString();
    }

}
