namespace FastFood.Core.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<CreateorderItemViewModel> Items { get; set; }

        public List<CreateOrderEmployeeViewModel> Employees { get; set; }


    }
}
