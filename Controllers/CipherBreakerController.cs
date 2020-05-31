using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CipherBreakerApi.Models;
using CipherBreaker;

namespace CipherBreakerApi.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class CipherBreakerController : ControllerBase
    {
        private readonly WordFrequencyContext wordFrequencyDb;

        public CipherBreakerController(WordFrequencyContext context)    //这里利用Asp.net core框架自动注入Context对象
        {
            this.wordFrequencyDb = context;
        }

        //GET: cipherbreaker/api/encrypt?method=加密方法&str=字符串&key=密钥
        [HttpGet]
        [Route("encrypt")]
        public ActionResult<string> GetEncrypt(string method, string str, string key)
        {
            try
            {
                if (method == "caesar")
                {
                    Caesar caesar = new Caesar();
                    
                    var result = caesar.Encode(str, key);

                    if (result.Item2 == true) 
                    {
                        return result.Item1;
                    }
                }
                else if (method == "railfence")
                {
                    RailFence railFence = new RailFence();

                    var result = railFence.Encode(str, key);

                    if (result.Item2 == true)
                    {
                        return result.Item1;
                    }
                }
                else if (method == "affine")
                {
                    Affine affine = new Affine();

                    var result = affine.Encode(str, key);

                    if (result.Item2 == true)
                    {
                        return result.Item1;
                    }
                }
                else if (method == "substitution")
                {
                    Substitution substitution = new Substitution();

                    var result = substitution.Encode(str, key);

                    if (result.Item2 == true)
                    {
                        return result.Item1;
                    }
                }
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

            return "No such method!";
        }

        //POST: cipherbreaker/api/encrypt
        [HttpPost]
        [Route("encrypt")]
        public ActionResult<string> PostEncrypt(EncryptItem item)
        {
            return item.str + item.encryptMethod;
        }

        //GET: cipherbreaker/api/decrypt?method=解密方法&str=字符串&key=密钥
        [HttpGet]
        [Route("decrypt")]
        public ActionResult<string> GetDecrypt(string method, string str, string key)
        {
           try
            {
                if (method == "caesar")
                {
                    Caesar caesar = new Caesar();
                    
                    var result = caesar.Decode(str, key);

                    if (result.Item2 == true) 
                    {
                        return result.Item1;
                    }
                }
                else if (method == "railfence")
                {
                    RailFence railFence = new RailFence();

                    var result = railFence.Decode(str, key);

                    if (result.Item2 == true)
                    {
                        return result.Item1;
                    }
                }
                else if (method == "affine")
                {
                    Affine affine = new Affine();

                    var result = affine.Decode(str, key);

                    if (result.Item2 == true)
                    {
                        return result.Item1;
                    }
                }
                else if (method == "substitution")
                {
                    Substitution substitution = new Substitution();

                    var result = substitution.Decode(str, key);

                    if (result.Item2 == true)
                    {
                        return result.Item1;
                    }
                }
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

            return "No such method!";
        }

        //POST: cipherbreaker/api/decrypt
        [HttpPost]
        [Route("decrypt")]
        public ActionResult<string> PostDecrypt(DecryptItem item)
        {
            return "Wait to finish";
        }

        //GET: cipherbreaker/api/break?method=破解方法&str=字符串
        [HttpGet]
        [Route("break")]
        public ActionResult<string> GetBreak(string method, string str)
        {
            try
            {
                if (method == "caesar")
                {
                    Caesar caesar = new Caesar();
                    
                    var result = caesar.Break(str);

                    return result.Item1 + "," + result.Item2.ToString();
                }
                else if (method == "railfence")
                {
                    RailFence railFence = new RailFence();

                    var result = railFence.Break(str);

                    return result.Item1 + "," + result.Item2.ToString();
                }
                else if (method == "affine")
                {
                    Affine affine = new Affine();

                    var result = affine.Break(str);

                    return result.Item1 + "," + result.Item2.ToString();
                }
                else if (method == "substitution")
                {
                    Substitution substitution = new Substitution();

                    var result = substitution.Break();

                    return result.Item1 + "," + result.Item2.ToString();
                }
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

            return "No such method!";
        }

        //GET: cipherbreaker/api/wordfreq
        [HttpGet]
        [Route("wordfreq")]
        public ActionResult<string> GetWordFrequency()
        {
            return "Wait to finish";
        }
    }
}
