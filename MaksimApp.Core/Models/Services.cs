﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaksimApp.Core.Models;

public class Services:BaseEntity
{
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = null!;

    public string? ImageUrl { get; set; }
    [NotMapped]
    public IFormFile PhotoFile { get; set; }
}
