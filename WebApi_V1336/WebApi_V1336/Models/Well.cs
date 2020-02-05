using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApi_V1336.Models
{
    public class Well
    {
        public int Id { get; set; }             //ID

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Недопустимая длина названия скважины")]
        public string Name { get; set; }        //Название

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Недопустимая длина названия куста")]
        public string Group { get; set; }       //Название группы скважин

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Недопустимая длина названия месторождения")]
        public string Field { get; set; }       //Название месторождения

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Недопустимая длина названия куста")]
        public string Factory { get; set; }     //Название цеха

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Недопустимая идентификатор контроллера")]
        public int ControllerId { get; set; }   //Идентификатор контроллера
        public OperationTypeEnum OperationType { get; set; }        //Тип эксплуатации
        public enum OperationTypeEnum { ЭЦН = 1, ШГН = 2, ГПШГН = 3, ЭВН = 4}   //Тип эксплуатации (перечисление)
    }
}