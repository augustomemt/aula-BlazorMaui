﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveCCEE.Domain.Entities
{
  public class ConfigurationCCEE
  {

    [Key]
    public int ID { get; set; }
    public string CertificatePath { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string CodAgent {  get; set; }
  }
}
