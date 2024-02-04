using Connection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Connection.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    SqlConnection connection = new("");
    [HttpPost]
    public IActionResult Create(string name)
    {
        //ApplicationDbContext context = new();
        //Personel personel = new()
        //{
        //    Name = name
        //};

        //context.Add(personel);
        //context.SaveChanges();

        connection.Open();


        SqlCommand kmt = new("insert into Personels(Name) Values(@p1)", connection);
        kmt.Parameters.AddWithValue("@p1", name);
        kmt.ExecuteNonQuery();



        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        //ApplicationDbContext context = new();
        //var personels = context.Personels.ToList();

        connection.Open();

        SqlCommand kmt = new("Select * from Personels", connection);
        SqlDataReader reader = kmt.ExecuteReader();
        List<Personel> personels = new();

        while (reader.Read())
        {
            var personel = new Personel
            {
                // Burada, veritabanı sütunlarınıza uygun şekilde Personel nesnesini doldurmanız gerekiyor.
                // Örnek:
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                // Diğer alanlarınız buraya eklenebilir.
            };
            personels.Add(personel);
        }

        return Ok(personels);
    }
}
