using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;

namespace Domain.VirtualMachines.BackUp
{
    public class Backup : ValueObject
    {


        private BackUpType _type;

        public BackUpType Type { get { return _type; } set { _type = Guard.Against.Null(value, nameof(_type)); } }
        public DateTime? LastBackup { get; set; }  //lastBackup can be null


        public Backup(BackUpType type, DateTime? lastBackup)
        {
            Type = type;
            LastBackup = lastBackup;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return (int)Type;
            yield return LastBackup.HasValue ? LastBackup.Value.Millisecond : 0;

        }
    }
}
