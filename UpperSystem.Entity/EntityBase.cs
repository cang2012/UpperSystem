using System;

namespace UpperSystem.Entity
{
    public  class EntityBase
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedUserId { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public string ModifiedUserId { get; set; }
    }
}
