using AdventureWorksAPI.Middlewares.ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExceptionController : ControllerBase
    {
       [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        if (id <= 0)
        {
            throw new ValidationExceptions("Order ID must be greater than zero.");
        }

        // فرض کنیم این متد به دیتابیس دسترسی دارد
        try
        {
            // شبیه‌سازی خطای دیتابیس
            throw new DatabaseException("Failed to connect to the database.");
        }
        catch (Exception ex)
        {
            throw new DatabaseException($"Database operation failed: {ex.Message}");
        }

        // فرض کنیم سفارش پیدا نشد
        throw new NotFoundException($"Order with ID {id} not found.");
    }
    }
}