using Data;
using Domain;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MinimalApiCodeCoolShop.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly CodecoolshopContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public OrderService(CodecoolshopContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public List<Domain.Order> GetAllOrders() => _context.Orders.ToList();

        public void SaveOrderToJson(Order order)
        {
            var currentDate = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
            var fileName = $"{order.Status}_{currentDate}.json";
            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "OrderJsonLogFiles", fileName);

            // Create the directory if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            // Serialize the order object to JSON
            var options = new JsonSerializerOptions { WriteIndented = true };
            var orderJson = JsonSerializer.Serialize(order, options);

            // Write the JSON data to the file using FileStream
            using var stream = new FileStream(filePath, FileMode.Create);
            using var writer = new StreamWriter(stream);
            writer.Write(orderJson);
        }
    }
}
