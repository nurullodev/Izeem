using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Configurations;
using Izeem.Domain.Entities.Addresses;
using Izeem.Service.DTOs.Addresses;
using Izeem.Service.Exceptions;
using Izeem.Service.Extensions;
using Izeem.Service.Interfaces.Addresses;

namespace Izeem.Service.Services.Addresses;

public class AddressService : IAddressService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Address> _addressRepository;
    public AddressService(
        IMapper mapper,
        IRepository<Address> addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }

    public async Task<AddressResultDto> AddAsync(AddressCreationDto dto)
    {
        var mappedAddress = _mapper.Map<Address>(dto);
        await _addressRepository.AddAsync(mappedAddress);
        await _addressRepository.SaveAsync();

        return _mapper.Map<AddressResultDto>(mappedAddress);
    }

    public async Task<AddressResultDto> ModifyAsync(AddressUpdateDto dto)
    {
        var existAddress = await _addressRepository.SelectAsync(r => r.Id.Equals(dto.Id))
            ?? throw new IzeemException(404, $"This id was not found with {dto.Id}");

        _mapper.Map(dto, existAddress);
        _addressRepository.Update(existAddress);
        await _addressRepository.SaveAsync();

        return _mapper.Map<AddressResultDto>(existAddress);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var existAddress = await _addressRepository.SelectAsync(r => r.Id.Equals(id))
            ?? throw new IzeemException(404, $"This id was not found with {id}");

        _addressRepository.Delete(existAddress);
        await _addressRepository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<AddressResultDto>> RetrieveAllAsync(PaginationParams pagination)
    {
        var addresses = _addressRepository.SelectAll()
            .ToPagedList(pagination);

        return _mapper.Map<IEnumerable<AddressResultDto>>(addresses);
    }

    public async Task<AddressResultDto> RetrieveByIdAsync(long id)
    {
        var existAddress = await _addressRepository.SelectAsync(p => p.Id.Equals(id))
            ?? throw new IzeemException(404, $"This id was not found with {id}");

        return _mapper.Map<AddressResultDto>(existAddress);
    }
}
