﻿/* 
* Copyright (c) Marc Clifton
* The Code Project Open License (CPOL) 1.02
* http://www.codeproject.com/info/cpol10.aspx
*/

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Clifton.Blockchain
{
    public class MerkleHash
    {
        public byte[] Value { get; protected set; }

        protected MerkleHash()
        {
        }

        public static MerkleHash Create(byte[] buffer)
        {
            var hash = new MerkleHash();
            hash.ComputeHash(buffer);

            return hash;
        }

        public static MerkleHash Create(string buffer) => Create(Encoding.UTF8.GetBytes(buffer));

        public static MerkleHash Create(MerkleHash left, MerkleHash right) => Create(left.Value.Concat(right.Value).ToArray());

        public static bool operator ==(MerkleHash h1, MerkleHash h2)
        {
            return h1.Equals(h2);
        }

        public static bool operator !=(MerkleHash h1, MerkleHash h2)
        {
            return !h1.Equals(h2);
        }

        public override bool Equals(object obj)
        {
            MerkleTree.Contract(() => obj is MerkleHash, "rvalue is not a MerkleHash");
            return Equals((MerkleHash)obj);
        }

        public override string ToString() => BitConverter.ToString(Value).Replace("-", "");

        public void ComputeHash(byte[] buffer)
        {
            var sha256 = SHA256.Create();
            SetHash(sha256.ComputeHash(buffer));
        }

        public void SetHash(byte[] hash)
        {
            MerkleTree.Contract(() => hash.Length == Constants.HASH_LENGTH, "Unexpected hash length.");
            Value = hash;
        }

        public bool Equals(byte[] hash) => Value.SequenceEqual(hash);

        public bool Equals(MerkleHash hash)
        {
            var ret = false;

            if (((object)hash) != null)
            {
                ret = Value.SequenceEqual(hash.Value);
            }

            return ret;
        }
    }
}
