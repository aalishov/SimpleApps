using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HousekeeperManager.ViewModels.Missions
{
    public class MissionCreateVM
    {
        [Required]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Полето е задължително")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Обект/Адрес")]
        public int LocationId { get; set; }

        
        [Display(Name = "Краен срок")]
        [DataType(DataType.Date,ErrorMessage = "Полето е задължително")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TimeLimit { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Бюджет")]
        [Range(minimum: 10, maximum: double.MaxValue,ErrorMessage ="Въведете стойност по-голяма от 0")]
        public double Budget { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        public int StatusId { get; set; }

        public string ClientId { get; set; }

        public SelectList LocationItems { get; set; }

        public SelectList CategoryItems { get; set; }

    }
}
