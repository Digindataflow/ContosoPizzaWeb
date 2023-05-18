using ContosoPizzaWeb.Models;
using ContosoPizzaWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizzaWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController: ControllerBase {
    private PizzaService _service;

    public PizzaController (PizzaService service) {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Pizza> GetAll(){
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id) {
        var p = _service.GetById(id);
        if (p == null) {
            return NotFound();
        }
        return p;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {            
        _service.Create(pizza);
        return CreatedAtAction(nameof(Get), new {id = pizza.Id}, pizza);
    }

    [HttpPut("{id}/addtopping")]
    public IActionResult AddTopping(int id, int toppingId)
    {
        var pizzaToUpdate = _service.GetById(id);

        if(pizzaToUpdate is not null)
        {
            _service.AddTopping(id, toppingId);
            return NoContent();    
        }
        else
        {
            return NotFound();
        }
    }
    
    [HttpPut("{id}/updatesauce")]
    public IActionResult Update(int id, int sauceId)
    {
        var OldPizza = _service.GetById(id);
        if (OldPizza == null) {
            return NotFound();
        }
        _service.UpdateSauce(id, sauceId);
        return NoContent();

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var OldPizza = _service.GetById(id);
        if (OldPizza == null) {
            return NotFound();
        }
        _service.DeleteById(id);
        return Ok();
    }
}