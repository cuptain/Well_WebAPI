using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_V1336.Models
{
    public static class WellCollection //Для хранения скважин
    {
        public static List<Well> Wells { get; set; } = new List<Well>(); //Список скважин
    }
}