using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappingScript : MonoBehaviour {

    public List<GameObject> thingsToMould;

    public int TapsToGo = 2;

    public int tapModifier = 10;

    public int itemsremoved = 0;

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

    public void Tap()
    {
        TapsToGo -= tapModifier;

        while (TapsToGo <= 0)
        {
            ChangeActive();
            itemsremoved += 1;
            TapsToGo += itemsremoved + 2;
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
}
