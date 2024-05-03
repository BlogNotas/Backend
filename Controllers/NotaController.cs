using Microsoft.AspNetCore.Mvc;
using Block.Data;
using Notas.Models; //Nombre del namespace del modelo (Models/NotasModels(SE llama el name space))
using Microsoft.EntityFrameworkCore; 

[Route("api/NotaController")]
[ApiController]
public class NotaController : ControllerBase
{
    private readonly BaseContext _context;
    public NotaController(BaseContext context)
    {
        _context = context;
    }


    [HttpGet]  //Listar todas las Notas
    public async Task<ActionResult<IEnumerable<Nota>>> GetNotas()
    {
        return await _context.Notas.ToListAsync();
    }

    [HttpGet("{id}")] //Detalles de la nota segun su id
    public async Task<ActionResult<Nota>> GetNota(int id)
    {
        var nota = await _context.Notas.FindAsync(id);
        if (nota == null)
        {
            return NotFound();
        }
        return nota;
    }

    [HttpPost] //Crear una nota
    public async Task<ActionResult<Nota>> PostNota(Nota nota)
    {
        _context.Notas.Add(nota);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetNota), new { id = nota.Id }, nota);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNota(int id)
    {
        var nota = await _context.Notas.FindAsync(id);
        if (nota == null)
        {
            return NotFound();
        }
        _context.Notas.Remove(nota);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutNota(int id, Nota nota)
    {
        if (id!= nota.Id)
        {
            return BadRequest();
        }
        _context.Entry(nota).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NotaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    private bool NotaExists(int id) //Verifica si el id Existe
    {
        return _context.Notas.Any(e => e.Id == id);
    }





}

