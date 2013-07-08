using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DmirProject.ViewModel
{
    public class SearchModel
    {
        public int TotalCount { get; set; }
        public int Pages { get; set; }

        public IEnumerable<User> Users { get; set; }

        [DisplayName("Введите имя или часть имени.")]
        [RegularExpression(@"^[a-zA-Zа-яёА-ЯЁ0-9''-'\s]*$", ErrorMessage = "Укажите корректное значение")]
        public string SearchName { get; set; }
    }
}