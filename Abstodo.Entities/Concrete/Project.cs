﻿using Abstodo.DataAccess.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Abstodo.Entities.Concrete
{
    public class Project
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StatusID { get; set; }

        // Navigation property
        public Status Status { get; set; }
    }
}
