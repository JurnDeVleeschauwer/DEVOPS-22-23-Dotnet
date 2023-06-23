using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace Domain.Common
{
    public class Hardware : ValueObject
    {
        private int _memory;
        private int _storage;
        private int _amountVCPU;


        public int Id { get; set; }
        public int Memory
        {
            get { return _memory; }
            set { _memory = Guard.Against.Negative(value, nameof(_memory)); }
        }
        public int Storage
        {
            get { return _storage; }
            set { _storage = Guard.Against.Negative(value, nameof(_storage)); }
        }
        public int Amount_vCPU
        {
            get { return _amountVCPU; }
            set { _amountVCPU = Guard.Against.Negative(value, nameof(_amountVCPU)); }
        }



        public Hardware(int m, int s, int a_vCPU)
        {
            this.Memory = m;
            this.Storage = s;
            this.Amount_vCPU = a_vCPU;

        }


        public Hardware()
        {

        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Memory;
            yield return Storage;
            yield return Amount_vCPU;
        }

        public override string ToString() => $"{Amount_vCPU} {Storage} {Memory}";
    }
}