using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_IDA.DTO.Models.Result;
using Project_P34.DataAccess;
using Project_P34.DataAccess.Entity;
using Project_P34.DTO.Models;

namespace Project_P34.API_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        private readonly EFContext _context;


        public FlatController(EFContext context)
        {
            _context = context;
        }

        [HttpPost("addflat")]
        public ResultDto AddFlat([FromBody] FlatDTO model)
        {
            Flat flats = new Flat();

            flats.Id = Guid.NewGuid().ToString();
            flats.Address = model.Address;
            flats.Floor = model.Floor;
            flats.Number = model.Number;
            flats.Photo = model.Photo;
            flats.Price = model.Price;
            flats.Rooms = model.Rooms;
            flats.Sold = model.Sold;
            flats.SquareId = model.SquareId;

            _context.flats.Add(flats);

            _context.SaveChanges();

            return new ResultDto
            {
                Status = 200,
                Message = "OK"
            };

        }


        [HttpGet]
        public IEnumerable<FlatDTO> getEmptyFlats()
        {
            List<FlatDTO> data = new List<FlatDTO>();

            var dataFromDB = _context.flats.Where(t => t.Sold == false).ToList();

            foreach (var item in dataFromDB)
            {
                FlatDTO temp = new FlatDTO();

                temp.Id = item.Id;
                temp.Address = item.Address;
                temp.Floor = item.Floor;
                temp.Number = item.Number;
                temp.Photo = item.Photo;
                temp.Price = item.Price;
                temp.Sold = item.Sold;
                temp.Rooms = item.Rooms;
                temp.SquareId = item.SquareId;
                

                data.Add(temp);
            }

            return data;


        }



        [HttpGet("getSoldFlats")]
        public IEnumerable<FlatDTO> getSoldFlats()
        {
            List<FlatDTO> data = new List<FlatDTO>();

            var dataFromDB = _context.flats.Where(t => t.Sold == true).ToList();

            foreach(var item in dataFromDB)
            {
                FlatDTO temp = new FlatDTO();

                temp.Id = item.Id;
                temp.Address = item.Address;
                temp.Floor = item.Floor;
                temp.Number = item.Number;
                temp.Photo = item.Photo;
                temp.Price = item.Price;
                temp.Sold = item.Sold;
                temp.Rooms = item.Rooms;
                temp.SquareId = item.SquareId;

                data.Add(temp);

            }

            return data;
        }



        [HttpGet("getAllFlats")]
        public IEnumerable<FlatDTO> getAllFlats()
        {
            List<FlatDTO> data = new List<FlatDTO>();

            var dataFromDB = _context.flats.ToList();

            foreach(var item in dataFromDB)
            {
                FlatDTO temp = new FlatDTO();

                temp.Id = item.Id;
                temp.Address = item.Address;
                temp.Floor = item.Floor;
                temp.Number = item.Number;
                temp.Photo = item.Photo;
                temp.Price = item.Price;
                temp.Rooms = item.Rooms;
                temp.Sold = item.Sold;
                temp.SquareId = item.SquareId;

                data.Add(temp);
            }
            return data;
        }


        [HttpPost("editFlat/{id}")]
        public ResultDto EditUser([FromRoute] string id, [FromBody] FlatDTO model)
        {
            var flats = _context.flats.FirstOrDefault(t => t.Id == id);


            flats.Address = model.Address;
            flats.Floor = model.Floor;
            flats.Number = model.Number;
            flats.Rooms = model.Rooms;
            flats.Sold = model.Sold;
            flats.SquareId = model.SquareId;
            flats.Id = model.Id;
            flats.Price = model.Price;
            flats.Photo = model.Photo;



            _context.SaveChanges();

            return new ResultDto
            {
                Status = 200,
                Message = "OK"
            };

        }

        [HttpGet("{id}")]
        public FlatDTO GetUser([FromRoute] string id)
        {
            var flat = _context.flats.FirstOrDefault(t => t.Id == id);


            FlatDTO model = new FlatDTO();
            flat.Id = model.Id;
            flat.Number = model.Number;
            flat.Photo = model.Photo;
            flat.Price = model.Price;
            flat.Rooms = model.Rooms;
            flat.Sold = model.Sold;
            flat.SquareId = model.SquareId;
            flat.Floor = model.Floor;
            flat.Address = model.Address;

            return model;
        }


    }
}
