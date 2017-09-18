using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data.Entity;


namespace Diplom_Anti_ice.Controllers
{
    public class HomeController : Controller
    {
        Model_Antiice ent = new Model_Antiice();
        Functions func = new Functions();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }//Первоначальная страничка

        //Добавление устройства
        /// /////////////////////////////////////////////////
        [HttpGet]
        public ActionResult addDev()
        {
            return View("addDev");
        }
        [HttpPost]
        public ActionResult addDev(Device device)
        {
            device.Id = Guid.NewGuid();
            ent.Device.Add(device);
            ent.SaveChanges();
            return View("Index");
        }
        /// ///////////////////////////////////////////////////

        public ActionResult seeMap()
        {
            List<Device> list = new List<Device>();
            foreach (var dev in ent.Device.ToList())
            {
                list.Add(dev);
            }
            return View(list);
        }//Просмотр карты с устройствами

        [HttpGet]
        public void addInfoDevicce(string token, string Temperature,string Wetness)
        {
            foreach(var dev in ent.Device.ToList())
            {
                if (token == dev.Id.ToString())
                {
                    dev.Temperature = double.Parse(Temperature);
                    dev.Wetness = double.Parse(Wetness);
                    ent.Entry(dev).State = EntityState.Modified;
                    ent.SaveChanges();
                    break;
                }
            }
        }//Метод добавления информации о температуре и влаажности

        [HttpGet]
        public void addHelp(string token)
        {
            foreach (var dev in ent.Device.ToList())
            {
                if (token == dev.Id.ToString())
                {
                    Help newHelp = new Help();
                    newHelp.ID_Device = Guid.Parse(token);
                    newHelp.Date = DateTime.Now;
                    ent.Help.Add(newHelp);
                    ent.Entry(newHelp).State = EntityState.Added;
                    ent.SaveChanges();
                    func.sendEmail(dev.Id);
                    break;
                }
            }
        }//Метод отправки Email о помощи
    }
}