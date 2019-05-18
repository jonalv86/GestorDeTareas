﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GestorDeTareas.ViewModels
{
    public class TareaViewModel
    {
        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "El título de la tarea no debe estar vacío")]
        public string Titulo { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción de la tarea no debe estar vacía")]
        public string Descripcion { get; set; }

        [Display(Name = "Asignado a:")]
        public int? UsuarioAsignado { get; set; }

        [Display(Name = "Vencimiento")]
        public DateTime? Vencimiento { get; set; }

        [Display(Name = "Prioridad")]
        public int Prioridad { get; set; }

        [Display(Name = "Nombre")]
        public int Estado { get; set; }

        //Drop down lists
        public List<SelectListItem> PrioridadesDDL { get; set; }
        public List<SelectListItem> EstadosDDL { get; set; }
    }
}