﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApi.Models
{
  public class Movie
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public  string Language { get; set; }
    public double Rating { get; set; }
    [NotMapped]
    public IFormFile Image { get; set; }
  }
}
