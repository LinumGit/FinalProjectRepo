using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{
    public GameObject arrow;

    // Update is called once per frame
    void Update()
    {
        useSubWeapon();
    }

    public void useSubWeapon()
    {
        if (Input.GetKeyDown("e") && SubItems.instance.subItemAmount > 0 )
        {
            AudioManager.instance.playAudio(AudioManager.instance.arrow);
            GameObject subItem = Instantiate(arrow, transform.position, Quaternion.Euler(0,0, -46));
            if (transform.localScale.x < 0)
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-900f, 0f), ForceMode2D.Force);
                subItem.transform.localScale = new Vector2(-1, -1);
            }
            else
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(900f, 0f), ForceMode2D.Force);
            }

            SubItems.instance.subItem(-1);          
        }
    }
}
