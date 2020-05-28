using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CipherBreakerApi.Models;

namespace CipherBreakerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CipherBreakerController : ControllerBase
    {
        private readonly WordFrequencyContext wordFrequencyDb;

        // public CipherBreakerController(WordFrequencyContext context)    //这里利用Asp.net core框架自动注入Context对象
        // {
        //     this.wordFrequencyDb = context;
        // }

        //GET: api/cipherbreaker/encrypt?string=字符串&encryptMethod=加密方法
        [HttpGet]
        [Route("encrypt")]
        public ActionResult<string> GetEncrypt(string str, string encryptMethod)
        {
            return str + encryptMethod;
        }

        //POST: api/cipherbreaker/encrypt
        [HttpPost]
        [Route("encrypt")]
        public ActionResult<string> PostEncrypt(EncryptItem item)
        {
            return item.str + item.encryptMethod;
        }

        //GET: api/cipherbreaker/decrypt?str=字符串&encrypt_method=解密方法&key=密钥
        [HttpGet]
        [Route("decrypt")]
        public ActionResult<string> GetDecrypt(string str, string encryptMethod, string key)
        {
            return str + encryptMethod + key;
        }

        //POST: api/cipherbreaker/decrypt
        [HttpPost]
        [Route("decrypt")]
        public ActionResult<string> PostDecrypt(DecryptItem item)
        {
            return "Wait to finish";
        }

        //GET: api/cipherbreaker/break?str=字符串
        [HttpGet]
        [Route("break")]
        public ActionResult<string> GetBreak(string str)
        {
            return str;
        }

        //GET: api/cipherbreaker/wordfreq
        [HttpGet]
        [Route("wordfreq")]
        public ActionResult<string> GetWordFrequency()
        {
            return "Wait to finish";
        }
    }
}
