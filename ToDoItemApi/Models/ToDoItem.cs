using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoItemApi.Models
{
    public class ToDoItem
    {
        [Required(ErrorMessage = "ID is required")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public bool IsComplete { get; set; }
    }
}
