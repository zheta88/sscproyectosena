using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CursoMVC.Models;
using CursoMVC.Models.TableViewModels;
using CursoMVC.Models.ViewModels;

namespace CursoMVC.Models.TableViewModels
{
    public class ActivosTableViewModels
    {
        public int Id { get; set; }
        public string Marca { get; set; }

        public string Serial { get; set; }
        public string Observaciones { get; set; }
    }
}