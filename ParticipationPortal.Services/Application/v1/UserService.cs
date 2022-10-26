using AutoMapper;
using ParticipationPortal.Domain.Entities.v1;
using ParticipationPortal.Domain.Errors.v1.Users;
using ParticipationPortal.Domain.Repositories.v1;
using ParticipationPortal.Domain.RequestModels.v1.User;
using ParticipationPortal.Domain.ResponseModels.v1.User;
using ParticipationPortal.Domain.Services.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Services.Application.v1
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

        public async Task CreateAsync(string userId, AddUserRequestModel model)
        {
            if (await _userRepository.AnyAsync(userId))
                throw new AlreadyPresentUserException();

            model.FirebaseUserId = userId;
            var user = _mapper.Map<User>(model);

            var addedUser = _userRepository.Insert(user);
            await _userRepository.SaveAsync();
        }

        public async Task<GetUserByUserIdResponseModel> GetByUserIdAsync(string userId)
        {
            var result = new GetUserByUserIdResponseModel();
            User user = await _userRepository.GetByUserIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException();

            result.Data = _mapper.Map<UserByUserIdResponseModel>(user);
            return result;
        }
    }
}
