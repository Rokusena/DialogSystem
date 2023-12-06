using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public static Selector instance;

    public bool active = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && active)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var character = hit.transform.gameObject.GetComponent<Character>();

                if (character != null)
                {
                    DialogUI.instance.StartDialog(character);
                }
            }
        }
    }
}
