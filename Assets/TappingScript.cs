using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TappingScript : MonoBehaviour {

    public List<GameObject> thingsToMould;

    public int TapsToGo = 2;

    public int itemsremoved = 0;

    public Text priceText;
    public int price;

    public int priceModifier;

    public GameObject statue;
    public Slider slider;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tap();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tap();
        }
    }

    public void updateRotation()
    {
        Debug.Log("Updating Rotation");
        Vector3 tempRot = new Vector3(0, slider.value, 0);
        statue.transform.rotation = Quaternion.Euler(tempRot);
    }

    public void Tap()
    {
        if (thingsToMould.Count == 0)
        {
            Debug.Log("Nothing to be tapped on");
            return;
        }

        TapsToGo -= PlayerWallet.instance.tapModifier;

        while (TapsToGo <= 0)
        {
            ChangeActive();
            itemsremoved += 1;
            TapsToGo += itemsremoved + 2;
            price += priceModifier;
            priceText.text = "Current sell Value - $" + price.ToString();
        }
    }

    public void ChangeActive()
    {
        if (thingsToMould[0].GetComponent<TrailScript>().lastInLine == false)
        {
            GameObject toAdd = Instantiate(thingsToMould[0].GetComponent<TrailScript>().nextInLine, thingsToMould[0].transform.position, thingsToMould[0].transform.rotation, thingsToMould[0].transform.parent);
            thingsToMould.Add(toAdd);
            Destroy(thingsToMould[0]);
        }
        thingsToMould.RemoveAt(0);
    }

    public void Sell()
    {
        Debug.Log("You made " + price + " amount of money! Well done!");
    }
}
