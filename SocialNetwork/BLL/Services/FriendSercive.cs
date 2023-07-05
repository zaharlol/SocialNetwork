using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendSercive
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendSercive()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public IEnumerable<Friend> ListFriends(int friendId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(friendId).ToList()
                .ForEach(friend =>

            friends.Add(new Friend(friend.id, friend.friend_id, friend.user_id))
                );
        
                        return friends;
        }

        public void Add(AddFriend addFriend)
        {
            if (String.IsNullOrEmpty(addFriend.FriendEmail)) 
                throw new ArgumentNullException();

            var findEmail = this.userRepository.FindByEmail(addFriend.FriendEmail);
            if (findEmail == null) throw new UserNotFoundException();

            var friend = new FriendEntity
            {
                user_id = findEmail.id,
                friend_id = addFriend.UserId,
            };

            if (this.friendRepository.Create(friend) == 0)
                throw new Exception();
        }
    }
}