

namespace PizzaStore.Utils
{
    enum MainMenuOptions
    {
        Exit = 0,
        OrderMenu = 1,
        CustomerMenu = 2,
        AdminMenu = 3,
        StoreTutorial = 4
    }

    enum OrderMenuOptions
    {
        Back = 0,
        Order = 1,
        PastOrders = 2,
    }

    enum SubOrderMenuOptions
    {
        Back = 0,
        ViewMenu = 1,
        AddPizza = 2,
        PrintCurrentOrder = 3,
        DelPizzaFromOrder = 4,
        FinalizeOrder = 5
    }
    enum CustomerMenuOptions
    {
        Back = 0,
        PrintCustomerFile = 1,
        CreateCustomer = 2,
        ReadCustomer = 3,
        UpdateCustomer = 4,
        DeleteCustomer = 5
    }
    enum AdminMenuOptions
    {
        Back = 0,
        PrintMenu = 1,
        CreatePizza = 2,
        ReadPizza = 3,
        UpdatePizza = 4,
        DeletePizza = 5
    }

    
}
