﻿using System;

namespace ProjetoTeste2.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public virtual byte[] RecordTimeStamp { get; set; }
    }
}
