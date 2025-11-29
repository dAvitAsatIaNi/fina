using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly IGroupService _groupService;
    private readonly IProductService _productService;

    public HomeController(
        IGroupService groupService,
        IProductService productService)
    {
        _groupService = groupService;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var groups = await _groupService.GetGroupsAsync();
        var products = await _productService.GetProductsAsync();

        var vm = new ProductManagementViewModel
        {
            Groups = groups,
            Products = products
        };

        return View(vm);
    }
}