using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class game_manager : MonoBehaviour
{
    // Đoàn Thanh Hòa
    public GameObject draggingObject;
    public GameObject currentContainer;
    public GameObject sunObject;
    public AudioSource sound_plant;
    public AudioSource sound_eat_plant, sound_bullet, sound_die, sound_lawnMower, sound_gameover, sound_start, sound_pepperboom, sound_cherryboom;

    public static game_manager instance;
    public bool isStart = false;
    public bool[] slotX = { false, false, false, false, false, false, false, false };
    public bool isRoofMap = true;

    // Đoàn Thanh Hòa
    // nguyễn bá sơn
    //public GameObject currentPlant;
    //public Sprite currentPlantSprite;
    //public Transform tiles;
    //public LayerMask tileMask;
    public int suns = 400;
    public TextMeshProUGUI sunText;
    public LayerMask sunMask;

    //public void BuyPlant(GameObject plant, Sprite sprite)
    //{
    //    currentPlant = plant;
    //    currentPlantSprite = sprite;
    //}

    //// Update is called once per frame
    void Update()
    {
        sunText.text = suns.ToString();
        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);

        //    foreach (Transform tile in tiles)
        //        tile.GetComponent<SpriteRenderer>().enabled = false;


        //    if (hit.collider && currentPlant)
        //    {
        //        hit.collider.GetComponent<SpriteRenderer>().sprite = currentPlantSprite;
        //        hit.collider.GetComponent<SpriteRenderer>().enabled = true;

        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            Instantiate(currentPlant, hit.collider.transform.position, Quaternion.identity);
        //            currentPlant = null;
        //            currentPlantSprite = null;
        //        }
        //    }


        RaycastHit2D sunHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, sunMask);

        if (sunHit.collider)
        {
            if (Input.GetMouseButtonDown(0))
            {
                suns += 25;
                Destroy(sunHit.collider.gameObject);
            }

        }
    }
        //nguyễn bá sơn

        // Đoàn Thanh Hòa
        private void Awake()
    {
        instance = this;
    }

    public void placeObject()
    {
        if (draggingObject != null && currentContainer != null)
        {
            
            GameObject gameObject = draggingObject.GetComponent<Object_Dragging>().card.object_Game;
            
            Instantiate(gameObject, currentContainer.transform);
            // Đảm bảo đối tượng mới tạo nằm trên cùng lớp render
            gameObject.transform.SetAsLastSibling();
            gameObject.transform.position = new Vector3(0, 0.2f, currentContainer.transform.position.z);


            //Debug.Log(currentContainer.transform.position);
            //Debug.Log(currentContainer.transform.localPosition);
            //Debug.Log(gameObject.transform.position);
            //Debug.Log(gameObject.transform.localPosition);
            currentContainer.GetComponent<ObjectContainer>().isFull = true;
            sound_plant.Play();
        }
    }
    public void SpawnSun()
    {
        GameObject mySun = Instantiate(sunObject, new Vector3(UnityEngine.Random.Range(-7.44f, 7.44f), 6, 0), Quaternion.identity);
        mySun.GetComponent<sunScripts>().dropToYPos = UnityEngine.Random.Range(1f, -3.5f);
        Invoke("SpawnSun", UnityEngine.Random.Range(4, 10));
    }

    // Đoàn Thanh Hòa

}
