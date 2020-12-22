using CodeHub.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using CodeHub.Models.Dao;
using CodeHub.utils;

namespace CodeHub.Controllers
{
    public class PastebinController : Controller
    {
        private PastebinDao pastebinDao = new PastebinDao();
        private Encode encode = new Encode();
        [HttpGet]
        public ActionResult write()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult postCode(PasteCode pasteCode)
        {
            pasteCode.code = encode.stringToNum(pasteCode.code);
            int id = pastebinDao.insertNewPasteCode(pasteCode);
            Object result = new
            {
                id = id
            };
            string jsonStr = JsonConvert.SerializeObject(result);
            return Content(jsonStr);
        }

        [HttpGet]
        public ActionResult show(int id)
        {
            PasteCode pasteCode = pastebinDao.selectPasteCodeById(id);
            pasteCode.code = encode.numToString(pasteCode.code);
            base.ViewData["PasteCode"] = pasteCode;
            return View(pasteCode);
        }
    }
}