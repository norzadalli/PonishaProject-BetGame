using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class muno_anim : MonoBehaviour
{
    public RectTransform game_panel;
    public RectTransform porfile_ponel;
    public RectTransform walwt_ponel;
    public RectTransform masej_panel;

    public float speed;
    public void  Game_ponel_on()
    {
        game_panel.DOAnchorPos(new Vector2(0, 0), speed);


    }

public void Game_pnel_off()
    {

        game_panel.DOAnchorPos(new Vector2(-1500, 0), speed);

    }

    public void porfle_panel_on()
    {

        porfile_ponel.DOAnchorPos(new Vector2(0, 0), speed);
    }

    public void porfle_panel_off()
    {
        porfile_ponel.DOAnchorPos(new Vector2(1500, 0), speed);


    }

    public void walet_ponel_on()
    {

        walwt_ponel.DOAnchorPos(new Vector2(0, 0), speed); 

    }

    public void walet_ponel_off()
    {

        walwt_ponel.DOAnchorPos(new Vector2(0, 1500), speed);

    }
    public void massej_ponel_on()
    {
        masej_panel.DOAnchorPos(new Vector2(0, 0), speed);


    }
    public void mssj_ponel_off()
    {
        masej_panel.DOAnchorPos(new Vector2(0, 1500), speed);

    }
    void Start()
    {
        
    }

   
    
}
