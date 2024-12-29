﻿namespace car_management_api.Services
{
    using car_management_api.Dtos;
    using car_management_api.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CarService : ICarService
    {
        private readonly DatabasebContext _context;

        public CarService(DatabasebContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseCarDto>> GetAllCars(string? carMake, int? garageId, int? fromYear, int? toYear)
        {
            var carsQuery = _context.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(carMake))
            {
                carsQuery = carsQuery.Where(c => c.Make.Contains(carMake));
            }

            if (garageId > 0)
            {
                carsQuery = carsQuery.Where(c => c.Garages.Any(g => g.Id == garageId));
            }

            if (fromYear > 0)
            {
                carsQuery = carsQuery.Where(c => c.ProductionYear >= fromYear);
            }

            if (toYear > 0)
            {
                carsQuery = carsQuery.Where(c => c.ProductionYear <= toYear);
            }

            var cars = await carsQuery.Include(c => c.Garages).ToListAsync();

            var responseCars = cars.Select(c => new ResponseCarDto
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                ProductionYear = c.ProductionYear,
                LicensePlate = c.LicensePlate,
                Garages = c.Garages.Select(g => new ResponseGarageDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    City = g.City,
                    Location = g.Location,
                    Capacity = g.Capacity,
                }).ToList(),
            }).ToList();

            return responseCars;
        }

        public async Task<ResponseCarDto> GetCarById(int id)
        {
            var carDto = await _context.Cars
                .Where(c => c.Id == id)
                .Select(c => new ResponseCarDto 
                { 
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    ProductionYear = c.ProductionYear,
                    LicensePlate = c.LicensePlate,
                    Garages = c.Garages.Select(g => new ResponseGarageDto
                    {
                        Id = g.Id,
                        Name = g.Name,
                        City = g.City,
                        Location = g.Location,
                        Capacity = g.Capacity,
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return carDto;
        }

        public async Task<ResponseCarDto> CreateCar(CreateCarDto carDto)
        {
            var garages = new List<Garage>();
            foreach (var garageId in carDto.GarageIds)
            {
                var garage = await _context.Garages.FirstOrDefaultAsync(g => g.Id == garageId);
                if (garage != null)
                {
                    garages.Add(garage);
                }
            }

            var car = new Car
            {
                Make = carDto.Make,
                Model = carDto.Model,
                ProductionYear = carDto.ProductionYear,
                LicensePlate = carDto.LicensePlate,
                Garages = garages
            };

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return await GetCarById(car.Id);
        }

        public async Task<ResponseCarDto> UpdateCar(int id, UpdateCarDto carDto)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                return null;
            }

            var garages = new List<Garage>();
            foreach (var garageId in carDto.GarageIds)
            {
                var garage = await _context.Garages.FirstOrDefaultAsync(g => g.Id == garageId);
                if (garage != null)
                {
                    garages.Add(garage);
                }
            }

            car.Make = carDto.Make;
            car.Model = carDto.Model;
            car.LicensePlate = carDto.LicensePlate;
            car.ProductionYear = carDto.ProductionYear;
            car.Garages = garages;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return await GetCarById(car.Id);
        }

        public async Task<bool> DeleteCar(int id)
        {
            var car = await _context.Cars.Include(c => c.Garages).FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                return false;
            }

            foreach (var garage in car.Garages.ToList())
            {
                car.Garages.Remove(garage);
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
