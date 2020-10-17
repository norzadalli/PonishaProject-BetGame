using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiroozehGameService.Core;
using FiroozehGameService.Core.GSLive;
using FiroozehGameService.Handlers;
using FiroozehGameService.Models;
using FiroozehGameService.Models.GSLive;
using FiroozehGameService.Models.GSLive.Command;
using FiroozehGameService.Models.GSLive.TB;
using FiroozehGameService.Utils;
using System.Threading.Tasks;
using Utils;
using Models;
using DG.Tweening;
using UnityEngine.UI;
public class User : MonoBehaviour
{
    public RectTransform game_btn;
    public RectTransform user_btn;
    public RectTransform wallt_btn;
    public RectTransform game_panel;
    public string data_id;
    private string user_name;
    private string ID;
    public Text user_text;
    public InputField name;
    public InputField Pohenee;
    public InputField shomar_shaba;
    public InputField shomare_hsab;

    public Text cone_text;

    private bool data = false;
    private int cone;
    private string user_id_cod;
   async void Start()
    {


       var user= await GameService.GetCurrentPlayer();
        ID = user.Id;
        user_name = user.Name;
        user_text.text = user_name;
        getitme();
    }



    private async Task getitme()
    {
        try
        {
           
         var claent=  await  GameService.GetBucketItems<client>(data_id, new FiroozehGameService.Models.BasicApi.Buckets.BucketOption[] { new FiroozehGameService.Models.BasicApi.Buckets.FindByElement<string>("Username", ID)});
            foreach (client item in claent)
            {
                if (item == null)
                {
                        //////
                        ///dilog 
                        ///////
                        ///
                }
                else
                {
                    user_id_cod = item.Id;
                    name.text = item.Name;
                    Pohenee.text = item.Pohone.ToString();
                    shomare_hsab.text = item.shomare_hsab;
                    shomar_shaba.text = item.shomare_shaba;
                    data = true;
                    cone = item.cone;
                }
            }
            cone_text.text = cone.ToString();
           
        }
        catch (System.Exception)
        {

            
        }
       

            
        

    }

  async  public void Save_data_btn_event()
    {
        try
        {
            if (data)
            {
                await GameService.UpdateBucketItem<client>(data_id, user_id_cod, new client
                {

                    Name = name.text,
                    Pohone = int.Parse(Pohenee.text),
                    shomare_hsab = shomare_hsab.text,
                    shomare_shaba = shomar_shaba.text
                });


            }
            else
            {

                await GameService.AddBucketItem<client>(data_id, new client
                {

                    Name = name.text,
                    Pohone = int.Parse(Pohenee.text),
                    shomare_hsab = shomare_hsab.text,
                    shomare_shaba = shomar_shaba.text

                });
            }
        }
        catch (System.Exception)
        {

            
        }
        



    }





    
    
}
