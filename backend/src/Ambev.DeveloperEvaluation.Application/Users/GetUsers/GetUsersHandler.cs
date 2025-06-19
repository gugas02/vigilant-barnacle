using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUsers;

/// <summary>
/// Handler for processing GetUsersCommand requests
/// </summary>
public class GetUsersHandler : IRequestHandler<GetUsersCommand, PaginatedList<GetUsersResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetUsersHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetUsersCommand</param>
    public GetUsersHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetUsersCommand request
    /// </summary>
    /// <param name="request">The GetUsers command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    public async Task<PaginatedList<GetUsersResult>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.ListAsync(request.Page, request.Size, request.Order, cancellationToken);
        if (user == null)
            throw new KeyNotFoundException($"There is no user registered.");

        return _mapper.Map<PaginatedList<GetUsersResult>>(user);
    }
}
