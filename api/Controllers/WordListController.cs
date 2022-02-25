#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Models.Dtos;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordListController : Controller
    {
        private readonly DBcontext _context;

        public WordListController(DBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getWordLists()
        {

            WordList[] list = await _context.WordLists.ToArrayAsync();
            List<WordListDTO> dto_list = new List<WordListDTO>();
            foreach (var wl in list)
            {
                WordListDTO dto = new WordListDTO
                {
                    Id = wl.Id,
                    Name = wl.Name,
                    CreatedAt = wl.CreatedAt
                };
                dto_list.Add(dto);
            }
            dto_list.Sort();
            return Ok(dto_list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getWordsInList([FromRoute] int id)
        {
            WordList wl = await _context.WordLists.Include("Words").FirstOrDefaultAsync(x => x.Id == id);
            if (wl == null) return BadRequest("List does not exist");
            
            List<WordDTO> li = new List<WordDTO>();
            foreach (var word in wl.Words)
            {
                WordDTO dto = new WordDTO
                {
                    Sv = word.Sv,
                    En = word.En 
                };
                li.Add(dto);
            }
            return Ok(li);
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> addWordToList([FromRoute] int id , WordDTO word)
        {
            WordList wl = await _context.WordLists.FirstAsync(x => x.Id == id);
            if (wl == null) return BadRequest("List does not exist");

            Word w = new Word()
            {
                Sv = "NOT IMPLEMENTED",
                En = word.En,
                InList = wl,
                InListId = wl.Id,
            };
            await _context.words.AddAsync(w);
            await _context.SaveChangesAsync();

            WordDTO dto = new WordDTO
            {
                Sv = w.Sv,
                En = w.En,
                InListId = w.InListId
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> createWordList(WordListDTO dto)
        {
            if (dto.Name == null) return BadRequest();
            WordList wl = new WordList()
            {
                Name = dto.Name,
                CreatedAt = DateTime.UtcNow,
                Words = new List<Word>()
            };
            await _context.WordLists.AddAsync(wl);
            await _context.SaveChangesAsync();
            return Ok(wl);
        }
        
    }
}
