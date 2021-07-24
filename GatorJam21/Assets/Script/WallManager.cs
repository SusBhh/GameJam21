/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    private Transform shoppingPic;
    // Start is called before the first frame update
    void Start()
    {
        shoppingPic = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition) {
            shoppingPic.localScale = new Vector3(0, 0, 0);
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallManager : MonoBehaviour
{
    public class NewBehaviourScript : MonoBehaviour
    {
        // Start is called before the first frame update
        public Transform shoppingPic;
        void Start()
        {
            shoppingPic.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void onClick()
        {
            shoppingPic = transform.GetChild(2);
            shoppingPic.gameObject.SetActive(true);
        }
    }
}
