﻿using Abstodo.DataAccess.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Abstodo.Entities.Concrete
{
    public class TaskDetail : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TaskID { get; set; }

        // Navigation property
        //public Task? Task { get; set; }
    }
}
