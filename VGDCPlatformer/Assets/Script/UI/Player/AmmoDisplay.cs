using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    private Text ammoText;
    private PlayerAmmo ammoComponent;

    private int count;

    // Use this for initialization
    void Start()
    {
        count = -1;
        ammoText = GetComponent<Text>();
        ammoComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAmmo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count != ammoComponent.getCurrentAmmo()) {
            count = ammoComponent.getCurrentAmmo();
            ammoText.text = count + " / " + ammoComponent.maxAmmo;
        }
    }

}
