﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CipherBreakerApi
{
    class RailFence : SymmetricScheme
    {
        protected override bool keyIsValid(string key = null)
        {
            if (key == null)
            {
                key = this.key;
            }
            int keyInt;
            return int.TryParse(key, out keyInt);
        }

        public RailFence(string plain=null,string cipher=null,string key = null) : base(plain, cipher, key)
        {
            Type = SchemeType.RailFence;
        }
        ~RailFence()
        {

        } 
        public override (string, bool) Encode(string plain = null, string key = null)
        {
            if (plain == null)
            {
                plain = Plain;
            }
            if (key == null)
            {
                key = Key;
            }
            if (!keyIsValid(key))
            {
                return (null, false);
            }
            int keyInt = int.Parse(key);
            string cipher = "";
            string[] cipherBucket = new string[keyInt];
            
            for (int i = 0; i < plain.Length; i++)
            {
                cipherBucket[i % keyInt]+=plain[i];
            } 
            
            for(int k=0;k<keyInt;k++)
            {
                cipher += cipherBucket[k];
            }
            this.Key = key;
            this.Cipher = cipher;
            this.Plain = plain;
            return (cipher, true);
        }
        
        public override (string, double) Break(string cipher = null)
        {
            throw new NotImplementedException();
        }

        public override (string, bool) Decode(string cipher = null, string key = null)
        {
            if (cipher == null)
            {
                cipher = Cipher;
            }
            if (key == null)
            {
                key = Key;
            }
            if (!keyIsValid(key))
            {
                return (null, false);
            }
            int keyInt = int.Parse(key);

            string plain = "";
            string[] plainBucket = new string[keyInt];
            int i = cipher.Length / keyInt;
            int j = cipher.Length % keyInt;

            for (int k = 0; k < keyInt; k++)
            {
                if (k < j)
                {
                    for (int m = 0; m <= i; m++)
                    {
                        plainBucket[k] += cipher[k * (i + 1) + m];
                    }
                }
                else
                {
                    for (int m = 0; m < i; m++)
                    {
                        plainBucket[k] += cipher[k * i + m + j];
                    }
                }
            }
            
            for(int m = 0; m < i; m++)
            {
                for (int k = 0; k < keyInt; k++)
                {
                    plain = plain + plainBucket[k][m];
                }
            }
            for(int k=0;k<j;k++)
            {
                plain += plainBucket[k][i];
            }

            this.Key = key;
            this.Plain = plain;
            this.Cipher = cipher;

            return (plain, true);
        }


        public override bool Load(string fileName)
        {
            throw new NotImplementedException();
        }

        public override bool Save(string fileName)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

       
    }
}
