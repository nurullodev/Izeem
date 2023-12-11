using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Entities.Suppliers;
using Izeem.Service.DTOs.Vehicles;
using Izeem.Service.Exceptions;
using Izeem.Service.Interfaces.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Izeem.Service.Services.Suppliers;

public class VehicleService : IVehicleService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Vehicle> _repository;
    public VehicleService(IRepository<Vehicle> repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<VehicleResultDto> AddAsync(VehicleCreationDto dto)
    {
        var mappedVehicle = _mapper.Map<Vehicle>(dto);
        await _repository.AddAsync(mappedVehicle);
        await _repository.SaveAsync();

        var result = _mapper.Map<VehicleResultDto>(mappedVehicle);
        return result;
    }

    public async Task<VehicleResultDto> ModifyAsync(VehicleUpdateDto dto)
    {
        Vehicle vehicle = await _repository.SelectAsync(u => u.Id.Equals(dto.Id))
            ?? throw new IzeemException(404, $"This vehicle is not found with ID = {dto.Id}");

        _mapper.Map(dto, vehicle);
        _repository.Update(vehicle);
        await _repository.SaveAsync();

        var result = _mapper.Map<VehicleResultDto>(vehicle);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Vehicle vehicle = await _repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new IzeemException(404, $"This vehicle is not found with ID = {id}");

        _repository.Delete(vehicle);
        await _repository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<VehicleResultDto>> RetrieveAllAsync()
    {
        var vehicle = await _repository.SelectAll().ToListAsync();
        var result = _mapper.Map<IEnumerable<VehicleResultDto>>(vehicle);
        return result;
    }

    public async Task<VehicleResultDto> RetrieveByIdAsync(long id)
    {
        Vehicle vehicle = await _repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new IzeemException(404, $"This vehicle is not found with ID = {id}");

        var result = _mapper.Map<VehicleResultDto>(vehicle);
        return result;
    }
}