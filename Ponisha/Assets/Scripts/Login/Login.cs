using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiroozehGameService.Core;
using FiroozehGameService.Core.GSLive;
using FiroozehGameService.Handlers;
using FiroozehGameService.Models;
using FiroozehGameService.Models.GSLive;
using FiroozehGameService.Models.GSLive.Command;
using FiroozehGameService.Models.GSLive.TB;
using FiroozehGameService.Utils;
using Handlers;
using Models;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using UnityEngine.SceneManagement;
using LogType = FiroozehGameService.Utils.LogType;
using DG.Tweening;

public class Login : MonoBehaviour
{
    public RectTransform ponel_sinup;

    public float speed;
    /// <summary>
    /// ////////////////
    /// 
    /// </summary>
    public InputField username;
    public InputField poswwerd;
    /// <summary>
    /// ///////////////////////
    /// </summary>
    public GameObject Rigester_panel;
    /// <summary>
    /// ///////////////////
    /// </summary>
    public InputField _user;
    public InputField _emale;
    public InputField _posword;
    public InputField _posword_r;
    public InputField _frend_id;

    public Toggle _chekbox;

    public GameObject gameObjects;
    
    public String str;
    async void Start()
    {
       

        if (Utils.FileUtil.IsLoginBefore())
        {
            try
            {

                await GameService.Login(FileUtil.GetUserToken());
                username.text = FileUtil.GetUserToken();

                if (GameService.IsAuthenticated())
                {
                    SceneManager.LoadScene(str);
                }




            }
            catch (GameServiceException e)
            {


                print(e.Message);

            }
        }else
        {

           



        }
        CoreEventHandlers.SuccessfullyLogined += OnSuccessfullyLogined;



    }

 public void rigester_event_ponel_on()
    {

        gameObjects.SetActive(false);
        ponel_sinup.DOAnchorPos(new Vector2(0, 0), speed);
       

      

       

    }
    public void rigester_event_ponel_off()
    {
        gameObjects.SetActive(true);
        ponel_sinup.DOAnchorPos(new Vector2(-1500, 0), -speed*10);
        

    }

  async  public void rigester()
    {
        if (_posword.text.Trim()==_posword_r.text.Trim())
        {

           string pos_str = _posword.text;

            try
            {
                if (_chekbox.isOn)
                {

                  var user=  await GameService.SignUp(_user.text, _emale.text, pos_str);
                    FileUtil.SaveUserToken(user);
                    if (GameService.IsAuthenticated())
                    {
                        SceneManager.LoadScene(str);
                    }


                }
                else
                {

                    //////
                    ///EROOR


                }



            }
            catch (GameServiceException e)
            {
                print(e.Message);
               
            }

            
        }else
        {
            //////
            ///////EROOR
            


        }

    }


 async   public void login_event()
    {
        try
        {
            if (username.text.Trim() == "" || poswwerd.text.Trim() == "")
            {

                //////
                ///EROOR
                ///


            }
            else
            {

             var user=   await GameService.Login(username.text.Trim(), poswwerd.text.Trim());
                FileUtil.SaveUserToken(user);

                if (GameService.IsAuthenticated())
                {
                    SceneManager.LoadScene(str);
                }
               

            }


        }
        catch (GameServiceException e)
        {
            print(e.Message);

        }



    }


    public void Recaverposwerd()
    {

        Application.OpenURL("https://gamesservice.ir/auth/app/forgetpassword");


    }

    async  void OnSuccessfullyLogined(object sender, EventArgs e)
    {
        
       

    }

    void Update()
    {
        
    }
}
