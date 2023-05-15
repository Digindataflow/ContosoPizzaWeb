using ContosoPizzaWeb.Models;
using ContosoPizzaWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizzaWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController: ControllerBase {
    public PizzaController () {

    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll(){
        return PizzaService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id) {
        var p = PizzaService.Get(id);
        if (p == null) {
            return NotFound();
        }
        return p;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {            
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new {id = pizza.Id}, pizza);
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id) {
            return BadRequest();
        }
        var OldPizza = PizzaService.Get(id);
        if (OldPizza == null) {
            return NotFound();
        }
        PizzaService.Update(pizza);
        return NoContent();

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var OldPizza = PizzaService.Get(id);
        if (OldPizza == null) {
            return NotFound();
        }
        PizzaService.Delete(id);
        return NoContent();
    }
}