﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.TableViewModels
{
    public class UserTableViewModels
    {
        public int Id { get; set; }
        public  string Email {get;set;}

        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
}