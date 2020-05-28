﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;

namespace CipherBreaker
{
	enum SchemeType
	{
		Caesar,
		Vigenere,
		Substitution,
		Transposition,
		RailFence,
		Columnar
	}

	enum SchemeState
	{
		Ready,
		Encoding,
		Decoding,
		Breaking,
		Finish,
		Over
	}

	abstract class Scheme
	{
		protected string name;

		protected const int LetterSetSize = 26;

		protected static Dictionary<SchemeType, int> schemeCount = new Dictionary<SchemeType, int>();

		protected SchemeState state;
		protected ConcurrentQueue<string> processLog;

		public Scheme(string plain = null, string cipher = null)
		{
			this.state = SchemeState.Ready;
			this.Plain = plain;
			this.Cipher = cipher;
			processLog = new ConcurrentQueue<string>();
			this.ShouldOutput = false;
		}

		~Scheme()
		{
			// Do nothing
		}

		public string Name
		{
			get => name;
			set
			{
				StringBuilder nameBuilder = new StringBuilder(value);
				foreach (char invalidChar in System.IO.Path.GetInvalidFileNameChars())
					nameBuilder = nameBuilder.Replace(invalidChar.ToString(), string.Empty);
				this.name = nameBuilder.ToString();
			}
		}

		public SchemeType Type { get; protected set; }
		public SchemeState State { get => state; }
		public string Plain { get; set; }
		public string Cipher { get; set; }

		public bool ShouldOutput { get; set; }

		public abstract (string, bool) Encode(string plain = null, string encodeKey = null);
		public abstract (string, bool) Decode(string cipher = null, string decodeKey = null);
		public abstract (string, double) Break(string cipher = null);

		public SchemeState End()
		{
			state = SchemeState.Over;
			return state;
		}

		public abstract bool Save(string fileName);
		public abstract bool Load(string fileName);

		public static int SchemeCount()
		{
			int sum = 0;
			foreach (int val in schemeCount.Values)
			{
				sum += val;
			}
			return sum;
		}
		public static int SchemeCount(SchemeType type)
		{
			return schemeCount[type];
		}

		public new abstract string ToString();
	}
}
