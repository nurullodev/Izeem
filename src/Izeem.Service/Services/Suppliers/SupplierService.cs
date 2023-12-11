using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Entities.Suppliers;
using Izeem.Service.DTOs.Suppliers;
using Izeem.Service.Exceptions;
using Izeem.Service.Interfaces.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Izeem.Service.Services.Suppliers;

public class SupplierService : ISupplierService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Supplier> _repository;
    private readonly IRepository<Vehicle> _vehicleRepository;

    public SupplierService(IRepository<Supplier> repository, IMapper mapper, IRepository<Vehicle> vehicleRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _vehicleRepository = vehicleRepository;
    }

    public async Task<SupplierResultDto> AddAsync(SupplierCreationDto dto)
    {
        var existVehicle = await _vehicleRepository.SelectAsync(vehicle => vehicle.Id.Equals(dto.VehicleId))
            ?? throw new IzeemException(404, $"This vehicleId is not found with Id = {dto.VehicleId}");

        var supplier = await _repository.SelectAsync(c => c.Phone.Equals(dto.Phone));
        if (supplier is not null)
            throw new IzeemException(403, "This supplier is already exists");

        var mappedSupplier = _mapper.Map<Supplier>(dto);
        await _repository.AddAsync(mappedSupplier);
        await _repository.SaveAsync();

        return _mapper.Map<SupplierResultDto>(mappedSupplier);
    }

    public async Task<SupplierResultDto> ModifyAsync(SupplierUpdateDto dto)
    {
        var existSupplier = await _repository.SelectAsync(u => u.Id.Equals(dto.Id))
            ?? throw new IzeemException(404, $"This supplier is not found with ID = {dto.Id}");

        var existVehicle = await _vehicleRepository.SelectAsync(vehicle => vehicle.Id.Equals(dto.VehicleId))
            ?? throw new IzeemException(404, $"This vehicleId is not found with Id = {dto.VehicleId}");

        _mapper.Map(dto, existSupplier);
        _repository.Update(existSupplier);
        await _repository.SaveAsync();

        var result = _mapper.Map<SupplierResultDto>(existSupplier);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var existSupplier = await _repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new IzeemException(404, $"This supplier is not found with ID = {id}");

        _repository.Delete(existSupplier);
        await _repository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<SupplierResultDto>> RetrieveAllAsync()
    {
        var supplier = await _repository.SelectAll().ToListAsync();
        var result = _mapper.Map<IEnumerable<SupplierResultDto>>(supplier);
        return result;
    }

    public async Task<SupplierResultDto> RetrieveByIdAsync(long id)
    {
        var supplier = await _repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new IzeemException(404, $"This supplier is not found with ID = {id}");

        var result = _mapper.Map<SupplierResultDto>(supplier);
        return result;
    }
}