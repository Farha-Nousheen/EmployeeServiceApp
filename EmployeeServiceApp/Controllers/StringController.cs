using EmployeeServiceApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeServiceApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StringController : ControllerBase
    {

        EmployeeContext _context;
        public StringController(EmployeeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public string Stringreverse(string s)



        {
            string result = string.Join(' ', s
                .Split(' ').
                Select(x => new string(x.Reverse().ToArray())));
            return result;
        }
        [HttpGet]
        public string Namingsplit(string name)
        {
            string first = name.Split(' ')[0];
            return first;
        }
        [HttpGet]
        public string convertnameUpper(string txt)
        {
            string txt1 = txt.ToUpper();
            return txt1;
        }
        [HttpGet]
        public string convertnameLower(string txt)
        {
            string txt1 = txt.ToLower();
            return txt1;
        }
        [HttpGet]
        public bool Comparing(string txt, string txt1)
        {
            if (string.Compare(txt, txt1) == 0)
            {
                return true;
            }



            else { }
            return false;
        }
        [HttpGet]
        public int leng(string str)
        {
            int str1 = str.Length;
            return str1;
        }
        [HttpGet]
        public string concat(string str1, string str2)
        {
            string name = string.Concat(str1, str2);
            return name;
        }
        [HttpGet]
        public int IndexOf(string name,char c)
        {
         
            return name.IndexOf(c);
        }


        }
        

            
    }


    

