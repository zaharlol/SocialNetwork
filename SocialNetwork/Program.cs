using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL;
using SocialNetwork.PLL.Views;
using System;
using System.Linq;

namespace SocialNetwork
{
    class Program
    {
        static MessageService messageService;
        static UserService userService;
        static FriendSercive friendSercive;
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        public static AddFriendsView addFriendsView;
        public static QuantityFriendsView quantityFriendsView;

        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();
            friendSercive = new FriendSercive();

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService, userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();
            addFriendsView = new AddFriendsView(userService, friendSercive);
            quantityFriendsView = new QuantityFriendsView();

            while (true)
            {
                mainView.Show();
            }
        }
    }
}