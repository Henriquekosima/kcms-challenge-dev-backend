using kcms_challenge_dev_backend.Models.Collections;

namespace kcms_challenge_dev_backend.ViewModels
{
    public class ProductViewModel
    {
        public string ProductID { get; set; }
        public string Description { get; set; }
        public string CategoryID { get; set; }

        public static explicit operator ProductViewModel(Product obj)
        {
            ProductViewModel CategoryViewModel = new()
            {
                ProductID = obj.ProductID,
                Description = obj.Description,
                CategoryID = obj.CategoryID
            };

            return CategoryViewModel;
        }
    }
}
