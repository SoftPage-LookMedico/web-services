using AutoMapper;
using LookMedico.API.Security.Domain.Models;
using LookMedico.API.Security.Domain.Repositories;
using LookMedico.API.Security.Domain.Services;
using LookMedico.API.Security.Domain.Services.Communication;
using LookMedico.API.Security.Exceptions;
using LookMedico.API.Shared.Domain.Repositories;
namespace LookMedico.API.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }



    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(string id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new AppException("User not found");
        return user;
    }



    public Task DeleteAsync(string id)
    {
        var user = GetById(id);
        try
        {
            _userRepository.Remove(user);
            return _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the user: {e.Message}");
        }
    }

    private User GetById(string id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task<UserResponse> SaveAsync(User user)
    {
        var existingUser = await _userRepository.FindByIdAsync(user.Id);

        if (existingUser != null)
            return new UserResponse("Username is already user");
        
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(user);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while saving the doctor: {e.Message}");
        }
    }
}
