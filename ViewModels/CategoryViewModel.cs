using kcms_challenge_dev_backend.Models.Collections;
using System.Collections.Generic;
using System.Linq;

namespace kcms_challenge_dev_backend.ViewModels
{
    public class CategoryViewModel
    {
        public string CategoryID { get; set; }
        public string Name { get; set; }

        public static explicit operator CategoryViewModel(Category obj)
        {
            CategoryViewModel CategoryViewModel = new()
            {
                CategoryID = obj.CategoryID,
                Name = obj.Name
            };

            return CategoryViewModel;
        }
    }
}
