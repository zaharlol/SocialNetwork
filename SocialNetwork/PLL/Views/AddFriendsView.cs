using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendsView
    {
        UserService userService;
        FriendSercive friendSercive;
        public AddFriendsView(UserService userService, FriendSercive friendSercive)
        {
            this.userService = userService;
            this.friendSercive = friendSercive;
        }

        public void Show(User user)
        {
            var addFriend = new AddFriend();

            Console.WriteLine("Введите почту друга");
            addFriend.FriendEmail = Console.ReadLine();

            addFriend.UserId = user.Id;

            try
            {
                friendSercive.Add(addFriend);

                SuccessMessage.Show("Друг добавлен");

                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении!");
            }
        }
    }
}
