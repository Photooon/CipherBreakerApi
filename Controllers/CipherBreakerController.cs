using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CipherBreakerApi.Models;
using CipherBreakerApi;

namespace CipherBreakerApi.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class CipherBreakerController : ControllerBase
    {
        private readonly CBContext context;

        public CipherBreakerController(CBContext context)    //这里利用Asp.net core框架自动注入Context对象
        {
            this.context = context;
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
                        SaveEncryptItems(method, str, key, result.Item1);

                        return result.Item1;
                    }
                }
                else if (method == "railfence")
                {
                    RailFence railFence = new RailFence();

                    var result = railFence.Encode(str, key);

                    if (result.Item2 == true)
                    {
                        SaveEncryptItems(method, str, key, result.Item1);

                        return result.Item1;
                    }
                }
                else if (method == "affine")
                {
                    Affine affine = new Affine();

                    var result = affine.Encode(str, key);

                    if (result.Item2 == true)
                    {
                        SaveEncryptItems(method, str, key, result.Item1);

                        return result.Item1;
                    }
                }
                else if (method == "substitution")
                {
                    Substitution substitution = new Substitution();

                    var result = substitution.Encode(str, key);

                    if (result.Item2 == true)
                    {
                        SaveEncryptItems(method, str, key, result.Item1);
                        
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
        public ActionResult<string> PostEncrypt(string method, string str, string key)
        {
            return GetEncrypt(method, str, key);
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
                        SaveDecryptItems(method, str, key, result.Item1);

                        return result.Item1;
                    }
                }
                else if (method == "railfence")
                {
                    RailFence railFence = new RailFence();

                    var result = railFence.Decode(str, key);

                    if (result.Item2 == true)
                    {
                        SaveDecryptItems(method, str, key, result.Item1);

                        return result.Item1;
                    }
                }
                else if (method == "affine")
                {
                    Affine affine = new Affine();

                    var result = affine.Decode(str, key);

                    if (result.Item2 == true)
                    {
                        SaveDecryptItems(method, str, key, result.Item1);

                        return result.Item1;
                    }
                }
                else if (method == "substitution")
                {
                    Substitution substitution = new Substitution();

                    var result = substitution.Decode(str, key);

                    if (result.Item2 == true)
                    {
                        SaveDecryptItems(method, str, key, result.Item1);
                        
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
        public ActionResult<string> PostDecrypt(string method, string str, string key)
        {
            return GetDecrypt(method, str, key);
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

                    SaveBreakItems(method, str, result.Item1, result.Item2);

                    return result.Item1 + "," + result.Item2.ToString();
                }
                else if (method == "railfence")
                {
                    RailFence railFence = new RailFence();

                    var result = railFence.Break(str);

                    SaveBreakItems(method, str, result.Item1, result.Item2);

                    return result.Item1 + "," + result.Item2.ToString();
                }
                else if (method == "affine")
                {
                    Affine affine = new Affine();

                    var result = affine.Break(str);

                    SaveBreakItems(method, str, result.Item1, result.Item2);

                    return result.Item1 + "," + result.Item2.ToString();
                }
                else if (method == "substitution")
                {
                    Substitution substitution = new Substitution();

                    var result = substitution.Break();

                    SaveBreakItems(method, str, result.Item1, result.Item2);

                    return result.Item1 + "," + result.Item2.ToString();
                }
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

            return "No such method!";
        }

        //POST: cipherbreaker/api/break
        [HttpPost]
        [Route("break")]
        public ActionResult<string> PostBreak(string method, string str)
        {
            return GetBreak(method, str);
        }

        //GET: cipherbreaker/api/encryptitems
        [HttpGet]
        [Route("encryptitems")]
        public ActionResult<List<EncryptItem>> GetEncryptItems()
        {
            var query = context.EncryptItems.ToList();
            return query;
        }

        //GET: cipherbreaker/api/decryptitems
        [HttpGet]
        [Route("decryptitems")]
        public ActionResult<List<DecryptItem>> GetDecryptItems()
        {
            var query = context.DecryptItems.ToList();
            return query;
        }

        //GET: cipherbreaker/api/breakitems
        [HttpGet]
        [Route("breakitems")]
        public ActionResult<List<BreakItem>> GetBreakItems()
        {
            var query = context.BreakItems.ToList();
            return query;
        }

        private void SaveEncryptItems(string method, string str, string key, string result)
        {
            EncryptItem encryptItem = new EncryptItem();
            encryptItem.method = method;
            encryptItem.str = str;
            encryptItem.key = key;
            encryptItem.result = result;

            context.EncryptItems.Add(encryptItem);
            context.SaveChanges();
        }

        private void SaveDecryptItems(string method, string str, string key, string result)
        {
            DecryptItem decryptItem = new DecryptItem();
            decryptItem.method = method;
            decryptItem.str = str;
            decryptItem.key = key;
            decryptItem.result = result;

            context.DecryptItems.Add(decryptItem);
            context.SaveChanges();
        }

        private void SaveBreakItems(string method, string str, string result_str, double result_prob)
        {
            BreakItem breakItem = new BreakItem();
            breakItem.method = method;
            breakItem.str = str;
            breakItem.result_str = result_str;
            breakItem.result_prob = result_prob;

            context.BreakItems.Add(breakItem);
            context.SaveChanges();
        }
    }
}

